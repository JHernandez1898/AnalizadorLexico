using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Quindim.Clases
{
    class MetodosAS
    {
       

        public static void CrearMatriz()
        {

            //Obtener Matriz
            using (SqlConnection con = ConexionMatriz.ObtenerConexion())
            {
                SqlCommand comm = new SqlCommand("SELECT * FROM GramaticaLibre  order by DATALENGTH(Combinacion) ASC", con);
                SqlDataReader red = comm.ExecuteReader();
                Matriz.Load(red);
            }

        }
        public static DataTable Matriz = new DataTable();
        public static string ObtenerConversion(string Combinacion)
        {
            string resultado = Combinacion;
            string where = "Combinacion = '" + Combinacion + "'";
            DataRow[] conversion = Matriz.Select(where);
            if (conversion.Length !=0) resultado = conversion[0]["Conversion"].ToString();
            return resultado;

        }
        public static string NormalizarCadena(string subcadena, int tempo)
        {

            string[] d = subcadena.Split(' ');
            string strCambio = subcadena;
            if (tempo == 1)
            {
                if (d[0] != "IDEN")
                {
                    switch (d[0].Substring(0, 2))
                    {
                        case "ID":
                            strCambio = "ID";
                            break;
                        case "CN":
                            strCambio = "CNE";
                            break;
                    }
                }
            /*    if (d[0].Substring(0, 2) == "ID" && d[0] != "IDEN") { strCambio = "ID"; }
                else if ((d[0] + "  ").Substring(0, 3) == "CNE") { strCambio = "CNE"; }
                else if ((d[0] + " ").Substring(0, 3) == "CNR") { strCambio = "CNR"; }
                else if ((d[0] + " ").Substring(0, 4) == "CNEE") { strCambio = "CNEE"; }
                else if ((d[0] + " ").Substring(0, 4) == "CNRE") { strCambio = "CNRE"; }*/
            }
            return strCambio;


        }
        public static bool DisminuirTemp(string[] Combinaciones,int temp)
        {
            string strCambio = "";
            foreach (string str in Combinaciones)
            {
                strCambio = NormalizarCadena(str, temp);
                string where = "Combinacion = '" + strCambio + "'";
                DataRow[] conversion = Matriz.Select(where);
                if (conversion.Length != 0)
                {
                    return false;
                }
            }
            return true;
        }
        /*
        public static List<string> AnalizadorSemantico(string entrada, ref string salida, ref string comprobacion)
        {
            MetodosAL.Identificadores = new List<Identificador>();
            List<string> LineasTokens;
            LineasTokens = Lexico.AnalizadorLexico(entrada);
            int linea = 1;
            string strCambio;
            string strActual;
            int temp;
            try
            {
                foreach (string cadena in LineasTokens)
                {
                    strActual = cadena;
                    strActual = strActual.Substring(0, strActual.Length - 1);
                    salida += cadena + "\n";
                    temp = strActual.Split(' ').Length;

                    while (temp > 0)
                    {
                        string[] strSubcadenas = MetodosSe.CrearCombinaciones(temp, strActual);
                        //if (!Revisar(strSubcadenas, temp)) temp--;
                        if (MetodosAS.DisminuirTemp(strSubcadenas, temp)) { temp--; }
                        else
                        {
                            foreach (string str in strSubcadenas)
                            {
                                strCambio = NormalizarCadena(str, temp);
                                strActual = strActual.Replace(str, MetodosSe.ObtenerConversion(strCambio));
                            }
                            salida += strActual + "\n";
                            temp = strActual.Split(' ').Length;
                        }
                        if (strActual == "S") { comprobacion += "Línea " + linea.ToString() + ":S" + "\n"; temp = 0; linea++; }
                    }
                    if (strActual != "S") { comprobacion += "Línea " + linea.ToString() + ":ERROR" + "\n"; throw new Exception("Sintaxis incorrecta en la línea: " + linea); }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en sintaxis: " + ex);
            }
        }*/
    }
}
