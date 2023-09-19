using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Dependiente
    {
        public static ML.Result GetByNumeroEmpleado(string NumeroEmpleado)
        {
            ML.Result resultado = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var filasAfectadas = context.DependienteGetByNumeroEmpleado(NumeroEmpleado).ToList();
                    if (filasAfectadas != null)
                    {
                        resultado.Objects = new List<object>();
                        foreach (var registro in filasAfectadas)
                        {
                            ML.Dependiente dependiente = new ML.Dependiente();
                            dependiente.IdDependiente = registro.IdDependiente;
                            //dependiente.Empleado=new ML.Empleado();
                            dependiente.Empleado.NumeroEmpleado=registro.NumeroEmpleado;
                            dependiente.Nombre = registro.Nombre;
                            dependiente.ApellidoPaterno = registro.ApellidoPaterno;
                            dependiente.ApellidoMaterno = registro.ApellidoMaterno;
                            dependiente.FechaNacimiento = DateTime.Parse(registro.FechaNacimiento.ToString());
                            dependiente.EstadoCivil=registro.EstadoCivil;
                            dependiente.Genero = Char.Parse(registro.Genero.ToString());
                            dependiente.Telefono=registro.Telefono;
                            dependiente.RFC = registro.RFC;
                          
                            resultado.Objects.Add(dependiente);

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
