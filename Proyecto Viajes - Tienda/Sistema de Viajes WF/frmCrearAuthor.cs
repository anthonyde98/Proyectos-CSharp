using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Peralta100430840_TiendaX.Pubs;

namespace Peralta100430840_WinX
{
    public partial class frmCrearAuthor : Form
    {
        private int numa = 100;
        public frmCrearAuthor()
        {
            InitializeComponent();
        }

        public frmCrearAuthor(string au_id)
        {
            InitializeComponent();
            mostrarTabla(au_id);
        }

        private void mostrarTabla(string au_id)
        {
            Author objAuthor = new Author();
            objAuthor.Buscar(au_id, true);

            

            textBox1.Text = au_id;
            textBox2.Text = objAuthor.getau_lastname();
            textBox3.Text = objAuthor.getau_firstname();
            textBox4.Text = objAuthor.getphone();
            textBox5.Text = objAuthor.getaddress();
            textBox6.Text = objAuthor.getcity();
            textBox7.Text = objAuthor.getstate();
            textBox8.Text = objAuthor.getzip();
            if (objAuthor.getcontract() == 0)
                comboBox1.Text = "Si";
            else
                comboBox1.Text = "No";
            
            
        }

        private void limpiarControles()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
            }

            comboBox1.Text = "";
        }

        private void AgregarDatos()
        {
            Author objAuthor = new Author();
            if (objAuthor.Agregar(numa + "-" + 88 + "-" + numa,
                               textBox2.Text,
                               textBox3.Text,
                               textBox4.Text,
                               textBox5.Text,
                               textBox6.Text,
                               textBox7.Text,
                               textBox8.Text,
                               comboBox1.SelectedIndex))
            {
                MessageBox.Show("Exitoso....!!!!");
                button1.Text = "Limpiar";
            }
            else
                MessageBox.Show(objAuthor.getMensaje());

            numa++;
        }

        private void ActualizarDatos()
        {
            Author objAuthor = new Author();
            if (objAuthor.Actualizar(textBox1.Text,
                               textBox2.Text,
                               textBox3.Text,
                               textBox4.Text,
                               textBox5.Text,
                               textBox6.Text,
                               textBox7.Text,
                               textBox8.Text,
                               comboBox1.SelectedIndex))
            {
                MessageBox.Show("Exitoso....!!!!");
                button1.Text = "Limpiar";
            }
            else
                MessageBox.Show(objAuthor.getMensaje());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (button1.Text == "Limpiar")
            {
                limpiarControles();
                button1.Text = "Agregar";
            }
            else
            {
                AgregarDatos();
            }
        }
    }
}
