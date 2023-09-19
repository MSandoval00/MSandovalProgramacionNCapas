using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var query = context.EmpleadoAdd(empleado.NumeroEmpleado,
                                empleado.RFC,
                                empleado.Nombre,
                                empleado.ApellidoPaterno,
                                empleado.ApellidoMaterno,
                                empleado.Email,
                                empleado.Telefono,
                                empleado.FechaNacimiento,
                                empleado.NSS,
                                empleado.Foto,
                                empleado.Empresa.IdEmpresa);
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

        public static ML.Result Delete(string NumeroEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var query = context.EmpleadoDelete(NumeroEmpleado);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Empleado no eliminado";
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

        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var query = context.EmpleadoUpdate(empleado.NumeroEmpleado,
                                 empleado.RFC,
                                 empleado.Nombre,
                                 empleado.ApellidoPaterno,
                                 empleado.ApellidoMaterno,
                                 empleado.Email,
                                 empleado.Telefono,
                                 empleado.FechaNacimiento,
                                 empleado.NSS,
                                 empleado.Foto,
                                 empleado.Empresa.IdEmpresa);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se modificaron los datos del empleado";
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

        public static ML.Result GetById(string NumeroEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var filasAfectadas = context.EmpleadoGetById(NumeroEmpleado).FirstOrDefault();
                    result.Objects = new List<object>();
                    if (filasAfectadas != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.NumeroEmpleado = filasAfectadas.NumeroEmpleado;
                        empleado.RFC = filasAfectadas.RFC;
                        empleado.Nombre = filasAfectadas.NombreEmpleado;
                        empleado.ApellidoPaterno = filasAfectadas.ApellidoPaterno;
                        empleado.ApellidoMaterno = filasAfectadas.ApellidoMaterno;
                        empleado.Email = filasAfectadas.Email;
                        empleado.Telefono = filasAfectadas.TelefonoEmpleado;
                        empleado.FechaNacimiento = DateTime.Parse(filasAfectadas.FechaNacimiento.ToString());
                        empleado.NSS = filasAfectadas.NSS;
                        empleado.FechaIngreso = DateTime.Parse(filasAfectadas.FechaIngreso.ToString());
                        empleado.Foto = filasAfectadas.Foto;

                        empleado.Empresa = new ML.Empresa();
                        empleado.Empresa.IdEmpresa = filasAfectadas.IdEmpresa;
                        empleado.Empresa.Nombre = filasAfectadas.NombreEmpresa; //Cambiar alias
                        empleado.Empresa.Telefono = filasAfectadas.TelefonoEmpresa;


                        result.Object = empleado;
                        result.Correct = true;
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var filasAfectadas = context.EmpleadoGetAll().ToList();
                    result.Objects = new List<object>();
                    if (filasAfectadas != null)
                    {
                        foreach (var row in filasAfectadas)
                        {

                            ML.Empleado empleado = new ML.Empleado();
                            empleado.NumeroEmpleado = row.NumeroEmpleado;
                            empleado.RFC = row.RFC;
                            empleado.Nombre = row.NombreEmpleado;
                            empleado.ApellidoPaterno = row.ApellidoPaterno;
                            empleado.ApellidoMaterno = row.ApellidoMaterno;
                            empleado.Email = row.Email;
                            empleado.Telefono = row.TelefonoEmpleado;
                            empleado.FechaNacimiento = DateTime.Parse(row.FechaNacimiento.ToString());
                            empleado.NSS = row.NSS;
                            empleado.FechaIngreso = DateTime.Parse(row.FechaIngreso.ToString());
                            empleado.Foto = row.Foto;

                            empleado.Empresa = new ML.Empresa();
                            empleado.Empresa.IdEmpresa = int.Parse(row.IdEmpresa.ToString());
                            empleado.Empresa.Nombre = row.NombreEmpresa; //Cambiar alias
                            empleado.Empresa.Telefono = row.TelefonoEmpresa;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pueden mostrar los registros de los empleados";
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
