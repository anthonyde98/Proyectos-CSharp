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
    public partial class frmTitle : Form
    {
        int opcion;
        public frmTitle(int opcion)
        {
            this.opcion = opcion;

            InitializeComponent();
            mostrarTabla(opcion);
        }

        private void mostrarTabla(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    Titles objBook = new Titles();
                    objBook.Buscar(textBox1.Text, false);
                    dataGridView1.DataSource = objBook.getAllBook();
                    break;
                case 2:
                    Author objAuthor = new Author();
                    objAuthor.Buscar(textBox1.Text, false);
                    dataGridView1.DataSource = objAuthor.getobj_AllAuthors();
                    break;
                case 3:
                    Publishers objPublishers = new Publishers();
                    objPublishers.Buscar(textBox1.Text, false);
                    dataGridView1.DataSource = objPublishers.getobj_AllPublishers();
                    break;
                case 4:
                    Store objStores = new Store();
                    objStores.Buscar(textBox1.Text, false);
                    dataGridView1.DataSource = objStores.getobj_AllStores();
                    break;
                case 5:
                    Jobs objJobs = new Jobs();
                    objJobs.Buscar(textBox1.Text, false);
                    dataGridView1.DataSource = objJobs.getobj_AllJobs();
                    break;
                case 6:
                    Employee objEmployee = new Employee();
                    objEmployee.Buscar(textBox1.Text, false);
                    dataGridView1.DataSource = objEmployee.getobj_AllEmployees();
                    break;
                case 7:
                    textBox2.Visible = true;
                    label1.Visible = true;
                    Titles objLibro = new Titles();
                    objLibro.Buscar(textBox1.Text, false);
                    dataGridView1.DataSource = objLibro.getAllBook();

                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrarTabla(opcion);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (opcion)
                {
                    case 1:
                        llenarFormLibros(e);
                        break;
                    case 2:
                        llenarFormAutor(e);
                        break;
                    case 3:
                        llenarFormPublicitaria(e);
                        break;
                    case 4:
                        llenarFormTienda(e);
                        break;
                    case 5:
                        llenarFormEmpleos(e);
                        break;
                    case 6:
                        llenarFormEmpleado(e);
                        break;
                    case 7:
                        break;
                }
            }
            catch (Exception objError)
            {
                MessageBox.Show(objError.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (opcion)
            {
                case 1:
                    frmCrearTitle objTitle = new frmCrearTitle();
                    objTitle.MdiParent = this.MdiParent;
                    objTitle.WindowState = FormWindowState.Maximized;
                    objTitle.Show();
                    break;
                case 2:
                    frmCrearAuthor objAuthor = new frmCrearAuthor();
                    objAuthor.MdiParent = this.MdiParent;
                    objAuthor.WindowState = FormWindowState.Maximized;
                    objAuthor.Show();
                    break;
                case 3:
                    frmCrearPublishers objPublishers = new frmCrearPublishers();
                    objPublishers.MdiParent = this.MdiParent;
                    objPublishers.WindowState = FormWindowState.Maximized;
                    objPublishers.Show();
                    break;
                case 4:
                    frmCrearStores objStores = new frmCrearStores();
                    objStores.MdiParent = this.MdiParent;
                    objStores.WindowState = FormWindowState.Maximized;
                    objStores.Show();
                    break;
                case 5:
                    frmCrearJobs objJobs = new frmCrearJobs();
                    objJobs.MdiParent = this.MdiParent;
                    objJobs.WindowState = FormWindowState.Maximized;
                    objJobs.Show();
                    break;
                case 6:
                    frmCrearEmployees objEmployee = new frmCrearEmployees();
                    objEmployee.MdiParent = this.MdiParent;
                    objEmployee.WindowState = FormWindowState.Maximized;
                    objEmployee.Show();
                    break;
                case 7:
                                        
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {

                        //CAPTURAMOS VALOR DE LA FILA SELECCIONADA DG FORM2
                        string title_id = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        string title = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        string type = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        double price = double.Parse(this.dataGridView1.CurrentRow.Cells[4].Value.ToString());
                        int qty = int.Parse(textBox2.Text);
                        //PASAMOS VALORES DE FORM2  A FORM1 

                        frmCarrito1 carrito = new frmCarrito1();

                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm.Name == "frmCarrito1")
                            {
                                carrito = (frmCarrito1)frm;
                                carrito.dataGridView1.Rows.Add(title_id, title, type, price, qty);

                                break;
                            }
                        }

                    }
                    break;
            }
            
        }

        private void llenarFormLibros(DataGridViewCellEventArgs e)
        {
            int ind_Fila_actual = e.RowIndex;
            DataTable objDataBook = (DataTable)dataGridView1.DataSource;
            string title_id = objDataBook.Rows[ind_Fila_actual]["title_id"].ToString();
            frmCrearTitle objTitle = new frmCrearTitle(title_id);
            objTitle.MdiParent = this.MdiParent;
            objTitle.WindowState = FormWindowState.Maximized;
            objTitle.Show();
        }

        private void llenarFormAutor(DataGridViewCellEventArgs e)
        {
            int ind_Fila_actual = e.RowIndex;
            DataTable objDataBook = (DataTable)dataGridView1.DataSource;
            string au_id = objDataBook.Rows[ind_Fila_actual]["au_id"].ToString();
            frmCrearAuthor objAutor = new frmCrearAuthor(au_id);
            objAutor.MdiParent = this.MdiParent;
            objAutor.WindowState = FormWindowState.Maximized;
            objAutor.Show();
        }

        private void llenarFormPublicitaria(DataGridViewCellEventArgs e)
        {
            int ind_Fila_actual = e.RowIndex;
            DataTable objDataBook = (DataTable)dataGridView1.DataSource;
            string pub_id = objDataBook.Rows[ind_Fila_actual]["pub_id"].ToString();
            frmCrearPublishers objPublishers = new frmCrearPublishers(pub_id);
            objPublishers.MdiParent = this.MdiParent;
            objPublishers.WindowState = FormWindowState.Maximized;
            objPublishers.Show();
        }

        private void llenarFormTienda(DataGridViewCellEventArgs e)
        {
            int ind_Fila_actual = e.RowIndex;
            DataTable objDataBook = (DataTable)dataGridView1.DataSource;
            string stor_id = objDataBook.Rows[ind_Fila_actual]["stor_id"].ToString();
            frmCrearStores objStores = new frmCrearStores(stor_id);
            objStores.MdiParent = this.MdiParent;
            objStores.WindowState = FormWindowState.Maximized;
            objStores.Show();
        }

        private void llenarFormEmpleos(DataGridViewCellEventArgs e)
        {
            int ind_Fila_actual = e.RowIndex;
            DataTable objDataBook = (DataTable)dataGridView1.DataSource;
            string job_id = objDataBook.Rows[ind_Fila_actual]["job_id"].ToString();
            frmCrearJobs objJobs = new frmCrearJobs(job_id);
            objJobs.MdiParent = this.MdiParent;
            objJobs.WindowState = FormWindowState.Maximized;
            objJobs.Show();
        }

        private void llenarFormEmpleado(DataGridViewCellEventArgs e)
        {
            int ind_Fila_actual = e.RowIndex;
            DataTable objDataBook = (DataTable)dataGridView1.DataSource;
            string emp_id = objDataBook.Rows[ind_Fila_actual]["emp_id"].ToString();
            frmCrearEmployees objEmployees = new frmCrearEmployees(emp_id);
            objEmployees.MdiParent = this.MdiParent;
            objEmployees.WindowState = FormWindowState.Maximized;
            objEmployees.Show();
        }
    }
}
