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
    public class CategoriasController : ApiController
    {
        private ModelVentas db = new ModelVentas();

        // GET: api/Categorias

        /*   public IQueryable<Categoria> GetCategoria()
    {
        return db.Categoria;
    }*/

        [HttpPost]
        public List<CategoriaDTO> GetCategoria()
        {
            var query = (from categ in db.Categoria
                         select new CategoriaDTO()
                         {
                             Categoria_id = categ.categoria_id,
                             Nombre = categ.nombre
                         }).ToList();
            return query;
        }

        [HttpPost]
        public List<CategoriaDTO> GetCategoriaPorNombre(string nombre)
        {
            if (String.IsNullOrEmpty(nombre))
            {
                return GetCategoria();
            }

            var query = (from categ in db.Categoria
                         select new CategoriaDTO()
                         {
                             Categoria_id = categ.categoria_id,
                             Nombre = categ.nombre
                         }).Where(x => x.Nombre.Contains(nombre)).ToList();
            return query;
        }

        [HttpPost]
        public List<CategoriaDTO> GetCategoriaPorId(int id)
        {
            if (id == 0)
            {
                return GetCategoria();
            }

            var query = (from categ in db.Categoria
                         where categ.categoria_id.Equals(id)
                         select new CategoriaDTO()
                         {
                             Categoria_id = categ.categoria_id,
                             Nombre = categ.nombre
                         }).ToList();
            return query;
        }
    }
}