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
    public partial class frmDineroRangoFecha : Form
    {
        public frmDineroRangoFecha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fechainicial = dateTimePicker1.Text;
                string fechaFinal = dateTimePicker2.Text;

                Boleta objReadingOnly = new Boleta();
                double TotalMoney = objReadingOnly.getTotalMoneyDateRank(fechainicial, fechaFinal);

                if (TotalMoney == 0)
                    MessageBox.Show("\n\tFecha no encontrada");
                else
                    MessageBox.Show("\n\tTotal de dinero : " + TotalMoney);

                objReadingOnly = null;
            }
            catch(Exception objError)
            {
                MessageBox.Show(objError.ToString());
            }        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
