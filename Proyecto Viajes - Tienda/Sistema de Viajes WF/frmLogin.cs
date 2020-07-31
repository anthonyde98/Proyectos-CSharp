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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal MenuPrincipal = new frmMenuPrincipal();
            MenuPrincipal.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string admin = textBox1.Text;
                string contra = textBox2.Text;

                if (DataInterface.ExisteArchivo("Contraseña.txt"))
                {
                    if (DataInterface.Desencriptar("Contraseña.txt") == contra &&
                    DataInterface.Desencriptar("Usuario.txt") == admin)
                    {
                        MainMenuForm objMainMenuForm = new MainMenuForm(1);
                        objMainMenuForm.Show();
                    }

                    else
                        MessageBox.Show(" Usuario o Contraseña incorrecta.\n\nIntentelo de nuevo.");
                }
                else
                    MessageBox.Show("Ha Ocurrido un error en el inicio.\n\nPor favor intentelo de nuevo más tarde.");
            }
            catch(Exception objError)
            {
                MessageBox.Show(objError.ToString());
            }            
        }
    }
}
