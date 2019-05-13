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
