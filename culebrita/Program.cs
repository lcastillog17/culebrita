using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace culebrita
{
    class Program
    {

        //jjjj  convertirlo en un programa orietado a objetos     siuuuu
        //jjjj  emitir beep cuando coma la comida     siuuuu                                                
        //jjjj  incrementar la velocidad conforme vaya avanzando
        //jjjj  modificar el uso de queue y reemplazarlo con la estructura de cola vista en clase
        //jjjj  colalinal arreglo 
        //jjjj  cola lineal  usando arrayList
        //cola lista enlazada
        // explicar qué pasa al alterar cada una de las lineas marcadas con las preguntas
        // se aprecia si pueden cambiar las reglas del juego o si le agrega cosas extra



        static void Main()
        {
            var punteo = 0;
            var velocidad = 100; //modificar estos valores y ver qué pasa //mientras menor es, más rápido
            var posiciónComida = Point.Empty;
            var tamañoPantalla = new Size(60, 20);
            //var culebrita = new ColaListaEnlazada();
            var culebrita = new ColaLinArrayList();
            //var culebrita = new ColaLineal();
            var longitudCulebra = 3; //modificar estos valores y ver qué pasa //este es el tamaño con que empezará a disminuir el fin de la cola, osea cuando se va mover
            var posiciónActual = new Point(0, 9); //modificar estos valores y ver qué pasa
            culebrita.insertar(posiciónActual);
            //culebrita.insertar(posiciónActual);
            var dirección = Direction.Derecha; //modificar estos valores y ver qué pasa //es hacia donde va la culebrita pero si va a la izquierda pierde por el putno en el que sale

            Pantalla.DibujaPantalla(tamañoPantalla);
            Pantalla.MuestraPunteo(punteo);

            while (Culebra.MoverLaCulebrita(culebrita, posiciónActual, longitudCulebra, tamañoPantalla))
            {
                //pausa el programa por los milisegundos indicados
                Thread.Sleep(velocidad);
                dirección = Culebra.ObtieneDireccion(dirección);
                posiciónActual = Culebra.ObtieneSiguienteDireccion(dirección, posiciónActual);

                if (posiciónActual.Equals(posiciónComida))
                {
                    Console.Beep();
                    posiciónComida = Point.Empty;
                    longitudCulebra++; //modificar estos valores y ver qué pasa //en vez de crecer se disminuirá al comer 
                    punteo += 10; //modificar estos valores y ver qué pasa //se reestaran los 10 o se sumará menos puntaje cada vez que coma
                    velocidad -= 1; //para que la velocidad se aumente al comer un frijol
                    Pantalla.MuestraPunteo(punteo);
                }

                //cada vez que se coma la comida se reicia para mostrar de nuevo la comida en otro lado


                if (posiciónComida == Point.Empty) //entender qué hace esta linea
                {
                    posiciónComida = Culebra.MostrarComida(tamañoPantalla, culebrita);
                }
            }

            Console.ResetColor();
            Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, tamañoPantalla.Height / 2);
            Console.Write("Fin del Juego");
            Thread.Sleep(2000);
            Console.ReadKey();


        }


    }//end class
}













