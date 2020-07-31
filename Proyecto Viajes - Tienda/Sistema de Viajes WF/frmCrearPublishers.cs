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
    public partial class frmCrearPublishers : Form
    {
        private int nump = 1001;
        public frmCrearPublishers()
        {
            InitializeComponent();
        }

        public frmCrearPublishers(string pub_id)
        {
            InitializeComponent();
            mostrarTabla(pub_id);
        }

        private void mostrarTabla(string pub_id)
        {
            Publishers objPublishers = new Publishers();
            objPublishers.Buscar(pub_id, true);

            textBox1.Text = pub_id;
            textBox2.Text = objPublishers.getpub_name();
            textBox3.Text = objPublishers.getcity();
            textBox4.Text = objPublishers.getstate();
            textBox5.Text = objPublishers.getcountry();
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
        }

        private void AgregarDatos()
        {
            Publishers objPublishers = new Publishers();
            if (objPublishers.Agregar("" + nump,
                               textBox2.Text,
                               textBox3.Text,
                               textBox4.Text,
                               textBox5.Text))
            {
                MessageBox.Show("Exitoso....!!!!");
                button1.Text = "Agregar";
            }
            else
                MessageBox.Show(objPublishers.getMensaje());

            nump++;
        }

        private void Actualizar()
        {
            Publishers objPublishers = new Publishers();
            if (objPublishers.Actualizar(textBox1.Text,
                               textBox2.Text,
                               textBox3.Text,
                               textBox4.Text,
                               textBox5.Text))
            {
                MessageBox.Show("Exitoso....!!!!");
            }
            else
                MessageBox.Show(objPublishers.getMensaje());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Actualizar();
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
