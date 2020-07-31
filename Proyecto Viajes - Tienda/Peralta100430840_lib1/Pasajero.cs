using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Peralta100430840_lib1.Personas
{
    public class Pasajero : IOAqui.DataInterface, IOAqui.iPersistencia
    {
        private int PassangerID;
        private string Name;
        private string Passport;
        private DateTime BirthDate;
        private string BloodType;
        private string MaritalStatus;
        private string Address;
        private string Cellphone;
        private string Telephone;
        private string Occupation;
        private List<string[]> objAllThePassangers;
        public Pasajero() : base("Pasajero.txt")
        {
        }
        public Pasajero(string p_Name, string p_Passport, string p_BirthDate, string p_BloodType, string p_MaritalStatus, string
        p_Address, string p_Cellphone, string p_Telephone, string p_Occupation) : base("Pasajero.txt")
        {
            PassangerID = getMaxPassanger() + 1;
            Name = p_Name;
            if (Buscar(p_Name))
            {
                throw new Exception("Esta Nombre ya existe : " + p_Name);
            }
            Passport = p_Passport;
            BirthDate = DateTime.Parse(p_BirthDate);
            BloodType = p_BloodType;
            MaritalStatus = p_MaritalStatus;
            Address = p_Address;
            Cellphone = p_Cellphone;
            Telephone = p_Telephone;
            Occupation = p_Occupation;
            Grabar();
        }
        public int getPassangerID() { return PassangerID; }
        public string getPassport() { return Passport; }
        public string getName() { return Name; }
        public string getBloodType() { return BloodType; }
        public string getMaritalStatus() { return MaritalStatus; }
        public string getAddress() { return Address; }
        public string getCellphone() { return Cellphone; }
        public string getTelephone() { return Telephone; }
        public string getOccupation() { return Occupation; }
        private int getMaxPassanger()
        {
            if (IOAqui.DataInterface.ExisteArchivo("Pasajero.txt"))
                if (objAllThePassangers == null)
                    Leer();
            if (objAllThePassangers == null)
                return 0;
            int lv_int_max = -99999;
            int lv_int_ID_current = 0;
            foreach (string[] unAtributos in objAllThePassangers)
            {
                int.TryParse(unAtributos[0], out lv_int_ID_current);
                if (lv_int_ID_current > lv_int_max)
                    lv_int_max = lv_int_ID_current;
            }
            if (lv_int_max < 0)
                lv_int_max = 0;
            return lv_int_max;
        }
        public override string ToString()
        {
            string lv_str_display = "Los Datos del Pasajero son:\n";
            lv_str_display += "\n ID Pasajero : " + PassangerID;
            lv_str_display += "\n-----------------------------------\n";
            lv_str_display += "\n\n Nombre del Pasajero\t\t:" + Name;
            lv_str_display += "\n\n Pasaporte\t\t:" + Passport;
            lv_str_display += "\n\n Fecha de Nacimiento\t\t:" + BirthDate.ToShortDateString();
            lv_str_display += "\n\n Tipo de Sangre\t\t:" + BloodType;
            lv_str_display += "\n\n Estado Civil\t\t:" + MaritalStatus.ToString();
            lv_str_display += "\n\n Direccion\t\t:" + Address;
            lv_str_display += "\n\n Celular\t\t:" + Cellphone;
            lv_str_display += "\n\n Telefono\t\t:" + Telephone.ToString();
            lv_str_display += "\n\n Ocupacion\t\t:" + Occupation.ToString();
            Boleta objBoletaReadOnly = new Boleta();
            objBoletaReadOnly.Buscar(PassangerID);
            lv_str_display += "\n\n" + objBoletaReadOnly.ToString();
            lv_str_display += "\n -----------------------------------\n";
            return lv_str_display;
        }
        private void AssignAttributes(string[] p_str_Attributes)
        {
            try
            {
                int.TryParse(p_str_Attributes[0], out PassangerID);
                Name = p_str_Attributes[1];
                Passport = p_str_Attributes[2];
                BirthDate = DateTime.Parse(p_str_Attributes[3]);
                BloodType = p_str_Attributes[4];
                MaritalStatus = p_str_Attributes[5];
                Address = p_str_Attributes[6];
                Cellphone = p_str_Attributes[7];
                Telephone = p_str_Attributes[8];
                Occupation = p_str_Attributes[9];
            }
            catch (Exception objError)
            {
                mv_str_elMensajeSalida = objError.Message;
            }
        }
        public List<string[]> getAllPassanger()
        {
            if (objAllThePassangers == null)
                Leer();
            string display = IOAqui.DataInterface.getMatrixData(objAllThePassangers, "PASAJEROS");
            return objAllThePassangers;
        }

        public string getAllPassangerString()
        {
            if (objAllThePassangers == null)
                Leer();
            string display = IOAqui.DataInterface.getMatrixData(objAllThePassangers, "PASAJEROS");
            return display;
        }
        #region INTERFACES
        public bool Grabar()
        {
            bool lv_pointer;
            try
            {
                string lv_str_line = PassangerID.ToString();
                lv_str_line += "|" + Name;
                lv_str_line += "|" + Passport;
                lv_str_line += "|" + BirthDate.ToShortDateString();
                lv_str_line += "|" + BloodType;
                lv_str_line += "|" + MaritalStatus;
                lv_str_line += "|" + Address;
                lv_str_line += "|" + Cellphone;
                lv_str_line += "|" + Telephone;
                lv_str_line += "|" + Occupation;
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
                objAllThePassangers = getArchivo();
                AssignAttributes(objAllThePassangers[0]);
                return objAllThePassangers != null;
            }
            catch (Exception objError)
            {
                mv_str_elMensajeSalida = objError.ToString();
                return false;
            }
        }
        public bool Buscar(string p_str_WisLooked)
        {
            if (objAllThePassangers == null)
                Leer();
            ///---
            bool lv_bln_result = false;
            foreach (string[] anAttribute in objAllThePassangers)
            {
                if (anAttribute[1] == p_str_WisLooked)
                {
                    lv_bln_result = true;
                    AssignAttributes(anAttribute);
                    break;
                }
            }
            return lv_bln_result;
        }
        public bool Buscar(int p_int_PassangerID)
        {
            if (objAllThePassangers == null)
                Leer();
            ///---
            bool lv_bln_result = false;
            int lv_int_PassangerID = 0;
            foreach (string[] unAtributos in objAllThePassangers)
            {
                int.TryParse(unAtributos[0], out lv_int_PassangerID);
                if (lv_int_PassangerID == p_int_PassangerID)
                {
                    lv_bln_result = true;
                    AssignAttributes(unAtributos);
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
