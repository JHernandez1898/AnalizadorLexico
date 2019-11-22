using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Quindim.Clases
{
    class MetodosSe
    {
        public static string[] CrearCombinaciones(int temp, string linea)
        {
            string[] arreglo = linea.Split(' ');

            string[] NuevaLinea = new string[(arreglo.Length + 1) - temp];
            for (int j = 0; j < NuevaLinea.Length; j++)
            {
                string Elemento = "";
                for (int i = 0; i < temp; i++)
                {
                    if (temp != 1) Elemento += arreglo[j + i] + " ";
                    else Elemento += arreglo[j + i];
                }
                if (temp == 1) NuevaLinea[j] = Elemento;
                else NuevaLinea[j] = Elemento.Substring(0, Elemento.Length - 1);
            }
            return NuevaLinea;
        }
        public static string ObtenerArchivoTemporal(string Linea) 
        {
           Linea = Linea.Replace("CADE", "STRG");
           Linea = Linea.Replace("PR23", "BOOL");
           Linea = Linea.Replace("PR22", "BOOL");
            foreach (Identificador elemento in MetodosAL.Identificadores)
            {
                string id = "ID" + elemento.Index;
                if (Linea.Contains("PR11") && elemento.Tipo == null) { Linea = Linea.Replace(id, "VOID"); elemento.Tipo = "VOID"; }
                else Linea = Linea.Replace(id, elemento.Tipo);
            }
           foreach(NumericoEntero x in MetodosAL.ConstantesNumericasEnteras)
            {
                string id = "CNE" + x.Index;
                Linea = Linea.Replace(id,"INTE");
            }
            foreach (NumericoExponencial x in MetodosAL.ConstantesNumericasExponenciales)
            {
                string id = "CNEE" + x.Index;
                Linea = Linea.Replace(id, "INTE");
            }
            foreach (NumericoReal x in MetodosAL.ConstantesNumericasReales)
            {
                string id = "CNR" + x.Index;
                Linea = Linea.Replace(id, "DBLE");
            }
            foreach (NumericoExpReal x in MetodosAL.ConstantesNumericasExpReales)
            {
                string id = "CNRE" + x.Index;
                Linea = Linea.Replace(id, "INTE");
            }
            return Linea;
        }
        public static List<string> PrimeraPasada(List<string> LineasTokens)
        {
            List<string> LineasSemantica = new List<string>();
            string strActual = "";
            try
            {
                foreach (string cadena in LineasTokens)
                {
                    strActual = cadena;
                    strActual = strActual.Substring(0, strActual.Length - 1);
                    string[] combinacionesde2 = CrearCombinaciones(2, strActual);
                    foreach (string str in combinacionesde2)
                    {
                        string[] arreglo1 = str.Split(' ');
                        
                        if (arreglo1[0].Substring(0, 3) == "TDD" && arreglo1[1].Substring(0, 2) == "ID")
                        {
                            string strIndex1 = arreglo1[1];
                            int index = int.Parse(strIndex1.Replace("ID", ""));
                            Identificador elemento = MetodosAL.Identificadores.Find(x => x.Index == index);
                            MetodosAL.Identificadores.Remove(elemento);
                            switch (arreglo1[0])
                            {
                                case "TDD1":
                                    elemento.Tipo = "INTE";
                                    break;
                                case "TDD2":
                                    elemento.Tipo = "DBLE";
                                    break;
                                case "TDD3":
                                    elemento.Tipo = "STRG";
                                    break;
                                case "TDD4":
                                    elemento.Tipo = "CHAR";
                                    break;
                                case "TDD5":
                                    elemento.Tipo = "BOOL";
                                    break;
                                default:
                                    throw new Exception("Tipo de dato erroneo");
                            }
                            MetodosAL.Identificadores.Add(elemento);
                        }
                    }
                }
                foreach(string d in LineasTokens)
                {
                    LineasSemantica.Add(ObtenerArchivoTemporal(d));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return LineasSemantica;
        }
        public static void CrearMatriz()
        {

            //Obtener Matriz
            using (SqlConnection con = ConexionMatriz.ObtenerConexion())
            {
                SqlCommand comm = new SqlCommand("SELECT * FROM ReglasSemanticas order by DATALENGTH(Combinacion) ASC", con);
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
            if (conversion.Length != 0) resultado = conversion[0]["Conversion"].ToString();
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
        public static bool DisminuirTemp(string[] Combinaciones, int temp)
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
        public static List<string> SegundaPasada(List<string> LineasSemantica)
        {
            string salida="";
            string validas = "";
            List<string> salidas = new List<string>();
            int linea = 1;
            string strCambio;
            string strActual;
            int begins = 0;
            int ends = 0;
            int temp;
            MetodosSe.CrearMatriz();
            try
            {
                foreach (string cadena in LineasSemantica)
                {
                    strActual = cadena;
                    strActual = strActual.Trim();
                    //strActual = strActual.Substring(0, strActual.Length - 1); JULIOOOOOOOOOOOOO
                    salida += cadena + "\n";
                    temp = strActual.Split(' ').Length;

                    while (temp > 0)
                    {
                        string[] strSubcadenas = MetodosSe.CrearCombinaciones(temp, strActual);
                        if (MetodosSe.DisminuirTemp(strSubcadenas, temp)) { temp--; }
                        else
                        {
                            foreach (string str in strSubcadenas)
                            {
                                strCambio = MetodosSe.NormalizarCadena(str, temp);
                                strActual = strActual.Replace(str, MetodosSe.ObtenerConversion(strCambio));
                            }
                            salida += strActual + "\n";
                            temp = strActual.Split(' ').Length;
                        }
                        if (strActual == "S")
                        {
                            if (
                                (cadena.Contains("PR04") && cadena.Contains("PR20")) |
                                cadena.Contains("PR04") |
                                cadena.Contains("PR05") |
                                cadena.Contains("PR06") |
                                cadena.Contains("PR07") |
                                cadena.Contains("PR08") |
                                cadena.Contains("PR11") |
                                cadena.Contains("PR18") |
                                cadena.Contains("PR20")
                            ) begins++;
                            else
                            {
                                if (cadena.Contains("PR21")) ends++;
                            }
                            validas += "Línea " + linea.ToString() + ":S" + "\n";
                            temp = 0;
                            linea++;
                        }
                    }
                    if (strActual != "S") { validas += "Línea " + linea.ToString() + ":ERROR" + "\n"; MessageBox.Show("Semantica incorrecta en la línea: " + linea, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); linea++; }
                }
                if (begins - ends == 0) validas += "Bloque valido";
                else {
                    validas += "Bloque invalido";
                    MessageBox.Show("Bloques invalidos, hay instrucciones compuestas que nunca terminan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                salidas.Add(salida);
                salidas.Add(validas);
                return salidas;

            }
            catch (Exception ex) { MessageBox.Show("Error: Error de semantica en la linea: " + linea +" Los tipos de dato no concuerdan"+ ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  return salidas; }
        }
    }
}


