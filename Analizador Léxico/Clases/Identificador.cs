using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Analizador_Léxico.Clases
{
    public class Identificador :IEquatable<Identificador>
    {
        private int _intIndex;

        public int Index
        {
            get { return _intIndex; }
            set { _intIndex = value; }
        }


        private string _strNombre;

        public string Nombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }
        private string _strTipo;

        public string Tipo
        {
            get { return _strTipo; }
            set { _strTipo = value; }
        }
        private object _objCont;

        public object Contenido
        {
            get { return _objCont; }
            set
            {
                _objCont = value;
                if (value is NumericoEntero || value is NumericoExponencial)
                    this.Tipo = "int";
                if (value is NumericoExpReal || value is NumericoReal)
                    this.Tipo = "double";
            }
        }
        public bool Equals(Identificador otroidentificador)
        {
            return (this.Nombre == otroidentificador.Nombre);
        }
    }
}
