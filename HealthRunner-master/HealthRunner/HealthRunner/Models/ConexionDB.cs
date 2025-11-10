using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRunner.Model
{
    public sealed class ConexionDB
    {
        // Instancia única (Singleton)
        private static readonly ConexionDB instancia = new ConexionDB();

        // 🔹 Cadena de conexión (ajustada a tu servidor)
        private readonly string cadenaConexion =
            "Data Source=GUERRERO;Initial Catalog=HealthRunnerDB;Integrated Security=True;TrustServerCertificate=True";

        // 🔹 Constructor privado: evita que se creen instancias externas
        private ConexionDB() { }

        // 🔹 Propiedad pública de acceso a la instancia única
        public static ConexionDB Instancia
        {
            get { return instancia; }
        }

        // 🔹 Devuelve una conexión nueva y abierta a SQL Server
        public SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                // ✅ Verifica que la conexión esté cerrada antes de abrir
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
                return conexion;
            }
            catch (Exception ex)
            {
                // Si hay error, asegúrate de cerrar la conexión antes de lanzar la excepción
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();

                throw new Exception("Error al abrir la conexión con la base de datos: " + ex.Message);
            }
        }

        // 🔹 Cierra la conexión pasada como parámetro (si está abierta)
        public void CerrarConexion(SqlConnection conexion)
        {
            try
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                    conexion.Dispose(); // ✅ libera recursos correctamente
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexión con la base de datos: " + ex.Message);
            }
        }

        // 🔹 Método para probar la conexión manualmente (útil en el botón “Probar conexión”)
        public bool ProbarConexion()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    return conn.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

