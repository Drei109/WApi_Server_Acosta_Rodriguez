using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WApi_Server_Acosta.Models
{
    public class ProductoDTO
    {
        public int Producto_id { get; set; }

        public string Categoria { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string Imagen { get; set; }

        public string Estado { get; set; }
    }
}