using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTableroV2.Dominio.Excepciones;

namespace ProyectoTableroV2.Dominio.Entidades
{
    public class Tablero
    {
        //Atributos
        private string _titulo;
        private string _descripcion;
        private List<Tarea> _tareas;
        private DateTime _fechaInicioProyecto;

        //Constructor
        public Tablero(string titulo, string descripcion, DateTime fechaInicioProyecto)
        {
            _titulo = titulo;
            _descripcion = descripcion;
            _tareas = new List<Tarea>();
            _fechaInicioProyecto = fechaInicioProyecto;
        }

        //Propiedades
        public string Titulo { get => _titulo; }
        public string Descripcion { get => _descripcion; }
        public List<Tarea> Tareas { get => _tareas; }
        public DateTime FechaInicioProyecto { get => _fechaInicioProyecto; }

        //Método para agregar una tarea al tablero
        public void AgregarTarea(Tarea tarea)
        {
            //Asignación del código de tarea de manera incremental
            tarea.Codigo = _tareas.Count + 1;

            if (tarea is TareaEspecial)
            {
                TareaEspecial tareaEspecial = (TareaEspecial)tarea;

                if (tareaEspecial.FechaRealizacion > tareaEspecial.FechaVencimiento)
                {
                    throw new FechaFinMayorAVencimientoException();
                }
                else
                {
                    _tareas.Add(tarea);
                }
            }
            else if (tarea is TareaComun)
            {
                TareaComun tareaComun = (TareaComun)tarea;

                if (tareaComun.FechaAlta > tareaComun.FechaRealizacion)
                {
                    throw new FechaAltaMayorAFechaFinException();
                }

                _tareas.Add(tarea);
            }

        }

        //Método para cambiar el estado de una tarea
        public string CambiarEstado(int codigo, string estado)
        {
            //Declaración de variables
            string resultado;

            foreach (Tarea t in _tareas)
            {
                if (t.Codigo == codigo)
                {
                    t.Estado = estado;
                }
            }

            resultado = "Cambio satisfactorio! La tarea con codigo " + codigo + " ahora posee el estado " + estado;

            return resultado;
        }

        //Función para listar las tareas del tablero
        public List<Tarea> TraerTareas(string estado, ref string acumulador)
        {
            //Declaración de lista
            List<Tarea> _tareasTablero = new List<Tarea>();

            if (string.IsNullOrEmpty(estado))
            {
                foreach (Tarea t in _tareas)
                {
                    _tareasTablero.Add(t);

                    if (t is TareaComun)
                    {
                        TareaComun tareaComun = (TareaComun)t;

                        acumulador +=
                            "Código: " + t.Codigo + Environment.NewLine +
                            "Descripción: " + t.Descripcion + Environment.NewLine +
                            "Estado: " + t.Estado + Environment.NewLine +
                            "Orden: " + tareaComun.Orden + Environment.NewLine +
                            "Fecha de Alta: " + t.FechaAlta + Environment.NewLine +
                            "Fecha de Realización: " + tareaComun.FechaRealizacion + Environment.NewLine
                            ;
                    }
                    else
                    {
                        TareaEspecial tareaEspecial = (TareaEspecial)t;

                        acumulador +=
                            "Código: " + t.Codigo + Environment.NewLine +
                            "Descripción: " + t.Descripcion + Environment.NewLine +
                            "Estado: " + t.Estado + Environment.NewLine +
                            "Fecha de Alta: " + t.FechaAlta + Environment.NewLine +
                            "Fecha de vencimiento: " + tareaEspecial.FechaVencimiento + Environment.NewLine +
                            "Fecha de Realización: " + tareaEspecial.FechaRealizacion + Environment.NewLine +
                            "Dificultad: " + tareaEspecial.Dificultad + Environment.NewLine +
                            "Porcentaje realizado: " + tareaEspecial.PorcentajeRealizado + Environment.NewLine
                            ;
                    }
                }
            }
            else
            {
                foreach (Tarea t in _tareas)
                {
                    if (t.Estado == estado)
                    {
                        _tareasTablero.Add(t);

                        if (t is TareaComun)
                        {
                            TareaComun tareaComun = (TareaComun)t;

                            acumulador +=
                                "Código: " + t.Codigo + Environment.NewLine +
                                "Descripción: " + t.Descripcion + Environment.NewLine +
                                "Estado: " + t.Estado + Environment.NewLine +
                                "Orden: " + tareaComun.Orden + Environment.NewLine +
                                "Fecha de Alta: " + t.FechaAlta + Environment.NewLine +
                                "Fecha de Realización: " + tareaComun.FechaRealizacion
                                ;
                        }
                        else
                        {
                            TareaEspecial tareaEspecial = (TareaEspecial)t;

                            acumulador +=
                                "Código: " + t.Codigo + Environment.NewLine +
                                "Descripción: " + t.Descripcion + Environment.NewLine +
                                "Estado: " + t.Estado + Environment.NewLine +
                                "Fecha de Alta: " + t.FechaAlta + Environment.NewLine +
                                "Fecha de vencimiento: " + tareaEspecial.FechaVencimiento + Environment.NewLine +
                                "Fecha de Realización: " + tareaEspecial.FechaRealizacion + Environment.NewLine +
                                "Dificultad: " + tareaEspecial.Dificultad + Environment.NewLine +
                                "Porcentaje realizado: " + tareaEspecial.PorcentajeRealizado + Environment.NewLine
                                ;
                        }
                    }
                }  
            }

            if (_tareasTablero.Count == 0)
            {
                throw new EstadoTareaInvalidoException(estado);
            }

            return _tareasTablero;
        }

        //Función para buscar y traer la tarea más antigua del tablero
        public Tarea TraerTareaMasAntigua()
        {
            //Declaración de variables
            DateTime _fechaAltaTareaMasAntigua = DateTime.Now;
            Tarea resultado = null;


            foreach (Tarea t in _tareas)
            {
                if (t.FechaAlta < _fechaAltaTareaMasAntigua)
                {
                    _fechaAltaTareaMasAntigua = t.FechaAlta;
                    resultado = t;
                }
            }

            return resultado;
        }
    }
}
