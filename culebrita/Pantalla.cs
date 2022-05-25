using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita
{
    internal class Pantalla
    {
        internal static void DibujaPantalla(Size size)
        {
            Console.Title = "Culebrita";
            Console.WindowHeight = size.Height + 2;
            Console.WindowWidth = size.Width + 2;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Black;
            for (int row = 0; row < size.Height; row++)
            {
                for (int col = 0; col < size.Width; col++)
                {
                    Console.SetCursorPosition(col + 1, row + 1);
                    Console.Write(" ");
                }
            }
        }



        internal static void MuestraPunteo(int punteo)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta;
            //(col, fila)
            Console.SetCursorPosition(20, 0);
            Console.Write($"Puntuación: {punteo.ToString("00000000")}");
        }

    }
}
