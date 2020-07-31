using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Peralta100430840_lib1;
using Peralta100430840_lib1.Personas;
using Peralta100430840_lib1.IOAqui;

namespace Peralta100430840_WinX
{
    public partial class frmBoletas : Form
    {
        public frmBoletas()
        {
            InitializeComponent();
            llenarcomboBoxpiloto();
            llenarcomboBoxclase();
            llenarcomboBoxAeropuertoorigen();
            llenarcomboBoxAeropuertodestino();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            dateTimePicker1.Text = null;
            dateTimePicker2.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = textBox1.Text;
                string pasaporte = textBox2.Text;
                string fechanacimiento = dateTimePicker1.Text;
                string tiposangre = textBox3.Text;
                string estadocivil = textBox4.Text;
                string direccion = textBox5.Text;
                string celular = textBox6.Text;
                string telefono = textBox7.Text;
                string ocupacion = textBox8.Text;
                int piloto = comboBox1.SelectedIndex;
                string clase = Convert.ToString(comboBox2.SelectedIndex);
                double pesoequipaje = double.Parse(textBox9.Text);
                int Aeropuertoorigen = comboBox3.SelectedIndex;
                int Aeropuertodestino = comboBox4.SelectedIndex;
                string fechapartida = dateTimePicker1.Text;

                Boleta LaBoleta = new Boleta(piloto, clase, Aeropuertoorigen, Aeropuertodestino, fechapartida, pesoequipaje);
                Pasajero ElPasajero = new Pasajero(nombre, pasaporte, fechanacimiento, tiposangre, estadocivil, direccion, celular, telefono, ocupacion);

                MessageBox.Show("Su boleta ha sido registrada exitosamente. \nInformación:" + ElPasajero.ToString() + LaBoleta.ToString());
            }
            catch(Exception objError)
            {
                MessageBox.Show(objError.ToString());
            }     
        }

        private void llenarcomboBoxpiloto()
        {
            Piloto objPiloto = new Piloto();
            string objeto_string_elementos = "";

            foreach (var elemento in DataInterface.MostrarElementosLista("ListaDePiloto.txt"))
            {

                foreach (var cosas in elemento)
                {
                    objeto_string_elementos += cosas;
                    objeto_string_elementos += "";
                }

                comboBox1.Items.Add(objeto_string_elementos);
                objeto_string_elementos = "";

            }

            comboBox1.SelectedIndex = 0;
        }

        private void llenarcomboBoxclase()
        {
            string objeto_string_elementos = "";

            foreach (var elemento in Boleta.getAllClase().Split('.'))
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

        private void llenarcomboBoxAeropuertoorigen()
        {
            Piloto objPiloto = new Piloto();
            string objeto_string_elementos = "";

            foreach (var elemento in DataInterface.MostrarElementosLista("ListaDeAeropuerto.txt"))
            {

                foreach (var cosas in elemento)
                {
                    objeto_string_elementos += cosas;
                    objeto_string_elementos += "";
                }

                comboBox3.Items.Add(objeto_string_elementos);
                objeto_string_elementos = "";

            }

            comboBox3.SelectedIndex = 0;
        }

        private void llenarcomboBoxAeropuertodestino()
        {
            string objeto_string_elementos = "";

            foreach (var elemento in DataInterface.MostrarElementosLista("ListaDeAeropuerto.txt"))
            {

                foreach (var cosas in elemento)
                {
                    objeto_string_elementos += cosas;
                    objeto_string_elementos += "";
                }

                comboBox4.Items.Add(objeto_string_elementos);
                objeto_string_elementos = "";

            }

            comboBox4.SelectedIndex = 0;
        }
    }
}
