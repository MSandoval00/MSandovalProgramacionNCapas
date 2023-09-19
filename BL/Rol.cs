using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAll()
        {
            ML.Result resultado = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context= new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var filasAfectadas =context.RolGetAll();
                    resultado.Objects = new List<object>();
                    if (filasAfectadas != null)
                    {
                        foreach (var row in filasAfectadas)
                        {
                            ML.Rol rol = new ML.Rol();
                            rol.IdRol = row.IdRol;
                            rol.Nombre = row.Nombre;
                            resultado.Objects.Add(rol);
                        }
                        resultado.Correct = true;
                    }
                    else
                    {
                        resultado.Correct = false;
                        resultado.ErrorMessage = "No se pueden mostrar los registros de rol";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.ErrorMessage = ex.Message;
                resultado.Ex=ex;
                
            }
            return resultado;
        }
    }
}
