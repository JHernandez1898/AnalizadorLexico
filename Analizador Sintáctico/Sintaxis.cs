﻿using Analizador_Sintáctico.Clases;
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
            nLinea = 0;
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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
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
                        if (SplitLinea[i].Substring(0, 2) == "ID" || SplitLinea[i].Substring(0, 3) == "CNE" || SplitLinea[i].Substring(0, 3) == "CNR" || SplitLinea[i].Substring(0, 4) == "CNEE" || SplitLinea[i].Substring(0, 4) == "CNRE")
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
                        if (temporal == 0 && banderaRepite)
                        {
                            banderaRepite = false;
                            if (LineaMod.Trim() != "S")
                            {
                                rtxSintaxLineaxLinea.Text += "Línea " + (LineaActual + 1).ToString() + ": Error\n";
                                throw new Exception("Error sintactico en línea " + (LineaActual + 1).ToString() + ".\nVerifique el uso apropiado la sintaxis.");
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
            stopwatch.Stop();
            MessageBox.Show(stopwatch.Elapsed.ToString() + "ms", "Analizador léxico", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //btnleertodo.Enabled = false;
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
                    //btnleertodo.Enabled = true;
                    MetodosAL.Servidor = txtServer.Text;
                    lblconexion.BackColor = Color.Green;
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

            string[] NuevaLinea = new string[(arreglo.Length + 1) - temp];
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
                else NuevaLinea[j] = Elemento.Substring(0, Elemento.Length - 1);
            }
            return NuevaLinea;
        }
        static bool principio = true;
        private void btnCaracterxCarter_Click(object sender, EventArgs e)
        {

            LineasTokens = Lexico.AnalizadorLexico(rtxtentrada.Text);
            string[] ArregloLineas = RellenarArreglo();
            if (principio)
            {
                principio = false;
                rtxtcodigointermedio.Text = "";
                strActual = RellenarArreglo()[nLinea];
                strActual = strActual.Substring(0, strActual.Length - 1);
                rtxtcodigointermedio.Text += ArregloLineas[nLinea] + "\n";
                txtcadenatokens.Text = ArregloLineas[nLinea];
                
                temp = strActual.Split(' ').Length;
            }
            txtTemporal.Text = temp.ToString();

            
            string Existe = "";
            txtTemporal.Text = temp.ToString();
            if (temp == 0) { MessageBox.Show("Error de sintaxis en línea " + (nLinea + 1)); nLinea = 0; principio = true; rtxtcodigointermedio.Text = " "; }
            else
            {
                string[] strSubcadenas = CrearCombinaciones(temp, strActual);
                if (!Revisar(CrearCombinaciones(temp, strActual),temp)) { temp--; txtTemporal.Text = temp.ToString(); }

                else
                {
                    foreach (string str in strSubcadenas)
                    {
                        if (str != "")
                        {
                            string strCambio = str;
                            foreach (SintaxLibre S in miSintaxis.Sintax)
                            {
                                strCambio = NormalizarCadena(str,temp);
                                Existe = S.Exist(strCambio);
                                if (Existe != strCambio)
                                {

                                    strActual = strActual.Replace(str, Existe);
                                    break;
                                }
                            }
                        }
                    }
                    rtxtcodigointermedio.Text += strActual + "\n";
                    temp = strActual.Split(' ').Length;

                }
                txtcadenatokens.Text = strActual;

                if (strActual == "S") { nLinea++; principio = true; rtxSintaxLineaxLinea.Text += "Línea " + nLinea.ToString() + ":S" + "\n"; }
            }
            if (LineasTokens.Count <= nLinea) nLinea = 0;

        }
        public bool Revisar(string[] strSubcadenas,int temp)
        {
            string Existe = "";
            string strCambio = "";
            bool evento = false;
            foreach (string str in strSubcadenas)
            {
                if (str != "")
                {   
                    foreach (SintaxLibre S in miSintaxis.Sintax)
                    {       
                        strCambio = NormalizarCadena(str,temp);
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
        public string NormalizarCadena(string subcadena,int tempo)
        {
            string[] d = subcadena.Split(' ');
            string strCambio = subcadena;
            if (tempo == 1)
            {
                if (d[0].Substring(0, 2) == "ID" && d[0] != "IDEN") { strCambio = "ID"; }
                if ((d[0]+"  ").Substring(0, 3) == "CNE") { strCambio = "CNE"; }
                if ((d[0] + " ").Substring(0, 3) == "CNR") { strCambio = "CNR"; }
                if ((d[0] + " ").Substring(0, 4) == "CNEE") { strCambio = "CNEE"; }
                if ((d[0] + " ").Substring(0, 4) == "CNRE") { strCambio = "CNRE"; }
            }
            return strCambio;


        }

        /*    tokens.Add("PR01 ID1 ");
            tokens.Add("ID2 OPA6 ID3 ");
            tokens.Add("PR12 ID2 ");
            tokens.Add("PR09 TDD2 PR21 ID3 PAR2 PAR1 ");
            tokens.Add("PR23 ID4 OPR6 CNE1 ");
            tokens.Add("PR17 PAR2 CNE2 PAR1 ");
            tokens.Add("PR04 ");
            tokens.Add("PR16 ID5 OPA6 ID4 PR10 ID4 OPR1 CNE2 PR24 ID5 OPA6 ID5 OPA5 CNE2 ");
            tokens.Add("ID6 OPA6 ID6 OPA1 ID5 ");
            tokens.Add("PR08 ");
            tokens.Add("PR17 PAR2 ID6 PAR1 ");
            LineasTokens = tokens;*/
        private void LeerTodo2_Click(object sender, EventArgs e)
        {
            rtxtcodigointermedio.Text = "";
            rtxSintaxLineaxLinea.Text = "";

            List<string> LineasTokens = new List<string>();
            List<string> tokens = new List<string>();
            LineasTokens = Lexico.AnalizadorLexico(rtxtentrada.Text);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<string> LineasTokens = new List<string>();
            LineasTokens = Lexico.AnalizadorLexico(rtxtentrada.Text);

            int linea = 1;
            string Existe = "";
            string strActual = "";
            int temp;
            try
            {
                foreach (string cadena in LineasTokens)
                {
                    strActual = cadena;
                    strActual = strActual.Substring(0, strActual.Length - 1);
                    rtxtcodigointermedio.Text += cadena + "\n";
                    temp = strActual.Split(' ').Length;
                    while (temp > 0)
                    {
                            string[] strSubcadenas = CrearCombinaciones(temp, strActual);
                        if (!Revisar(CrearCombinaciones(temp, strActual), temp)) { temp--; }
                        else
                        {
                            foreach (string str in strSubcadenas)
                            {
                                if (str != "")
                                {
                                    string strCambio = str;
                                    foreach (SintaxLibre S in miSintaxis.Sintax)
                                    {
                                        strCambio = NormalizarCadena(str, temp);
                                        Existe = S.Exist(strCambio);
                                        if (Existe != strCambio)
                                        {
                                            strActual = strActual.Replace(str, Existe);
                                            break;
                                        }
                                    }
                                }
                            }
                            rtxtcodigointermedio.Text += strActual + "\n";
                            temp = strActual.Split(' ').Length;
                        }
                        txtcadenatokens.Text = strActual;
                        if (strActual == "S") { rtxSintaxLineaxLinea.Text += "Línea " + linea.ToString() + ":S" + "\n"; temp = 0; linea++; }
                    }
                }
                stopwatch.Stop();
               
                MessageBox.Show(stopwatch.Elapsed.ToString() + "ms", "Analizador sintáctico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(Exception ex) { MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
