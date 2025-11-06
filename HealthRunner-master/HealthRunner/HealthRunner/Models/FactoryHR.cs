using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRunner.Model
{
    public static class FactoryHR
    {
        public static Usuario CrearUsuario(string nombre, string correo, string contrasena)
        {
            return new Usuario
            {
                Nombre = nombre,
                CorreoElectronico = correo,
                Contrasena = contrasena,
                Rol = "Usuario",
                FechaRegistro = DateTime.Now,
                Activo = true
            };
        }

        public static Usuario CrearAdministrador(string nombre, string correo, string contrasena)
        {
            return new Usuario
            {
                Nombre = nombre,
                CorreoElectronico = correo,
                Contrasena = contrasena,
                Rol = "Administrador",
                FechaRegistro = DateTime.Now,
                Activo = true
            };
        }
    }

    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
    }
}
