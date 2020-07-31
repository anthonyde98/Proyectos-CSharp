using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Peralta100430840_lib1.Vehiculo
{
    public enum NivelSeguridad
    {
        Alto,
        Medio,
        Baja
    }
    public class Avion : IOAqui.DataInterface, IOAqui.iPersistencia
    {
        private int av_IdAirplane;
        private int av_Year;
        private double av_Price;
        private string av_Brand;
        private string av_Model;
        private string av_Color;
        private string av_Engine;
        private int av_CargoCapacity;
        private int av_PassangerCapacity;
        private int av_AboardTripulation;
        private NivelSeguridad av_SecurityLevel;
        private double av_Weight;
        private List<string[]> av_objAirplanes;
        protected string mv_str_mensajeError;
        public Avion() : base("Avion.txt")
        {
        }
        public Avion(int p_Year, double p_Price, string p_Brand, string p_Model, string p_Color, string p_Engine, int p_CargoCapacity,
        int p_PassangerCapacity, int p_Tripulation, string p_SecurityLevel, double p_Weight) : base("Avion.txt")
        {
            av_IdAirplane = getMaxAvion() + 1;
            av_Year = p_Year;
            av_Price = p_Price;
            av_Brand = p_Brand;
            av_Model = p_Model;
            if (Buscar(p_Model))
            {
                throw new Exception("Este Modelo ya existe : " + p_Model);
            }
            av_Color = p_Color;
            av_Engine = p_Engine;
            av_CargoCapacity = p_CargoCapacity;
            av_PassangerCapacity = p_PassangerCapacity;
            av_SecurityLevel = (NivelSeguridad)Enum.Parse(typeof(NivelSeguridad), p_SecurityLevel);
            av_AboardTripulation = p_Tripulation;
            av_Weight = p_Weight;
            AgregarATxt("ListaDeAviones.txt", p_Brand);
            Grabar();
        }
        public override string ToString()
        {
            string lv_str_display = "\n\n\nCaracteristicas de este Avion son:\n";
            lv_str_display += base.ToString();
            lv_str_display += "\n-----------------------------------\n";
            lv_str_display += " \nID Avion:" + av_IdAirplane.ToString();
            lv_str_display += " \nAño:" + av_Year.ToString();
            lv_str_display += " \n Precio\t\t:" + av_Price.ToString();
            lv_str_display += " \n Marca es\t\t:" + av_Brand;
            lv_str_display += " \n\n Modelo \t\t:" + av_Model;
            lv_str_display += " \n Color \t\t:" + av_Color;
            lv_str_display += " \n Motor \t\t:" + av_Engine;
            lv_str_display += " \n CapacidadCarga \t\t:" + av_CargoCapacity;
            lv_str_display += " \n CapacidadPasajero \t\t:" + av_PassangerCapacity;
            lv_str_display += "\n -----------------------------------\n";
            return lv_str_display;
        }
        public static string getAllSeguridad()
        {
            return IOAqui.DataInterface.EnumToString(typeof(NivelSeguridad));
        }
        public string getTodoAvion()
        {
            if (av_objAirplanes == null)
                Leer();
            string lv_display = IOAqui.DataInterface.getMatrixData(av_objAirplanes, "AVIONES");
            return lv_display;
        }
        private int getMaxAvion()
        {
            if (IOAqui.DataInterface.ExisteArchivo("Avion.txt"))
                if (av_objAirplanes == null)
                    Leer();
            if (av_objAirplanes == null)
                return 0;
            int lv_int_max = -99999;
            int lv_int_ID_current = 0;
            ///---
            foreach (string[] anAttributes in av_objAirplanes)
            {
                int.TryParse(anAttributes[0], out lv_int_ID_current);
                if (lv_int_ID_current > lv_int_max)
                    lv_int_max = lv_int_ID_current;
            }
            if (lv_int_max < 0)
                lv_int_max = 0;
            return lv_int_max;
        }
        #region interface implement.....
        public bool Grabar()
        {
            bool lv_pointer;
            try
            {
                IOAqui.DataInterface objElFile = new IOAqui.DataInterface("Avion.txt");
                string lv_str_line = av_IdAirplane.ToString();
                lv_str_line += "|" + av_Year;
                lv_str_line += "|" + av_Price;
                lv_str_line += "|" + av_Brand;
                lv_str_line += "|" + av_Model;
                lv_str_line += "|" + av_Color;
                lv_str_line += "|" + av_Engine;
                lv_str_line += "|" + av_CargoCapacity;
                lv_str_line += "|" + av_PassangerCapacity;
                lv_pointer = objElFile.Agregar(lv_str_line);
                if (!lv_pointer)
                    mv_str_mensajeError = objElFile.getMensajeError();
            }
            catch (Exception objError)
            {
                mv_str_mensajeError = objError.ToString();
                lv_pointer = false;
            };
            return lv_pointer;
        }
        public bool Leer()
        {
            IOAqui.DataInterface objElFile = new IOAqui.DataInterface("Avion.txt");
            av_objAirplanes = objElFile.getArchivo();
            AssignAttributes(av_objAirplanes[0]);
            return av_objAirplanes != null;
        }
        public bool Buscar(string p_str_loBuscado)
        {
            bool lv_bln_result = false;
            foreach (string[] anAttributes in av_objAirplanes)
            {
                if (anAttributes[4] == p_str_loBuscado)
                {
                    lv_bln_result = true;
                    AssignAttributes(anAttributes);
                    break;
                }
            }
            return lv_bln_result;
        }
        public bool Buscar(int p_int_AirplaneID)
        {
            if (av_objAirplanes == null)
                Leer();
            ///---
            bool lv_bln_result = false;
            int lv_int_AirplaneID = 0;
            foreach (string[] anAttributes in av_objAirplanes)
            {
                int.TryParse(anAttributes[0], out lv_int_AirplaneID);
                if (lv_int_AirplaneID == p_int_AirplaneID)
                {
                    lv_bln_result = true;
                    AssignAttributes(anAttributes);
                    break;
                }
            }
            return lv_bln_result;
        }
        public string getMensaje()
        {
            return mv_str_mensajeError;
        }
        #endregion interfaces.......
        public string getTodaData()
        {
            string lv_display = IOAqui.DataInterface.getMatrixData(av_objAirplanes, "AVIONES");
            return lv_display;
        }
        private void AssignAttributes(string[] p_str_Atributos)
        {
            av_IdAirplane = int.Parse(p_str_Atributos[0]);
            av_Year = int.Parse(p_str_Atributos[1]);
            av_Price = double.Parse(p_str_Atributos[2]);
            av_Brand = p_str_Atributos[3];
            av_Model = p_str_Atributos[4];
            av_Color = p_str_Atributos[5];
            av_Engine = p_str_Atributos[6];
            av_CargoCapacity = int.Parse(p_str_Atributos[7]);
            av_PassangerCapacity = int.Parse(p_str_Atributos[8]);
        }
    }
}

