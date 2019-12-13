namespace WApi_Server_Acosta.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Pedido = new HashSet<Pedido>();
        }

        [Key]
        public int usuario_id { get; set; }

        public int tipousuario_id { get; set; }

        [Required]
        [StringLength(150)]
        public string nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string apellido { get; set; }

        [StringLength(250)]
        public string email { get; set; }

        [StringLength(15)]
        public string celular { get; set; }

        [StringLength(250)]
        public string foto { get; set; }

        [Required]
        [StringLength(150)]
        public string nombreusu { get; set; }

        [Required]
        [StringLength(100)]
        public string clave { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedido { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
