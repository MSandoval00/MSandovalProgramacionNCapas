using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.OleDb;

namespace BL
{
    public class Usuario
    {
        
        //public static ML.Result Add(ML.Usuario usuario)
        //{
        //    ML.Result resultado = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context =new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "INSERT INTO Usuario VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Telefono,@Altura,@Genero )";

        //            SqlCommand cmd = new SqlCommand(query, context);//Mandamos a llamar la consulta y la conexión

        //            SqlParameter[] collection = new SqlParameter[6]; // Definimos los parametros y y cuantos se van a definir en la coleccion  ej SqlParameter[5] 

        //            collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
        //            collection[0].Value = usuario.Nombre;
        //            collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
        //            collection[1].Value = usuario.ApellidoPaterno;
        //            collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
        //            collection[2].Value = usuario.ApellidoMaterno;
        //            collection[3] = new SqlParameter("@Telefono", SqlDbType.Int);
        //            collection[3].Value = usuario.Telefono;
        //            //collection[4] = new SqlParameter("@Altura", SqlDbType.Decimal);
        //            //collection[4].Value = usuario.Altura;
        //            //collection[5] = new SqlParameter("@Genero", SqlDbType.Char);
        //            //collection[5].Value = usuario.Genero;

        //            cmd.Parameters.AddRange(collection);
        //            cmd.Connection.Open();
        //            int filasAfectadas = cmd.ExecuteNonQuery();
        //            if (filasAfectadas > 0)
        //            {
        //                resultado.Correct = true;
        //            }
        //            else
        //            {
        //                resultado.Correct =false ;
        //                resultado.ErrorMessage = "Error al agregar al usuario";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.Correct=false ;
        //        resultado.ErrorMessage = ex.Message;
        //        resultado.Ex=ex;
        //    }
        //    return resultado;
        //}
        //public static ML.Result Delete(ML.Usuario usuario)
        //{
        //    ML.Result resultado = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {

        //            string query = "DELETE FROM Usuario WHERE IdUsuario=@IdUsuario";
        //            SqlCommand cmd = new SqlCommand(query, context);
                  

        //            SqlParameter[] collection = new SqlParameter[1]; // Definimos los parametros y y cuantos se van a definir en la coleccion  ej SqlParameter[5] 

        //            collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //            collection[0].Value = usuario.IdUsuario; 
                    

        //            cmd.Parameters.AddRange(collection);
        //            cmd.Connection.Open();

        //            int filasAfectadas = cmd.ExecuteNonQuery();
        //            if (filasAfectadas>0)
        //            {
        //                resultado.Correct = true;
        //            }
        //            else
        //            {
        //                resultado.Correct = false ;
        //                resultado.ErrorMessage = "Error al eliminar al usuario";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.Correct=false ;
        //        resultado.ErrorMessage=ex.Message;
        //        resultado.Ex = ex;
        //    }
        //    return resultado;
        //}
        //public static ML.Result Update(ML.Usuario usuario)
        //{
        //    ML.Result resultado = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UPDATE Usuario SET Nombre=@Nombre, ApellidoPaterno=@ApellidoPaterno, ApellidoMaterno=@ApellidoMaterno, Telefono=@Telefono, Altura=@Altura, Genero=@Genero WHERE IdUsuario=@IdUsuario";
        //            SqlCommand cmd = new SqlCommand(query,context);
        //            SqlParameter[] collection = new SqlParameter[7];

        //            collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //            collection[0].Value = usuario.IdUsuario;
        //            collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
        //            collection[1].Value = usuario.Nombre;
        //            collection[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
        //            collection[2].Value = usuario.ApellidoPaterno;
        //            collection[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
        //            collection[3].Value = usuario.ApellidoMaterno;
        //            collection[4] = new SqlParameter("@Telefono", SqlDbType.Int);
        //            collection[4].Value = usuario.Telefono;
        //            //collection[5] = new SqlParameter("@Altura", SqlDbType.Decimal);
        //            //collection[5].Value = usuario.Altura;
        //            //collection[6] = new SqlParameter("@Genero", SqlDbType.Char);
        //            //collection[6].Value = usuario.Genero;

        //            cmd.Parameters.AddRange(collection);
        //            //cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
        //            cmd.Connection.Open();
        //            int filasAfectadas=cmd.ExecuteNonQuery();
        //            if (filasAfectadas > 0) 
        //            {
        //                resultado.Correct = true;
        //            }
        //            else
        //            {
        //                resultado.Correct = false;
        //                resultado.ErrorMessage = "Error al eliminar ";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.Correct=false;
        //        resultado.ErrorMessage =ex.Message;
        //        resultado.Ex=ex;
        //    }
        //    return resultado;
        //}
        //public static ML.Result GetAll()
        //{
        //    ML.Result resultado = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "SELECT IdUsuario, Nombre, ApellidoPaterno, ApellidoMaterno, Telefono, Altura, Genero FROM Usuario ";
        //            SqlCommand cmd = new SqlCommand(query, context);
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //            DataTable tablaUsuario = new DataTable();

