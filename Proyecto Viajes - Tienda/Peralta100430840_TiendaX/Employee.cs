using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Peralta100430840_TiendaX.Pubs
{
    public class Employee : Data.DataBaseConnect
    {
        private string emp_id;
        private string fname;
        private string minit;
        private string lname;
        private string pub_name;
        private string job_desc;
        private string job_id;
        private string job_lvl;
        private string pub_id;
        private DateTime hire_date;
        private DataTable obj_AllEmployees;

        public Employee()
        {

        }

        public string getemp_id() { return emp_id; }
        public string getfname() { return fname; }
        public string getminit() { return minit; }
        public string getlname() { return lname; }
        public string getpub_name() { return pub_name; }
        public string getjob_desc() { return job_desc; }
        public string getjob_id() { return job_id; }
        public string getjob_lvl() { return job_lvl; }
        public string getpub_id() { return pub_id; }
        public DateTime gethire_date() { return hire_date; }
        public DataTable getobj_AllEmployees() { return obj_AllEmployees; }

        public bool Buscar(string criterio, bool ind_PK)
        {
            try
            {
                string filtro = ind_PK ? "emp_id='" + criterio + "'" : "fname like '%" +
                    criterio + "%'";
                obj_AllEmployees = getTabla("employee", filtro).Tables[0];
                LlenarAtributos();
                return emp_id != "";
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
                obj_AllEmployees = null;
                return false;
            }
        }

        public bool Agregar(string emp_id,
                            string fname,
                            string minit,
                            string lanme,
                            string job_id,
                            string job_lvl,
                            string pub_id,
                            DateTime hire_date)
        {
            try
            {
                string insert_sql = "INSERT INTO employee VALUES(";
                insert_sql += "'" + emp_id + "'";
                insert_sql += ",'" + fname + "'";
                insert_sql += ",'" + minit + "'";
                insert_sql += ",'" + lanme + "'";
                insert_sql += ",'" + job_id + "'";
                insert_sql += ",'" + job_lvl + "'";
                insert_sql += ",'" + pub_id + "'";
                insert_sql += ",'" + hire_date + "')";
                return executeDML(insert_sql);
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
                return false;
            }
        }

        public bool Actualizar(string emp_id,
                            string fname,
                            string minit,
                            string lanme,
                            string job_id,
                            string job_lvl,
                            string pub_id,
                            DateTime hire_date)
        {
            try
            {
                string fecha = hire_date.Year + "-" + hire_date.Month + "-" + hire_date.Day;

                string update_sql = "UPDATE employee SET ";
                update_sql += "fname = '" + fname + "'";
                update_sql += ", minit = '" + minit + "'";
                update_sql += ", lanme = '" + lanme + "'";
                update_sql += ", job_id = " + job_id + "";
                update_sql += ", job_lvl = " + job_lvl + "";
                update_sql += ", pub_id = " + pub_id + "";
                update_sql += ", pubdate = '" + fecha + "'";
                update_sql += "WHERE title_id = '" + emp_id + "'";

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

        public string getEmpleo(string job_id)
        {
            DataSet objDataPub = getTabla("jobs", "job_desc", "job_id = '" + job_id + "'");
            string result = objDataPub != null && objDataPub.Tables[0].Rows.Count > 0 ?
                objDataPub.Tables[0].Rows[0]["job_desc"].ToString() : "";
            if (objDataPub != null)
                objDataPub.Dispose();
            return result;
        }

        public DataTable getEmpleo()
        {
            DataSet objTablePub = getTabla("jobs", "job_id, job_desc", " 1=1 ");
            DataTable result = objTablePub != null && objTablePub.Tables[0].Rows.Count > 0 ?
                objTablePub.Tables[0] : null;
            return result;
        }

        public void LlenarAtributos()
        {
            try
            {
                emp_id = "";
                fname = "";
                minit = "";
                lname = "";
                job_id = "";
                job_lvl ="";
                pub_id = "";
                hire_date = DateTime.Now;
                if (obj_AllEmployees.Rows.Count == 0)
                    return;
                DataRow objRecord = obj_AllEmployees.Rows[0];
                emp_id = objRecord["emp_id"].ToString();
                fname = objRecord["fname"].ToString();
                minit = objRecord["minit"].ToString();
                lname = objRecord["lname"].ToString();
                pub_name = getEditora(objRecord["pub_id"].ToString());
                job_desc = getEmpleo(objRecord["job_id"].ToString());
                job_id = objRecord["job_id"].ToString();
                job_lvl = objRecord["job_lvl"].ToString();
                pub_id = objRecord["pub_id"].ToString();
                hire_date = DateTime.Parse(objRecord["pubdate"].ToString());
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
            }
        }
    }
}