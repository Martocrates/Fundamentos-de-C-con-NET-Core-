using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Entidades
{
    class Escuela
    {

        string nombre;
        public string Nombre
        {
            get { return "Copia: " + nombre; }
            set { nombre = value.ToUpper(); }

        }
        public int AnioCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TiposEscuela TiposEscuela { get; set; }
       
        public Escuela(string nombre, int anio) => (Nombre, AnioCreacion) = (nombre, anio);
        public Escuela(string nombre, int anio, TiposEscuela tipo,
                       string pais = "", string ciudad = "")
        { (Nombre, AnioCreacion) = (nombre, anio);
            Pais = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre} Tipo: {TiposEscuela}\n Pais: {Pais}, Ciudad: {Ciudad}";
        }

    }
}
