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
    public partial class frmCrearTitle : Form
    {
        private int numt = 1110;
        public frmCrearTitle()
        {
            InitializeComponent();
            llenarCombobox();
        }

        public frmCrearTitle(string title_id)
        {
            InitializeComponent();
            mostrarTabla(title_id);
        }

        private void mostrarTabla(string title_id)
        {
            Titles objBook = new Titles();
            objBook.Buscar(title_id, true);
            llenarCombobox();

            textBox1.Text = title_id;
            textBox2.Text = objBook.gettitle();
            comboBox1.Text = objBook.gettype();
            comboBox2.Text = objBook.getPub_Name();
            textBox3.Text = objBook.getprice().ToString();
            textBox4.Text = objBook.getadvance().ToString();
            textBox5.Text = objBook.getroyalty().ToString();
            textBox6.Text = objBook.gettytd_sales().ToString();
            richTextBox1.Text = objBook.getnotes().ToString();
            dateTimePicker1.Text = objBook.getpubdate().ToString();
        }

        private void llenarCombobox()
        {
            Titles objBook = new Titles();
            DataTable objTablePub = objBook.getEditora();
            comboBox2.DataSource = objTablePub;
            comboBox2.DisplayMember = "pub_name";
            comboBox2.ValueMember = "pub_id";

            DataTable objDataGenero = objBook.getGenero();
            comboBox1.DataSource = objDataGenero;
            comboBox1.DisplayMember = "Type";
            comboBox1.ValueMember = "Type";
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
            comboBox2.Text = "";

            dateTimePicker1.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Limpiar")
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
            Titles objBook = new Titles();
            if (objBook.Agregar("AP" + numt,
                               textBox2.Text,
                               comboBox1.Text,
                               comboBox2.SelectedValue.ToString(),
                               float.Parse(textBox3.Text),
                               int.Parse(textBox4.Text),
                               int.Parse(textBox5.Text),
                               int.Parse(textBox6.Text),
                               richTextBox1.Text,
                               DateTime.Parse(dateTimePicker1.Text)))
            {
                MessageBox.Show("Exitoso....!!!!");
                button1.Text = "Agregar";
            }
            else
                MessageBox.Show(objBook.getMensaje());

            numt++;
        }

        private void ActualizarDatos()
        {
            Titles objBook = new Titles();
            if (objBook.Actualizar(textBox1.Text,
                               textBox2.Text,
                               comboBox1.Text,
                               comboBox2.SelectedValue.ToString(),
                               float.Parse(textBox3.Text),
                               int.Parse(textBox4.Text),
                               int.Parse(textBox5.Text),
                               int.Parse(textBox6.Text),
                               richTextBox1.Text,
                               DateTime.Parse(dateTimePicker1.Text)))
            {
                MessageBox.Show("Exitoso....!!!!");               
            }
            else
                MessageBox.Show(objBook.getMensaje());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }  
}
