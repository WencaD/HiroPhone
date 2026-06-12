using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HiroPhone
{
    public partial class FormPrincipal : Form
    {
        // Importación de DLLs de Windows para permitir mover el formulario sin bordes
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Button botonActivo = null;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        // Carga inicial del formulario
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            // Inicializar reloj y fecha
            ActualizarReloj();
            
            // Establecer el botón de Inicio como activo por defecto
            ActivarBoton(btnDashboard);

            // Cargar indicadores KPI desde la base de datos
            CargarKPIs();
        }

        // Temporizador para actualizar la hora en tiempo real
        private void timerClock_Tick(object sender, EventArgs e)
        {
            ActualizarReloj();
        }

        private void ActualizarReloj()
        {
            lblFechaHora.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy | hh:mm:ss tt");
        }

        // Permitir arrastrar la ventana desde la cabecera
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Botones de control de ventana
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximizar.Text = "🗗"; // Icono de restaurar
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximizar.Text = "🗖"; // Icono de maximizar
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Método para estilizar y marcar el botón activo en el menú lateral
        private void ActivarBoton(Button btn)
        {
            if (btn == null) return;

            // Restaurar estilo del botón anteriormente activo
            if (botonActivo != null)
            {
                botonActivo.BackColor = Color.Transparent;
                botonActivo.ForeColor = Color.FromArgb(220, 220, 240);
            }

            // Aplicar estilo al nuevo botón activo
            botonActivo = btn;
            botonActivo.BackColor = Color.FromArgb(41, 128, 185);
            botonActivo.ForeColor = Color.White;

            // Actualizar el título de la cabecera
            lblModuloActivo.Text = btn.Text.Substring(2); // Eliminar el emoji inicial
        }

        // Eventos de clic de la barra lateral
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            
            // Ocultar cualquier control dinámico e ir al Dashboard de inicio
            LimpiarControlesDinamicos();
            panelDashboardHome.Visible = true;
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormHijo(new FormInventario());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormHijo(new FormVentas());
        }

        private void btnRRHH_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormHijo(new FormRRHH());
        }

        private void btnSoporte_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormHijo(new FormSoporte());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                // Reiniciar la aplicación para mostrar el Login nuevamente
                Application.Restart();
            }
        }

        // Método auxiliar para abrir formularios hijo en el panel contenedor
        private void AbrirFormHijo(Form formHijo)
        {
            LimpiarControlesDinamicos();
            panelDashboardHome.Visible = false;

            if (formHijo != null)
            {
                formHijo.TopLevel = false;
                formHijo.FormBorderStyle = FormBorderStyle.None;
                formHijo.Dock = DockStyle.Fill;
                panelContenedor.Controls.Add(formHijo);
                formHijo.Show();
            }
        }

        // Limpiar otros controles agregados dinámicamente
        private void LimpiarControlesDinamicos()
        {
            for (int i = panelContenedor.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = panelContenedor.Controls[i];
                if (ctrl != panelDashboardHome)
                {
                    panelContenedor.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }
        }

        private void CargarKPIs()
        {
            try
            {
                // 1. Ventas del Día
                string qVentas = "SELECT ISNULL(SUM(total_venta), 0) FROM Venta WHERE CAST(fecha_venta AS DATE) = CAST(GETDATE() AS DATE)";
                double ventasHoy = Convert.ToDouble(DatabaseHelper.ExecuteScalar(qVentas));
                lblKPIVal1.Text = $"S/. {ventasHoy:N2}";
                lblKPIVal1.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold); // Reducir tamaño de letra para evitar el desborde

                // 2. Total Teléfonos en Stock
                string qStock = "SELECT ISNULL(SUM(i.stock_actual), 0) FROM Inventario i INNER JOIN Producto p ON i.id_producto = p.id_producto INNER JOIN Categoria_Producto c ON p.id_categoria = c.id_categoria WHERE c.nombre_categoria = 'Smartphones'";
                int stock = Convert.ToInt32(DatabaseHelper.ExecuteScalar(qStock));
                lblKPIVal2.Text = $"{stock} u.";

                // 3. Empleados Activos
                string qEmpleados = "SELECT COUNT(1) FROM Empleado";
                int empleados = Convert.ToInt32(DatabaseHelper.ExecuteScalar(qEmpleados));
                lblKPIVal3.Text = empleados.ToString();

                // 4. Servicio Técnico en cola/diagnóstico
                string qSoporte = "SELECT COUNT(1) FROM Servicio_Tecnico WHERE estado_servicio IN ('En Cola', 'Diagnostico')";
                int soporte = Convert.ToInt32(DatabaseHelper.ExecuteScalar(qSoporte));
                lblKPIVal4.Text = soporte.ToString();
            }
            catch (Exception)
            {
                // Fallback a valores por defecto
                lblKPIVal1.Text = "S/. 0.00";
                lblKPIVal1.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold);
                lblKPIVal2.Text = "0 u.";
                lblKPIVal3.Text = "0";
                lblKPIVal4.Text = "0";
            }
        }
    }
}
