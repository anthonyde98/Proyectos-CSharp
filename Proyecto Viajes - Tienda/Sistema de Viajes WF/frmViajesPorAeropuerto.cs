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
using Peralta100430840_lib1.IOAqui;

namespace Peralta100430840_WinX
{
    public partial class frmViajesPorAeropuerto : Form
    {
        public frmViajesPorAeropuerto()
        {
            InitializeComponent();

            llenarListbox();
        }

        private void llenarListbox()
        {
            string display = "";
            List<int> objFlightList = new List<int>();
            List<string> objAirportList = new List<string>();
            objAirportList = DataInterface.getListaElementos("ListaDeAeropuerto.txt");
            objFlightList = Boleta.getTotalVuelos("RegistroOrigen.txt", "RegistroDestino.txt", "ListaDeAeropuerto.txt");
            for (int i = 0; i < objFlightList.Count(); i++)
            {
                display = " " + (i + 1) + ") " + objAirportList[i] + " = " + objFlightList[i] + "\n";

                listBox1.Items.Add(display);
            }                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
