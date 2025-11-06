using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRunner.Model
{
    public class ConexionDB
    {
        private static ConexionDB _instancia;
        private readonly string _cadenaConexion = "Server=localhost;Database=HealthRunnerDB;Trusted_Connection=True;";

        private ConexionDB() { }

        public static ConexionDB Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ConexionDB();
                return _instancia;
            }
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }
    }
}