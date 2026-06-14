using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HiroPhone
{
    public partial class FormSoporte : Form
    {
        private DataTable dtReparaciones;

        public FormSoporte()
        {
            InitializeComponent();
        }

        private void FormSoporte_Load(object sender, EventArgs e)
        {
            CargarEstados();
            InicializarReparaciones();
        }

        private void CargarEstados()
        {
            cboEstado.Items.Add("En Cola");
            cboEstado.Items.Add("Diagnostico");
            cboEstado.Items.Add("Reparado");
            cboEstado.Items.Add("Entregado");
            cboEstado.SelectedIndex = 0;
        }

        private void InicializarReparaciones()
        {
            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ListarServiciosTecnicos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dtReparaciones = new DataTable();
                            da.Fill(dtReparaciones);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar ordenes de soporte desde SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtReparaciones = new DataTable();
            }

            dgvReparaciones.DataSource = dtReparaciones;
            AjustarDiseñoGrid();
        }

        private void AjustarDiseñoGrid()
        {
            dgvReparaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReparaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReparaciones.RowHeadersVisible = false;
        }

        private void dgvReparaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReparaciones.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dgvReparaciones.SelectedRows[0].DataBoundItem;
                txtCliente.Text = row["Cliente"].ToString();
                txtEquipo.Text = row["Equipo"].ToString();
                txtFalla.Text = row["Falla Reportada"].ToString();
                txtCosto.Text = row["Costo"].ToString();

                string estado = row["Estado"].ToString();
                int index = cboEstado.FindStringExact(estado);
                if (index != -1) cboEstado.SelectedIndex = index;
            }
        }

        private int ObtenerOCrearCliente(string nombre)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerOCrearClienteSoporte", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    object res = cmd.ExecuteScalar();
                    return Convert.ToInt32(res);
                }
            }
        }

        private int ObtenerPrimerEmpleado()
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 id_empleado FROM Empleado", cn))
                {
                    object res = cmd.ExecuteScalar();
                    if (res != null && res != DBNull.Value)
                    {
                        return Convert.ToInt32(res);
                    }
                }
            }
            return 1; // Fallback
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string cliente = txtCliente.Text.Trim();
            string equipo = txtEquipo.Text.Trim();
            string falla = txtFalla.Text.Trim();
            string costoStr = txtCosto.Text.Trim();
            string estado = cboEstado.SelectedItem != null ? cboEstado.SelectedItem.ToString() : "En Cola";

            if (string.IsNullOrEmpty(cliente) || string.IsNullOrEmpty(equipo) || string.IsNullOrEmpty(falla))
            {
                MessageBox.Show("Por favor complete todos los datos requeridos.", "Servicio Técnico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(costoStr, out double costo))
            {
                MessageBox.Show("Por favor ingrese un costo estimado numérico válido.", "Servicio Técnico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (dgvReparaciones.SelectedRows.Count > 0)
                {
                    DialogResult r = MessageBox.Show("¿Desea actualizar la orden de trabajo seleccionada?", "Actualizar OT", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        DataRowView row = (DataRowView)dgvReparaciones.SelectedRows[0].DataBoundItem;
                        int idServicio = Convert.ToInt32(row["OT #"]);

                        // Actualizar cliente
                        int idCliente = ObtenerOCrearCliente(cliente);

                        using (SqlConnection cn = Conexion.Conectar())
                        {
                            cn.Open();
                            using (SqlCommand cmd = new SqlCommand("sp_GuardarServicioTecnico", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@id_servicio", idServicio);
                                cmd.Parameters.AddWithValue("@descripcion_falla", falla);
                                cmd.Parameters.AddWithValue("@estado_servicio", estado);
                                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                                cmd.Parameters.AddWithValue("@id_empleado", DBNull.Value);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Orden de trabajo actualizada con éxito.", "Soporte Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        InicializarReparaciones();

                        return;
                    }
                    else if (r == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                // Crear nueva orden
                int newClienteId = ObtenerOCrearCliente(cliente);
                int firstEmpleadoId = ObtenerPrimerEmpleado();

                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GuardarServicioTecnico", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_servicio", 0);
                        cmd.Parameters.AddWithValue("@descripcion_falla", falla);
                        cmd.Parameters.AddWithValue("@estado_servicio", estado);
                        cmd.Parameters.AddWithValue("@id_cliente", newClienteId);
                        cmd.Parameters.AddWithValue("@id_empleado", firstEmpleadoId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Nueva orden de trabajo de soporte ingresada al taller con éxito.", "Soporte Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);

                InicializarReparaciones();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la orden de soporte en SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            dgvReparaciones.ClearSelection();
            txtCliente.Clear();
            txtEquipo.Text = "Samsung Galaxy S24 Ultra";
            txtFalla.Text = "Pantalla rota por caída";
            txtCosto.Text = "150.00";
            cboEstado.SelectedIndex = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReparaciones.SelectedRows.Count > 0)
            {
                DialogResult r = MessageBox.Show("¿Desea eliminar la orden de trabajo seleccionada?", "Eliminar OT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    try
                    {
                        DataRowView row = (DataRowView)dgvReparaciones.SelectedRows[0].DataBoundItem;
                        int idServicio = Convert.ToInt32(row["OT #"]);
                        using (SqlConnection cn = Conexion.Conectar())
                        {
                            cn.Open();
                            using (SqlCommand cmd = new SqlCommand("sp_EliminarServicioTecnico", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@id_servicio", idServicio);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Orden de trabajo eliminada con éxito.", "Soporte Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        InicializarReparaciones();
                        LimpiarFormulario();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la orden de soporte en SQL Server:\n" + ex.Message, 
                                        "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una orden de trabajo para eliminar.", "Soporte Técnico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBuscarSoporte_TextChanged(object sender, EventArgs e)
        {
            if (dtReparaciones == null) return;
            string filtro = txtBuscarSoporte.Text.Trim().Replace("'", "''");
            if (string.IsNullOrEmpty(filtro))
            {
                dtReparaciones.DefaultView.RowFilter = "";
            }
            else
            {
                dtReparaciones.DefaultView.RowFilter = string.Format(
                    "Cliente LIKE '%{0}%' OR [Falla Reportada] LIKE '%{0}%' OR Estado LIKE '%{0}%'", filtro);
            }
        }
    }
}
