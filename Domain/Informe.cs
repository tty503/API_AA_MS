namespace Domain
{
    public class Informe
    {
        public Guid Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public IEnumerable<Usuario> Usuario { get; set; }
    }
}
