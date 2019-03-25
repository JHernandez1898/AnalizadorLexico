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
using Lenguaje;



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

        }

        private void btnleertodo_Click(object sender, EventArgs e)
        {
            rtxtcodigointermedio.Text = "";
            string strEntrada = rtxtentrada.Text;
            List<string> tokens = new List<string>();
            ConexionBD.ObtenerToken(strEntrada, ref tokens);
            foreach (string token in tokens) rtxtcodigointermedio.Text += token + " ";
        }

        private void rtxtcodigointermedio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnleersiguiente_Click(object sender, EventArgs e)
        {

        }
    }

}
