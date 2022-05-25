using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace culebrita 
{
    public class ColaLineal:IEnumerable, InterCola
    {
        protected int fin;
        private static int MAXTAM = 500;
        protected int frente;

        protected Object[] listaCola;

        public ColaLineal()
        {
            frente = 0;
            fin = -1;
            listaCola = new Object[MAXTAM];
        }

        public void insertar(Object elemento)
        {
        if (!colaLlena()) {
            fin++;
            listaCola[fin] = elemento;
        } else {
            throw new Exception("Overflow en la cola");
}
    }

    
        public Object quitar() 
        {
        if (!colaVacia()){
                //Object aux = listaCola[frente];
                //listaCola[frente] = null;
                //frente++;
                //return aux;
                return listaCola[frente++];

            } else {
            throw new Exception("Cola vacia");
}
    }

        public int tamano() {
            return (fin - frente)+1;
        }

public void borrarCola()
{
    frente = 0;
    fin = -1;
}

//public Object frenteCola() 
//{
//        if (!colaVacia()) {
//        return listaCola[frente];
//    } else {
//        throw new Exception("Cola vacia");
//    }
//}
        public Object finalCola()
        {
            if (!colaVacia())
            {
                return listaCola[fin];
            }
            else
            {
                throw new Exception("Cola vacia");
            }
        }


        public bool colaVacia()
{
    return frente > fin;
}

public bool colaLlena()
{
    return fin == MAXTAM-1;
}

        //implemento la clase Ienumerable para poder recorrer el vector


        public IEnumerator GetEnumerator()
        {

            for (int index = frente; index < fin; index++) { 
            yield return listaCola[index];
            }
            
        }
    }

}
