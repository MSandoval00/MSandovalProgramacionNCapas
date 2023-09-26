using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AseguradoraController : Controller
    {
        //WebConfig
        //bindingConfiguration="BasicHttpBinding_IServiceAseguradora"

        // GET: Aseguradora
        //[HttpGet]
        //Stored Procedure
        //public ActionResult GetAll() 
        //{
        //    ML.Result result=BL.Aseguradora.GetAll();
        //    ML.Aseguradora aseguradora=new ML.Aseguradora();
        //    aseguradora.Aseguradoras = new List<object>();
        //    if (result.Correct)
        //    {
        //        aseguradora.Aseguradoras = result.Objects;
        //    }
        //    else
        //    {
        //        ViewBag.Message = result.ErrorMessage;
        //    }
        //    return View(aseguradora);
        //}
        //WCF
        //public ActionResult GetAll()
        //{
        //    //ML.Result result = BL.Aseguradora.GetAll();
        //    ML.Aseguradora aseguradora = new ML.Aseguradora();
        //    //aseguradora.Aseguradoras = new List<object>();
        //    //WCF

        //    ServiceReferenceAseguradora.ServiceAseguradoraClient aseguradoraWCF = new ServiceReferenceAseguradora.ServiceAseguradoraClient();
        //    var result = aseguradoraWCF.GetAll();
        //    if (result.Correct)
        //    {
        //        aseguradora.Aseguradoras = result.Objects.ToList();
        //    }
        //    else
        //    {
        //        ViewBag.Message = result.ErrorMessage;
        //    }
        //    return View(aseguradora);
        //}

        //API
        [HttpGet]
        public ActionResult GetAll()
        {
            
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Aseguradoras = new List<object>();
            //usuario.Nombre = "";
            //usuario.ApellidoPaterno = ""; 
            ML.Result result = new ML.Result();

            using (var client =new HttpClient())
            {
                //aseguradora.Aseguradoras=result.Objects.ToList();
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                var responseTask = client.GetAsync("aseguradora/");//En empleado va la busqueda
                responseTask.Wait();
                
                var resultService=responseTask.Result;
                if (resultService.IsSuccessStatusCode)
                {
                    var readTask = resultService.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultAseguradora in readTask.Result.Objects)
                    {
                        ML.Aseguradora resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Aseguradora>(resultAseguradora.ToString());
                        aseguradora.Aseguradoras.Add(resultItemList);
                    }
                }

            }
            return View(aseguradora);
        }

        //Stored y WCF
        //[HttpGet]
        //public ActionResult Form(int? IdAseguradora)
        //{
        //    ML.Aseguradora aseguradora = new ML.Aseguradora();
        //    aseguradora.Usuario=new ML.Usuario();
        //    aseguradora.Usuario.Nombre = "";
        //    aseguradora.Usuario.ApellidoPaterno = "";
        //    //WCF
        //    ServiceReferenceAseguradora.ServiceAseguradoraClient aseguradoraWCF = new ServiceReferenceAseguradora.ServiceAseguradoraClient();
        //    var resultadoAseguradora=aseguradoraWCF.UsuarioGetAll(aseguradora.Usuario);


        //    //ML.Result resultadoAseguradora = BL.Usuario.GetAllEF(aseguradora.Usuario); //Verificar 

        //    if (IdAseguradora != null) //Update
        //    {
        //        //WCF
        //        var result = aseguradoraWCF.GetById(IdAseguradora.Value);
        //        //Sin WCF
        //        //ML.Result result = BL.Aseguradora.GetById(IdAseguradora.Value);
        //        if (result.Correct)
        //        {
        //            aseguradora = (ML.Aseguradora)result.Object;
        //            //aseguradora.Usuario.Usuarios = resultadoAseguradora.Objects;
        //            aseguradora.Usuario.Usuarios = resultadoAseguradora.Objects.ToList();
        //        }//Unboxing
        //    }
        //    else //Add
        //    {
        //        //// aseguradora.Aseguradoras = resultadoUsuario.Objects;
        //        // aseguradora.Usuario.Usuarios = resultadoAseguradora.Objects;
        //        aseguradora.Usuario.Usuarios = resultadoAseguradora.Objects.ToList();

        //    }
        //    return View(aseguradora);
        //}

        [HttpGet]
        public ActionResult Form(int? IdAseguradora, ML.Aseguradora aseguradora)
        {
            //ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario();
            aseguradora.Usuario.Nombre = "";
            aseguradora.Usuario.ApellidoPaterno = "";

            ML.Result result=new ML.Result();

            if (IdAseguradora != null) //Update
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"] + "aseguradora");
                    ////POST
                    var postTask = client.PostAsync(client.BaseAddress.ToString() + IdAseguradora);
                    //var postTask = client.PostAsync("aseguradora/"+ IdAseguradora);
                    postTask.Wait();

                    var resultService= postTask.Result;
                    if (resultService.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAll");
                    }

                }
            }
            else //Add
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"] + "aseguradora");
                    //POST
                    var postTask = client.PostAsync("aseguradora/");
                    //var postTask = client.PostAsJsonAsync<ML.Aseguradora>(client.BaseAddress,aseguradora);
                    postTask.Wait();

                    var resultService = postTask.Result;
                    if (resultService.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAll");
                    }
                }

            }
            return View(aseguradora);
        }
        [HttpPost]
        public ActionResult Form(ML.Aseguradora aseguradora)
        {
            if (aseguradora.IdAseguradora==0)//Add
            {
                //WCF
                ServiceReferenceAseguradora.ServiceAseguradoraClient aseguradoraWCF = new ServiceReferenceAseguradora.ServiceAseguradoraClient();
                var result = aseguradoraWCF.Add(aseguradora);

                //ML.Result result = BL.Aseguradora.Add(aseguradora);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha ingresado correctamente la aseguradora";
                }
                else
                {
                    ViewBag.Mensaje = "No se ingresado correctamente la aseguradora. Error: " + result.ErrorMessage;
                }
            }
            else //Update
            {
                ServiceReferenceAseguradora.ServiceAseguradoraClient aseguradoraWCF = new ServiceReferenceAseguradora.ServiceAseguradoraClient();
                var result = aseguradoraWCF.Update(aseguradora);
                //ML.Result result= BL.Aseguradora.Update(aseguradora);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha actualizado los datos de la aseguradora correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "No se ha podido actualizar correctamente los datos de la aseguradora"+result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }
        public ActionResult Delete(int IdAseguradora)
        {
            //WCF
            ServiceReferenceAseguradora.ServiceAseguradoraClient aseguradoraWCF = new ServiceReferenceAseguradora.ServiceAseguradoraClient();
            var result =aseguradoraWCF.Delete(IdAseguradora);
            //ML.Result result = BL.Aseguradora.Delete(IdAseguradora);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Aseguradora borrada correctamente";
            }
            else
            {
                ViewBag.Mensaje="La aseguradora no fue borrada correctamente" +result.ErrorMessage;
            }
            return PartialView("Modal");
        }
    }
}