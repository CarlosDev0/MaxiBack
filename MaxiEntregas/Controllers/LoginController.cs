using Maxi.Persistencia.Login;
using MaxiEntregas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;

namespace MaxiEntregas.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("autenticar")]
        public IHttpActionResult Autenticar(LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //TODO: Validate credentials Correctly, this code is only for demo !!
            bool isCredentialValid = LoginDAO.Autenticar(login);

            //bool isCredentialValid = (login.Password == "123456");
            if (isCredentialValid)
            {
                
                var identity = Thread.CurrentPrincipal.Identity;
                
                return Ok(200);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("List")]
        public IEnumerable<Usuario> getList() {
            
            var listaUsuarios = LoginDAO.getUsuarios();
            return listaUsuarios;
        }
    }
}
