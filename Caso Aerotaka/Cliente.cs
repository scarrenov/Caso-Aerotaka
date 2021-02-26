namespace Caso_Aerotaka
{
    public class Cliente
    {
        private int _iD;
        private string _nombreCompleto;
        private string _email;
        private int _telefono;
        private string _ciudad;

        public int ID => _iD;

        public string NombreCompleto => _nombreCompleto;

        public string Email => _email;

        public int Telefono => _telefono;

        public string Ciudad => _ciudad;

        public Cliente()
        {
        }

        public Cliente(int iD, string nombreCompleto, string email, int telefono, string ciudad)
        {
            _iD = iD;
            _nombreCompleto = nombreCompleto;
            _email = email;
            _telefono = telefono;
            _ciudad = ciudad;
        }   
    }
}