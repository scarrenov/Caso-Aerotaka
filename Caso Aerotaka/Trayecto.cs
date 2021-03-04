using System;

namespace Caso_Aerotaka
{
    public class Trayecto
    {
        // Atributos
        private int _codigo;
        private string _origen, _destino;
        private DateTime _horaPartida, _horaLlegada;
        private int _valor;

        //Propiedades
        public int Codigo => _codigo;

        public string Origen => _origen;

        public string Destino => _destino;

        public DateTime HoraPartida => _horaPartida;

        public DateTime HoraLlegada => _horaLlegada;

        public int Valor => _valor;

        // Constructores
        public Trayecto()
        {
        }

        public Trayecto(int codigo, string origen, string destino, DateTime horaPartida, DateTime horaLlegada, int valor)
        {
            _codigo = codigo;
            _origen = origen;
            _destino = destino;
            _horaPartida = horaPartida;
            _horaLlegada = horaLlegada;
            _valor = valor;
        }
    }
}