using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PrestamosWF
{
    public partial class NuevoEmpleado : Form
    {
        DataSet Empleados;
        Personal Empleado;
        Usuario user;

        private int id;

        public NuevoEmpleado()
        {
            InitializeComponent();
        }

        public NuevoEmpleado(int id)
        {
            this.id = id;
            InitializeComponent();

            btnAccion.Text = "Actualizar";

            if (Login.nivel != 1)
            {
                checkBoxE.Visible = false;               
            }

            user = new Usuario();
            Empleado = new Personal();
            Empleados = Empleado.buscarPersonal(id);
            textBoxU.Text = user.buscarUsuario(Convert.ToInt32(Empleados.Tables[0].Rows[0]["usuario"].ToString())).Tables[0].Rows[0]["nickName"].ToString();
            textBoxN.Text = Empleados.Tables[0].Rows[0]["nombre"].ToString();
            textBoxA.Text = Empleados.Tables[0].Rows[0]["apellido"].ToString();
            textBoxT.Text = Empleados.Tables[0].Rows[0]["telefono"].ToString();
            textBoxC.Text = Empleados.Tables[0].Rows[0]["cedula"].ToString();
            textBoxD.Text = Empleados.Tables[0].Rows[0]["direccion"].ToString();
            textBoxCr.Text = Empleados.Tables[0].Rows[0]["cargo"].ToString();
            checkBoxE.Checked = Convert.ToBoolean(Empleados.Tables[0].Rows[0]["estado"].ToString());
            
            //No editables

            textBoxU.ReadOnly = true;
            textBoxC.ReadOnly = true;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void NuevoEmpleado_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            Empleado = new Personal();
            Usuario usuarioName = new Usuario();
            DataSet datos = Empleado.listarPersonal();
            DataSet ultimo = Empleado.ultimoPersonal();
            DataSet infoAct = Empleado.buscarPersonal(id);
            DataSet usuario = usuarioName.buscarUsuario(Login.id);
            
            DataSet Fila = ConexionSQL.Ejecutar(string.Format("select Row from (SELECT ROW_NUMBER() OVER(ORDER BY idPersonal) AS Row, idPersonal from Personal) Row where idPersonal = {0}", id));

            if (btnAccion.Text == "Actualizar")
            {
                int verf = 1; 

                for (int x = 0; x < datos.Tables[0].Rows.Count; x++)
                {
                    if (x + 1 == Convert.ToInt32(Fila.Tables[0].Rows[x]["Row"].ToString()))
                        x++;
                    if (textBoxC.Text == datos.Tables[0].Rows[x]["cedula"].ToString())
                    {
                        verf = 0;
                    }
                }
                if (verf == 0)
                {
                    MessageBox.Show(textBoxC.Text + " ya hay un empleado con esta identificación.");
                }
                else
                {
                    int codigo = Convert.ToInt32(infoAct.Tables[0].Rows[0]["codigo"].ToString());
                    string nickName = usuario.Tables[0].Rows[0]["nickName"].ToString();
                    int idModificador = Login.id;
                    int estado;

                    if (checkBoxE.Checked)
                        estado = 1;
                    else
                        estado = 0;

                    Empleado = new Personal(nickName, idModificador, int.Parse(ultimo.Tables[0].Rows[0]["codigo"].ToString()) + 1, id, textBoxN.Text, textBoxA.Text, textBoxT.Text, textBoxC.Text, textBoxD.Text, textBoxCr.Text, estado);

                    if (Empleado.actualizar())
                    {
                        string mensaje = "Empleado actualizado con exito.";
                        MessageBox.Show(mensaje);

                    }
                    else
                        MessageBox.Show("Empleado no actualizado.");
                }

            }
            else
            {
                int verf = 1;

                for (int x = 0; x < datos.Tables[0].Rows.Count; x++)
                {
                    if (textBoxC.Text == datos.Tables[0].Rows[x]["cedula"].ToString())
                    {
                        verf = 0;
                    }
                }
                if (verf == 0)
                {
                    MessageBox.Show(textBoxC.Text + " ya hay un empleado con esta identificación.");
                }
                else
                {
                    string nickName = usuario.Tables[0].Rows[0]["nickName"].ToString();
                    int idModificador = Login.id;
                    int codigo;

                    try
                    {
                        codigo = Convert.ToInt32(ultimo.Tables[0].Rows[0]["codigo"]) + 1;

                    }
                    catch
                    {
                        codigo = 101;
                    }

                    usuario = usuarioName.buscarUsuarioId(textBoxU.Text);
                    id = Convert.ToInt32(usuario.Tables[0].Rows[0]["idUsuario"]);

                    if (usuarioName.buscarUsuario(textBoxU.Text))
                    {
                        if (Empleado.buscarUsuario(Convert.ToInt32(usuario.Tables[0].Rows[0]["idusuario"])))
                        {
                            MessageBox.Show(textBoxU.Text + "esta siendo utilizado por otro empleado.");
                        }
                    }
                    else
                    {
                        MessageBox.Show(textBoxU.Text + "no existe");
                    }

                    Empleado = new Personal(nickName, idModificador, codigo, id, textBoxN.Text, textBoxA.Text, textBoxT.Text, textBoxC.Text, textBoxD.Text, textBoxCr.Text, 1);
                    if (Empleado.agregar())
                    {
                        string mensaje = "Empleado agregado con exito.";
                        MessageBox.Show(mensaje);

                    }
                    else
                        MessageBox.Show("Empleado no agregado.");

                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxC_MouseEnter(object sender, EventArgs e)
        {
            if(btnAccion.Text == "Actualizar")
            {
                textBoxC.BackColor = Color.Red;
                textBoxC.ForeColor = Color.White;
            }
        }

        private void textBoxC_MouseLeave(object sender, EventArgs e)
        {
            if (btnAccion.Text == "Actualizar")
            {
                textBoxC.BackColor = Color.White;
                textBoxC.ForeColor = Color.Black;
            }
        }

        private void textBoxU_MouseEnter(object sender, EventArgs e)
        {
            if (btnAccion.Text == "Actualizar")
            {
                textBoxU.BackColor = Color.Red;
                textBoxU.ForeColor = Color.White;
            }
        }

        private void textBoxU_MouseLeave(object sender, EventArgs e)
        {
            if (btnAccion.Text == "Actualizar")
            {
                textBoxU.BackColor = Color.White;
                textBoxU.ForeColor = Color.Black;
            }
        }
    }

}
