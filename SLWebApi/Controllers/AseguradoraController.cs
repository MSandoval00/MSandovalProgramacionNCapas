using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLWebApi.Controllers
{
    [RoutePrefix("api/aseguradora")]
    public class AseguradoraController : ApiController
    {
        
        [HttpPost]
        [Route("")]
        public IHttpActionResult Add([FromBody]ML.Aseguradora aseguradora)
        {
            var result= BL.Aseguradora.Add(aseguradora);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
            //Peticiones o hacer pruebas
            //ML.Result result=BL.Aseguradora.Add(aseguradora);
            //if (result.Correct)
            //{
            //    return Content(HttpStatusCode.OK, result);
            //}
            //else
            //{
            //    return Content(HttpStatusCode.BadRequest, result);
            //}

        }
        
        [HttpDelete]
        [Route("{IdAseguradora}")]
        public IHttpActionResult Delete(int IdAseguradora)
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.IdAseguradora = IdAseguradora;
            var result = BL.Aseguradora.Delete(aseguradora.IdAseguradora);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
            //Peticiones o hacer pruebas
            //ML.Result result = BL.Aseguradora.Delete(IdAseguradora);
            //if (result.Correct)
            //{
            //    return Content(HttpStatusCode.OK, result);
            //}
            //else
            //{
            //    return Content(HttpStatusCode.BadRequest,result);
            //}
        }

        [HttpPut]
        [Route("{IdAseguradora}")]
        public IHttpActionResult Update(int IdAseguradora, [FromBody]ML.Aseguradora aseguradora)
        {
            var result = BL.Aseguradora.Update(aseguradora);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
            //Peticiones o hacer pruebas
            //aseguradora.IdAseguradora=IdAseguradora;//Esto es para capturar lo de header
            //ML.Result result=BL.Aseguradora.Update(aseguradora);//Body
            //if (result.Correct)
            //{
            //    return Content(HttpStatusCode.OK, result);
            //}
            //else
            //{
            //    return Content(HttpStatusCode.BadRequest,result) ;
            //}
        }
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest,result);
            }
        }
        [HttpGet]
        [Route("{IdAseguradora}")]
        public IHttpActionResult GetById(int IdAseguradora)
        {
            ML.Result result = BL.Aseguradora.GetById(IdAseguradora);
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
