using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Peralta100430840_TiendaX.Pubs
{
    public class Sales : Data.DataBaseConnect
    {
        private string stor_id;
        private string store;
        private string ord_num;
        private DateTime ord_date;
        private int qty;
        private string payterms;
        private string title_id;
        private string title;
        private DataTable obj_AllSales;

        public Sales()
        {

        }

        public string getstor_id() { return stor_id; }
        public string getstore() { return store; }
        public string getord_num() { return ord_num; }
        public DateTime getord_date() { return ord_date; }
        public int getqty() { return qty; }
        public string getpayterms() { return payterms; }
        public string gettitle_id() { return title_id; }
        public string gettitle() { return title; }
        public DataTable getobj_AllSales() { return obj_AllSales; }

        public bool Buscar(string criterio, bool ind_PK)
        {
            try
            {                 
                obj_AllSales = getTabla(criterio).Tables[0];
                return stor_id != "";
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
                obj_AllSales = null;
                return false;
            }
        }

        public bool Agregar(string stor_id,
                            string ord_num,
                            DateTime ord_date,
                            int qty,
                            string payterms,
                            string title_id)
        {
            try
            {
                string insert_sql = "INSERT INTO stores VALUES(";
                insert_sql += "'" + stor_id + "'";
                insert_sql += ",'" + ord_num + "'";
                insert_sql += ",'" + ord_date + "'";
                insert_sql += "," + qty + "";
                insert_sql += ",'" + payterms + "'";
                insert_sql += ",'" + title_id + "')";
                return executeDML(insert_sql);
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
                return false;
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
    }
}
