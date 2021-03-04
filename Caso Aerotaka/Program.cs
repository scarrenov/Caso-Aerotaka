using System;
using System.Collections.Generic;
using System.Linq;

namespace Caso_Aerotaka
{
    internal static class Program
    {
        private static void Main()
        {
            ObjectController.Cargar(out var clientes,out var reservas,out var distribuciones,out var personal,out var aeronaves,out var trayectos);
            Console.WriteLine("Ingresar como:");
            Console.WriteLine("1. Cliente");
            Console.WriteLine("2. Departamento de mercadeo");
            Console.WriteLine("3. Administracion");
            var index = Convert.ToInt32(Console.ReadLine());
            switch (index)
            {
                case 1: // Cliente
                    Console.WriteLine("1. Registrarse");
                    Console.WriteLine("2. Reservar vuelo");
                    var usuarioIndex = Convert.ToInt32(Console.ReadLine());

                    switch (usuarioIndex)
                    {
                        case 1: // Registrarse
                            var nuevoCliente = RegistrarCliente();
                            clientes.Add(nuevoCliente);
                            ObjectController.GuardarClientes(clientes);
                            break;
                        case 2: // Vuelos disponibles y reservar
                            bool isValidId;
                            Cliente cliente;
                            do
                            {
                                Console.Write("Ingrese su ID: ");
                                var id = Convert.ToInt32(Console.ReadLine());
                                isValidId = ObjectController.BuscarClientePorId(clientes, id, out cliente);
                            } while (!isValidId);

                            Console.WriteLine("Usuario identificado exitosamente");
                            Console.Write("Ingrese su ciudad destino: ");
                            var ciudadDestino = Console.ReadLine();
                            var trayectosDisponibles = ObjectController.BuscarVueloPorDestino(trayectos, ciudadDestino);
                            if (trayectosDisponibles != null)
                            {
                                var reserva = SeleccionarTrayecto(trayectosDisponibles, cliente);
                                reservas.Add(reserva);
                                ObjectController.GuardarReservas(reservas);
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron vuelos disponibles para su destino seleccionado");
                            }
                            break;
                    }
                    break;
                case 2: // Dpto de mercadeo
                    ObjectController.ListarClientes(clientes);
                    Console.Clear();
                    break;
                case 3: // Admin
                    Console.WriteLine("1. Registrar aeronave");
                    Console.WriteLine("2. Registrar trayecto");
                    Console.WriteLine("3. Registrar distribución de aeronaves");
                    Console.WriteLine("4. Registrar personal");
                    Console.WriteLine("5. Buscar tripulación asignada a una aeronave");
                    Console.WriteLine("6. Listar todos los clientes pertenecientes a una ciudad");
                    var adminIndex = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    switch (adminIndex)
                    {
                        case 1:
                            Console.Write("Número de aeronave: ");
                            var numero = Console.ReadLine();
                            Console.Write("Tipo de avión: ");
                            var tipoAvion = Console.ReadLine();
                            Console.Write("Cupo máximo: ");
                            var cupo = Convert.ToInt32(Console.ReadLine());
                            aeronaves.Add(new Aeronave(numero, tipoAvion, cupo));
                            ObjectController.GuardarAeronaves(aeronaves);
                            break;
                        case 2:
                            var newTrayecto = CrearTrayecto();
                            trayectos.Add(newTrayecto);
                            ObjectController.GuardarTrayectos(trayectos);
                            break;
                        case 3:
                            var newDistribucion = CrearDistribucion(aeronaves, trayectos);
                            distribuciones.Add(newDistribucion);
                            ObjectController.GuardarDistribucion(distribuciones);
                            break;
                        case 4:
                            var newTripulacion = CrearTripulacion(aeronaves);
                            personal.Add(newTripulacion);
                            ObjectController.GuardarTripulación(personal);
                            break;
                        case 5:
                            Console.Write("Ingrese el código de aeronave: ");
                            var codigoBusqueda = Console.ReadLine();
                            var personalAsignado = personal.FirstOrDefault(personal1 =>
                                personal1.Aeronave.NumeroAeronave == codigoBusqueda);
                            if (personalAsignado != null)
                            {
                                Console.WriteLine("Personal asignado a la aeronave de código " + codigoBusqueda + ": " + personalAsignado.Codigo);
                            }
                            else
                            {
                                Console.WriteLine("No se encontró ninguna aeronave identificada con el código ingresado");
                            }
                            break;
                        case 6:
                            Console.Write("Ingrese el nombre de la ciudad objetivo: ");
                            var ciudadObjetivo = Console.ReadLine();
                            ObjectController.BuscarClientePorCiudad(clientes, ciudadObjetivo);
                            break;
                    }
                    Console.Clear();
                    break;
            }
        }

