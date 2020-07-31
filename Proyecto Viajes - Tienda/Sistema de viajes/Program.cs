using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peralta100430840_lib1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Vuelve el fondo de color blanco y las letras de color negro.

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            MenuStart();
        }

        static void MenuStart()
        {
            int option = 88;
            do
            {
                //Menu de Inicio. Para accesar al menu del cliente y el menu administrador.

                Console.Clear();
                Console.WriteLine("\n\n\t\t\t\tMenu de Inicio\n");
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("\n\t1) Acceso Cliente");
                Console.WriteLine("\t2) Acceso Administrador");
                Console.WriteLine("\t0) Salir");
                Console.WriteLine("\n---------------------------------------------------------------------------------");
                Console.Write("\n\n\tEntre una opcion : ");
                int x;
                string opening = Console.ReadLine();
                if (int.TryParse(opening, out x))
                    option = int.Parse(opening);
                switch (option)
                {
                    case 1:
                        //Acceso al menu cliente. Para que haya acceso el se debe hacer login al accesar a la opcion administrador.

                        if (IOAqui.DataInterface.ExisteArchivo("Contraseña.txt") && IOAqui.DataInterface.ExisteArchivo("Boleta.txt") &&
                        IOAqui.DataInterface.ExisteArchivo("Avion.txt") && IOAqui.DataInterface.ExisteArchivo("Piloto.txt") &&
                        IOAqui.DataInterface.ExisteArchivo("Aeropuerto.txt")) //Verificación del usuario administrador y del sistema (subida).
                            option = MenuCostumerTrip();
                        else
                        {
                            Console.Write("\n\n---------------------------------------------------------------------------------");
                            Console.Write("\n\n El administrador debe subir el sistema, presione una tecla para continuar...");
                            Console.ReadKey();
                            MenuStart();
                        }
                        break;
                    case 2:
                        option = AddAdministrator(); //Acceso al menu administrador.
                        break;
                    case 0:
                        break;
                    default:
                        Console.Write("\n\n---------------------------------------------------------------------------------");
                        Console.Write("\n\n *" + opening + "* Es una opcion incorrecta, presione una tecla para continuar...");
                        Console.ReadKey();
                        MenuStart();
                        break;

                }
            } while (option != 0);
            return;
        }

        static int MenuCostumerTrip()
        {
            int option = 88;
            do
            {
                //Menu del Cliente. Para comprar boleta y ver catologo de aviones, aeropuertos y pilotos.

                Console.Clear();
                Console.WriteLine("\n\t\t\t\tMenu de Viajes");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("\n\t1) Apartar Vuelo (Comprar Boleto)");
                Console.WriteLine("\t2) Catalogo de Aviones (Buscar y Leer)");
                Console.WriteLine("\t3) Catalogo de Pilotos (Pilotos Disponibles)");
                Console.WriteLine("\t4) Areopuertos Disponibles");
                Console.WriteLine("\t5) Volver A Menu Inicio");
                Console.WriteLine("\t0) Salir");
                Console.WriteLine("---------------------------------------------------");
                Console.Write("\n\n\t Entre una opcion:");
                int x;
                string opening = Console.ReadLine();
                if (int.TryParse(opening, out x))
                    option = int.Parse(opening);
                switch (option)
                {
                    case 1:
                        BuyTicket();//Llama a modelo
                        break;
                    case 2:
                        CostumerAirplanes();
                        break;
                    case 3:
                        CostumerPilots();
                        break;
                    case 4:
                        CostumerAirport();
                        break;
                    case 5:
                        MenuStart();
                        break;
                    case 0:
                        break;
                    default:
                        Console.Write("\n\n---------------------------------------------------------------------------------");
                        Console.Write("\n\n *" + opening + "* Es una opcion incorrecta, presione una tecla para continuar...");
                        Console.ReadKey();
                        MenuCostumerTrip();
                        break;

                }
            } while (option != 0); // ----
            return option;
        }

        static void CostumerPilots()
        {
            //Lista de Pilotos a ser mostrada al usuario.

            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\tPilotos\n");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("\n\n Lista de Pilotos disponibles para volar\n --------------------------------------------\n");
            Console.WriteLine(IOAqui.DataInterface.MostrarElementosLista("ListaDePiloto.txt"));
            Console.Write("\n\n------------------------------------------------\nPresione una tecla para continuar....");
            Console.ReadKey();
        }

        static void CostumerAirport()
        {
            //Lista de Areopurtos a ser mostrada al usuario.

            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\tAeropuertos\n");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("\n\n Lista de Aeropuertos disponibles para volar\n -------------------------------------------------\n");
            Console.WriteLine(IOAqui.DataInterface.MostrarElementosLista("ListaDeAeropuerto.txt"));
            Console.Write("\n\n------------------------------------------------\nPresione una tecla para continuar....");
            Console.ReadKey();
        }

        static void CostumerAirplanes()
        {
            //Lista de Avones a ser mostrada al usuario.

            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\tAviones\n");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("\n\n Lista de Aviones disponibles para volar\n --------------------------------------------\n");
            Console.WriteLine(IOAqui.DataInterface.MostrarElementosLista("ListaDeAviones.txt"));
            Console.Write("\n\n------------------------------------------------\nPresione una tecla para continuar....");
            Console.ReadKey();
        }

        private static void BuyTicket()
        {
            try
            {
                //Menu para comprar boleto.

                Console.Clear();
                Console.WriteLine("\n\n\t\t\t\tRegistrar Boleta\n");
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("\n Ingreso de Datos Para Registrar Boleta\n --------------------------------------------\n");
                Console.Write("\n Nombre Completo : ");
                string lv_NombrePasajero = Console.ReadLine();
                Console.Write("\n Cedula de Indentificacion : ");
                string lv_Cedula = Console.ReadLine();
                Console.Write("\n Fecha de Nacimiento : ");
                string lv_FechaNacimento = Console.ReadLine();
                Console.Write("\n Tipo de Sangre : ");
                string lv_TipoSangre = Console.ReadLine();
                Console.Write("\n Estado Civil : ");
                string lv_EstadoCivil = Console.ReadLine();
                Console.Write("\n Direccion : ");
                string lv_Direccion = Console.ReadLine();
                Console.Write("\n Numero de Celular : ");
                string lv_Celular = Console.ReadLine();
                Console.Write("\n Numero de Telefono : ");
                string lv_Telefono = Console.ReadLine();
                Console.Write("\n Ocupacion : ");
                string lv_Ocupacion = Console.ReadLine();
                Console.WriteLine("\n\n Lista de Pilotos disponibles para volar\n --------------------------------------------\n");
                Console.WriteLine(IOAqui.DataInterface.MostrarElementosLista("ListaDePiloto.txt"));
                Console.Write("Piloto con que desea Volar : ");
                int lv_Piloto = int.Parse(Console.ReadLine());
                Console.WriteLine("\n\n Lista de Clases disponibles para volar\n --------------------------------------------\n");
                Console.WriteLine(Peralta100430840_lib1.Boleta.getAllClase());
                Console.Write("Clase desea volar : ");
                string lv_str_clase = Console.ReadLine();
                Console.Write("\n\nPeso de Equipaje, en Libras : ");
                double lv_str_Peso_Equipaje = int.Parse(Console.ReadLine());
                Console.WriteLine("\n\n Lista de Aeropuertos disponibles\n --------------------------------------------\n");
                Console.WriteLine(IOAqui.DataInterface.MostrarElementosLista("ListaDeAeropuerto.txt")); Console.Write("Aeropuerto de Origen: ");
                int lv_str_origen = int.Parse(Console.ReadLine());
                Console.Write("\nAeropuerto de Destino : ");
                int lv_str_destino = int.Parse(Console.ReadLine());
                Console.Write("\n\nFecha de Partida : ");
                string lv_str_fecha_par = Console.ReadLine();
                Peralta100430840_lib1.Boleta objBoteta = new Peralta100430840_lib1.Boleta(lv_Piloto, lv_str_clase, lv_str_origen, lv_str_destino,
                lv_str_fecha_par, lv_str_Peso_Equipaje);
                Personas.Pasajero objElPasajero = new Personas.Pasajero(lv_NombrePasajero, lv_Cedula, lv_FechaNacimento, lv_TipoSangre,
                lv_EstadoCivil, lv_Direccion, lv_Celular, lv_Telefono, lv_Ocupacion);
                Console.WriteLine("\n\nSu Boleta Ha sido Regista Exitosamente!!!\n\nPresione una tecla para continuar...");
                Console.WriteLine("\n\n---------------------------\nLos Datos que ha ingresado son :\n\n" + objElPasajero.ToString());
                Console.ReadKey();
                objBoteta = null;
                objElPasajero = null;
            }
            catch (Exception objError)
            {
                Console.WriteLine(objError.ToString());
                Console.ReadKey();
            }
        }

        static void Administrator()
        {
            int option = 88;
            do
            {
                //Menu Administrador. Desde aquí se hara todo tipo de cambios y verificación del sistema.

                Console.Clear();
                Console.WriteLine("\n\n\t\t\t\tMenu de Acceso\n");
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("\n\t1) Ver Pasajeros Registrados");
                Console.WriteLine("\t2) Agregar Piloto");
                Console.WriteLine("\t3) Agregar Avion");
                Console.WriteLine("\t4) Agregar Aeropuerto");
                Console.WriteLine("\t5) Marcas de Aviones");
                Console.WriteLine("\t6) Modelos de Aviones");
                Console.WriteLine("\t7) Ver Pilotos Registrados");
                Console.WriteLine("\t8) Ver Aviones Registrados");
                Console.WriteLine("\t9) Ver Aeropuertos Registrados");
                Console.WriteLine("\t10) Total de Viajes por Aeropuerto");
                Console.WriteLine("\t11) Total de dinero pagado por cada pasajero");
                Console.WriteLine("\t12) Total de dinero en un rango de fecha");
                Console.WriteLine("\t13) Los 3 Aeropuertos de donde mas se llega");
                Console.WriteLine("\t14) Los 3 Aeropuertos de donde mas se parte");
                Console.WriteLine("\t15) Cambiar Datos de Ingreso");
                Console.WriteLine("\t16) Volver al Menu de Inicio");
                Console.WriteLine("\t0) Salir");
                Console.WriteLine("\n---------------------------------------------------------------------------------");
                Console.Write("\n\tEntre una opcion : ");
                int x;
                string entrada = Console.ReadLine();
                if (int.TryParse(entrada, out x))
                    option = int.Parse(entrada);
                switch (option)
                {
                    case 1:
                        Tickets();
                        break;
                    case 2:
                        AddPilot();
                        break;
                    case 3:
                        AddAirplane();
                        break;
                    case 4:
                        AddAirport();
                        break;
                    case 5:
                        BrandUserScreen();
                        break;
                    case 6:
                        BrandDisplay();
                        option = 25;
                        break;
                    case 7:
                        PilotsList();
                        break;
                    case 8:
                        AirplaneList();
                        break;
                    case 9:
                        Airport();
                        break;
                    case 10:
                        TotalFlights();
                        break;
                    case 11:
                        TotalMoneyPerPassangers();
                        break;
                    case 12:
                        TotalMoneyPerDateRank();
                        break;
                    case 13:
                        AirportPlusDestination();
                        break;
                    case 14:
                        AirportPlusOrigin();
                        break;
                    case 15:
                        ChangeData();
                        break;
                    case 16:
                        MenuStart();
                        break;
                    case 0:
                        break;
                    default:
                        Console.Write("\n\n---------------------------------------------------------------------------------");
                        Console.Write("\n\n *" + entrada + "* Es una opcion incorrecta, presione una tecla para continuar...");
                        Console.ReadKey();
                        Administrator();
                        break;
                }
            } while (option != 0);
            return;
        }

        static int AddAdministrator()
        {
            //Creacion e inicio de sesion del administrador.

            Console.Clear();
            if (!IOAqui.DataInterface.ExisteArchivo("Contraseña.txt"))
                Console.WriteLine("\n\n\t\t\t\t Crear Usuario\n");
            else
                Console.WriteLine("\n\n\t\t\t\t Inicio de Sesion\n");
            Console.WriteLine("---------------------------------------------------------------------------------");
            System.Console.SetCursorPosition(0, 13);
            Console.WriteLine("---------------------------------------------------------------------------------");
            System.Console.SetCursorPosition(0, 5);
            Console.Write("\n\n\tIntroduce el nombre del administrador : ");
            string user = Console.ReadLine();
            Console.Write("\n\n\tIntroduce la contraseña para {0} : ", user);
            string password = IOAqui.DataInterface.Contraseña.ReadPassword();
            System.Console.SetCursorPosition(0, 15);
            if (IOAqui.DataInterface.ExisteArchivo("Contraseña.txt"))
            {
                if (IOAqui.DataInterface.Desencriptar("Contraseña.txt") == password &&
                IOAqui.DataInterface.Desencriptar("Usuario.txt") == user)
                    Administrator();
                else
                {
                    Console.Write(" Usuario o Contraseña incorrecta, presione una tecla para continuar...");
                    Console.ReadKey();
                    AddAdministrator();
                    return 0;
                }
            }
            else
            {
                Console.Write(" Su nuevo usuario es {0} y su nueva contraseña es {1}.\n\n Presione una tecla para guardar y volver al Menu Principal...", user, password);
                Console.ReadKey();
                IOAqui.DataInterface.AgregarATxt("Usuario.txt", user);
                IOAqui.DataInterface.AgregarATxt("Contraseña.txt", password);
                MenuStart();
            }
            return 0;
        }

        static void ChangeData()
        {
            //Cambiar los datos del administrador.

            Console.Write("\n---------------------------------------------------------------------------------\n\tIntroduce la contraseña actual: ");
            string password = IOAqui.DataInterface.Contraseña.ReadPassword();
            if (IOAqui.DataInterface.Desencriptar("Contraseña.txt") == password)
            {
                IOAqui.DataInterface.BorrarDatos("Usuario.txt", "Contraseña.txt");
                AddAdministrator();
            }
            else
            {
                Console.Write("\tContraseña incorrecta, presione una tecla para continuar...");
                Console.ReadKey();
                Administrator();
            }
        }

        static void AddPilot()
        {
            //Para Ingresar un piloto.

            try
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t\tIngresar Nuevo Piloto\n");
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("\n Ingreso de Datos Para Registrar el Piloto\n --------------------------------------------\n");
                Console.Write("\n Passport : ");
                string Passport = Console.ReadLine();
                Console.Write("\n Nombre Completo : ");
                string PilotName = Console.ReadLine();
                Console.Write("\n Cantidad de Años de Experiencia : ");
                int ExpYears = int.Parse(Console.ReadLine());
                Console.Write("\n Direccion : ");
                string Address = Console.ReadLine();
                Console.Write("\n Tipo de Sangre : ");
                string BloodType = Console.ReadLine();
                Console.Write("\n Numero de Celular : ");
                string CellphoneNumber = Console.ReadLine();
                Console.Write("\n Numero de Telefono : ");
                string TelephoneNumber = Console.ReadLine();
                Console.Write("\n Estado Civil : ");
                string MaritalStatus = Console.ReadLine();
                Console.Write("\n Sueldo Mensual : ");
                double Salary = double.Parse(Console.ReadLine());
                Console.Write("\n Fecha de Nacimiento : ");
                string BirthDate = Console.ReadLine();
                Console.Write("\n Fecha de Contratacion : ");
                string DealDate = Console.ReadLine();
                Console.WriteLine(IOAqui.DataInterface.MostrarElementosLista("ListaDeAviones.txt"));
                Console.Write("Avion Asignado para Volar : ");
                int AssignedAirplane = int.Parse(Console.ReadLine());
                Personas.Piloto ElPiloto = new Personas.Piloto(Passport, PilotName, ExpYears, Address, BloodType,
                CellphoneNumber, TelephoneNumber, MaritalStatus, Salary, BirthDate, DealDate, AssignedAirplane);
                Console.WriteLine(ElPiloto.ToString());
                Console.ReadKey();
            }
            catch (Exception objError)
            {
                Console.WriteLine(objError.ToString());
                Console.ReadKey();
            }
        }

        static void Tickets()
        {
            //Mostrar y buscar todos los pasajeros registrados.

            Console.Clear();
            Personas.Pasajero objBoletaReaonly = new Personas.Pasajero();
            Console.WriteLine(objBoletaReaonly.getAllPassanger());
            Console.Write("\nDesea Buscar un Pasajero para ver el Boleto? S -- > si : ");
            string option = Console.ReadLine();
            if (option == "S" || option == "s")
            {
                Console.Write("\n--------------------------------------------------\n Digite el nombre: ");
                string name = Console.ReadLine();
                if (objBoletaReaonly.Buscar(name))
                    Console.WriteLine("\n--------------------------------------------------\n\n" + objBoletaReaonly.ToString());
                else
                    Console.WriteLine("\n\nBusqueda no encontrada en la base de datos");
            }
            Console.Write("\n\n------------------------------------------------\nPresione una tecla para continuar....");
            Console.ReadKey();
        }

        static void AirplaneList()
        {
            //Mostrar y buscar todos los aviones registrados.

            Console.Clear();
            Vehiculo.Avion objAvionReaonly = new Vehiculo.Avion();
            Console.WriteLine(objAvionReaonly.getTodoAvion());
            Console.Write("\nDesea Buscar un Avion? S -- > si : ");
            string option = Console.ReadLine();
            if (option == "S" || option == "s")
            {
                Console.Write("\n--------------------------------------------------\n Digite Nombre: ");
                string name = Console.ReadLine();
                if (objAvionReaonly.Buscar(name))
                    Console.WriteLine("\n--------------------------------------------------\n\n" + objAvionReaonly.ToString());
                else
                    Console.WriteLine("\n\nBusqueda no encontrada en la base de datos");
            }
            Console.Write("\n\n------------------------------------------------\nPresione una tecla para continuar....");
            Console.ReadKey();
        }

        static void PilotsList()
        {
            //Mostrar y buscar todos los pilotos registrados.

            Console.Clear();
            Personas.Piloto objPilotpReaonly = new Personas.Piloto();
            Console.WriteLine(objPilotpReaonly.getAllPilot());
            Console.Write("\nDesea Buscar un Piloto? S -- > si : ");
            string option = Console.ReadLine();
            if (option == "S" || option == "s")
            {
                Console.Write("\n--------------------------------------------------\n Digite el nombre: ");
                string name = Console.ReadLine();
                if (objPilotpReaonly.Buscar(name))
                    Console.WriteLine("\n--------------------------------------------------\n\n" + objPilotpReaonly.ToString());
                else
                    Console.WriteLine("\n\nBusqueda no encontrada en la base de datos");
            }
            Console.Write("\n\n------------------------------------------------\nPresione una tecla para continuar....");
            Console.ReadKey();
        }

        static void Airport()
        {
            //Mostrar y buscar todos los aeropuertos registrados.

            Console.Clear();
            Edificacion.Aeropuerto objAeropuertoReaonly = new Edificacion.Aeropuerto();
            Console.WriteLine(objAeropuertoReaonly.getTodoAeropuerto());
            Console.Write("\nDesea Buscar un Aeropuerto? S -- > si : ");
            string op = Console.ReadLine();
            if (op == "S" || op == "s")
            {
                Console.Write("\n--------------------------------------------------\n Digite el nombre: ");
                string name = Console.ReadLine();
                if (objAeropuertoReaonly.Buscar(name))
                    Console.WriteLine("\n--------------------------------------------------\n\n" + objAeropuertoReaonly.ToString());
                else
                    Console.WriteLine("\n\nBusqueda no encontrada en la base de datos");
            }
            Console.Write("\n\n------------------------------------------------\nPresione una tecla para continuar....");
            Console.ReadKey();
        }

        static void AddAirplane()
        {
            //Para agregar un avion (vehiculo).

            try
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t\tIngresar Nuevo Avion\n");
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("\n Ingreso de Datos Para Registrar el Avion\n --------------------------------------------\n");
                Console.Write("\n Año de creacion : ");
                int CreationDate = int.Parse(Console.ReadLine());
                Console.Write("\n Precio Valorado : ");
                double Price = double.Parse(Console.ReadLine());
                Console.Write("\n Marca : ");
                string Brand = Console.ReadLine();
                Console.Write("\n Modelo : ");
                string Model = Console.ReadLine();
                Console.Write("\n Color : ");
                string Color = Console.ReadLine();
                Console.Write("\n Motor : ");
                string Engine = Console.ReadLine();
                Console.Write("\n Capacidad de Carga : ");
                int CargoCapacity = int.Parse(Console.ReadLine());
                Console.Write("\n Capacidad de Pasajeros : ");
                int PassangersCapacity = int.Parse(Console.ReadLine());
                Console.Write("\n Tripulacion : ");
                int Tripulation = int.Parse(Console.ReadLine());
                Console.WriteLine(Vehiculo.Avion.getAllSeguridad());
                Console.Write("\n Nivel de Seguridad : ");
                string lv_lvlSegurity = Console.ReadLine();
                Console.Write("\n Peso del Avion : ");
                double Weight = double.Parse(Console.ReadLine());
                Vehiculo.Avion objElAvion = new Vehiculo.Avion(CreationDate, Price, Brand, Model, Color, Engine,
                CargoCapacity, PassangersCapacity, Tripulation, lv_lvlSegurity, Weight);
                Console.WriteLine(objElAvion.ToString());
                Console.ReadKey();
            }
            catch (Exception objError)
            {
                Console.WriteLine(objError.ToString());
                Console.ReadKey();
            }
        }

        static void AddAirport()
        {
            //Para agregar un aeropuerto.
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t\tIngresar Nuevo Aeropuerto\n");
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("\n Ingreso de Datos Para Registrar el Aeropuerto\n --------------------------------------------\n");
                Console.Write("\n\n Nombre Aeropuerto : ");
                string Name = Console.ReadLine();
                Console.Write("\n Direccion : ");
                string Address = Console.ReadLine();
                Console.Write("\n Pais de Ubicacion : ");
                string Location = Console.ReadLine();
                Console.Write("\n Telefono : ");
                string Telephone = Console.ReadLine();
                Console.Write("\n Fecha de Fundado : ");
                string FundationDate = Console.ReadLine();
                Edificacion.Aeropuerto objElAeropuerto = new Edificacion.Aeropuerto(Name, Address, Location, Telephone,
                FundationDate);
                Console.Write("\n\n El Aeropuerto se ha agregado exitosamente!!!\n\nPresione una tecla para continuar....");
                Console.ReadKey();
            }
            catch (Exception objError)
            {
                Console.WriteLine(objError.ToString());
                Console.ReadKey();
            }
        }

        private static void BrandUserScreen()
        {
            //Para agregar una nueva marca.

            string Brand = "";
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\t\tINGRESO NUEVA MARCA\n");
                    Console.WriteLine("---------------------------------------------------------------------------------");
                    Console.WriteLine("\n Ingreso de Datos Para Registrar la Marca\n Digite ENTER para ver Marcas\n--------------------------------------------\n");
                    Console.Write("\n\n Nombre : "); // sin salto de linea
                    Brand = Console.ReadLine();
                    if (Brand == "")
                        continue;
                    Console.Write("\n------------------------------\n Lista de Origenes\n------------------------------\n\n");
                    Console.WriteLine(Vehiculo.Marca.getAllOrigen());
                    Console.Write(" Origen : ");
                    string Origin = Console.ReadLine();
                    Console.Write("\n Fecha Fundada : ");
                    string str_Date = Console.ReadLine();
                    Vehiculo.Marca objMarca = new Vehiculo.Marca(Brand, Origin, str_Date);
                    Console.WriteLine("\n--------------------------------------\nLa Marca se ha registrado con Exito!!!\n--------------------------------------\n");
                    Console.WriteLine(objMarca.ToString());
                    Console.WriteLine("\n¿Desea agregar modelos? [S-->Si]:"); //Para agregar un modelo de la marca, si se desea.
                    string str_option = Console.ReadLine();
                    if (str_option == "S")
                        ModelUserScreen(objMarca.getID(), objMarca.getName());
                    objMarca = null;
                }
                catch (Exception objError)
                {
                    Console.WriteLine(objError.ToString());
                    Console.ReadKey();
                }
            } while (Brand != "");
            if (IOAqui.DataInterface.ExisteArchivo("Marca.txt"))
            {
                Console.Clear();
                Vehiculo.Marca objMarcaReaonly = new Vehiculo.Marca();
                Console.WriteLine(objMarcaReaonly.getAllBrand());
                Console.Write("\n\n------------------------------------------------\nPresione una tecla para continuar....");
            }
            else
                Console.WriteLine("\n\nNo hay marcas para mostrar\n\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private static void BrandDisplay()
        {
            //Mostrar marcas y agregar modelos de estas, si se desea.
            string option = "";
            Vehiculo.Marca objMarcaReaonly = new Vehiculo.Marca();
            try
            {
                Console.Clear();
                Console.WriteLine(objMarcaReaonly.getAllBrand());
                Console.Write("Agregar Nuevo Modelo\n------------------------------------------------------");
            Back:
                Console.Write("\n\nDesea agregar modelos? [ S --> Si || N -- > No] : ");
                option = Console.ReadLine();
                if (option == "S" || option == "s")
                {
                    Console.Write("\n--------------------\n\nElija una Marca (ID) : ");
                    string str_Brand = Console.ReadLine();
                    int int_MKID = int.Parse(str_Brand);
                    if (objMarcaReaonly.Buscar(int_MKID))
                        ModelUserScreen(int_MKID, objMarcaReaonly.getName());
                    else
                    {
                        Console.WriteLine("\n\nID no existe!!!... presione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                else if (option != "N" && option != "n")
                {
                    Console.WriteLine("\n\nOpcion incorrecta...");
                    goto Back;
                }
            }
            catch (Exception objError)
            {
                Console.WriteLine(objError.ToString());
                Console.ReadKey();
            }
            objMarcaReaonly = null;
            Console.ReadKey();
        }

        private static void ModelUserScreen(int p_int_BrandID, string p_str_BrandName)
        {
            //Agregar modelo.

            string Model = "";
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\t\tIngresar Nuevo Modelo\n");
                    Console.WriteLine("---------------------------------------------------------------------------------");
                    Console.WriteLine("\n Ingreso de Datos Para Registrar el Modelo\n Digite ENTER para ver Modelos\n--------------------------------------------\n");
                    Console.WriteLine("\n\n Marca {0},{1} ", p_int_BrandID, p_str_BrandName);
                    Console.WriteLine("\n Entre los datos del Modelo\n---------------------------------------\n");
                    Console.Write("\n Nombre : "); // sin salto de linea
                    Model = Console.ReadLine();
                    if (Model == "")
                        continue;
                    //Console.WriteLine(Autos.OrigenVehiculo;
                    Console.Write("\n Fecha Primera Edición : ");
                    string str_Date = Console.ReadLine();
                    DateTime dte_FundationDate = DateTime.Parse(str_Date);
                    Vehiculo.Modelo objModel = new Vehiculo.Modelo(Model, p_int_BrandID, dte_FundationDate);
                    Console.WriteLine("\n------------------------------------\n\nModelo agregado exitosamnente!!!");
                    Console.WriteLine("\n\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    objModel = null;
                }
                catch (Exception objError)
                {
                    Console.WriteLine(objError.ToString());
                    Console.ReadKey();
                }
            } while (Model != "");
            if (IOAqui.DataInterface.ExisteArchivo("Modelo.txt"))
            {
                Console.Clear();
                Vehiculo.Modelo objModelReaonly = new Vehiculo.Modelo();
                Console.WriteLine(objModelReaonly.getAllModel());
                Console.WriteLine("\n\nPresione una tecla para continuar...");
            }
            else
                Console.WriteLine("\n\nNo hay Modelos para mostrar\n\nPresione una tecla para continuar...");
        }

        static void AirportPlusOrigin()
        {
            //Registro de aeropuertos de donde se parte (origen).

            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\tAeropuerto de Origen\n");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("\n\nLista de aeropuertos de donde mas se parte");
            string display = "";
            List<string> p_objList = new List<string>();
            p_objList = Boleta.getMasVisitado("RegistroOrigen.txt", "ListaDeAeropuerto.txt");
            for (int i = 0; i < p_objList.Count(); i++)
                display += i + 1 + ") " + p_objList[i] + "\n";
            Console.WriteLine("\n\n" + display);
            Console.Write("\n\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        static void AirportPlusDestination()
        {
            //Registro de aeropuertos a donde se llega (destino).

            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\tAeropuerto de Destino\n");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("\n\nLista de aeropuertos de donde mas se llega");
            string display = "";
            List<string> p_objList = new List<string>();
            p_objList = Boleta.getMasVisitado("RegistroDestino.txt", "ListaDeAeropuerto.txt");
            for (int i = 0; i < p_objList.Count(); i++)
                display += i + 1 + ") " + p_objList[i] + "\n";
            Console.WriteLine("\n\n" + display);
            Console.Write("\n\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        static void TotalFlights()
        {
            //Vuelos por aeropuertos.
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\tTotal de Vuelos\n");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("\n\nLista los vuelos de cada Aeropuerto");
            string display = "";
            List<int> objFlightList = new List<int>();
            List<string> objAirportList = new List<string>();
            objAirportList = IOAqui.DataInterface.getListaElementos("ListaDeAeropuerto.txt");
            objFlightList = Boleta.getTotalVuelos("RegistroOrigen.txt", "RegistroDestino.txt", "ListaDeAeropuerto.txt");
            for (int i = 0; i < objFlightList.Count(); i++)
                display += " " + (i + 1) + ") " + objAirportList[i] + " = " + objFlightList[i] + "\n";
            Console.WriteLine("\n\n" + display);
            Console.Write("\n\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        static void TotalMoneyPerPassangers()
        {
            //Total de dinero por pasajeros.
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\tTotal de Dinero Por Pasajeros\n");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("\n\nLista de los pasajeros y el dinero que pagaron");
            Boleta objReadingOnly = new Boleta();
            List<string> Data = objReadingOnly.getTotalDineroPasajeros();
            Console.WriteLine(Data[0]);
            Console.WriteLine("\n\n---------------------------------------------------------------------------------");
            Console.WriteLine("\n\tTotal de dinero por todos los pasajeros : " + Data[1]);
            Console.Write("\n\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        static void TotalMoneyPerDateRank()
        {
            //Total de dinero por rango de fecha.

            Console.Clear();
            Console.WriteLine("\n\n\t\t\tTOTAL DE DINERO POR RANGO DE FECHA\n");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("\n\nIngrese los Datos Necesarios para Calcular el Total");
            Console.Write("\n\nFecha de Inicio : ");
            string StartDate = Console.ReadLine();
            Console.Write("\n\nFecha de Fin : ");
            string EndDate = Console.ReadLine();
            Boleta objReadingOnly = new Boleta();
            double TotalMoney = objReadingOnly.getTotalMoneyDateRank(StartDate, EndDate);
            Console.WriteLine("\n\n---------------------------------------------------------------------------------");
            if (TotalMoney == 0)
                Console.WriteLine("\n\tFecha no encontrada");
            else
                Console.WriteLine("\n\tTotal de dinero : " + TotalMoney);
            Console.Write("\n\nPresione una tecla para continuar...");
            Console.ReadKey();
            objReadingOnly = null;
        }
    }
}
