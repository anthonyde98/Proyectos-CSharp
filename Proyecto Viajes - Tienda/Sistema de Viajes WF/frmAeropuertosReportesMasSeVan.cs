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
    public partial class frmAeropuertosReportesMasSeVan : Form
    {
        public frmAeropuertosReportesMasSeVan()
        {
            InitializeComponent();
            llenarlistBox();
        }

        private void llenarlistBox()
        {
            string display = "";
            List<string> p_objList = new List<string>();
            p_objList = Boleta.getMasVisitado("RegistroOrigen.txt", "ListaDeAeropuerto.txt");
            for (int i = 0; i < p_objList.Count(); i++)
            {
                display = i + 1 + ") " + p_objList[i] + "\n";

                listBox1.Items.Add(display);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
