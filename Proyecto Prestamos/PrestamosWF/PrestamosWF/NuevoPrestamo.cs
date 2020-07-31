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
    public partial class NuevoPrestamo : Form
    {
        Prestamo Prestamos;
        Cliente Clientes;
        DataSet datos;
        private int id;
        private int meses, tasa;
        private float cantidadPrestada, interes, cantidadPagar;
        private DateTime fechaActual,fechaFinal;

        public NuevoPrestamo()
        {
            InitializeComponent();
        }

        public NuevoPrestamo(int id)
        {
            InitializeComponent();

            this.id = id;

            Clientes = new Cliente();
            datos = Clientes.buscarCliente(id);

            textBoxCl.Text = datos.Tables[0].Rows[0]["nombre"].ToString() + " " + datos.Tables[0].Rows[0]["apellido"].ToString();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnAccion_Click(object sender, EventArgs e)
        {
            Usuario usuarios = new Usuario();
            datos = usuarios.buscarUsuario(Login.id);
            int codigo;

            try
            {
                codigo = Convert.ToInt32(Prestamos.ultimoPrestamo().Tables[0].Rows[0]["codigo"]);
            }
            catch
            {
                codigo = 100;
            }
            
            float tasap = (float)(tasa) / 100;

            Prestamos = new Prestamo(cantidadPrestada, cantidadPagar, cantidadPagar, tasap, interes, 1, +1, id, Login.id, meses, fechaActual, fechaFinal, datos.Tables[0].Rows[0]["nickName"].ToString());


            if (Prestamos.agregar())
            {
                MessageBox.Show("Prestamo agregado.");
            }
            else
                MessageBox.Show("Hubo un error al agregar el prestamo.");
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void NuevoPrestamo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            cantidadPrestada = (float)Convert.ToDouble(textBoxCa.Text);
            meses = Convert.ToInt32(textBoxT.Text);
            tasa = Convert.ToInt32(textBoxTa.Text);
            interes = cantidadPrestada * ((float)tasa / 100) * ((float)meses / 12);
            cantidadPagar = cantidadPrestada + interes;
            fechaActual = DateTime.Today;
            fechaFinal = fechaActual.AddMonths(meses);
            
            //label
            labelCantidad.Text = Convert.ToString(cantidadPrestada) + " RD$";
            labelInteres.Text = Convert.ToString(interes) + " RD$";
            labeltasa.Text = Convert.ToString(tasa) + " %";
            labelPagar.Text = Convert.ToString(cantidadPagar) + " RD$";

            dateTimeT.Value = fechaFinal;
        }
    }
}
