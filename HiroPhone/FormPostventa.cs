using System;
using System.Data;
using System.Windows.Forms;

namespace HiroPhone
{
    // Formulario de Postventa: Gestiona Garantias y Reclamos de clientes
    public partial class FormPostventa : Form
    {
        public FormPostventa()
        {
            InitializeComponent();
        }

        // Carga los datos de Garantias y Reclamos al abrir la pantalla
        private void FormPostventa_Load(object sender, EventArgs e)
        {
            CargarGarantias();
            CargarReclamos();
        }

        #region GARANTIAS

        // Carga la lista de garantias y llena los combos de tipo y productos vendidos
        private void CargarGarantias()
        {
            try
            {
                // Consulta para listar garantias vigentes con detalles de la venta
                string query = @"
                    SELECT 
                        g.id_garantia AS [ID],
                        p.nombre_producto AS [Producto],
                        v.serie_comprobante + '-' + CONVERT(VARCHAR, v.correlativo_diario) AS [Comprobante],
                        tg.nombre_garantia AS [Tipo Garantia],
                        CONVERT(VARCHAR(10), g.fecha_inicio, 103) AS [Inicio],
                        CONVERT(VARCHAR(10), g.fecha_fin, 103) AS [Fin],
                        g.estado_garantia AS [Estado]
                    FROM Garantia g
                    INNER JOIN Tipo_Garantia tg ON g.id_tipo_garantia = tg.id_tipo_garantia
                    INNER JOIN Detalle_Venta dv ON g.id_detalle_venta = dv.id_detalle_venta
                    INNER JOIN Venta v ON dv.id_venta = v.id_venta
                    INNER JOIN Producto p ON dv.id_producto = p.id_producto";
                dgvGarantias.DataSource = Conexion.ExecuteQuery(query);

                // Carga los tipos de garantia en el combo
                cboTipoGarantia.DataSource = Conexion.ExecuteQuery("SELECT id_tipo_garantia, nombre_garantia FROM Tipo_Garantia");
                cboTipoGarantia.DisplayMember = "nombre_garantia";
                cboTipoGarantia.ValueMember = "id_tipo_garantia";

                // Carga los productos vendidos que aun no tienen una garantia activa
                string qDetalle = @"
                    SELECT 
                        dv.id_detalle_venta,
                        p.nombre_producto + ' (Venta: ' + v.serie_comprobante + '-' + CONVERT(VARCHAR, v.correlativo_diario) + ')' AS info_venta
                    FROM Detalle_Venta dv
                    INNER JOIN Producto p ON dv.id_producto = p.id_producto
                    INNER JOIN Venta v ON dv.id_venta = v.id_venta
                    WHERE dv.id_detalle_venta NOT IN (SELECT id_detalle_venta FROM Garantia WHERE estado_garantia = 'Activa')";
                
                cboVentaDetalleGarantia.DataSource = Conexion.ExecuteQuery(qDetalle);
                cboVentaDetalleGarantia.DisplayMember = "info_venta";
                cboVentaDetalleGarantia.ValueMember = "id_detalle_venta";

                CalcularFechaFin();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar garantias: " + ex.Message);
            }
        }

        // Calcula la fecha de vencimiento sumando la duracion del tipo de garantia seleccionado
        private void CalcularFechaFin()
        {
            if (cboTipoGarantia.SelectedValue != null)
            {
                try
                {
                    int idTipo = Convert.ToInt32(cboTipoGarantia.SelectedValue);
                    object duracion = Conexion.ExecuteScalar("SELECT duracion_meses FROM Tipo_Garantia WHERE id_tipo_garantia = " + idTipo);
                    if (duracion != null)
                    {
                        int meses = Convert.ToInt32(duracion);
                        DateTime fechaFin = dtpInicioGarantia.Value.AddMonths(meses);
                        lblFinGarantiaCalculada.Text = "Fecha Fin: " + fechaFin.ToString("dd/MM/yyyy") + " (" + meses + " meses)";
                    }
                }
                catch { }
            }
        }

        // Registra una nueva garantia asociada al producto vendido
        private void btnRegistrarGarantia_Click(object sender, EventArgs e)
        {
            if (cboVentaDetalleGarantia.SelectedValue == null || cboTipoGarantia.SelectedValue == null)
            {
                MessageBox.Show("Complete la seleccion del producto y tipo de garantia.");
                return;
            }

            int idDetalle = Convert.ToInt32(cboVentaDetalleGarantia.SelectedValue);
            int idTipo = Convert.ToInt32(cboTipoGarantia.SelectedValue);
            DateTime inicio = dtpInicioGarantia.Value;
            string cond = txtCondicionesGarantia.Text.Trim();

            try
            {
                object duracion = Conexion.ExecuteScalar("SELECT duracion_meses FROM Tipo_Garantia WHERE id_tipo_garantia = " + idTipo);
                int meses = duracion != null ? Convert.ToInt32(duracion) : 12;
                DateTime fin = inicio.AddMonths(meses);

                // SQL: Inserta la garantia parametrizada
                string query = @"
                    INSERT INTO Garantia (fecha_inicio, fecha_fin, estado_garantia, condiciones, id_detalle_venta, id_tipo_garantia)
                    VALUES (@Inicio, @Fin, 'Activa', @Cond, @IdDetalle, @IdTipo)";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@Inicio", inicio),
                    new System.Data.SqlClient.SqlParameter("@Fin", fin),
                    new System.Data.SqlClient.SqlParameter("@Cond", cond),
                    new System.Data.SqlClient.SqlParameter("@IdDetalle", idDetalle),
                    new System.Data.SqlClient.SqlParameter("@IdTipo", idTipo)
                };

