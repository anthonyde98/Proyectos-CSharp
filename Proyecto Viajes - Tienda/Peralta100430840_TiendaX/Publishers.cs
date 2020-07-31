using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Peralta100430840_TiendaX.Pubs
{
    public class Publishers : Data.DataBaseConnect
    {
        private string pub_id;
        private string pub_name;
        private string city;
        private string state;
        private string country;
        private DataTable obj_AllPublishers;

        public Publishers()
        {

        }

        public string getpub_id() { return pub_id; }
        public string getpub_name() { return pub_name; }
        public string getcity() { return city; }
        public string getstate() { return state; }
        public string getcountry() { return country; }
        public DataTable getobj_AllPublishers() { return obj_AllPublishers; }

        public bool Buscar(string criterio, bool ind_PK)
        {
            try
            {
                string filtro = ind_PK ? "pub_id='" + criterio + "'" : "pub_name like '%" +
                    criterio + "%'";
                obj_AllPublishers = getTabla("publishers", filtro).Tables[0];
                LlenarAtributos();
                return pub_id != "";
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
                obj_AllPublishers = null;
                return false;
            }
        }

        public bool Agregar(string pub_id,
                            string pub_name,
                            string city,
                            string state,
                            string country)
        {
            try
            {
                string insert_sql = "INSERT INTO publishers VALUES(";
                insert_sql += "'" + pub_id + "'";
                insert_sql += ",'" + pub_name + "'";
                insert_sql += ",'" + city + "'";
                insert_sql += ",'" + state + "'";
                insert_sql += ",'" + country + "')";
                return executeDML(insert_sql);
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
                return false;
            }
        }

        public bool Actualizar(string pub_id,
                            string pub_name,
                            string city,
                            string state,
                            string country)
        {
            try
            {
                string update_sql = "UPDATE publishers SET ";
                update_sql += "pub_name = '" + pub_name + "'";
                update_sql += ", city = '" + city + "'";
                update_sql += ", state = '" + state + "'";
                update_sql += ", country = '" + country + "'";
                update_sql += "WHERE pub_id = '" + pub_id + "'";

                return executeDML(update_sql);
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
                return true;
            }
        }

        public bool Eliminar(string criterio)
        {
            return true;
        }

        public void LlenarAtributos()
        {
            try
            {
                pub_id = "";
                pub_name = "";
                city = "";
                state = "";
                country = "";
                if (obj_AllPublishers.Rows.Count == 0)
                    return;
                DataRow objRecord = obj_AllPublishers.Rows[0];
                pub_id = objRecord["pub_id"].ToString();
                pub_name = objRecord["pub_name"].ToString();
                city = objRecord["city"].ToString();
                state = objRecord["state"].ToString();
                country = objRecord["country"].ToString();
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
            }
        }
    }
}
