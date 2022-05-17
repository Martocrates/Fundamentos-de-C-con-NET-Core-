using Etapa1.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {
        public int AñoDeCreacion { get; set; }

        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public string Direccion { get; set; }

        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }

        public Escuela(string nombre, int año) => (Nombre, AñoDeCreacion) = (nombre, año);

        public Escuela(string nombre, int año,
                       TiposEscuela tipo,
                       string pais = "", string ciudad = "") : base()
        {
            (Nombre, AñoDeCreacion) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
        }

        public void LimpiarLugar()
        {

            Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela..");

            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }

            Printer.WriteTitle($"Escuela {Nombre} Limpia");
            Printer.Beep(1000, cantidad: 3);
        }
    }
}
