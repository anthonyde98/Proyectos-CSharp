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

namespace Peralta100430840_WinX
{
    public partial class frmVerBoletas : Form
    {
        public frmVerBoletas()
        {
            InitializeComponent();
            llenarListbox();
        }

        private void llenarListbox()
        {
            Boleta objBoleta = new Boleta();
            string objeto_string_elementos = "";
            listBox1.Items.Add("Registro de Boletas");
            listBox1.Items.Add("");

            foreach (var elemento in objBoleta.getTodaBoleta())
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

