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
    public partial class FPrestamo : Form
    {
        Cliente Clientes;
        DataSet datos;

        public FPrestamo()
        {
            InitializeComponent();
        }

        private void cargarDataGrid()
        {
            Clientes = new Cliente();
            datos = Clientes.LlenarDataGrid("Cliente");
            dataGridView1.DataSource = datos.Tables[0];

        }

        private void cargarDataGridBuscar(int id)
        {
            Prestamo Prestamos = new Prestamo();
            datos = Prestamos.buscarPrestamoCliente(id);
            dataGridView1.DataSource = datos.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Clientes = new Cliente();
            datos = Clientes.consultar(textBox1.Text);
            dataGridView1.DataSource = datos.Tables[0];
        }

        private void FPrestamo_Load(object sender, EventArgs e)
        {
            cargarDataGrid();
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            cargarDataGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButton1.Checked)
            {
                try
                {
                    int id;
                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    cargarDataGridBuscar(id);
                }
                catch
                {
                    MessageBox.Show("Hubo un error al seleccionar este elemento.");
                }
            }
            else
            {
                try
                {
                    int id;
                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    NuevoPrestamo AxPrestamo = new NuevoPrestamo(id);
                    AxPrestamo.Show();
                }
                catch
                {
                    MessageBox.Show("Hubo un error al seleccionar este elemento.");
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            NuevoPrestamo AxPrestamo = new NuevoPrestamo();
            AxPrestamo.Show();
        }
    }
}
