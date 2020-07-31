using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Peralta100430840_lib1.Edificacion
{
    public class Aeropuerto : IOAqui.DataInterface, IOAqui.iPersistencia
    {
        private int IdAirport;
        private string AirportName;
        private string direction;
        private string country;
        private string Telephone;
        private DateTime FoundedDate;
        private List<string[]> objAllTheAirports;
        public Aeropuerto() : base("Aeropuerto.txt")
        {
        }
        public Aeropuerto(string p_AirportName, string p_direction, string p_country, string p_Telephone, string p_FoundedDate) :
        base("Aeropuerto.txt")
        {
            IdAirport = getMaxAirport() + 1;
            AirportName = p_AirportName;
            if (Buscar(p_AirportName))
            {
                throw new Exception("Este Nombre ya existe : " + p_AirportName);
            }
            direction = p_direction;
            country = p_country;
            Telephone = p_Telephone;
            FoundedDate = DateTime.Parse(p_FoundedDate);
            Grabar();
            AgregarATxt("ListaDeAeropuerto.txt", p_AirportName);
        }
        public int getIdAirport() { return IdAirport; }
        public string getAirportName() { return AirportName; }
        public string getDirection() { return direction; }
        public string getCountry() { return country; }
        public string getTelephone() { return Telephone; }
        public DateTime getFoundedDate() { return FoundedDate; }
        private int getMaxAirport()
        {
            if (IOAqui.DataInterface.ExisteArchivo("Aeropuerto.txt"))
                if (objAllTheAirports == null)
                    Leer();
            if (objAllTheAirports == null)
                return 0;
            int lv_int_max = -99999;
            int lv_int_ID_actual = 0;
            foreach (string[] unAtributos in objAllTheAirports)
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
            string lv_str_display = "Los Datos del Aeropuerto son:\n";
            lv_str_display += "\n\n ID Aeropuerto : " + IdAirport.ToString();
            lv_str_display += "\n-----------------------------------\n";
            lv_str_display += " \n\n Nombre Aropuerto\t\t:" + AirportName.ToString();
            lv_str_display += " \n\n Direccion\t\t:" + direction.ToString();
            lv_str_display += " \n\n Pais\t\t:" + country.ToString();
            lv_str_display += " \n\n Telefono\t\t:" + Telephone.ToString();
            lv_str_display += " \n\n Fecha de Fundado\t\t:" + FoundedDate.ToShortDateString();
            lv_str_display += "\n------------------------------------\n";
            return lv_str_display;
        }
        private void AssignAttributes(string[] p_str_Attributes)
        {
            try
            {
                int.TryParse(p_str_Attributes[0], out IdAirport);
                AirportName = p_str_Attributes[1];
                direction = p_str_Attributes[2];
                country = p_str_Attributes[3];
                Telephone = p_str_Attributes[4];
                FoundedDate = DateTime.Parse(p_str_Attributes[5]);
            }
            catch (Exception objError)
            {
                mv_str_elMensajeSalida = objError.Message;
            }
        }
        public List<string[]> getTodoAeropuerto()
        {
            if (objAllTheAirports == null)
                Leer();
            string lv_display = IOAqui.DataInterface.getMatrixData(objAllTheAirports, "AEROPUERTOS");
            return objAllTheAirports;
        }
        public string getTodoAeropuertoString()
        {
            if (objAllTheAirports == null)
                Leer();
            string lv_display = IOAqui.DataInterface.getMatrixData(objAllTheAirports, "AEROPUERTOS");
            return lv_display;
        }
        #region INTERFACES
        public bool Grabar()
        {
            bool lv_pointer;
            try
            {
                string lv_str_line = IdAirport.ToString();
                lv_str_line += "|" + AirportName.ToString();
                lv_str_line += "|" + direction.ToString();
                lv_str_line += "|" + country.ToString();
                lv_str_line += "|" + Telephone.ToString();
                lv_str_line += "|" + FoundedDate.ToShortDateString();
                lv_pointer = Agregar(lv_str_line);
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
                objAllTheAirports = getArchivo();
                AssignAttributes(objAllTheAirports[0]);
                return objAllTheAirports != null;
            }

            catch (Exception objError)
            {
                mv_str_elMensajeSalida = objError.ToString();
                return false;
            }
        }
        public bool Buscar(string p_str_WisLooked)
        {
            if (objAllTheAirports == null)
                Leer();
            ///---
            bool lv_bln_result = false;
            foreach (string[] anAttributes in objAllTheAirports)
            {
                if (anAttributes[1] == p_str_WisLooked)
                {
                    lv_bln_result = true;
                    AssignAttributes(anAttributes);
                    break;
                }
            }
            return lv_bln_result;
        }
        public bool Buscar(int p_int_AeroID)
        {
            if (objAllTheAirports == null)
                Leer();
            ///---
            bool lv_bln_result = false;
            int lv_int_AeroID = 0;
            foreach (string[] anAttributes in objAllTheAirports)
            {
                int.TryParse(anAttributes[0], out lv_int_AeroID);
                if (lv_int_AeroID == p_int_AeroID)
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
            return mv_str_elMensajeSalida;
        }
        #endregion INTERFACES
    }
}
