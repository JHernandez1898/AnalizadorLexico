using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static void PrimeraPasada(List<string> LineasTokens)
        {
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
                        string aver = arreglo1[0].Substring(0, 2);
                        string aver2 = arreglo1[1].Substring(0, 1);
                        if (arreglo1[0].Substring(0, 3) == "TDD" && arreglo1[1].Substring(0, 2) == "ID")
                        {
                            string strIndex1 = arreglo1[1];
                            int index = int.Parse(strIndex1.Replace("ID", ""));
                            Identificador elemento = MetodosAL.Identificadores.Find(x => x.Index == index);
                            MetodosAL.Identificadores.Remove(elemento);
                            switch (arreglo1[0])
                            {
                                case "TDD1":
                                    elemento.Tipo = "int";
                                    break;
                                case "TDD2":
                                    elemento.Tipo = "dbl";
                                    break;
                                case "TDD3":
                                    elemento.Tipo = "str";
                                    break;
                                default:
                                    elemento.Tipo = "chr";
                                    break;
                            }
                            MetodosAL.Identificadores.Add(elemento);
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
