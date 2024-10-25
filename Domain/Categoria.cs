namespace Domain
{
    public class Categoria
    {
        public enum TipoCategoria { ingreso, egreso};
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public TipoCategoria Tipo { get; set; }
    }
}
