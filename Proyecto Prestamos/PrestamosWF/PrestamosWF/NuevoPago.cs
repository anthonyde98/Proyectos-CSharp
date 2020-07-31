using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrestamosWF
{
    public partial class NuevoPago : Form
    {
        private bool retorno;
        private string recibido;
        private float cargo;

        public NuevoPago()
        {
            InitializeComponent();
        }

        public NuevoPago(string recibir)
        {
            InitializeComponent();

            recibido = recibir;

            label1.Text = "¿" + recibido + " quiere efectuar el pago?";
        }

        public NuevoPago(string recibir, float recargo)
        {
            InitializeComponent();

            recibido = recibir;
            cargo = recargo;

            label1.Text = "¿" + recibido + " quiere efectuar el pago?";
            label2.Visible = true;
            label2.Text = "Cargo: " + cargo.ToString() + " RD$";
        }

        public bool Desicion()
        {
            return retorno;
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            retorno = false;
            this.Close();
            
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            retorno = true;
            this.Close();
        }

        private void NuevoPago_Load(object sender, EventArgs e)
        {


        }
    }
}
