using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Peralta100430840_lib1;
using Peralta100430840_lib1.IOAqui;
using Peralta100430840_lib1.Vehiculo;
using Peralta100430840_lib1.Personas;
using Peralta100430840_lib1.Edificacion;
using Peralta100430840_TiendaX.Pubs;

namespace Peralta100430840_WinX
{
    public partial class MainMenuForm : Form
    {
        private int cont = 0;
        private int valorboton;
        private TreeNode Sistema;
        private TreeNode Tienda;

        public MainMenuForm()
        {
            InitializeComponent();
        }

        public MainMenuForm(int resultado)
        {
            InitializeComponent();

            valorboton = resultado;

            if (valorboton == 0)
                OcultarAdmin();
            else
                OcultarUsuario();

            llenarStatus(valorboton);

        }

        public void CrearArbol()
        {
            Marca objMarca = new Marca();
            Modelo objModelo = new Modelo();
            Avion objAvion = new Avion();
            Pasajero objPasajero = new Pasajero();
            Piloto objPiloto = new Piloto();
            Aeropuerto objAeropuerto = new Aeropuerto();
            Boleta objBoletas = new Boleta();
            var objetos = new
            {
                Marcas = objMarca.getAllBrand(),
                Modelos = objModelo.getAllModel(),
                Aviones = objAvion.getTodoAvion(),
                Pasajeros = objPasajero.getAllPassanger(),
                Pilotos = objPiloto.getAllPilot(),
                Aeropuertos = objAeropuerto.getTodoAeropuerto(),
                Boletas = objBoletas.getTodaBoleta()
            };

            Sistema = treeView1.Nodes.Add("Sistema de Viajes");

            BuildingNodes(objetos.Marcas, "Marcas");
            BuildingNodes(objetos.Modelos, "Modelos");
            BuildingNodes(objetos.Aviones, "Aviones");
            BuildingNodes(objetos.Pilotos, "Pilotos");
            BuildingNodes(objetos.Pasajeros, "Pasajeros");
            BuildingNodes(objetos.Aeropuertos, "Aeropuertos");
            BuildingNodes(objetos.Boletas, "Boletas");

            CrearNodosDelPadre(0, null);

        }

        public void BuildingNodes(List<string[]> objeto, string NombreObjeto)
        {

            string objeto_string_elementos = "";
           
            TreeNode Hijo;
            Hijo = Sistema.Nodes.Add(NombreObjeto);
            TreeNode Nieto;
            foreach (var elemento in objeto)
            {
                   
                 foreach (var cosas in elemento)
                 {
                        objeto_string_elementos += cosas.ToString();
                        objeto_string_elementos += " ";
                 }

                Nieto = Hijo.Nodes.Add(objeto_string_elementos);
                    objeto_string_elementos = "";
             }

            ++cont;

        }
        private void avionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAviones objAviones = new frmAviones();
            objAviones.MdiParent = this;
            objAviones.WindowState = FormWindowState.Maximized;
            objAviones.Show();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcas objMarcas = new frmMarcas();
            objMarcas.MdiParent = this;
            objMarcas.WindowState = FormWindowState.Maximized;
            objMarcas.Show();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModelos objModelos = new frmModelos();
            objModelos.MdiParent = this;
            objModelos.WindowState = FormWindowState.Maximized;
            objModelos.Show();
        }

