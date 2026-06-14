using System;
using System.Data;
using System.Windows.Forms;

namespace HiroPhone
{
    // Clase para el visor de auditoria del sistema
    public partial class FormAuditoria : Form
    {
        public FormAuditoria()
        {
            InitializeComponent();
        }

        private void FormAuditoria_Load(object sender, EventArgs e)
        {
            CargarAuditoria();
        }

        // Carga los registros de auditoria ordenados por fecha mas reciente
        private void CargarAuditoria()
        {
            try
            {
                string query = @"
                    SELECT TOP 200 
                        id_auditoria AS [ID], 
                        fecha_hora AS [Fecha y Hora], 
                        tabla_afectada AS [Tabla], 
                        action AS [Acción], 
                        valor_anterior AS [V. Anterior], 
                        valor_nuevo AS [V. Nuevo] 
                    FROM auditoria_sistema 
                    ORDER BY fecha_hora DESC";
                
                DataTable dt = Conexion.ExecuteQuery(query);
                dgvAuditoria.DataSource = dt;
                AjustarDiseñoGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar auditoría: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AjustarDiseñoGrid()
        {
            dgvAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditoria.RowHeadersVisible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarAuditoria();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarAuditoria();
        }

        private void FiltrarAuditoria()
        {
            if (dgvAuditoria.DataSource is DataTable dt)
            {
                string filtro = txtBuscar.Text.Trim().Replace("'", "''");
                if (string.IsNullOrEmpty(filtro))
                {
                    dt.DefaultView.RowFilter = "";
                }
                else
                {
                    dt.DefaultView.RowFilter = string.Format(
                        "Tabla LIKE '%{0}%' OR Acción LIKE '%{0}%'", filtro);
                }
            }
        }
    }
}
