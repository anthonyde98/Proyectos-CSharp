using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
namespace Peralta100430840_lib1.IOAqui
{
    public class DataInterface
    {
        private string mv_str_elNobreFisico;
        protected string mv_str_elMensajeSalida;

        public DataInterface(string p_nombre_archivo)
        {
            mv_str_elNobreFisico = p_nombre_archivo;
        }

        public bool Agregar(string p_str_line)
        {
            try
            {
                if (mv_str_elNobreFisico == "")
                    return false;
                string lv_str_laRuta = System.Configuration.ConfigurationManager.AppSettings["ruta_en_disk"];
                StreamWriter objFileActual = new StreamWriter(lv_str_laRuta + "\\" + mv_str_elNobreFisico, true);
                objFileActual.WriteLine(p_str_line);
                objFileActual.Close();
                return true;
            }

            catch (Exception objErrores)
            {
                mv_str_elMensajeSalida = objErrores.ToString();
                return false;
            }
        }
        public List<string[]> getArchivo()
        {
            try
            {
                string lv_str_laruta = System.Configuration.ConfigurationManager.AppSettings["ruta_en_disk"];
                StreamReader objFileActual = new StreamReader(lv_str_laruta + "\\" + mv_str_elNobreFisico);
                List<string[]> objLasLineas = new List<string[]>();
                while (!objFileActual.EndOfStream)
                {
                    lv_str_laruta = objFileActual.ReadLine();
                    objLasLineas.Add(lv_str_laruta.Split('|'));
                }
                objFileActual.Close();
                return objLasLineas;
            }
            catch (Exception objErrores)
            {
                mv_str_elMensajeSalida = objErrores.ToString();
                return null;
            }
        }
        public string getMensajeError()
        {
            return mv_str_elMensajeSalida;
        }
        /******************************** statics ************************************************/
        public static string getMatrixData(List<string[]> p_objListAtributos, string p_regis)
        {
            StringBuilder lv_SalidaMatrix = new StringBuilder("\n\n\t\t\tREGISTRO DE " + p_regis + "\n--------------------------------------------------------------------------------------------\n\n\n");
            string lv_str_linea = "";
            foreach (string[] unAtributos in p_objListAtributos)
            {
                lv_str_linea = "";
                for (int K = 0; K < unAtributos.Length; K++)
                {
                    lv_str_linea += " |" + unAtributos[K];
                }
                lv_SalidaMatrix.Append(lv_str_linea + "\n");
                lv_SalidaMatrix.Append("--------------------------------------------------------------------------------------------" + "\n");
            }
            return lv_SalidaMatrix.ToString();
        }
        public static string EnumToString(Type p_EnumType)
        {
            string lv_str_salida = "";
            foreach (var value in Enum.GetValues(p_EnumType))
            {
                lv_str_salida += (int)value + "," + value.ToString() + ".\n";
            }
            return lv_str_salida;
        }
        public static class Contraseña
        {
            public static string ReadPassword(char mask)
            {
                const int ENTER = 13, BACKSP = 8, CTRLBACKSP = 127;
                int[] FILTERED = { 0, 27, 9, 10, 32 };
                var pass = new Stack<char>();
                char chr = (char)0;
                while ((chr = System.Console.ReadKey(true).KeyChar) != ENTER)
                {
                    if (chr == BACKSP)
                    {
                        if (pass.Count > 0)
                        {
                            System.Console.Write("\b \b");
                            pass.Pop();
                        }
                    }
                    else if (chr == CTRLBACKSP)
                    {
                        while (pass.Count > 0)
                        {
                            System.Console.Write("\b \b");
                            pass.Pop();
                        }
                    }
                    else if (FILTERED.Count(x => chr == x) > 0) { }
                    else
                    {
                        pass.Push((char)chr);
                        System.Console.Write(mask);
                    }
                }
                System.Console.WriteLine();
                return new string(pass.Reverse().ToArray());
            }
            public static string ReadPassword()
            {
                return Contraseña.ReadPassword('*');
            }
        }
        public static bool ExisteArchivo(string p_ElNombre)
        {
            string laRuta = System.Configuration.ConfigurationManager.AppSettings["ruta_en_disk"];
            if (File.Exists(laRuta + "\\" + p_ElNombre))
                return true;
            else
                return false;
        }

