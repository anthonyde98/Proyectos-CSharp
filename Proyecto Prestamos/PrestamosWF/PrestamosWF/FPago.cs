using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrestamosWF
{
    public partial class FPago : Form
    {
        Pago Pagos;
        DataSet datos;
        private string tabla;
        private int cliente, prestamo, pago;
        public FPago()
        {
            InitializeComponent();
        }

        private void FPago_Load(object sender, EventArgs e)
        {
            cargarDataGrid("pago");
            comboBox1.SelectedIndex = 0;
        }

        private void cargarDataGrid(string tabla)
        {
            this.tabla = tabla;

            Pagos = new Pago();

            if (tabla == "Clientes")
            {
                Cliente Clientes = new Cliente();
                dataGridView1.DataSource = Clientes.LlenarDataGrid("cliente").Tables[0];
            }
            else if(tabla == "Pagos realizados")
            {
                dataGridView1.DataSource = Pagos.LlenarDataGrid("Pago").Tables[0];
            }
            else if(tabla == "Pagos siguientes")
            {
                dataGridView1.DataSource = Pagos.LlenarDataGrid("PagoSiguiente").Tables[0];
            }
            else if(tabla == "Pagos retrasados")
            {
                dataGridView1.DataSource = Pagos.LlenarDataGrid("PagoRetrasado").Tables[0];
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(Convert.ToString(comboBox1.SelectedItem) == "Clientes")
            {
                Cliente Clientes = new Cliente();
                datos = Clientes.consultar(textBox1.Text);
                dataGridView1.DataSource = datos.Tables[0];
            }           
            else if(Convert.ToString(comboBox1.SelectedItem) == "Pagos Retrasados")
            {
                Cliente Clientes = new Cliente();
                datos = Clientes.consultarPagoRetrasado(textBox1.Text);
                dataGridView1.DataSource = datos.Tables[0];
            }
            else if(Convert.ToString(comboBox1.SelectedItem) == "Pagos Siguientes")
            {
                Cliente Clientes = new Cliente();
                datos = Clientes.consultarPagoSiguiente(textBox1.Text);
                dataGridView1.DataSource = datos.Tables[0];
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDataGrid(Convert.ToString(comboBox1.SelectedItem));
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            if(tabla == "Pago")
            {
                Cliente Clientes = new Cliente();
                dataGridView1.DataSource = Clientes.buscarPrestamos(prestamo).Tables[0];
                tabla = "Prestamos";
            }
            else if(tabla == "Prestamos")
            {
                Cliente Clientes = new Cliente();
                dataGridView1.DataSource = Clientes.buscarCliente(cliente).Tables[0];
                tabla = "Clientes";
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (tabla == "Clientes")
                {
                    cliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Cliente Clientes = new Cliente();
                    dataGridView1.DataSource = Clientes.buscarPrestamos(cliente).Tables[0];
                    tabla = "Prestamos";
                }
                else if (tabla == "Prestamos")
                {
                    prestamo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Cliente Clientes = new Cliente();
                    dataGridView1.DataSource = Clientes.buscarPago(prestamo).Tables[0];
                    tabla = "Pago";
                }
                else if (tabla == "Pagos Siguientes")
                {
                    try { pago = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); } 
                    catch { MessageBox.Show("Hubo un error al seleccionar el elemento."); }

                    string cliente;
                    Pago accesoPago = new Pago();
                    cliente = accesoPago.consultarPagoSiguiente(Convert.ToInt32(accesoPago.buscarPagoSiguiente(pago).Tables[0].Rows[0]["prestamo"])).Tables[0].Rows[0]["nombre"].ToString();

                    NuevoPago decision = new NuevoPago(cliente);
                    if (decision.Desicion())
                    {
                        try
                        {
                            Usuario Usuarios = new Usuario();
                            
                            Pago Pagos = new Pago();
                            datos = Pagos.buscarPagoSiguiente(pago);
                            Pagos = new Pago(Convert.ToInt32(datos.Tables[0].Rows[0]["codigo"].ToString()), Login.id, Convert.ToInt32(datos.Tables[0].Rows[0]["prestamo"].ToString()), (float)Convert.ToDouble(datos.Tables[0].Rows[0]["cantidad"].ToString()), DateTime.Now, Usuarios.buscarUsuario(Login.id).Tables[0].Rows[0]["nickName"].ToString());

                            if (Pagos.agregarPago())
                                Pagos.actualizarPagoS(Pagos.agregarPago(), pago);
                        }
                        catch
                        {
                            MessageBox.Show("Hubo un error al efectuar el pago.");
                        }
                    }

                    
                    Prestamo prestamo = new Prestamo();
                    float monto = (float)prestamo.buscarPrestamo(Convert.ToInt32(accesoPago.buscarPagoSiguiente(pago).Tables[0].Rows[0]["prestamo"])).Tables[0].Rows[0]["cantidadDebe"];
                    if (monto == 0)
                    {
                        if (prestamo.desactivarPrestamo(Convert.ToInt32(accesoPago.buscarPagoSiguiente(pago).Tables[0].Rows[0]["prestamo"])))
                        {
                            MessageBox.Show("El prestamo ha sigo pagado en su totalidad.");
                        }
                        else
                        {
                            MessageBox.Show("Hubo un error desactivando el pago.");
                        }

                    }
                    else
                    {
                        int tmeses;
                        monto = (float)prestamo.buscarPrestamo(Convert.ToInt32(accesoPago.buscarPagoSiguiente(pago).Tables[0].Rows[0]["prestamo"])).Tables[0].Rows[0]["cantidadPagar"];
                        tmeses = Convert.ToInt32(prestamo.buscarPrestamo(Convert.ToInt32(accesoPago.buscarPagoSiguiente(pago).Tables[0].Rows[0]["prestamo"])).Tables[0].Rows[0]["tiempoMeses"]);
                        Pagos = new Pago(Convert.ToInt32(accesoPago.buscarPagoSiguiente(pago).Tables[0].Rows[0]["prestamo"]), monto / tmeses);
                        DateTime MesSigte = DateTime.Now.AddMonths(1);
                        if (Pagos.agregarPagoSiguiente())
                        {
                            MessageBox.Show("Debe de pagar la cantidad de " + monto / tmeses + " RD$ en la fecha " + MesSigte + ". Si no realiza el pago en esta fecha, deberá de pagar un cargo del 5% del pago.");
                        }
                        else
                            MessageBox.Show("Hubo un error al agregar el siguiente pago");
                    }
                }
                else if (tabla == "Pagos Retrasados")
                {
                    try { pago = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); }
                    catch { MessageBox.Show("Hubo un error al seleccionar el elemento."); }

                    string cliente;
                    Pago accesoPago = new Pago();
                    cliente = accesoPago.consultarPagoRetrasado(Convert.ToInt32(accesoPago.buscarPagoRetrasado(pago).Tables[0].Rows[0]["prestamo"])).Tables[0].Rows[0]["nombre"].ToString();
                    float recargo = (float)accesoPago.buscarPagoRetrasado(pago).Tables[0].Rows[0]["cantidad"] * 0.05f;
                    float NuevaCantidad = recargo + (float)accesoPago.buscarPagoRetrasado(pago).Tables[0].Rows[0]["cantidad"];
                    NuevoPago decision = new NuevoPago(cliente, recargo);
                    if (decision.Desicion())
                    {
                        try
                        {
                            Usuario Usuarios = new Usuario();

                            Pago Pagos = new Pago();
                            datos = Pagos.buscarPagoRetrasado(pago);
                            Pagos = new Pago(Convert.ToInt32(datos.Tables[0].Rows[0]["codigo"].ToString()), Login.id, Convert.ToInt32(datos.Tables[0].Rows[0]["prestamo"].ToString()), NuevaCantidad, DateTime.Now, Usuarios.buscarUsuario(Login.id).Tables[0].Rows[0]["nickName"].ToString());

                            if (Pagos.agregarPago())
                                Pagos.actualizarPagoR(Pagos.agregarPago(), pago, recargo);
                        }
                        catch
                        {
                            MessageBox.Show("Hubo un error al efectuar el pago.");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Hubo un error al seleccionar este elemento.");
            }
        }
    }
}
