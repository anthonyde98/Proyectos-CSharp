using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Peralta100430840_lib1.Vehiculo;

namespace Peralta100430840_WinX
{
    public partial class frmModelos : Form
    {
        public frmModelos()
        {
            InitializeComponent();
            llenarComboBox1();
            llenarComboBox2();
            llenarlistBox1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llenarComboBox2()
        {
            Marca objMarca = new Marca();
            string objeto_string_elementos = "";
            int cont = 0;

            foreach (var elemento in objMarca.getAllBrand())
            {

                foreach (var cosas in elemento)
                {
                    if (cont == 2)
                        continue;

                    objeto_string_elementos += cosas.ToString();
                    objeto_string_elementos += " ";

                    ++cont;
                }

                cont = 0;

                comboBox2.Items.Add(objeto_string_elementos);
                objeto_string_elementos = "";
                
            }

            comboBox2.SelectedIndex = 0;
        }

        private void llenarComboBox1()
        {
            Modelo objModelo = new Modelo();
            string objeto_string_elementos = "";

            foreach (var elemento in objModelo.getAllModel())
            {

                foreach (var cosas in elemento)
                {
                    objeto_string_elementos += cosas.ToString();
                    objeto_string_elementos += "|";
                }

                comboBox1.Items.Add(objeto_string_elementos);
                objeto_string_elementos = "";

            }
        }

        private void llenarlistBox1()
        {
            Modelo objModelo = new Modelo();
            string objeto_string_elementos = "";

            foreach (var elemento in objModelo.getAllModel())
            {

                foreach (var cosas in elemento)
                {
                    objeto_string_elementos += cosas.ToString();
                    objeto_string_elementos += "|";
                }

                listBox1.Items.Add(objeto_string_elementos);
                objeto_string_elementos = "";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
            }

            comboBox2.SelectedIndex = 0;
            dateTimePicker1.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            llenarComboBox1();

            listBox1.Items.Clear();
            llenarlistBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 1 + comboBox2.SelectedIndex;
                string modelo = textBox1.Text;
                DateTime fechaedicion = DateTime.Parse(dateTimePicker1.Text);

                Modelo ElModelo = new Modelo(modelo, id, fechaedicion);
                MessageBox.Show("El nuevo modelo " + modelo + " se ha agregado exitosamente.\nSu ID es " + id + ".");
            }
            catch(Exception objError)
            {
                MessageBox.Show(objError.ToString());
            }          
        }

        private void llenarComponentesFroMlistBox()
        {
            string seleccion = listBox1.GetItemText(listBox1.SelectedItem);
            int cont = 0;

            foreach (var cosa in seleccion.Split('|'))
            {
                switch (cont)
                {
                    case 1:
                        textBox1.Text = cosa;
                        break;
                    case 2:
                         comboBox2.SelectedIndex = int.Parse(cosa) - 1;
                        break;
                    case 3:
                        dateTimePicker1.Text = cosa;
                        break;
                }
                ++cont;
            }
        }

        private void llenarComponentesFroMComboBox()
        {
            string seleccion = comboBox1.GetItemText(comboBox1.SelectedItem);
            int cont = 0;

            foreach (var cosa in seleccion.Split('|'))
            {
                switch (cont)
                {
                    case 1:
                        textBox1.Text = cosa;
                        break;
                    case 2:
                        comboBox2.SelectedIndex = int.Parse(cosa) - 1;
                        break;
                    case 3:
                        dateTimePicker1.Text = cosa;
                        break;
                }
                ++cont;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarComponentesFroMlistBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarComponentesFroMComboBox();
        }
    }
}