        //            adapter.Fill(tablaUsuario);
        //            if (tablaUsuario.Rows.Count > 0)
        //            {
        //                resultado.Objects = new List<object>();
        //                foreach (DataRow row in tablaUsuario.Rows)
        //                {
        //                    ML.Usuario usuario = new ML.Usuario();
        //                    usuario.IdUsuario = int.Parse(row[0].ToString());
        //                    usuario.Nombre = row[1].ToString();
        //                    usuario.ApellidoPaterno = row[2].ToString();
        //                    usuario.ApellidoMaterno = row[3].ToString();
        //                    usuario.Telefono = int.Parse(row[4].ToString());
        //                    //usuario.Altura = decimal.Parse(row[5].ToString());
        //                    //usuario.Genero = char.Parse(row[6].ToString());

        //                    resultado.Objects.Add(usuario);
        //                }
        //                resultado.Correct = true;
        //            }
        //            else
        //            {
        //                resultado.Correct=false;
        //                resultado.ErrorMessage = "La tabla usuario no contiene registros";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.Correct = false;
        //        resultado.ErrorMessage = ex.Message;
        //        resultado.Ex = ex;
        //    }
        //    return resultado;
        //}
        //public static ML.Result GetById(int idusuario)
        //{
        //    ML.Result resultado = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection (DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "SELECT IdUsuario, Nombre, ApellidoPaterno, ApellidoMaterno, Telefono, Altura, Genero FROM Usuario WHERE IdUsuario=@IdUsuario";
        //            SqlCommand cmd=new SqlCommand(query, context);
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            DataTable tablaUsuario = new DataTable();
        //            SqlParameter[] collection = new SqlParameter[1];
        //            collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //            collection[0].Value = idusuario;
        //            cmd.Parameters.AddRange(collection);//Para dar a conocer la coleccion antes de llenar la tabla 

        //            adapter.Fill(tablaUsuario);
        //            if (tablaUsuario.Rows.Count > 0)
        //            {
                        
        //                DataRow row = tablaUsuario.Rows[0];
        //                ML.Usuario usuario = new ML.Usuario();
        //                usuario.IdUsuario = int.Parse(row[0].ToString());
        //                usuario.Nombre = row[1].ToString();
        //                usuario.ApellidoPaterno = row[2].ToString();
        //                usuario.ApellidoMaterno = row[3].ToString();
        //                usuario.Telefono = int.Parse(row[4].ToString());
        //                //usuario.Altura = decimal.Parse(row[5].ToString());
        //                //usuario.Genero = char.Parse(row[6].ToString());
                       

        //                resultado.Object = usuario; //Boxing
        //                resultado.Correct = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        resultado.Correct = false;
        //        resultado.ErrorMessage= ex.Message;
        //        resultado.Ex= ex;
        //    }
        //    return resultado;
        //}

        //public static ML.Result AddSP(ML.Usuario usuario)
        //{
        //    ML.Result resultado = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UsuarioAdd";
        //            SqlCommand cmd = new SqlCommand(query, context);
        //            SqlParameter[] collection = new SqlParameter[7];

        //            cmd.CommandType = CommandType.StoredProcedure;

                    
        //            collection[0] = new SqlParameter("@Nombre",SqlDbType.VarChar);
        //            collection[0].Value = usuario.Nombre;
        //            collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
        //            collection[1].Value = usuario.ApellidoPaterno;
        //            collection[2] = new SqlParameter("@ApellidoMaterno",SqlDbType.VarChar);
        //            collection[2].Value=usuario.ApellidoMaterno;
        //            collection[3] = new SqlParameter("@Telefono", SqlDbType.Int);
        //            collection[3].Value = usuario.Telefono;
        //            //collection[4]=new SqlParameter("@Altura",SqlDbType.Decimal);
        //            //collection[4].Value = usuario.Altura;
        //            //collection[5] = new SqlParameter("@Genero",SqlDbType.Char);
        //            //collection[5].Value = usuario.Genero;
                    
        //            //Propiedades de navegación
        //            //Se instamcia siempre y cuando voy a recuperar datos, si voy a ingresar se instancia en la capa PL
        //            //usuario.Rol = new ML.Rol();
        //            collection[6]=new SqlParameter("@IdRol",SqlDbType.Int);
        //            collection[6].Value=usuario.Rol.IdRol;

                   
        //            cmd.Parameters.AddRange(collection);
        //            cmd.Connection.Open();
        //            int filasAfectadas=cmd.ExecuteNonQuery();
        //            if (filasAfectadas>0)
        //            {
        //                resultado.Correct = true;
        //            }
        //            else
        //            {
        //                resultado.Correct=false;
        //                resultado.ErrorMessage = "Error al agregar al usuario";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.Correct = false;
        //        resultado.ErrorMessage=ex.Message;
        //        resultado.Ex= ex;
                
