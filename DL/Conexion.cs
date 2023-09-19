using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; //Se agrega al momento de agregar la assembly

namespace DL
{
    public class Conexion
    {
        //Mandar a traer la cadena de conexión 
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MSandovalProgramacionNCapas"].ConnectionString.ToString();
        }
    }
}
