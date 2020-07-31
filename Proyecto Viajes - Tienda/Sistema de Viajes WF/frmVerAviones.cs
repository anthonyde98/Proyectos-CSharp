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
using Peralta100430840_lib1.IOAqui;

namespace Peralta100430840_WinX
{
    public partial class frmVerAviones : Form
    {
        int valorboton;
        public frmVerAviones(int valorboton)
        {
            InitializeComponent();

            this.valorboton = valorboton;

            llenarListbox();
        }

        private void llenarListbox()
        {
            Avion objAvion = new Avion();

            frmMenuPrincipal MenuPrincipal = new frmMenuPrincipal();
            if (valorboton == 0)
            {
                List<string> data = DataInterface.MostrarElementosLista("ListaDeAviones.txt");
                string objeto_string_elementos = "";
                listBox1.Items.Add("Catalogo de Aviones Disponibles");
                listBox1.Items.Add("");

                foreach (var elemento in data)
                {

                    foreach (var cosas in elemento)
                    {
                        objeto_string_elementos += cosas.ToString();
                        objeto_string_elementos += "";
                    }

                    listBox1.Items.Add(objeto_string_elementos);
                    objeto_string_elementos = "";

                }
            }
            else
            {
                Avion objAviones = new Avion();

                string objeto_string_elementos = "";
                listBox1.Items.Add("Registro de Aviones");
                listBox1.Items.Add("");

                foreach (var elemento in objAviones.getTodoAvion())
                {

                    foreach (var cosas in elemento)
                    {
                        objeto_string_elementos += cosas.ToString();
                        objeto_string_elementos += "\t";
                    }

                    listBox1.Items.Add(objeto_string_elementos);
                    objeto_string_elementos = "";

                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
