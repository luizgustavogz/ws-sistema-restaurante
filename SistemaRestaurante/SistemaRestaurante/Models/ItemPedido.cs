using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaRestaurante.Models
{
    [Table("ItensPedido")]
    public class ItemPedido
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Prato")]
        public string? Prato { get; set; }

        [Column("Bebida")]
        public string? Bebida { get; set; }

        [Column("Quantidade")]
        public int Quantidade { get; set; }

        [Column("PedidoId")]
        [Display(Name = "Nº Pedido")]
        public int PedidoId { get; set; }

        public virtual Pedido? Pedido { get; set; }
    }
}
