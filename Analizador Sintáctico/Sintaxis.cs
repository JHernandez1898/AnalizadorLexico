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
        public Sintaxis()
        {
            InitializeComponent();
        }

        private void btnleertodo_Click(object sender, EventArgs e)
        {
            rtxtcodigointermedio.Text = "";
            List<string> LineasLexico = new List<string>();
            LineasLexico = Lexico.AnalizadorLexico(rtxtentrada.Text);
            foreach (string Linea in LineasLexico)
            {
                rtxtcodigointermedio.Text += Linea + "\n";
            }
        }
    }
}
