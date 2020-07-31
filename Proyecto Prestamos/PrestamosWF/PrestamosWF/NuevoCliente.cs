using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PrestamosWF
{
    public partial class NuevoCliente : Form
    {
        DataSet Clientes;
        Cliente Cliente;
        private int id;

        public NuevoCliente()
        {
            InitializeComponent();

            checkBoxE.Visible = false;
        }

        public NuevoCliente(int id)
        {
            this.id = id;
            InitializeComponent();

            btnAccion.Text = "Actualizar";

            if (Login.nivel != 1)
            {
                checkBoxE.Visible = false;
            }

            Cliente = new Cliente();
            Clientes = Cliente.buscarCliente(id);
            textBoxN.Text = Clientes.Tables[0].Rows[0]["nombre"].ToString();
            textBoxA.Text = Clientes.Tables[0].Rows[0]["apellido"].ToString();
            textBoxT.Text = Clientes.Tables[0].Rows[0]["telefono"].ToString();
            textBoxC.Text = Clientes.Tables[0].Rows[0]["cedula"].ToString();
            textBoxD.Text = Clientes.Tables[0].Rows[0]["direccion"].ToString();
            textBoxR.Text = Clientes.Tables[0].Rows[0]["dataCredito"].ToString();
            checkBoxE.Checked = Convert.ToBoolean(Clientes.Tables[0].Rows[0]["estado"].ToString());

            //No editables

            textBoxC.ReadOnly = true;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void NuevoCliente_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            Cliente = new Cliente();
            Usuario usuarioName = new Usuario();
            DataSet datos = Cliente.listarClientes();
            DataSet ultimo = Cliente.ultimoCliente();
            DataSet infoAct = Cliente.buscarCliente(id);
            DataSet usuario = usuarioName.buscarUsuario(Login.id);
            DataSet Fila = ConexionSQL.Ejecutar(string.Format("select Row from (SELECT ROW_NUMBER() OVER(ORDER BY idCliente) AS Row, idCliente from Cliente) Row where idCliente = {0}", id));

            if (btnAccion.Text == "Actualizar")
            {
                int verf = 1;

                for (int x = 0; x < datos.Tables[0].Rows.Count; x++)
                {
                    if (x + 1 == Convert.ToInt32(Fila.Tables[0].Rows[x]["Row"].ToString()))
                        x++;
                    if (textBoxC.Text == datos.Tables[0].Rows[x]["cedula"].ToString())
                    {
                        verf = 0;
                    }
                }
                if (verf == 0)
                {
                MessageBox.Show(textBoxC.Text + " ya hay un cliente con esta identificación.");
                }
                else
                {
                    int codigo = Convert.ToInt32(infoAct.Tables[0].Rows[0]["codigo"].ToString());
                    string nickName = usuario.Tables[0].Rows[0]["nickName"].ToString();
                    int idModificador = Login.id;
                    int estado;
                    if (checkBoxE.Checked)
                        estado = 1;
                    else
                        estado = 0;

                    Cliente = new Cliente(codigo, textBoxN.Text, textBoxA.Text, textBoxT.Text, textBoxC.Text, textBoxD.Text, textBoxR.Text, estado, idModificador, nickName);

                    if (Cliente.actualizar())
                    {
                        string mensaje = "Cliente actualizado con exito.";
                        MessageBox.Show(mensaje);

                    }
                    else
                        MessageBox.Show("Cliente no actualizado.");
                }

                
            }
            else
            {
                int verf = 1;

                for (int x = 0; x < datos.Tables[0].Rows.Count; x++)
                {
                    if (textBoxC.Text == datos.Tables[0].Rows[x]["cedula"].ToString())
                    {
                        verf = 0;
                    }
                }
                if (verf == 0)
                {
                MessageBox.Show(textBoxC.Text + " ya hay un cliente con esta identificación.");
                }
                else
                {
                    string nickName = usuario.Tables[0].Rows[0]["nickName"].ToString();
                    int idModificador = Login.id;
                    int codigo;

                    try
                    {
                        codigo = int.Parse(ultimo.Tables[0].Rows[0]["codigo"].ToString());

                    }
                    catch
                    {
                        codigo = 100;
                    }
                    Cliente = new Cliente(codigo + 1, textBoxN.Text, textBoxA.Text, textBoxT.Text, textBoxC.Text, textBoxD.Text, textBoxR.Text, 1, idModificador, nickName);
                    if (Cliente.agregar())
                    {
                        string mensaje = "Cliente agregado con exito.";
                        MessageBox.Show(mensaje);

                    }
                    else
                        MessageBox.Show("Cliente no agregado.");

                }   
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxC_MouseEnter(object sender, EventArgs e)
        {
            if (btnAccion.Text == "Actualizar")
            {
                textBoxC.BackColor = Color.Red;
                textBoxC.ForeColor = Color.White;
            }
        }
    }
}
