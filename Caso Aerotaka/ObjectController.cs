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

        #region Métodos de búsqueda

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

            ListarClientes(clienteQuery);
        }

        /// <summary>
        /// Busca trayectos cuya ciudad destino correspondiente sea ciudadDestino
        /// </summary>
        /// <param name="trayectos">Colección de trayectos donde se buscará</param>
        /// <param name="ciudadDestino">Ciudad a buscar dentro de la colección de trayectos</param>
        /// <returns>Retorna una colección de trayectos a las que le corresponde la ciudad destino ingresada</returns>
        public static IEnumerable<Trayecto> BuscarVueloPorDestino(IEnumerable<Trayecto> trayectos, string ciudadDestino)
        {
            var destinoQuery =
                from trayecto in trayectos 
                where trayecto.Destino.Contains(ciudadDestino) 
                select trayecto;

            return destinoQuery;
        }

        /// <summary>
        /// Busca un cliente de la lista clientes según el id seleccionado.
        /// </summary>
        /// <param name="clientes">Colección de clientes.</param>
        /// <param name="iD">ID a coincidir dentro de la coleección de clientes.</param>
        /// <param name="outputCliente">Almacena el primer cliente que coincide con el ID criterio.</param>
        /// <returns>Verdadero si se encuentra un cliente con el ID ingresado, falso en caso contrario.</returns>
        public static bool BuscarClientePorId(IEnumerable<Cliente> clientes, int iD, out Cliente outputCliente)
        {
            foreach (var thisCliente in clientes)
            {
                if (thisCliente.ID != iD) continue;
                outputCliente = thisCliente;
                return true;
            }

            outputCliente = null;
            return false;
        }
        #endregion

        #region Métodos de listado

        /// <summary>
        /// Lista, de forma ordenada, todos los elementos de una colección.
        /// </summary>
        /// <param name="lista">Colección a listar.</param>
        public static void ListarClientes(IEnumerable<Cliente> lista)
        {
            foreach (var t in lista)
            {
                Console.WriteLine("ID: " + t.ID);
                Console.WriteLine("Nombre completo: " + t.NombreCompleto);
                Console.WriteLine("Email: " + t.Email);
                Console.WriteLine("Teléfono: " + t.Telefono);
                Console.WriteLine("Ciudad: " + t.Ciudad);
                Console.WriteLine("______________________________");
            }
            Console.WriteLine("Oprima cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void ListarTrayectos(IEnumerable<Trayecto> trayectos)
        {
            foreach (var t in trayectos)
            {
                Console.WriteLine("Trayecto disponible");
                Console.WriteLine("Código de trayecto: " + t.Codigo);
                Console.WriteLine("Ciudad origen: " + t.Origen);
                Console.WriteLine("Ciudad destino: " + t.Destino);
                Console.WriteLine("Hora de partida: " + t.HoraPartida);
                Console.WriteLine("Hora llegada: " + t.HoraLlegada);
                Console.WriteLine("Valor del trayecto: $" + t.Valor);
                Console.WriteLine("____________________________________");
            }
        }

        #endregion

        #region Métodos de guardado

        /// <summary>
        /// Guarda la lista listaGuardada en un archivo .json en el directorio especificado.
        /// </summary>
        /// <param name="clientes">Coleccion de objetos a guardar</param>
        public static void GuardarClientes(IEnumerable<Cliente> clientes)
        {
            var jsonObject = JsonConvert.SerializeObject(clientes);
            File.WriteAllText(ClientesPath, jsonObject);
        }

        public static void GuardarDistribucion(IEnumerable<Distribucion> distribucion)
        {
            var jsonObject = JsonConvert.SerializeObject(distribucion);
            File.WriteAllText(DistribucionPath, jsonObject);
        }

        public static void GuardarAeronaves(IEnumerable<Aeronave> aeronaves)
        {
            var jsonObject = JsonConvert.SerializeObject(aeronaves);
            File.WriteAllText(AeronavesPath, jsonObject);
        }

        public static void GuardarTripulación(IEnumerable<Tripulacion> tripulacion)
        {
            var jsonObject = JsonConvert.SerializeObject(tripulacion);
            File.WriteAllText(PersonalPath, jsonObject);
        }

        public static void GuardarReservas(IEnumerable<Reserva> reservas)
        {
            var jsonObject = JsonConvert.SerializeObject(reservas);
            File.WriteAllText(ReservasPath, jsonObject);
        }

        public static void GuardarTrayectos(IEnumerable<Trayecto> trayectos)
        {
            var jsonObject = JsonConvert.SerializeObject(trayectos);
            File.WriteAllText(TrayectosPath, jsonObject);
        }

        #endregion

        public static void Cargar(out List<Cliente> clientes, out List<Reserva> reservas, out List<Distribucion> distribuciones, out List<Tripulacion> personal, out List<Aeronave> aeronaves, out List<Trayecto> trayectos)
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
                personal = JsonConvert.DeserializeObject<List<Tripulacion>>(jsonRead);
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