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
    public partial class frmCrearJobs : Form
    {
        private int numj = 15;
        public frmCrearJobs()
        {
            InitializeComponent();
        }

        public frmCrearJobs(string Job_id)
        {
            InitializeComponent();
            mostrarTabla(Job_id);
        }

        private void mostrarTabla(string Job_id)
        {
            Jobs objJobs = new Jobs();
            objJobs.Buscar(Job_id, true);

            textBox1.Text = Job_id;
            textBox2.Text = objJobs.getjob_desc();
            textBox3.Text = objJobs.getmin_lvl();
            textBox4.Text = objJobs.getmax_lvl();
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
            Jobs objJobs = new Jobs();
            if (objJobs.Agregar("" + numj,
                               textBox2.Text,
                               textBox3.Text,
                               textBox4.Text))
            {
                MessageBox.Show("Exitoso....!!!!");
                button1.Text = "Agregar";
            }
            else
                MessageBox.Show(objJobs.getMensaje());

            numj++;
        }

        private void Actualizar()
        {
            Jobs objJobs = new Jobs();
            if (objJobs.Actualizar(textBox1.Text,
                               textBox2.Text,
                               textBox3.Text,
                               textBox4.Text))
            {
                MessageBox.Show("Exitoso....!!!!");
            }
            else
                MessageBox.Show(objJobs.getMensaje());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void button3_Click_1(object sender, EventArgs e)
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