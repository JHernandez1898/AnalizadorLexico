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


namespace Analizador_Léxico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = ConexionMatriz.ObtenerConexion())
            {
                MessageBox.Show("Conexion chida, Todo chido.");
            }
        }

        private void btnleertodo_Click(object sender, EventArgs e)
        {
            rtxtcodigointermedio.Text = "";
            string strEntrada = rtxtentrada.Text;
            string[] strLineas = strEntrada.Split('\n');
            foreach (string Linea in strLineas)
            {
                List<string> tokens = new List<string>();

               MetodosAL.ObtenerToken(Linea, ref tokens);
                foreach (string token in tokens) rtxtcodigointermedio.Text += token +" " ;
                rtxtcodigointermedio.Text +="\n";
            }
        }

    }

}
