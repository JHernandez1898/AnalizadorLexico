using Quindim.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace Quindim
{
    public partial class btnOpt4 : Form
    {
        public btnOpt4()
        {
            InitializeComponent();
        }

        private void QuindimPad_Load(object sender, EventArgs e)
        {
            EstablecerConexion();
        }

        #region Conexión
        public void EstablecerConexion()
        {
            //MessageBox.Show("Capture una instancia para la conexion", "Analizador Sintactico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //btnleertodo.Enabled = false;
            //gbLexico.Enabled = false;
            //gbSintax.Enabled = false;
            //btnleertodo.Enabled = false;
            /*lblServidor.Text = "Servidor: " + System.Environment.MachineName;
            lblconexion.BackColor = Color.Red;
            txtServer.Focus();*/
        }

        /*private void BtnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMatriz.ProbarConexion(txtServer.Text))
                {
                    MessageBox.Show("Conectado al servidor", "Lexico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.Enabled = true;
                    //btnleertodo.Enabled = true;
                    MetodosAL.Servidor = txtServer.Text;
                    lblconexion.BackColor = Color.Green;
                    MetodosAS.CrearMatriz();
                    MetodosSe.CrearMatriz();
                    //btnleertodo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Conexion fallida", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnCaracterxCarter.Enabled = false;
                    //btnleertodo.Enabled = false;
                    lblconexion.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        #endregion

        #region General
        public string[] RellenarArreglo()
        {
            string[] ArregloLineas = new string[LineasTokens.Count];
            int i = 0;
            foreach (string strLinea in LineasTokens)
            {
                ArregloLineas[i] = strLinea;
                i++;
            }
            return ArregloLineas;
        }

        private void Btnleertodo_Click(object sender, EventArgs e) { }

        private void MostrarIdentificadoresConstantes()
        {
            dgvIDE.Rows.Clear();
            dgvConstatesNumericasEnteras.Rows.Clear();
            dgvConstatesNumericasReales.Rows.Clear();
            dgvConstantesExpo.Rows.Clear();
            foreach (Identificador IDE in MetodosAL.Identificadores)
                dgvIDE.Rows.Add("ID" + IDE.Index, IDE.Nombre, IDE.Tipo, "");
            foreach (NumericoEntero Num in MetodosAL.ConstantesNumericasEnteras)
                dgvConstatesNumericasEnteras.Rows.Add("CNE" + Num.Index, Num.Contenido);
            foreach (NumericoReal Real in MetodosAL.ConstantesNumericasReales)
                dgvConstatesNumericasReales.Rows.Add("CNR" + Real.Index, Real.Contenido);
            foreach (NumericoExponencial expo in MetodosAL.ConstantesNumericasExponenciales)
                dgvConstantesExpo.Rows.Add("CNEE" + expo.Index, expo.Contenido, expo.Exponencial);
            foreach (NumericoExpReal exporeal in MetodosAL.ConstantesNumericasExpReales)
                dgvConstantesExpo.Rows.Add("CNRE" + exporeal.Index, exporeal.Contenido, exporeal.Exponencial);
            dgvIDE.CurrentCell = null;
            dgvConstatesNumericasEnteras.CurrentCell = null;
            dgvConstatesNumericasReales.CurrentCell = null;
            dgvConstantesExpo.CurrentCell = null;

        }


        private void Rtxtentrada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                LeerTodo();
            }
        }

        public void LeerTodo()
        {
            MetodosAL.Depurar();
            rtxtcodigointermediolexico.Text = "";
            rtxtcodigointermediosintax.Text = "";
            rtxSintaxLineaxLinea.Text = "";
            string entrada = LimpiarEntrada();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                //LEXICO
                List<string> LineasTokens;
                LineasTokens = Lexico.AnalizadorLexico(entrada);
                foreach (String token in LineasTokens)
                {
                    rtxtcodigointermediolexico.Text += token + " ";
                    rtxtcodigointermediolexico.Text += "\n";
                }

                LineasTokens = SustituirMultiplicaciones(LineasTokens);


                //SINTAXIS
                List<string> SintaxResult = Sintaxis.AnalisisSintactico(LineasTokens);
                rtxtcodigointermediosintax.Text = SintaxResult[0];
                rtxSintaxLineaxLinea.Text = SintaxResult[1];


                //SEMANTICA
                List<string> LineasSemantica = MetodosSe.PrimeraPasada(LineasTokens);
                List<string> bottomupSemantica = MetodosSe.SegundaPasada(LineasSemantica);
                rchSemantica.Text = "";
                rchtxtSemantic.Text = "";
                rchSemantica.Text = bottomupSemantica[0];
                rchtxtSemantic.Text = bottomupSemantica[1];

                GenerarTripletas(LineasTokens);
                Optimizacion();



            }
             catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            stopwatch.Stop();
            MessageBox.Show(stopwatch.Elapsed.ToString() + "ms", " Compilacion ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MostrarIdentificadoresConstantes();
            //PostFijo
            List<string> cadenasPostFijo = postFijo(rtxtcodigointermediolexico.Text);
            MostrarPostFijos(cadenasPostFijo);
        }

        private void LeerTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LeerTodo();
        }

        private string LimpiarEntrada()
        {
            return rtxtentrada.Text.Replace("\t", "");
        }

        private void InstanciasSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            this.Hide();
            settings.ShowDialog();
            this.Close();
        }

        private void RUNToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void AbriToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void CargarEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtentrada.Text = "int num\nread num\nint res = Calcfact ( num )\nprint ( res )\nfunction int Calcfact ( int num )\nif ( num == 0 )\nreturn ( 1 )\nend\nelse\nfor ( int x = num to num > 1 step x = x - 1 )\nint R = R * x\nend\nend\nreturn ( R )\nend";
            //rtxtentrada.Text = "int num\n\nint res\nif ( ( num > res & res > 0 ) | ( res > 5 ) )\nend";
        }

        #endregion

        #region Léxico

        static bool principio = true;
        static bool linea = true;
        static List<string> LineasTokens = new List<string>();
        static int nLinea = 0;
        static string strActual = "";
        static int temp = 1;

        private void btnCaracterxCarter_Click(object sender, EventArgs e)
        {

            LineasTokens = Lexico.AnalizadorLexico(rtxtentrada.Text);
            string[] ArregloLineas = RellenarArreglo();
            if (principio)
            {
                principio = false;
                rtxtcodigointermediolexico.Text = "";
                rtxSintaxLineaxLinea.Text = "";
            }
            if (linea)
            {
                linea = false;
                strActual = RellenarArreglo()[nLinea];
                strActual = strActual.Substring(0, strActual.Length - 1);
                rtxtcodigointermediolexico.Text += ArregloLineas[nLinea] + "\n";
                txtcadenatokens.Text = ArregloLineas[nLinea];

                temp = strActual.Split(' ').Length;
            }
            txtTemporal.Text = temp.ToString();
            if (temp == 0) { MessageBox.Show("Error de sintaxis en línea " + (nLinea + 1)); nLinea = 0; principio = true; rtxtcodigointermediolexico.Text = " "; }
            else
            {
                string[] strSubcadenas = Sintaxis.CrearCombinaciones(temp, strActual);
                if (MetodosAS.DisminuirTemp(strSubcadenas, temp)) { txtTemporal.Text = temp.ToString(); temp--; }

                else
                {
                    foreach (string str in strSubcadenas)
                    {
                        string strCambio = "";

                        strCambio = Sintaxis.NormalizarCadena(str, temp);
                        strActual = strActual.Replace(str, MetodosAS.ObtenerConversion(strCambio));

                    }
                    rtxtcodigointermediolexico.Text += strActual + "\n";
                    temp = strActual.Split(' ').Length;

                }
                txtcadenatokens.Text = strActual;

                if (strActual == "S") { nLinea++; linea = true; rtxSintaxLineaxLinea.Text += "Línea " + nLinea.ToString() + ":S" + "\n"; }
            }
            if (LineasTokens.Count <= nLinea) { nLinea = 0; principio = true; }

        }



        static int indx = 0;
        static int palabra = 0;
        static int intEstadoActual = 0;
        static int lineax = 1;
        static List<char> caracteres = new List<char>();


        private void BtnCaracterxCarter_Click_1(object sender, EventArgs e)
        {
            try
            {
                string strEntrada = rtxtentrada.Text;
                if (indx == 0)
                {
                    Lexico.Depurar();
                    rtxtcodigointermediolexico.Text = "";
                }
                strEntrada = strEntrada.Replace('\n', ' ');
                string[] strPalabras = strEntrada.Split(' ');
                strEntrada = rtxtentrada.Text;
                List<string> tokens = new List<string>();
                txtSubcadena.Text = strPalabras[palabra];//Mostrar la subcadena actual
                string palabraActual = strPalabras[palabra];
                bool bandera = false;
                if (strEntrada.Length > indx)
                {
                    char c = strEntrada[indx];
                    caracteres.Add(c);
                    if (c != '\n')
                    {
                        txtEstadoAnt.Text = intEstadoActual.ToString();
                        txtCaracter.Text = c.ToString();
                        txtnumrenglon.Text = linea.ToString();
                        intEstadoActual = MetodosAL.NuevoEstado(c, intEstadoActual, ref bandera);
                        if (bandera)
                        {
                            string tokn = MetodosAL.ObtenerToken(intEstadoActual, caracteres);
                            tokens.Add(tokn);
                            txttoken.Text = tokn;
                            foreach (string tkn in tokens) txtcadenatokens.Text += tkn + " "; //Muestro la cadena de tokens
                            intEstadoActual = 0;
                            palabra++; //Avanzo a la siguiente palabra
                            bandera = false;
                            caracteres.Clear();
                        }
                        txtEstadoActual.Text = intEstadoActual.ToString();
                    }
                    else
                    {
                        lineax++;
                        CambiarEstado(' ', ref bandera, ref tokens);
                        palabra++;
                    }
                    indx++;
                }
                else
                {
                    CambiarEstado(' ', ref bandera, ref tokens);
                    indx = 0;
                    palabra = 0;
                    lineax = 1;
                }
                MostrarIdentificadoresConstantes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + lineax + ".\nVerifique el uso apropiado del léxico, y el caracter actual.", "Error de analizador léxico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CambiarEstado(char c, ref bool bandera, ref List<string> tokens)
        {
            txtEstadoAnt.Text = intEstadoActual.ToString();
            intEstadoActual = MetodosAL.NuevoEstado(' ', intEstadoActual, ref bandera);
            txtEstadoActual.Text = intEstadoActual.ToString();
            string tokn = MetodosAL.ObtenerToken(intEstadoActual, caracteres);
            tokens.Add(tokn);
            txttoken.Text = tokn;
            foreach (string tkn in tokens) txtcadenatokens.Text += tkn + " "; //Muestro la cadena de tokens
            rtxtcodigointermediolexico.Text += txtcadenatokens.Text + "\n";
            txtcadenatokens.Text = "";
            caracteres.Clear();
            intEstadoActual = 0;
        }

        #endregion

        #region Sintáctico
        private void BtnLineaxLinea_Click(object sender, EventArgs e)
        {
            rtxtcodigointermediolexico.Text = "";
            LineasTokens = Lexico.AnalizadorLexico(rtxtentrada.Text);
            foreach (String token in LineasTokens)
            {
                rtxtcodigointermediolexico.Text += token + " ";
                rtxtcodigointermediolexico.Text += "\n";
            }
            MostrarIdentificadoresConstantes();
            string[] ArregloLineas = RellenarArreglo();
            if (principio)
            {
                principio = false;
                rtxtcodigointermediosintax.Text = "";
                rtxSintaxLineaxLinea.Text = "";
            }
            if (linea)
            {
                linea = false;
                strActual = RellenarArreglo()[nLinea];
                strActual = strActual.Substring(0, strActual.Length - 1);
                rtxtcodigointermediosintax.Text += ArregloLineas[nLinea] + "\n";
                tokenSintax.Text = ArregloLineas[nLinea];

                temp = strActual.Split(' ').Length;
            }
            txtTemporal.Text = temp.ToString();
            if (temp == 0) { MessageBox.Show("Error de sintaxis en línea " + (nLinea + 1)); nLinea = 0; principio = true; rtxtcodigointermediosintax.Text = " "; }
            else
            {
                string[] strSubcadenas = Sintaxis.CrearCombinaciones(temp, strActual);
                if (MetodosAS.DisminuirTemp(strSubcadenas, temp)) { txtTemporal.Text = temp.ToString(); temp--; }

                else
                {
                    foreach (string str in strSubcadenas)
                    {
                        string strCambio = "";

                        strCambio = Sintaxis.NormalizarCadena(str, temp);
                        strActual = strActual.Replace(str, MetodosAS.ObtenerConversion(strCambio));

                    }
                    rtxtcodigointermediosintax.Text += strActual + "\n";
                    temp = strActual.Split(' ').Length;

                }
                tokenSintax.Text = strActual;

                if (strActual == "S") { nLinea++; linea = true; rtxSintaxLineaxLinea.Text += "Línea " + nLinea.ToString() + ":S" + "\n"; }
            }
            if (LineasTokens.Count <= nLinea) { nLinea = 0; principio = true; }
        }
        #endregion

        #region Semántico

        public string[] RellenarArregloSemantica()
        {
            string[] ArregloLineas = new string[LineasTokensSmt.Count];
            int i = 0;
            foreach (string strLinea in LineasTokensSmt)
            {
                ArregloLineas[i] = strLinea;
                i++;
            }
            return ArregloLineas;
        }

        private void btnPrimeraPasada_Click(object sender, EventArgs e)
        {
            rchSemantica.Text = "";
            rchtxtSemantic.Text = "";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<string> LineasTokens = Lexico.AnalizadorLexico(rtxtentrada.Text);
            try
            {
                foreach (string cadena in LineasTokens)
                {
                    strActual = cadena;
                    strActual = strActual.Substring(0, strActual.Length - 1);
                    string[] combinacionesde2 = Sintaxis.CrearCombinaciones(2, strActual);
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
                                default:
                                    elemento.Tipo = "BOOL";
                                    break;
                            }
                            MetodosAL.Identificadores.Add(elemento);

                        }

                    }
                }
                foreach (string d in LineasTokens)
                {
                    rchSemantica.Text += MetodosSe.ObtenerArchivoTemporal(d) + "\n";
                }
                MostrarIdentificadoresConstantes();
                stopwatch.Stop();
                MessageBox.Show(stopwatch.Elapsed.ToString() + "ms", "Primera Pasada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SegundaPasada_Click(object sender, EventArgs e)
        {
            rchSemantica.Text = "";
            rchtxtSemantic.Text = "";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<string> LineasTokens = Lexico.AnalizadorLexico(rtxtentrada.Text);
            List<string> LineasSemantica = MetodosSe.PrimeraPasada(LineasTokens);
            int linea = 1;
            string strCambio;
            string strActual;
            int temp;
            MetodosSe.CrearMatriz();
            try
            {
                foreach (string cadena in LineasSemantica)
                {
                    strActual = cadena;
                    strActual = strActual.Substring(0, strActual.Length - 1);
                    rchSemantica.Text += cadena + "\n";
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
                            rchSemantica.Text += strActual + "\n";
                            temp = strActual.Split(' ').Length;
                        }
                        if (strActual == "S") { rchtxtSemantic.Text += "Línea " + linea.ToString() + ":S" + "\n"; temp = 0; linea++; }
                    }
                    if (strActual != "S") { rchtxtSemantic.Text += "Línea " + linea.ToString() + ":ERROR" + "\n"; MessageBox.Show("Semantica incorrecta en la línea: " + linea); linea++; }
                }

            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }


        }

        private void BtnTerceraPasada_Click(object sender, EventArgs e)
        {
            rchSemantica.Text = "";
            rchtxtSemantic.Text = "";
            List<string> LineasTokens = Lexico.AnalizadorLexico(rtxtentrada.Text);
            List<string> LineasSemantica = MetodosSe.PrimeraPasada(LineasTokens);
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
                    strActual = strActual.Substring(0, strActual.Length - 1);
                    rchSemantica.Text += cadena + "\n";
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
                            rchSemantica.Text += strActual + "\n";
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
                            rchtxtSemantic.Text += "Línea " + linea.ToString() + ":S" + "\n";
                            temp = 0;
                            linea++;
                        }
                    }
                    if (strActual != "S") { rchtxtSemantic.Text += "Línea " + linea.ToString() + ":ERROR" + "\n"; MessageBox.Show("Semantica incorrecta en la línea: " + linea); linea++; }
                }
                if (begins - ends == 0) rchtxtSemantic.Text += "Bloque valido";
                else rchtxtSemantic.Text += "Bloque invalido";

            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        static bool principioSmt = true;
        static bool lineaSmt = true;
        static int nLineaSmt = 0;
        static string strActualSmt = "";
        static int tempSmt = 1;
        static List<char> caracteresSmt = new List<char>();
        List<string> LineasTokensSmt = new List<string>();

        private void LineaLineaSemantico_Click(object sender, EventArgs e)
        {
            LineasTokens = Lexico.AnalizadorLexico(rtxtentrada.Text);
            LineasTokensSmt = MetodosSe.PrimeraPasada(LineasTokens);
            MostrarIdentificadoresConstantes();
            string[] ArregloLineas = RellenarArregloSemantica();
            if (principioSmt)
            {
                principioSmt = false;
                rchSemantica.Text = "";
                rchtxtSemantic.Text = "";
            }
            if (lineaSmt)
            {
                lineaSmt = false;
                strActualSmt = RellenarArregloSemantica()[nLineaSmt];
                strActualSmt = strActualSmt.Substring(0, strActualSmt.Length - 1);
                rchSemantica.Text += ArregloLineas[nLineaSmt] + "\n";
                tokenSemantica.Text = ArregloLineas[nLineaSmt];
                tempSmt = strActualSmt.Split(' ').Length;
            }
            txtTemporalSemantica.Text = tempSmt.ToString();
            if (tempSmt == 0) { MessageBox.Show("Error de semántica en línea " + (nLineaSmt + 1)); nLineaSmt = 0; principioSmt = true; rchSemantica.Text = " "; }
            else
            {
                string[] strSubcadenas = MetodosSe.CrearCombinaciones(tempSmt, strActualSmt);
                if (MetodosSe.DisminuirTemp(strSubcadenas, tempSmt)) { txtTemporalSemantica.Text = tempSmt.ToString(); tempSmt--; }
                else
                {
                    foreach (string str in strSubcadenas)
                    {
                        string strCambio = "";
                        strCambio = MetodosSe.NormalizarCadena(str, tempSmt);
                        strActualSmt = strActualSmt.Replace(str, MetodosSe.ObtenerConversion(strCambio));
                    }
                    rchSemantica.Text += strActualSmt + "\n";
                    tempSmt = strActualSmt.Split(' ').Length;
                }
                tokenSemantica.Text = strActualSmt;
                if (strActualSmt == "S") { nLineaSmt++; lineaSmt = true; rchtxtSemantic.Text += "Línea " + nLineaSmt.ToString() + ":S" + "\n"; }
            }
            if (LineasTokensSmt.Count <= nLineaSmt) { nLineaSmt = 0; principioSmt = true; }
        }
        #endregion

        #region Código intermedio

        #region Postfijo
        List<string> postFijo(string strTokens)
        {
            List<string> loQueSeRegresa = new List<string>();
            var lineas = strTokens.Split('\n');
            string tempLinea = "";
            foreach (string linea in lineas)
            {
                var Tokens = linea.Split(' ');
                bool banderaNumero = false;
                bool banderaIdentificador = false;
                bool bandera = false;
                string tokenIdentificador = "";
                foreach (string token in Tokens)
                {
                    if (bandera)
                        tempLinea += token + ' ';
                    else if (banderaIdentificador)
                    {
                        if (token.Contains("OP"))
                        {
                            if (token.Contains("OPA") || token.Contains("OPR") || token.Contains("OL0"))
                            {
                                tempLinea += tokenIdentificador + ' ' + token + ' ';
                                bandera = true;
                            }
                            else
                                banderaIdentificador = false;
                        }
                        else
                            banderaIdentificador = false;
                    }
                    else if (banderaNumero)
                    {
                        if (token.Contains("OPA") || token.Contains("OPR") || token.Contains("OL0"))
                        {
                            tempLinea += token + ' ';
                            bandera = true;
                        }
                    }
                    else if (token.Contains("CNE") || token.Contains("CNR"))
                    {
                        banderaNumero = true;
                        tempLinea += token + ' ';
                    }
                    else if (token.Contains("ID") || token.Contains("CN"))
                    {
                        banderaIdentificador = true;
                        tokenIdentificador = token;
                    }
                }
                if (tempLinea != "")
                {
                    tempLinea.Remove(tempLinea.Length - 1);
                    bandera = false;
                    banderaNumero = false;
                    banderaIdentificador = false;
                    loQueSeRegresa.Add(Reordenar(tempLinea));
                }
                tempLinea = "";
            }
            return loQueSeRegresa;
        }

        int jerarquiaOperador(String operador)
        {
            switch (operador)
            {
                case "OPA3": // ^
                    return 8;
                case "OPA1":// *                                                  
                case "OPA2":// /
                    return 7;
                case "OPA4": // +                                              
                case "OPA5": // -
                    return 6;
                case "OPR5": // == 
                case "OPR4": // <=                 
                case "OPR6": // !=  
                case "OPR3": // <                    
                case "OPR2": // >=                    
                case "OPR1": // >
                    return 5;
                case "OL03": // !
                    return 4;
                case "OL01": // &
                    return 2;
                case "OL02": // |
                    return 3;
                case "OPA6": // =
                    return 1;
                default:
                    return 0;
            }
        }

        Stack<string> pilaTokensLogicos = new Stack<string>();
        string Reordenar(string strCadenaTokens)
        {
            Stack<string> pilaTokens = new Stack<string>();
            string[] cadenaTokens = strCadenaTokens.Split(' ');
            string strNumeritos = "";
            int operador1 = 0;
            int operador2 = 0;
            int contadorRelacional = 0;
            int contadorParentesis = 0;
            string subCadenaParentesis = "";
            bool banderaParentesis = false;

            foreach (string token in cadenaTokens)
            {
                if (banderaParentesis)
                {
                    if (token.Contains("PAR2"))
                    {
                        contadorParentesis--;
                        if (contadorParentesis == 0)
                        {
                            subCadenaParentesis = subCadenaParentesis.Remove(subCadenaParentesis.Length - 1);
                            strNumeritos += Reordenar(subCadenaParentesis) + " ";
                            subCadenaParentesis = "";
                            banderaParentesis = false;
                        }
                    }
                    else if (token.Contains("PAR1"))
                        contadorParentesis++;
                    else
                        subCadenaParentesis += token + ' ';
                }
                else
                {
                    if (token.Contains("CNE") || token.Contains("CNR") || token.Contains("ID"))
                        strNumeritos += token + " ";
                    if (token.Contains("OPA") || token.Contains("OPR") || token.Contains("OL0"))
                    {
                        if (token.Contains("OPR"))
                            contadorRelacional++;
                        if (operador1 == 0)
                        {
                            operador1 = jerarquiaOperador(token);
                            pilaTokens.Push(token);
                        }
                        else
                        {
                            operador2 = jerarquiaOperador(token);
                            if (operador1 < operador2)
                            {
                                if (operador1 < 4 && contadorRelacional > 1)
                                {
                                    string tokenDePila = pilaTokens.Pop();
                                    pilaTokens.Push(token + " " + tokenDePila);
                                    operador1 = operador2;
                                }
                                else
                                    pilaTokens.Push(token);
                                operador1 = operador2;
                            }
                            else if (operador2 < operador1)
                            {
                                string tokenDePila = pilaTokens.Pop();
                                operador1 = operador2;
                                pilaTokens.Push(token);
                                strNumeritos += tokenDePila + " ";
                            }
                            else if (operador2 == operador1)
                            {
                                strNumeritos += pilaTokens.Pop() + " ";
                                pilaTokens.Push(token);
                            }
                        }
                    }

                    if (token.Contains("PAR1"))
                    {
                        contadorParentesis++;
                        banderaParentesis = true;
                    }
                }
            }
            foreach (string operadorEnPila in pilaTokens)
            {
                strNumeritos += operadorEnPila + ' ';
            }
            return strNumeritos.Remove(strNumeritos.Length - 1);
        }

        void MostrarPostFijos(List<string> lineas)
        {
            rtxtPostFijos.Text = "";
            foreach (string linea in lineas)
            {
                rtxtPostFijos.Text += linea + "\n";
            }
        }

        #endregion

        #region Tripletas
        public void Optimizacion()
        {
            string Tripleta = "";
            int renglon = 0;
            int renglonesEnTripleta = 0;
            int valordeT = 0;
            int valordeTRemplazador = 0;
            bool coincidencia = false;

            List<int> listaReemplazables = new List<int>();
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (!coincidencia)
                {
                    string nuevaLinea;
                    if (dr.Cells[1].Value.ToString().Substring(0, 1) == "T")
                    {
                        valordeT = int.Parse(dr.Cells[1].Value.ToString().Split('T')[1]);
                    }
                    nuevaLinea = renglon.ToString() + ':' + dr.Cells[1].Value.ToString() + 'x' + dr.Cells[2].Value.ToString() + 'x' + dr.Cells[3].Value.ToString() + '\n';
                    string lineaoperacion = dr.Cells[2].Value.ToString() + 'x' + dr.Cells[3].Value.ToString();
                    if (Tripleta.Contains(lineaoperacion))
                    {
                        if (renglon + 1 < dataGridView1.Rows.Count)
                        {
                            DataGridViewRow dr2 = dataGridView1.Rows[renglon + 1];
                            string linea2 = dr2.Cells[2].Value.ToString() + 'x' + dr2.Cells[3].Value.ToString();
                            if (Tripleta.Contains(linea2))
                            {
                                for (int x = 0; x < renglonesEnTripleta; x++)
                                {
                                    if (x + 1 < renglonesEnTripleta)
                                    {
                                        if (Tripleta.Split('\n')[x].Contains(lineaoperacion) && Tripleta.Split('\n')[x + 1].Contains(linea2))
                                        {


                                            valordeTRemplazador = int.Parse(Tripleta.Split('\n')[x].Split(':')[1].Split('x')[0].Replace("T", string.Empty).Trim());
                                            listaReemplazables.Add(valordeTRemplazador);
                                            listaReemplazables.Add(valordeT);
                                            coincidencia = true;


                                        }
                                    }
                                }
                                if (!coincidencia)
                                {
                                    Tripleta += nuevaLinea;
                                    renglonesEnTripleta++;
                                }

                            }
                            else
                            {
                                Tripleta += nuevaLinea;
                                renglonesEnTripleta++;
                            }
                        }
                    }
                    else
                    {
                        Tripleta += nuevaLinea;
                        renglonesEnTripleta++;
                    }
                    renglon++;

                }
                else { coincidencia = false; renglon++; }
            }

            dataGridView1.Rows.Clear();
            for (int x = 0; x < listaReemplazables.Count; x += 2)
            {
                string Remplazador = 'T' + listaReemplazables[x].ToString();
                string Remplazado = 'T' + listaReemplazables[x + 1].ToString();
                Tripleta = Tripleta.Replace(Remplazado, Remplazador);
            }
            for (int x = 0; x < renglonesEnTripleta; x++)
            {
                string dobjeto = Tripleta.Split('\n')[x].Split(':')[1].Split('x')[0];
                string dfuente = Tripleta.Split('\n')[x].Split(':')[1].Split('x')[1];
                string operador = Tripleta.Split('\n')[x].Split(':')[1].Split('x')[2];

                dataGridView1.Rows.Add(x + 1, dobjeto, dfuente, operador);
            }
            dataGridView1.Rows.Add(renglonesEnTripleta + 1, "FIN");
            //RASTREO 3 OPTIMIZACION
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (!coincidencia)
                {
                    string nuevaLinea;
                    if (dr.Cells[1].Value.ToString().Substring(0, 1) == "T")
                    {
                        valordeT = int.Parse(dr.Cells[1].Value.ToString().Split('T')[1]);
                    }
                    nuevaLinea = dr.Cells[1].Value.ToString() + 'x' + dr.Cells[2].Value.ToString() + 'x' + dr.Cells[3].Value.ToString() + '\n';
                    string datofuente = dr.Cells[2].Value.ToString() + 'x';
                    if (Tripleta.Contains(datofuente))
                    {
                        if (renglon + 1 < dataGridView1.Rows.Count)
                        {
                            DataGridViewRow dr2 = dataGridView1.Rows[renglon + 1];
                            string linea2 = dr2.Cells[2].Value.ToString() + 'x' + dr2.Cells[3].Value.ToString();
                            if (Tripleta.Contains(linea2))
                            {
                                for (int x = 0; x < renglonesEnTripleta; x++)
                                {
                                    if (x + 1 < renglonesEnTripleta)
                                    {
                                        string compdatofuente = (Tripleta.Split('\n')[x].Split('x')[1]);

                                        string compoperacio = Tripleta.Split('\n')[x + 1].Split('x')[1] + 'x' + Tripleta.Split('\n')[x + 1].Split('x')[2];
                                        if (compdatofuente.Contains(datofuente) && compoperacio.Contains(linea2))
                                        {
                                            valordeTRemplazador = int.Parse(Tripleta.Split('\n')[x].Split(':')[1].Split('x')[0].Replace("T", string.Empty).Trim());
                                            listaReemplazables.Add(valordeTRemplazador);
                                            listaReemplazables.Add(valordeT);
                                            coincidencia = true;
                                        }
                                    }
                                }
                                if (!coincidencia)
                                {
                                    Tripleta += nuevaLinea;
                                    renglonesEnTripleta++;
                                }
                            }
                            else
                            {
                                Tripleta += nuevaLinea;
                                renglonesEnTripleta++;
                            }
                        }
                    }
                    else
                    {
                        Tripleta += nuevaLinea;
                        renglonesEnTripleta++;
                    }
                    renglon++;

                }
                else { coincidencia = false; renglon++; }
            }



        }
        public void GenerarTripletas( List<string> lineas)
        {
            DataTable Tripleta = GenerarTabla();
            string entrada = LimpiarEntrada();
            List<string> LineasTokens = lineas;
            int T = 1;
            string postFijoIncremento = "";
            bool banderafor = false;
            bool banderafunc = false;
            bool condicion = false;
            foreach (string Linea in LineasTokens)
            {
                //string LineaActual = Linea.Substring(0, Linea.Length - 1); JULIOOOOOOOOO POR QUEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
                string LineaActual = Linea.Trim();
                string[] Tokens = MetodosSe.CrearCombinaciones(1, LineaActual);
                string LineaPostFijo = "";


                switch (Tokens[0])
                {
                    case string strValue when strValue.Substring(0, 3) == "TDD" || strValue.Substring(0, 2) == "ID":
                        if (Tokens.Length == 2)
                        {
                            Tripleta.Rows.Add("T" + T.ToString(), Tokens[1], "OPA6");
                            T++;
                        }
                        else
                        {
                            string metodo = "";
                            bool Metodo = RevisarMetodo(LineaActual, ref metodo);
                            if (Metodo)
                            {
                                Tripleta.Rows.Add("T" + T.ToString(), Tokens[1], "OPA6");
                                Tripleta.Rows.Add("T" + T.ToString(), "TR" + metodo, "OPA6");
                                T++;
                            }
                            else
                            {
                                postFijo(LineaActual).ForEach(delegate (string pf) { LineaPostFijo = pf; });
                                TripletaOperacionesAritmeticas(ref Tripleta, LineaPostFijo, ref T);
                            }
                        }
                        break;
                    case "PR08":
                        postFijo(LineaActual).ForEach(delegate (string pf) { LineaPostFijo = pf; });
                        TripletaCondicional(ref Tripleta, LineaPostFijo, ref T);
                        condicion = true;
                        break;
                    case "PR21":
                        if (!banderafor && !condicion && banderafunc)
                        {
                            Tripleta.Rows.Add("ENDP", "", "-");
                            banderafunc = false;
                        }
                        else if (banderafor)
                        {
                            TripletaOperacionesAritmeticas(ref Tripleta, postFijoIncremento, ref T);
                            banderafor = false;
                        }
                        else if (condicion) condicion = false;

                        CerrarFalse(ref Tripleta, "");
                        break;
                    case "PR05":
                        condicion = true;
                        break;
                    case "PR06":
                        string LineaInicializacion = $"{Tokens[2]} {Tokens[3]} {Tokens[4]} {Tokens[5]}";
                        string LineaComparacion = $"{Tokens[7]} {Tokens[8]} {Tokens[9]}";
                        string LineaIncremento = $"{Tokens[11]} {Tokens[12]} {Tokens[13]} {Tokens[14]} {Tokens[15]}";
                        postFijo(LineaInicializacion).ForEach(delegate (string pf) { LineaPostFijo = pf; });
                        TripletaOperacionesAritmeticas(ref Tripleta, LineaPostFijo, ref T);
                        postFijo(LineaComparacion).ForEach(delegate (string pf) { LineaPostFijo = pf; });
                        TripletaCondicional(ref Tripleta, LineaPostFijo, ref T);
                        postFijo(LineaIncremento).ForEach(delegate (string pf) { postFijoIncremento = pf; });
                        banderafor = true;
                        break;
                    case "PR07":
                        Tripleta.Rows.Add("FUNC", "TR" + Tokens[2], "-");
                        inicializarParametros(ref Tripleta, Tokens, ref T);
                        banderafunc = true;
                        break;
                    case "PR11":
                        Tripleta.Rows.Add("PROC", "TR" + Tokens[2], "-");
                        inicializarParametros(ref Tripleta, Tokens, ref T);
                        banderafunc = true;
                        break;
                    default:
                        TripletaOtrasPalabras(ref Tripleta, LineaActual);
                        banderafunc = true;
                        break;
                }
            }
            Tripleta.Rows.Add("FIN", "", "");
            dataGridView1.Rows.Clear();
            int num = 0;
            Tripleta = OptimizacionDeMirilla(Tripleta);
            foreach (DataRow s in Tripleta.Rows)
            {
                num++;
                dataGridView1.Rows.Add(num, s.ItemArray[0], s.ItemArray[1], s.ItemArray[2]);
            }


        }

        private void GenerarTripleta_Click(object sender, EventArgs e)
        {
            DataTable Tripleta = GenerarTabla();
            List<string> LineasTokens = Lexico.AnalizadorLexico(rtxtentrada.Text);
            int T = 0;
            string postFijoIncremento = "";
            bool banderafor = false;
            bool banderafunc = false;
            foreach (string Linea in LineasTokens)
            {
                string LineaActual = Linea.Substring(0, Linea.Length - 1);
                string[] Tokens = MetodosSe.CrearCombinaciones(1, LineaActual);
                string LineaPostFijo = "";

                //TOKEN[0]  PALABRA RESERVADA,  IDENTIFICADOR, TIPO DE DATO
                switch (Tokens[0])
                {
                    case string strValue when strValue.Substring(0, 3) == "TDD" || strValue.Substring(0, 2) == "ID":
                        //SI HAY 2 TOKENS ES UNA DECLARACION DE UN IDENTIFICADOR
                        if (Tokens.Length == 2) { Tripleta.Rows.Add("T" + T.ToString(), Tokens[1], "OPR6"); T++; }
                        //SI NO ES UNA ASIGNACION
                        else
                        {
                            string metodo = "";
                            //ASIGNACION DE METODOS ?
                            bool Metodo = RevisarMetodo(LineaActual, ref metodo);
                            if (Metodo)
                            {
                                Tripleta.Rows.Add("T" + T.ToString(), Tokens[1], "OPR6");
                                T++;
                                Tripleta.Rows.Add(Tokens[1], "TR" + metodo, "OPR6");
                            }
                            else
                            {
                                postFijo(LineaActual).ForEach(delegate (string pf) { LineaPostFijo = pf; });
                                TripletaOperacionesAritmeticas(ref Tripleta, LineaPostFijo, ref T);
                            }
                        }
                        break;
                    case "PR08":
                        postFijo(LineaActual).ForEach(delegate (string pf) { LineaPostFijo = pf; });
                        TripletaCondicional(ref Tripleta, LineaPostFijo, ref T);
                        break;
                    case "PR21":
                        if (banderafor)
                        {
                            TripletaOperacionesAritmeticas(ref Tripleta, postFijoIncremento, ref T);
                            banderafor = false;
                        }
                        else if (banderafunc)
                        {

                        }
                        CerrarFalse(ref Tripleta, "");
                        break;
                    case "PR05":
                        break;
                    case "PR06":
                        string LineaInicializacion = $"{Tokens[2]} {Tokens[3]} {Tokens[4]} {Tokens[5]}";
                        string LineaComparacion = $"{Tokens[7]} {Tokens[8]} {Tokens[9]}";
                        string LineaIncremento = $"{Tokens[11]} {Tokens[12]} {Tokens[13]} {Tokens[14]} {Tokens[15]}";
                        postFijo(LineaInicializacion).ForEach(delegate (string pf) { LineaPostFijo = pf; });
                        TripletaOperacionesAritmeticas(ref Tripleta, LineaPostFijo, ref T);
                        postFijo(LineaComparacion).ForEach(delegate (string pf) { LineaPostFijo = pf; });
                        TripletaCondicional(ref Tripleta, LineaPostFijo, ref T);
                        postFijo(LineaIncremento).ForEach(delegate (string pf) { postFijoIncremento = pf; });
                        banderafor = true;
                        break;
                    case "PR07":
                        Tripleta.Rows.Add("PROC", "TR" + Tokens[2], "num");

                        break;
                    default:
                        TripletaOtrasPalabras(ref Tripleta, LineaActual);
                        banderafunc = true;
                        break;
                }
            }
            Tripleta.Rows.Add("FIN", "", "");
            dataGridView1.Rows.Clear();
            int num = 0;
            foreach (DataRow s in Tripleta.Rows)
            {
                num++;
                dataGridView1.Rows.Add(num, s.ItemArray[0], s.ItemArray[1], s.ItemArray[2]);
            }
        }

        bool RevisarMetodo(string Linea, ref string Metodo)
        {
            bool hayUnMetodo = false;
            string[] CombinacionesdeDos = MetodosSe.CrearCombinaciones(2, Linea);
            foreach (string s in CombinacionesdeDos)
            {
                string[] idpar = s.Split(' ');
                if (idpar[0]?.Substring(0, 2) == "ID" && idpar[1] == "PAR1")
                {
                    Metodo = idpar[0];
                    hayUnMetodo = true;
                }
            }
            return hayUnMetodo;
        }

        void inicializarParametros(ref DataTable Tripleta, string[] tokens, ref int t)
        {
            int control = 0;
            List<string> paramestros = new List<string>();
            for (int i = 0; i <= tokens.Length; i++)
            {
                if (tokens[i] == "PAR1")
                {
                    control = i + 1;
                    for (int j = 0; j <= tokens.Length - i; j++)
                    {
                        if (tokens[control] != "PAR2")
                        {
                            paramestros.Add(tokens[control]);
                            control++;
                        }
                        else break;
                    }
                    break;
                }
            }
            for (int h = 0; h < paramestros.Count; h++)
            {
                if (paramestros[h].Substring(0, 3) != "TDD")
                {
                    Tripleta.Rows.Add("T" + t.ToString(), paramestros[h], "OPA6");
                    t++;
                }
            }

        }

        void TripletaOtrasPalabras(ref DataTable Tripleta, string Linea)
        {
            Linea = Linea.Replace("PAR1", "");
            Linea = Linea.Replace("PAR2", "");
            string[] Tokens = Linea.Split(' ');
            for (int i = 0; i < Tokens.Length - 1; i++)
            {
                Tokens[i] = Tokens[i].Trim();
                if (Tokens[i] == "")
                {
                    string s = Tokens[i];
                    Tokens[i] = Tokens[i + 1];
                    Tokens[i + 1] = s;
                }
            }

            string temp = "";
            foreach (DataRow s in Tripleta.Rows) if (s.ItemArray[1].ToString() == Tokens[1]) temp = s.ItemArray[0].ToString();
            Tripleta.Rows.Add("", Tokens[1], Tokens[0]);

        }
        static void CerrarFalse(ref DataTable Tripleta, string OpLog)
        {
            DataTable nueva = GenerarTabla();
            foreach (DataRow s in Tripleta.Rows)
            {
                if (s.ItemArray[2].ToString() == "")
                {
                    DataRow dataRow = s;
                    switch (OpLog)
                    {
                        case "OL01":
                            nueva.Rows.Add(dataRow.ItemArray[0], dataRow.ItemArray[1], (Tripleta.Rows.Count) + 2);
                            break;
                        case "OL02":
                            nueva.Rows.Add(dataRow.ItemArray[0], dataRow.ItemArray[1], (Tripleta.Rows.Count));
                            break;
                        default:
                            nueva.Rows.Add(dataRow.ItemArray[0], dataRow.ItemArray[1], (Tripleta.Rows.Count) + 1);
                            break;
                    }

                }
                else nueva.Rows.Add(s.ItemArray[0], s.ItemArray[1], s.ItemArray[2]); //podria  poner solo la s pero por alguna razon no jala
            }
            Tripleta = nueva;
        }
        void TripletaCondicional(ref DataTable Tripleta, string postfijo, ref int T)
        {

            string[] pf = postfijo.Split(' ');
            Stack<string> OperadoresLogicos = ConseguirOperadores(pf, ref postfijo);
            string strPostfijoTemporal = postfijo;
            pf = postfijo.Split(' ');
            while (pf.Length >= 3)
            {
                int c = 0;
                string remplazo = "";
                foreach (string Token in pf)
                {

                    if (Token.Substring(0, 1) == "O")
                    {
                        remplazo = CrearRenglonesCondicional(ref Tripleta, pf, c, ref T, ref OperadoresLogicos);
                        break;
                    }
                    c++;
                }
                if (remplazo != "") strPostfijoTemporal = strPostfijoTemporal.Replace(remplazo, "T" + (T - 1));
                else strPostfijoTemporal = "T0";
                pf = strPostfijoTemporal.Split(' ');
            }
            //CrearRenglonesCondicional(ref Tripleta, pf, 2, ref T, ref OperadoresLogicos);
        }
        Stack<string> ConseguirOperadores(string[] Postfijo, ref string strPostfijo)
        {
            int c = 0;
            Stack<string> OperadoresLogicos = new Stack<string>();
            foreach (string operador in Postfijo)
            {
                if (operador.Substring(0, 3) == "OL0")
                {
                    c++;
                    OperadoresLogicos.Push(operador);
                    strPostfijo = strPostfijo.Replace(operador, "");

                }
            }
            strPostfijo = strPostfijo.Substring(0, strPostfijo.Length - c);
            return OperadoresLogicos;
        }
        static string operador = "";
        static string CrearRenglonesCondicional(ref DataTable trip, string[] pf, int c, ref int T, ref Stack<string> Operadores)
        {
            string temp = "";
            foreach (DataRow s in trip.Rows) if (s.ItemArray[1].ToString() == pf[c - 2] && s.ItemArray[0].ToString() != "") temp = s.ItemArray[0].ToString();
            trip.Rows.Add("T" + T, pf[c - 1], "OPA6");
            trip.Rows.Add(temp, "T" + T, pf[c]);

            if (Operadores.Count != 0)
            {

                operador = Operadores.Pop();
                switch (operador)
                {
                    case "OL02":

                        trip.Rows.Add("TR" + T, "FALSE", (trip.Rows.Count) + 3);
                        trip.Rows.Add("TR" + T, "TRUE", "");

                        break;
                    default:
                        trip.Rows.Add("TR" + T, "TRUE", (trip.Rows.Count) + 3);
                        CerrarFalse(ref trip, "OL01");
                        trip.Rows.Add("TR" + T, "FALSE", "");
                        break;
                }
            }
            else
            {
                switch (operador)
                {
                    case "OL02":

                        trip.Rows.Add("TR" + T, "TRUE", (trip.Rows.Count) + 3);
                        CerrarFalse(ref trip, operador);
                        trip.Rows.Add("TR" + T, "FALSE", "");
                        break;
                    default:
                        CerrarFalse(ref trip, operador);
                        trip.Rows.Add("TR" + T, "FALSE", "");
                        trip.Rows.Add("TR" + T, "TRUE", (trip.Rows.Count) + 2);


                        break;
                }
            }
            T++;
            return (pf[c - 2] + " " + pf[c - 1] + " " + pf[c]);

        }
        void TripletaOperacionesAritmeticas(ref DataTable Tripleta, string postfijo, ref int T)
        {
            string[] pf = postfijo.Split(' ');
            string strPostfijoTemporal = postfijo;
            while (pf.Length > 3)
            {
                int c = 0;
                string remplazo = "";
                foreach (string Token in pf)
                {

                    if (Token.Substring(0, 1) == "O")
                    {
                        remplazo = CrearRenglones(ref Tripleta, pf, c, ref T);
                        break;
                    }
                    c++;
                }
                strPostfijoTemporal = strPostfijoTemporal.Replace(remplazo, "T" + (T - 1));
                pf = strPostfijoTemporal.Split(' ');
            }
            CrearRenglones(ref Tripleta, pf, 2, ref T);

        }

        string CrearRenglones(ref DataTable trip, string[] pf, int c, ref int T)
        {

            trip.Rows.Add("T" + T, pf[c - 2], "OPA6");
            trip.Rows.Add("T" + T, pf[c - 1], pf[c]);
            T++;
            return (pf[c - 2] + " " + pf[c - 1] + " " + pf[c]);

        }

        static DataTable GenerarTabla()
        {
            DataTable Tripleta = new DataTable("Tripletas");
            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "DatoObjeto";
            column.AutoIncrement = false;
            column.Caption = "DatoObjeto";
            column.ReadOnly = false;
            column.Unique = false;
            Tripleta.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "DatoFuente";
            column.AutoIncrement = false;
            column.Caption = "DatoFuente";
            column.ReadOnly = false;
            column.Unique = false;
            Tripleta.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "DatoOperador";
            column.AutoIncrement = false;
            column.Caption = "DatoOperador";
            column.ReadOnly = false;
            column.Unique = false;
            Tripleta.Columns.Add(column);
            return Tripleta;
        }

        #endregion

        #endregion

        public List<string> Optimizar2()
        {
            List<string> LineasTokens = Lexico.AnalizadorLexico(rtxtentrada.Text);

            List<string> tokens = new List<string>();
            List<string> tokens1 = new List<string>();

            string tipodato = "";
            string iden = "";
            int contadorIden = 0;
            int lineaActual = 0;
            List<string> tokensProcesados = new List<string>();
            foreach (string linea in LineasTokens)
            {
                foreach (string token in linea.Split(' '))
                {
                    tokens.Add(token);
                }
            }

            for (int i = 0; i <= tokens.Count - 1; i++)
            {
                if (tokens[i] == "") { lineaActual++; }
                if (tokens[i].Contains("ID")) //aqui estaba ID
                {
                    tipodato = tokens[i + 1].ToString();
                    if (tokensProcesados.Contains(tokens[i])) { continue; }
                    tokensProcesados.Add(tokens[i]);

                    iden = tokens[i];

                    for (int j = 0; j <= tokens.Count - 1; j++)
                    {
                        if (tokens[j].ToString() == iden)
                        {
                            contadorIden++;
                        }
                    }

                    if (contadorIden <= 1)
                    {
                        MessageBox.Show("Se elimino una linea." + LineasTokens[lineaActual].ToString());
                        LineasTokens.RemoveAt(lineaActual);
                        lineaActual--;
                        contadorIden = 0;
                    }
                    else { contadorIden = 0; }
                }
            }

            foreach (string linea in LineasTokens)
            {
                foreach (string token in linea.Split(' '))
                {
                    tokens1.Add(token);
                }
            }

            //int valor;
            //for (int i = 0; i <= tokens1.Count - 1; i++)
            //{
            //    switch (tokens1[i].ToString().Substring(0,3))
            //    {
            //        case "CNE":
            //            {
            //                valor = TomarValorAlmacenado(tokens1[i].ToString());
            //                if (valor == 0 && tokens1[i - 1].ToString() == "OPA4")
            //                {
            //                    tokens1.RemoveAt(i);
            //                    tokens1.RemoveAt(i - 1);
            //                    i = i - 2;
            //                }
            //            }
            //            break;

            //        default:
            //            break;
            //    }
            //}


            return (LineasTokens);
        }

        public List<string> OptimizarExpresionesAlgebraicas(List<string> listaOptimizada)
        {
            List<string> tokens1 = new List<string>();
            foreach (string linea in listaOptimizada)
            {
                foreach (string token in linea.Split(' '))
                {
                    tokens1.Add(token);
                }
            }

            int valor;
            for (int i = 0; i <= tokens1.Count - 1; i++)
            {
                if (tokens1[i].ToString() == "") { continue; }
                switch (tokens1[i].ToString().Substring(0, 2))
                {
                    case "CN":
                        {
                            valor = TomarValorAlmacenado(tokens1[i].ToString());
                            if ((valor == 0 && tokens1[i - 1].ToString() == "OPA4" || (valor == 0 && tokens1[i + 1].ToString() == "OPA4")) || valor == 0 && tokens1[i - 1].ToString() == "OPA5" || (valor == 1 && tokens1[i - 1].ToString() == "OPA1") || (valor == 1 && tokens1[i + 1].ToString() == "OPA1") || (valor == 1 && tokens1[i - 1].ToString() == "OPA2"))
                            {
                                tokens1.RemoveAt(i);
                                tokens1.RemoveAt(i - 1);
                                //i = i - 1;
                            }
                        }
                        break;
                }
            }
            string strLinea = "";
            List<string> ListaDeLineas = new List<string>();
            foreach (string token in tokens1)
            {
                if (token != "")
                {
                    strLinea += token.ToString() + " ";
                }
                else
                {

                    ListaDeLineas.Add(strLinea);
                    strLinea = "";
                }
            }




            //foreach(string token in tokens1)
            //{
            //    MessageBox.Show(token);
            //}

            return (ListaDeLineas);

        }

        public int TomarValorAlmacenado(string strCNE)
        {
            int valor = 0;
            for (int i = 0; i <= dgvConstatesNumericasEnteras.Rows.Count - 1; i++)
            {
                if (dgvConstatesNumericasEnteras.Rows[i].Cells[0].Value.ToString() == strCNE)
                {
                    valor = int.Parse(dgvConstatesNumericasEnteras.Rows[i].Cells[1].Value.ToString());
                }
            }

            return (valor);
        }


        private void btnOpt2_Click(object sender, EventArgs e)
        {
            List<string> LineasTokens = Lexico.AnalizadorLexico(rtxtentrada.Text);

            List<string> tokens = new List<string>();
            List<string> tokens1 = new List<string>();

            string tipodato = "";
            bool bandera = false;
            string iden = "";
            int contadorIden = 0;
            int lineaActual = 0;
            List<string> tokensProcesados = new List<string>();
            foreach (string linea in LineasTokens)
            {
                foreach (string token in linea.Split(' '))
                {
                    tokens.Add(token);
                }
            }

            //foreach (string linea in LineasTokens)
            //{
            //    if (linea.Contains("TDD"))
            //    {
            //        foreach (string token in linea.Split(' '))
            //        {
            //            if (token.Contains("TDD"))
            //            {
            //                tipodato = token;
            //                continue;
            //                if (token.Contains("ID"))
            //                {
            //                    iden = token;
            //                }
            //            }
            //        }
            //    }
            //}

            //foreach (string token in tokens)
            //{
            //    if (token.Contains("TDD"))
            //    {
            //        tipodato = token;
            //        bandera = true;
            //    }

            //    if (bandera)
            //    {
            //        iden = token;
            //    }
            //}

            for (int i = 0; i <= tokens.Count - 1; i++)
            {
                if (tokens[i] == "") { lineaActual++; }
                if (tokens[i].Contains("ID"))
                {
                    tipodato = tokens[i].ToString();
                    if (tokensProcesados.Contains(tokens[i])) { continue; }
                    tokensProcesados.Add(tokens[i]);

                    iden = tokens[i];

                    for (int j = 0; j <= tokens.Count - 1; j++)
                    {
                        if (tokens[j].ToString() == iden)
                        {
                            contadorIden++;
                        }
                    }

                    if (contadorIden <= 1)
                    {
                        MessageBox.Show("Se elimino una linea." + LineasTokens[lineaActual].ToString());
                        LineasTokens.RemoveAt(lineaActual);
                        lineaActual--;
                        contadorIden = 0;
                    }
                    else { contadorIden = 0; }
                }
            }

            foreach (string linea in LineasTokens)
            {
                foreach (string token in linea.Split(' '))
                {
                    tokens1.Add(token);
                }
            }


            //bool bandera = false;
            //string temporal = "";

            //for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            //{
            //    temporal = dataGridView1.Rows[i].Cells[1].Value.ToString();

            //    for (int j = 0; j <= dataGridView1.Rows.Count - 1; j++)
            //    {
            //        if (dataGridView1.Rows[j].Cells[2].Value.ToString() == temporal)
            //        {
            //            bandera = true;
            //            break;
            //        }
            //        else { bandera = false; };
            //    }

            //    if (bandera)
            //    {
            //    }
            //    else
            //    {
            //        //eliminar ese registro de alguna forma
            //        dataGridView1.Rows.RemoveAt(dataGridView1.Rows[i].Index);
            //        dataGridView1.Refresh();
            //        i--;
            //    }
            //}


        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dataGridView1.Rows.Count; i++)
            {

            }
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        #region Optimización de ciclos
        /*
         *  Si se tiene un ciclo cuyo funcionamiento depende de una condición compuesta 
         *  (quizá incluso operaciones aritméticas) se debe aislar la condición para 
         *  resolverse antes de que se eejecute el ciclo, pues el programa tomará en cuenta realizar
         *  el cálculo. Se debería transladar la condición a un identificador antes de iniciar el ciclo.
         *  Es muy importante considerar que el valor que se va a reducir no sea incluido dentro del ciclo. 
         *  
         *  Se necesita:
         *      + DETERMINAR QUE TIENE UN CICLO FOR
         *      + Identificar que nos encontramos en un ciclo.
         *      + Determinar la condición del ciclo         
         *      + Determinar que la condición del ciclo es compuesta.
         *      - Buscar que las variables de la condición compuestas no sean modificadas dentro del ciclo
         *      - Si todo se cumple, asignar la parte distinta la variable de condición del ciclo en otra variable y sustituir.
         *      
         *  Si se utiliza la variable del ciclo para hacer multiplicaciones, se recomienda hacer sumas partiendo desde cero 
         *  por fuera del ciclo.
         *  
         *  Se necesita:
         *      + DETERMINAR QUE TIENE UN CICLO FOR
         *      + Identificar que nos encontramos en un ciclo.
         *      + Conocer la variable de iteración
         *      + Buscar si hay reaparición de la variable de iteración en una línea que NO es la línea del foreach.
         *      + Checar si dicha línea tiene una operación de multiplicación
         *      + Reescribir con suma
         *      - Inicializar la variable
         * 
         */

        bool CondicionCicloCompuesta(List<string> listaTokens)
        {
            string provisional = "";
            foreach (string lineaToken in listaTokens)
            {
                if (lineaToken.Contains("PR06") && lineaToken.Contains("PR19"))
                {
                    provisional = lineaToken.Substring(lineaToken.IndexOf("PR19"));
                    provisional = provisional.Substring(0, provisional.IndexOf("PR17"));
                    provisional = provisional.Substring(provisional.IndexOf(" "));
                }
            }
            return provisional.Contains("OL01") || provisional.Contains("OL02");
        }

        string TokenCiclo(List<string> listaTokens)
        {
            string provisional = "";
            foreach (string lineaToken in listaTokens)
            {
                if (lineaToken.Contains("PR06") && lineaToken.Contains("OPA6"))
                {
                    provisional = lineaToken.Substring(0, lineaToken.IndexOf("OPA6") - 1);
                    provisional = provisional.Substring(provisional.LastIndexOf(" "));
                }
            }
            return provisional.Trim();
        }

        List<string> AparicionesTokenCiclo(List<string> listaTokens)
        {
            List<string> apariciones = new List<string>();
            foreach (string lineaToken in listaTokens)
            {
                if (lineaToken.Contains(TokenCiclo(listaTokens)) && !lineaToken.Contains("PR06"))
                    apariciones.Add(lineaToken);
            }
            return apariciones;
        }

        List<string> MultiplicandoTokenCiclo(List<string> listaTokens)
        {
            List<string> multiplicando = new List<string>();
            foreach (string lineaToken in AparicionesTokenCiclo(listaTokens))
            {
                if (lineaToken.Contains("OPA1 " + TokenCiclo(listaTokens)) || lineaToken.Contains(TokenCiclo(listaTokens) + " OPA1"))
                    multiplicando.Add(lineaToken);
            }
            return multiplicando;
        }

        string ObtenerVariableProductoConTipo(List<string> listaTokens)
        {
            string str = "";
            foreach (string lineaToken in MultiplicandoTokenCiclo(listaTokens))
            {
                str = lineaToken.Substring(0, lineaToken.IndexOf("OPA6"));
            }
            return str.Trim();
        }

        string ObtenerVariableProducto(List<string> listaTokens)
        {
            string str = "";
            foreach (string lineaToken in MultiplicandoTokenCiclo(listaTokens))
            {
                str = lineaToken.Substring(0, lineaToken.IndexOf("OPA6"));
            }
            return str.Substring(str.IndexOf(" "));

        }

        List<string> SustituirMultiplicaciones(List<string> listaTokens)
        {
            List<string> nuevaLista = new List<string>();
            foreach (string lineaToken in listaTokens)
            {
                if (lineaToken.Contains("PR06"))
                {
                    bool cero = false;
                    int lastIndex = 0;
                    foreach (NumericoEntero unEntero in MetodosAL.ConstantesNumericasEnteras)
                    {
                        if (unEntero.Contenido == 0)
                        {
                            cero = true;
                            lastIndex = unEntero.Index;
                            break;
                        }
                        lastIndex = unEntero.Index;
                    }
                    if (!cero)
                    {
                        lastIndex++;
                        MetodosAL.ConstantesNumericasEnteras.Add(new NumericoEntero { Index = lastIndex, Contenido = 0 });
                    }
                    nuevaLista.Add(ObtenerVariableProductoConTipo(listaTokens) + " OPA6 " + "CNE" + lastIndex);
                    nuevaLista.Add(lineaToken);
                }
                else
                {
                    foreach (string tokesion in MultiplicandoTokenCiclo(listaTokens))
                    {
                        if (lineaToken == tokesion)
                        {
                            string provisional = lineaToken.Replace("OPA1 " + TokenCiclo(listaTokens), "OPA4 " + ObtenerVariableProducto(listaTokens));
                            provisional = provisional.Replace(TokenCiclo(listaTokens) + " OPA1", ObtenerVariableProducto(listaTokens) + " OPA4").Replace("  ", " ");
                            if (provisional.Contains("TDD"))
                                provisional = provisional.Substring(provisional.IndexOf(" "));
                            nuevaLista.Add(provisional.Trim());
                        }
                        else
                        {
                            nuevaLista.Add(lineaToken);
                        }
                    }
                }

            }
            return nuevaLista;
        }
        #endregion


        public DataTable OptimizacionDeMirilla(DataTable Tripleta)
        {
            int lineasDentroDelMetodo = 0;
            DataTable nuevaTripleta =  GenerarTabla();
            bool dentroDeUnMetodo = false;
            DataTable temp = GenerarTabla();
            string nombreTemporalMetodoInutil = "";
            string nombreTemporalMetodoUtil = "";
            bool esInutil = false;
            foreach (DataRow dtr in Tripleta.Rows)
            {
                DataRow matar = nuevaTripleta.NewRow();
                object[] matriz = { dtr.ItemArray[0], dtr.ItemArray[1], dtr.ItemArray[2] };
                matar.ItemArray = matriz;
                nuevaTripleta.Rows.Add(matar);
                if (dtr.ItemArray[0].ToString() == "FUNC")
                {
                    dentroDeUnMetodo = true;
                    nombreTemporalMetodoInutil = dtr.ItemArray[1].ToString();
                    temp.Rows.Add(dtr.ItemArray[0],dtr.ItemArray[1],dtr.ItemArray[2]);
                    nuevaTripleta.Rows.Remove(matar);
                    continue;

                }
                if (dentroDeUnMetodo)
                {
                    lineasDentroDelMetodo++;
                    temp.Rows.Add(dtr.ItemArray[0], dtr.ItemArray[1], dtr.ItemArray[2]);
                    nuevaTripleta.Rows.Remove(matar);
                    if (dtr.ItemArray[0].ToString() == "ENDP")
                    {
                        dentroDeUnMetodo = false;
                    }
                    else {
                        continue;
                    }
                 
                }
                switch (lineasDentroDelMetodo)
                {
                    case 5:
                        foreach (DataRow tempdtr in temp.Rows)
                        {
                            if (tempdtr.ItemArray[1].ToString().Contains("TR")) 
                            {
                                nombreTemporalMetodoUtil = tempdtr.ItemArray[1].ToString();
                                esInutil = true;
                            }
                            lineasDentroDelMetodo = 0;
                        }
                        break;
                    case 6:
                        //Codificar aqui el caso en que se haga una declaracion extra
                        break;
                    default:
                        lineasDentroDelMetodo = 0;
                        esInutil = false;
                        break;
                }
                if (!esInutil)
                {
                    foreach (DataRow tempdtr in temp.Rows)
                    {
                            nuevaTripleta.Rows.Add(tempdtr.ItemArray[0],tempdtr.ItemArray[1],tempdtr.ItemArray[2]);
                    }
                }
                else
                {
                    foreach (DataRow tempdtr in nuevaTripleta.Rows)
                    {
                        if (tempdtr.ItemArray[1].ToString().Contains(nombreTemporalMetodoInutil))
                        {
                            object[] nuevosDatos = { tempdtr.ItemArray[0], nombreTemporalMetodoUtil, tempdtr.ItemArray[2] };
                            tempdtr.ItemArray = nuevosDatos;
                        }
                    }
                }
                temp = GenerarTabla();
               
            }
            return nuevaTripleta;
        }
    }

}