using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTableroV2.Dominio.Entidades
{
    public class TareaComun : Tarea
    {
        //Atributos
        protected int _orden;
        protected DateTime _fechaRealizacion;

        //Constructor
        public TareaComun(string descripcion, DateTime fechaAlta, int orden, DateTime fechaRealizacion) : base (descripcion, fechaAlta)
        {
            _orden = orden;
            _fechaRealizacion = fechaRealizacion;
        }

        //Propiedades
        public int Orden { get => _orden; }
        public DateTime FechaRealizacion { get => _fechaRealizacion; }
    }
}
