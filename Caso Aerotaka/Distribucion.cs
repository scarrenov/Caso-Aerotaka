using System;

namespace Caso_Aerotaka
{
    public class Distribucion
    {
        private Aeronave _aeronave;
        private Trayecto _trayecto;
        private DateTime _fecha;

        public Aeronave Aeronave => _aeronave;

        public Trayecto Trayecto => _trayecto;

        public DateTime Fecha => _fecha;

        public Distribucion()
        {
        }

        public Distribucion(Aeronave aeronave, Trayecto trayecto, DateTime fecha)
        {
            _aeronave = aeronave;
            _trayecto = trayecto;
            _fecha = fecha;
        }
        
    }
}