using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static ML.Result GetAll()
        {
            ML.Result resultado = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context=new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var filasAfectadas = context.PaisGetAll().ToList();
                    if (filasAfectadas!=null)
                    {
                        resultado.Objects = new List<object>();
                        foreach (var registro in filasAfectadas)
                        {
                            ML.Pais pais = new ML.Pais(registro.IdPais,registro.Nombre);
                            resultado.Objects.Add(pais);
                        }
                        resultado.Correct=true;
                    }
                    else
                    {
                        resultado.Correct=false;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.ErrorMessage = ex.Message;
                resultado.Ex = ex;

            }
            return resultado;
        }
    }
}
