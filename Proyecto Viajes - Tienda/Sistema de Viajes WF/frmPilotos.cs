using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Peralta100430840_lib1.Personas;
using Peralta100430840_lib1.Vehiculo;
using Peralta100430840_lib1.IOAqui;

namespace Peralta100430840_WinX
{
    public partial class frmPilotos : Form
    {
        public frmPilotos()
        {
            InitializeComponent();
            llenarlistBox1();
            llenarcomboBox1();
            llenarComboBox2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llenarlistBox1()
        {
            Piloto objPiloto = new Piloto();
            string objeto_string_elementos = "";

            foreach (var elemento in objPiloto.getAllPilot())
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

        private void llenarcomboBox1()
        {
            Piloto objPiloto = new Piloto();
            string objeto_string_elementos = "";

            foreach (var elemento in objPiloto.getAllPilot())
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
            dateTimePicker2.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            llenarcomboBox1();

            listBox1.Items.Clear();
            llenarlistBox1();
        }

        private void llenarComboBox2()
        {
            Piloto objPiloto = new Piloto();
            string objeto_string_elementos = "";

            foreach (var elemento in DataInterface.MostrarElementosLista("ListaDeAviones.txt"))
            {

                foreach (var cosas in elemento)
                {
                    objeto_string_elementos += cosas;
                    objeto_string_elementos += "";
                }

                comboBox2.Items.Add(objeto_string_elementos);
                objeto_string_elementos = "";

            }

            
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string pasaporte = textBox1.Text;
                string nombrepiloto = textBox2.Text;
                int aniosExp = int.Parse(textBox3.Text);
                string direccion = textBox4.Text;
                string tiposangre = textBox5.Text;
                string numerocelular = textBox6.Text;
                string numerotelefono = textBox7.Text;
                string estadocivil = textBox8.Text;
                double salario = double.Parse(textBox9.Text);
                string fechanacimiento = dateTimePicker1.Text;
                string fechacontrato = dateTimePicker2.Text;
                int avionasignado = comboBox2.SelectedIndex;

                Piloto ElPiloto = new Piloto(pasaporte, nombrepiloto, aniosExp, direccion, tiposangre, numerocelular, numerotelefono,
                    estadocivil, salario, fechanacimiento, fechacontrato, avionasignado);
                MessageBox.Show(ElPiloto.ToString());
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
                        textBox2.Text = cosa;
                        break;
                    case 3:
                        textBox3.Text = cosa;
                        break;
                    case 4:
                        textBox4.Text = cosa;
                        break;
                    case 5:
                        textBox5.Text = cosa;
                        break;
                    case 6:
                        textBox6.Text = cosa;
                        break;
                    case 7:
                        textBox7.Text = cosa;
                        break;
                    case 8:
                        textBox8.Text = cosa;
                        break;
                    case 9:
                        textBox9.Text = cosa;
                        break;
                    case 10:
                        dateTimePicker1.Text = cosa;
                        break;
                    case 11:
                        dateTimePicker2.Text = cosa;
                        break;
                    case 12:
                        comboBox2.Text = cosa;
                        break;
                }
                ++cont;
            }
        }

        private void llenarComponentesFroMcomboBox()
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
                        textBox5.Text = cosa;
                        break;
                    case 6:
                        textBox6.Text = cosa;
                        break;
                    case 7:
                        textBox7.Text = cosa;
                        break;
                    case 8:
                        textBox8.Text = cosa;
                        break;
                    case 9:
                        textBox9.Text = cosa;
                        break;
                    case 10:
                        dateTimePicker1.Text = cosa;
                        break;
                    case 11:
                        dateTimePicker2.Text = cosa;
                        break;
                    case 12:
                        comboBox2.Text = cosa;
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
            llenarComponentesFroMcomboBox();
        }
    }
}
