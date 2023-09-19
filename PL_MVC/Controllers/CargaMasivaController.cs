using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PL_MVC.Controllers
{
    public class CargaMasivaController : Controller
    {
        // GET: CargaMasiva
        public ActionResult Cargar()
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            return View(result);
        }
        [HttpPost]
        public ActionResult Cargar(ML.Result result)
        {
            HttpPostedFileBase file = Request.Files["Excel"];
            //HttpPostedFileBase filetxt = Request.Files["Txt"];

            if(Session["pathExcel"] == null)
            {
                if (file != null)
                {

                    string extensionArchivo = Path.GetExtension(file.FileName).ToLower();
                    string extesionValida = ConfigurationManager.AppSettings["TipoExcel"];

                    if (extensionArchivo == extesionValida)
                    {
                        string rutaproyecto = Server.MapPath("~/CargaMasiva/");
                        string filePath = rutaproyecto + Path.GetFileNameWithoutExtension(file.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                        
                        if (!System.IO.File.Exists(filePath))
                        {

                            file.SaveAs(filePath);


                            string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"] + filePath;
                            ML.Result resultUsuarios = BL.Usuario.LeerExcel(connectionString);

                            if (resultUsuarios.Correct)
                            {
                                ML.Result resultValidacion = BL.Usuario.ValidarExcel(resultUsuarios.Objects);
                                //ML.Result resultValidacion = BL.Usuario.ValidarExcel(resultUsuarios.Objects);
                                if(resultValidacion.Objects.Count == 0)
                                {
                                    resultValidacion.Correct = true;
                                    //resultValidacion.Correct = true;
                                    Session["pathExcel"] = filePath;
                                }

                                return View(resultValidacion);
                            }
                            else
                            {
                                ViewBag.Message = "El excel no contiene registros";
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Favor de seleccionar un archivo .xlsx, Verifique su archivo";
                    }
                }
                else
                {
                    ViewBag.Message = "No selecciono ningun archivo, Seleccione uno correctamente";
                }
                return View(result);
            }
            else
            {
                string filepath = Session["pathExcel"].ToString();

                if (filepath != null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"] + filepath;
                    ML.Result resultUsuarios = BL.Usuario.LeerExcel(connectionString);

                    if (resultUsuarios.Correct)
                    {
                        ML.Result resultErrores = new ML.Result();//Instanciar antes de entrar al flujo 
                        resultErrores.Objects = new List<object>();

                        foreach (ML.Usuario usuario in resultUsuarios.Objects)
                        {
                            ML.Result result1 = BL.Usuario.AddEF(usuario);
                            if (!result1.Correct)
                            {
                                string error = "Ocurrio un problema al insertar los datos: " +usuario.Email+" con este error"+ resultErrores.ErrorMessage;
                                resultErrores.Objects.Add(error);
                                //CREAR UN TXT CON LOS ERRORES 
                            }
                            Session["pathExcel"] = null;
                        }
                        if (resultErrores.Objects.Count>0)
                        {
                            string path = Server.MapPath(@"~\Files\logErrores");
                            string filePath = path + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

                            using (StreamWriter writer=new StreamWriter(filePath))
                            {
                                foreach (string linea in resultErrores.Objects)
                                {
                                    
                                    writer.WriteLine(linea);
                                }
                            }
                        }
                    }

                }
            }
            return View(result);
        }
    }
}