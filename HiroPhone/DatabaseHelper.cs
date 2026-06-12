using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HiroPhone
{
    public static class DatabaseHelper
    {
        // Obtiene la cadena de conexión de App.config
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["HiroPhoneDB"]?.ConnectionString;

        // Método auxiliar para obtener una conexión abierta
        private static SqlConnection GetConnection()
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {   
                throw new InvalidOperationException("La cadena de conexión 'HiroPhoneDB' no está configurada en App.config.");
            }
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        // Ejecuta una consulta SELECT y devuelve un DataTable
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Ejecuta sentencias INSERT, UPDATE, DELETE y devuelve el número de filas afectadas
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // Ejecuta una consulta que devuelve un único valor escalar (ej. COUNT, MAX)
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
