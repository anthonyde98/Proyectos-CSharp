using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Peralta100430840_TiendaX.Pubs;

namespace Peralta100430840_WinX
{
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
            llenarGrid();
        }

        private void llenarGrid()
        {
            Sales Ventas = new Sales();
            Ventas.Buscar("Select * from sales" , false);
            dataGridView1.DataSource = Ventas.getobj_AllSales();

        }
    }
}
