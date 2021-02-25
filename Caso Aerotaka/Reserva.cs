using System;

namespace Caso_Aerotaka
{
    public class Reserva
    {
        private Cliente _cliente;
        private Trayecto _trayecto;
        private DateTime _fecha;

        public Cliente Cliente => _cliente;

        public Trayecto Trayecto => _trayecto;

        public DateTime Fecha => _fecha;

        public Reserva()
        {
        }

        public Reserva(Cliente cliente, Trayecto trayecto, DateTime fecha)
        {
            _cliente = cliente;
            _trayecto = trayecto;
            _fecha = fecha;
        }
    }
}