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

        SintaxisL miSintaxis = new SintaxisL();

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

        public string[] CrearCombinaciones(int temp, string linea)
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


            string Existe = "";
            txtTemporal.Text = temp.ToString();
            if (temp == 0) { MessageBox.Show("Error de sintaxis en línea " + (nLinea + 1)); nLinea = 0; principio = true; rtxtcodigointermediolexico.Text = " "; }
            else
            {
                string[] strSubcadenas = CrearCombinaciones(temp, strActual);
                if (MetodosAS.DisminuirTemp(strSubcadenas, temp)) { txtTemporal.Text = temp.ToString(); temp--; }

                else
                {
                    foreach (string str in strSubcadenas)
                    {
                        string strCambio = "";

                        strCambio = NormalizarCadena(str, temp);
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

        public bool Revisar(string[] strSubcadenas, int temp)
        {
            string Existe = "";
            string strCambio = "";
            bool evento = false;
            foreach (string str in strSubcadenas)
            {
                foreach (SintaxLibre S in miSintaxis.Sintax)
                {
                    strCambio = NormalizarCadena(str, temp);
                    Existe = S.Exist(strCambio);
                    if (Existe != strCambio)
                    {
                        evento = true;
                        return evento;
                    }
                }
            }
            return evento;
        }

        public string NormalizarCadena(string subcadena, int tempo)
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

        private void Btnleertodo_Click(object sender, EventArgs e)
        {
            rtxtcodigointermediolexico.Text = "";
            rtxtcodigointermediosintax.Text = "";
            rtxSintaxLineaxLinea.Text = "";
            rtxSintaxLineaxLinea.Text = "";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<string> LineasTokens = new List<string>();
            LineasTokens = Lexico.AnalizadorLexico(rtxtentrada.Text);
            foreach (String token in LineasTokens)
            {
                rtxtcodigointermediolexico.Text += token + " ";
                rtxtcodigointermediolexico.Text += "\n";
            }
            MostrarIdentificadoresConstantes();
            Lexico.Depurar();
            int linea = 1;
            string strCambio = "";
            string strActual = "";
            int temp = 0;
            try
            {
                foreach (string cadena in LineasTokens)
                {
                    strActual = cadena;
                    strActual = strActual.Substring(0, strActual.Length - 1);
                    rtxtcodigointermediosintax.Text += cadena + "\n";
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
                            rtxtcodigointermediosintax.Text += strActual + "\n";
                            temp = strActual.Split(' ').Length;
                        }
                        if (strActual == "S") { rtxSintaxLineaxLinea.Text += "Línea " + linea.ToString() + ":S" + "\n"; temp = 0; linea++; }
                    }
                    if (strActual != "S") { rtxSintaxLineaxLinea.Text += "Línea " + linea.ToString() + ":ERROR" + "\n"; MessageBox.Show("Sintaxis incorrecta en la línea: " + linea); linea++; }
                }
                stopwatch.Stop();
                MessageBox.Show(stopwatch.Elapsed.ToString() + "ms", "Analizador sintáctico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void MostrarIdentificadoresConstantes()
        {
            dgvIDE.Rows.Clear();
            dgvConstatesNumericasEnteras.Rows.Clear();
            dgvConstatesNumericasReales.Rows.Clear();
            dgvConstantesExpo.Rows.Clear();
            foreach (Identificador IDE in MetodosAL.Identificadores)
                dgvIDE.Rows.Add("ID" + IDE.Index, IDE.Nombre, "", "");
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


            string Existe = "";
            txtTemporal.Text = temp.ToString();
            if (temp == 0) { MessageBox.Show("Error de sintaxis en línea " + (nLinea + 1)); nLinea = 0; principio = true; rtxtcodigointermediosintax.Text = " "; }
            else
            {
                string[] strSubcadenas = CrearCombinaciones(temp, strActual);
                if (MetodosAS.DisminuirTemp(strSubcadenas, temp)) { txtTemporal.Text = temp.ToString(); temp--; }

                else
                {
                    foreach (string str in strSubcadenas)
                    {
                        string strCambio = "";

                        strCambio = NormalizarCadena(str, temp);
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
    }
}
