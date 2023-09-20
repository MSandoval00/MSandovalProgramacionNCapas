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
        public ActionResult Form(string NumeroEmpleado)
        {
            ML.Dependiente dependiente = new ML.Dependiente();
            dependiente.Empleado=new ML.Empleado();
            dependiente.Empleado.NumeroEmpleado=NumeroEmpleado;

            if (NumeroEmpleado!=null)//Update
            {
                ML.Result result = BL.Dependiente.GetByNumeroEmpleado(NumeroEmpleado.ToString());
                if (result.Correct)
                {

                    dependiente.Empleado = new ML.Empleado();
                    dependiente.Empleado.NumeroEmpleado = NumeroEmpleado;

                }

            }
            else//Add
            {
                dependiente.Empleado.NumeroEmpleado = NumeroEmpleado;
            }
            return View(dependiente);
        }
        [HttpPost]
        public ActionResult Form(ML.Dependiente dependiente)
        {
            if (dependiente.IdDependiente == 0)//Add
            {
                ML.Result result = BL.Dependiente.Add(dependiente);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha ingresado correctamente el dependiente";
                }
                else
                {
                    ViewBag.Mensaje = "No se ingresado correctamente el dependiente. Error: " + result.ErrorMessage;
                }
            }
            else //Update
            {
                ML.Result result = BL.Dependiente.Update(dependiente);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha actualizado los datos del dependiente correctamente";
                }
                else
                {
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