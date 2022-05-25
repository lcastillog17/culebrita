using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace culebrita
{
    internal interface InterCola
    {
        public void insertar(Object elemento);
        public Object quitar();
        public int tamano();
        public void borrarCola();
        public Object finalCola();
        public bool colaVacia();

        public IEnumerator GetEnumerator();

    }
}
