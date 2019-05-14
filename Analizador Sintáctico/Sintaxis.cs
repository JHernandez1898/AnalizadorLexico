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
            int InicioSub = 1;
            int FinSub = 0;
            int varControl = 0;
            int control = 0;
            int LineaActual = 0;
            bool banderaRepite = true;
            bool banderaCambio = false;
            string LineaMod = "";
            string SubCadena = "";
            string ExistS = "";
            string SintaxRes = "";
            string[] SplitLinea;
            rtxtcodigointermedio.Text = "";
            rtxSintaxLineaxLinea.Text = "";
            try
            {
                //IMPLEMENTACION ANALISIS LEXICO
                List<string> LineasLexico = new List<string>();
                LineasLexico = Lexico.AnalizadorLexico(rtxtentrada.Text);

                //ANALISIS SINTACTICO
                foreach (string Linea in LineasLexico)
                {
                    //SEPARAR LINEA EN TOKENS
                    banderaRepite = true;
                    LineaMod = Linea;
                    SplitLinea = Linea.Trim().Split(' ');
                    // ID# TO ID
                    for (int i = 0; i < SplitLinea.Length; i++)
                    {
                        if (SplitLinea[i].Substring(0, 2) == "ID" && SplitLinea[i] != "IDEN")
                        {
                            string IdVal = SplitLinea[i];
                            for (int k = 0; k < SplitLinea[i].Length; k++)
                            {
                                if (char.IsNumber(SplitLinea[i][k])) { IdVal = SplitLinea[i].Replace(SplitLinea[i][k], ' ').Trim(); }
                            }
                            LineaMod = LineaMod.Replace(SplitLinea[i], IdVal);
                        }
                    }
                    SplitLinea = LineaMod.Trim().Split(' ');
                    FinSub = temporal = SplitLinea.Length;

                    do
                    {
                        SubCadena = "";
                        //VARIABLE PARA SABER CUANTOS GRUPOS DEBEMOS FORMAR EN SUB CADENA
                        varControl = (SplitLinea.Length + 1) - temporal;
                        //CREACION DE SUB CADENA
                        for (int i = InicioSub - 1; i < FinSub; i++) { SubCadena += SplitLinea[i] + " "; }
                        foreach (SintaxLibre S in miSintaxis.Sintax)
                        {
                            //BUSCA CONINCIDENCIA DE SUB CADENA CON GRAMATICA
                            ExistS = S.Exist(SubCadena);
                            if (ExistS != SubCadena)
                            {
                                /*LineaMod = "";
                                for (int k = 0; k < SplitLinea.Length; k++)
                                {
                                    if (SplitLinea[k] == SubCadena.Trim())
                                    {
                                        SplitLinea[k] = ExistS;
                                        break;
                                    }
                                }
                                for (int j = 0; j < SplitLinea.Length; j++)
                                {
                                    LineaMod += SplitLinea[j] + " ";
                                }*/
                                LineaMod = SintaxRes = LineaMod.Replace(SubCadena.Trim(), ExistS);
                                SplitLinea = LineaMod.Trim().Split(' ');
                                banderaCambio = true;
                                rtxtcodigointermedio.Text += SintaxRes + "\n";
                                if (ExistS == "S")
                                {
                                    rtxSintaxLineaxLinea.Text += "Linea " + (LineaActual + 1) + ": " + ExistS + "\n";
                                    rtxtcodigointermedio.Text += "\n";
                                }
                                InicioSub = 1;
                                FinSub = temporal = SplitLinea.Length;
                                SubCadena = "";
                                control = 0;
                                break;
                            }
                            else { banderaCambio = false; }
                        }
                        if (!banderaCambio)
                        {
                            if (InicioSub != varControl)
                            {
                                InicioSub++;
                                control++;
                                FinSub = temporal + control;
                            }
                            else
                            {
                                temporal--;
                                InicioSub = 1;
                                control = 0;
                                FinSub = temporal;
                            }
                        }
                        if (temporal == 0  && banderaRepite)
                        {
                            banderaRepite = false;
                            if (LineaMod.Trim() != "S")
                            {
                                rtxSintaxLineaxLinea.Text += "Linea " + (LineaActual + 1).ToString() + ": Error\n";
                                throw new Exception("Error sintactico en linea " + (LineaActual + 1).ToString() + ".\nVerifique el uso apropiado la sintaxis.");
                            }
                        }
                    } while (banderaRepite);
                    LineaActual++;
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
                    MessageBox.Show("Conectado al servidor", "Lexico", MessageBoxButtons.OK,MessageBoxIcon.Information);
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
    }
}
