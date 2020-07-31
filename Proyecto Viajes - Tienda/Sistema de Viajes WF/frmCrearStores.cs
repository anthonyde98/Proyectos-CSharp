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
    public partial class frmCrearStores : Form
    {
        private int nums = 1111;
        public frmCrearStores()
        {
            InitializeComponent();
        }

        public frmCrearStores(string stor_id)
        {
            InitializeComponent();
            mostrarTabla(stor_id);
        }

        private void mostrarTabla(string stor_id)
        {
            Store objStore = new Store();
            objStore.Buscar(stor_id, true);

            textBox1.Text = stor_id;
            textBox2.Text = objStore.getstor_name();
            textBox3.Text = objStore.getstor_address();
            textBox4.Text = objStore.getstor_city();
            textBox5.Text = objStore.getstor_state();
            textBox6.Text = objStore.getstor_zip();
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

        private void button1_Click(object sender, EventArgs e)
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

        private void AgregarDatos()
        {
            Store objStore = new Store();
            if (objStore.Agregar("" + nums,
                               textBox2.Text,
                               textBox3.Text,
                               textBox4.Text,
                               textBox5.Text,
                               textBox6.Text))
            {
                MessageBox.Show("Exitoso....!!!!");
                button1.Text = "Agregar";
            }
            else
                MessageBox.Show(objStore.getMensaje());

            nums++;
        }

        private void Actualizar()
        {
            Store objStore = new Store();
            if (objStore.Actualizar(textBox1.Text,
                               textBox2.Text,
                               textBox3.Text,
                               textBox4.Text,
                               textBox5.Text,
                               textBox6.Text))
            {
                MessageBox.Show("Exitoso....!!!!");
            }
            else
                MessageBox.Show(objStore.getMensaje());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCrearStores_Load(object sender, EventArgs e)
        {

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
