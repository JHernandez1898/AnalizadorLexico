using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Léxico.Clases
{
    class Lexico
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
                MessageBox.Show(ex.Message + linea + ".\nVerifique el uso apropiado del léxico.", "Error de analizador léxico", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
