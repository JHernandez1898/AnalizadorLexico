using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lenguaje;
using System.Data.SqlClient;



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
           
            //ConexionBD.LlenarListaTokens(strEntrada, ref tokens);
            foreach (string token in tokens) rtxtcodigointermedio.Text += token + " ";
        }
    }
}
   /*     public void ObtenerToken(string Palabra, ref List<string> tokens)
        {
            int intEstadoActual = 0;
            bool bandera = false;
            foreach (char c in Palabra)
            {
                //if (c == '"' || (c == '-' && intEstadoActual != 0) || c == '/' && intEstadoActual != 0) { bandera = !bandera; }
                intEstadoActual = NuevoEstado(c, intEstadoActual,bandera);
                if (bandera)
                {
                    ObtenerToken(intEstadoActual);
                    intEstadoActual = 0;
                }
                //if (c == ' ' && bandera) { tokens.Add(ObtenerToken(intEstadoActual)); intEstadoActual = 0; }
            }
           
        }
        public int NuevoEstado(char c, int intEstadoActual,bool bandera)
        {
            int Estado = 0;

            using (SqlConnection con = ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand();
                comando = new SqlCommand("select [" + c.ToString() + "] from transicion where estado = " + intEstadoActual, con);
                if (c >= 'a' && c <= 'z' | c == 'ñ') comando = new SqlCommand("select [" + c.ToString() + "m] from transicion where estado = " + intEstadoActual, con);
                else if (c == ']') comando = new SqlCommand("select [" + c.ToString() + "]] from transicion where estado = " + intEstadoActual, con);
                SqlDataReader estado = comando.ExecuteReader();
                if (estado.Read()) Estado = estado.GetInt32(0);

                comando = new SqlCommand("SELECT TOKEN FROM TRANSICION WHERE ESTADO = " + Estado, con);
                estado = comando.ExecuteReader();
                if (estado.Read())
                {
                    if(!estado.IsDBNull(0))
                    bandera = true;
                }
            }
            return Estado;
        }
        public string ObtenerToken(int intEstadoActual)
        {
            string token = "";
            using (SqlConnection con = ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("select token from transicion where estado = " + intEstadoActual, con);
                SqlDataReader tok = comando.ExecuteReader();
                if (tok.Read()) token = tok.GetString(0);
            }
            return token;
        }
        SqlConnection ObtenerConexion()
        {
            SqlConnection con = new SqlConnection(@"Data Source=HERNANDEZ109; Initial Catalog = LENGUAJE; Server=HERNANDEZ109\SQLEXPRESS; Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
            con.Open();
            return (con);
        }
    }
}
*/
