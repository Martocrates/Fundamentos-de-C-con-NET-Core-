using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Util
{
    public static class Printer
    {
        public static void DrawLine(int tam = 10)
        {
            Console.WriteLine("".PadLeft(tam, '='));
        }

        public static void PresioneENTER()
        {
            Console.WriteLine("Presione ENTER para continuar");
        }
        public static void WriteTitle(string titulo)
        {
            var tamaño = titulo.Length + 4;
            DrawLine(tamaño);
            Console.WriteLine($"| {titulo} |");
            DrawLine(tamaño);
        }

        public static void Beep(int hz = 2000, int tiempo = 500, int cantidad = 1)
        {
            while (cantidad-- > 0)
            {
                System.Console.Beep(hz, tiempo);
            }
        }
    }
}
