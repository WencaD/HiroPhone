using System;
using System.Data;
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
                string query = @"
                    SELECT TOP 100
                        st.id_servicio AS [OT #],
                        c.nombre_o_razon_social AS [Cliente],
                        'Celular Cliente' AS [Equipo],
                        st.descripcion_falla AS [Falla Reportada],
                        150.00 AS [Costo],
                        st.estado_servicio AS [Estado],
                        CONVERT(VARCHAR(10), st.fecha_ingreso, 103) AS [Fecha Ingreso]
                    FROM 
                        Servicio_Tecnico st
                        INNER JOIN Cliente c ON st.id_cliente = c.id_cliente
                    ORDER BY 
                        st.fecha_ingreso DESC";

                dtReparaciones = DatabaseHelper.ExecuteQuery(query);
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
            // Buscar id_cliente por nombre_o_razon_social
            string search = "SELECT id_cliente FROM Cliente WHERE nombre_o_razon_social = @nombre";
            var param = new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@nombre", nombre) };
            object res = DatabaseHelper.ExecuteScalar(search, param);
            if (res != null && res != DBNull.Value)
            {
                return Convert.ToInt32(res);
            }
            
            // Si no existe, crear uno nuevo con datos por defecto
            string insert = @"
                INSERT INTO Cliente (numero_documento, nombre_o_razon_social, correo, telefono, id_tipo_cliente)
                VALUES (@doc, @nombre, @correo, @tel, 1);
                SELECT SCOPE_IDENTITY();";
            
            // Generar un número de documento aleatorio
            string rdoc = "10" + new Random().Next(10000000, 99999999).ToString();
            var insertParams = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@doc", rdoc),
                new System.Data.SqlClient.SqlParameter("@nombre", nombre),
                new System.Data.SqlClient.SqlParameter("@correo", nombre.Replace(" ", "").ToLower() + "@gmail.com"),
                new System.Data.SqlClient.SqlParameter("@tel", "9" + new Random().Next(10000000, 99999999).ToString())
            };
            
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(insert, insertParams));
        }

        private int ObtenerPrimerEmpleado()
        {
            object res = DatabaseHelper.ExecuteScalar("SELECT TOP 1 id_empleado FROM Empleado");
            if (res != null && res != DBNull.Value)
            {
                return Convert.ToInt32(res);
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

                        string updateQuery = @"
                            UPDATE Servicio_Tecnico
                            SET descripcion_falla = @falla, estado_servicio = @estado, id_cliente = @id_cliente
                            WHERE id_servicio = @id_servicio";

                        System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                        {
                            new System.Data.SqlClient.SqlParameter("@falla", falla),
                            new System.Data.SqlClient.SqlParameter("@estado", estado),
                            new System.Data.SqlClient.SqlParameter("@id_cliente", idCliente),
                            new System.Data.SqlClient.SqlParameter("@id_servicio", idServicio)
                        };

                        DatabaseHelper.ExecuteNonQuery(updateQuery, parameters);
                        MessageBox.Show("Orden de trabajo actualizada con éxito.", "Soporte Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (string.IsNullOrEmpty(txtBuscarSoporte.Text.Trim()))
                            InicializarReparaciones();
                        else
                            FiltrarReparaciones(txtBuscarSoporte.Text.Trim());

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

                string insertQuery = @"
                    INSERT INTO Servicio_Tecnico (fecha_ingreso, descripcion_falla, estado_servicio, id_cliente, id_empleado)
                    VALUES (GETDATE(), @falla, @estado, @id_cliente, @id_empleado)";

                System.Data.SqlClient.SqlParameter[] insertParams = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@falla", falla),
                    new System.Data.SqlClient.SqlParameter("@estado", estado),
                    new System.Data.SqlClient.SqlParameter("@id_cliente", newClienteId),
                    new System.Data.SqlClient.SqlParameter("@id_empleado", firstEmpleadoId)
                };

                DatabaseHelper.ExecuteNonQuery(insertQuery, insertParams);
                MessageBox.Show("Nueva orden de trabajo de soporte ingresada al taller con éxito.", "Soporte Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (string.IsNullOrEmpty(txtBuscarSoporte.Text.Trim()))
                    InicializarReparaciones();
                else
                    FiltrarReparaciones(txtBuscarSoporte.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la orden de soporte en SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarSoporte_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarSoporte.Text.Trim();
            if (string.IsNullOrEmpty(filtro))
            {
                InicializarReparaciones();
            }
            else
            {
                FiltrarReparaciones(filtro);
            }
        }

        private void FiltrarReparaciones(string filtro)
        {
            try
            {
                string query = @"
                    SELECT 
                        st.id_servicio AS [OT #],
                        c.nombre_o_razon_social AS [Cliente],
                        'Celular Cliente' AS [Equipo],
                        st.descripcion_falla AS [Falla Reportada],
                        150.00 AS [Costo],
                        st.estado_servicio AS [Estado],
                        CONVERT(VARCHAR(10), st.fecha_ingreso, 103) AS [Fecha Ingreso]
                    FROM 
                        Servicio_Tecnico st
                        INNER JOIN Cliente c ON st.id_cliente = c.id_cliente
                    WHERE 
                        c.nombre_o_razon_social LIKE @Filtro OR 
                        st.descripcion_falla LIKE @Filtro OR 
                        st.estado_servicio LIKE @Filtro
                    ORDER BY 
                        st.fecha_ingreso DESC";

                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Filtro", "%" + filtro + "%")
                };

                dtReparaciones = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvReparaciones.DataSource = dtReparaciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar ordenes de soporte desde SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
