using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Peralta100430840_TiendaX.Pubs
{
    public class Store : Data.DataBaseConnect
    {
        private string stor_id;
        private string stor_name;
        private string stor_address;
        private string stor_city;
        private string stor_state;
        private string stor_zip;
        private DataTable obj_AllStores;

        public Store()
        {

        }

        public string getstor_id() { return stor_id; }
        public string getstor_name() { return stor_name; }
        public string getstor_address() { return stor_address; }
        public string getstor_city() { return stor_city; }
        public string getstor_state() { return stor_state; }
        public string getstor_zip() { return stor_zip; }
        public DataTable getobj_AllStores() { return obj_AllStores; }

        public bool Buscar(string criterio, bool ind_PK)
        {
            try
            {
                string filtro = ind_PK ? "stor_id='" + criterio + "'" : "stor_name like '%" +
                    criterio + "%'";
                obj_AllStores = getTabla("stores", filtro).Tables[0];
                LlenarAtributos();
                return stor_id != "";
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
                obj_AllStores = null;
                return false;
            }
        }

        public bool Agregar(string stor_id,
                            string stor_name,
                            string stor_address,
                            string stor_city,
                            string stor_state,
                            string stor_zip)
        {
            try
            {
                string insert_sql = "INSERT INTO stores VALUES(";
                insert_sql += "'" + stor_id + "'";
                insert_sql += ",'" + stor_name + "'";
                insert_sql += ",'" + stor_address + "'";
                insert_sql += ",'" + stor_city + "'";
                insert_sql += ",'" + stor_state + "'";
                insert_sql += ",'" + stor_zip + "')";
                return executeDML(insert_sql);
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
                return false;
            }
        }

        public bool Actualizar(string stor_id,
                            string stor_name,
                            string stor_address,
                            string stor_city,
                            string stor_state,
                            string stor_zip)
        {
            try
            {
                string update_sql = "UPDATE stores SET ";
                update_sql += "stor_name = '" + stor_name + "'";
                update_sql += ", stor_address = '" + stor_address + "'";
                update_sql += ", stor_city = '" + stor_city + "'";
                update_sql += ", stor_state = '" + stor_state + "'";
                update_sql += ", stor_state = '" + stor_state + "'";
                update_sql += "WHERE pub_id = '" + stor_zip + "'";

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

        public DataTable getTiendas()
        {
            DataSet objTablePub = getTabla("stores", "stor_id, stor_name", " 1=1 ");
            DataTable result = objTablePub != null && objTablePub.Tables[0].Rows.Count > 0 ?
                objTablePub.Tables[0] : null;
            return result;
        }

        public void LlenarAtributos()
        {
            try
            {
                stor_id = "";
                stor_name = "";
                stor_address = "";
                stor_city = "";
                stor_state = "";
                stor_zip = "";
                if (obj_AllStores.Rows.Count == 0)
                    return;
                DataRow objRecord = obj_AllStores.Rows[0];
                stor_id = objRecord["stor_id"].ToString();
                stor_name = objRecord["stor_name"].ToString();
                stor_address = objRecord["stor_address"].ToString();
                stor_city = objRecord["city"].ToString();
                stor_state = objRecord["state"].ToString();
                stor_zip = objRecord["zip"].ToString();
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
            }
        }
    }
}
