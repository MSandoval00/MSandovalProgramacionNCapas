using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetByIdPais(int idPais)
        {
            ML.Result resultado = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var filasAfectadas = context.EstadoGetByIdPais(idPais).ToList();
                    if (filasAfectadas != null)
                    {
                        resultado.Objects = new List<object>();
                        foreach (var registro in filasAfectadas)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.Nombre=registro.Nombre;
                            estado.IdEstado = registro.IdEstado;
                            resultado.Objects.Add(estado);

                        }
                        resultado.Correct = true;
                    }
                    else
                    {
                        resultado.Correct=false;
                    }
                }
            }
            catch (Exception ex)
            {
                //resultado.Correct = false;
                resultado.ErrorMessage = ex.Message;
                //resultado.Ex = ex;
            }
            return resultado;
        }
    }
}
