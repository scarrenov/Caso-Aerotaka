namespace Caso_Aerotaka
{
    public class Aeronave
    {
        private string _numeroAeronave;
        private string _tipoAvion;
        private int _cupoMaximo;

      
        public string NumeroAeronave => _numeroAeronave;

        public string TipoAvion => _tipoAvion;

        public int CupoMaximo => _cupoMaximo;
        
        public Aeronave()
        {
        }


        public Aeronave(string numeroAeronave, string tipoAvion, int cupoMaximo)
        {
            _numeroAeronave = numeroAeronave;
            _tipoAvion = tipoAvion;
            _cupoMaximo = cupoMaximo;
        }
    }
}