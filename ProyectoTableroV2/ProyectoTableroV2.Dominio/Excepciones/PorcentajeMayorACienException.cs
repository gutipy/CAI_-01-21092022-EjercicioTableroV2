using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTableroV2.Dominio;

namespace ProyectoTableroV2.Dominio.Excepciones
{
    public class PorcentajeMayorACienException : Exception
    {
        public PorcentajeMayorACienException() : base("El porcentaje ingresado hace que el porcentaje total supere el 100%, por favor ingrese otro porcentaje.")
        {

        }
    }
}
