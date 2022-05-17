using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Entidades
{
    public interface ILugar
    {
        string Direccion { get; set; }

        void LimpiarLugar();

    }
}
