namespace Domain
{
    public class CuentaUsuario
    {
        public Guid    CuentaId  {  get; set; }
        public Cuenta  Cuenta    {  get; set; }
        public Guid    UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
