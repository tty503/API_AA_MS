using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Persistence
{
    public class API_AA_MS_Context  : IdentityDbContext<Usuario>
    {
        public API_AA_MS_Context(DbContextOptions<API_AA_MS_Context> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CuentaUsuario>().HasKey(cu => new { cu.UsuarioId, cu.CuentaId});
            modelBuilder.Entity<InformeUsuario>().HasKey(cu => new { cu.UsuarioId, cu.InformeId });
        }
        public DbSet<Cuenta> Cuenta{ get; set; }
        public DbSet<Transaccion> Transaccion { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Informe> Informe { get; set; }
        public DbSet<CuentaUsuario> CuentaUsuario { get; set; }
        public DbSet<InformeUsuario> InformeUsuario { get; set; }
    }
}