                Conexion.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Garantia guardada con exito.");
                CargarGarantias();
                txtCondicionesGarantia.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar garantia: " + ex.Message);
            }
        }

        private void cboTipoGarantia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularFechaFin();
        }

        private void dtpInicioGarantia_ValueChanged(object sender, EventArgs e)
        {
            CalcularFechaFin();
        }

        #endregion

        #region RECLAMOS

        // Carga la lista de reclamos y llena el combo de clientes
        private void CargarReclamos()
        {
            try
            {
                // Consulta para listar los reclamos de clientes
                string query = @"
                    SELECT 
                        r.id_reclamo AS [ID],
                        c.nombre_o_razon_social AS [Cliente],
                        v.serie_comprobante + '-' + CONVERT(VARCHAR, v.correlativo_diario) AS [Comprobante],
                        CONVERT(VARCHAR(10), r.fecha_reclamo, 103) AS [Fecha Reclamo],
                        r.descripcion AS [Descripcion],
                        r.estado AS [Estado]
                    FROM Reclamo r
                    INNER JOIN Cliente c ON r.id_cliente = c.id_cliente
                    INNER JOIN Venta v ON r.id_venta = v.id_venta";
                dgvReclamos.DataSource = Conexion.ExecuteQuery(query);

                // Carga la lista de clientes en el combo
                cboClienteReclamo.DataSource = Conexion.ExecuteQuery("SELECT id_cliente, nombre_o_razon_social FROM Cliente");
                cboClienteReclamo.DisplayMember = "nombre_o_razon_social";
                cboClienteReclamo.ValueMember = "id_cliente";

                CargarVentasDelCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reclamos: " + ex.Message);
            }
        }

        // Carga las boletas/facturas que pertenecen exclusivamente al cliente seleccionado
        private void CargarVentasDelCliente()
        {
            if (cboClienteReclamo.SelectedValue != null)
            {
                try
                {
                    int idCliente = Convert.ToInt32(cboClienteReclamo.SelectedValue);
                    string query = "SELECT id_venta, serie_comprobante + '-' + CONVERT(VARCHAR, correlativo_diario) + ' (Total: S/. ' + CONVERT(VARCHAR, total_venta) + ')' AS info_comp FROM Venta WHERE id_cliente = " + idCliente;
                    cboVentaReclamo.DataSource = Conexion.ExecuteQuery(query);
                    cboVentaReclamo.DisplayMember = "info_comp";
                    cboVentaReclamo.ValueMember = "id_venta";
                }
                catch { }
            }
        }

        // Registra el reclamo en la base de datos
        private void btnRegistrarReclamo_Click(object sender, EventArgs e)
        {
            if (cboClienteReclamo.SelectedValue == null || cboVentaReclamo.SelectedValue == null || string.IsNullOrEmpty(txtDescripcionReclamo.Text.Trim()))
            {
                MessageBox.Show("Complete el Cliente, Comprobante y Descripcion.");
                return;
            }

            int idCliente = Convert.ToInt32(cboClienteReclamo.SelectedValue);
            int idVenta = Convert.ToInt32(cboVentaReclamo.SelectedValue);
            string desc = txtDescripcionReclamo.Text.Trim();
            string estado = cboEstadoReclamo.SelectedItem.ToString();

            try
            {
                // SQL: Registra la queja en la tabla Reclamo con fecha actual
                string query = "INSERT INTO Reclamo (descripcion, estado, id_cliente, id_venta, fecha_reclamo) VALUES (@Desc, @Estado, @IdCliente, @IdVenta, GETDATE())";
                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@Desc", desc),
                    new System.Data.SqlClient.SqlParameter("@Estado", estado),
                    new System.Data.SqlClient.SqlParameter("@IdCliente", idCliente),
                    new System.Data.SqlClient.SqlParameter("@IdVenta", idVenta)
                };

                Conexion.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Reclamo registrado con exito.");
                CargarReclamos();
                txtDescripcionReclamo.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar reclamo: " + ex.Message);
            }
        }

        // Evento: Al cambiar de cliente, se cargan sus compras
        private void cboClienteReclamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarVentasDelCliente();
        }

        #endregion
    }
}
