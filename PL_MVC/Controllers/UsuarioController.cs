using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Nombre = "";
            usuario.ApellidoPaterno = "";
            ML.Result resultado = BL.Usuario.GetAllEF(usuario);
            //ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = new List<object>();
            if (resultado.Correct)
            {
                usuario.Usuarios = resultado.Objects;
            }
            else
            {
                ViewBag.Message = resultado.ErrorMessage;
            }
            return View(usuario);
        }
        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            if (usuario.Nombre==null)
            {
                usuario.Nombre = "";
            }
            if (usuario.ApellidoPaterno==null)
            {
                usuario.ApellidoPaterno = "";

            }
            ML.Result resultado = BL.Usuario.GetAllEF(usuario);
            usuario = new ML.Usuario();
            usuario.Usuarios = resultado.Objects;
            return View(usuario);
        }
        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Direccion=new ML.Direccion();
            
            //Nuevos
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio=new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais=new ML.Pais();

            ML.Result resultadoRol = BL.Rol.GetAll();
            ML.Result resultadoPais = BL.Pais.GetAll();

            
            if (IdUsuario != null) //Update
            {
                ML.Result resultado = BL.Usuario.GetByIdEF(IdUsuario.Value);
                
                if (resultado.Correct)
                {
                    usuario = (ML.Usuario)resultado.Object;
                    usuario.Rol.Roles = resultadoRol.Objects;
                    //Nuevas
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultadoPais.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais).Objects;
                    usuario.Direccion.Colonia.Municipio.Municipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado).Objects;
                    usuario.Direccion.Colonia.Colonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio).Objects;

                   
                }
                //unboxing                
            }
            else  //Add
            {
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultadoPais.Objects;
                usuario.Rol.Roles = resultadoRol.Objects; 
            }

            return View(usuario);
        }   
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["Imagen"];
                if (file.ContentLength > 0)
                {
                    usuario.Imagen = ConvertirABase64(file);
                }

                if (usuario.IdUsuario == 0)//ADD
                {
                    ML.Result resultado = BL.Usuario.AddEF(usuario);
                    if (resultado.Correct)
                    {
                        ViewBag.Mensaje = "Se han ingresado los datos correctamente del usuario";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se ha ingresado correctamente los datos del usuario. Error: " + resultado.ErrorMessage;
                    }
                }
                else//Update
                {
                    ML.Result resultado = BL.Usuario.UpdateEF(usuario);
                    if (resultado.Correct)
                    {
                        ViewBag.Mensaje = "Se ha actualizado correctamente los datos del usuario";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se ha podido actualizar los datos del usuario. Error: " + resultado.ErrorMessage;
                    }
                }
                return PartialView("Modal");
            }
            else
            {
                ML.Result resultadoRol = BL.Rol.GetAll();
                ML.Result resultadoPais = BL.Pais.GetAll();

                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultadoPais.Objects;
                usuario.Rol.Roles = resultadoRol.Objects;
                //Posible
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultadoPais.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Estados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais).Objects;
                usuario.Direccion.Colonia.Municipio.Municipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado).Objects;
                usuario.Direccion.Colonia.Colonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio).Objects;
                return View(usuario);

            }

        }
        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
                ML.Result resultado = BL.Usuario.DeleteEF(IdUsuario);

                if (resultado.Correct)
                {
                    ViewBag.Mensaje = "Usuario borrado correctamente";
                
                }
                else
                {
                    ViewBag.Mensaje = "El usuario no fue borrado correctamente. Error:" + resultado.ErrorMessage;
                }
            return PartialView("Modal");

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            //Crear metodo
            ML.Result result = BL.Usuario.GetByEmail(email);
            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;
                if (password==usuario.Password)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Login = true;
                    ViewBag.Mensaje = "La contraseña es incorrecta";
                    return PartialView("Modal");
                }
            }
            else
            {
                ViewBag.Login = true;
                ViewBag.Mensaje = "El correo es incorrecto";
                return PartialView("Modal");
            }
        }
        public JsonResult EstadoGetByIdPais(int IdPais)
        {
            ML.Result result = BL.Estado.GetByIdPais(IdPais);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MunicipioGetByIdEstado(int IdEstado)
        {
            ML.Result result = BL.Municipio.GetByIdEstado(IdEstado);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ColoniaGetByIdIdMunicipio(int IdMunicipio)
        {
            ML.Result result = BL.Colonia.GetByIdMunicipio(IdMunicipio);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public string ConvertirABase64(HttpPostedFileBase Foto)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            string imagen = Convert.ToBase64String(data);
            return imagen;
        }
        public JsonResult ChangeStatus(int IdUsuario, bool Status)
        {
            ML.Result result=BL.Usuario.ChangeStatus(IdUsuario, Status);
            return Json(null);
        }
    }
}