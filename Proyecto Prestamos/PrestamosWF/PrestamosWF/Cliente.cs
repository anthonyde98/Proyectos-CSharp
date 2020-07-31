using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace PrestamosWF
{
    class Cliente
    {
        DataSet ultimo;
        DataSet cliente;

        private string nombre, apellido, telefono, cedula, direccion, dataCredito, nickName;
        private int estado, codigo, usuario;

        public Cliente()
        {

        }
        public Cliente(int p_codigo, string p_nombre, string p_apellido, string p_telefono, string p_cedula, string p_direccion, string p_dataCredito, int p_estado, int p_usuario, string p_nickName)
        {
            codigo = p_codigo;
            cedula = p_cedula;
            nombre = p_nombre;
            apellido = p_apellido;
            direccion = p_direccion;
            telefono = p_telefono;
            dataCredito = p_dataCredito;
            estado = p_estado;
            usuario = p_usuario;
            nickName = p_nickName;
        }

        public bool agregar()
        {
            bool identificador;
            try
            {
                ConexionSQL.Ejecutar(string.Format("Insert into cliente(codigo, nombre, apellido, telefono, cedula, direccion, dataCredito, estado) values ({0},'{1}','{2}','{3}','{4}','{5}','{6}', {7})", codigo, nombre, apellido, telefono, cedula, direccion, dataCredito, estado));
                ConexionSQL.Ejecutar(string.Format("Insert into cambio(usuario, evento, fecha, tabla, descripcion) values ({0}, 'Insert', GETDATE(), 'Cliente', 'El usuario {1} creó un nuevo cliente. Codigo: {2} Nombre: {3} {4} Cedula: {5}')", usuario, nickName, codigo, nombre, apellido, cedula));
                identificador = true;
            }
            catch (Exception e) { identificador = false; }
            return identificador;


        }

        public DataSet buscar(int p_codigo)
        {
            DataSet data = ConexionSQL.Ejecutar(string.Format("SELECT * FROM cliente Where codigo = {0}", p_codigo));

            return data;
        }

        public bool eliminar() { throw new NotImplementedException(); }
        public DataSet LlenarDataGrid(string tabla)
        {
            DataSet dataTabla = ConexionSQL.Ejecutar(string.Format("SELECT * FROM " + tabla));

            return dataTabla;
        }

        public DataSet listarClientes()
        {
            DataSet Clientes = ConexionSQL.Ejecutar(string.Format("SELECT * FROM cliente"));

            return Clientes;
        }

        public DataSet consultar(string p_nombre)
        {
            DataSet data = ConexionSQL.Ejecutar(string.Format("SELECT * FROM cliente Where nombre like '%{0}%'", p_nombre));

            return data;
        }

        public DataSet consultarPagoSiguiente(string p_nombre)
        {
            DataSet data = ConexionSQL.Ejecutar(string.Format("select PagoSiguiente.idPagoSiguiente, cliente.nombre, cliente.apellido, PagoSiguiente.prestamo, PagoSiguiente.cantidad, PagoSiguiente.fechaPagar, PagoSiguiente.codigo from PagoSiguiente join Prestamo on PagoSiguiente.prestamo = Prestamo.idPrestamo join cliente on Prestamo.cliente = cliente.idCliente where Cliente.nombre like '%{0}%'", p_nombre));

            return data;
        }

        public DataSet consultarPagoRetrasado(string p_nombre)
        {
            DataSet data = ConexionSQL.Ejecutar(string.Format("select PagoRetrasado.idPagoRetrasado, cliente.nombre, cliente.apellido, PagoRetrasado.prestamo, PagoRetrasado.cantidad, PagoRetrasado.fechaSupuestaPagar, PagoRetrasado.codigo from PagoRetrasado join Prestamo on PagoRetrasado.prestamo = Prestamo.idPrestamo join cliente on Prestamo.cliente = cliente.idCliente where  Cliente.nombre like '%{0}%'", p_nombre));

            return data;
        }

        public bool actualizar()
        {
            bool identificador;
            try
            {
                 
                ConexionSQL.Ejecutar(string.Format("Update cliente set nombre = '{0}', apellido = '{1}', telefono = '{2}', direccion = '{3}', dataCredito = '{4}', estado = {5} where cedula = '{6}'", nombre, apellido, telefono, direccion, dataCredito, estado, cedula));
                ConexionSQL.Ejecutar(string.Format("Insert into cambio(usuario, evento, fecha, tabla, descripcion) values ({0}, 'Update', GETDATE(), 'Cliente', 'El usuario {1} actualizó un cliente. Codigo: {2} Nombre: {3} {4} Cedula: {5}')", usuario, nickName, codigo, nombre, apellido, cedula));

                identificador = true;
            }
            catch (Exception e) { identificador = false; }
            return identificador;


        }

        public DataSet ultimoCliente()
        {
            ultimo = ConexionSQL.Ejecutar(string.Format("SELECT TOP 1 * FROM cliente ORDER BY idCliente DESC"));
            return ultimo;
        }

        public DataSet buscarCliente(int id)
        {
            cliente = ConexionSQL.Ejecutar(string.Format("SELECT * FROM cliente WHERE idCliente = {0}", id));
            return cliente;
        }

        public DataSet buscarClienteId(int codigo)
        {
            cliente = ConexionSQL.Ejecutar(string.Format("SELECT * FROM cliente WHERE codigo = {0}", codigo));
            return cliente;
        }

        public DataSet buscarPrestamos(int id)
        {
            ultimo = ConexionSQL.Ejecutar(string.Format("Select * from prestamo Where cliente = {0}", id));
            return ultimo;
        }


        public DataSet buscarPago(int id)
        {
            ultimo = ConexionSQL.Ejecutar(string.Format("Select * from pago Where prestamo = {0}", id));
            return ultimo;
        }

        public DataSet buscarPagoSiguiente(int id)
        {
            ultimo = ConexionSQL.Ejecutar(string.Format("Select * from pagoSiguiente Where prestamo = {0}", id));
            return ultimo;
        }

        public DataSet buscarPagoRetrasado(int id)
        {
            ultimo = ConexionSQL.Ejecutar(string.Format("Select * from pagoRetrasado Where prestamo = {0}", id));
            return ultimo;
        }
    }
}
