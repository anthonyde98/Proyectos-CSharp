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
using System.IO;
using System.Management.Instrumentation;

namespace PrestamosWF
{
    public partial class CrearUsuario : Form
    {
        private int id;
        private DataSet infoAct;
        private DataSet Fila;
        private string file;
        private char dif;
        public CrearUsuario()
        {
            InitializeComponent();
        }

        public CrearUsuario(char dif)
        {
            InitializeComponent();
            this.dif = dif;
        }

        public CrearUsuario(int p_id)
        {
            id = p_id;
            InitializeComponent();

            lbNivel.Visible = false;
            cblvl.Visible = false;
            btnCr.Text = "Actualizar";
            Usuario acceso = new Usuario();
            infoAct = acceso.buscarUsuario(id);
            byte[] foto = new byte[0];
            foto = (byte[])infoAct.Tables[0].Rows[0]["imagen"];
            MemoryStream memoryS = new MemoryStream(foto);
            pictureBox.Image = Image.FromStream(memoryS);
            textUser.Text = infoAct.Tables[0].Rows[0]["nickName"].ToString();

        }


        private void btnCr_Click(object sender, EventArgs e)
        {
            Usuario objetoUsuario = new Usuario();
            DataSet datos = objetoUsuario.logear();
            DataSet ultimo = objetoUsuario.ultimoUsuario();
            Fila = ConexionSQL.Ejecutar(string.Format("select Row from (SELECT ROW_NUMBER() OVER(ORDER BY idUsuario) AS Row, idUsuario from Usuario) Row where idUsuario = {0}", id));
            MemoryStream memory = new MemoryStream();

            int verf = 0;

            if (textPass.Text == textPass2.Text)
            {
                if (btnCr.Text == "Actualizar")
                {
                    for (int x = 0; x < datos.Tables[0].Rows.Count; x++)
                    {
                        if (x + 1 == Convert.ToInt32(Fila.Tables[0].Rows[0]["Row"].ToString()))
                            x++;

                        if (textUser.Text == datos.Tables[0].Rows[x]["nickName"].ToString())
                            verf = 1;

                        else
                            verf = 0;
                    }

                    if (verf == 1)
                    {

                        MessageBox.Show(textUser.Text + " ya esta siendo utilizado.");
                        textPass.Clear();
                        textUser.Clear();

                    }
                    else
                    {
                        int codigo = Convert.ToInt32(infoAct.Tables[0].Rows[0]["codigo"].ToString());
                        string nickName;
                        if (textUser.Text == "")
                            nickName = infoAct.Tables[0].Rows[0]["nickName"].ToString();
                        else
                            nickName = textUser.Text;

                        string contrasena;
                        if (textPass2.Text == "")
                            contrasena = infoAct.Tables[0].Rows[0]["contrasena"].ToString();
                        else
                            contrasena = textPass2.Text;
                            
                        int estado = Convert.ToInt32(infoAct.Tables[0].Rows[0]["estado"]);
                        int nivel = Convert.ToInt32(infoAct.Tables[0].Rows[0]["nivel"].ToString());

                        try
                        {
                            objetoUsuario = new Usuario(codigo, nickName, contrasena, estado, nivel, id, nickName, file);
                        }
                        catch { }

                        if (objetoUsuario.actualizar())
                        {
                            string mensaje = "Usuario actualizado con exito";
                            MessageBox.Show(mensaje);

                        }
                        else
                            MessageBox.Show("Usuario no actualizado");
                    }                           

                    
                }
                else
                {
                    int codigo;

                    try
                    {
                        codigo = Convert.ToInt32(ultimo.Tables[0].Rows[0]["codigo"].ToString());

                    }
                    catch
                    {
                        codigo = 100;
                    }

                    for (int x = 0; x < datos.Tables[0].Rows.Count; x++)
                    {
                        if (textUser.Text == datos.Tables[0].Rows[x]["nickName"].ToString())
                        {

                            MessageBox.Show(textUser.Text + " ya esta siendo utilizado.");
                            textPass.Clear();
                            textUser.Clear();

                        }
                        else
                        {   
                            if(file == "")
                            {
                                MessageBox.Show("Debe de colocar una imagen.");
                            }
                            else
                            {
                                try
                                {
                                    objetoUsuario = new Usuario(codigo + 1, textUser.Text, textPass.Text, 1, Convert.ToInt32(cblvl.Text), Login.id, Login.usuario, file);

                                }
                                catch{}

                                if (objetoUsuario.agregar())
                                {
                                    string mensaje = "Usuario agregado con exito.";
                                    MessageBox.Show(mensaje);

                                }
                                else
                                    MessageBox.Show("Usuario no agregado.");

                                this.Close();
                                Login login = new Login();
                                login.Show();
                            }                          
                        }
                    }
                }
            }
            else
                MessageBox.Show("Las contraseñas no coinciden.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog imagen = new OpenFileDialog();
            
            imagen.InitialDirectory = "c:\\";
            imagen.Filter = "Archivos jpg (*.jpg)|*.jpg|Archivos png(*.png)|*.png";
            imagen.FilterIndex = 1;
            imagen.RestoreDirectory = true;

            DialogResult resultado = imagen.ShowDialog();

            if (resultado == DialogResult.OK)
            {

                file = imagen.FileName;
                
            }

            pictureBox.Image = Image.FromFile(imagen.FileName);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void CrearUsuario_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(btnCr.Text == "Actualizar")
            {
                this.Close();
            }
            else if(btnCr.Text == "Crear" && dif == ' ')
            {
                this.Close();
                Login login = new Login();
                login.Show();
            }
            else
            {
                this.Close();
            }
        }
    }
}
