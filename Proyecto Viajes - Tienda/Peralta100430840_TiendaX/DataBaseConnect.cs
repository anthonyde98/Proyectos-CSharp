using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Peralta100430840_TiendaX.Data
{
    public class DataBaseConnect
    {
        protected string mensaje_user;
        private string stringConection;
        private string current_DB;

        public DataBaseConnect()
        {
            current_DB = "Pubs";
            stringConection = "Data Source = DESKTOP-S0UHG78; Initial Catalog =";
            stringConection += current_DB + "; Integrated Security = True";
        }
        public DataBaseConnect(string current_DB)
        {
            stringConection = "Data Source = DESKTOP-S0UHG78; Initial Catalog =";
            stringConection += current_DB + "; Integrated Security = True";
        }

        public DataSet getTabla(string consulta)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(stringConection);

                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataSet datos = new DataSet();
                adaptador.Fill(datos);
                conexion.Close();
                comando.Dispose();
                adaptador.Dispose();
                return datos;
            }
            catch (Exception objError)
            {
                mensaje_user = objError.Message;
                return null;
            }
        }
        
        public bool executeDML(string consulta)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(stringConection);
                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta, conexion);                
                comando.ExecuteNonQuery();                
                conexion.Close();
                comando.Dispose();
                return true;
            }
            catch (Exception objError)
            {
                mensaje_user = objError.Message;
                return false;
            }       
        }

        public DataSet getTabla(string tablas, string columnas, string where)
        {
            string consulta = "Select ";
            if (tablas.IndexOf(" ") >= 0)
            {
                tablas = "[" + tablas + "]";
                tablas = tablas.Replace(".", "].[");
            }
            if (columnas == null || columnas.Trim() == "")
                columnas += " * ";
            if(where == null || where.Trim() == "")
            {
                where = " 1 =1 \n Order by 1";

                columnas = " Top 10 " + columnas;
            }

            consulta += columnas + " ";
            consulta += " From " + tablas + "";
            consulta += " Where " + where;
            return getTabla(consulta);
        }

        public DataSet getTabla(string tablas, string where)
        {
            return getTabla(tablas, "*", where);
        }

        public DataTable getTablaSistema()
        {
            string consulta = "select schemas.name + '.' + sysobjects.name as name\n" +
                              "from sys.sysobjects \n" +
                              "inner join sys.schemas\n" +
                              "on schemas.schema_id = sysobjects.uid\n" +
                              "where type = 'U'\n";
            DataTable objTablaSist = getTabla(consulta).Tables[0];
            return objTablaSist;
        }

        public DataTable getTablaSistema(bool indCompile)
        {
            string consulta = "execute_sys_tables;";
            DataTable objTablaSist = getTabla(consulta).Tables[0];
            return objTablaSist;
        }

        public string getMensaje()
        {
            return mensaje_user;
        }
    }
}
