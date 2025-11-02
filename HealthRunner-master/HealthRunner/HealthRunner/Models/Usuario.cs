using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRunner.Models
{
    public class Usuario
    {
        // --- Datos personales ---
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NivelActividad { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }

        // --- Estadísticas ---
        public int Pasos { get; set; }
        public double Kilometros { get; set; }
        public int Calorias { get; set; }
        public int FrecuenciaCardiaca { get; set; }

        // --- Progreso ---
        public int NivelActual { get; set; } = 1;
        public int Experiencia { get; set; } = 0; // de 0 a 100
    }
}
