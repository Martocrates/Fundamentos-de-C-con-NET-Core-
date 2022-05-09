using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Entidades


{
    public class Alumno
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public List<Evaluaciones> Evaluacion { get; set; }

        //--- CONSTRUCTOR ---
        public Alumno()
        {
            this.UniqueId = Guid.NewGuid().ToString();
            this.Evaluacion = new List<Evaluaciones>() { };
        }

    }
}