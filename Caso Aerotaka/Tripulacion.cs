namespace Caso_Aerotaka
{
    public class Tripulacion
    {
        private string _codigoPersonal;
        
        private Aeronave _aeronave;

        public string Codigo => _codigoPersonal;

        public Aeronave Aeronave => _aeronave;

        public Tripulacion()
        {
        }

        public Tripulacion(string codigoPersonal, Aeronave aeronave)
        {
            _codigoPersonal = codigoPersonal;
            _aeronave = aeronave;
        }
    }
}