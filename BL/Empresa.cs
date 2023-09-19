using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empresa
    {
        public static ML.Result GetAll()
        {
            ML.Result resultado = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var filasAfectadas = context.EmpresaGetAll();
                    resultado.Objects = new List<object>();
                    if (filasAfectadas != null)
                    {
                        foreach (var row in filasAfectadas)
                        {
                            ML.Empresa empresa = new ML.Empresa();
                            empresa.IdEmpresa = row.IdEmpresa;
                            empresa.Nombre = row.Nombre;
                            empresa.Telefono = row.Telefono;

                            resultado.Objects.Add(empresa);
                        }
                        resultado.Correct = true;
                    }
                    else
                    {
                        resultado.Correct = false;
                        resultado.ErrorMessage = "No se pueden mostrar los registros de empresa";
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
