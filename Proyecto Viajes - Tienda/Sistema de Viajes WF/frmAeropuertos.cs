using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Peralta100430840_lib1.Edificacion;

namespace Peralta100430840_WinX
{
    public partial class frmAeropuertos : Form
    {
        public frmAeropuertos()
        {
            InitializeComponent();
            LLenarCombobox1();
            llenarlistBox1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LLenarCombobox1()
        {
            Aeropuerto objAeropuerto = new Aeropuerto();
            string objeto_string_elementos = "";

            foreach (var elemento in objAeropuerto.getTodoAeropuerto())
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
            Aeropuerto objAeropuerto = new Aeropuerto();
            string objeto_string_elementos = "";

            foreach (var elemento in objAeropuerto.getTodoAeropuerto())
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

            dateTimePicker1.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = textBox1.Text;
                string direccion = textBox2.Text;
                string pais = textBox3.Text;
                string telefono = textBox4.Text;
                string fechafundacion = dateTimePicker1.Text;

                Aeropuerto objElAeropuerto = new Aeropuerto(nombre, direccion, pais, telefono, fechafundacion);
                MessageBox.Show(objElAeropuerto.ToString());
            }
            catch (Exception objError)
            {
                MessageBox.Show(objError.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            LLenarCombobox1();

            listBox1.Items.Clear();
            llenarlistBox1();
        }

        private void llenarComponentesFroMlistBox()
        {
            string seleccion = listBox1.GetItemText(listBox1.SelectedItem);
            int cont = 0;

            foreach (var cosa in seleccion.Split('|'))
            {
                switch(cont)
                {
                    case 1: textBox1.Text = cosa;
                        break;
                    case 2: textBox2.Text = cosa;
                        break;
                    case 3: textBox3.Text = cosa;
                        break;
                    case 4: textBox4.Text = cosa;
                        break;
                    case 5: dateTimePicker1.Text = cosa;
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
                        textBox2.Text = cosa;
                        break;
                    case 3:
                        textBox3.Text = cosa;
                        break;
                    case 4:
                        textBox4.Text = cosa;
                        break;
                    case 5:
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
