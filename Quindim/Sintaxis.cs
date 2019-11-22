using Quindim.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quindim
{
    class Sintaxis
    {


        public static List<string> AnalisisSintactico(List<string> LineasTokens)
        {
            // SINTAXIS
            int linea = 1;
            string strCambio;
            string strActual = "";
            string salida = "";
            string validacion = "";
            List<string> salidas = new List<string>();
            int temp;
            try
            {
                foreach (string cadena in LineasTokens)
                {
                    strActual = cadena;
                    strActual = strActual.Trim();
                    salida += cadena + "\n";
                    temp = strActual.Split(' ').Length;

                    while (temp > 0)
                    {
                        string[] strSubcadenas = CrearCombinaciones(temp, strActual);
                        //if (!Revisar(strSubcadenas, temp)) temp--;
                        if (MetodosAS.DisminuirTemp(strSubcadenas, temp)) { temp--; }
                        else
                        {
                            foreach (string str in strSubcadenas)
                            {
                                strCambio = NormalizarCadena(str, temp);
                                strActual = strActual.Replace(str, MetodosAS.ObtenerConversion(strCambio));
                            }
                            salida += strActual + "\n";
                            temp = strActual.Split(' ').Length;
                        }
                        if (strActual == "S") { validacion += "Línea " + linea.ToString() + ":S" + "\n"; temp = 0; linea++; }
                    }
                    if (strActual != "S") { validacion += "Línea " + linea.ToString() + ":ERROR" + "\n"; MessageBox.Show("Sintaxis incorrecta en la línea: " + linea); linea++; }
                }
                salidas.Add(salida);
                salidas.Add(validacion);
                return salidas;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Error " + strActual, MessageBoxButtons.OK, MessageBoxIcon.Error); return salidas; }
        }


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
                else NuevaLinea[j] = Elemento.Trim();
            }
            return NuevaLinea;
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
                /*if (d[0].Substring(0, 2) == "ID" && d[0] != "IDEN") { strCambio = "ID"; }
                else if ((d[0] + "  ").Substring(0, 3) == "CNE") { strCambio = "CNE"; }
                else if ((d[0] + " ").Substring(0, 3) == "CNR") { strCambio = "CNR"; }
                else if ((d[0] + " ").Substring(0, 4) == "CNEE") { strCambio = "CNEE"; }
                else if ((d[0] + " ").Substring(0, 4) == "CNRE") { strCambio = "CNRE"; }*/
            }
            return strCambio;
        }

    }
}
