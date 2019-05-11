using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Sintáctico.Clases
{
    public class SintaxLibre
    {
        private string _strSintaxIzquierda;

        public string SintaxIzquierda
        {
            get { return _strSintaxIzquierda; }
            set { _strSintaxIzquierda = value; }
        }

        public List<string> lstSintaxDerecha  = new List<string>();
        
        public string Exist(string other)
        {
            foreach (string Sintax in lstSintaxDerecha)
            {
                if (Sintax.Equals(other))
                {
                    return SintaxIzquierda;
                }
            }
            throw new Exception("El elemento no coinside con la sintaxis.");
        }
    }
}
