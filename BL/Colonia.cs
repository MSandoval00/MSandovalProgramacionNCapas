using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result GetByIdMunicipio(int idMunicipio)
        {
            ML.Result resultado = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var filasAfectadas = context.ColoniaGetByIdIdMunicipio(idMunicipio).ToList();
                    if (filasAfectadas != null)
                    {
                        resultado.Objects = new List<object>();
                        foreach (var registro in filasAfectadas)
                        {
                            ML.Colonia colonia = new ML.Colonia();
                            colonia.Nombre = registro.Nombre;
                            colonia.IdColonia = registro.IdColonia;
                            
                            resultado.Objects.Add(colonia);

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
