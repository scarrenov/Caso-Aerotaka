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
                            break;
                            
                        case 2:
                                
                            
                            
                        break;
                            
                    }
                    
                    break;
            }
            
        }
    }
}