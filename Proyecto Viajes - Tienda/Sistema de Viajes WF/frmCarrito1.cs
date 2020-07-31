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
    public partial class frmCarrito1 : Form
    {
        private int ord_num = 1010;
        private DateTime ord_date;
        public frmCarrito1()
        {
            InitializeComponent();
        }

        public frmCarrito1(string usuario)
        {
            InitializeComponent();
            llenarComponentes(usuario);

        }

        private void llenarComponentes(string usuario)
        {
            Store objStore = new Store();
            DataTable objTablePub = objStore.getTiendas();
            comboBox1.DataSource = objTablePub;
            comboBox1.DisplayMember = "stor_name";
            comboBox1.ValueMember = "stor_id";

            label1.Text = usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {

                //CAPTURAMOS VALOR DE LA FILA SELECCIONADA DG FORM2

                string stor_id = comboBox1.SelectedValue.ToString();
                ord_date = DateTime.Now;
                int qty = int.Parse(this.dataGridView1.CurrentRow.Cells[4].Value.ToString());
                string payterms = comboBox2.Text;
                string title_id = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string title = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //PASAMOS VALORES A CLASE VENTAS

                Sales ventas = new Sales();
                if (ventas.Agregar(stor_id, "" + ord_num, ord_date, qty, payterms, title_id))
                {
                    MessageBox.Show("La compra se ha realizado con exito" + "\nLibro: " + title +
                        "\nCantidad: " + qty + "\nNumero de orden: " + ord_num + "\nTermino de pago: " + payterms +
                        "\nTienda: " + stor_id);
                }

                ord_num++;
            }
        }
    }
}
