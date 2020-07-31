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
    public partial class frmMarcas : Form
    {
        public frmMarcas()
        {
            InitializeComponent();
            llenarlistBox1();
            llenarComboBox1();
            llenarComboBox2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llenarlistBox1()
        {
            Marca objMarca = new Marca();
            string objeto_string_elementos = "";

            foreach (var elemento in objMarca.getAllBrand())
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

        private void llenarComboBox2()
        {
            Marca objMarca = new Marca();
            string objeto_string_elementos = "";

            foreach (var elemento in objMarca.getAllBrand())
            {

                foreach (var cosas in elemento)
                {
                    objeto_string_elementos += cosas.ToString();
                    objeto_string_elementos += "|";
                }

                comboBox2.Items.Add(objeto_string_elementos);
                objeto_string_elementos = "";

            }
        }

        private void llenarComboBox1()
        {
            Marca objMarca = new Marca();

            for (int i = 0; i < 6; i++)
                comboBox1.Items.Add(objMarca.getAllOrigen().Split('_')[i]);

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = textBox1.Text;
                string origen = Convert.ToString(comboBox1.SelectedIndex);
                string fechafundada = dateTimePicker1.Text;

                Marca LaMarca = new Marca(nombre, origen, fechafundada);
                MessageBox.Show(LaMarca.ToString());
            }
            catch(Exception objError)
            {
                MessageBox.Show(objError.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            llenarComboBox2();

            listBox1.Items.Clear();
            llenarlistBox1();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
            }

            comboBox1.SelectedIndex = 0;
            dateTimePicker1.Text = null;
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
                        switch (cosa)
                        {
                            case "Europeo_":
                                comboBox1.SelectedIndex = 0;
                                break;
                            case "Americano_":
                                comboBox1.SelectedIndex = 1;
                                break;
                            case "Japonez_":
                                comboBox1.SelectedIndex = 2;
                                break;
                            case "Coreano_":
                                comboBox1.SelectedIndex = 3;
                                break;
                            case "Chino_":
                                comboBox1.SelectedIndex = 4;
                                break;
                            case "ZDesconocido_":
                                comboBox1.SelectedIndex = 5;
                                break;
                        }
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
            string seleccion = comboBox2.GetItemText(comboBox2.SelectedItem);
            int cont = 0;

            foreach (var cosa in seleccion.Split('|'))
            {
                switch (cont)
                {
                    case 1:
                        textBox1.Text = cosa;
                        break;
                    case 2:
                        switch (cosa)
                        {
                            case "Europeo_":
                                comboBox1.SelectedIndex = 0;
                                break;
                            case "Americano_":
                                comboBox1.SelectedIndex = 1;
                                break;
                            case "Japonez_":
                                comboBox1.SelectedIndex = 2;
                                break;
                            case "Coreano_":
                                comboBox1.SelectedIndex = 3;
                                break;
                            case "Chino_":
                                comboBox1.SelectedIndex = 4;
                                break;
                            case "ZDesconocido_":
                                comboBox1.SelectedIndex = 5;
                                break;
                        }
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarComponentesFroMComboBox();
        }
    }
}
