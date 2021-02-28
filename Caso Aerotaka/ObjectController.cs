using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Caso_Aerotaka
{
    internal static class ObjectController
    {
        private const string ClientesPath = @"JsonFiles\AerotakaClientes.json";
        private const string ReservasPath = @"JsonFiles\AerotakaReservas.json";
        private const string DistribucionPath = @"JsonFiles\AerotakaDistribuciones.json";
        private const string PersonalPath = @"JsonFiles\AerotakaPersonal.json";
        private const string TrayectosPath = @"JsonFiles\AerotakaTrayectos.json";
        private const string AeronavesPath = @"JsonFiles\AerotakaAeronaves.json";
        
        /// <summary>
        /// Busca e imprime un cliente de la colección clientes cuya ciudad coincida con ciudadObjetivo.
        /// </summary>
        /// <param name="clientes">Colección de clientes a buscar</param>
        /// <param name="ciudadObjetivo">Ciudad que se buscará en los atributos de la colección de clientes</param>
        public static void BuscarClientePorCiudad(IEnumerable<Cliente> clientes, string ciudadObjetivo)
        {
            var clienteQuery =
                from cliente in clientes
                where cliente.Ciudad.Contains(ciudadObjetivo)
                select cliente;

            ListarInfo(clienteQuery);
        }

        public static IEnumerable<Trayecto> BuscarVueloPorDestino(IEnumerable<Trayecto> trayectos, string ciudadDestino)
        {
            var destinoQuery =
                from trayecto in trayectos 
                where trayecto.Destino.Contains(ciudadDestino) 
                select trayecto;

            return destinoQuery;
        }

        /// <summary>
        /// Lista, de forma ordenada, todos los elementos de una colección.
        /// </summary>
        /// <param name="lista">Colección a listar.</param>
        public static void ListarInfo(IEnumerable<Cliente> lista)
        {
            foreach (var t in lista)
            {
                Console.WriteLine("ID: " + t.ID);
                Console.WriteLine("Nombre completo: " + t.NombreCompleto);
                Console.WriteLine("Email: " + t.Email);
                Console.WriteLine("Teléfono: " + t.Telefono);
                Console.WriteLine("Ciudad: " + t.Ciudad);
                Console.WriteLine("Oprima cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Guarda la lista listaGuardada en un archivo .json en el directorio especificado.
        /// </summary>
        /// <param name="clientes">Coleccion de objetos a guardar</param>
        public static void GuardarClientes(IEnumerable<Cliente> clientes)
        {
            var jsonObject = JsonConvert.SerializeObject(clientes);
            File.WriteAllText(ClientesPath, jsonObject);
        }

        public static void Cargar(out List<Cliente> clientes, out List<Reserva> reservas, out List<Distribucion> distribuciones, out List<Personal> personal, out List<Aeronave> aeronaves, out List<Trayecto> trayectos)
        {
            using (var clientesStream = File.OpenText(ClientesPath))
            {
                var jsonRead = clientesStream.ReadToEnd();
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(jsonRead);
            }

            using (var reservaStream = File.OpenText(ReservasPath))
            {
                var jsonRead = reservaStream.ReadToEnd();
                reservas = JsonConvert.DeserializeObject<List<Reserva>>(jsonRead);
            }
            
            using (var distribucionesStream = File.OpenText(DistribucionPath))
            {
                var jsonRead = distribucionesStream.ReadToEnd();
                distribuciones = JsonConvert.DeserializeObject<List<Distribucion>>(jsonRead);
            }
            
            using (var personalStream = File.OpenText(PersonalPath))
            {
                var jsonRead = personalStream.ReadToEnd();
                personal = JsonConvert.DeserializeObject<List<Personal>>(jsonRead);
            }
            
            using (var aeronavesStream = File.OpenText(AeronavesPath))
            {
                var jsonRead = aeronavesStream.ReadToEnd();
                aeronaves = JsonConvert.DeserializeObject<List<Aeronave>>(jsonRead);
            }
            
            using (var trayectosStream = File.OpenText(TrayectosPath))
            {
                var jsonRead = trayectosStream.ReadToEnd();
                trayectos = JsonConvert.DeserializeObject<List<Trayecto>>(jsonRead);
            }
        }
    }
}