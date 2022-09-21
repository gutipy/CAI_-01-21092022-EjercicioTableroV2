using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTableroV2.Dominio.Excepciones
{
    public class FechaFinMayorAVencimientoException : Exception
    {
        public FechaFinMayorAVencimientoException() : base(
            "La fecha de finalización ingresada es mayor a la fecha de vencimiento que le corresponde a la tarea según la dificultad ingresada, intente nuevamente.")
        {

        }
    }
}
