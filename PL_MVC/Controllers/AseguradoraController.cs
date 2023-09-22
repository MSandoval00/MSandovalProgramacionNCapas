using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AseguradoraController : Controller
    {
        //WebConfig
        //bindingConfiguration="BasicHttpBinding_IServiceAseguradora"

        // GET: Aseguradora
        [HttpGet]
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
        public ActionResult GetAll()
        {
            //ML.Result result = BL.Aseguradora.GetAll();
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            //aseguradora.Aseguradoras = new List<object>();
            //WCF
            ServiceReferenceAseguradora.ServiceAseguradoraClient aseguradoraWCF=new  ServiceReferenceAseguradora.ServiceAseguradoraClient();
            var result = aseguradoraWCF.GetAll();
            if (result.Correct)
            {
                aseguradora.Aseguradoras = result.Objects.ToList();
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(aseguradora);
        }


        [HttpGet]
        public ActionResult Form(int? IdAseguradora)
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario=new ML.Usuario();
            //WCF
            ServiceReferenceAseguradora.ServiceAseguradoraClient aseguradoraWCF = new ServiceReferenceAseguradora.ServiceAseguradoraClient();
            var resultadoAseguradora=aseguradoraWCF.GetAll();


            //ML.Result resultadoAseguradora = BL.Usuario.GetAllEF(aseguradora.Usuario); //Verificar 

            if (IdAseguradora != null) //Update
            {
                //WCF
                var result = aseguradoraWCF.GetById(IdAseguradora.Value);
                //Sin WCF
                //ML.Result result = BL.Aseguradora.GetById(IdAseguradora.Value);
                if (result.Correct)
                {
                    aseguradora = (ML.Aseguradora)result.Object;
                    //aseguradora.Usuario.Usuarios = resultadoAseguradora.Objects;
                    aseguradora.Usuario.Usuarios = resultadoAseguradora.Objects.ToList();
                }//Unboxing
            }
            else //Add
            {
               //// aseguradora.Aseguradoras = resultadoUsuario.Objects;
               // aseguradora.Usuario.Usuarios = resultadoAseguradora.Objects;
                aseguradora.Usuario.Usuarios = resultadoAseguradora.Objects.ToList();
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