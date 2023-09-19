using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Aseguradora
    {
        public static ML.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var query = context.AseguradoraAdd(aseguradora.Nombre, aseguradora.Usuario.IdUsuario);
                    if (query>=1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct=false;
                        result.ErrorMessage = "No se inserto el registro";
                    }
                    result.Correct=true;
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex=ex;
            }
            return result;
        }
        public static ML.Result Delete(int IdAseguradora)
        {
            ML.Result result=new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context=new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var query = context.AseguradoraDelete(IdAseguradora);
                    if (query>0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct=false;
                        result.ErrorMessage = "Aseguradora no eliminada";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage=ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result=new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context=new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var query = context.AseguradoraUpdate(aseguradora.IdAseguradora, aseguradora.Nombre,aseguradora.Usuario.IdUsuario);
                    if (query>0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct=false ;
                        result.ErrorMessage = "No se modificaron los datos de la aseguradora";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex=ex;
            }
            return result;
        }
        public static ML.Result GetById(int IdAseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context=new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var filasAfectadas = context.AseguradoraGetById(IdAseguradora).FirstOrDefault();
                    result.Objects = new List<object>();
                    if (filasAfectadas!=null)
                    {
                        ML.Aseguradora aseguradora = new ML.Aseguradora();
                        aseguradora.IdAseguradora =filasAfectadas.IdAseguradora;
                        aseguradora.Nombre = filasAfectadas.Nombre;
                        aseguradora.FechaCreacion = DateTime.Parse(filasAfectadas.FechaCreacion.ToString());
                        aseguradora.FechaModificacion = DateTime.Parse(filasAfectadas.FechaModificacion.ToString());

                        
                        //Instancia de ML.Usuario
                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.Usuario.IdUsuario = filasAfectadas.IdUsuario;
                        aseguradora.Usuario.Email = filasAfectadas.Email;

                        result.Object = aseguradora;
                        result.Correct=true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context=new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var filasAfectadas = context.AseguradoraGetAll().ToList();
                    result.Objects = new List<object>();
                    if (filasAfectadas!=null)
                    {
                        foreach (var row in filasAfectadas)
                        {
                            ML.Aseguradora aseguradora = new ML.Aseguradora();
                            aseguradora.IdAseguradora = int.Parse(row.IdAseguradora.ToString());
                            aseguradora.Nombre=row.Nombre;
                            aseguradora.FechaCreacion = DateTime.Parse(row.FechaCreacion.ToString());
                            aseguradora.FechaModificacion=DateTime.Parse(row.FechaModificacion.ToString());

                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = int.Parse(row.IdUsuario.ToString());
                            aseguradora.Usuario.Email=row.Email;
                            
                            result.Objects.Add(aseguradora);
                        }
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct=false;
                        result.ErrorMessage = "No se pueden mostrar los registros de la aseguradora";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
