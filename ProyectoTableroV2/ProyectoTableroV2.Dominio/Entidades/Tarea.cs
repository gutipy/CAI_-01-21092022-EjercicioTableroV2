using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTableroV2.Dominio
{
    public abstract class Tarea
    {
        //Atributos
        private int _codigo;
        private string _descripcion;
        private string _estado;
        private DateTime _fechaAlta;

        //Constructor
        public Tarea(string descripcion, DateTime fechaAlta)
        {
            _descripcion = descripcion;
            _estado = "No iniciada";
            _fechaAlta = fechaAlta;
        }

        //Propiedades
        public int Codigo { get => _codigo; set => _codigo = value; }
        public string Descripcion { get => _descripcion; }
        public string Estado { get => _estado; set => _estado = value; }
        public DateTime FechaAlta { get => _fechaAlta; }

        //Método para validar si la tarea está finalizada
        public bool IsFinalizada()
        {
            if (Estado == "Finalizada")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
