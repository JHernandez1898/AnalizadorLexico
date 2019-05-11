using System;
using System.Collections.Generic;

namespace Lenguaje_Automatas.cs
{
    public class Lexico
    {
        public static List<string> AnalizadorLexico(string CadenaEntrada)
        {
            List<string> LineasLexico = new List<string>();
            int linea = 0;

            try
            {
                //Stopwatch stopwatch = new Stopwatch();
                //stopwatch.Start();

                //Anlizador Lexico
                string LineaLexico = "";
                //rtxtcodigointermedio.Text = "";
                //string strEntrada = rtxtentrada.Text;
                //txtnumrenglon.Text = linea.ToString();
                string[] strLineas = CadenaEntrada.Split('\n');
                foreach (string Linea in strLineas)
                {
                    linea++;
                    //txtnumrenglon.Text = linea.ToString();
                    List<string> tokens = new List<string>();
                    MetodosAL.ObtenerToken(Linea, ref tokens);
                    if (Linea != "")
                    {
                        foreach (string token in tokens) LineaLexico += token + " ";
                        LineasLexico.Add(LineaLexico);
                        LineaLexico = "";
                        //rtxtcodigointermedio.Text += "\n";
                    }
                    //txtnumrenglon.Text = linea.ToString();
                }
                //MostrarIdentificadoresConstantes();
                Depurar();
                linea = 1;
                //stopwatch.Stop();
                //MessageBox.Show(stopwatch.Elapsed.ToString() + "ms", "Analizador léxico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LineasLexico.Add(ex.Message + linea + ".\nVerifique el uso apropiado del léxico.");
                linea = 1;
            }
            return LineasLexico;
        }

        private static void Depurar()
        {
            MetodosAL.Identificadores.Clear();
            MetodosAL.ConstantesNumericasEnteras.Clear();
            MetodosAL.ConstantesNumericasReales.Clear();
            MetodosAL.ConstantesNumericasExponenciales.Clear();
            MetodosAL.ConstantesNumericasExpReales.Clear();
        }
    }
}
