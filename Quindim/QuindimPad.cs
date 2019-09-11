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

namespace Quindim
{
    public partial class QuindimPad : Form
    {


        public QuindimPad()
        {
            InitializeComponent();
        }

        private void QuindimPad_Load(object sender, EventArgs e)
        {
            EstablecerConexion();
        }

        public void EstablecerConexion()
        {
            MessageBox.Show("Capture una instancia para la conexion", "Analizador Sintactico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnleertodo.Enabled = false;
            gbLexico.Enabled = false;
            gbSintax.Enabled = false;
            //btnleertodo.Enabled = false;
            lblServidor.Text = "Servidor: " + System.Environment.MachineName;
            lblconexion.BackColor = Color.Red;
            txtServer.Focus();
        }

        private void BtnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMatriz.ProbarConexion(txtServer.Text))
                {
                    MessageBox.Show("Conectado al servidor", "Lexico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gbLexico.Enabled = true;
                    gbSintax.Enabled = true;
                    btnleertodo.Enabled = true;
                    MetodosAL.Servidor = txtServer.Text;
                    lblconexion.BackColor = Color.Green;
                    MetodosAS.CrearMatriz();
                    MetodosSe.CrearMatriz();
                    btnleertodo.Enabled = true;


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
        }

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



        private void Btnleertodo_Click(object sender, EventArgs e)
        {
            MetodosAL.Depurar();
            rtxtcodigointermediolexico.Text = "";
            rtxtcodigointermediosintax.Text = "";
            rtxSintaxLineaxLinea.Text = "";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //LEXICO
            List<string> LineasTokens;
            LineasTokens = Lexico.AnalizadorLexico(rtxtentrada.Text);
            foreach (String token in LineasTokens)
            {
                rtxtcodigointermediolexico.Text += token + " ";
                rtxtcodigointermediolexico.Text += "\n";
            }

            //SINTAXIS
            rtxtcodigointermediosintax.Text = Sintaxis.AnalisisSintactico(LineasTokens);
        

            //SEMANTICA
            //PrimerPasada
            List<string> LineasSemantica = MetodosSe.PrimeraPasada(LineasTokens);
            string status = "";
            string bottomupSemantica =  MetodosSe.SegundaPasada(LineasSemantica,ref status);
            rchSemantica.Text = "";
            rchSemantica.Text = bottomupSemantica;
            rchtxtSemantic.Text = status;

            stopwatch.Stop();
            MessageBox.Show(stopwatch.Elapsed.ToString() + "ms", " Compilacion ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MostrarIdentificadoresConstantes();
        }

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

        private void BtnLineaxLinea_Click(object sender, EventArgs e)
        {
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

        private void btnPrimeraPasada_Click(object sender, EventArgs e)
        {
            rchSemantica.Text = "";
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
                        //if (!Revisar(strSubcadenas, temp)) temp--;
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

    }

}