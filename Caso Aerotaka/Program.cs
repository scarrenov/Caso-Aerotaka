using System;
using System.Collections.Generic;

namespace Caso_Aerotaka
{
    internal static class Program
    {
        private static void Main()
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