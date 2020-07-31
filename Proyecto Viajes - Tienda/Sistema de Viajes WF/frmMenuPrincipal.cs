using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Peralta100430840_lib1.IOAqui;

namespace Peralta100430840_WinX
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {          
            if (DataInterface.ExisteArchivo("Contraseña.txt") && DataInterface.ExisteArchivo("Boleta.txt") &&
                        DataInterface.ExisteArchivo("Avion.txt") && DataInterface.ExisteArchivo("Piloto.txt") &&
                        DataInterface.ExisteArchivo("Aeropuerto.txt"))
            {
                MainMenuForm objMenu = new MainMenuForm(0);
                objMenu.WindowState = FormWindowState.Maximized;
                objMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("El administrador debe subir el sistema, presione una tecla para continuar...");
            }

            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmLogin objLogin = new frmLogin();
            objLogin.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            MainMenuForm objMenu = new MainMenuForm(0);
            objMenu.WindowState = FormWindowState.Maximized;

            if (DataInterface.ExisteArchivo("Contraseña.txt") && DataInterface.ExisteArchivo("Boleta.txt") &&
                        DataInterface.ExisteArchivo("Avion.txt") && DataInterface.ExisteArchivo("Piloto.txt") &&
                        DataInterface.ExisteArchivo("Aeropuerto.txt"))
            {
                objMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("El administrador debe subir el sistema, presione una tecla para continuar...");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frmLogin objLogin = new frmLogin();
            objLogin.Show();
            this.Hide();
        }
    }
}
