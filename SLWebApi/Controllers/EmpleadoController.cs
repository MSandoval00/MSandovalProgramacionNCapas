using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLWebApi.Controllers
{
    
    [RoutePrefix("api/empleado")]
    public class EmpleadoController : ApiController
    {
        [HttpPost]
        [Route("")]
        public IHttpActionResult Add(ML.Empleado empleado)
        {
            ML.Result result=BL.Empleado.Add(empleado);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK,result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest,result);
            }
        }

        [HttpPut]
        [Route("{NumeroEmpleado}")]
        public IHttpActionResult Update(string NumeroEmpleado, [FromBody] ML.Empleado empleado)
        {
            empleado.NumeroEmpleado = NumeroEmpleado;//Esto es para capturar lo de header
            ML.Result result = BL.Empleado.Update(empleado);//Body
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest,result);
            }
        }
        
        [HttpDelete]
        [Route("{NumeroEmpleado}")]
        public IHttpActionResult Delete(string NumeroEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(NumeroEmpleado);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }

        }
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Empleado.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [HttpGet]
        [Route("{NumeroEmpleado}")]
        public IHttpActionResult GetByNumeroEmpleado(string NumeroEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(NumeroEmpleado);
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