        private static Tripulacion CrearTripulacion(IEnumerable<Aeronave> aeronaves)
        {
            Console.Write("Código de personal: ");
            var codigoPersonal = Console.ReadLine();
            Console.Write("Código de aeronave correspondiente: ");
            var codigoAero = Console.ReadLine();
            var aeronavePersonal = aeronaves.FirstOrDefault(aeronave1 => aeronave1.NumeroAeronave == codigoAero);
            var newTripulacion = new Tripulacion(codigoPersonal, aeronavePersonal);
            return newTripulacion;
        }

        private static Distribucion CrearDistribucion(IEnumerable<Aeronave> aeronaves, IEnumerable<Trayecto> trayectos)
        {
            Console.Write("Código de aeronave: ");
            var codigoAeronave = Console.ReadLine();
            var aeronave = aeronaves.FirstOrDefault(aeronave1 => aeronave1.NumeroAeronave == codigoAeronave);
            Console.Write("Código de trayecto: ");
            var codigoTrayecto = Console.ReadLine();
            var trayecto = trayectos.FirstOrDefault(trayecto1 => trayecto1.Codigo == codigoTrayecto);
            var newPersonal = new Distribucion(aeronave, trayecto, GetDate());
            return newPersonal;
        }

        private static Trayecto CrearTrayecto()
        {
            Console.Write("Código de trayecto: ");
            var codigo = Console.ReadLine();
            Console.Write("Ciudad origen: ");
            var origen = Console.ReadLine();
            Console.Write("Ciudad destino: ");
            var destino = Console.ReadLine();
            Console.Write("Año: ");
            var año = Convert.ToInt32(Console.ReadLine());
            Console.Write("Mes: ");
            var mes = Convert.ToInt32(Console.ReadLine());
            Console.Write("Día: ");
            var dia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hora de partida");
            Console.Write("Horas: ");
            var horasPartida = Convert.ToInt32(Console.ReadLine());
            Console.Write("Minutos: ");
            var minutosPartida = Convert.ToInt32(Console.ReadLine());
            Console.Write("Segundos: ");
            var segundosPartida = Convert.ToInt32(Console.ReadLine());
            var horaPartida = new DateTime(año, mes, dia, horasPartida, minutosPartida, segundosPartida);
            Console.WriteLine("Hora de llegada");
            Console.Write("Horas: ");
            var horasLlegada = Convert.ToInt32(Console.ReadLine());
            Console.Write("Minutos: ");
            var minutosLlegada = Convert.ToInt32(Console.ReadLine());
            Console.Write("Segundos: ");
            var segundosLlegada = Convert.ToInt32(Console.ReadLine());
            var horaLlegada = new DateTime(año, mes, dia, horasLlegada, minutosLlegada, segundosLlegada);
            Console.Write("Valor del vuelo ($): ");
            var valor = Convert.ToInt32(Console.ReadLine());
            var newTrayecto = new Trayecto(codigo, origen, destino, horaPartida, horaLlegada, valor);
            return newTrayecto;
        }

        private static Cliente RegistrarCliente()
        {
            Console.Write("ID: ");
            var idUsuario = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nombre completo: ");
            var nombreCompleto = Console.ReadLine();
            Console.Write("Email: ");
            var correoUsuario = Console.ReadLine();
            Console.Write("Teléfono: ");
            var telefonoUsuario = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ciudad: ");
            var ciudad = Console.ReadLine();

            var nuevoCliente = new Cliente(idUsuario, nombreCompleto, correoUsuario, telefonoUsuario,
                ciudad);
            return nuevoCliente;
        }

        private static Reserva SeleccionarTrayecto(IEnumerable<Trayecto> trayectosDisponibles, Cliente cliente)
        {
            bool confirmed;
            do
            {
                var disponibles = trayectosDisponibles as Trayecto[] ?? trayectosDisponibles.ToArray();
                ObjectController.ListarTrayectos(disponibles);
                Console.WriteLine("Ingrese el código del trayecto que desea seleccionar");
                var codigoTrayecto = Console.ReadLine();
                var trayectoSeleccionado = disponibles.FirstOrDefault(trayecto => trayecto.Codigo == codigoTrayecto);
                Console.WriteLine("¿Confirmar reserva? (Y/N)");
                var confirmar = Console.ReadKey();
                confirmed = confirmar.Key == ConsoleKey.Y;
                if (confirmed && trayectoSeleccionado != null)
                    return new Reserva(cliente, trayectoSeleccionado, trayectoSeleccionado.HoraPartida);
            } while (!confirmed);

            return null;
        }

        private static DateTime GetDate()
        {
            Console.Write("Año: ");
            var año = Convert.ToInt32(Console.ReadLine());
            Console.Write("Mes: ");
            var mes = Convert.ToInt32(Console.ReadLine());
            Console.Write("Día: ");
            var dia = Convert.ToInt32(Console.ReadLine());
            return new DateTime(año, mes, dia);
        }
    }
}