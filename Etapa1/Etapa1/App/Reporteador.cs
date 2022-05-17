using Etapa1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etapa1.Util;
namespace Etapa1.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjEsc)
        {
            if (dicObjEsc == null)
            {
                throw new ArgumentNullException(nameof(dicObjEsc));
            }
            _diccionario = dicObjEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            // var lista = _diccionario.GetValueOrDefault(LlaveDiccionario.Escuela);
            // IEnumerable<Escuela> rta;
            if (_diccionario.TryGetValue(
                LlaveDiccionario.Evaluacion,
                out IEnumerable<ObjetoEscuelaBase> lista
            ))
            {
                return lista.Cast<Evaluacion>();
            }
            {
                return new List<Evaluacion>();
            }
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dumy);
        }
        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            return (from Evaluacion ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDiccionarioEvaluacionesPorAsignatura()
        {
            var diccionarioRta = new Dictionary<string, IEnumerable<Evaluacion>>();

            var listaAsignaturas = GetListaAsignaturas(out var listaEvaluaciones);

            foreach (var asig in listaAsignaturas)
            {
                var evalAsig = from eval in listaEvaluaciones
                               where eval.Asignatura.Nombre == asig
                               select eval;
                diccionarioRta.Add(asig, evalAsig);
            }
            return diccionarioRta;
        }

        public Dictionary<string, IEnumerable<AlumnoPromedio>> GetPromedioAlumnosXAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<AlumnoPromedio>>();
            var diccionarioEvXAsig = GetDiccionarioEvaluacionesPorAsignatura();
            foreach (var asigConEval in diccionarioEvXAsig)
            {
                var promsAlumnos = from eval in asigConEval.Value
                                   group eval by new
                                   {
                                       eval.Alumno.UniqueId,
                                       eval.Alumno.Nombre
                                   }
                           into grupoEvalAlumno
                                   select new AlumnoPromedio
                                   {
                                       alumnoid = grupoEvalAlumno.Key.UniqueId,
                                       alumnoNombre = grupoEvalAlumno.Key.Nombre,
                                       promedio = grupoEvalAlumno.Average(evaluacion => evaluacion.Nota)
                                   };
                rta.Add(asigConEval.Key, promsAlumnos);
            }

            return rta;
        }

        /* Reto 2.
        */

        public Dictionary<string, IEnumerable<AlumnoPromedio>> GetTopEstudiantesXAsignatura(int cantidad)
        {
            var rta = new Dictionary<string, IEnumerable<AlumnoPromedio>>();
            var listaPromedioXAsignatura = GetPromedioAlumnosXAsignatura();
            foreach (var listaPromedio in listaPromedioXAsignatura)
            {
                var lista = listaPromedio.Value.OrderByDescending(eva => eva.promedio).Take(cantidad);
                rta.Add(listaPromedio.Key, lista);
            }

            return rta;
        }
        public void ImprimirEvaluaciones()
        {
            var eval = GetListaEvaluaciones();
            Printer.WriteTitle("Lista de Evaluaciones por alumno.");
            foreach (var lista in eval)
            {
                Console.WriteLine($"Nombre de la evaluación: {lista.Nombre}{System.Environment.NewLine}Asignatura: {lista.Asignatura.Nombre} {System.Environment.NewLine}Nombre del estudiante: {lista.Alumno.Nombre} Nota: {lista.Nota}{System.Environment.NewLine}=====");
            }
        }
        public void ImprimirAsignaturas()
        {
            var asig = GetListaAsignaturas();
            Printer.WriteTitle("Lista de Asignaturas.");
            foreach (var lista in asig)
            {
                Console.WriteLine($"Nombre de la asignatura: {lista}");
            }
        }

        public void ImprimirEvaluacionesXAsignatura()
        {
            var evXAsig = GetDiccionarioEvaluacionesPorAsignatura();
            Printer.WriteTitle("Lista de Evaluaciones por Asignatura.");
            foreach (var lista in evXAsig)
            {
                Printer.WriteTitle($"Asignatura: {lista.Key}");
                foreach (var eval in lista.Value)
                {
                    Console.WriteLine($"Nombre de la evaluación: {eval.Nombre}{System.Environment.NewLine}Nombre del estudiante: {eval.Alumno.Nombre}{System.Environment.NewLine}Nota: {eval.Nota}");
                }
            }
        }
        public void ImprimirPromedioAlumnosXAsignatura()
        {
            var proms = GetPromedioAlumnosXAsignatura();
            Printer.WriteTitle("Promedio de Alumnos por Asignatura");
            foreach (var lista in proms)
            {
                Printer.WriteTitle($"Asignatura: {lista.Key}");
                foreach (var prom in lista.Value)
                {
                    Console.WriteLine($"Nombre del estudiante: {prom.alumnoNombre} Promedio: {prom.promedio}");
                }
            }
        }
        public void ImprimirTopPromediosXAsignatura(int cantidad)
        {
            var top = GetTopEstudiantesXAsignatura(cantidad);
            Printer.WriteTitle($"Top {cantidad} estudiantes por asignatura.");
            foreach (var lista in top)
            {
                Printer.WriteTitle($"Asignatura: {lista.Key}");
                foreach (var est in lista.Value)
                {
                    Console.WriteLine($"Nombre del estudiante: {est.alumnoNombre} - Promedio {est.promedio}");
                }
            }
        }
    }
}
