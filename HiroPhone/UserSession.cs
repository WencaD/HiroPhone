using System;
using System.Collections.Generic;

namespace HiroPhone
{
    // Clase estática para guardar los datos de la sesión del usuario que inició sesión
    public static class UserSession
    {
        public static int IdUsuario { get; set; }
        public static int IdEmpleado { get; set; }
        public static string Username { get; set; }
        public static string NombreCompletoEmpleado { get; set; }
        public static string Rol { get; set; }
        
        // Lista para almacenar los permisos que el usuario tiene asignados
        public static List<string> Permisos { get; set; } = new List<string>();

        // Método para verificar si el usuario está logueado
        public static bool IsLoggedIn
        {
            get
            {
                if (IdUsuario > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Método para validar si el usuario logueado tiene un permiso específico
        public static bool HasPermission(string nombrePermiso)
        {
            if (Permisos == null)
            {
                return false;
            }

            // Buscamos si la lista contiene el permiso solicitado
            if (Permisos.Contains(nombrePermiso))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Limpia todos los datos de la sesión al cerrar sesión
        public static void Clear()
        {
            IdUsuario = 0;
            IdEmpleado = 0;
            Username = null;
            NombreCompletoEmpleado = null;
            Rol = null;
            Permisos.Clear();
        }
    }
}

