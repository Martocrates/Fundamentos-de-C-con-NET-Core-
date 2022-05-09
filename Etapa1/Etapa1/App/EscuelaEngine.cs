using Etapa1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Etapa1.App
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
            
        }
        public void Inicializar()
        {
            Escuela = new Escuela("Tecnologico de Merida", 1980, TiposEscuela.primaria,
                                      ciudad: "EUA");
            CargarCursos();
            CargarAsignaturas();

           
            
            CargarEvaluaciones();

        }

        private void CargarEvaluaciones()
        {
          foreach (var curso in Escuela.Cursos)
            {
                foreach(var asignatura in curso.Asignaturas)
                {
                    foreach(var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);
                        for(int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluaciones
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev# {i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluacion.Add(ev);
                        }
                    }
                }
            }
        }

        private void CargarAsignaturas()
        {
           foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura{Nombre = "Matematicas"},
                    new Asignatura{Nombre = "Educacion fisica"},
                    new Asignatura{Nombre = "Castellano"},
                    new Asignatura{Nombre = "Ciencias naturales"}
                };
                //  curso.Asignaturas.AddRange(listaAsignaturas);
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> CargarAlumnos(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };
            return listaAlumnos.OrderBy( (al)=> al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>()
            {
                new Curso(){Nombre = "101", Jornada = TiposJornada.Manana},
                new Curso(){Nombre = "201", Jornada = TiposJornada.Manana},
                new Curso(){Nombre = "301", Jornada = TiposJornada.Manana},
                new Curso { Nombre = "102", Jornada = TiposJornada.Tarde },
                new Curso { Nombre = "202", Jornada = TiposJornada.Tarde }
            };

            Random rnd = new Random();
            int cantRandom;
            foreach (var c in Escuela.Cursos)
            {
                cantRandom = rnd.Next(5, 20);
                c.Alumnos = CargarAlumnos(cantRandom);
            }
        }
    }
}
