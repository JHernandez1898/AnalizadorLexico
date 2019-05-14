using Analizador_Sintáctico.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analizador_Sintáctico
{
    public partial class Sintaxis : Form
    {
        SintaxisL miSintaxis = new SintaxisL();

        public Sintaxis()
        {
            InitializeComponent();
        }

        private void btnleertodo_Click(object sender, EventArgs e)
        {
            int temporal = 0;
            int InicioSub = 0;
            bool banderaRepite = false;
            bool banderaSub = false;
            string SubCadena = "";
            string ExistS = "";
            string SintaxRes = "";
            string[] SplitLinea;
            rtxtcodigointermedio.Text = "";
            try
            {
                //IMPLEMENTACION ANALISIS LEXICO
                //ESTA LISTA TIENE LINEA POR LINEA LOS TOKENS CORRESPONDIENTES
                List<string> LineasLexico = new List<string>();
                LineasLexico = Lexico.AnalizadorLexico(rtxtentrada.Text);

                //ANALISIS SINTACTICO
                foreach (string Linea in LineasLexico)
                {
                    //SEPARAR LINEA EN TOKENS
                    SplitLinea = Linea.Split(' ');
                    temporal = SplitLinea.Length;

                    do
                    {
                        for (int i = InicioSub; i < temporal; i++) { SubCadena += SplitLinea[i] + " "; }
                        txtTemporal.Text = temporal.ToString();
                        foreach (SintaxLibre S in miSintaxis.Sintax)
                        {
                            ExistS = S.Exist(SubCadena);
                            if (ExistS != SubCadena)
                            {
                                SintaxRes = Linea.Replace(SubCadena.Trim(), ExistS);
                                rtxtcodigointermedio.Text += SintaxRes + "\n";
                                banderaRepite = true;
                                InicioSub = 0;
                                temporal = SplitLinea.Length;
                                SubCadena = "";
                                break;
                            }
                            else { banderaRepite = false; }
                        }
                        if (temporal != SplitLinea.Length)
                        {
                            if (banderaRepite) { temporal--; }
                            InicioSub++;
                        }
                        if (temporal == 0  && !banderaRepite) { throw new Exception("Sintaxis invalida."); }
                    } while (banderaRepite);
               }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //CONEXION A MATRIZ - LEXICO//
        private void Sintaxis_Load(object sender, EventArgs e)
        {
            EstablecerConexion();
        }

        public void EstablecerConexion()
        {
            MessageBox.Show("Capture una instancia para la conexion", "Analizador Sintactico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnCaracterxCarter.Enabled = false;
            btnleertodo.Enabled = false;
            lblServidor.Text = "Servidor: " + System.Environment.MachineName;
            lblconexion.BackColor = Color.Red;
            txtServer.Focus();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMatriz.ProbarConexion(txtServer.Text))
                {
                    MessageBox.Show("Conectado al servidor", "Lexico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCaracterxCarter.Enabled = true;
                    btnleertodo.Enabled = true;
                    MetodosAL.Servidor = txtServer.Text;
                    lblconexion.BackColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("Conexion fallida", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnCaracterxCarter.Enabled = false;
                    btnleertodo.Enabled = false;
                    lblconexion.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static List<string> LineasTokens = new List<string>();
        static int nLinea = 0;
        static string strActual = "";
        static int temp = 1;
       

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

            string[] NuevaLinea = new string[(arreglo.Length + 1 ) - temp];
            for (int j = 0; j < NuevaLinea.Length; j++)
            {
                string Elemento = "";
                for (int i = 0; i < temp; i++)
                {
                    if (temp != 1)
                        Elemento += arreglo[j + i] + " ";
                    else Elemento += arreglo[j + i];
                    //if((j+i) == arreglo.Length - 1) { j = arreglo.Length + 1; }
                }
                if (temp == 1)
                    NuevaLinea[j] = Elemento;
                else NuevaLinea[j] = Elemento.Substring(0, Elemento.Length -1);
            }
            return NuevaLinea;
        }
        static bool principio = true;
        static bool transformo = false;
        private void btnCaracterxCarter_Click(object sender, EventArgs e)
        {
            LineasTokens = Lexico.AnalizadorLexico(rtxtentrada.Text);
            string[] ArregloLineas = RellenarArreglo();
            if (principio)
            {
                principio = false;
                strActual = RellenarArreglo()[nLinea];
                rtxtcodigointermedio.Clear();
               
                rtxtcodigointermedio.Text = ArregloLineas[nLinea] + "\n";
                txtcadenatokens.Text = ArregloLineas[nLinea];
                strActual = strActual.Substring(0, strActual.Length - 1);
                temp = strActual.Split(' ').Length;
            }
            txtTemporal.Text = temp.ToString();
            
           
            string Existe = "";
            string Remplazable = strActual;
            txtTemporal.Text = temp.ToString();
            string[] strSubcadenas = CrearCombinaciones(temp, strActual);
            if (!Revisar(CrearCombinaciones(temp, strActual)))
            {
                
           
                if(temp == 0 ) { MessageBox.Show("Error de sintaxis"); }
                else { temp--; txtTemporal.Text = temp.ToString(); }
            }
            else
            {
                foreach (string str in strSubcadenas)
                {
                    if (str != "")
                    {
                        string strCambio = str;
                        foreach (SintaxLibre S in miSintaxis.Sintax)
                        { 
                            if (str.Substring(0, 2) == "ID" && str.Length <= 3) { strCambio = "ID"; }
                            Existe = S.Exist(strCambio);
                            if (Existe != strCambio)
                            {
                                strActual = strActual.Replace(str, Existe);
                                rtxtcodigointermedio.Text += strActual + "\n";
                                temp = strActual.Split(' ').Length;
                            
                                break;
                            }
                        }
                    }

                }

                if (strActual == "S") { nLinea++; principio = true; }
            }
           
            if (nLinea == ArregloLineas.Length) nLinea = 0;

        }
        public bool Revisar(string[] strSubcadenas)
        {
            string Existe = "";
            bool evento = false;
            foreach (string str in strSubcadenas)
            {
                if (str != "")
                {
                    foreach (SintaxLibre S in miSintaxis.Sintax)
                    {
                        string strCambio = str;
                          if (str.Substring(0, 2) == "ID" && str.Length <= 3) { strCambio = "ID"; }
                        Existe = S.Exist(strCambio);
                        if (Existe != strCambio)
                        {
                            evento = true;
                            break;
                        }
                    }

                }
            }
            return evento;
        }
    }
}
