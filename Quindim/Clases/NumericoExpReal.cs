using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quindim.Clases
{
     public class NumericoExpReal : IEquatable<NumericoExpReal>, IComparable<NumericoExpReal>
    {
        private int _intIndex;

        public int Index
        {
            get { return _intIndex; }
            set { _intIndex = value; }
        }
        private double _dblContenido;

        public double Contenido
        {
            get { return _dblContenido; }
            set { _dblContenido = value; }
        }
        private int _intExponencial;

        public int Exponencial
        {
            get { return _intExponencial; }
            set { _intExponencial = value; }
        }
        public bool Equals(NumericoExpReal otroNumero)
        {
            return (this.Contenido.Equals(otroNumero.Contenido));
        }
        public int CompareTo(NumericoExpReal otroNumero)
        {
            return (this.Index.CompareTo(otroNumero.Index));
        }
        public NumericoExpReal()
        {
        }
    }
}
