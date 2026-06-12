using System;
using System.Data;
using System.Windows.Forms;

namespace HiroPhone
{
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
        }

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
                
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                cboEmpleado.DataSource = dt;
                cboEmpleado.DisplayMember = "nombre_completo_cargo";
                cboEmpleado.ValueMember = "id_empleado";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados desde SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarAsistencias()
        {
            try
            {
                string query = @"
                    SELECT TOP 100
                        e.nombres_empleado + ' ' + e.apellidos_Paterno AS [Empleado],
                        CONVERT(VARCHAR(10), a.fecha_asistencia, 103) AS [Fecha],
                        CONVERT(VARCHAR(8), a.hora_entrada, 108) AS [Hora Entrada],
                        ISNULL(CONVERT(VARCHAR(8), a.hora_salida, 108), '--:--') AS [Hora Salida],
                        a.estado_asistencia AS [Estado]
                    FROM 
                        Asistencia a
                        INNER JOIN Empleado e ON a.id_empleado = e.id_empleado
                    ORDER BY 
                        a.fecha_asistencia DESC, a.hora_entrada DESC";

                dtAsistencia = DatabaseHelper.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar asistencias desde SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtAsistencia = new DataTable();
            }

            dgvAsistencia.DataSource = dtAsistencia;
            AjustarDiseñoGrid();
        }

        private void AjustarDiseñoGrid()
        {
            dgvAsistencia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAsistencia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAsistencia.RowHeadersVisible = false;
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            if (cboEmpleado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un empleado.", "Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView rowView = (DataRowView)cboEmpleado.SelectedItem;
            string nombre = rowView["nombre_completo"].ToString();
            int idEmpleado = Convert.ToInt32(rowView["id_empleado"]);

            try
            {
                // Verificar si ya registró entrada hoy en la base de datos
                string checkQuery = "SELECT COUNT(*) FROM Asistencia WHERE id_empleado = @id_empleado AND fecha_asistencia = CAST(GETDATE() AS DATE)";
                System.Data.SqlClient.SqlParameter[] checkParams = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@id_empleado", idEmpleado)
                };

                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));
                if (count > 0)
                {
                    MessageBox.Show($"El empleado {nombre} ya registró su entrada para el día de hoy.", "Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                
                System.Data.SqlClient.SqlParameter[] insertParams = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@estado", estado),
                    new System.Data.SqlClient.SqlParameter("@id_empleado", idEmpleado)
                };

                DatabaseHelper.ExecuteNonQuery(insertQuery, insertParams);
                MessageBox.Show($"Entrada registrada con éxito para {nombre} a las {DateTime.Now.ToShortTimeString()}.", "Entrada Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Recargar las asistencias de la BD
                if (string.IsNullOrEmpty(txtBuscarAsistencia.Text.Trim()))
                {
                    InicializarAsistencias();
                }
                else
                {
                    FiltrarAsistencias(txtBuscarAsistencia.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar entrada en SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            if (cboEmpleado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un empleado.", "Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView rowView = (DataRowView)cboEmpleado.SelectedItem;
            string nombre = rowView["nombre_completo"].ToString();
            int idEmpleado = Convert.ToInt32(rowView["id_empleado"]);

            try
            {
                // Verificar si ya registró entrada hoy
                string checkEntradaQuery = "SELECT COUNT(*) FROM Asistencia WHERE id_empleado = @id_empleado AND fecha_asistencia = CAST(GETDATE() AS DATE)";
                System.Data.SqlClient.SqlParameter[] checkParams = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@id_empleado", idEmpleado)
                };

                int countEntrada = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkEntradaQuery, checkParams));
                if (countEntrada == 0)
                {
                    MessageBox.Show($"No se encontró registro de entrada hoy para {nombre}. Debe marcar entrada primero.", "Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar si ya registró salida hoy
                string checkSalidaQuery = "SELECT COUNT(*) FROM Asistencia WHERE id_empleado = @id_empleado AND fecha_asistencia = CAST(GETDATE() AS DATE) AND hora_salida IS NOT NULL";
                int countSalida = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkSalidaQuery, checkParams));
                if (countSalida > 0)
                {
                    MessageBox.Show($"El empleado {nombre} ya registró su salida anteriormente hoy.", "Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string updateQuery = @"
                    UPDATE Asistencia
                    SET hora_salida = CAST(GETDATE() AS TIME)
                    WHERE id_empleado = @id_empleado AND fecha_asistencia = CAST(GETDATE() AS DATE)";

                DatabaseHelper.ExecuteNonQuery(updateQuery, checkParams);
                MessageBox.Show($"Salida registrada con éxito para {nombre} a las {DateTime.Now.ToShortTimeString()}.", "Salida Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar las asistencias de la BD
                if (string.IsNullOrEmpty(txtBuscarAsistencia.Text.Trim()))
                {
                    InicializarAsistencias();
                }
                else
                {
                    FiltrarAsistencias(txtBuscarAsistencia.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar salida en SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarAsistencia_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarAsistencia.Text.Trim();
            if (string.IsNullOrEmpty(filtro))
            {
                InicializarAsistencias();
            }
            else
            {
                FiltrarAsistencias(filtro);
            }
        }

        private void FiltrarAsistencias(string filtro)
        {
            try
            {
                string query = @"
                    SELECT 
                        e.nombres_empleado + ' ' + e.apellidos_Paterno AS [Empleado],
                        CONVERT(VARCHAR(10), a.fecha_asistencia, 103) AS [Fecha],
                        CONVERT(VARCHAR(8), a.hora_entrada, 108) AS [Hora Entrada],
                        ISNULL(CONVERT(VARCHAR(8), a.hora_salida, 108), '--:--') AS [Hora Salida],
                        a.estado_asistencia AS [Estado]
                    FROM 
                        Asistencia a
                        INNER JOIN Empleado e ON a.id_empleado = e.id_empleado
                    WHERE 
                        e.nombres_empleado LIKE @Filtro OR 
                        e.apellidos_Paterno LIKE @Filtro OR
                        a.estado_asistencia LIKE @Filtro OR
                        CONVERT(VARCHAR(10), a.fecha_asistencia, 103) LIKE @Filtro
                    ORDER BY 
                        a.fecha_asistencia DESC, a.hora_entrada DESC";

                System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Filtro", "%" + filtro + "%")
                };

                dtAsistencia = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvAsistencia.DataSource = dtAsistencia;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar asistencias desde SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
