using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProyectoTableroV2.Dominio.Excepciones;

namespace ProyectoTableroV2.Dominio.Entidades
{
    public class TareaEspecial : Tarea
    {
        //Atributos
        protected int _dificultad;
        protected double _porcentajeRealizado;
        protected DateTime _fechaVencimiento;
        protected DateTime _fechaRealizacion;

        //Constructor
        public TareaEspecial(string descripcion, DateTime fechaAlta, int dificultad) : base(descripcion, fechaAlta)
        {
            _dificultad = dificultad;
            _porcentajeRealizado = 0;
        }

        //Propiedades
        public int Dificultad { get => _dificultad; }
        public double PorcentajeRealizado { get => _porcentajeRealizado; }
        public DateTime FechaVencimiento { get => _fechaVencimiento; }
        public DateTime FechaRealizacion { get => _fechaRealizacion; }

        //Métodos
        public void AumentarPorcentajeRealizacion(double porcentajeAumento)
        {
            if((porcentajeAumento + _porcentajeRealizado) > 100)
            {
                throw new PorcentajeMayorACienException();
            }
            else
            {
                _porcentajeRealizado += porcentajeAumento;
            }
        }

        public void DefinirFechaVencimientoSegunDificultad(int dificultad)
        {
            if (dificultad == 1)
            {
                _fechaVencimiento = FechaAlta.AddDays(30);
            }
            else if (dificultad == 2)
            {
                _fechaVencimiento = FechaAlta.AddDays(45);
            }
            else
            {
                _fechaVencimiento = FechaAlta.AddDays(90);
            }
        }

        public void ValidarFecha()
        {
            if (FechaAlta > FechaRealizacion)
            {
                throw new FechaAltaMayorAFechaFinException();
            }
            else if (FechaRealizacion > FechaVencimiento)
            {
                throw new FechaFinMayorAFechaVencException();
            }
        }
    }
}