        private void aeropuertosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAeropuertos objAeropuertos = new frmAeropuertos();
            objAeropuertos.MdiParent = this;
            objAeropuertos.WindowState = FormWindowState.Maximized;
            objAeropuertos.Show();
        }

        private void pilotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPilotos objPilotos = new frmPilotos();
            objPilotos.MdiParent = this;
            objPilotos.WindowState = FormWindowState.Maximized;
            objPilotos.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void toolStripButton1_DoubleClick(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            cont = 0;
            if (valorboton == 0)
                CrearArbolUsuario();
            else
                CrearArbol();
        }

        private void avionesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAviones objAviones = new frmAviones();
            objAviones.MdiParent = this;
            objAviones.WindowState = FormWindowState.Maximized;
            objAviones.Show();
        }

        private void marcasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmMarcas objMarcas = new frmMarcas();
            objMarcas.MdiParent = this;
            objMarcas.WindowState = FormWindowState.Maximized;
            objMarcas.Show();
        }

        private void modelosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmModelos objModelos = new frmModelos();
            objModelos.MdiParent = this;
            objModelos.WindowState = FormWindowState.Maximized;
            objModelos.Show();
        }

        private void aeropuertosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAeropuertos objAeropuertos = new frmAeropuertos();
            objAeropuertos.MdiParent = this;
            objAeropuertos.WindowState = FormWindowState.Maximized;
            objAeropuertos.Show();
        }

        private void pilotosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmPilotos objPilotos = new frmPilotos();
            objPilotos.MdiParent = this;
            objPilotos.WindowState = FormWindowState.Maximized;
            objPilotos.Show();
        }

        private void comprarBoletaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBoletas objBoletas = new frmBoletas();
            objBoletas.MdiParent = this;
            objBoletas.WindowState = FormWindowState.Maximized;
            objBoletas.Show();
        }

        private void avionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmVerAviones objVerAviones = new frmVerAviones(valorboton);
            objVerAviones.MdiParent = this;
            objVerAviones.WindowState = FormWindowState.Maximized;
            objVerAviones.Show();

        }

        private void marcasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVerMarcas objVerMarcas = new frmVerMarcas();
            objVerMarcas.MdiParent = this;
            objVerMarcas.WindowState = FormWindowState.Maximized;
            objVerMarcas.Show();
        }

        private void modelosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVerModelos objVerModelos = new frmVerModelos();
            objVerModelos.MdiParent = this;
            objVerModelos.WindowState = FormWindowState.Maximized;
            objVerModelos.Show();
        }

        private void pilotosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVerPilotos objVerPilotos = new frmVerPilotos(valorboton);
            objVerPilotos.MdiParent = this;
            objVerPilotos.WindowState = FormWindowState.Maximized;
            objVerPilotos.Show();
        }

        private void aeropuertosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVerAeropuertos objVerAeropuerto = new frmVerAeropuertos(valorboton);
            objVerAeropuerto.MdiParent = this;
            objVerAeropuerto.WindowState = FormWindowState.Maximized;
            objVerAeropuerto.Show();
        }

        private void pasajerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerPasajeros objVerPasajeros = new frmVerPasajeros();
            objVerPasajeros.MdiParent = this;
            objVerPasajeros.WindowState = FormWindowState.Maximized;
            objVerPasajeros.Show();
        }

        private void boletasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerBoletas objVerBoletas = new frmVerBoletas();
            objVerBoletas.MdiParent = this;
            objVerBoletas.WindowState = FormWindowState.Maximized;
            objVerBoletas.Show();
        }

        private void avionesToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVerAviones objVerAviones = new frmVerAviones(valorboton);
            objVerAviones.MdiParent = this;
            objVerAviones.WindowState = FormWindowState.Maximized;
            objVerAviones.Show();
        }

        private void marcasToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVerMarcas objVerMarcas = new frmVerMarcas();
            objVerMarcas.MdiParent = this;
            objVerMarcas.WindowState = FormWindowState.Maximized;
            objVerMarcas.Show();
        }

        private void modelosToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVerModelos objVerModelos = new frmVerModelos();
            objVerModelos.MdiParent = this;
            objVerModelos.WindowState = FormWindowState.Maximized;
            objVerModelos.Show();
        }

        private void aeropuertosToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVerAeropuertos objVerAeropuerto = new frmVerAeropuertos(valorboton);
            objVerAeropuerto.MdiParent = this;
            objVerAeropuerto.WindowState = FormWindowState.Maximized;
            objVerAeropuerto.Show();
        }

        private void pilotosToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVerPilotos objVerPilotos = new frmVerPilotos(valorboton);
            objVerPilotos.MdiParent = this;
            objVerPilotos.WindowState = FormWindowState.Maximized;
            objVerPilotos.Show();
        }

        private void pasajerosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVerPasajeros objVerPasajeros = new frmVerPasajeros();
            objVerPasajeros.MdiParent = this;
            objVerPasajeros.WindowState = FormWindowState.Maximized;
            objVerPasajeros.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerBoletas objVerBoletas = new frmVerBoletas();
            objVerBoletas.MdiParent = this;
            objVerBoletas.WindowState = FormWindowState.Maximized;
            objVerBoletas.Show();
        }

        private void viajesPorAeropuertoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViajesPorAeropuerto objViajesPorAeropuerto = new frmViajesPorAeropuerto();
            objViajesPorAeropuerto.MdiParent = this;
            objViajesPorAeropuerto.WindowState = FormWindowState.Maximized;
            objViajesPorAeropuerto.Show();

        }

        private void dineroPagadoPorCadaPasajeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boleta objReadingOnly = new Boleta();
            List<string> Data = objReadingOnly.getTotalDineroPasajeros();
            MessageBox.Show(Data[0] + "\n\n---------------------------------------------------------------------------------" +
               "\n\tTotal de dinero por todos los pasajeros : " + Data[1]);

        }

        private void dineroEnUnRangoDeFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDineroRangoFecha objDineroFecha = new frmDineroRangoFecha();
            objDineroFecha.Show();
        }

        private void dondeMásSeLlegaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAeropuertosReporteSeLlegan objAeropuertosReporteSeLlegan = new frmAeropuertosReporteSeLlegan();
            objAeropuertosReporteSeLlegan.MdiParent = this;
            objAeropuertosReporteSeLlegan.WindowState = FormWindowState.Maximized;
            objAeropuertosReporteSeLlegan.Show();
        }

        private void dondeMásSeParteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAeropuertosReportesMasSeVan objAeropuertosReportesMasSeVan = new frmAeropuertosReportesMasSeVan();
            objAeropuertosReportesMasSeVan.MdiParent = this;
            objAeropuertosReportesMasSeVan.WindowState = FormWindowState.Maximized;
            objAeropuertosReportesMasSeVan.Show();
        }

        private void OcultarAdmin()
        {  
            crearToolStripMenuItem.Visible = false;
            reportesToolStripMenuItem.Visible = false;
            toolStripSplitButton1.Visible = false;
            marcasToolStripMenuItem3.Visible = false;
            modelosToolStripMenuItem3.Visible = false;
            pasajerosToolStripMenuItem1.Visible = false;
            ventasToolStripMenuItem.Visible = false;
            marcasToolStripMenuItem1.Visible = false;
            modelosToolStripMenuItem1.Visible = false;
            pasajerosToolStripMenuItem.Visible = false;
            boletasToolStripMenuItem.Visible = false;
            librosToolStripMenuItem.Visible = false;
            autoresToolStripMenuItem.Visible = false;
            editoraToolStripMenuItem.Visible = false;
            tiendasToolStripMenuItem.Visible = false;
            empleosToolStripMenuItem.Visible = false;
            empleadoToolStripMenuItem.Visible = false;

            this.Text = "Sistema de Viajes Usuario";

            CrearArbolUsuario();
        }

        public void CrearArbolUsuario()
        {
            Marca objMarca = new Marca();
            Modelo objModelo = new Modelo();
            Avion objAvion = new Avion();
            Pasajero objPasajero = new Pasajero();
            Piloto objPiloto = new Piloto();
            Aeropuerto objAeropuerto = new Aeropuerto();
            Boleta objBoletas = new Boleta();

            var objetos = new
            {
                Aviones = DataInterface.MostrarElementosLista("ListaDeAviones.txt"),
                Pilotos = DataInterface.MostrarElementosLista("ListaDePiloto.txt"),
                Aeropuertos = DataInterface.MostrarElementosLista("ListaDeAeropuerto.txt"),
            };

            Sistema = treeView1.Nodes.Add("Sistema de Viajes");

            BuildingNodesUsario(objetos.Aviones, "Aviones");
            BuildingNodesUsario(objetos.Pilotos, "Pilotos");
            BuildingNodesUsario(objetos.Aeropuertos, "Aeropuertos");

            CrearNodosDelPadre(0, null);
        }

        public void BuildingNodesUsario(List<string> objeto, string NombreObjeto)
        {

            string objeto_string_elementos = "";
            TreeNode Hijo;

            Hijo = Sistema.Nodes.Add(NombreObjeto);

            foreach (var elemento in objeto)
            {

                foreach (var cosas in elemento)
                {
                    objeto_string_elementos += cosas.ToString();
                    objeto_string_elementos += "";
                }

                Hijo.Nodes.Add(objeto_string_elementos);
                objeto_string_elementos = "";
            }

            ++cont;
        }

        private void OcultarUsuario()
        {
            comprarBoletaToolStripMenuItem.Visible = false;
            comprarLibroToolStripMenuItem.Visible = false;

            CrearArbol();
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTitle Titles = new frmTitle(1);
            Titles.MdiParent = this;
            Titles.WindowState = FormWindowState.Maximized;
            Titles.Show();
        }    

        private void autoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTitle Authors = new frmTitle(2);
            Authors.MdiParent = this;
            Authors.WindowState = FormWindowState.Maximized;
            Authors.Show();
        }

        private void editoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTitle Publishers = new frmTitle(3);
            Publishers.MdiParent = this;
            Publishers.WindowState = FormWindowState.Maximized;
            Publishers.Show();
        }

        private void tiendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTitle Stores = new frmTitle(4);
            Stores.MdiParent = this;
            Stores.WindowState = FormWindowState.Maximized;
            Stores.Show();
        }

        private void empleosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTitle Jobs = new frmTitle(5);
            Jobs.MdiParent = this;
            Jobs.WindowState = FormWindowState.Maximized;
            Jobs.Show();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTitle Employee = new frmTitle(6);
            Employee.MdiParent = this;
            Employee.WindowState = FormWindowState.Maximized;
            Employee.Show();
        }

        protected void llenarStatus(int who)
        {
            frmLoginUser login = new frmLoginUser();
            
            toolStripStatusLabel2.Text = Convert.ToString(DateTime.Now) + "                   ";
            if (who == 1)
                toolStripStatusLabel4.Text = "Administrador                         ";
            else
                toolStripStatusLabel4.Text = "Comprador                        ";

            //if()
            toolStripStatusLabel6.Text = "ninguno";

        }

        public void cambiarTexto(string text)
        {
            toolStripStatusLabel4.Text = "Comprador" + "                        ";
        }

        private void comprarLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoginUser Login = new frmLoginUser();
            Login.MdiParent = this;
            Login.Show();
        }

        private void CrearNodosDelPadre(int indicePadre, TreeNode nodePadre)
        {
            Tienda = treeView1.Nodes.Add("Tienda de Libros");
            TreeNode Hijo = Tienda.Nodes.Add("Editoras");

            Publishers objPublishers = new Publishers();
            objPublishers.Buscar("", false);
            objPublishers.getobj_AllPublishers();

            /*//TreeNode Nieto = Hijo.Nodes.Add(Convert.ToString(objTablePub));

            // Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
            DataView dataViewHijos = new DataView(objPublishers.getobj_AllPublishers());
            dataViewHijos.RowFilter = objPublishers.getobj_AllPublishers().Columns["pub_name"].ColumnName + " = " + indicePadre;

            // Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
            foreach (DataRowView dataRowCurrent in dataViewHijos)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = dataRowCurrent["pub_name"].ToString().Trim();

                // si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
                // del primer nivel que no dependen de otro nodo.
                if (nodePadre == null)
                {
                    treeView1.Nodes.Add(nuevoNodo);
                }
                // se añade el nuevo nodo al nodo padre.
                else
                {
                    nodePadre.Nodes.Add(nuevoNodo);
                }

                // Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.

                CrearNodosDelPadre(Int32.Parse(dataRowCurrent["pub_name"].ToString()), nuevoNodo);
            }*/
        }

        private void ventasLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentas Ventas = new frmVentas();
            Ventas.MdiParent = this;
            Ventas.WindowState = FormWindowState.Maximized;
            Ventas.Show();
        }

        private void acercaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcerca Acerca = new frmAcerca();
            Acerca.MdiParent = this;
            Acerca.WindowState = FormWindowState.Maximized;
            Acerca.Show();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAyuda Ayuda = new frmAyuda();
            Ayuda.MdiParent = this;
            Ayuda.WindowState = FormWindowState.Maximized;
            Ayuda.Show();
        }
    }
}
