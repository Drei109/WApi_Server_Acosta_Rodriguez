using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WApi_Server_Acosta.Models;

namespace WApi_Server_Acosta.Controllers
{
    public class ProductosController : ApiController
    {
        private ModelVentas db = new ModelVentas();

        // GET: api/Productos
        //public IQueryable<Producto> GetProducto()
        //{
        //    return db.Producto;
        //}

        //// GET: api/Productos/5
        //[ResponseType(typeof(Producto))]
        //public IHttpActionResult GetProducto(int id)
        //{
        //    Producto producto = db.Producto.Find(id);
        //    if (producto == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(producto);
        //}
        [HttpPost]
        public List<ProductoDTO> GetProducto()
        {
            var query = (from prod in db.Producto
                         join cate in db.Categoria on prod.categoria_id equals cate.categoria_id
                         select new ProductoDTO()
                         {
                             Producto_id = prod.producto_id,
                             Categoria = cate.nombre,
                             Nombre = prod.nombre,
                             Descripcion = prod.descripcion,
                             Precio = prod.precio,
                             Stock = prod.stock,
                             Imagen = prod.imagen,
                             Estado = prod.estado
                         }).ToList();
            return query;
        }

        [HttpPost]
        public List<ProductoDTO> GetProductoPorNombre(string nombre)
        {
            if (String.IsNullOrEmpty(nombre))
            {
                return GetProducto();
            }

            var query = (from prod in db.Producto
                         join cate in db.Categoria on prod.categoria_id equals cate.categoria_id
                         select new ProductoDTO()
                         {
                             Producto_id = prod.producto_id,
                             Categoria = cate.nombre,
                             Nombre = prod.nombre,
                             Descripcion = prod.descripcion,
                             Precio = prod.precio,
                             Stock = prod.stock,
                             Imagen = prod.imagen,
                             Estado = prod.estado
                         }).Where(x => x.Nombre.Contains(nombre)).ToList();
            return query;
        }

        [HttpPost]
        public List<ProductoDTO> GetProductoPorId(int id)
        {
            if (id == 0)
            {
                return GetProducto();
            }

            var query = (from prod in db.Producto
                         join cate in db.Categoria on prod.categoria_id equals cate.categoria_id
                         where prod.producto_id == id
                         select new ProductoDTO()
                         {
                             Producto_id = prod.producto_id,
                             Categoria = cate.nombre,
                             Nombre = prod.nombre,
                             Descripcion = prod.descripcion,
                             Precio = prod.precio,
                             Stock = prod.stock,
                             Imagen = prod.imagen,
                             Estado = prod.estado
                         }).ToList();
            return query;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductoExists(int id)
        {
            return db.Producto.Count(e => e.producto_id == id) > 0;
        }
    }
}