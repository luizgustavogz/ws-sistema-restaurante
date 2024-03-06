using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaRestaurante.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Column("PedidoId")]
        public int Id { get; set; }

        [Column("NomeSolicitante")]
        [Display(Name = "Nome Cliente")]
        public string? NomeSolicitante { get; set; }

        [Column("Mesa")]
        [Display(Name = "Nº Mesa")]
        public int Mesa { get; set; }

        public virtual ICollection<ItemPedido>? ItensPedido { get; set; }
    }
}
