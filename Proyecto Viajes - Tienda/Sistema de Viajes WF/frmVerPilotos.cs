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
using Peralta100430840_lib1.IOAqui;

namespace Peralta100430840_WinX
{
    public partial class frmVerPilotos : Form
    {
        int valorboton;
        public frmVerPilotos(int valorboton)
        {
            InitializeComponent();

            this.valorboton = valorboton;

            llenarListbox();
        }

        private void llenarListbox()
        {
            frmMenuPrincipal MenuPrincipal = new frmMenuPrincipal();
            if (valorboton == 0)
            {
                List<string> data = DataInterface.MostrarElementosLista("ListaDePiloto.txt");
                string objeto_string_elementos = "";
                listBox1.Items.Add("Catalogo de Pilotos Disponibles");
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
                Piloto objPiloto = new Piloto();
                string objeto_string_elementos = "";
                listBox1.Items.Add("Registro de Pilotos");
                listBox1.Items.Add("");

                foreach (var elemento in objPiloto.getAllPilot())
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
