using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        //public ActionResult Empleado()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult GetAll()
        {
            //ML.Result result = BL.Empleado.GetAll();
            ML.Empleado empleado = new ML.Empleado();
            ServiceReferenceEmpleado.ServiceEmpleadoClient empleadoWCF= new ServiceReferenceEmpleado.ServiceEmpleadoClient();
            var result =empleadoWCF.GetAll();
            //empleado.Empleados = new List<object>();
            if (result.Correct)
            {
                empleado.Empleados = result.Objects.ToList();
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(empleado);
        }

        //Verificar si entra a realizar la condición
        [HttpGet]
        public ActionResult Form(string NumeroEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();
            //WCF
            ServiceReferenceEmpleado.ServiceEmpleadoClient empleadoWCF = new ServiceReferenceEmpleado.ServiceEmpleadoClient();
            var resultadoEmpresa = empleadoWCF.EmpresaGetAll();
            //ML.Result resultadoEmpresa = BL.Empresa.GetAll();

            if (NumeroEmpleado != null) //Update
            {
                //WCF
                var result = empleadoWCF.GetById(NumeroEmpleado.ToString());
                
                /*ML.Result result = BL.Empleado.GetById(NumeroEmpleado.ToString());*/ //Verificar si va con value
                if (result.Correct)
                {
                    empleado = (ML.Empleado)result.Object;
                    empleado.Empresa.Empresas = resultadoEmpresa.Objects.ToList();
                    empleado.Accion = "Update";
                }//Unboxing
            }
            else //Add
            {
                empleado.Empresa.Empresas = resultadoEmpresa.Objects.ToList();
                empleado.Accion = "Add";
            }
            return View(empleado);
        }
        [HttpPost]
        public ActionResult Form(ML.Empleado empleado)
        {

            ServiceReferenceEmpleado.ServiceEmpleadoClient empleadoWCF = new ServiceReferenceEmpleado.ServiceEmpleadoClient();
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["Imagen"];
                if (file.ContentLength > 0)
                {
                    empleado.Foto = ConvertirABase64(file);
                }

                if (empleado.Accion == "Add")//Add //Verificar si entra al if
                {
                    //WCF
                    var result = empleadoWCF.Add(empleado);
                    //ML.Result result = BL.Empleado.Add(empleado);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Se ha ingresado correctamente el empleado";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se ingresado correctamente el empleado. Error: " + result.ErrorMessage;
                    }
                }
                else //Update
                {
                    //WCF 
                    var result =empleadoWCF.Update(empleado);
                    //ML.Result result = BL.Empleado.Update(empleado);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Se ha actualizado los datos del empleado correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se ha podido actualizar correctamente los datos del empleado" + result.ErrorMessage;
                    }
                }
                return PartialView("Modal");
            }
            else
            {
                var resultadoEmpresa = empleadoWCF.GetAll();
                //ML.Result resultadoEmpresa = BL.Empresa.GetAll();
                empleado.Empresa.Empresas = resultadoEmpresa.Objects.ToList();
                return View(empleado);
            }
        }
        public ActionResult Delete(string NumeroEmpleado)
        {
            ServiceReferenceEmpleado.ServiceEmpleadoClient empleadoWCF = new ServiceReferenceEmpleado.ServiceEmpleadoClient();
            var result = empleadoWCF.Delete(NumeroEmpleado);
            //ML.Result result = BL.Empleado.Delete(NumeroEmpleado);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Empleado borrado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "El empleado no fue borrado correctamente" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
        public string ConvertirABase64(HttpPostedFileBase Foto)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            string imagen = Convert.ToBase64String(data);
            return imagen;
        }

    }
}