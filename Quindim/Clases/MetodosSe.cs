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
        public static string ObtenerArchivoTemporal(string Linea) 
        {
           foreach(Identificador elemento in MetodosAL.Identificadores)
            {
                string id = "ID" + elemento.Index;
                Linea = Linea.Replace(id, elemento.Tipo);
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
    }
}
