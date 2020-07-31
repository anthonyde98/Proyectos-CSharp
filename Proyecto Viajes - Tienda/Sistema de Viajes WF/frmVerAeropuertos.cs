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
using Peralta100430840_lib1.IOAqui;

namespace Peralta100430840_WinX
{
    public partial class frmVerAeropuertos : Form
    {
        int valorboton;
        public frmVerAeropuertos(int valorboton)
        {
            InitializeComponent();

            this.valorboton = valorboton;

            llenarListbox();
        }

        private void llenarListbox()
        {
            Aeropuerto objAeropuertos = new Aeropuerto();

            frmMenuPrincipal MenuPrincipal = new frmMenuPrincipal();
            if (valorboton == 0)
            {
                List<string> data = DataInterface.MostrarElementosLista("ListaDeAeropuerto.txt");
                string objeto_string_elementos = "";
                listBox1.Items.Add("Catalogo de Aeropuertos Disponibles");
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
                Aeropuerto objAeropuerto = new Aeropuerto();
                string objeto_string_elementos = "";
                listBox1.Items.Add("Registro de Aeropuertos");
                listBox1.Items.Add("");

                foreach (var elemento in objAeropuerto.getTodoAeropuerto())
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
