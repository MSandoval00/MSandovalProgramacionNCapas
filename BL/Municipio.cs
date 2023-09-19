using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result GetByIdEstado(int idEstado)
        {
            ML.Result resultado = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var filasAfectadas = context.MunicipioGetByIdEstado(idEstado).ToList();
                    if (filasAfectadas != null)
                    {
                        resultado.Objects = new List<object>();
                        foreach (var registro in filasAfectadas)
                        {
                            ML.Municipio municipio= new ML.Municipio();
                            municipio.Nombre = registro.Nombre;
                            municipio.IdMunicipio = registro.IdMunicipio;
                            resultado.Objects.Add(municipio);

                        }
                        resultado.Correct = true;
                    }
                    else
                    {
                        resultado.Correct = false;
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
