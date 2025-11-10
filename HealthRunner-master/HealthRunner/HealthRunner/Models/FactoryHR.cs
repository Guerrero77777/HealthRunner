using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRunner.Model
{
    public class FactoryHR
    {
        private static FactoryHR instancia = null;
        private static readonly object padlock = new object();

        private FactoryHR() { }

        public static FactoryHR Instancia
        {
            get
            {
                lock (padlock)
                {
                    if (instancia == null)
                        instancia = new FactoryHR();
                    return instancia;
                }
            }
        }

        // =========================
        // 🔹 REGISTRAR USUARIO FINAL
        // =========================
        public bool RegistrarUsuario(string nombre, string correo, string contraseña, string confirmar, DateTime fechaNacimiento, string nivel, string genero, string telefono)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@CorreoElectronico", correo);
                cmd.Parameters.AddWithValue("@PasswordHash", contraseña);
                cmd.Parameters.AddWithValue("@ConfirmarPassword", confirmar);
                cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@NivelActividad", nivel);
                cmd.Parameters.AddWithValue("@Genero", genero);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@Rol", "UsuarioFinal");

                cn.Open();
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        // =========================
        // 🔹 REGISTRAR ADMINISTRADOR
        // =========================
        public bool RegistrarAdministrador(string nombre, string correo, string contraseña, string confirmar, DateTime fechaNacimiento, string genero, string telefono)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarAdministrador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@CorreoElectronico", correo);
                cmd.Parameters.AddWithValue("@PasswordHash", contraseña);
                cmd.Parameters.AddWithValue("@ConfirmarPassword", confirmar);
                cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@Genero", genero);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@Rol", "Administrador");

                cn.Open();
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        // =========================
        // 🔹 INICIO DE SESIÓN
        // =========================
        public string IniciarSesion(string correo, string contraseña)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_LoginUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CorreoElectronico", correo);
                cmd.Parameters.AddWithValue("@PasswordHash", contraseña);

                SqlParameter rol = new SqlParameter("@Rol", SqlDbType.VarChar, 50);
                rol.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(rol);

                cn.Open();
                cmd.ExecuteNonQuery();

                return rol.Value.ToString();
            }
        }

        // =========================
        // 🔹 LISTAR USUARIOS (ADMIN)
        // =========================
        public DataTable ListarUsuarios()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarUsuarios", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }
            return tabla;
        }

        // =========================
        // 🔹 ELIMINAR USUARIO
        // =========================
        public bool EliminarUsuario(int idUsuario)
        {
            using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                cn.Open();
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }
    }
}