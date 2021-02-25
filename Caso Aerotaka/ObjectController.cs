using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Caso_Aerotaka
{
    public class ObjectController
    {
        /// <summary>
        /// Busca e imprime un cliente de la colección clientes cuya ciudad coincida con ciudadObjetivo.
        /// </summary>
        /// <param name="clientes">Colección de clientes a buscar</param>
        /// <param name="ciudadObjetivo">Ciudad que se buscará en los atributos de la colección de clientes</param>
        public void BuscarClientePorCiudad(IEnumerable<Cliente> clientes, string ciudadObjetivo)
        {
            var clienteQuery =
                from cliente
                in clientes
                where cliente.Ciudad.Contains(ciudadObjetivo)
                select cliente;

            ListarInfo(clienteQuery);
        }

        /// <summary>
        /// Lista, de forma ordenada, todos los elementos de una colección.
        /// </summary>
        /// <param name="lista">Colección a listar.</param>
        private static void ListarInfo(IEnumerable<Cliente> lista)
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
        /// <param name="listaGuardada">Coleccion de objetos a guardar</param>
        public void Guardar(IEnumerable<object> listaGuardada)
        {
            var jsonObject = JsonConvert.SerializeObject(listaGuardada);
            const string path = @"C:\JsonFiles\Aerotaka.json";
            File.WriteAllText(jsonObject, path);
        }

        public List<object> Cargar()
        {
            var path = @"C:\JsonFiles\Aerotaka.json";
            using var jsonStream = File.OpenText(path);
            var jsonRead = jsonStream.ReadToEnd();
            var output = JsonConvert.DeserializeObject<List<object>>(jsonRead);

            return output;
        }
    }
}