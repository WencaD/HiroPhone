using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HiroPhone
{
    public partial class FormLogin : Form
    {
        // Importación de DLLs de Windows para permitir mover el formulario sin bordes
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public FormLogin()
        {
            InitializeComponent();
        }

        // Evento para arrastrar el formulario haciendo clic en la barra superior
        private void panelTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Botón Cerrar aplicación
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Botón Minimizar formulario
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Lógica de validación de credenciales
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            // Validación básica para campos vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Por favor ingrese usuario y contraseña.";
                lblError.Visible = true;
                return;
            }

            // Intentar validación contra base de datos SQL Server
            bool loginValido = false;

            try
            {
                string query = @"
                    SELECT TOP 1
                        u.id_usuario,
                        u.username,
                        ISNULL(e.id_empleado, 0) AS id_empleado,
                        ISNULL(e.nombres_empleado + ' ' + e.apellidos_Paterno, u.username) AS nombre_completo,
                        ISNULL(c.nombre_cargo, 'Administrador del Sistema') AS rol
                    FROM Usuario u
                    LEFT JOIN Empleado e ON u.id_usuario = e.id_usuario
                    LEFT JOIN Cargo c ON e.id_cargo = c.id_cargo
                    WHERE u.username = @User AND u.password = @Pass AND u.estado_usuario = 1";

                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@User", usuario),
                    new System.Data.SqlClient.SqlParameter("@Pass", password)
                };
                
                DataTable dt = Conexion.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    UserSession.IdUsuario = Convert.ToInt32(row["id_usuario"]);
                    UserSession.Username = row["username"].ToString();
                    UserSession.IdEmpleado = Convert.ToInt32(row["id_empleado"]);
                    UserSession.NombreCompletoEmpleado = row["nombre_completo"].ToString();
                    UserSession.Rol = row["rol"].ToString();

                    // ====================================================
                    // CARGAR PERMISOS DEL USUARIO DESDE LA BD
                    // ====================================================
                    UserSession.Permisos.Clear(); // Limpiamos los permisos anteriores
                    
                    // Consulta SQL con INNER JOIN para traer los permisos del usuario
                    string qPermisos = "SELECT p.nombre_permiso FROM Usuario_Permiso up " +
                                       "INNER JOIN Permiso p ON up.id_permiso = p.id_permiso " +
                                       "WHERE up.id_usuario = @IdUsuario";

                    System.Data.SqlClient.SqlParameter[] pPermisos = new System.Data.SqlClient.SqlParameter[]
                    {
                        new System.Data.SqlClient.SqlParameter("@IdUsuario", UserSession.IdUsuario)
                    };

                    // Ejecutamos la consulta
                    DataTable dtPermisos = Conexion.ExecuteQuery(qPermisos, pPermisos);
                    
                    // Llenamos la lista de permisos usando un bucle for tradicional
                    for (int i = 0; i < dtPermisos.Rows.Count; i++)
                    {
                        string nombrePermiso = dtPermisos.Rows[i]["nombre_permiso"].ToString();
                        UserSession.Permisos.Add(nombrePermiso);
                    }

                    loginValido = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión con SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (loginValido)
            {
                lblError.Visible = false;
                this.DialogResult = DialogResult.OK; // Esto indica al Program.cs que abra el FormPrincipal
                this.Close();
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
                lblError.Visible = true;
            }
        }

        // Permitir iniciar sesión al presionar Enter en el campo de contraseña
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIngresar.PerformClick();
                e.SuppressKeyPress = true; // Evitar sonido beep de Windows
            }
        }
    }
}
