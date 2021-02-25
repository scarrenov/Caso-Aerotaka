namespace Caso_Aerotaka
{
    public class Personal
    {
        private Personal _personal;
        
        private Aeronave _aeronave;

        public Personal Personal1 => _personal;

        public Aeronave Aeronave => _aeronave;

        public Personal()
        {
        }

        public Personal(Personal personal, Aeronave aeronave)
        {
            _personal = personal;
            _aeronave = aeronave;
        }
        
        

      
        
        

    }
}