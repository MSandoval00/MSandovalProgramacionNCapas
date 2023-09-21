using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Dependiente
    {
        public static ML.Result GetById(int IdDependiente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context= new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var query = context.DependienteGetByIdDependiente(IdDependiente).FirstOrDefault();
                    result.Objects = new List<object>();
                    if (query!=null)
                    {
                        ML.Dependiente dependiente = new ML.Dependiente();
                        dependiente.IdDependiente = query.IdDependiente;
                        dependiente.Empleado = new ML.Empleado();
                        dependiente.Empleado.NumeroEmpleado = query.NumeroEmpleado;
                        dependiente.Nombre=query.Nombre;
                        dependiente.ApellidoPaterno=query.ApellidoPaterno;
                        dependiente.ApellidoMaterno=query.ApellidoMaterno;
                        dependiente.FechaNacimiento = DateTime.Parse(query.FechaNacimiento.ToString());
                        dependiente.EstadoCivil=query.EstadoCivil;
                        dependiente.Genero = query.Genero.FirstOrDefault();
                        dependiente.Telefono=query.Telefono;
                        dependiente.RFC=query.RFC;

                        result.Object=dependiente;
                        result.Correct = true;
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
                            dependiente.Empleado=new ML.Empleado();
                            dependiente.Empleado.NumeroEmpleado=registro.NumeroEmpleado;
                            dependiente.Nombre = registro.Nombre;
                            dependiente.ApellidoPaterno = registro.ApellidoPaterno;
                            dependiente.ApellidoMaterno = registro.ApellidoMaterno;
                            dependiente.FechaNacimiento = DateTime.Parse(registro.FechaNacimiento.ToString());
                            dependiente.EstadoCivil=registro.EstadoCivil;
                            dependiente.Genero = registro.Genero.FirstOrDefault();
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
        public static ML.Result Add(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var query = context.DependienteAdd(dependiente.Empleado.NumeroEmpleado,
                        dependiente.Nombre, 
                        dependiente.ApellidoPaterno,
                        dependiente.ApellidoMaterno,
                        dependiente.FechaNacimiento,
                        dependiente.EstadoCivil,
                        dependiente.Genero.ToString(),
                        dependiente.Telefono,
                        dependiente.RFC);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto el registro";
                    }
                    result.Correct = true;
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
        public static ML.Result Delete(int IdDependiente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var query = context.DependienteDelete(IdDependiente);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Dependiente no eliminado";
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
        public static ML.Result Update(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var query = context.DependienteUpdate(dependiente.IdDependiente,
                        dependiente.Empleado.NumeroEmpleado,
                        dependiente.Nombre, 
                        dependiente.ApellidoPaterno,
                        dependiente.ApellidoMaterno,
                        dependiente.FechaNacimiento,
                        dependiente.EstadoCivil,
                        dependiente.Genero.ToString(),
                        dependiente.Telefono,
                        dependiente.RFC);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se modificaron los datos del dependiente";
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
