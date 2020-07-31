using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Peralta100430840_lib1.Personas
{
    public class Piloto : IOAqui.DataInterface, IOAqui.iPersistencia
    {
        private int IDEmploye;
        private string Passport;
        private string Name;
        private int ExpYears;
        private string Address;
        private string BloodType;
        private string Cellphone;
        private string Telephone;
        private string MaritalStatus;
        private double Salary;
        private DateTime BirthDate;
        private DateTime DealDate;
        private string AssignedAirplane;
        private List<string[]> objAllThePilots;
        private List<string> auxAvion;
        public Piloto() : base("Piloto.txt")
        {
        }
        public Piloto(string p_Passport, string p_Name, int p_ExpYears, string p_Address, string p_BloodType, string p_Cellphone,
        string p_Telephone, string p_MaritalStatus, double p_Salary, string p_BirthDate, string p_DealDate, int p_AssignedAirplane) :
        base("Piloto.txt")
        {
            IDEmploye = getMaxPilot() + 1;
            Passport = p_Passport;
            Name = p_Name;
            if (Buscar(p_Name))
            {
                throw new Exception("Esta Nombre ya existe : " + p_Name);
            }
            ExpYears = p_ExpYears;
            Address = p_Address;
            BloodType = p_BloodType;
            Cellphone = p_Cellphone;
            Telephone = p_Telephone;
            MaritalStatus = p_MaritalStatus;
            Salary = p_Salary;
            BirthDate = DateTime.Parse(p_BirthDate);
            DealDate = DateTime.Parse(p_DealDate);
            auxAvion = IOAqui.DataInterface.getListaElementos("ListaDeAviones.txt");
            AssignedAirplane = auxAvion[p_AssignedAirplane];
            AgregarATxt("ListaDePiloto.txt", p_Name);
            Grabar();
        }
        public string getPassport() { return Passport; }
        public int getExpYears() { return ExpYears; }
        public string getAddress() { return Address; }
        public string getBloodType() { return BloodType; }
        public string getCellphone() { return Cellphone; }
        public string getTelephone() { return Telephone; }
        public string getMaritalStatus() { return MaritalStatus; }
        public double getSalary() { return Salary; }
        public DateTime getBirthDate() { return BirthDate; }
        public DateTime getDealDate() { return DealDate; }
        public string getAssignedAirplane() { return AssignedAirplane; }
        public List<string> getauxAvion() { return auxAvion; }
        private int getMaxPilot()
        {
            if (IOAqui.DataInterface.ExisteArchivo("Piloto.txt"))
                if (objAllThePilots == null)
                    Leer();
            if (objAllThePilots == null)
                return 0;
            int lv_int_max = -99999;
            int lv_int_ID_current = 0;
            foreach (string[] unAtributos in objAllThePilots)
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
            string lv_str_diplay = "Los Datos del Piloto son:\n";
            lv_str_diplay += "\n ID Empleado : " + IDEmploye.ToString();
            lv_str_diplay += "\n-----------------------------------\n";
            lv_str_diplay += " \n\n Passport\t\t:" + Passport.ToString();
            lv_str_diplay += " \n Nombre Piloto\t\t:" + Name;
            lv_str_diplay += " \n\n Años de Experiencia\t\t:" + ExpYears.ToString();
            lv_str_diplay += " \n\n Direccion\t\t:" + Address;
            lv_str_diplay += " \n\n Tipo de Sangre\t\t:" + BloodType;
            lv_str_diplay += " \n\n Celular\t\t:" + Cellphone.ToString();
            lv_str_diplay += " \n\n Telefono\t\t:" + Telephone.ToString();
            lv_str_diplay += " \n\n Estado Civil\t\t:" + MaritalStatus;
            lv_str_diplay += " \n\n Sueldo\t\t:" + Salary.ToString();
            lv_str_diplay += " \n\nFecha de Nacimiento\t\t:" + BirthDate.ToShortDateString();
            lv_str_diplay += " \n\nFecha de Contratacion\t\t:" + DealDate.ToShortDateString();
            lv_str_diplay += " \n\nAvion Asignado\t\t:" + AssignedAirplane;
            lv_str_diplay += "\n -----------------------------------\n";
            return lv_str_diplay;
        }
        private void AssignAttributes(string[] p_str_Attributes)
        {
            try
            {
                int.TryParse(p_str_Attributes[0], out IDEmploye);
                Passport = p_str_Attributes[1];
                Name = p_str_Attributes[2];
                ExpYears = int.Parse(p_str_Attributes[3]);
                Address = p_str_Attributes[4];
                BloodType = p_str_Attributes[5];
                Cellphone = p_str_Attributes[6];
                Telephone = p_str_Attributes[7];
                MaritalStatus = p_str_Attributes[8];
                Salary = double.Parse(p_str_Attributes[9]);
                BirthDate = DateTime.Parse(p_str_Attributes[10]);
                DealDate = DateTime.Parse(p_str_Attributes[11]);
                AssignedAirplane = p_str_Attributes[12];
            }

            catch (Exception objError)
            {
                mv_str_elMensajeSalida = objError.Message;
            }
        }
        public List<string[]> getAllPilot()
        {
            if (objAllThePilots == null)
                Leer();
            string lv_display = IOAqui.DataInterface.getMatrixData(objAllThePilots, "PILOTOS");
            return objAllThePilots;
        }

        public string getAllPilotString()
        {
            if (objAllThePilots == null)
                Leer();
            string lv_display = IOAqui.DataInterface.getMatrixData(objAllThePilots, "PILOTOS");
            return lv_display;
        }
        #region INTERFACES
        public bool Grabar()
        {
            bool lv_pointer;
            try
            {
                string lv_str_line = IDEmploye.ToString();
                lv_str_line += "|" + Passport.ToString();
                lv_str_line += "|" + Name.ToString();
                lv_str_line += "|" + ExpYears.ToString();
                lv_str_line += "|" + Address.ToString();
                lv_str_line += "|" + BloodType.ToString();
                lv_str_line += "|" + Cellphone;
                lv_str_line += "|" + Telephone;
                lv_str_line += "|" + MaritalStatus.ToString();
                lv_str_line += "|" + Salary.ToString();
                lv_str_line += "|" + BirthDate.ToShortDateString();
                lv_str_line += "|" + DealDate.ToShortDateString();
                lv_str_line += "|" + AssignedAirplane;
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
                objAllThePilots = getArchivo();
                AssignAttributes(objAllThePilots[0]);
                return objAllThePilots != null;
            }

            catch (Exception objError)
            {
                mv_str_elMensajeSalida = objError.ToString();
                return false;
            }
        }
        public bool Buscar(string p_str_WisLooked)
        {
            if (objAllThePilots == null)
                Leer();
            ///---
            bool lv_bln_result = false;
            foreach (string[] anAttribute in objAllThePilots)
            {
                if (anAttribute[2] == p_str_WisLooked)
                {
                    lv_bln_result = true;
                    AssignAttributes(anAttribute);
                    break;
                }
            }
            return lv_bln_result;
        }
        public bool Buscar(int p_int_PilotoID)
        {
            if (objAllThePilots == null)
                Leer();
            ///---
            bool lv_bln_result = false;
            int lv_int_PilotID = 0;
            foreach (string[] anAttribute in objAllThePilots)
            {
                int.TryParse(anAttribute[0], out lv_int_PilotID);
                if (lv_int_PilotID == p_int_PilotoID)
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
