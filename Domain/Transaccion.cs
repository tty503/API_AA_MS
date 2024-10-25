using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Transaccion
    {
        public Guid Id { get; set; }
        
        public DateTime Fecha { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public Decimal Monto {  get; set; }
        
        public Guid   CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }

        public Guid CategoriaId {  get; set; }
        public Categoria Categoria { get; set; }

    }
}
