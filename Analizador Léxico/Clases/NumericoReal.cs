using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Léxico.Clases
{
    public class NumericoReal : IEquatable<NumericoReal>, IComparable<NumericoReal>
    {
        private int _intIndex;

        public int Index
        {
            get { return _intIndex; }
            set { _intIndex = value; }
        }
        private double _dblCont;

        public double Contenido
        {
            get { return _dblCont; }
            set { _dblCont = value; }
        }
        public bool Equals(NumericoReal otroNumero)
        {
            return (this.Index.Equals(otroNumero.Index));
        }
        public int CompareTo(NumericoReal otroNumero)
        {
            return (this.Index.CompareTo(otroNumero.Index));
        }
        public NumericoReal()
        {
        }
    }
}
