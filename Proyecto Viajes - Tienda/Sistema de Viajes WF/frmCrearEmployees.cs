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
    public partial class frmCrearEmployees : Form
    {
        private int nume = 100;
        public frmCrearEmployees()
        {
            InitializeComponent();
        }

        public frmCrearEmployees(string emp_id)
        {
            InitializeComponent();
            mostrarTabla(emp_id);
        }

        private void mostrarTabla(string emp_id)
        {
            Employee objEmployee = new Employee();
            objEmployee.Buscar(emp_id, true);
            llenarCombobox();

            textBox1.Text = emp_id;
            textBox2.Text = objEmployee.getfname();
            textBox3.Text = objEmployee.getminit().ToString();
            textBox4.Text = objEmployee.getlname();
            comboBox1.Text = objEmployee.getjob_desc();
            textBox5.Text = objEmployee.getjob_lvl();
            comboBox2.Text = objEmployee.getpub_name();
            dateTimePicker1.Text = Convert.ToString(objEmployee.gethire_date());
        }

        private void llenarCombobox()
        {
            Employee objEmployee = new Employee();
            DataTable objTablePub = objEmployee.getEditora();
            comboBox2.DataSource = objTablePub;
            comboBox2.DisplayMember = "pub_name";
            comboBox2.ValueMember = "pub_id";

            DataTable objDataEmpleo = objEmployee.getEmpleo();
            comboBox1.DataSource = objDataEmpleo;
            comboBox1.DisplayMember = "job_desc";
            comboBox1.ValueMember = "job_id";
        }

        private void limpiarControles()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
            }

            comboBox1.Text = "";
            comboBox2.Text = "";

            dateTimePicker1.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Limpiar")
            {
                limpiarControles();
                button1.Text = "Agregar";
            }
            else
            {
                AgregarDatos();
            }
        }

        private void AgregarDatos()
        {
            Employee objEmployee = new Employee();
            if (objEmployee.Agregar("A" + nume + "P",
                                    textBox2.Text,
                                    textBox3.Text,
                                    textBox4.Text,
                                    comboBox1.SelectedValue.ToString(),
                                    textBox5.Text,
                                    comboBox1.SelectedValue.ToString(),
                                    DateTime.Parse(dateTimePicker1.Text)))
            {
                MessageBox.Show("Exitoso....!!!!");
                button1.Text = "Agregar";
            }
            else
                MessageBox.Show(objEmployee.getMensaje());

            nume++;
        }

        private void ActualizarDatos()
        {
            Employee objEmployee = new Employee();
            if (objEmployee.Actualizar(textBox1.Text,
                                    textBox2.Text,
                                    textBox3.Text,
                                    textBox4.Text,
                                    comboBox1.SelectedValue.ToString(),
                                    textBox5.Text,
                                    comboBox1.SelectedValue.ToString(),
                                    DateTime.Parse(dateTimePicker1.Text)))
            {
                MessageBox.Show("Exitoso....!!!!");
            }
            else
                MessageBox.Show(objEmployee.getMensaje());
        }
    }
}
