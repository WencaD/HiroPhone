using System;
using System.Data;
using System.Windows.Forms;

namespace HiroPhone
{
    // Logica para Asistencias, Contratos, Capacitaciones, Areas y Turnos
    public partial class FormRRHH : Form
    {
        private DataTable dtAsistencia;

        public FormRRHH()
        {
            InitializeComponent();
        }

        private void FormRRHH_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            InicializarAsistencias();
            CargarDatosContratos();
            CargarDatosCapacitaciones();
            CargarAreas();
            CargarTurnos();
        }

        // Llena los comboboxes de empleados
        private void CargarEmpleados()
        {
            try
            {
                string query = @"
                    SELECT 
                        e.id_empleado,
                        e.nombres_empleado + ' ' + e.apellidos_Paterno AS nombre_completo,
                        e.nombres_empleado + ' ' + e.apellidos_Paterno + ' - ' + c.nombre_cargo AS nombre_completo_cargo
                    FROM 
                        Empleado e
                        INNER JOIN Cargo c ON e.id_cargo = c.id_cargo";
                
                DataTable dt = Conexion.ExecuteQuery(query);
                
                // Cbo Asistencia
                cboEmpleado.DataSource = dt;
                cboEmpleado.DisplayMember = "nombre_completo_cargo";
                cboEmpleado.ValueMember = "id_empleado";

                // Cbo Contratos
                DataTable dtContratos = dt.Copy();
                cboEmpleadoContrato.DataSource = dtContratos;
                cboEmpleadoContrato.DisplayMember = "nombre_completo";
                cboEmpleadoContrato.ValueMember = "id_empleado";

                // Cbo Capacitaciones
                DataTable dtCapacitaciones = dt.Copy();
                cboEmpleadoCapacitacion.DataSource = dtCapacitaciones;
                cboEmpleadoCapacitacion.DisplayMember = "nombre_completo";
                cboEmpleadoCapacitacion.ValueMember = "id_empleado";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region ASISTENCIAS
        // Carga las asistencias registradas
        private void InicializarAsistencias()
        {
            try
            {
                string query = @"
                    SELECT TOP 100
                        e.nombres_empleado + ' ' + e.apellidos_Paterno AS [Empleado],
                        CONVERT(VARCHAR(10), a.fecha_asistencia, 103) AS [Fecha],
                        CONVERT(VARCHAR(8), a.hora_entrada, 108) AS [Ingreso],
                        ISNULL(CONVERT(VARCHAR(8), a.hora_salida, 108), '--:--') AS [Salida],
                        a.estado_asistencia AS [Estado]
                    FROM 
                        Asistencia a
                        INNER JOIN Empleado e ON a.id_empleado = e.id_empleado
                    ORDER BY 
                        a.fecha_asistencia DESC, a.hora_entrada DESC";

                dtAsistencia = Conexion.ExecuteQuery(query);
                dgvAsistencia.DataSource = dtAsistencia;
                dgvAsistencia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvAsistencia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvAsistencia.RowHeadersVisible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar asistencias: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Registra la entrada del dia
        private void btnEntrada_Click(object sender, EventArgs e)
        {
            if (cboEmpleado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un empleado.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView rowView = (DataRowView)cboEmpleado.SelectedItem;
            string nombre = rowView["nombre_completo"].ToString();
            int idEmpleado = Convert.ToInt32(rowView["id_empleado"]);

            try
            {
                string checkQuery = "SELECT COUNT(*) FROM Asistencia WHERE id_empleado = @id_empleado AND fecha_asistencia = CAST(GETDATE() AS DATE)";
                System.Data.SqlClient.SqlParameter[] checkParams = { new System.Data.SqlClient.SqlParameter("@id_empleado", idEmpleado) };

                int count = Convert.ToInt32(Conexion.ExecuteScalar(checkQuery, checkParams));
                if (count > 0)
                {
                    MessageBox.Show("El empleado " + nombre + " ya registró entrada hoy.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string estado = "Puntual";
                if (DateTime.Now.TimeOfDay > new TimeSpan(9, 0, 0))
                {
                    estado = "Tardanza";
                }

                string insertQuery = @"
                    INSERT INTO Asistencia (fecha_asistencia, hora_entrada, hora_salida, estado_asistencia, id_empleado)
                    VALUES (CAST(GETDATE() AS DATE), CAST(GETDATE() AS TIME), NULL, @estado, @id_empleado)";
                
                System.Data.SqlClient.SqlParameter[] insertParams = {
                    new System.Data.SqlClient.SqlParameter("@estado", estado),
                    new System.Data.SqlClient.SqlParameter("@id_empleado", idEmpleado)
                };

                Conexion.ExecuteNonQuery(insertQuery, insertParams);
                MessageBox.Show("Entrada registrada con éxito para " + nombre, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBuscarAsistencia.Text = "";
                InicializarAsistencias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar entrada: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Registra la salida del dia
        private void btnSalida_Click(object sender, EventArgs e)
        {
            if (cboEmpleado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un empleado.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView rowView = (DataRowView)cboEmpleado.SelectedItem;
            string nombre = rowView["nombre_completo"].ToString();
            int idEmpleado = Convert.ToInt32(rowView["id_empleado"]);

            try
            {
                string checkEntradaQuery = "SELECT COUNT(*) FROM Asistencia WHERE id_empleado = @id_empleado AND fecha_asistencia = CAST(GETDATE() AS DATE)";
                System.Data.SqlClient.SqlParameter[] checkParams = { new System.Data.SqlClient.SqlParameter("@id_empleado", idEmpleado) };

                int countEntrada = Convert.ToInt32(Conexion.ExecuteScalar(checkEntradaQuery, checkParams));
                if (countEntrada == 0)
                {
                    MessageBox.Show("No se encontró entrada para " + nombre + " hoy.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string checkSalidaQuery = "SELECT COUNT(*) FROM Asistencia WHERE id_empleado = @id_empleado AND fecha_asistencia = CAST(GETDATE() AS DATE) AND hora_salida IS NOT NULL";
                int countSalida = Convert.ToInt32(Conexion.ExecuteScalar(checkSalidaQuery, checkParams));
                if (countSalida > 0)
                {
                    MessageBox.Show("El empleado " + nombre + " ya registró salida hoy.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string updateQuery = @"
                    UPDATE Asistencia
                    SET hora_salida = CAST(GETDATE() AS TIME)
                    WHERE id_empleado = @id_empleado AND fecha_asistencia = CAST(GETDATE() AS DATE)";

                Conexion.ExecuteNonQuery(updateQuery, checkParams);
                MessageBox.Show("Salida registrada con éxito para " + nombre, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBuscarAsistencia.Text = "";
                InicializarAsistencias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar salida: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarAsistencia_TextChanged(object sender, EventArgs e)
        {
            if (dtAsistencia == null) return;
            string filtro = txtBuscarAsistencia.Text.Trim().Replace("'", "''");
            if (string.IsNullOrEmpty(filtro))
            {
                dtAsistencia.DefaultView.RowFilter = "";
            }
            else
            {
                dtAsistencia.DefaultView.RowFilter = string.Format(
                    "Empleado LIKE '%{0}%' OR Estado LIKE '%{0}%'", filtro);
            }
        }
        #endregion

        #region CONTRATOS
        // Muestra la lista de contratos de los empleados
        private void CargarDatosContratos()
        {
            try
            {
                string query = @"
                    SELECT 
                        con.id_contrato AS [ID],
                        emp.nombres_empleado + ' ' + emp.apellidos_Paterno AS [Empleado],
                        con.sueldo_base AS [Sueldo Base],
                        CONVERT(VARCHAR(10), con.fecha_inicio, 103) AS [F. Inicio],
                        CONVERT(VARCHAR(10), con.fecha_fin, 103) AS [F. Fin],
                        con.estado_contrato AS [Estado]
                    FROM Contrato con
                    INNER JOIN Empleado emp ON con.id_empleado = emp.id_empleado";
                
                dgvContratos.DataSource = Conexion.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar contratos: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Guarda un nuevo contrato de empleado
        private void btnRegistrarContrato_Click(object sender, EventArgs e)
        {
            if (cboEmpleadoContrato.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un empleado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal sueldo;
            if (!decimal.TryParse(txtSueldoBase.Text.Trim(), out sueldo) || sueldo <= 0)
            {
                MessageBox.Show("Ingrese un sueldo base válido mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEmpleado = Convert.ToInt32(cboEmpleadoContrato.SelectedValue);
            DateTime inicio = dtpInicioContrato.Value;
            DateTime fin = dtpFinContrato.Value;
            string estado = cboEstadoContrato.SelectedItem.ToString();

            if (inicio >= fin)
            {
                MessageBox.Show("La fecha de fin debe ser posterior a la fecha de inicio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Inactivar contratos anteriores del mismo empleado
                if (estado == "Activo")
                {
                    string qDesactivar = "UPDATE Contrato SET estado_contrato = 'Inactivo' WHERE id_empleado = " + idEmpleado;
                    Conexion.ExecuteNonQuery(qDesactivar);
                }

                string query = @"
                    INSERT INTO Contrato (fecha_inicio, fecha_fin, sueldo_base, estado_contrato, id_empleado)
                    VALUES (@Inicio, @Fin, @Sueldo, @Estado, @IdEmpleado)";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@Inicio", inicio),
                    new System.Data.SqlClient.SqlParameter("@Fin", fin),
                    new System.Data.SqlClient.SqlParameter("@Sueldo", sueldo),
                    new System.Data.SqlClient.SqlParameter("@Estado", estado),
                    new System.Data.SqlClient.SqlParameter("@IdEmpleado", idEmpleado)
                };

                Conexion.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Contrato registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatosContratos();
                txtSueldoBase.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar contrato: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CAPACITACIONES
        // Muestra la lista de capacitaciones de los empleados
        private void CargarDatosCapacitaciones()
        {
            try
            {
                string query = @"
                    SELECT 
                        cap.id_capacitacion AS [ID],
                        emp.nombres_empleado + ' ' + emp.apellidos_Paterno AS [Empleado],
                        cap.nombre_capacitacion AS [Capacitación],
                        cap.descripcion AS [Descripción],
                        CONVERT(VARCHAR(10), cap.fecha_capacitacion, 103) AS [Fecha],
                        cap.duracion_horas AS [Duración (Hrs)]
                    FROM Capacitacion cap
                    INNER JOIN Empleado emp ON cap.id_empleado = emp.id_empleado";
                
                dgvCapacitaciones.DataSource = Conexion.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar capacitaciones: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Registra una nueva capacitacion de empleado
        private void btnRegistrarCapacitacion_Click(object sender, EventArgs e)
        {
            if (cboEmpleadoCapacitacion.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un empleado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = txtNombreCapacitacion.Text.Trim();
            string desc = txtDescripcionCapacitacion.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Complete el nombre y descripción de la capacitación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEmpleado = Convert.ToInt32(cboEmpleadoCapacitacion.SelectedValue);
            DateTime fecha = dtpFechaCapacitacion.Value;
            int horas = Convert.ToInt32(nudDuracionHoras.Value);

            try
            {
                string query = @"
                    INSERT INTO Capacitacion (nombre_capacitacion, descripcion, fecha_capacitacion, duracion_horas, id_empleado)
                    VALUES (@Nombre, @Desc, @Fecha, @Horas, @IdEmpleado)";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@Nombre", nombre),
                    new System.Data.SqlClient.SqlParameter("@Desc", desc),
                    new System.Data.SqlClient.SqlParameter("@Fecha", fecha),
                    new System.Data.SqlClient.SqlParameter("@Horas", horas),
                    new System.Data.SqlClient.SqlParameter("@IdEmpleado", idEmpleado)
                };

                Conexion.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Capacitación registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatosCapacitaciones();
                txtNombreCapacitacion.Clear();
                txtDescripcionCapacitacion.Clear();
                nudDuracionHoras.Value = 8;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar capacitación: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region AREAS Y TURNOS
        // Carga las areas en el grid
        private void CargarAreas()
        {
            try
            {
                dgvAreas.DataSource = Conexion.ExecuteQuery("SELECT id_area AS [ID], nombre_area AS [Área], descripcion_area AS [Descripción] FROM Area");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar áreas: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga los turnos en el grid
        private void CargarTurnos()
        {
            try
            {
                dgvTurnos.DataSource = Conexion.ExecuteQuery("SELECT id_turno AS [ID], nombre_turno AS [Turno], CONVERT(VARCHAR(5), hora_inicio, 108) AS [Inicio], CONVERT(VARCHAR(5), hora_fin, 108) AS [Fin] FROM Turno");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar turnos: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Registra una nueva area en la BD
        private void btnRegistrarArea_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreArea.Text.Trim();
            string desc = txtDescripcionArea.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingrese el nombre del área.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO Area (nombre_area, descripcion_area) VALUES (@Nombre, @Desc)";
                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@Nombre", nombre),
                    new System.Data.SqlClient.SqlParameter("@Desc", string.IsNullOrEmpty(desc) ? (object)DBNull.Value : desc)
                };
                Conexion.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Área registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarAreas();
                txtNombreArea.Clear();
                txtDescripcionArea.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar área: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Registra un nuevo turno en la BD
        private void btnRegistrarTurno_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreTurno.Text.Trim();
            TimeSpan inicio = dtpHoraInicio.Value.TimeOfDay;
            TimeSpan fin = dtpHoraFin.Value.TimeOfDay;

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingrese el nombre del turno.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO Turno (nombre_turno, hora_inicio, hora_fin) VALUES (@Nombre, @Inicio, @Fin)";
                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@Nombre", nombre),
                    new System.Data.SqlClient.SqlParameter("@Inicio", inicio),
                    new System.Data.SqlClient.SqlParameter("@Fin", fin)
                };
                Conexion.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Turno registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTurnos();
                txtNombreTurno.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar turno: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
