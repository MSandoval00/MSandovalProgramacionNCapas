using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class DependientesController : Controller
    {
        // GET: Dependientes

        //Se realizar get all del empleado para poder mostrar la vista y realizar las peticiones
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result resultEmpleados=BL.Empleado.GetAll();
            ML.Empleado empleado=new ML.Empleado();
            empleado.Empleados = new List<object>();
            if (resultEmpleados.Correct)
            {
                empleado.Empleados = resultEmpleados.Objects;
            }
            else
            {
                ViewBag.Message = resultEmpleados.ErrorMessage;
            }

            return View(empleado);
        }
        
        public ActionResult GetDependiente(string NumeroEmpleado)
        {
            ML.Result result = BL.Dependiente.GetByNumeroEmpleado(NumeroEmpleado);
            ML.Dependiente dependiente=new ML.Dependiente();
            dependiente.Dependientes = result.Objects;
            dependiente.Empleado = new ML.Empleado();
            dependiente.Empleado.NumeroEmpleado = NumeroEmpleado;
            return View(dependiente);
        }
        [HttpGet]
        public ActionResult Form(string NumeroEmpleado, int? IdDependiente)
        {
            ML.Dependiente dependiente = new ML.Dependiente();
            //int IdDependiente = dependiente.IdDependiente;

            dependiente.Empleado=new ML.Empleado();
            dependiente.Empleado.NumeroEmpleado=NumeroEmpleado;

            //ML.Result resultEmpleado = BL.Empleado.GetAll();

            if (IdDependiente!=null)//Update
            {
                ML.Result result = BL.Dependiente.GetById(IdDependiente.Value);
                //ML.Result result1 = BL.Dependiente.GetByNumeroEmpleado(NumeroEmpleado.ToString());
                if (result.Correct)
                {
                    dependiente = (ML.Dependiente)result.Object;
                    dependiente.Dependientes=result.Objects;
                    dependiente.Empleado = new ML.Empleado();
                    dependiente.Empleado.NumeroEmpleado = NumeroEmpleado;
                    dependiente.Accion = "Update";

                }

            }
            else//Add
            {
                dependiente.Empleado.NumeroEmpleado = NumeroEmpleado;
                dependiente.Accion = "Add";
            }
            return View(dependiente);
        }
        [HttpPost]
        public ActionResult Form(ML.Dependiente dependiente)
        {
            if (dependiente.Accion=="Add")
           /* if (dependiente.IdDependiente == 0)*///Add
            {
                ML.Result result = BL.Dependiente.Add(dependiente);
                if (result.Correct)
                {
                    ViewBag.NumeroEmpleado = dependiente.Empleado.NumeroEmpleado;
                    ViewBag.Mensaje = "Se ha ingresado correctamente el dependiente";
                }
                else
                {
                    ViewBag.NumeroEmpleado = dependiente.Empleado.NumeroEmpleado;
                    ViewBag.Mensaje = "No se ingresado correctamente el dependiente. Error: " + result.ErrorMessage;
                }
            }
            else //Update
            {
                ML.Result result = BL.Dependiente.Update(dependiente);
                if (result.Correct)
                {
                    ViewBag.NumeroEmpleado = dependiente.Empleado.NumeroEmpleado;
                    ViewBag.Mensaje = "Se ha actualizado los datos del dependiente correctamente";
                }
                else
                {
                    ViewBag.NumeroEmpleado = dependiente.Empleado.NumeroEmpleado;
                    ViewBag.Mensaje = "No se ha podido actualizar correctamente los datos del dependiente" + result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }
        public ActionResult Delete(int IdDependiente)
        {
            ML.Result result = BL.Dependiente.Delete(IdDependiente);
            if (result.Correct)
            {
                ViewBag.IdDependiente = IdDependiente;
                ViewBag.Mensaje = "Dependiente borrado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "El dependiente no fue borrado correctamente" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
       
    }
}