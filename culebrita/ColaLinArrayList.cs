using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace culebrita
{
    internal class ColaLinArrayList : IEnumerable, InterCola
    {
        protected int fin;
        protected int frente;

        protected ArrayList ColaArrayList;


        public ColaLinArrayList() {
            frente = 0;
            fin = -1;
            ColaArrayList = new ArrayList();
        }
        public void borrarCola()
        {
            frente = 0;
            fin = -1;
        }

        public bool colaVacia()
        {
            return frente > fin;
        }

        public object finalCola()
        {
            if (!colaVacia())
            {
                //devuelvve la cabeza
                return ColaArrayList[ColaArrayList.Count - 1];
            }
            else
            {
                throw new Exception("La cola está vacía");
            }
        }

        public void insertar(object elemento)
        {
                fin++;
            ColaArrayList.Add(elemento);

        }

        public object quitar()
        {
            return ColaArrayList[frente++];
        }

        public int tamano()
        {
            return (fin - frente) + 1;
        }

        public IEnumerator GetEnumerator()
        {

            for (int index = frente; index < fin; index++)
            {
                yield return ColaArrayList[index];
            }

        }
      
    }
}
