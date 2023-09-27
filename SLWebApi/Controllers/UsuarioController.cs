using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLWebApi.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("{nombre?}/{apellidopaterno?}")]
        public IHttpActionResult GetAll(string nombre,string apellidopaterno)
        {
            if (nombre == null) nombre = "";
            if (apellidopaterno == null) apellidopaterno = "";
            ML.Usuario usuario=new ML.Usuario();
            usuario.Nombre=nombre;
            usuario.ApellidoPaterno=apellidopaterno;

            ML.Result result = BL.Usuario.GetAllEF(usuario);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);

            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [Route("{idUsuario}")]
        [HttpGet]
        public IHttpActionResult GetById(int idUsuario)
        {
            ML.Result result=BL.Usuario.GetByIdEF(idUsuario);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);

            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
