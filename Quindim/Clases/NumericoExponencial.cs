using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quindim.Clases
{
    public class NumericoExponencial : IEquatable<NumericoExponencial>, IComparable<NumericoExponencial>
    {
        private int _intIndex;

        public int Index
        {
            get { return _intIndex; }
            set { _intIndex = value; }
        }
        private int _intExponencial;

        public int Exponencial
        {
            get { return _intExponencial; }
            set { _intExponencial = value; }
        }
        private int _intContenido;

        public int Contenido
        {
            get { return _intContenido; }
            set { _intContenido = value; }
        }
        public bool Equals(NumericoExponencial otroNumero)
        {
            return (this.Contenido.Equals(otroNumero.Contenido));
        }
        public int CompareTo(NumericoExponencial otroNumero)
        {
            return (this.Index.CompareTo(otroNumero.Index));
        }

        public NumericoExponencial()
        {
        }
    }
}
