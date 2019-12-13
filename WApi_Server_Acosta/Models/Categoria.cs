namespace WApi_Server_Acosta.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Categoria")]
    public partial class Categoria
    {


        [Key]
        public int categoria_id { get; set; }

        [Required]
        [StringLength(150)]
        public string nombre { get; set; }

    }
}
