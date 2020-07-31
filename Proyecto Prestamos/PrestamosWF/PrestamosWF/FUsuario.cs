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
    public partial class FUsuario : Form
    {
        Usuario Usuarios;
        DataSet datos;
        private int usuario;
        public FUsuario()
        {
            InitializeComponent();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            CrearUsuario usuario = new CrearUsuario('a');
            usuario.Show();
        }

        private void cargarDataGrid()
        {
            Usuarios = new Usuario();
            datos = Usuarios.LlenarDataGrid("Usuario");
            dataGridView1.DataSource = datos.Tables[0];
            datos = Usuarios.LlenarDataGrid("cambio");
            dataGridView2.DataSource = datos.Tables[0];
        }

        private void FUsuario_Load(object sender, EventArgs e)
        {
            cargarDataGrid();           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Usuarios = new Usuario();
            datos = Usuarios.consultar(textBox1.Text);
            dataGridView1.DataSource = datos.Tables[0];
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            cargarDataGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                usuario = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Usuario Usuario = new Usuario();
                dataGridView1.DataSource = Usuario.buscarCambios(usuario).Tables[0];
            }
            catch
            {
                MessageBox.Show("Hubo un error al seleccionar ese elemento.");
            }           
        }
    }
}
