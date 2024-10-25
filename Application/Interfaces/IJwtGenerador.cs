using Domain;

namespace Application.Interfaces
{
    public interface IJwtGenerador
    {
        string CrearToken(Usuario usuario);
    }
}
