﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Entidades
{
    public abstract class ObjetoEscuelaBase
    {

        public string UniqueId { get; private set; } 
        public string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre}, {UniqueId}";
        }
    }
}