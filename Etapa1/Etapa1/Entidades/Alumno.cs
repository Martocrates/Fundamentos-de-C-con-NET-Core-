using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Entidades


{
    public class Alumno: ObjetoEscuelaBase
    {
    

        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();


    }
}