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
                    break;
                case 3: // Admin
                    break;
            }
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
                var codigoTrayecto = Convert.ToInt32(Console.ReadLine());
                var trayectoSeleccionado = disponibles.FirstOrDefault(trayecto => trayecto.Codigo == codigoTrayecto);
                Console.WriteLine("¿Confirmar reserva? (Y/N)");
                var confirmar = Console.ReadKey();
                confirmed = confirmar.Key == ConsoleKey.Y;
                if (confirmed && trayectoSeleccionado != null)
                    return new Reserva(cliente, trayectoSeleccionado, trayectoSeleccionado.HoraPartida);
            } while (!confirmed);

            return null;
        }
    }
}