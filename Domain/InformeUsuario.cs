namespace Domain
{
    public  class InformeUsuario
    {
        public Guid InformeId { get; set; }
        public Informe Informe { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
