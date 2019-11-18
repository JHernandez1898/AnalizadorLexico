using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using Quindim.Clases;

namespace Quindim
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            DataTable dataT = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow dr in dataT.Rows)
            {
                lblServidor.Text = lblServidor.Text == "Server" ? dr["ServerName"].ToString() : lblServidor.Text ;
                comboBox1.Items.Add(dr["InstanceName"]);
            }

        }

        private void BtnConectar_Click(object sender, EventArgs e)
        {

            try
            {
                if (ConexionMatriz.ProbarConexion(comboBox1.Text))
                {
                    MessageBox.Show("Conectado al servidor", "Lexico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MetodosAL.Servidor = comboBox1.Text;
                    lblconexion.BackColor = Color.Green;
                    MessageBox.Show(comboBox1.Text);
                    Program.serverInstace = comboBox1.Text;

                    BinaryFile<string> file = new BinaryFile<string>("Settings.qnd");
                    file.Close();
                    file.OpenInReadWriteMode();
                    file.WriteObject(Program.serverInstace);
                    file.Close();

                    MetodosAS.CrearMatriz();
                    MetodosSe.CrearMatriz();
                    btnOpt4 iloveQuindim = new btnOpt4();
                    this.Hide();
                    iloveQuindim.ShowDialog();
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Conexion fallida", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
