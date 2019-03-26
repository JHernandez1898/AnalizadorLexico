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

        string strEntrada;
        char[] strCaracteres;
        bool BanderaCaracteres=false;
        int ContadorArreglo = 0;
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

        private void btnCaracterXCaracter_Click(object sender, EventArgs e)
        {
            if(BanderaCaracteres==false)
            {
                ContadorArreglo = 0;
                txtEstadoAnt.Text = "";
                string strEntrada = rtxtentrada.Text;
                strCaracteres =rtxtentrada.Text.ToCharArray();
                BanderaCaracteres = true;
                txtCaracter.Text = strCaracteres[ContadorArreglo].ToString();
                txtEstadoActual.Text = MetodosAL.CaracterPorCaracter(strCaracteres[ContadorArreglo], 0).ToString();
                ContadorArreglo++;
            }
            else
            {
                if(ContadorArreglo == strCaracteres.Length)
                {
                    txtEstadoAnt.Text = txtEstadoActual.Text;
                    txtEstadoActual.Text=MetodosAL.CaracterPorCaracter(' ', int.Parse(txtEstadoActual.Text)).ToString();
                    txtCaracter.Text = ' '+"del";
                    rtxtcodigointermedio.Text+= MetodosAL.ObtenerToken(int.Parse(txtEstadoActual.Text))+'\n';
                    txtEstadoAnt.Text = txtEstadoActual.Text;
                    txtEstadoActual.Text = "0";
                    BanderaCaracteres = false;
                    return;
                }
                if(txtEstadoActual.Text == "196")
                {
                    txtEstadoAnt.Text = txtEstadoActual.Text;
                    txtEstadoActual.Text = MetodosAL.CaracterPorCaracter('/', int.Parse(txtEstadoActual.Text)).ToString();
                    txtCaracter.Text = '/' + "del";
                    rtxtcodigointermedio.Text += MetodosAL.ObtenerToken(int.Parse(txtEstadoActual.Text)) + '\n';
                    txtEstadoAnt.Text = txtEstadoActual.Text;
                    txtEstadoActual.Text = "0";
                    BanderaCaracteres = false;
                    return;
                }
                if((strCaracteres[ContadorArreglo]==' '&&txtEstadoActual.Text!="195"))
                {
                    txtEstadoAnt.Text = txtEstadoActual.Text;
                    txtEstadoActual.Text = MetodosAL.CaracterPorCaracter(' ', int.Parse(txtEstadoActual.Text)).ToString();
                    txtCaracter.Text = ' ' + "del";
                    rtxtcodigointermedio.Text += MetodosAL.ObtenerToken(int.Parse(txtEstadoActual.Text)) + ' ';
                    txtEstadoAnt.Text = txtEstadoActual.Text;                   
                    ContadorArreglo++;
                    txtEstadoActual.Text = MetodosAL.CaracterPorCaracter(strCaracteres[ContadorArreglo], int.Parse(txtEstadoActual.Text)).ToString();
                    return;
                }
                if (MetodosAL.ObtenerToken(int.Parse(txtEstadoActual.Text))!="")
                {
                    MetodosAL.ObtenerToken(int.Parse(txtEstadoActual.Text));
                    txtEstadoAnt.Text = txtEstadoActual.Text;
                    txtEstadoActual.Text = "0";
                }
                else
                {
                    txtEstadoAnt.Text = txtEstadoActual.Text;
                    txtCaracter.Text = strCaracteres[ContadorArreglo].ToString();
                    txtEstadoActual.Text = MetodosAL.CaracterPorCaracter(strCaracteres[ContadorArreglo], int.Parse(txtEstadoActual.Text)).ToString();
                    ContadorArreglo++;
                }
            }
            
        }
    }

}
