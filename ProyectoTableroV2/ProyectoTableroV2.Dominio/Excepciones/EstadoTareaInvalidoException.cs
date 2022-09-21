using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTableroV2.Dominio.Excepciones
{
    public class EstadoTareaInvalidoException : Exception
    {
        public EstadoTareaInvalidoException(string estado) : base("El estado de la tarea " + estado + " no corresponde a ningún tipo de tarea válido, por favor intente nuevamente.")
        {

        }
    }
}
