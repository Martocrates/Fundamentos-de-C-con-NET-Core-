using System;
using System.Collections.Generic;
using Etapa1.App;
using Etapa1.Entidades;
using Etapa1.Util;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {


            var engine = new EscuelaEngine();
            engine.Inicializar();

            Printer.DibujarLinea();

            ImprimirCursosEscuela(engine.Escuela);
            Printer.Beep(10000, cantidad:10);

        }

        private static void ImprimirCursosEscuela(Escuela escuela)//Forma de recorrer el arreglo utilizando el Ciclo While
        {
            Printer.WriteTitle("Cursos de la escuela");
          foreach (var curso in escuela.Cursos)
            {
                Console.WriteLine($"Nombre: {curso.Nombre},ID: {curso.UniqueId}");
            }
        }

    
    
    }
}
