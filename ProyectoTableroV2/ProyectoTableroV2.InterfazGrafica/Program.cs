using ProyectoTableroV2.Dominio.Entidades;
using ProyectoTableroV2.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTableroV2.InterfazGrafica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaración de variables
            List<Tarea> _listadoTareas = new List<Tarea>();
            string _estado = "";
            string _opcionMenu = "";

            Tarea T1 = new TareaComun("Tarea Común 1", DateTime.Now.AddDays(-14), 1, DateTime.Now.AddDays(-3));
            Tarea T2 = new TareaEspecial("Tarea Especial 1", DateTime.Now, 2, DateTime.Now.AddDays(45), DateTime.Now.AddDays(30));

            Tablero tableroElectronico = new Tablero("Trabajo", "Contiene tareas de trabajo", DateTime.Now.AddYears(-2));

            tableroElectronico.AgregarTarea(T1);
            tableroElectronico.AgregarTarea(T2);

            //_listadoTareas = tableroElectronico.TraerTareas(estado);

            //Console.WriteLine(_listadoTareas);

            bool _consolaActiva = true;

            try
            {
                while (_consolaActiva)
                {
                    //Despliego en pantalla las opciones para que el usuario decida
                    OpcionesMenu();

                    //Se valida que la opcion ingresada no sea vacío y/o distinta de las opciones permitidas
                    FuncionValidacionOpcion(ref _opcionMenu);

                    //Estructura condicional para controlar el flujo del programa
                    switch (_opcionMenu)
                    {
                        case "1":
                            //Listar tareas del tablero por estado
                            Listar(tableroElectronico, _estado);
                            break;
                        case "2":
                            //Cambio el estado a una tarea del tablero
                            Cambiar(tableroElectronico);
                            break;
                        case "3":
                            //Agrego una tarea al tablero
                            Agregar(tableroElectronico);
                            break;
                        case "4":
                            //Salir del programa
                            Salir();
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static void OpcionesMenu()
        {
            Console.WriteLine(
                "Bienvenido al tablero! Seleccione una opción:" + Environment.NewLine +
                "1 - Listar tareas del tablero por estado" + Environment.NewLine +
                "2 - Cambiar el estado a una tarea" + Environment.NewLine +
                "3 - Agregar una tarea al tablero" + Environment.NewLine +
                "4 - Salir"
                )
                ;
        }

        //Método para listar las tareas del tablero por estado
        public static void Listar(Tablero _tablero, string estado)
        {
            //Declaración de variables
            string resultado = "";
            //Se valida que el estado ingresado no sea distinto de las opciones permitidas
            FuncionValidacionEstado(ref estado);

            _tablero.TraerTareas(estado, ref resultado);

            Console.WriteLine(resultado);

            Console.WriteLine("La tareas fueron listadas exitosamente arriba, presione Enter para elegir otra opción.");
            Console.ReadKey();
            Console.Clear();
        }

        //Método para cambiar el estado de una tarea que indique el usuario por codigo
        public static void Cambiar(Tablero t)
        {
            //Declaración de variables
            string _codigo;
            int _codigoValidado = 0;
            string _estado = "";
            bool flag;

            //Pido al usuario que ingrese el código de tarea y a la vez valido el input ingresado
            do
            {
                Console.WriteLine("Ingrese el código de la tarea que desea cambiar su estado");
                _codigo = Console.ReadLine();
                flag = FuncionValidacionCodigo(_codigo, ref _codigoValidado);

            } while (flag == false);

            Console.WriteLine("Ahora ingrese el estado que desea poner para la tarea con código " + _codigoValidado);

            //Se valida que el estado ingresado no sea distinto de las opciones permitidas
            FuncionValidacionEstado(ref _estado);

            //Llamo al método 'CambiarEstado' de la clase 'Tablero' para que busque el código y haga el cambio correspondiente
            t.CambiarEstado(_codigoValidado, _estado);
        }

        //Método para agregar una nueva tarea al tablero
        public static void Agregar(Tablero tableroElectronico)
        {
            //Declaración de variables
            string _opcion;
            string _descripcion;
            string _orden;
            int _ordenValidado = 0;
            string _fechaAlta;
            DateTime _fechaAltaValidada = DateTime.Now;
            string _fechaFin;
            DateTime _fechaFinValidada = DateTime.Now;
            string _dificultad;
            int _dificultadValidada = 0;
            DateTime _fechaVencimiento = DateTime.Now;
            bool flag;

            //Pregunto al usuario que tipo de tarea quiere ingresar al tablero
            Console.WriteLine("¿Que tipo de tarea desea cargar? Presione 1 si quiere cargar una tarea común, presione 2 si quiere cargar una tarea especial");
            _opcion = Console.ReadLine();

            if (_opcion == "1")
            {
                //Pido al usuario que ingrese los datos de la tarea y a la vez valido cada input ingresado
                do
                {
                    Console.WriteLine("Ingrese la descripción de la nueva tarea");
                    _descripcion = Console.ReadLine();
                    flag = FuncionValidacionCadena(ref _descripcion);

                } while (flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de alta de la nueva tarea");
                    _fechaAlta = Console.ReadLine();
                    flag = FuncionValidacionFechaAlta(_fechaAlta, ref _fechaAltaValidada);

                } while (flag == false);

                do
                {
                    Console.WriteLine("Ingrese el número de orden de la nueva tarea");
                    _orden = Console.ReadLine();
                    flag = FuncionValidacionNumero(_orden, ref _ordenValidado);

                } while (flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de finalización de la nueva tarea");
                    _fechaFin = Console.ReadLine();
                    flag = FuncionValidacionFechaFin(_fechaFin, ref _fechaFinValidada);

                } while (flag == false);

                //Instancio la clase Tarea Común y la agrego al Tablero
                Tarea tc = new TareaComun(
                    _descripcion,
                    _fechaAltaValidada,
                    _ordenValidado,
                    _fechaFinValidada
                    );

                tableroElectronico.AgregarTarea(tc);

                Console.WriteLine("La tarea fue agregada exitosamente al tablero, presione Enter para elegir otra opción.");
                Console.ReadKey();
                Console.Clear();
            }
            else if (_opcion == "2")
            {
                //Pido al usuario que ingrese los datos de la tarea y a la vez valido cada input ingresado
                do
                {
                    Console.WriteLine("Ingrese la descripción de la nueva tarea");
                    _descripcion = Console.ReadLine();
                    flag = FuncionValidacionCadena(ref _descripcion);

                } while (flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de alta de la nueva tarea");
                    _fechaAlta = Console.ReadLine();
                    flag = FuncionValidacionFechaAlta(_fechaAlta, ref _fechaAltaValidada);

                } while (flag == false);

                do
                {
                    Console.WriteLine(
                        "Ingrese la dificultad de la nueva tarea:" + Environment.NewLine +
                        "1 - Baja" + Environment.NewLine +
                        "2 - Moderada" + Environment.NewLine +
                        "3 - Alta" + Environment.NewLine
                        )
                        ;

                    _dificultad = Console.ReadLine();
                    flag = FuncionValidacionDificultad(_dificultad, ref _dificultadValidada, _fechaAltaValidada, ref _fechaVencimiento);

                } while (flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de finalización de la nueva tarea");
                    _fechaFin = Console.ReadLine();
                    flag = FuncionValidacionFechaFin(_fechaFin, ref _fechaFinValidada);

                } while (flag == false);

                //Instancio la clase Tarea Especial y la agrego al Tablero
                Tarea ts = new TareaEspecial(
                    _descripcion,
                    _fechaAltaValidada,
                    _dificultadValidada,
                    _fechaVencimiento,
                    _fechaFinValidada
                    )
                    ;

                tableroElectronico.AgregarTarea(ts);

                Console.WriteLine("La tarea fue agregada exitosamente al tablero, presione Enter para elegir otra opción.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void Salir()
        {
            Console.WriteLine("Usted ha salido del tablero, presione Enter");
            Console.ReadKey();

            Environment.Exit(0);
        }

        //Funciones que validan los inputs requeridos al usuario
        public static string FuncionValidacionOpcion(ref string opcion)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                opcion = Console.ReadLine();

                if (string.IsNullOrEmpty(opcion))
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }
                else if (opcion == "1" || opcion == "2" || opcion == "3" || opcion == "4")
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("ERROR! La opción " + opcion + " no es una opción válida, intente nuevamente.");
                }
            } while (flag == false);

            return opcion;
        }

        public static string FuncionValidacionEstado(ref string estado)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                Console.WriteLine("Los estados son: " + Environment.NewLine +
                    "No iniciada" + Environment.NewLine +
                    "En curso" + Environment.NewLine +
                    "Finalizada" + Environment.NewLine +
                    "Ingrese el estado:");

                estado = Console.ReadLine();

                if (estado == "No iniciada" || estado == "En curso" || estado == "Finalizada" || estado == "")
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("ERROR! El estado " + estado + " no es un estado válido, intente nuevamente.");
                }

            } while (flag == false);

            return estado;
        }

        public static bool FuncionValidacionCodigo(string codigo, ref int codigoValidado)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                if (!int.TryParse(codigo, out codigoValidado))
                {
                    Console.WriteLine("El código ingresado debe ser de tipo numérico, intente nuevamente.");
                }
                else if (codigoValidado <= 0)
                {
                    Console.WriteLine("El código ingresado debe ser mayor a cero, intente nuevamente");
                }
                else
                {
                    flag = true;
                }
            } while (flag == false);

            return flag;
        }

        public static bool FuncionValidacionCadena(ref string cadena)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(cadena))
            {
                Console.WriteLine("ERROR! El valor ingresado no puede ser vacío, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static bool FuncionValidacionNumero(string numero, ref int numeroValidado)
        {
            //Declaración de variables
            bool flag = false;

            if (!int.TryParse(numero, out numeroValidado))
            {
                Console.WriteLine("ERROR! El valor ingresado tiene que ser de tipo numérico, intente nuevamente.");
            }
            else if (numeroValidado <= 0)
            {
                Console.WriteLine("ERROR! El valor ingresado tiene que ser mayor a cero, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static bool FuncionValidacionFechaAlta(string fecha, ref DateTime fechaValidada)
        {
            //Declaración de variables
            bool flag = false;

            if (!DateTime.TryParse(fecha, out fechaValidada))
            {
                Console.WriteLine("ERROR! El valor ingresado tiene que ser de tipo fecha, intente nuevamente.");
            }
            else if (fechaValidada > DateTime.Now)
            {
                Console.WriteLine("ERROR! La fecha ingresada no puede ser superior al día de hoy, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static bool FuncionValidacionFechaFin(string fecha, ref DateTime fechaValidada)
        {
            //Declaración de variables
            bool flag = false;

            if (!DateTime.TryParse(fecha, out fechaValidada))
            {
                Console.WriteLine("ERROR! El valor ingresado tiene que ser de tipo fecha, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static bool FuncionValidacionDificultad(string dificultad, ref int dificultadValidada, DateTime fechaAlta, ref DateTime fechaVencimiento)
        {
            //Declaración de variables
            bool flag = false;

            if (!int.TryParse(dificultad, out dificultadValidada))
            {
                Console.WriteLine("ERROR! El valor ingresado tiene que ser de tipo numérico, intente nuevamente.");
            }
            else if (dificultadValidada <= 0 || dificultadValidada > 3)
            {
                Console.WriteLine("ERROR! La dificultad ingresada tiene que ser un número entre 1 y 3, intente nuevamente.");
            }
            else if (dificultadValidada == 1)
            {
                fechaVencimiento = fechaAlta.AddDays(30);
                flag = true;
            }
            else if (dificultadValidada == 2)
            {
                fechaVencimiento = fechaAlta.AddDays(45);
                flag = true;
            }
            else
            {
                fechaVencimiento = fechaAlta.AddDays(90);
                flag = true;
            }

            return flag;
        }
    }
}
