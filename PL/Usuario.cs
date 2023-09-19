using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingresa el nombre del usuario");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa el apellido paterno del usuario");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingresa el apellido materno del usuario");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingresa el teléfono del usuario sin el 55 o 56");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingresa el celular del usuario");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingresa la letra (H) si es hombre y ingresa la letra (M) si es mujer");
            usuario.Sexo = char.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo rol de usuario");
            //Instaciar propiedad de navegación
            usuario.Rol=new ML.Rol();
            usuario.Rol.IdRol =int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el nombre de usuario");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingresa el email del usuario");
            usuario.Email=Console.ReadLine();
            Console.WriteLine("Ingresa el password del usuario");
            usuario.Password=Console.ReadLine();
            Console.WriteLine("Ingresa la fecha de nacimiento del usuario");
            usuario.FechaNacimiento=DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el CURP del usuario");
            usuario.Curp = Console.ReadLine();

            //ML.Result resultado = BL.Usuario.Add(usuario);//Sin el addSP stored procedure
            //ML.Result resultado = BL.Usuario.AddSP(usuario);
           ML.Result resultado = BL.Usuario.AddEF(usuario);
          // ML.Result resultado =BL.Usuario.AddL(usuario);
           /* Console.WriteLine(resultado);*///aqui si lo hiciste
            if (resultado.Correct)
            {
                Console.WriteLine("Usuario agregado exitosamente");
            }
            else
            {
                Console.WriteLine("Usuario no agregado" + resultado.ErrorMessage);
            }
        }
        public static void Delete()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingresa el Id del usuario a eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
           // ML.Result resultado = BL.Usuario.DeleteL(usuario);
            ML.Result resultado=BL.Usuario.DeleteEF(usuario.IdUsuario);
          // ML.Result resultado=BL.Usuario.DeleteSP(usuario);
           //ML.Result resultado = BL.Usuario.Delete(usuario); //Sin el stored procedure
            //Console.WriteLine(resultado);
            if (resultado.Correct)
            {
                Console.WriteLine("Usuario eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Usuario no eliminado"+resultado.ErrorMessage);
            }
        }
        public static void Update()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingresa el Id del usuario a actualizar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());


            Console.WriteLine("Agrega el nuevo nombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Agrega el nuevo apellido paterno del usuario");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Agrega el nuevo apellido materno del usuario");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Agrega el nuevo teléfono del usuario sin el 55 o 56");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Agrega el celular del usuario");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingresa el cambio de letra (H) si es hombre y ingresa la letra (M) si es mujer");
            usuario.Sexo = char.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el cambio de rol");
            //Instaciar propiedad de navegación
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol=int.Parse(Console.ReadLine());

            Console.WriteLine("Agrega el nuevo nombre de usuario");
            usuario.UserName=Console.ReadLine();

            Console.WriteLine("Agrega el nuevo email del usuario");
            usuario.Email=Console.ReadLine();

            Console.WriteLine("Agrega el nuevo password del usuario ");
            usuario.Password=Console.ReadLine();

            Console.WriteLine("Agrega la nueva Fecha de nacimiento del usuario ");
            usuario.FechaNacimiento=DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Agrega el nuevo CURP del usuario");
            usuario.Curp=Console.ReadLine();
            // ML.Result resultado = BL.Usuario.UpdateSP(usuario);
            // ML.Result resultado = BL.Usuario.Update(usuario);// sin el stored procedure
            //ML.Result resultado = BL.Usuario.UpdateL(usuario);
            ML.Result resultado=BL.Usuario.UpdateEF(usuario);
            //Console.WriteLine(resultado);
            if (resultado.Correct)
            {
                Console.WriteLine("Campos del usuario actualizados correctamente");
            }
            else
            {
                Console.WriteLine("Campos del usuario no actualizados"+resultado.ErrorMessage);
            }
        }
        //public static void GetAll()
        //{
        //    //ML.Usuario usuario = new ML.Usuario();

        //    //ML.Result resultado = BL.Usuario.GetAll();
        //    //ML.Result resultado = BL.Usuario.GetAllSP();
        //    ML.Result resultado=BL.Usuario.GetAllEF();
        //    //ML.Result resultado= BL.Usuario.GetUsuario();
        //    if (resultado.Correct)
        //    {
        //        foreach (ML.Usuario usuario in resultado.Objects)
        //        {
        //            Console.WriteLine("El id del usuario es: " + usuario.IdUsuario);
        //            Console.WriteLine("El nombre del usuario es: " + usuario.Nombre);
        //            Console.WriteLine("El apellido paterno del usuario es: " + usuario.ApellidoPaterno);
        //            Console.WriteLine("El apellido materno del usuario es: " + usuario.ApellidoMaterno);
        //            Console.WriteLine("El telefono del usuario es: " + usuario.Telefono);
        //            Console.WriteLine("El celular del usuario es: " + usuario.Celular);
        //            Console.WriteLine("El sexo del usuario es: " + usuario.Sexo);
        //            Console.WriteLine("El rol del usuario es: "+usuario.Rol.IdRol);
        //            Console.WriteLine("El nombre del rol es: " + usuario.Rol.Nombre);
        //            Console.WriteLine("El nombre de usuario es: " + usuario.UserName);
        //            Console.WriteLine("El email del usuario es: " + usuario.Email);
        //            Console.WriteLine("El password del usuario es: " + usuario.Password);
        //            Console.WriteLine("La Fecha de Nacimiento del usuario es: " + usuario.FechaNacimiento);
        //            Console.WriteLine("El CURP del usuario es: " + usuario.Curp);
        //            //Instaciar propiedad de navegación
        //            usuario.Rol = new ML.Rol();

        //            Console.WriteLine("***************************************************+");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error"+resultado.ErrorMessage);
        //    }
        //}
        public static void GetById()
        {

            Console.WriteLine("Ingresa el id del usuario: ");
            int idusuario=int.Parse(Console.ReadLine());
           // ML.Result resultado=BL.Usuario.GetByIdSP(idusuario);
              ML.Result resultado=BL.Usuario.GetByIdEF(idusuario);
           // ML.Result resultado = BL.Usuario.GetById(idusuario);
           //ML.Result resultado=BL.Usuario.GetByIdL(idusuario);
            if (resultado.Correct)
            {
                ML.Usuario usuario=(ML.Usuario)resultado.Object;//Unboxing
                Console.WriteLine("El id del usuario es: " + usuario.IdUsuario);
                Console.WriteLine("El nombre del usuario es: " + usuario.Nombre);
                Console.WriteLine("El apellido paterno del usuario es: " + usuario.ApellidoPaterno);
                Console.WriteLine("El apellido materno del usuario es: " + usuario.ApellidoMaterno);
                Console.WriteLine("El telefono del usuario es: " + usuario.Telefono);
                Console.WriteLine("El celular del usuario es: " + usuario.Celular);
                Console.WriteLine("El sexo del usuario es: " + usuario.Sexo); 
                Console.WriteLine("El rol del usuario es: "+usuario.Rol.IdRol);
                Console.WriteLine("El nombre del rol es: "+usuario.Rol.Nombre);
                Console.WriteLine("El nombre de usuario es: "+usuario.UserName);
                Console.WriteLine("El email del usuario es: "+usuario.Email);
                Console.WriteLine("El password del usuario es: "+usuario.Password);
                Console.WriteLine("La Fecha de Nacimiento del usuario es: "+usuario.FechaNacimiento);
                Console.WriteLine("El CURP del usuario es: "+usuario.Curp);


                //Instaciar propiedad de navegación
                usuario.Rol = new ML.Rol();
                Console.WriteLine("***************************************************+");

            }
            else
            {
                Console.WriteLine("Error" + resultado.ErrorMessage);
            }
        }
        public static void CargaMasivaTxt()
        {
            string file = @"C:\Users\digis\OneDrive\Escritorio\Mauricio Sandoval\MSandovalProgramacionNCapas\PL_MVC\Files\CargaMasivaUsuario.txt";
            if (File.Exists(file))
            {
                StreamReader streamReader = new StreamReader(file);
                string line = streamReader.ReadLine();
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] row = line.Split('|');
                    ML.Usuario usuario = new ML.Usuario();
                    usuario.Nombre = row[0];
                    usuario.ApellidoPaterno = row[1];
                    usuario.ApellidoMaterno = row[2];
                    usuario.Telefono = row[3];
                    usuario.Celular = row[4];
                    usuario.Sexo = char.Parse(row[5]);
                    usuario.Rol = new ML.Rol();
                    usuario.Rol.IdRol = int.Parse(row[6]);
                    usuario.UserName = row[7];
                    usuario.Email = row[8];
                    usuario.Password = row[9];
                    usuario.FechaNacimiento = DateTime.Parse(row[10]);
                    usuario.Curp = row[11];
                    usuario.Direccion=new ML.Direccion();
                    usuario.Direccion.Calle = row[12];
                    usuario.Direccion.NumeroInterior = row[13];
                    usuario.Direccion.NumeroExterior = row[14];
                    usuario.Direccion.Colonia = new ML.Colonia();
                    usuario.Direccion.Colonia.IdColonia = int.Parse(row[15]);
                    BL.Usuario.AddEF(usuario);

                }
            }

        }
    }

}
