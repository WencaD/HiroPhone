using System;
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
                string query = "SELECT COUNT(1) FROM Usuario WHERE username = @User AND password = @Pass AND estado_usuario = 1";
                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@User", usuario),
                    new System.Data.SqlClient.SqlParameter("@Pass", password)
                };
                
                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
                if (count > 0)
                {
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
