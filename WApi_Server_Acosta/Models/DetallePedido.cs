namespace WApi_Server_Acosta.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetallePedido")]
    public partial class DetallePedido
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pedido_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int producto_id { get; set; }

        public decimal precio { get; set; }

        public int cantidad { get; set; }

        public decimal subtotal { get; set; }

        [Required]
        [StringLength(12)]
        public string estado { get; set; }

        public virtual Pedido Pedido { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
