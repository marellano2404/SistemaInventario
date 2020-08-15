using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Almacen.Core.ViewModels
{
    public class ResultadoLoginViewModel
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
        public Guid IdUsuario { get; set; }
        public string UserName { get; set; }
        public string RFC { get; set; }
        public string CodigoPuesto { get; set; }

    }
    public class JWTViewModel
    {
        public string Token { get; set; }
        public long Expires { get; set; }
        public Guid IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
        public string UserName { get; set; }
        public string RFC { get; set; }
        public string CodigoPuesto { get; set; }
        public bool Exito { get; set; }
        public string Mensaje { get; set; }

    }
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
