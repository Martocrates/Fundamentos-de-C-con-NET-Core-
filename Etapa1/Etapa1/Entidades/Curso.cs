using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Entidades
{
    class Curso
    {
        public string UniqueId { get;private set; }
        public string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }

        public Curso()
        {
            UniqueId = Guid.NewGuid().ToString();
        }
    }
}
    