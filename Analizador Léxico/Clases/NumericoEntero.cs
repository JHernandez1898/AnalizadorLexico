﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Léxico.Clases
{
    class NumericoEntero : IEquatable<NumericoEntero>, IComparable<NumericoEntero>
    {
        private int _intIndex;

        public int Index
        {
            get { return _intIndex; }
            set { _intIndex = value; }
        }
        private int _intCont;

        public int Contenido
        {
            get { return _intCont; }
            set { _intCont = value; }
        }
        public bool Equals(NumericoEntero otroNumero)
        {
            return (this.Index.Equals(otroNumero.Index));
        }
        public int CompareTo(NumericoEntero otroNumero)
        {
            return (this.Index.CompareTo(otroNumero.Index));
        }
        public NumericoEntero()
        {
        }
    }
}