        public static string Desencriptar(string p_ElNombre)
        {
            string ADesencriptar = "";
            string laRuta = System.Configuration.ConfigurationManager.AppSettings["ruta_en_disk"];
            using (StreamReader objFileActual = new StreamReader(laRuta + "\\" + p_ElNombre, true))
            {
                string aux = objFileActual.ReadLine();
                for (int i = 0; i < aux.Length; i++)
                {
                    ADesencriptar += (char)(aux[i] - 3);
                }
                objFileActual.Close();
            }
            return ADesencriptar;
        }
        public static string Encriptar(string p_Texto)
        {
            string Encriptado = "";
            for (int i = 0; i < p_Texto.Length; i++)
            {
                Encriptado += (char)(p_Texto[i] + 3);
            }
            return Encriptado;
        }
        public static void AgregarATxt(string p_ElNombre, string p_Texto)
        {
            string laRuta = System.Configuration.ConfigurationManager.AppSettings["ruta_en_disk"];
            if (File.Exists(laRuta + "\\" + p_ElNombre))
                if ((File.GetAttributes(laRuta + "\\" + p_ElNombre) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    File.SetAttributes((laRuta + "\\" + p_ElNombre), FileAttributes.Normal);
            string TextoEncriptado = Encriptar(p_Texto);
            using (StreamWriter objCrear = new StreamWriter(laRuta + "\\" + p_ElNombre, true))
            {
                objCrear.WriteLine(TextoEncriptado);
                objCrear.Close();
            }
            File.SetAttributes((laRuta + "\\" + p_ElNombre), FileAttributes.ReadOnly | FileAttributes.Hidden);
            return;
        }
        public static void BorrarDatos(string p_usuario, string p_clave)
        {
            string laRuta = System.Configuration.ConfigurationManager.AppSettings["ruta_en_disk"];
            if ((File.GetAttributes(laRuta + "\\" + p_usuario) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                File.SetAttributes((laRuta + "\\" + p_usuario), FileAttributes.Normal);
            File.Delete(laRuta + "\\" + p_usuario);
            if ((File.GetAttributes(laRuta + "\\" + p_clave) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                File.SetAttributes((laRuta + "\\" + p_clave), FileAttributes.Normal);
            File.Delete(laRuta + "\\" + p_clave);
            return;
        }
        public static List<string> MostrarElementosLista(string p_archivo_fisico)
        {
            List<string> p_objLista = getListaElementos(p_archivo_fisico);
            string mostrar = "";
            for (int i = 0; i < p_objLista.Count(); i++)
                mostrar += i + ")" + p_objLista[i] + ".";
            return p_objLista;
        }
        public static string MostrarElementosLista2(string p_archivo_fisico)
        {
            List<string> p_objLista = getListaElementos(p_archivo_fisico);
            string mostrar = "";
            for (int i = 0; i < p_objLista.Count(); i++)
                mostrar += 1+i + ") " + p_objLista[i] + "\n";
            return mostrar;
        }
        public static List<string> getListaElementos(string p_archivo_fisico)
        {
            try
            {
                string lv_str_laruta = System.Configuration.ConfigurationManager.AppSettings["ruta_en_disk"];
                StreamReader objFileActual = new StreamReader(lv_str_laruta + "\\" + p_archivo_fisico);
                List<string> objLasLineas = new List<string>();
                while (!objFileActual.EndOfStream)
                {
                    lv_str_laruta = objFileActual.ReadLine();
                    lv_str_laruta = DesencriptarCadena(lv_str_laruta);
                    objLasLineas.Add(lv_str_laruta);
                }
                objFileActual.Close();
                return objLasLineas;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string DesencriptarCadena(string p_cadena)
        {
            string ADesencriptar = "";
            for (int i = 0; i < p_cadena.Length; i++)
            {
                ADesencriptar += (char)(p_cadena[i] - 3);
            }
            return ADesencriptar;
        }
    }
}