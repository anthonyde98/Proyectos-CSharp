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
    public partial class Login : Form
    {
        Usuario objetoUsuario;
        public static string usuario;
        public static int nivel, id;
        private int verf;

        public Login()
        {
            InitializeComponent();
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            verf = 0;
            objetoUsuario = new Usuario();
            DataSet datos = objetoUsuario.logear();
            Personal employee = new Personal();

            for (int x = 0; x < datos.Tables[0].Rows.Count; x++)
            {
                if (textUser.Text == datos.Tables[0].Rows[x]["nickName"].ToString() && textPass.Text == datos.Tables[0].Rows[x]["contrasena"].ToString())
                {
                    verf = 1;
                    usuario = datos.Tables[0].Rows[x]["nickName"].ToString();
                    id = Convert.ToInt32(datos.Tables[0].Rows[x]["idUsuario"]);
                    nivel = Convert.ToInt32(datos.Tables[0].Rows[x]["nivel"]);

                    if (employee.buscarUsuario(id))
                    {
                        this.Hide();
                        Inicio principal = new Inicio();
                        principal.Show();
                    }
                    else
                    {
                        MessageBox.Show("Este usuario no ha sido relacionado con un empleado.");
                    }
                }
            }

            if(verf == 0)
            {
                MessageBox.Show("Datos incorrectos.");
                textPass.Clear();
                textUser.Clear();
            }            
        }

        private void btnCr_Click(object sender, EventArgs e)
        {
            verf = 0;
            objetoUsuario = new Usuario();
            DataSet datos = objetoUsuario.logear();

            for (int x = 0; x < datos.Tables[0].Rows.Count; x++)
            {
                if (textUser.Text == datos.Tables[0].Rows[x]["nickName"].ToString() && textPass.Text == datos.Tables[0].Rows[x]["contrasena"].ToString())
                {
                    verf = 1;
                    usuario = datos.Tables[0].Rows[x]["nickName"].ToString();
                    id = Convert.ToInt32(datos.Tables[0].Rows[x]["idUsuario"]);
                    nivel = Convert.ToInt32(datos.Tables[0].Rows[x]["nivel"]);
                    
                    if(nivel == 1)
                    {                        
                        this.Hide();
                        CrearUsuario CrearUser = new CrearUsuario();
                        CrearUser.Show();
                    }
                    else
                        MessageBox.Show("No tienes permiso para crear un usuario.");

                }               
            }

            if (verf == 0)
            {
                MessageBox.Show("Datos incorrectos.");
                textPass.Clear();
                textUser.Clear();
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
