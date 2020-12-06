using Maxi.Persistencia.ZonaDAO;
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
    [RoutePrefix("api/zona")]
    public class ZonaController : ApiController
    {
        [HttpGet]
        [Route("List")]
        public IEnumerable<Zona> getList()
        {

            var listaZonas= ZonaDAO.ListarZonas();
            return listaZonas;
        }
        [HttpPost]
        [Route("Insert")]
        public IHttpActionResult Insert(Zona zona)
        {

            var respuestaInsertar = ZonaDAO.InsertarZona(zona);
            if (respuestaInsertar)
                return Ok(201);
            else
                return Content(HttpStatusCode.InternalServerError, zona);

        }
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Actualizar(Zona zona)
        {

            var respuestaActualizar = ZonaDAO.ActualizarZona(zona);
            if (respuestaActualizar)
                return Ok(202);
            else
                return Content(HttpStatusCode.InternalServerError, zona);

        }
        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Eliminar(Int16 idZona)
        {
            Zona zona = new Zona();
            zona.idZona = idZona;
            var respuestaEliminar = ZonaDAO.EliminarZona(zona);
            if (respuestaEliminar)
                return Ok(202);
            else
                return Content(HttpStatusCode.InternalServerError, zona);

        }
        //BuscarProductoId
        [HttpGet]
        [Route("findById")]
        public IEnumerable<Zona> BuscarxId(Int16 idzona)
        {
            Zona zona = new Zona();
            zona.idZona = idzona;
            var respuestaBuscar = ZonaDAO.BuscarZonaId(zona);
            return respuestaBuscar;

        }

    }
}
