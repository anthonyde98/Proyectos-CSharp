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
    public partial class FEmpleado : Form
    {
        Personal Empleados;
        DataSet datos;

        public FEmpleado()
        {
            InitializeComponent();
        }

        private void cargarDataGrid()
        {
            Empleados = new Personal();
            datos = Empleados.LlenarDataGrid("Personal");
            dataGridView1.DataSource = datos.Tables[0];

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Empleados = new Personal();
            datos = Empleados.consultar(textBox1.Text);
            dataGridView1.DataSource = datos.Tables[0];
        }

        private void FEmpleado_Load(object sender, EventArgs e)
        {
            cargarDataGrid();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            NuevoEmpleado AxEmpleado = new NuevoEmpleado();
            AxEmpleado.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Login.nivel == 1)
            {
                try
                {
                    int id;
                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    NuevoEmpleado AxEmpleado = new NuevoEmpleado(id);
                    AxEmpleado.Show();
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
