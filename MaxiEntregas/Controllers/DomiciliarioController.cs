using MaxiEntregas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Maxi.Persistencia.DomiciliarioDAO;

namespace MaxiEntregas.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/domiciliario")]
    public class DomiciliarioController : ApiController
    {
        [HttpGet]
        [Route("List")]
        public IEnumerable<Domiciliario> getList()
        {

            var listaProductos = DomiciliarioDAO.ListarDomiciliarios();
            return listaProductos;
        }
        [HttpPost]
        [Route("Insert")]
        public IHttpActionResult Insert(Domiciliario domiciliario)
        {

            var respuestaInsertar = DomiciliarioDAO.InsertarDomiciliario(domiciliario);
            if (respuestaInsertar)
                return Ok(201);
            else
                return Content(HttpStatusCode.InternalServerError, domiciliario);

        }
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Actualizar(Domiciliario domiciliario)
        {

            var respuestaActualizar = DomiciliarioDAO.ActualizarDomiciliario(domiciliario);
            if (respuestaActualizar)
                return Ok(202);
            else
                return Content(HttpStatusCode.InternalServerError, domiciliario);

        }
        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Eliminar(Int16 idDomiciliario)
        {
            Domiciliario domiciliario = new Domiciliario();
            domiciliario.idDomiciliario = idDomiciliario;
            var respuestaEliminar = DomiciliarioDAO.EliminarDomiciliario(domiciliario);
            if (respuestaEliminar)
                return Ok(202);
            else
                return Content(HttpStatusCode.InternalServerError, domiciliario);

        }
        //BuscarProductoId
        [HttpGet]
        [Route("findById")]
        public IEnumerable<Domiciliario> BuscarxId(Int16 idDomiciliario)
        {
            Domiciliario domiciliario = new Domiciliario();
            domiciliario.idDomiciliario = idDomiciliario;
            var respuestaBuscar = DomiciliarioDAO.BuscarDomiciliarioId(domiciliario);
            return respuestaBuscar;

        }
    }
}
