using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{

    public class Usuario
    {
        
        public int IdUsuario{ get; set; }
        [Display(Name = "Nombre (s)")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Nombre should be minimum 3 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
       
        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Apellido Paterno should be minimum 3 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Required]

        public string Telefono { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Required]
        public string Celular { get; set; }
        public char Sexo { get; set; }
        
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Usuario should be minimum 3 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Contraseña")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string Curp { get; set; }
        public string Imagen { get; set; }
        public bool Status { get; set; }
        //public decimal Altura { get; set; }
        //public char Genero { get; set; }
        public ML.Rol Rol { get; set; }

        //ASP.Net
        public List<object> Usuarios { get; set; }
        public ML.Direccion Direccion { get; set; }

    }
}