        //    }
        //    return resultado;
        //}
        //public static ML.Result DeleteSP(ML.Usuario usuario)
        //{
        //    ML.Result resultado = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context=new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UsuarioDelete";
        //            SqlCommand cmd = new SqlCommand(query,context);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlParameter[] collection = new SqlParameter[1];
        //            collection[0] = new SqlParameter("@IdUsuario", SqlDbType.VarChar);
        //            collection[0].Value = usuario.IdUsuario;

        //            cmd.Parameters.AddRange(collection);
        //            cmd.Connection.Open();
        //            int filasAfectadas=cmd.ExecuteNonQuery();
        //            if (filasAfectadas>0)
        //            {
        //                resultado.Correct=true;
        //            }
        //            else
        //            {
        //                resultado.Correct = false;
        //                resultado.ErrorMessage = "Error usuario no eliminado";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.Correct = false;
        //        resultado.ErrorMessage= ex.Message;
        //        resultado.Ex=ex;
        //    }
        //    return resultado;
        //}
        //public static ML.Result UpdateSP(ML.Usuario usuario)
        //{
        //    ML.Result resultado=new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context=new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UsuarioUpdate";
        //            SqlCommand cmd=new SqlCommand(query,context);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlParameter[] collection=new SqlParameter[8];
        //            collection[0] = new SqlParameter("@IdUsuario",SqlDbType.VarChar);
        //            collection[0].Value = usuario.IdUsuario;
        //            collection[1] = new SqlParameter("@Nombre",SqlDbType.VarChar);
        //            collection[1].Value = usuario.Nombre;
        //            collection[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
        //            collection[2].Value = usuario.ApellidoPaterno;
        //            collection[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
        //            collection[3].Value=usuario.ApellidoMaterno;
        //            collection[4] = new SqlParameter("@Telefono", SqlDbType.Int);
        //            collection[4].Value = usuario.Telefono;
        //            //collection[5] = new SqlParameter("@Altura",SqlDbType.Decimal);
        //            //collection[5].Value = usuario.Altura;
        //            //collection[6] = new SqlParameter("@Genero",SqlDbType.Char);
        //            //collection[6].Value=usuario.Genero;
        //            //Propiedades de navegación
        //            //usuario.Rol = new ML.Rol();
        //            collection[7] = new SqlParameter("@IdRol", SqlDbType.Int);
        //            collection[7].Value = usuario.Rol.IdRol;

        //            cmd.Parameters.AddRange(collection);
        //            cmd.Connection.Open();
        //            int filasAfectadas=cmd.ExecuteNonQuery();
        //            if (filasAfectadas>0)
        //            {
        //                resultado.Correct = true;
        //            }
        //            else
        //            {
        //                resultado.Correct=false;
        //                resultado.ErrorMessage = "Error campos no actualizados";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.Correct = false;
        //        resultado.ErrorMessage=ex.Message;
        //        resultado.Ex = ex;
        //    }
        //    return resultado ;
        //}
        //public static ML.Result GetAllSP()
        //{
        //    ML.Result resultado = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UsuarioGetAll";
        //            SqlCommand cmd=new SqlCommand(query,context);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //            DataTable tablaUsuario=new DataTable(); 
        //            adapter.Fill(tablaUsuario);
        //            if (tablaUsuario.Rows.Count>0)
        //            {
        //                resultado.Objects = new List<object>();
        //                foreach (DataRow row in tablaUsuario.Rows)
        //                {
        //                    ML.Usuario usuario = new ML.Usuario();
        //                    usuario.IdUsuario = int.Parse(row[0].ToString());
        //                    usuario.Nombre= row[1].ToString();
        //                    usuario.ApellidoPaterno= row[2].ToString();
        //                    usuario.ApellidoMaterno=row[3].ToString();
        //                    usuario.Telefono= int.Parse(row[4].ToString());
        //                    //usuario.Altura=decimal.Parse(row[5].ToString());
        //                    //usuario.Genero= char.Parse(row[6].ToString());

        //                    //instanciar propiedad de navegación
        //                    usuario.Rol = new ML.Rol();
        //                    usuario.Rol.IdRol =int.Parse(row[7].ToString());
                            

        //                    resultado.Objects.Add(usuario);
        //                }
        //                resultado.Correct = true;
        //            }
        //            else
        //            {
        //                resultado.Correct= false;
        //                resultado.ErrorMessage = "Error no se encuentran registros";
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        resultado.Correct = false;
        //        resultado.ErrorMessage= ex.Message;
        //        resultado.Ex= ex;
        //    }
        //    return resultado;
        //}
        //public static ML.Result GetByIdSP(int idusuario)
        //{
        //    ML.Result resultado = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UsuarioGetById";
        //            SqlCommand cmd = new SqlCommand(query, context);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            DataTable tablaUsuario = new DataTable();

