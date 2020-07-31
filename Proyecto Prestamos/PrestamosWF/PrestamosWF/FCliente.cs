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
    public partial class FCliente : Form
    {
        Cliente Clientes;
        DataSet datos;

        public FCliente()
        {
            InitializeComponent();
        }

        private void cargarDataGrid()
        {
            Clientes = new Cliente();
            datos = Clientes.LlenarDataGrid("Cliente");
            dataGridView1.DataSource = datos.Tables[0];

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Clientes = new Cliente();
            datos = Clientes.consultar(textBox1.Text);
            dataGridView1.DataSource = datos.Tables[0];
        }

        private void FCliente_Load(object sender, EventArgs e)
        {
            cargarDataGrid();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            NuevoCliente AxCliente = new NuevoCliente();
            AxCliente.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Login.nivel == 1)
            {
                try
                {
                    int id;
                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    NuevoCliente AxCliente = new NuevoCliente(id);
                    AxCliente.Show();
                }
                catch
                {
                    MessageBox.Show("Hubo un error al seleccionar este elemento.");
                }
            }
            else
            {
                MessageBox.Show("No tiene acceso para actualizar elementos.");
            }           
        }
    }
}
