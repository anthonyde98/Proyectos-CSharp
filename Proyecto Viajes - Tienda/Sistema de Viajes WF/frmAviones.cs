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
    public partial class frmAviones : Form
    {
        public frmAviones()
        {
            InitializeComponent();
            LLenarCombobox1();
            llenarlistBox1();
            llenarComboBox2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LLenarCombobox1()
        {
            Avion objAvion = new Avion();
            for (int i = 0; i < 3; i++)
                comboBox1.Items.Add(objAvion.getAllSeguridad().Split('_')[i]);

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int aniocreacion = int.Parse(textBox2.Text);
                double precio = double.Parse(textBox1.Text);
                string marca = textBox3.Text;
                string modelo = textBox4.Text;
                string color = textBox5.Text;
                string motor = textBox6.Text;
                int capacidadcarga = int.Parse(textBox7.Text);
                int capacidadpasajeros = int.Parse(textBox8.Text);
                int tripulacion = int.Parse(textBox9.Text);
                string nivelseguridad = Convert.ToString(comboBox1.SelectedIndex);
                double peso = double.Parse(textBox10.Text);

                Avion objElAvion = new Avion(aniocreacion, precio, marca, modelo, color, motor, capacidadcarga,
                    capacidadpasajeros, tripulacion, nivelseguridad, peso);
                MessageBox.Show(objElAvion.ToString());
            }
            catch(Exception objError)
            {
                MessageBox.Show(objError.ToString());
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

            comboBox1.SelectedIndex = 0;

        }

        private void llenarlistBox1()
        {
            Avion objAvion = new Avion();
            string objeto_string_elementos = "";

            foreach (var elemento in objAvion.getTodoAvion())
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
            Avion objAvion = new Avion();
            string objeto_string_elementos = "";

            foreach (var elemento in objAvion.getTodoAvion())
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

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            llenarComboBox2();

            listBox1.Items.Clear();
            llenarlistBox1();
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
                        textBox2.Text = cosa;
                        break;
                    case 2:
                        textBox1.Text = cosa;
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
                        switch(cosa)
                        {
                            case "Alto_" : comboBox1.SelectedIndex = 0;
                                break;
                            case "Medio_": comboBox1.SelectedIndex = 1;
                                break;
                            case "Bajo_": comboBox1.SelectedIndex = 2;
                                break;
                        }
                        break;
                    case 10:
                        textBox9.Text = cosa;
                        break;
                    case 11:
                        textBox10.Text = cosa;
                        break;
                }
                ++cont;
            }
        }

        private void llenarComponentesFroMcomboBox()
        {
            string seleccion = comboBox2.GetItemText(comboBox2.SelectedItem);
            int cont = 0;

            foreach (var cosa in seleccion.Split('|'))
            {
                switch (cont)
                {
                    case 1:
                        textBox2.Text = cosa;
                        break;
                    case 2:
                        textBox1.Text = cosa;
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
                        switch (cosa)
                        {
                            case "Alto_":
                                comboBox1.SelectedIndex = 0;
                                break;
                            case "Medio_":
                                comboBox1.SelectedIndex = 1;
                                break;
                            case "Bajo_":
                                comboBox1.SelectedIndex = 2;
                                break;
                        }
                        break;
                    case 10:
                        textBox9.Text = cosa;
                        break;
                    case 11:
                        textBox10.Text = cosa;
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
            llenarComponentesFroMcomboBox();
        }
    }
}
