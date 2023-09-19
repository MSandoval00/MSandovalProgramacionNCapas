using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Ingresa la opcion \n 1- Agregar usuario,\n 2-Borrar usuario,\n 3-Actualizar usuario,\n 4-Buscar todos los usuarios,\n 5-Buscar por id al usuario");
            //int opcion=int.Parse(Console.ReadLine());
            //switch (opcion)
            //{
            //    case 1:
            //        PL.Usuario.Add();
            //        Console.ReadKey();
            //        break;
            //        case 2:
            //        PL.Usuario.Delete();
            //        Console.ReadKey();
            //        break;
            //    case 3:
            //        PL.Usuario.Update();
            //        Console.ReadKey();
            //        break;
            //        case 4:
            //        //PL.Usuario.GetAll();
            //        Console.ReadKey();
            //        break;
            //        case 5:
            //        PL.Usuario.GetById();
            //        Console.ReadKey();
            //        break;
            //    default:
            //        break;
            //}
            PL.Usuario.CargaMasivaTxt();
            Console.ReadKey();
        }
    }
}
