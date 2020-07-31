using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Peralta100430840_lib1.Vehiculo
{
    public enum OrigenVehiculo
    {
        Europeo,
        Americano,
        Japonez,
        Coreano,
        Chino,
        ZDesconocido
    }
    public class Marca : IOAqui.DataInterface, IOAqui.iPersistencia
    {
        private int mv_int_ID;
        private string mv_str_name;
        private OrigenVehiculo mv_veh_Origin;
        private DateTime mv_fec_founded;
        private List<string[]> mv_objAllBrand;
        public Marca() : base("Marca.txt")
        {
        }
        public Marca(string p_name, string p_Origin, string p_founded) : base("Marca.txt")
        {
            mv_int_ID = getMaxBrand() + 1;
            mv_str_name = p_name;
            if (Buscar(p_name))
            {
                throw new Exception("Esta Marca ya existe : " + p_name);
            }
            mv_veh_Origin = (OrigenVehiculo)Enum.Parse(typeof(OrigenVehiculo), p_Origin);
            mv_fec_founded = DateTime.Parse(p_founded); ;
            Grabar();
        }
        public int getID() { return mv_int_ID; }
        public string getName() { return mv_str_name; }
        public OrigenVehiculo getOrigin()
        {
            return mv_veh_Origin;
        }
        public DateTime getDateFounded() { return mv_fec_founded; }
        private int getMaxBrand()
        {
            if (IOAqui.DataInterface.ExisteArchivo("Marca.txt"))
                if (mv_objAllBrand == null)
                    Leer();
            if (mv_objAllBrand == null)
                return 0;
            int lv_int_max = -99999;
            int lv_int_ID_current = 0;
            ///---
            foreach (string[] unAttributes in mv_objAllBrand)
            {
                int.TryParse(unAttributes[0], out lv_int_ID_current);
                if (lv_int_ID_current > lv_int_max)
                    lv_int_max = lv_int_ID_current;
            }
            if (lv_int_max < 0)
                lv_int_max = 0;
            return lv_int_max;
        }
        public override string ToString()
        {
            string lv_str_display = "Atributos de la Marca son:\n";
            lv_str_display += "\n ID: " + mv_int_ID.ToString();
            lv_str_display += "\n-----------------------------------\n";
            lv_str_display += " Nombre:\t\t" + mv_str_name.ToString();
            lv_str_display += " \n Origen\t\t:" + mv_veh_Origin.ToString();
            lv_str_display += " \n Fecha Fundó:\t\t:" + mv_fec_founded.ToShortDateString();
            lv_str_display += "\n -----------------------------------\n";
            return lv_str_display;
        }
        private void AsignarAtributos(string[] p_str_Atributos)
        {
            try
            {
                int.TryParse(p_str_Atributos[0], out mv_int_ID);
                mv_str_name = p_str_Atributos[1];
                mv_veh_Origin = (OrigenVehiculo)Enum.Parse(typeof(OrigenVehiculo), p_str_Atributos[2]);
                mv_fec_founded = DateTime.Parse(p_str_Atributos[3]);
            }
            catch (Exception objError)
            {
                mv_str_elMensajeSalida = objError.Message;
            }
        }
        public string getAllBrand()
        {
            if (mv_objAllBrand == null)
                Leer();
            string lv_display = IOAqui.DataInterface.getMatrixData(mv_objAllBrand, "MARCAS");
            return lv_display;
        }
        public static string getAllOrigen()
        {
            return IOAqui.DataInterface.EnumToString(typeof(OrigenVehiculo));
        }
        #region INTERFACES
        public bool Grabar()
        {
            bool lv_pointer;
            try
            {
                string lv_str_line = mv_int_ID.ToString();
                lv_str_line += "|" + mv_str_name;
                lv_str_line += "|" + mv_veh_Origin.ToString();
                lv_str_line += "|" + mv_fec_founded.ToShortDateString();
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
                mv_objAllBrand = getArchivo();
                AsignarAtributos(mv_objAllBrand[0]);
                return mv_objAllBrand != null;
            }
            catch (Exception objError)
            {
                mv_str_elMensajeSalida = objError.ToString();
                return false;
            }
        }
        public bool Buscar(string p_str_loBuscado)
        {
            if (mv_objAllBrand == null)
                Leer();
            ///---
            bool lv_bln_result = false;
            foreach (string[] unAttributes in mv_objAllBrand)
            {
                if (unAttributes[1] == p_str_loBuscado)
                {
                    lv_bln_result = true;
                    AsignarAtributos(unAttributes);
                    break;
                }
            }
            return lv_bln_result;
        }
        public bool Buscar(int p_int_BrandID)
        {
            if (mv_objAllBrand == null)
                Leer();
            ///---
            bool lv_bln_result = false;
            int lv_int_BrandID = 0;
            foreach (string[] unAttributes in mv_objAllBrand)
            {
                int.TryParse(unAttributes[0], out lv_int_BrandID);
                if (lv_int_BrandID == p_int_BrandID)
                {
                    lv_bln_result = true;
                    AsignarAtributos(unAttributes);
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
