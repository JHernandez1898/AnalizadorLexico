using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quindim
{
    static class Program
    {
        public static string serverInstace = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (System.IO.File.Exists("Settings.qnd"))
            {
                BinaryFile<string> binaryFile = new BinaryFile<string>("Settings.qnd");
                binaryFile.OpenInReadWriteMode();
                Program.serverInstace = binaryFile.ReadObject();
                binaryFile.Close();
                Application.Run(new QuindimPad());
            }
            else
            {
                MessageBox.Show("Prepararemos todo para tí, te pedimos esperes un poco.", "¡Bienvenido a QuindimPad!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Run(new Settings());
            }
        }
    }
}