        //            SqlParameter[] collection = new SqlParameter[1];
        //            collection[0]= new SqlParameter("@IdUsuario",SqlDbType.Int);
        //            collection[0].Value = idusuario;
        //            cmd.Parameters.AddRange(collection);

        //            adapter.Fill(tablaUsuario);
        //            if (tablaUsuario.Rows.Count>0)
        //            {
        //                DataRow row = tablaUsuario.Rows[0];
        //                ML.Usuario usuario= new ML.Usuario();
        //                usuario.IdUsuario = int.Parse(row[0].ToString());
        //                usuario.Nombre = row[1].ToString();
        //                usuario.ApellidoPaterno = row[2].ToString();
        //                usuario.ApellidoMaterno = row[3].ToString();
        //                usuario.Telefono = int.Parse(row[4].ToString());
        //                //usuario.Altura = decimal.Parse(row[5].ToString());
        //                //usuario.Genero = char.Parse(row[6].ToString());
        //                //Propiedad de navegacion
        //                usuario.Rol=new ML.Rol();
        //                usuario.Rol.IdRol=int.Parse(row[7].ToString());
                        
        //                resultado.Object=usuario;
        //                resultado.Correct=true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.Correct = false;
        //        resultado.ErrorMessage=ex.Message;
        //        resultado.Ex = ex;
        //    }
        //    return resultado ;
        //}
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result resultado = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context=new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    ObjectParameter filasAfectadas = new ObjectParameter("FilasAfectadas", typeof(int)); 
                                      
