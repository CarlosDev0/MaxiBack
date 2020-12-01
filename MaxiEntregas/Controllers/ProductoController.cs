using Maxi.Persistencia.ProductoDAO;
using MaxiEntregas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MaxiEntregas.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/producto")]
    public class ProductoController : ApiController
    {
        [HttpGet]
        [Route("List")]
        public IEnumerable<Producto> getList()
        {

            var listaProductos = ProductoDAO.ListarProductos();
            return listaProductos;
        }
        [HttpPost]
        [Route("Insert")]
        public IHttpActionResult Insert(Producto producto)
        {

            var respuestaInsertar = ProductoDAO.InsertarProducto(producto);
            if (respuestaInsertar)
                return Ok(201);
            else
                return Content(HttpStatusCode.InternalServerError, producto);
            
        }
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Actualizar(Producto producto)
        {

            var respuestaActualizar = ProductoDAO.ActualizarProducto(producto);
            if (respuestaActualizar)
                return Ok(202);
            else
                return Content(HttpStatusCode.InternalServerError, producto);

        }
        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Eliminar(Int16 idProducto)
        {
            Producto producto = new Producto();
            producto.idProducto = idProducto;
            var respuestaEliminar = ProductoDAO.EliminarProducto(producto);
            if (respuestaEliminar)
                return Ok(202);
            else
                return Content(HttpStatusCode.InternalServerError, producto);

        }
        //BuscarProductoId
        [HttpGet]
        [Route("findById")]
        public IEnumerable<Producto> BuscarxId(Int16 idProducto)
        {
            Producto producto = new Producto();
            producto.idProducto = idProducto;
            var respuestaBuscar = ProductoDAO.BuscarProductoId(producto);
            return respuestaBuscar;

        }
    }
}
