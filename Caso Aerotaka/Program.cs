using System;

namespace Caso_Aerotaka
{
    internal static class Program
    {
        private static void Main()
        {
            ObjectController.Cargar(out var clientes,out var reservas,out var distribuciones,out var personal,out var aeronaves,out var trayectos);
            Console.WriteLine("Ingresar como:");
            Console.WriteLine("1.Cliente");
            Console.WriteLine("2.Departamento de mercadeo");
            Console.WriteLine("3.Administracion");
            var index = Convert.ToInt32(Console.ReadLine());
            switch (index)
            {
                case 1:
                    Console.WriteLine("Siga las siguientes instrucciones:");
                    Console.WriteLine("1.Registrarse");
                    Console.WriteLine("2.Reservar vuelo");
                    
                    var usuarioIndex = Convert.ToInt32(Console.ReadLine());

                    switch (usuarioIndex)
                    {
                        case 1:
                            Console.WriteLine("Ingrese Id");
                            var idUsuario = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese nombre completo");
                            var nombreCompleto = Console.ReadLine();
                            Console.WriteLine("Ingrese el correo");
                            var correoUsuario = Console.ReadLine();
                            Console.WriteLine("Digite el telefono");
                            var telefonoUsuario = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Digite la ciudad");
                            var ciudad = Console.ReadLine();

                            var nuevoCliente = new Cliente(idUsuario, nombreCompleto, correoUsuario, telefonoUsuario,
                                ciudad);
                            clientes.Add(nuevoCliente);
                            ObjectController.GuardarClientes(clientes);
                            
                            case 2:
                                if()
                            
                            break;
                    }
                    
                    break;
            }
            
        }

        private static void PruebaClientes()
        {
            ObjectController.Cargar
            (
                out var clientes,
                out var reservas,
                out var distribuciones,
                out var personal,
                out var aeronaves,
                out var trayectos
            );
            ObjectController.ListarInfo(clientes);
            var intPtr = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < intPtr; i++)
            {
                Console.WriteLine("Cliente " + i + 1);
                Console.WriteLine("ID:");
                var id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Nombre:");
                var nombre = Console.ReadLine();
                Console.WriteLine("Email:");
                var email = Console.ReadLine();
                Console.WriteLine("Teléfono:");
                var telefono = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ciudad:");
                var ciudad = Console.ReadLine();

                var newCliente = new Cliente(id, nombre, email, telefono, ciudad);
                clientes.Add(newCliente);
            }

            ObjectController.GuardarClientes(clientes);
        }
    }
}