                    var query = context.UsuarioAdd(usuario.Nombre,
                        usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno,
                        usuario.Telefono,/* usuario.Altura,usuario.Genero.ToString(),*/
                        usuario.Celular,
                        usuario.Sexo.ToString(), 
                        usuario.Rol.IdRol,
                        usuario.UserName,
                        usuario.Email,
                        usuario.Password,
                        usuario.FechaNacimiento,
                        usuario.Curp,
                        usuario.Direccion.Calle,
                        usuario.Direccion.NumeroInterior,
                        usuario.Direccion.NumeroExterior,
                        usuario.Direccion.Colonia.IdColonia,
                        usuario.Imagen,
                        filasAfectadas
                        );
                    //usuario.Rol = new ML.Rol();
                    if ((int)filasAfectadas.Value ==2)
                        //if(query==2)
                    {
                        resultado.Correct = true;
                    }
                    else
                    {
                        resultado.Correct=false;
                        resultado.ErrorMessage = "Usuario no agregado";
                    }
                }
            }
            catch (Exception ex)
            {

                resultado.Correct=false ;
                resultado.ErrorMessage = ex.Message;
                resultado.Ex=ex;
            }
            return resultado;
        }
        public static ML.Result DeleteEF(int IdUsuario)
        {
            ML.Result resultado=new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context=new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    ObjectParameter filasAfectadas = new ObjectParameter("FilasAfectadas", typeof(int));
                    var query = context.UsuarioDelete(IdUsuario,filasAfectadas);
                    if (query > 0)
                    //if (filasAfectadas>0)
                    {
                        resultado.Correct = true;
                    }
                    else
                    {
                        resultado.Correct=false;
                        resultado.ErrorMessage = "Usuario no eliminado";
                    }
                }
            }
            catch (Exception ex)
            {

                resultado.Correct = false;
                resultado.ErrorMessage=ex.Message;
                resultado.Ex = ex;
            }
            return resultado ;
        }
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result resultado =new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context=new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    ObjectParameter filasAfectadas = new ObjectParameter("FilasAfectadas", typeof(int));
                    var query = context.UsuarioUpdate(
                        usuario.IdUsuario, 
                        usuario.Nombre, 
                        usuario.ApellidoPaterno, 
                        usuario.ApellidoMaterno, 
                        usuario.Telefono, /*usuario.Altura, usuario.Genero.ToString(),*/ 
                        usuario.Celular,
                        usuario.Sexo.ToString(),
                        usuario.Rol.IdRol,
                        usuario.UserName,
                        usuario.Email,
                        usuario.Password,
                        usuario.FechaNacimiento,
                        usuario.Curp,
                        usuario.Direccion.Calle,
                        usuario.Direccion.NumeroInterior,
                        usuario.Direccion.NumeroExterior,
                        usuario.Imagen,
                        filasAfectadas
                        );
                    //if(query>=1)
                    if (query > 0)
                    {
                        resultado.Correct = true;
                    }
                    else
                    {
                        resultado.Correct=false;
                        resultado.ErrorMessage = "Campos no actualizados";
                    }
                }
            }
            catch (Exception ex)
            {

                resultado.Correct = false;
                resultado.ErrorMessage=ex.Message;
                resultado.Ex=ex;
            }
            return resultado;
        }
        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result resultado=new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context=new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var filasAfectadas=context.UsuarioGetAll(usuario.Nombre,usuario.ApellidoPaterno).ToList();
                    resultado.Objects = new List<object>();
                    if (filasAfectadas!=null)
                    {
                        foreach (var row in filasAfectadas)
                        {
                            ML.Usuario usuarioObj=new ML.Usuario();
                            usuarioObj.IdUsuario= int.Parse(row.IdUsuario.ToString());
                            usuarioObj.Nombre= row.Nombre;
                            usuarioObj.ApellidoPaterno= row.ApellidoPaterno;
                            usuarioObj.ApellidoMaterno= row.ApellidoMaterno;
                            usuarioObj.Telefono= row.Telefono;
                            usuarioObj.Celular=row.Celular;
                            usuarioObj.Sexo=row.Sexo.FirstOrDefault();
                            usuarioObj.UserName = row.UserName;
                            usuarioObj.Email = row.Email;
                            usuarioObj.Password = row.Password;
                            usuarioObj.FechaNacimiento = DateTime.Parse(row.FechaNacimiento.ToString());
                            usuarioObj.Curp = row.CURP;
                            usuarioObj.Imagen=row.Imagen;
                            usuarioObj.Status = row.Status;
                            //Rol
                            usuarioObj.Rol = new ML.Rol();
                            usuarioObj.Rol.IdRol = int.Parse(row.IdRol.ToString());
                            usuarioObj.Rol.Nombre = row.NombreRol.ToString();
                            //Direccion
                            usuarioObj.Direccion=new ML.Direccion();
                            usuarioObj.Direccion.IdDireccion = int.Parse(row.IdDireccion.ToString());
                            usuarioObj.Direccion.Calle=row.Calle;
                            usuarioObj.Direccion.NumeroInterior=row.NumeroInterior;
                            usuarioObj.Direccion.NumeroExterior=row.NumeroExterior;
                            //Colonia
                            usuarioObj.Direccion.Colonia=new ML.Colonia();
                            usuarioObj.Direccion.Colonia.IdColonia=row.IdColonia;
                            usuarioObj.Direccion.Colonia.Nombre = row.NombreColonia;
                            usuarioObj.Direccion.Colonia.CodigoPostal = row.CodigoPostal;
                            //Municipio
                            usuarioObj.Direccion.Colonia.Municipio=new ML.Municipio();
                            usuarioObj.Direccion.Colonia.Municipio.IdMunicipio = row.IdMunicipio;
                            usuarioObj.Direccion.Colonia.Municipio.Nombre=row.NombreMunicipio;
                            //Estado
                            usuarioObj.Direccion.Colonia.Municipio.Estado=new ML.Estado();
                            usuarioObj.Direccion.Colonia.Municipio.Estado.IdEstado=row.IdEstado;
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Nombre = row.NombreEstado;
                            //Pais
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Pais=new ML.Pais();
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Pais.IdPais=row.IdPais;
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Pais.Nombre = row.NombrePais;
                            //usuario.Direccion.IdDireccion = int.Parse(row..ToString());
                            //usuario.Curp = row.CURP.ToString();

                            //usuario.Altura=decimal.Parse(row.Altura.ToString());
                            //usuario.Genero=char.Parse(row.Genero.ToString());

                            resultado.Objects.Add(usuarioObj);
                        }
                        resultado.Correct = true;
                    }
                    else
                    {
                        resultado.Correct= false;
                        resultado.ErrorMessage = "No se pueden mostrar los registros de usuarios";
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
        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result resultado = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context= new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var filasAfectadas = context.UsuarioGetById(IdUsuario).FirstOrDefault();
                  
                    resultado.Objects = new List<object>();
                    if (filasAfectadas!=null)
                    {
                        
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario =filasAfectadas.IdUsuario;
                        usuario.Nombre =filasAfectadas.Nombre;
                        usuario.ApellidoPaterno =filasAfectadas.ApellidoPaterno;
                        usuario.ApellidoMaterno =filasAfectadas.ApellidoMaterno;
                        usuario.Telefono = filasAfectadas.Telefono;
                        usuario.Celular = filasAfectadas.Celular;
                        usuario.Sexo = filasAfectadas.Sexo.FirstOrDefault();
                        usuario.UserName=filasAfectadas.UserName;
                        usuario.Email=filasAfectadas.Email;
                        usuario.Password=filasAfectadas.Password;
                        usuario.FechaNacimiento = DateTime.Parse(filasAfectadas.FechaNacimiento.ToString());
                        usuario.Curp = filasAfectadas.CURP;
                        usuario.Imagen = filasAfectadas.Imagen;
                        usuario.Status = filasAfectadas.Status;


                        //usuario.Altura=filasAfectadas.Altura;
                        //usuario.Genero = char.Parse(filasAfectadas.Genero);

                        //Instanciar Rol
                        usuario.Rol=new ML.Rol();
                       usuario.Rol.IdRol = filasAfectadas.IdRol;
                        usuario.Rol.Nombre = filasAfectadas.NombreRol.ToString();

                        //Direccion
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion=filasAfectadas.IdDireccion;
                        usuario.Direccion.Calle = filasAfectadas.Calle;
                        usuario.Direccion.NumeroInterior = filasAfectadas.NumeroInterior;
                        usuario.Direccion.NumeroExterior = filasAfectadas.NumeroExterior;
                        //Colonia
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = filasAfectadas.IdColonia;
                        usuario.Direccion.Colonia.Nombre = filasAfectadas.NombreColonia;
                        usuario.Direccion.Colonia.CodigoPostal = filasAfectadas.CodigoPostal;
                        //Municipio
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = filasAfectadas.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = filasAfectadas.NombreMunicipio;
                        //Estado
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = filasAfectadas.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = filasAfectadas.NombreEstado;
                        //Pais
                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = filasAfectadas.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = filasAfectadas.NombrePais;

                        resultado.Object=usuario;
                        resultado.Correct = true;
                    }

                }
            }
            catch (Exception ex)
            {

                resultado.Correct=false;
                resultado.ErrorMessage = ex.Message;
                resultado.Ex= ex;
            }
            return resultado ;
        }
        public static ML.Result GetByEmail (string email)
        { 
            ML.Result resultado = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context= new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var filasAfectadas = context.GetByEmail(email).FirstOrDefault();
                    resultado.Objects = new List<object>();
                    if (filasAfectadas != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.Email = filasAfectadas.Email;
                        usuario.Password = filasAfectadas.Password;

                        resultado.Object= usuario;
                        resultado.Correct=true;
                    }
                }

            }
            catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.ErrorMessage= ex.Message;
                resultado.Ex=ex;
            }
            return resultado;
        }
        public static ML.Result ChangeStatus(int IdUsuario,bool Status)
        {
            ML.Result resultado = new ML.Result();
            try
            {
                using (DL_EF.MSandovalProgramacionNcapasEntities context=new DL_EF.MSandovalProgramacionNcapasEntities())
                {
                    var filasAfectadas = context.UsuarioChangeStatus(IdUsuario, Status);
                    if (filasAfectadas > 0)
                    {
                        resultado.Correct = true;
                    }
                    else
                    {
                        resultado.Correct= false;
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

        public static ML.Result LeerExcel(string connectionString)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (OleDbConnection context = new OleDbConnection(connectionString))
                {
                    string query = "SELECT * FROM [Hoja1$]";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;

                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;

                        DataTable tableUsuario = new DataTable();

                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableUsuario.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                
                                usuario.Nombre=row[0].ToString();
                                usuario.ApellidoPaterno=row[1].ToString();
                                usuario.ApellidoMaterno=row[2].ToString();
                                usuario.Telefono=row[3].ToString();
                                usuario.Celular=row[4].ToString();
                                usuario.Sexo=char.Parse(row[5].ToString());
                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = int.Parse(row[6].ToString());
                                usuario.UserName = row[7].ToString();
                                usuario.Email = row[8].ToString();
                                usuario.Password = row[9].ToString();
                                usuario.FechaNacimiento = DateTime.Parse(row[10].ToString());
                                usuario.Curp = row[11].ToString();
                                usuario.Direccion = new ML.Direccion();
                                usuario.Direccion.Calle = row[12].ToString();
                                usuario.Direccion.NumeroInterior = row[13].ToString();
                                usuario.Direccion.NumeroExterior = row[14].ToString();
                                usuario.Direccion.Colonia = new ML.Colonia();
                                usuario.Direccion.Colonia.IdColonia = int.Parse(row[15].ToString());

                                result.Objects.Add(usuario);
                            }
                            result.Correct=true;
                        }
                        result.Object = tableUsuario;
                        if (tableUsuario.Rows.Count>0)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en el excel";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result ValidarExcel(List<object> usuarios)
        {
            ML.Result result = new ML.Result();

            try
            {
                result.Objects = new List<object>(); //almacena los registros incompletos
                int i = 1; //guarda el numero de la fila
                foreach (ML.Usuario usuario in usuarios)
                {
                    ML.ErrorExcel error = new ML.ErrorExcel();
                    error.IdRegistro = i++;
                    if (usuario.Nombre=="")
                    {
                        error.Mensaje += "Ingresar el nombre,  ";
                    }
                    if (usuario.ApellidoPaterno == "")
                    {
                        error.Mensaje += "Ingresar el apellido paterno,  ";
                    }
                    if (usuario.ApellidoMaterno == "")
                    {
                        error.Mensaje += "Ingresar el apellido materno,  ";
                    }
                    if (usuario.Telefono == "")
                    {
                        error.Mensaje += "Ingresar el Telefono,  ";
                    }
                    if (usuario.Celular == "")
                    {
                        error.Mensaje += "Ingresar el celular,  ";
                    }
                    if (usuario.Sexo.ToString() == "")
                    {
                        error.Mensaje += "Ingresar el sexo,  ";
                    }
                    if (usuario.Rol.IdRol.ToString() == "")
                    {
                        error.Mensaje += "Ingresar el rol,  ";
                    }
                    if (usuario.UserName == "")
                    {
                        error.Mensaje += "Ingresar el nombre de usuario,  ";
                    }
                    if (usuario.Email == "")
                    {
                        error.Mensaje += "Ingresar el email, ";
                    }
                    if (usuario.Password == "")
                    {
                        error.Mensaje += "Ingresar el password,  ";
                    }
                    if (usuario.FechaNacimiento.ToString() == "")
                    {
                        error.Mensaje += "Ingresar la fecha de nacimiento,  ";
                    }
                    if (usuario.Curp == "")
                    {
                        error.Mensaje += "Ingresar el curp,  ";
                    }
                    if (usuario.Direccion.Calle == "")
                    {
                        error.Mensaje += "Ingresar la calle,  ";
                    }
                    if (usuario.Direccion.NumeroInterior == "")
                    {
                        error.Mensaje += "Ingresar el numero interior,  ";
                    }
                    if (usuario.Direccion.NumeroExterior == "")
                    {
                        error.Mensaje += "Ingresar el numero exterior,  ";
                    }
                    if (usuario.Direccion.Colonia.IdColonia.ToString() == "")
                    {
                        error.Mensaje += "Ingresar la colonia  ";
                    }

                    if (error.Mensaje != null)
                    {
                        result.Objects.Add(error);
                    }


                }
                result.Correct=true;

            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }
    }
}
//LINQ
//public static ML.Result GetUsuario()
//{
//    ML.Result resultado = new ML.Result();
//    try
//    {
//        using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
//        {

//            var query = (from usuario in context.Usuarios
//                         join rol in context.Rols on usuario.IdRol equals rol.IdRol
//                         select new
//                         {
//                             IdUsuario = usuario.IdUsuario,
//                             Nombre = usuario.Nombre,
//                             ApellidoPaterno = usuario.ApellidoPaterno,
//                             ApellidoMaterno = usuario.ApellidoMaterno,
//                             Telefono = usuario.Telefono,
//                             //Altura = usuario.Altura,
//                             //Genero = usuario.Genero.ToString(),
//                             IdRol = usuario.IdRol,
//                             NombreRol = usuario.Rol.Nombre
//                         }).ToList();

//            resultado.Objects = new List<object>();
//            if (query != null)
//            {
//                foreach (var obj in query)
//                {
//                    ML.Usuario usuario = new ML.Usuario();

//                    usuario.IdUsuario = obj.IdUsuario;
//                    usuario.Nombre = obj.Nombre;
//                    usuario.ApellidoPaterno = obj.ApellidoPaterno;
//                    usuario.ApellidoMaterno = obj.ApellidoMaterno;
//                    usuario.Telefono = obj.Telefono;
//                    //usuario.Altura=obj.Altura;
//                    //usuario.Genero =char.Parse(obj.Genero.ToString());
//                    usuario.Rol = new ML.Rol();
//                    usuario.Rol.IdRol = obj.IdRol.Value;
//                    usuario.Rol.Nombre = obj.NombreRol;

//                    resultado.Objects.Add(usuario);

//                }
//                resultado.Correct = true;
//            }
//            else
//            {
//                resultado.Correct = false;
//                resultado.ErrorMessage = "No se encontraron registros";
//            }

//        }
//    }
//    catch (Exception ex)
//    {

//        resultado.Correct = false;
//        resultado.ErrorMessage = ex.Message;
//        resultado.Ex = ex;
//    }
//    return resultado;
//}
//public static ML.Result AddL(ML.Usuario usuario)
//{
//    ML.Result resultado = new ML.Result();
//    try
//    {
//        using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
//        {
//            ML.Usuario usuario1 = new ML.Usuario();

//            usuario1.Nombre = usuario.Nombre;
//            usuario1.ApellidoPaterno = usuario.ApellidoPaterno;
//            usuario1.ApellidoMaterno = usuario.ApellidoMaterno;
//            usuario1.Telefono = usuario.Telefono;
//            //usuario1.Altura = usuario.Altura;
//            //usuario1.Genero = usuario.Genero;
//            usuario1.Rol = new ML.Rol();
//            usuario1.Rol.IdRol = usuario.Rol.IdRol;

//            context.UsuarioAdd(usuario1.Nombre, usuario1.ApellidoPaterno, usuario1.ApellidoMaterno, usuario1.Telefono,/*usuario1.Altura,usuario1.Genero.ToString(),*/usuario1.Celular, usuario1.Sexo.ToString(), usuario1.Rol.IdRol, usuario1.UserName, usuario1.Email, usuario1.Password, usuario1.FechaNacimiento, usuario1.Curp, usuario1.Direccion.Calle, usuario1.Direccion.NumeroInterior, usuario1.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
//            context.SaveChanges();
//            resultado.Correct = true;

//        }
//    }
//    catch (Exception ex)
//    {

//        resultado.Correct = false;
//        resultado.ErrorMessage = ex.Message;
//        resultado.Ex = ex;
//    }
//    return resultado;
//}
//public static ML.Result UpdateL(ML.Usuario usuario)
//{
//    ML.Result resultado = new ML.Result();
//    try
//    {
//        using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
//        {
//            var query = (from a in context.Usuarios
//                         where a.IdUsuario == usuario.IdUsuario
//                         select a).SingleOrDefault();
//            if (query != null)
//            {
//                query.Nombre = usuario.Nombre;
//                query.ApellidoPaterno = usuario.ApellidoPaterno;
//                query.ApellidoMaterno = usuario.ApellidoMaterno;
//                query.Telefono = usuario.Telefono;
//                //query.Altura=usuario.Altura;
//                //query.Genero=usuario.Genero.ToString();

//                usuario.Rol = new ML.Rol();
//                usuario.Rol.IdRol = usuario.Rol.IdRol;

//                context.SaveChanges();
//                resultado.Correct = true;
//            }
//        }
//    }
//    catch (Exception ex)
//    {

//        resultado.Correct = false;
//        resultado.ErrorMessage = ex.Message;
//        resultado.Ex = ex;
//    }
//    return resultado;
//}
//public static ML.Result DeleteL(ML.Usuario usuario)
//{
//    ML.Result resultado = new ML.Result();
//    try
//    {
//        using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
//        {
//            var query = (from a in context.Usuarios
//                         where a.IdUsuario == usuario.IdUsuario
//                         select a).First();
//            context.Usuarios.Remove(query);
//            context.SaveChanges();
//            resultado.Correct = true;
//        }
//    }
//    catch (Exception ex)
//    {
//        resultado.Correct = false;
//        resultado.ErrorMessage = ex.Message;
//        resultado.Ex = ex;
//    }
//    return resultado;
//}
//public static ML.Result GetByIdL(int idUsuario)
//{
//    ML.Result resultado = new ML.Result();
//    try
//    {
//        using (DL_EF.MSandovalProgramacionNcapasEntities context = new DL_EF.MSandovalProgramacionNcapasEntities())
//        {
//            var objusuario = (from UsuarioRol in context.Usuarios
//                              join usuario in context.Usuarios on UsuarioRol.IdUsuario equals usuario.IdRol
//                              join rol in context.Rols on UsuarioRol.IdRol equals rol.IdRol
//                              where UsuarioRol.IdUsuario == usuario.IdUsuario
//                              where UsuarioRol.IdRol == usuario.IdRol
//                              select new
//                              {
//                                  IdUsuario = usuario.IdUsuario,
//                                  Nombre = usuario.Nombre,
//                                  ApellidoPaterno = usuario.ApellidoPaterno,
//                                  ApellidoMaterno = usuario.ApellidoMaterno,
//                                  Telefono = usuario.Telefono,
//                                  //Altura = usuario.Altura,
//                                  //Genero = usuario.Genero,
//                                  IdRol = usuario.IdRol,
//                                  NombreRol = usuario.Rol.Nombre
//                              }).FirstOrDefault(); // se asigna un objeto que se manda a llamar para asignar los valores dentro del método
//                                                   // resultado.Objects = new List<object>(); no se usa por que solo trae un elemento
//            if (objusuario != null)
//            {
//                ML.Usuario usuario = new ML.Usuario();
//                usuario.IdUsuario = objusuario.IdUsuario;
//                usuario.Nombre = objusuario.Nombre; //ejemplo
//                usuario.ApellidoPaterno = objusuario.ApellidoPaterno;
//                usuario.ApellidoMaterno = objusuario.ApellidoMaterno;
//                usuario.Telefono = objusuario.Telefono;
//                //usuario.Altura = objusuario.Altura;
//                //usuario.Genero = char.Parse(objusuario.Genero.ToString());
//                usuario.Rol = new ML.Rol();
//                usuario.Rol.IdRol = objusuario.IdRol.Value;
//                usuario.Rol.Nombre = objusuario.NombreRol;

//                resultado.Object = usuario;
//                resultado.Correct = true;
//            }


//        }
//    }
//    catch (Exception ex)
//    {

//        resultado.Correct = false;
//        resultado.ErrorMessage = ex.Message;
//        resultado.Ex = ex;
//    }
//    return resultado;
//}

