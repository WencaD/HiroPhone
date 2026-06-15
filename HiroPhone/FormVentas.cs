using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HiroPhone
{
    public partial class FormVentas : Form
    {
        private DataTable dtCart;
        private double totalAcumulado = 0.0;

        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarMetodosPago();
            CargarTiposComprobante();
            InicializarCarrito();
            AjustarDiseñoGrid();
            CargarHistorialVentas();
        }

        private void CargarCategorias()
        {
            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT id_categoria, nombre_categoria FROM Categoria_Producto ORDER BY nombre_categoria", cn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            
                            cboCategoria.SelectedIndexChanged -= cboCategoria_SelectedIndexChanged;
                            cboCategoria.DataSource = dt;
                            cboCategoria.DisplayMember = "nombre_categoria";
                            cboCategoria.ValueMember = "id_categoria";
                            cboCategoria.SelectedIndexChanged += cboCategoria_SelectedIndexChanged;
                        }
                    }
                }

                if (cboCategoria.Items.Count > 0)
                {
                    cboCategoria.SelectedIndex = 0;
                    cboCategoria_SelectedIndexChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías desde SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductosPorCategoria(int idCategoria)
        {
            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT nombre_producto, precio_venta FROM Producto WHERE id_categoria = @IdCat", cn))
                    {
                        cmd.Parameters.AddWithValue("@IdCat", idCategoria);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            cboProducto.Items.Clear();
                            foreach (DataRow row in dt.Rows)
                            {
                                string nombre = row["nombre_producto"].ToString();
                                double precio = Convert.ToDouble(row["precio_venta"]);
                                cboProducto.Items.Add($"{nombre} - S/. {precio:F2}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos por categoría desde SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cboProducto.Items.Count > 0)
            {
                cboProducto.SelectedIndex = 0;
            }
            else
            {
                cboProducto.Text = string.Empty;
                txtPrecio.Clear();
            }
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoria.SelectedValue != null && cboCategoria.SelectedValue is int idCat)
            {
                CargarProductosPorCategoria(idCat);
            }
            else if (cboCategoria.SelectedValue != null && int.TryParse(cboCategoria.SelectedValue.ToString(), out int idCatParsed))
            {
                CargarProductosPorCategoria(idCatParsed);
            }
        }

        private void CargarMetodosPago()
        {
            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT id_metodo_pago, nombre_metodo_pago FROM Metodo_Pago", cn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            cboMetodoPago.DataSource = dt;
                            cboMetodoPago.DisplayMember = "nombre_metodo_pago";
                            cboMetodoPago.ValueMember = "id_metodo_pago";
                        }
                    }
                }

                if (cboMetodoPago.Items.Count > 0)
                {
                    cboMetodoPago.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar métodos de pago desde SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMetodoPago.DataSource = null;
            }
        }

        private void CargarTiposComprobante()
        {
            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT id_tipo_comprobante, nombre_tipo, requiere_ruc FROM Tipo_Comprobante", cn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            cboTipoComprobante.DataSource = dt;
                            cboTipoComprobante.DisplayMember = "nombre_tipo";
                            cboTipoComprobante.ValueMember = "id_tipo_comprobante";
                        }
                    }
                }

                if (cboTipoComprobante.Items.Count > 0)
                {
                    cboTipoComprobante.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de comprobante desde SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTipoComprobante.DataSource = null;
            }
        }

        private void cboTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoComprobante.SelectedItem is DataRowView rowView)
            {
                int requiereRuc = Convert.ToInt32(rowView["requiere_ruc"]);
                if (requiereRuc == 1)
                {
                    lblCliente.Text = "RUC de la Empresa (11 dígitos):";
                    txtCliente.Text = string.Empty;
                }
                else
                {
                    lblCliente.Text = "Cliente (Nombre o DNI):";
                    txtCliente.Text = string.Empty;
                }
            }
            else
            {
                lblCliente.Text = "Cliente (Nombre/ID):";
                txtCliente.Text = string.Empty;
            }
        }

        private void InicializarCarrito()
        {
            dtCart = new DataTable();
            dtCart.Columns.Add("Producto", typeof(string));
            dtCart.Columns.Add("Precio Unit.", typeof(double));
            dtCart.Columns.Add("Cant.", typeof(int));
            dtCart.Columns.Add("Subtotal", typeof(double));

            dgvDetalle.DataSource = dtCart;
            AjustarDiseñoGrid();
        }

        private void AjustarDiseñoGrid()
        {
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);

            if (dgvDetalle.Columns.Contains("Precio Unit."))
                dgvDetalle.Columns["Precio Unit."].DefaultCellStyle.Format = "'S/.' #,##0.00";
            if (dgvDetalle.Columns.Contains("Subtotal"))
                dgvDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "'S/.' #,##0.00";
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            double precio = ObtenerPrecioSeleccionado();
            txtPrecio.Text = $"S/. {precio:F2}";
        }

        private double ObtenerPrecioSeleccionado()
        {
            string textoProd = cboProducto.SelectedItem.ToString();
            int indexSoles = textoProd.LastIndexOf("S/. ");
            if (indexSoles != -1)
            {
                string precioStr = textoProd.Substring(indexSoles + 4).Trim();
                if (double.TryParse(precioStr, out double precio))
                {
                    return precio;
                }
            }
            return 0.0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProducto.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un producto.", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string textoProd = cboProducto.SelectedItem.ToString();
            string nombreProd = textoProd.Substring(0, textoProd.IndexOf(" - "));
            double precioUnit = ObtenerPrecioSeleccionado();
            int cant = (int)numCantidad.Value;
            double sub = precioUnit * cant;

            // 1. Obtener cantidad ya agregada al carrito
            int cantEnCarrito = 0;
            foreach (DataRow row in dtCart.Rows)
            {
                if (row["Producto"].ToString() == nombreProd)
                {
                    cantEnCarrito = (int)row["Cant."];
                    break;
                }
            }

            int cantTotalRequerida = cantEnCarrito + cant;

            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    string qStock = @"
                        SELECT ISNULL(i.stock_actual, 0)
                        FROM Inventario i
                        INNER JOIN Producto p ON i.id_producto = p.id_producto
                        WHERE p.nombre_producto = @Nombre AND i.id_almacen = 1";

                    using (SqlCommand cmd = new SqlCommand(qStock, cn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombreProd);
                        object resStock = cmd.ExecuteScalar();
                        int stockDisponible = resStock != null ? Convert.ToInt32(resStock) : 0;

                        if (cantTotalRequerida > stockDisponible)
                        {
                            MessageBox.Show($"Stock insuficiente en almacén. Disponible: {stockDisponible} u. | Requerido en carrito: {cantTotalRequerida} u.", 
                                            "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar stock disponible:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Modificar o agregar al carrito
            bool existe = false;
            foreach (DataRow row in dtCart.Rows)
            {
                if (row["Producto"].ToString() == nombreProd)
                {
                    row["Cant."] = cantTotalRequerida;
                    row["Subtotal"] = cantTotalRequerida * precioUnit;
                    existe = true;
                    break;
                }
            }

            if (!existe)
            {
                dtCart.Rows.Add(nombreProd, precioUnit, cant, sub);
            }

            RecalcularTotales();
        }

        private void RecalcularTotales()
        {
            totalAcumulado = 0.0;
            foreach (DataRow row in dtCart.Rows)
            {
                totalAcumulado += (double)row["Subtotal"];
            }

            double subtotal = totalAcumulado / 1.18;
            double igv = totalAcumulado - subtotal;

            lblSubtotalVal.Text = $"S/. {subtotal:F2}";
            lblIgvVal.Text = $"S/. {igv:F2}";
            lblTotalVal.Text = $"S/. {totalAcumulado:F2}";
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (dtCart.Rows.Count == 0)
            {
                MessageBox.Show("El carrito de compras está vacío.", "Punto de Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cliente = txtCliente.Text.Trim();
            if (string.IsNullOrEmpty(cliente))
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente o RUC.", "Punto de Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener tipo de comprobante seleccionado
            int idTipoComprobante = 1;
            int requiereRuc = 0;
            string tipoComprobanteNombre = "Boleta de Venta";

            if (cboTipoComprobante.SelectedItem is DataRowView compView)
            {
                idTipoComprobante = Convert.ToInt32(compView["id_tipo_comprobante"]);
                requiereRuc = Convert.ToInt32(compView["requiere_ruc"]);
                tipoComprobanteNombre = compView["nombre_tipo"].ToString();
            }

            // Validar RUC si corresponde
            if (requiereRuc == 1)
            {
                if (cliente.Length != 11 || (!cliente.StartsWith("10") && !cliente.StartsWith("20") && !cliente.StartsWith("15") && !cliente.StartsWith("17")))
                {
                    MessageBox.Show("Para emitir una Factura, debe ingresar un RUC válido de 11 dígitos (habitualmente comienza con 10 o 20).", 
                                    "Validación de RUC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string metodo = "";
            int idMetodoPago = 1;

            if (cboMetodoPago.SelectedItem is DataRowView rowView)
            {
                metodo = rowView["nombre_metodo_pago"].ToString();
                idMetodoPago = Convert.ToInt32(rowView["id_metodo_pago"]);
            }
            else
            {
                metodo = cboMetodoPago.SelectedItem?.ToString() ?? "Efectivo Soles";
                idMetodoPago = 1;
            }

            double montoEfectivo = 0.0;
            double montoTarjeta = 0.0;

            if (idMetodoPago == 4) // Pago Mixto
            {
                using (var diag = new FormPagoMixtoDialog(totalAcumulado))
                {
                    if (diag.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    montoEfectivo = diag.MontoEfectivo;
                    montoTarjeta = diag.MontoTarjeta;
                }
            }
            else if (idMetodoPago == 1) // Efectivo Soles
            {
                montoEfectivo = totalAcumulado;
                montoTarjeta = 0.0;
            }
            else if (idMetodoPago == 2) // Tarjeta
            {
                montoEfectivo = 0.0;
                montoTarjeta = totalAcumulado;
            }
            else // Transferencia u otros
            {
                montoEfectivo = 0.0;
                montoTarjeta = 0.0;
            }

            try
            {
                int idCliente = 0;
                int correlativo = 0;
                int idVenta = 0;
                int idEmpleado = UserSession.IsLoggedIn && UserSession.IdEmpleado > 0 ? UserSession.IdEmpleado : 1;
                string serie = idTipoComprobante == 2 ? "F001" : "B001";

                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    using (SqlTransaction tx = cn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Obtener o registrar cliente en base de datos usando Stored Procedure
                            using (SqlCommand cmdCli = new SqlCommand("sp_ObtenerOCrearClienteVenta", cn, tx))
                            {
                                cmdCli.CommandType = CommandType.StoredProcedure;
                                cmdCli.Parameters.AddWithValue("@requiereRuc", requiereRuc);
                                cmdCli.Parameters.AddWithValue("@cliente", cliente);
                                idCliente = Convert.ToInt32(cmdCli.ExecuteScalar());
                            }

                            // 2. Obtener correlativo diario usando Stored Procedure
                            using (SqlCommand cmdCorr = new SqlCommand("sp_ObtenerSiguienteCorrelativoVenta", cn, tx))
                            {
                                cmdCorr.CommandType = CommandType.StoredProcedure;
                                correlativo = Convert.ToInt32(cmdCorr.ExecuteScalar());
                            }

                            // Calcular subtotal, igv, total
                            double subtotal = totalAcumulado / 1.18;
                            double igv = totalAcumulado - subtotal;

                            // 3. Registrar venta (Cabecera) usando Stored Procedure
                            using (SqlCommand cmdVenta = new SqlCommand("sp_InsertarCabeceraVenta", cn, tx))
                            {
                                cmdVenta.CommandType = CommandType.StoredProcedure;
                                cmdVenta.Parameters.AddWithValue("@serie", serie);
                                cmdVenta.Parameters.AddWithValue("@correlativo", correlativo);
                                cmdVenta.Parameters.AddWithValue("@subtotal", (decimal)subtotal);
                                cmdVenta.Parameters.AddWithValue("@igv", (decimal)igv);
                                cmdVenta.Parameters.AddWithValue("@total", (decimal)totalAcumulado);
                                cmdVenta.Parameters.AddWithValue("@idCliente", idCliente);
                                cmdVenta.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                                cmdVenta.Parameters.AddWithValue("@idMetodo", idMetodoPago);
                                cmdVenta.Parameters.AddWithValue("@idTipoComprobante", idTipoComprobante);
                                cmdVenta.Parameters.AddWithValue("@montoEfectivo", (decimal)montoEfectivo);
                                cmdVenta.Parameters.AddWithValue("@montoTarjeta", (decimal)montoTarjeta);
                                idVenta = Convert.ToInt32(cmdVenta.ExecuteScalar());
                            }

                            // 4. Registrar detalles de venta e insertar en Detalle_Venta usando Stored Procedure
                            foreach (DataRow row in dtCart.Rows)
                            {
                                string nombreProducto = row["Producto"].ToString();
                                double precioUnit = (double)row["Precio Unit."];
                                int cant = (int)row["Cant."];
                                double subItem = (double)row["Subtotal"];

                                using (SqlCommand cmdDet = new SqlCommand("sp_InsertarDetalleYActualizarStock", cn, tx))
                                {
                                    cmdDet.CommandType = CommandType.StoredProcedure;
                                    cmdDet.Parameters.AddWithValue("@idVenta", idVenta);
                                    cmdDet.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                                    cmdDet.Parameters.AddWithValue("@cantidad", cant);
                                    cmdDet.Parameters.AddWithValue("@precioUnitario", (decimal)precioUnit);
                                    cmdDet.Parameters.AddWithValue("@subtotal", (decimal)subItem);
                                    cmdDet.ExecuteNonQuery();
                                }
                            }

                            // 5.1 Registrar comisión de venta para el empleado usando Stored Procedure
                            using (SqlCommand cmdCom = new SqlCommand("sp_RegistrarComisionEmpleado", cn, tx))
                            {
                                cmdCom.CommandType = CommandType.StoredProcedure;
                                cmdCom.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                                cmdCom.Parameters.AddWithValue("@idVenta", idVenta);
                                cmdCom.Parameters.AddWithValue("@totalVenta", (decimal)totalAcumulado);
                                cmdCom.ExecuteNonQuery();
                            }

                            tx.Commit();
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                            throw ex;
                        }
                    }
                }

                // Mostrar comprobante final
                string comprobanteTicket = $"--- {tipoComprobanteNombre.ToUpper()} REGISTRADA ---\n\n" +
                                           $"Nro. Comprobante: {serie}-{correlativo:D8}\n" +
                                           $"Cliente / RUC: {cliente}\n" +
                                           $"Método de Pago: {metodo}\n" +
                                           $"Fecha: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}\n" +
                                           $"----------------------------------\n";

                foreach (DataRow row in dtCart.Rows)
                {
                    comprobanteTicket += $"{row["Producto"]} (x{row["Cant."]}) - S/. {row["Subtotal"]:F2}\n";
                }

                comprobanteTicket += $"----------------------------------\n" +
                                     $"Subtotal: {lblSubtotalVal.Text}\n" +
                                     $"IGV (18%): {lblIgvVal.Text}\n" +
                                     $"TOTAL A PAGAR: {lblTotalVal.Text}\n\n" +
                                     $"¡Venta insertada correctamente en la Base de Datos!";

                MessageBox.Show(comprobanteTicket, "Venta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dtCart.Rows.Clear();
                RecalcularTotales();
                numCantidad.Value = 1;
                txtCliente.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la venta en SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            double totalEfectivo = 0, totalTarjeta = 0, totalTransferencia = 0;
            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    string qEfectivo = "SELECT ISNULL(SUM(monto_efectivo), 0) FROM Venta WHERE id_caja = 1 AND CAST(fecha_venta AS DATE) = CAST(GETDATE() AS DATE)";
                    string qTarjeta = "SELECT ISNULL(SUM(monto_tarjeta), 0) FROM Venta WHERE id_caja = 1 AND CAST(fecha_venta AS DATE) = CAST(GETDATE() AS DATE)";
                    string qTransferencia = "SELECT ISNULL(SUM(total_venta), 0) FROM Venta WHERE id_caja = 1 AND id_metodo_pago = 3 AND CAST(fecha_venta AS DATE) = CAST(GETDATE() AS DATE)";

                    using (SqlCommand cmd = new SqlCommand(qEfectivo, cn))
                    {
                        totalEfectivo = Convert.ToDouble(cmd.ExecuteScalar());
                    }
                    using (SqlCommand cmd = new SqlCommand(qTarjeta, cn))
                    {
                        totalTarjeta = Convert.ToDouble(cmd.ExecuteScalar());
                    }
                    using (SqlCommand cmd = new SqlCommand(qTransferencia, cn))
                    {
                        totalTransferencia = Convert.ToDouble(cmd.ExecuteScalar());
                    }
                }

                using (var diag = new FormCierreCajaDialog(totalEfectivo, totalTarjeta, totalTransferencia))
                {
                    diag.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular montos de cierre de caja:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.RadioButton)sender).Checked)
                CargarHistorialVentas();
        }

        private void CargarHistorialVentas()
        {

            string query = "";
            if (rdbDia.Checked)
            {
                query = @"
                    SELECT 
                        v.id_venta AS [ID],
                        v.serie_comprobante + '-' + RIGHT('00000000' + CAST(v.correlativo_diario AS VARCHAR), 8) AS [Comprobante],
                        v.fecha_venta AS [Fecha],
                        c.nombre_o_razon_social AS [Cliente],
                        mp.nombre_metodo_pago AS [Método Pago],
                        v.monto_efectivo AS [Efectivo],
                        v.monto_tarjeta AS [Tarjeta],
                        v.total_venta AS [Total]
                    FROM Venta v
                    INNER JOIN Cliente c ON v.id_cliente = c.id_cliente
                    INNER JOIN Metodo_Pago mp ON v.id_metodo_pago = mp.id_metodo_pago
                    WHERE CAST(v.fecha_venta AS DATE) = CAST(GETDATE() AS DATE)
                    ORDER BY v.fecha_venta DESC";
            }
            else if (rdbSemana.Checked)
            {
                query = @"
                    SELECT 
                        v.id_venta AS [ID],
                        v.serie_comprobante + '-' + RIGHT('00000000' + CAST(v.correlativo_diario AS VARCHAR), 8) AS [Comprobante],
                        v.fecha_venta AS [Fecha],
                        c.nombre_o_razon_social AS [Cliente],
                        mp.nombre_metodo_pago AS [Método Pago],
                        v.monto_efectivo AS [Efectivo],
                        v.monto_tarjeta AS [Tarjeta],
                        v.total_venta AS [Total]
                    FROM Venta v
                    INNER JOIN Cliente c ON v.id_cliente = c.id_cliente
                    INNER JOIN Metodo_Pago mp ON v.id_metodo_pago = mp.id_metodo_pago
                    WHERE v.fecha_venta >= DATEADD(day, -7, GETDATE())
                    ORDER BY v.fecha_venta DESC";
            }
            else if (rdbMes.Checked)
            {
                query = @"
                    SELECT 
                        v.id_venta AS [ID],
                        v.serie_comprobante + '-' + RIGHT('00000000' + CAST(v.correlativo_diario AS VARCHAR), 8) AS [Comprobante],
                        v.fecha_venta AS [Fecha],
                        c.nombre_o_razon_social AS [Cliente],
                        mp.nombre_metodo_pago AS [Método Pago],
                        v.monto_efectivo AS [Efectivo],
                        v.monto_tarjeta AS [Tarjeta],
                        v.total_venta AS [Total]
                    FROM Venta v
                    INNER JOIN Cliente c ON v.id_cliente = c.id_cliente
                    INNER JOIN Metodo_Pago mp ON v.id_metodo_pago = mp.id_metodo_pago
                    WHERE v.fecha_venta >= DATEADD(month, -1, GETDATE())
                    ORDER BY v.fecha_venta DESC";
            }

            try
            {
                DataTable dt = Conexion.ExecuteQuery(query);
                dgvHistorialVentas.DataSource = dt;

                // Adjust grid column settings
                if (dgvHistorialVentas.Columns.Contains("ID"))
                    dgvHistorialVentas.Columns["ID"].Visible = false;

                if (dgvHistorialVentas.Columns.Contains("Fecha"))
                    dgvHistorialVentas.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

                if (dgvHistorialVentas.Columns.Contains("Efectivo"))
                    dgvHistorialVentas.Columns["Efectivo"].DefaultCellStyle.Format = "'S/.' #,##0.00";

                if (dgvHistorialVentas.Columns.Contains("Tarjeta"))
                    dgvHistorialVentas.Columns["Tarjeta"].DefaultCellStyle.Format = "'S/.' #,##0.00";

                if (dgvHistorialVentas.Columns.Contains("Total"))
                    dgvHistorialVentas.Columns["Total"].DefaultCellStyle.Format = "'S/.' #,##0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial de ventas:\n" + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHistorialVentas_DoubleClick(object sender, EventArgs e)
        {
            if (dgvHistorialVentas.CurrentRow != null)
            {
                try
                {
                    var row = dgvHistorialVentas.CurrentRow;
                    int idVenta = Convert.ToInt32(row.Cells["ID"].Value);
                    string comprobante = row.Cells["Comprobante"].Value.ToString();
                    string cliente = row.Cells["Cliente"].Value.ToString();
                    string fecha = Convert.ToDateTime(row.Cells["Fecha"].Value).ToString("dd/MM/yyyy HH:mm:ss");
                    string metodo = row.Cells["Método Pago"].Value.ToString();
                    double total = Convert.ToDouble(row.Cells["Total"].Value);

                    using (var diag = new FormDetalleVentaDialog(idVenta, comprobante, cliente, fecha, metodo, total))
                    {
                        diag.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir detalles de la venta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
