using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peralta100430840_lib1
{
    public enum ClaseBoleta
    {
        Alta,
        Media_Alta,
        Media,
        Media_Baja,
        Baja
    }
    public class Boleta : IOAqui.DataInterface, IOAqui.iPersistencia
    {
        private int bl_int_No_Flight;
        private double bl_price;
        private string bl_vul_Pilot;
        private DateTime bl_required_date;
        private ClaseBoleta bl_class;
        private int bl_gate;
        private int bl_sit;
        private string bl_origin;
        private string bl_destination;
        private DateTime bl_departure_date;
        private double bl_BaggageWeight;
        private List<string[]> bl_objAllTickets;

        public Boleta() : base("Boleta.txt")
        {
        }
        public Boleta(int p_vul_Piloto, string p_clase, int p_origen, int p_destino, string p_fec_partida, double p_PesoEquipaje) :
        base("Boleta.txt")
        {
            bl_int_No_Flight = getMaxBoleta() + 1;
            List<string> auxPilot = IOAqui.DataInterface.getListaElementos("ListaDePiloto.txt");
            bl_vul_Pilot = auxPilot[p_vul_Piloto];
            bl_required_date = DateTime.Today;
            bl_class = (ClaseBoleta)Enum.Parse(typeof(ClaseBoleta), p_clase);
            bl_price = getPrecio(bl_class.ToString(), p_PesoEquipaje);
            bl_gate = getMaxBoleta() + 3;
            bl_sit = getMaxBoleta() + 1;
            List<string> aux = IOAqui.DataInterface.getListaElementos("ListaDeAeropuerto.txt");
            bl_origin = aux[p_origen];
            bl_destination = aux[p_destino];
            bl_departure_date = DateTime.Parse(p_fec_partida);
            bl_BaggageWeight = p_PesoEquipaje;
            AgregarATxt("RegistroOrigen.txt", bl_origin);
            AgregarATxt("RegistroDestino.txt", bl_destination);
            Grabar();
        }
        public int getID() { return bl_int_No_Flight; }
        public double getPrecio() { return bl_price; }
        public DateTime getFec_solicitada() { return bl_required_date; }
        public ClaseBoleta getClase() { return bl_class; }
        public int getPuerta() { return bl_gate; }
        public int getAsiento() { return bl_sit; }
        public string getOrigen() { return bl_origin; }
        public string getDestino() { return bl_destination; }
        public DateTime getFec_partida() { return bl_departure_date; }
        public double getPesoEquipaje() { return bl_BaggageWeight; }
        public string getPiloto() { return bl_vul_Pilot; }
        private double getPrecio(string p_class, double p_weight)
        {
            double Precio = 0;
            switch (p_class)
            {
                case "Alta": Precio = 200000 + (p_weight * 40); break;
                case "Media_Alta": Precio = 150000 + (p_weight * 30); break;
                case "Media": Precio = 100000 + (p_weight * 20); break;
                case "Media_Baja": Precio = 80000 + (p_weight * 10); break;
                case "Baja": Precio = 50000 + (p_weight * 5); break;
            }
            return Precio;
        }
        private int getMaxBoleta()
        {
            if (IOAqui.DataInterface.ExisteArchivo("Boleta.txt"))
                if (bl_objAllTickets == null)
                    Leer();
            if (bl_objAllTickets == null)
                return 1;
            int lv_int_max = -99999;
            int lv_int_ID_actual = 0;
            foreach (string[] unAtributos in bl_objAllTickets)
            {
                int.TryParse(unAtributos[0], out lv_int_ID_actual);
                if (lv_int_ID_actual > lv_int_max)
                    lv_int_max = lv_int_ID_actual;
            }
            if (lv_int_max < 0)
                lv_int_max = 0;
            return lv_int_max;
        }
        public override string ToString()
        {
            string lv_str_display = "\n\nLos Datos de la Boleta son:\n";
            lv_str_display += "\n ID de Boleta : " + bl_int_No_Flight.ToString();
            lv_str_display += "\n-----------------------------------\n";
            lv_str_display += " \n\nPrecio\t\t:" + bl_price.ToString();
            lv_str_display += " \n\nFecha Solicitada la Boleta:\t\t" + bl_required_date.ToShortDateString();
            lv_str_display += " \n\nClase Boleta\t\t:" + bl_class.ToString();
            lv_str_display += " \n\nPuerta de Abordaje\t\t:" + bl_gate.ToString();
            lv_str_display += " \n\nAsiento\t\t:" + bl_sit.ToString();
            lv_str_display += " \n\nAeropuerto de origen\t\t:" + bl_origin;
            lv_str_display += " \n\nAeropuerto de destino\t\t:" + bl_destination;
            lv_str_display += " \n\nFecha de partida\t\t:" + bl_departure_date.ToShortDateString();
            lv_str_display += " \n\nPeso Equipaje\t\t:" + bl_BaggageWeight.ToString();
            lv_str_display += " \n\nPiloto\t\t:" + bl_vul_Pilot;
            lv_str_display += "\n------------------------------------\n";
            return lv_str_display;
        }
        private void AsignarAtributos(string[] p_str_Atributos)
        {
            try
            {
                int.TryParse(p_str_Atributos[0], out bl_int_No_Flight);
                bl_price = double.Parse(p_str_Atributos[1]);
                bl_required_date = DateTime.Parse(p_str_Atributos[2]);
                bl_class = (ClaseBoleta)Enum.Parse(typeof(ClaseBoleta), p_str_Atributos[3]);
                bl_gate = int.Parse(p_str_Atributos[4]);
                bl_sit = int.Parse(p_str_Atributos[5]);
                bl_origin = p_str_Atributos[6];
                bl_destination = p_str_Atributos[7];
                bl_departure_date = DateTime.Parse(p_str_Atributos[8]);
                bl_BaggageWeight = double.Parse(p_str_Atributos[9]);
                bl_vul_Pilot = p_str_Atributos[10];
            }
            catch (Exception objError)
            {
                mv_str_elMensajeSalida = objError.Message;
            }
        }
        public string getTodaBoleta()
        {
            if (bl_objAllTickets == null)
                Leer();
            string lv_salida = IOAqui.DataInterface.getMatrixData(bl_objAllTickets, "BOLETAS");
            return lv_salida;
        }
        public static string getAllClase()
        {
            return IOAqui.DataInterface.EnumToString(typeof(ClaseBoleta));
        }
        public static List<string> getMasVisitado(string p_Registro, string p_Lista)
        {
            List<string> objActivos = IOAqui.DataInterface.getListaElementos(p_Registro);
            List<string> objLista = IOAqui.DataInterface.getListaElementos(p_Lista);
            List<int> CantVisitados = new List<int>();
            List<string> masVisitados = new List<string>();
            foreach (string OrigenPropuesto in objLista)
            {
                int Contador = 0;
                foreach (string Aeropuerto in objActivos)
                {
                    if (Aeropuerto == OrigenPropuesto)
                        Contador += 1;
                }
                CantVisitados.Add(Contador);
            }
            for (int k = 0; k < 3; k++)
            {
                int posi = 0;
                int NumMax = -99999;
                string masVisitado = "";
                for (int i = 0; i < CantVisitados.Count(); i++)
                {
                    if (CantVisitados[i] >= NumMax)
                    {
                        NumMax = CantVisitados[i];
                        masVisitado = objLista[i];
                        posi = i;
                    }
                }
                masVisitados.Add(masVisitado);
                CantVisitados.Remove(NumMax);
                objLista.Remove(masVisitado);
            }
            return masVisitados;
        }
        public static List<int> getTotalVuelos(string p_RegistroOrigen, string p_RegistroDestino, string p_Lista)
        {
            List<string> objActivosOrigen = IOAqui.DataInterface.getListaElementos(p_RegistroOrigen);
            List<string> objActivosDestino = IOAqui.DataInterface.getListaElementos(p_RegistroDestino);
            List<string> objLista = IOAqui.DataInterface.getListaElementos(p_Lista);
            List<int> CantVuelosOrigen = new List<int>();
            List<int> CantVuelosDestino = new List<int>();
            List<int> CantVuelos = new List<int>();
            foreach (string OrigenPropuesto in objLista)
            {
                int Contador = 0;
                foreach (string Origen in objActivosOrigen)
                {
                    if (Origen == OrigenPropuesto)
                        Contador += 1;
                }
                CantVuelosOrigen.Add(Contador);
            }
            foreach (string DestinoPropuesto in objLista)
            {
                int Contador = 0;
                foreach (string Destino in objActivosDestino)
                {
                    if (Destino == DestinoPropuesto)
                        Contador += 1;
                }
                CantVuelosDestino.Add(Contador);
            }
            for (int i = 0; i < objLista.Count(); i++)
            {
                CantVuelos.Add(CantVuelosOrigen[i] + CantVuelosDestino[i]);
            }
            return CantVuelos;
        }
        public List<string> getTotalDineroPasajeros()
        {
            List<string[]> bjPasajeros;
            Personas.Pasajero objElPasajero = new Personas.Pasajero();
            bjPasajeros = objElPasajero.getArchivo();
            bl_objAllTickets = getArchivo();
            List<string> LosPasajerosLista = new List<string>();
            string Passangers = "";
            double Recaudado = 0;
            for (int i = 0; i < bl_objAllTickets.Count(); i++)
            {
                Passangers += "\n\n---------------------------------------------------------\n\n ID de Pasajero : " + bjPasajeros[i][0];
                Passangers += "\n Nombre : " + bjPasajeros[i][1];
                Passangers += "\n Clase : " + bl_objAllTickets[i][3];
                Passangers += "\n Precio : " + bl_objAllTickets[i][1];
                Passangers += "\n\n---------------------------------------------------------\n";
                Recaudado += double.Parse(bl_objAllTickets[i][1]);
            }
            LosPasajerosLista.Add(Passangers);
            LosPasajerosLista.Add(Recaudado.ToString());
            return LosPasajerosLista;
        }
        public double getTotalMoneyDateRank(string p_StartDate, string p_EndDate)
        {
            bl_objAllTickets = getArchivo();
            DateTime FechaInicio = DateTime.Parse(p_StartDate);
            DateTime FechaFin = DateTime.Parse(p_StartDate);
            if (FechaInicio == FechaFin)
            {
                int n = 0;
                double resul2 = 0;
                while (n < bl_objAllTickets.Count() && bl_objAllTickets[n][2] == FechaFin.ToShortDateString())
                {
                    resul2 += double.Parse(bl_objAllTickets[n][1]);
                    n += 1;
                }
                return resul2;
            }
            else
            {
                for (int i = 0; i < bl_objAllTickets.Count(); i++)
                {
                    if (FechaInicio.ToShortDateString() == bl_objAllTickets[i][2].ToString())
                    {
                        double resul = 0;
                        int k = i;
                        do
                        {
                            resul += double.Parse(bl_objAllTickets[k][1]);
                            k += 1;
                        } while (k < bl_objAllTickets.Count() && bl_objAllTickets[k][2] != FechaFin.ToShortDateString());
                        while (k < bl_objAllTickets.Count() && bl_objAllTickets[k][2] == FechaFin.ToShortDateString())
                        {
                            resul += double.Parse(bl_objAllTickets[k][1]);
                            k += 1;
                        }
                        return resul;
                    }
                }
            }
            return 0;
        }
        #region INTERFACES
        public bool Grabar()
        {
            bool lv_pointer;
            try
            {
                string str_display = bl_int_No_Flight.ToString();
                str_display += "|" + bl_price;
                str_display += "|" + bl_required_date.ToShortDateString();
                str_display += "|" + bl_class.ToString();
                str_display += "|" + bl_gate;
                str_display += "|" + bl_sit;
                str_display += "|" + bl_origin;
                str_display += "|" + bl_destination;
                str_display += "|" + bl_departure_date.ToShortDateString();
                str_display += "|" + bl_BaggageWeight.ToString();
                str_display += "|" + bl_vul_Pilot;
                lv_pointer = Agregar(str_display);
            }
            catch (Exception objError)
            {
                mv_str_elMensajeSalida = objError.ToString();
                lv_pointer = false;
            };
            return lv_pointer;
        }
        public bool Leer()
        {
            try
            {
                bl_objAllTickets = getArchivo();
                AsignarAtributos(bl_objAllTickets[0]);// el primer records
                return bl_objAllTickets != null;
            }
            catch (Exception objError)
            {
                mv_str_elMensajeSalida = objError.ToString();
                return false;
            }
        }
        public bool Buscar(string p_str_loBuscado)
        {
            if (bl_objAllTickets == null)
                Leer();
            ///---
            bool lv_bln_result = false;
            foreach (string[] anAttribute in bl_objAllTickets)
            {
                if (anAttribute.Contains(p_str_loBuscado, StringComparer.OrdinalIgnoreCase))
                {
                    lv_bln_result = true;
                    AsignarAtributos(anAttribute);
                    break;
                }
            }
            return lv_bln_result;
        }
        public bool Buscar(int p_int_ModelID)
        {
            if (bl_objAllTickets == null)
                Leer();
            ///---
            bool lv_bln_result = false;
            int lv_int_ModeloID = 0;
            foreach (string[] unAtributos in bl_objAllTickets)
            {
                int.TryParse(unAtributos[0], out lv_int_ModeloID);
                if (lv_int_ModeloID == p_int_ModelID)
                {
                    lv_bln_result = true;
                    AsignarAtributos(unAtributos);
                    break;
                }
            }
            return lv_bln_result;
        }
        public string getMensaje()
        {
            return mv_str_elMensajeSalida;
        }
        #endregion INTERFACES
    }
}
