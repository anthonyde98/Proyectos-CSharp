using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Peralta100430840_TiendaX.Pubs
{
    public class Author : Data.DataBaseConnect
    {
        private string au_id;
        private string au_lastname;
        private string au_firstname;
        private string phone;
        private string address;
        private string city;
        private string state;
        private string zip;
        private int contract;
        private DataTable obj_AllAuthors;

        public Author()
        {

        }

        public string getau_id() { return au_id; }
        public string getau_lastname() { return au_lastname; }
        public string getau_firstname() { return au_firstname; }
        public string getphone() { return phone; }
        public string getaddress() { return address; }
        public string getcity() { return city; }
        public string getstate() { return state; }
        public string getzip() { return zip; }
        public int getcontract() { return contract; }
        public DataTable getobj_AllAuthors() { return obj_AllAuthors; }

        public bool Buscar(string criterio, bool ind_PK)
        {
            try
            {
                string filtro = ind_PK ? "au_id='" + criterio + "'" : "au_lname like '%" +
                    criterio + "%'";
                obj_AllAuthors = getTabla("authors", filtro).Tables[0];
                LlenarAtributos();
                return au_id != "";
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
                obj_AllAuthors = null;
                return false;
            }
        }

        public bool Agregar(string au_id,
                            string au_lastname,
                            string au_firstname,
                            string phone,
                            string address,
                            string city,
                            string state,
                            string zip,
                            int contract)
        {
            try
            {
                string insert_sql = "INSERT INTO authors VALUES(";
                insert_sql += "'" + au_id + "'";
                insert_sql += ",'" + au_lastname + "'";
                insert_sql += ",'" + au_firstname + "'";
                insert_sql += ",'" + phone + "'";
                insert_sql += ",'" + address + "'";
                insert_sql += ",'" + city + "'";
                insert_sql += ",'" + state + "'";
                insert_sql += ",'" + zip + "'";
                insert_sql += "," + contract + ")";
                return executeDML(insert_sql);
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
                return false;
            }
        }
        public bool Actualizar(string au_id,
                            string au_lastname,
                            string au_firstname,
                            string phone,
                            string address,
                            string city,
                            string state,
                            string zip,
                            int contract)
        {
            try
            {
                string update_sql = "UPDATE authors SET ";
                update_sql += "au_lname = '" + au_lastname + "'";
                update_sql += ", au_fname = '" + au_firstname + "'";
                update_sql += ", phone = '" + phone + "'";
                update_sql += ", address = '" + address + "'";
                update_sql += ", city = '" + city + "'";
                update_sql += ", state = '" + state + "'";
                update_sql += ", zip = '" + zip + "'";
                update_sql += ", contract = " + contract + "";
                update_sql += " WHERE au_id = '" + au_id + "'";

                return executeDML(update_sql);
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
            }
            return true;
        }

        public bool Eliminar(string criterio)
        {
            return true;
        }
       
        public void LlenarAtributos()
        {
            try
            {
                au_id = "";
                au_lastname = "";
                au_firstname = "";
                phone = "";
                address = "";
                city = "";
                state = "";
                zip = "";
                contract = 0;               
                if (obj_AllAuthors.Rows.Count == 0)
                    return;
                DataRow objRecord = obj_AllAuthors.Rows[0];
                au_id = objRecord["au_id"].ToString();
                au_lastname = objRecord["au_lname"].ToString();
                au_firstname = objRecord["au_fname"].ToString();
                phone = objRecord["phone"].ToString();
                address = objRecord["address"].ToString();
                city = objRecord["city"].ToString();
                state = objRecord["state"].ToString();
                zip = objRecord["zip"].ToString();
                contract = objRecord["contract"] == null ? 0 : int.Parse(objRecord["contract"].ToString());
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
            }
        }
    }
}
