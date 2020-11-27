using Maxi.Persistencia.Proveedores;
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
    [RoutePrefix("api/proveedor")]
    public class ProveedorController : ApiController
    {

        [HttpGet]
        [Route("List")]
        public IEnumerable<Proveedor> getList()
        {

            var listaProductos = ProveedorDAO.ListarProveedores();
            return listaProductos;
        }
        [HttpPost]
        [Route("Insert")]
        public IHttpActionResult Insert(Proveedor proveedor)
        {

            var respuestaInsertar = ProveedorDAO.InsertarProveedor(proveedor);
            if (respuestaInsertar)
                return Ok(201);
            else
                return Content(HttpStatusCode.InternalServerError, proveedor);

        }
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Actualizar(Proveedor proveedor)
        {

            var respuestaActualizar = ProveedorDAO.ActualizarProveedor(proveedor);
            if (respuestaActualizar)
                return Ok(202);
            else
                return Content(HttpStatusCode.InternalServerError, proveedor);

        }
        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Eliminar(Proveedor proveedor)
        {

            var respuestaEliminar = ProveedorDAO.EliminarProveedor(proveedor);
            if (respuestaEliminar)
                return Ok(202);
            else
                return Content(HttpStatusCode.InternalServerError, proveedor);

        }
        //BuscarProductoId
        [HttpGet]
        [Route("findById")]
        public IEnumerable<Proveedor> BuscarxId(Proveedor proveedor)
        {

            var respuestaBuscar = ProveedorDAO.BuscarProveedorId(proveedor);
            return respuestaBuscar;

        }

    }
}
