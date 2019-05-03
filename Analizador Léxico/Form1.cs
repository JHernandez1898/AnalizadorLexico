using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Analizador_Léxico.Clases;
using System.Diagnostics;
using System.Data.Sql;

namespace Analizador_Léxico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnleertodo_Click(object sender, EventArgs e)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                //Anlizador Lexico
                rtxtcodigointermedio.Text = "";
                string strEntrada = rtxtentrada.Text;
                linea = 0;
                txtnumrenglon.Text = linea.ToString();
                string[] strLineas = strEntrada.Split('\n');                             
                foreach (string Linea in strLineas)
                {
                    linea++;
                    txtnumrenglon.Text = linea.ToString();
                    List<string> tokens = new List<string>();
                    MetodosAL.ObtenerToken(Linea, ref tokens);
                    if (Linea != "")
                    {
                        foreach (string token in tokens) rtxtcodigointermedio.Text += token + " ";
                        rtxtcodigointermedio.Text += "\n";                        
                    }
                    txtnumrenglon.Text = linea.ToString();
                }
                MostrarIdentificadoresConstantes();
                Depurar();
                linea = 1;
                stopwatch.Stop();
                MessageBox.Show(stopwatch.Elapsed.ToString() + "ms", "Analizador léxico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + linea + ".\nVerifique el uso apropiado del léxico.", "Error de analizador léxico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                linea = 1;
            }
        }

        private void Depurar()
        {
            MetodosAL.Identificadores.Clear();
            MetodosAL.ConstantesNumericasEnteras.Clear();
            MetodosAL.ConstantesNumericasReales.Clear();
            MetodosAL.ConstantesNumericasExponenciales.Clear();
            MetodosAL.ConstantesNumericasExpReales.Clear();
        }

        private void MostrarIdentificadoresConstantes()
        {
            dgvIDE.Rows.Clear();
            dgvConstatesNumericas.Rows.Clear();
            dgvConstantesExpo.Rows.Clear();
            foreach (Identificador IDE in MetodosAL.Identificadores)
                dgvIDE.Rows.Add("ID"+IDE.Index, IDE.Nombre, "", "");
            foreach (NumericoEntero Num in MetodosAL.ConstantesNumericasEnteras)
                dgvConstatesNumericas.Rows.Add("CNE" + Num.Index, Num.Contenido);
            foreach (NumericoReal Real in MetodosAL.ConstantesNumericasReales)
                dgvConstatesNumericas.Rows.Add("CNR" + Real.Index, Real.Contenido);
            foreach (NumericoExponencial expo in MetodosAL.ConstantesNumericasExponenciales)
                dgvConstantesExpo.Rows.Add("CNEE" + expo.Index, expo.Contenido, expo.Exponencial);
            foreach (NumericoExpReal exporeal in MetodosAL.ConstantesNumericasExpReales)
                dgvConstantesExpo.Rows.Add("CNRE" + exporeal.Index, exporeal.Contenido, exporeal.Exponencial);
        }
        static int indx = 0;
        static int palabra = 0;
        static int intEstadoActual = 0;
        static int linea = 1;
        static List<char> caracteres = new List<char>();
        private void btnCaracterXCaracter_Click(object sender, EventArgs e)
        {
            try {                            
                string strEntrada = rtxtentrada.Text;
                if (indx == 0)
                {
                    Depurar();
                    rtxtcodigointermedio.Text = "";
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
                        linea++;
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
                    linea = 1;
                }
                MostrarIdentificadoresConstantes();
            }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message + linea + ".\nVerifique el uso apropiado del léxico, y el caracter actual.", "Error de analizador léxico", MessageBoxButtons.OK, MessageBoxIcon.Error);            
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
            rtxtcodigointermedio.Text += txtcadenatokens.Text + "\n";
            txtcadenatokens.Text = "";
            caracteres.Clear();
            intEstadoActual = 0;
        }

        int intContadorPalabras = 0;
        int intCantidadPalabras = 0;
        int intLinea = 1;
        string[] strPalabras;

        private void Form1_Load(object sender, EventArgs e)
        {
            EstablecerConexion();
        }

        public void EstablecerConexion()
        {
            
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable instancias = instance.GetDataSources();
            
            for (int i = 0; i <instancias.Rows.Count ; i++)
            {
                cmbServidores.Items.Add(instancias.Rows[i][1].ToString());
            }
            MessageBox.Show("Seleccione un servidor para la conexion");
            btnCaracterxCarter.Enabled = false;
            btnleertodo.Enabled = false;
            cmbServidores.Focus();
        }

        private void cmbServidores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               if(ConexionMatriz.ProbarConexion(cmbServidores.SelectedItem.ToString()))
                {
                    MessageBox.Show("Conectado al servidor");
                    btnCaracterxCarter.Enabled = true;
                    btnleertodo.Enabled =true;
                    MetodosAL.Servidor = cmbServidores.SelectedItem.ToString();
                }
               else
                {
                    MessageBox.Show("Conexion fallida");
                    btnCaracterxCarter.Enabled = false;
                    btnleertodo.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void btnleersiguiente_Click(object sender, EventArgs e)
        //{
        //    if (intContadorPalabras <= intCantidadPalabras)
        //    {
        //        if (intContadorPalabras == 0)
        //        {
        //            rtxtcodigointermedio.Text = "";
        //            string strEntrada = rtxtentrada.Text;
        //            strPalabras = strEntrada.Split(' ');
        //            intCantidadPalabras = strPalabras.Length - 1;
        //        }

        //        List<string> tokens = new List<string>();
        //        string strPalabra = strPalabras[intContadorPalabras];
        //        if (!strPalabras[intContadorPalabras].Contains("\n"))
        //        {                    
        //            MetodosAL.ObtenerToken(strPalabras[intContadorPalabras], ref tokens);
        //            foreach (string token in tokens)
        //            {
        //                rtxtcodigointermedio.Text += token + " ";
        //                txttoken.Text = token;
        //            }
        //            rtxtcodigointermedio.Text += " ";
        //            MostrarIdentificadoresConstantes();
        //        }
        //        else
        //        {
        //            string strPalabraEspaciada = strPalabras[intContadorPalabras];
        //            if (strPalabras[intContadorPalabras] != "\n")
        //            {                        
        //                strPalabraEspaciada = strPalabraEspaciada.Replace("\n","");
        //            }
        //            MetodosAL.ObtenerToken(strPalabraEspaciada, ref tokens);
        //            foreach (string token in tokens)
        //            {
        //                rtxtcodigointermedio.Text += token + " ";
        //                txttoken.Text = token;
        //            }
        //            rtxtcodigointermedio.Text += " ";
        //            rtxtcodigointermedio.Text += " \n";
        //            MostrarIdentificadoresConstantes();
        //            intLinea++;                    
        //        }
        //        txtnumrenglon.Text = intLinea.ToString();
        //        intContadorPalabras++;
        //    }
        //    else
        //    {
        //        intContadorPalabras = 0;
        //        intCantidadPalabras = 0;
        //        intLinea = 1;
        //        Depurar();
        //    }
        //}
    }

}
