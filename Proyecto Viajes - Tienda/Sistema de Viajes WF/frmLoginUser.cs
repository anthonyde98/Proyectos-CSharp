using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peralta100430840_WinX
{
    public partial class frmLoginUser : Form
    {
        private int who = 1;
        private bool acceso;
        private string user;
        private string pass;


        public frmLoginUser()
        {
            InitializeComponent();
        }

        public bool getAcceso() { return acceso; }
        public string getNombre() { return user; }
        public string getPassword() { return pass; }

        public void validacion()
        {
            string lv_str_laRuta = System.Configuration.ConfigurationManager.AppSettings["ruta_en_disk"];
            string mv_str_elNobreFisico = "UsuariosTienda.txt";
            StreamReader objFileActual = new StreamReader(lv_str_laRuta + "\\" + mv_str_elNobreFisico, true);
            string[] objLasLineas;
            string line;

            while (!objFileActual.EndOfStream)
            {
                try
                {
                    line = objFileActual.ReadLine();
                    objLasLineas = line.Split(' ');

                    string user = objLasLineas[0];
                    string pass = objLasLineas[1];
                  
                    if ((user == textBox1.Text) && (pass == textBox2.Text))
                    {
                        frmTitle Title = new frmTitle(7);
                        Title.MdiParent = this.MdiParent;
                        Title.WindowState = FormWindowState.Maximized;
                        Title.Show();

                        MainMenuForm Main = new MainMenuForm();
                        frmCarrito1 carrito = new frmCarrito1(user);
                        carrito.StartPosition = FormStartPosition.CenterScreen;
                        carrito.Show();

                        Main.cambiarTexto(user);

                        acceso = true;
                        objFileActual.Close();
                        goto etiqueta;
                    }
                    objLasLineas = null;
                    line = null;
                }
                catch(Exception objError)
                {
                    MessageBox.Show(objError.Message);
                }               
            }

            MessageBox.Show("Usuario o contraseña incorrecta.");

        etiqueta:
            objFileActual.Close();
            this.Close();
        }

        public void CrearUsuario()
        {
            string mv_str_elNobreFisico = "UsuariosTienda.txt";
            string p_str_line = textBox1.Text + " " + textBox2.Text;
            try
            {
                string lv_str_laRuta = System.Configuration.ConfigurationManager.AppSettings["ruta_en_disk"];
                StreamWriter objFileActual = new StreamWriter(lv_str_laRuta + "\\" + mv_str_elNobreFisico, true);
                objFileActual.WriteLine(p_str_line + "\n");
                objFileActual.Close();
                MessageBox.Show("Usuario creado exitosamente.");
            }

            catch (Exception objErrores)
            {
                MessageBox.Show(objErrores.ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label1.Text = "Crear Usuario";
            button1.Text = "Crear";
            label4.Visible = false;

            who = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (who == 0)
            {
                CrearUsuario();
                who = 1;
                label1.Text = "Login";
                button1.Text = "Ingresar";
            }
            else
                validacion();
        }

        public override string ToString()
        {
            string lv_str_display = user;
            return lv_str_display;
        }
    }
}
