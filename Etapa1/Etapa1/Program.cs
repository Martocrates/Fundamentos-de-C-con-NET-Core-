using System;
using Etapa1.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Tecnologico de Merida", 1980, TiposEscuela.primaria,
                                       ciudad: "EUA");

            var arregloCursos = new Curso[3];

            arregloCursos[0] = new Curso()
            {
                Nombre = "101"
            };
            arregloCursos[1] = new Curso()
            {
                Nombre = "201"
            };
            arregloCursos[2] = new Curso()
            {
                Nombre = "301"
            };

            Console.WriteLine(escuela);
            Console.WriteLine("============================");
            ImprimirCursosWhile(arregloCursos);

            /* Una forma mas de imprimir los cursos
            var curso1 = new Curso()
            {
                Nombre = "101"
            };
            var curso2 = new Curso()
            {
                Nombre = "201"
            };
            var curso3 = new Curso()
            {
                Nombre = "301"
            };
            Console.WriteLine(escuela);
            Console.WriteLine("============================");
            Console.WriteLine(curso1.Nombre + ", " + curso1.UniqueId);
            Console.WriteLine(curso2.Nombre + ", " + curso2.UniqueId);
            Console.WriteLine(curso3.Nombre + ", " + curso3.UniqueId);
            */
        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)//Forma de recorrer el arreglo utilizando el Ciclo While
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre: {arregloCursos[contador].Nombre}, ID: {arregloCursos[contador].UniqueId}");
                contador++;
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)//Forma de recorrer el arreglo utilizando el Ciclo Do-While
        {
            int contador = 0;

            do
            {
                Console.WriteLine($"Nombre: {arregloCursos[contador].Nombre}, ID: {arregloCursos[contador].UniqueId}");
                contador++;
            }
            while (contador < arregloCursos.Length);

        }
        private static void ImprimirCursosFor(Curso[] arregloCursos) //Forma de recorrer el arreglo utilizando el Ciclo For
        {

            for (int i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine($"Nombre: {arregloCursos[i].Nombre}, ID: {arregloCursos[i].UniqueId}");

            }

        }
    }
}
