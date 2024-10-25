namespace Domain
{
    public class Cuenta
    {
        public enum TipoCuenta { activo, pasivo, patrimonio };

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public TipoCuenta Tipo { get; set; }
        public DateTime Fecha { get; set; }

        public IEnumerable<Usuario> Usuario { get; set; }
    }
}


