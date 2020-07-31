using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Peralta100430840_TiendaX.Pubs
{
    public class Titles  : Data.DataBaseConnect
    {
        private string title_id;
        private string title;
        private string type;
        private string pub_id;
        private string pub_name;
        private float price;
        private float advance;
        private int royalty;
        private int ytd_sales;
        private string notes;
        private DateTime pubdate;
        private DataTable obj_AllBooks;

        public Titles()
        {

        }

        public string gettitle_id() { return title_id; }
        public string gettitle() { return title; }
        public string gettype() { return type; }
        public string getpub_id() { return pub_id; }
        public string getPub_Name() { return pub_name; }
        public float getprice() { return price; }
        public float getadvance() { return advance; }
        public int getroyalty() { return royalty; }
        public int gettytd_sales() { return ytd_sales; }
        public string getnotes() { return notes; }
        public DateTime getpubdate() { return pubdate; }
        public DataTable getAllBook() { return obj_AllBooks; }

        public bool Buscar(string criterio, bool ind_PK)
        {
            try
            {
                string filtro = ind_PK ? "title_id='" + criterio + "'" : "title like '%" +
                    criterio + "%'";
                obj_AllBooks = getTabla("titles", filtro).Tables[0];
                LlenarAtributos();
                return title_id != "";
            }
            catch(Exception objError)
            {
                base.mensaje_user = objError.Message;
                obj_AllBooks = null;
                return false;
            }
        }

        public bool Agregar(string title_id,
                            string title,
                            string type,
                            string pub_id,
                            float price,
                            float advance,
                            int royalty,
                            int ytd_sales,
                            string notes,
                            DateTime pubdate)
        {
            try
            {
                string insert_sql = "INSERT INTO titles VALUES(";
                insert_sql += "'" + title_id + "'";
                insert_sql += ",'" + title + "'";
                insert_sql += ",'" + type + "'";
                insert_sql += ",'" + pub_id + "'";
                insert_sql += "," + price + "";
                insert_sql += "," + advance + "";
                insert_sql += "," + royalty + "";
                insert_sql += "," + ytd_sales + "";
                insert_sql += ",'" + notes + "'";
                insert_sql += ",'" + pubdate + "')";
                return executeDML(insert_sql);
            }
            catch(Exception objError)
            {
                base.mensaje_user = objError.Message;
                return false;
            }
        }

        public bool Actualizar(string title_id,
                               string title,
                               string type,
                               string pub_id,
                               float price,
                               float advance,
                               int royalty,
                               int ytd_sales,
                               string notes,
                               DateTime pubdate)
        {
            try
            {
                string fecha = pubdate.Year + "-" + pubdate.Month + "-" + pubdate.Day;

                string update_sql = "UPDATE titles SET ";
                update_sql += "title = '" + title + "'";
                update_sql += ", type = '" + type + "'";
                update_sql += ", pub_id = '" + pub_id + "'";
                update_sql += ", price = " + price + "";
                update_sql += ", advance = " + advance + "";
                update_sql += ", royalty = " + royalty + "";
                update_sql += ", ytd_sales = " + ytd_sales + "";
                update_sql += ", notes = '" + notes + "'";
                update_sql += ", pubdate = '" + fecha + "'";
                update_sql += "WHERE title_id = '" + title_id + "'";

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

        public string getEditora(string pub_id)
        {
            DataSet objDataPub = getTabla("publishers", "pub_name", "pub_id = '" + pub_id + "'");
            string result = objDataPub != null && objDataPub.Tables[0].Rows.Count > 0 ?
                objDataPub.Tables[0].Rows[0]["pub_name"].ToString() : "";
            if (objDataPub != null)
                objDataPub.Dispose();
            return result;
        }

        public DataTable getEditora()
        {
            DataSet objTablePub = getTabla("publishers", "pub_id, pub_name", " 1=1 ");
            DataTable result = objTablePub != null && objTablePub.Tables[0].Rows.Count > 0 ?
                objTablePub.Tables[0] : null;
            return result;
        }

        public DataTable getGenero()
        {
            DataSet objTablaPub = getTabla("titles", "distinct type", " 1=1 ");
            DataTable lv_str_Result = objTablaPub != null && objTablaPub.Tables[0].Rows.Count > 0 ? 
                objTablaPub.Tables[0] : null;
            return lv_str_Result;
        }

        public void LlenarAtributos()
        {
            try
            {
                title_id = "";
                title = "";
                type = "";
                pub_id = "";
                price = 0;
                advance = 0;
                royalty = 0;
                ytd_sales = 0;
                notes = "";
                pubdate = DateTime.Now;
                if (obj_AllBooks.Rows.Count == 0)
                    return;
                DataRow objRecord = obj_AllBooks.Rows[0];
                title_id = objRecord["title_id"].ToString();
                title = objRecord["title"].ToString();
                type = objRecord["type"].ToString();
                pub_id = objRecord["pub_id"].ToString();
                pub_name = getEditora(objRecord["pub_id"].ToString());
                price = objRecord["price"] == null ? 0 : float.Parse(objRecord["price"].ToString());
                advance = objRecord["advance"] == null ? 0 : float.Parse(objRecord["advance"].ToString());
                royalty = objRecord["royalty"] == null ? 0 : int.Parse(objRecord["royalty"].ToString());
                ytd_sales = objRecord["ytd_sales"] == null ? 0 : int.Parse(objRecord["ytd_sales"].ToString());
                notes = objRecord["notes"].ToString();
                pubdate = DateTime.Parse(objRecord["pubdate"].ToString());
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
            }
        }
    }
}
