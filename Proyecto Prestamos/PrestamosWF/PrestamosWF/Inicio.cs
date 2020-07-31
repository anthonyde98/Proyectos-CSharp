using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace PrestamosWF
{
    public partial class Inicio : Form
    {
        //Campos
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form formHijoActual;

        //Constructor
        public Inicio()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            //Form
            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            if(Login.nivel != 1)
            {
                BUser.Visible = false;
                BPersonal.Visible = false;
            }

            //Sesion
            Usuario sesion = new Usuario();
            DataSet UsuarioLinea;
            DataSet EmpleadoLinea;
            UsuarioLinea = sesion.buscarUsuario(Login.id);
            EmpleadoLinea = sesion.buscarPersonal(Login.id);
            byte[] datosB = new byte[0];

            datosB = (byte[])UsuarioLinea.Tables[0].Rows[0]["imagen"];
            MemoryStream memory = new MemoryStream(datosB);
            PBImagen.Image = Image.FromStream(memory);

            try
            {
                Convert.ToInt32(EmpleadoLinea.Tables[0].Rows[0]["idPersonal"]);
                iconSesion.Text = EmpleadoLinea.Tables[0].Rows[0]["nombre"].ToString();
                labelCargo.Text = EmpleadoLinea.Tables[0].Rows[0]["cargo"].ToString();
            }
            catch
            {
                MessageBox.Show("Este usuario no esta asignado a un empleado.");
            }

            //Insertar Pagos Retarsados
            Pago Pagos = new Pago();
            Pagos.agregarPagoRetrasado();

            //Asignar label tiempo 
            LabelTime.Text = DateTime.Now.ToString();

        }

        //Estructura de colores
        private struct ColoresRGB
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        //Metodos
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                ResaltadoBoton();
                //Boton
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                // Borde izquierdo del boton
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Icono de formulario hijo actual
                iconoForm.IconChar = currentBtn.IconChar;
                iconoForm.IconColor = color;

            }
        }

        private void ResaltadoBoton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

            }
        }

        private void BCliente_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, ColoresRGB.color1);

            FCliente formCliente = new FCliente();
            AbrirFormHijo(formCliente);
        }

        private void BPrestamo_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, ColoresRGB.color2);

            FPrestamo formPrestamo = new FPrestamo();
            AbrirFormHijo(formPrestamo);
        }

        private void Bpago_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, ColoresRGB.color3);

            FPago formPago = new FPago();
            AbrirFormHijo(formPago);
        }

        private void BPersonal_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, ColoresRGB.color4);

            FEmpleado formEmpleado= new FEmpleado();
            AbrirFormHijo(formEmpleado);
        }

        private void BUser_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, ColoresRGB.color5);

            FUsuario formUsuario = new FUsuario();
            AbrirFormHijo(formUsuario);
        }

        private void BtnLogo_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            ResaltadoBoton();
            leftBorderBtn.Visible = false;
            iconoForm.IconChar = IconChar.Home;
            iconoForm.IconColor = Color.MediumPurple;
            lbHome.Text = "Home";
        }

        // Mover Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormHijo(Form formHijo)
        {
            if(formHijoActual != null)
            {
                formHijoActual.Close();
            }

            formHijoActual = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelEscritorio.Controls.Add(formHijo);
            panelEscritorio.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
            lbHome.Text = currentBtn.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Reset();
            formHijoActual.Close();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else
                WindowState = FormWindowState.Maximized;
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseLeave_1(object sender, EventArgs e)
        {
            btnActualizar.Visible = false;
            btnCS.Visible = false;
        }

        private void iconSesion_Click(object sender, EventArgs e)
        {
            
            if(btnActualizar.Visible && btnCS.Visible)
            {
                btnActualizar.Visible = false;
                btnCS.Visible = false;
            }
            else
            {
                btnActualizar.Visible = true;
                btnCS.Visible = true;
            }
        }

        private void panelTitleBar_MouseEnter(object sender, EventArgs e)
        {
            btnActualizar.Visible = false;
            btnCS.Visible = false;
        }

        private void btnCS_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CrearUsuario Actualizar = new CrearUsuario(Login.id);
            Actualizar.Show();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelEscritorio_MouseEnter(object sender, EventArgs e)
        {
            btnActualizar.Visible = false;
            btnCS.Visible = false;
        }
    }
}
