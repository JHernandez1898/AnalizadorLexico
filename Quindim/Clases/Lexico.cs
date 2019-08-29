using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quindim.Clases
{
    public class Lexico
    {
        public static List<string> AnalizadorLexico(string CadenaEntrada)
        {
            List<string> LineasLexico = new List<string>();
            int linea = 0;
            MetodosAL.CrearMatriz();
            try
            {
                //Anlizador Lexico
                string LineaLexico = "";
                CadenaEntrada = CadenaEntrada.Replace("\n", " \n");
                CadenaEntrada = CadenaEntrada.Insert(CadenaEntrada.Length, " ");
                string[] strLineas = CadenaEntrada.Split('\n');
                foreach (string Linea in strLineas)
                {
                    linea++;
                    
                    List<string> tokens = new List<string>();
                    MetodosAL.ObtenerToken(Linea, ref tokens);
                    if (Linea.Trim() != "")
                    {
                        foreach (string token in tokens) LineaLexico += token +" ";
                        LineasLexico.Add(LineaLexico);
                        LineaLexico = "";
                        
                    }
                }
                Depurar();
                linea = 1;
            }
            catch (Exception ex)
            {
                LineasLexico.Add(ex.Message + linea + ".\nVerifique el uso apropiado del léxico.");
                linea = 1;
            }
            return LineasLexico;
        }

        public static void Depurar()
        {
            MetodosAL.Identificadores.Clear();
            MetodosAL.ConstantesNumericasEnteras.Clear();
            MetodosAL.ConstantesNumericasReales.Clear();
            MetodosAL.ConstantesNumericasExponenciales.Clear();
            MetodosAL.ConstantesNumericasExpReales.Clear();
        }
    }
}
