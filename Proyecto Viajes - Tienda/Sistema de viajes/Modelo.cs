using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Peralta100430840_lib1.Vehiculo
{
    public class Modelo : IOAqui.DataInterface, IOAqui.iPersistencia
    {
        private int bl_int_ID;
        private string bl_str_model;
        private Marca bl_obj_Brand;
        private int lv_int_BrandID;
        private DateTime bl_Date_founded;
        private List<string[]> bl_objAllBrand;
        public Modelo() : base("Modelo.txt")
        {
        }
        public Modelo(string p_model, string p_brand, DateTime p_founded) : base("Modelo.txt")
        {
            bl_obj_Brand = new Marca();
            if (!bl_obj_Brand.Buscar(p_brand))
                throw new Exception("Esta marca no Existe!!!:" + p_brand);
            lv_int_BrandID = bl_obj_Brand.getID();
            addModelo(p_model, p_founded);
        }
        public Modelo(string p_model, int p_BrandID, DateTime p_founded) : base("Modelo.txt")
        {
            bl_obj_Brand = new Marca();
            if (!bl_obj_Brand.Buscar(p_BrandID))
                throw new Exception("Esta marca no Existe!!!:" + p_BrandID.ToString());
            lv_int_BrandID = p_BrandID;
            addModelo(p_model, p_founded);
        }
        private void addModelo(string p_model, DateTime p_founded)
        {
            bl_int_ID = getMaxModelo() + 1;
            bl_str_model = p_model;
            if (Buscar(p_model))
            {
                throw new Exception("Este Modelo ya existe:" + p_model);
            }
            bl_Date_founded = p_founded;
            Grabar();
        }
        public int getID() { return bl_int_ID; }
        public string getName() { return bl_str_model; }
        public DateTime getDateFounded() { return bl_Date_founded; }
        public Marca getBrand() { return bl_obj_Brand; }

        private int getMaxModelo()
        {
            if (IOAqui.DataInterface.ExisteArchivo("Modelo.txt"))
                if (bl_objAllBrand == null)
                    Leer();
            if (bl_objAllBrand == null)
                return 0;
            int lv_int_max = -99999;
            int lv_int_ID_Current = 0;
            ///---
            foreach (string[] anAttributes in bl_objAllBrand)
            {
                int.TryParse(anAttributes[0], out lv_int_ID_Current);
                if (lv_int_ID_Current > lv_int_max)
                    lv_int_max = lv_int_ID_Current;
            }
            if (lv_int_max < 0)
                lv_int_max = 0;
            return lv_int_max;
        }
        public override string ToString()
        {
            string lv_str_display = "Atributos de la Modelo son:\n";
            lv_str_display += "\n ID: " + bl_int_ID.ToString();
            lv_str_display += "\n-----------------------------------\n";
            lv_str_display += " Marca:\t\t" + bl_obj_Brand.getName();
            lv_str_display += " Nombre:\t\t" + bl_str_model.ToString();
            lv_str_display += " \n Fecha Fundó:\t\t:" + bl_Date_founded.ToShortDateString();
            lv_str_display += "\n -----------------------------------\n";
            return lv_str_display;
        }
        private void AssignAttributes(string[] p_str_Attributes)
        {
            try
            {
                bl_obj_Brand = new Marca();
                if (!bl_obj_Brand.Buscar(p_str_Attributes[2]))
                    throw new Exception("Esta marca no Existe!!!:" + p_str_Attributes[2]);
                int.TryParse(p_str_Attributes[0], out bl_int_ID);
                bl_str_model = p_str_Attributes[1];
                bl_Date_founded = DateTime.Parse(p_str_Attributes[3]);
            }
            catch (Exception objError)
            {
                mv_str_elMensajeSalida = objError.Message;
            }
        }
        public string getAllModel()
        {
            if (bl_objAllBrand == null)
                Leer();
            string lv_salida = IOAqui.DataInterface.getMatrixData(bl_objAllBrand, "MARCAS");
            return lv_salida;
        }
        #region INTERFACES
        public bool Grabar()
        {
            bool lv_pointer;
            try
            {
                string lv_str_line = bl_int_ID.ToString();
                lv_str_line += "|" + bl_str_model;
                lv_str_line += "|" + lv_int_BrandID;
                lv_str_line += "|" + bl_Date_founded.ToShortDateString();
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
                bl_objAllBrand = getArchivo();
                AssignAttributes(bl_objAllBrand[0]);// el primer records
                return bl_objAllBrand != null;
            }

            catch (Exception objError)
            {
                mv_str_elMensajeSalida = objError.ToString();
                return false;
            }
        }
        public bool Buscar(string p_str_Wislooked)
        {
            if (bl_objAllBrand == null)
                Leer();
            if (bl_objAllBrand == null)
                return false;
            ///---
            bool lv_bln_result = false;
            foreach (string[] anAttribute in bl_objAllBrand)
            {
                if (anAttribute[1] == p_str_Wislooked)
                {
                    lv_bln_result = true;
                    AssignAttributes(anAttribute);
                    break;
                }
            }
            return lv_bln_result;
        }
        public bool Buscar(int p_int_ModelID)
        {
            if (bl_objAllBrand == null)
                Leer();
            ///---
            if (bl_objAllBrand == null)
                return false;
            bool lv_bln_result = false;
            int lv_int_ModelID = 0;
            foreach (string[] anAttribute in bl_objAllBrand)
            {
                int.TryParse(anAttribute[0], out lv_int_ModelID);
                if (lv_int_ModelID == p_int_ModelID)
                {
                    lv_bln_result = true;
                    AssignAttributes(anAttribute);
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

