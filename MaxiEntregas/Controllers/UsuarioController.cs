using Maxi.Persistencia.UsuarioPersistencia;
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
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("crearPassword")]
        public IHttpActionResult CrearPassword(LoginRequest usuario)
        {

            Boolean respuestaBuscar = UsuarioDAO.CrearPassword(usuario);
            if (respuestaBuscar)
                return Ok(200);
            else
                return Content(HttpStatusCode.BadRequest,usuario);

        }
    }
}
