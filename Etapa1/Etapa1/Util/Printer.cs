using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tam = 10)
        {
            Console.WriteLine("".PadLeft(tam,'='));
        }
        public static void WriteTitle(string titulo)
        {
            DibujarLinea(titulo.Length);
            Console.WriteLine(titulo.ToUpper());
            DibujarLinea(titulo.Length);
        }

        public static void Beep(int hz = 2000, int tiempo=500, int cantidad=1)
        {
            while (cantidad-- > 0)
            {
                Console.Beep(hz, tiempo);
            }
        }
    }
}
