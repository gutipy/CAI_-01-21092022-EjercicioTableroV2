using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTableroV2.Dominio.Excepciones
{
    public class FechaAltaMayorAFechaFinException : Exception
    {
        public FechaAltaMayorAFechaFinException() : base("La fecha de alta de una tarea no puede ser mayor a la fecha de finalización de la misma, por favor intente nuevamente.")
        {

        }
    }
}
