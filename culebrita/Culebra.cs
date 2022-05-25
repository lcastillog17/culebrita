using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace culebrita
{
    internal class Culebra {
        internal static Direction ObtieneDireccion(Direction direccionAcutal)
        {
            //mira si hay una tecla presionada y devuelve vedadero o falso
            if (!Console.KeyAvailable) return direccionAcutal;

            //en tecla se guarda lo que el usuario imprima
            var tecla = Console.ReadKey(true).Key;
            switch (tecla)
            {
                case ConsoleKey.DownArrow:
                    if (direccionAcutal != Direction.Arriba)
                        direccionAcutal = Direction.Abajo;
                    break;
                case ConsoleKey.LeftArrow:
                    if (direccionAcutal != Direction.Derecha)
                        direccionAcutal = Direction.Izquierda;
                    break;
                case ConsoleKey.RightArrow:
                    if (direccionAcutal != Direction.Izquierda)
                        direccionAcutal = Direction.Derecha;
                    break;
                case ConsoleKey.UpArrow:
                    if (direccionAcutal != Direction.Abajo)
                        direccionAcutal = Direction.Arriba;
                    break;
            }
            return direccionAcutal;
        }



        internal static Point ObtieneSiguienteDireccion(Direction direction, Point currentPosition)
        {
            Point siguienteDireccion = new Point(currentPosition.X, currentPosition.Y);
            switch (direction)
            {
                case Direction.Arriba:
                    siguienteDireccion.Y--;
                    break;
                case Direction.Izquierda:
                    siguienteDireccion.X--;
                    break;
                case Direction.Abajo:
                    siguienteDireccion.Y++;
                    break;
                case Direction.Derecha:
                    siguienteDireccion.X++;
                    break;
            }
            return siguienteDireccion;
        }



        internal static bool MoverLaCulebrita(InterCola culebra, Point posiciónObjetivo,
            int longitudCulebra, Size screenSize)
        {
            //devuelve la cabeza de la culebra
                
            var lastPoint = (Point) culebra.finalCola();
                
            if (lastPoint.Equals(posiciónObjetivo)) return true;

            //sustituye al any
            foreach (Point x in culebra)
            { 
                //si esto pasa pierde
                    if (x.Equals(posiciónObjetivo)) return false;
                break;
            }

            // if (culebra.Any(x => x.Equals(posiciónObjetivo))) return false;

            //si esto pasa pierde
            if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
                    || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)
            {
                return false;
            }

            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine(" ");

            culebra.insertar(posiciónObjetivo);

            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
            Console.Write(" ");

            // Quitar cola
            if (culebra.tamano() > longitudCulebra)
            {
                var removePoint = (Point)culebra.quitar();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }
            return true;
        }

        internal static Point MostrarComida(Size screenSize, InterCola culebra)
        {
            var lugarComida = Point.Empty;
            var cabezaCulebra = (Point)culebra.finalCola();
            //var cabezaCulebra = (Point) culebra.frenteCola();
            var rnd = new Random();
            do
            {
                //en x estoy guardando un valor random que esté entre 0 y el ancho de la pantalla
                var x = rnd.Next(0, screenSize.Width - 1);
                //en x estoy guardando un valor random que esté entre 0 y el largo de la pantalla
                var y = rnd.Next(0, screenSize.Height - 1);
                //el if dice que la comida no se ponga en ningun lugar de la culebra
                bool NoApareceEnCulebra = true;

                foreach (Point m in culebra)
                {
                            if (m.X == x || m.Y == y)
                            {
                        NoApareceEnCulebra = false;

                            }
                 }

                //esto es para que la comida no quede tan cerca de la culebrita
                    if (NoApareceEnCulebra && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
                    {
                        lugarComida = new Point(x, y);
                    }

                    //if (culebra.All(p => p.X != x || p.Y != y)
                    //    && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
                    //{
                    //   lugarComida = new Point(x, y);
                    //}

                
            } while (lugarComida == Point.Empty);

                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
                Console.Write(" ");

                return lugarComida;


            }
    }
} 
