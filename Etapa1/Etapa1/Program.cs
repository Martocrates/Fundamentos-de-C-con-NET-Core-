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
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");

            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evList = reporteador.GetListaEvaluaciones();
            var listaAsig = reporteador.GetListaAsignaturas();
            var listaEvalXAsig = reporteador.GetDiccionarioEvaluacionesPorAsignatura();
            var listaPromXAsig = reporteador.GetPromedioAlumnosXAsignatura();
            var topEstudiantes = reporteador.GetTopEstudiantesXAsignatura(5);


            /* Reto final.
            El último reto del curso colocará a prueba todos los conocimientos que has aprendido a lo largo del curso y te permitirá afianzar todos los conocimientos.
            Debes crear distintos métodos para mostrar por consola cada uno de los reportes, debe mantener una vista agradable y es más importante una buena experiencia del usuario al leer la información que la cantidad mostrada. */

            int selección = 1;
            string _selección;
            string _selector;
            int selector = 0;
            while (selección == 1)
            {
                Printer.WriteTitle("Seleccione el reporte a imprimir.");
                Console.WriteLine("(1) Nombre de la escuela.");
                Console.WriteLine("(2) Lista de cursos.");
                Console.WriteLine("(3) Reporte de evaluaciones.");
                Console.WriteLine("(4) Reporte de asignaturas.");
                Console.WriteLine("(5) Reporte de evaluaciones por asignatura.");
                Console.WriteLine("(6) Reporte del promedio de alumnos por asignatura.");
                Console.WriteLine("(7) Reporte Top X de estudiantes por asignatura.");
                Console.WriteLine("Presione 0 para salir.");
                Printer.PresioneENTER();
                _selector = Console.ReadLine();
                selector = int.Parse(_selector);

                switch (selector)
                {
                    case 0:
                        Console.WriteLine("Saliendo...");
                        selección = 0;
                        break;
                    case 1:
                        Console.WriteLine(engine.Escuela);
                        break;
                    case 2:
                        ImpimirCursosEscuela(engine.Escuela);
                        break;
                    case 3:
                        reporteador.ImprimirEvaluaciones();
                        break;
                    case 4:
                        reporteador.ImprimirAsignaturas();
                        break;
                    case 5:
                        reporteador.ImprimirEvaluacionesXAsignatura();
                        break;
                    case 6:
                        reporteador.ImprimirPromedioAlumnosXAsignatura();
                        break;
                    case 7:
                        int cantidad;
                        string _cantidad;
                        Console.WriteLine("Digite la cantidad Top de estudiantes.");
                        _cantidad = Console.ReadLine();
                        cantidad = int.Parse(_cantidad);
                        reporteador.ImprimirTopPromediosXAsignatura(cantidad);
                        break;
                    default:
                        Console.WriteLine("Selección errónea.");
                        Console.WriteLine("Saliendo...");
                        break;
                }
                Console.WriteLine("Presione 0 para salir, presione 1 para otro reporte.");
                _selección = Console.ReadLine();
                selección = int.Parse(_selección);
            }
        }


        private static void ImpimirCursosEscuela(Escuela escuela)
        {

            Printer.WriteTitle("Cursos de la Escuela");


            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    Console.WriteLine($"Nombre del curso: {curso.Nombre  }, Id:  {curso.UniqueId}");
                }
            }
        }
    }
}
