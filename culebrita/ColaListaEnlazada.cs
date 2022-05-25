using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita
{
    internal class ColaListaEnlazada : InterCola, IEnumerable
    {
        protected int fin;
        protected int frente;
        protected LinkedList<Object> ColaLinkedList;

        public ColaListaEnlazada() {
            frente = 0;
            fin = -1;
            ColaLinkedList = new LinkedList<Object>();
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

        //devuelve la cabeza de la culebra
        public Object finalCola()
        {
            //if (!colaVacia())
            //{

                return ColaLinkedList.Last();

            //}
            //else {
            //    throw new Exception("La cola está vacía");
            //}
        }

        public IEnumerator GetEnumerator()
        {
            foreach(Point i in ColaLinkedList) {
                yield return i;
            }
        }

        public void insertar(Object elemento)
        {
            fin++;
            ColaLinkedList.AddLast((Point)elemento);
        }

        public object quitar()
        {
            frente++;
            var aux= ColaLinkedList.First();
            ColaLinkedList.RemoveFirst();
            return aux;
        }

        public int tamano()
        {
            return (fin - frente)+1;
        }
    }
}
