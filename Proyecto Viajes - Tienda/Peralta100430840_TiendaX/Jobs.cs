using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Peralta100430840_TiendaX.Pubs
{
    public class Jobs : Data.DataBaseConnect
    {
        private string job_id;
        private string job_desc;
        private string min_lvl;
        private string max_lvl;
        private DataTable obj_AllJobs;

        public Jobs()
        {

        }

        public string getjob_id() { return job_id; }
        public string getjob_desc () { return job_desc; }
        public string getmin_lvl () { return min_lvl; }
        public string getmax_lvl () { return max_lvl; }
        public DataTable getobj_AllJobs() { return obj_AllJobs; }

        public bool Buscar(string criterio, bool ind_PK)
        {
            try
            {
                string filtro = ind_PK ? "job_id='" + criterio + "'" : "job_desc like '%" +
                    criterio + "%'";
                obj_AllJobs = getTabla("jobs", filtro).Tables[0];
                LlenarAtributos();
                return job_id != "";
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
                obj_AllJobs = null;
                return false;
            }
        }

        public bool Agregar( string job_id,
                            string job_desc,
                            string min_lvl,
                            string max_lvl)
        {
            try
            {
                string insert_sql = "INSERT INTO jobs VALUES(";
                insert_sql += "'" + job_id + "'";
                insert_sql += ",'" + job_desc + "'";
                insert_sql += ",'" + min_lvl + "'";
                insert_sql += ",'" + max_lvl + "')";
                return executeDML(insert_sql);
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
                return false;
            }
        }

        public bool Actualizar(string job_id,
                            string job_desc,
                            string min_lvl,
                            string max_lvl)
        {
            try
            {
                string update_sql = "UPDATE jobs SET ";
                update_sql += "job_desc = '" + job_desc + "'";
                update_sql += ", min_lvl = '" + min_lvl + "'";
                update_sql += ", max_lvl = '" + max_lvl + "'";
                update_sql += "WHERE pub_id = '" + job_id + "'";

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
                job_id = "";
                job_desc = "";
                min_lvl = "";
                max_lvl = "";
                if (obj_AllJobs.Rows.Count == 0)
                    return;
                DataRow objRecord = obj_AllJobs.Rows[0];
                job_id = objRecord["job_id"].ToString();
                job_desc = objRecord["job_desc"].ToString();
                min_lvl = objRecord["min_lvl"].ToString();
                max_lvl = objRecord["max_lvl"].ToString();
            }
            catch (Exception objError)
            {
                base.mensaje_user = objError.Message;
            }
        }

    }
}
