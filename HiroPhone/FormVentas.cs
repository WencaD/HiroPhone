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
            CargarProductos();
            CargarMetodosPago();
            CargarTiposComprobante();
            InicializarCarrito();
        }

        private void CargarProductos()
        {
            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT nombre_producto, precio_venta FROM Producto", cn))
                    {
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
                MessageBox.Show("Error al cargar productos desde SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            if (cboProducto.Items.Count > 0)
            {
                cboProducto.SelectedIndex = 0;
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
                    string qEfectivo = "SELECT ISNULL(SUM(total_venta), 0) FROM Venta WHERE id_caja = 1 AND id_metodo_pago = 1 AND CAST(fecha_venta AS DATE) = CAST(GETDATE() AS DATE)";
                    string qTarjeta = "SELECT ISNULL(SUM(total_venta), 0) FROM Venta WHERE id_caja = 1 AND id_metodo_pago = 2 AND CAST(fecha_venta AS DATE) = CAST(GETDATE() AS DATE)";
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
    }

    public class FormCierreCajaDialog : Form
    {
        private double sysEfectivo;
        private double sysTarjeta;
        private double sysTransf;
        private double sysTotal;

        private TextBox txtFisicoEfectivo;
        private TextBox txtFisicoTarjeta;
        private TextBox txtFisicoTransf;
        private Label lblTotalSistema;
        private Label lblTotalFisico;
        private Label lblDiferencia;
        private Button btnConfirmar;

        public FormCierreCajaDialog(double efectivo, double tarjeta, double transferencia)
        {
            this.sysEfectivo = efectivo;
            this.sysTarjeta = tarjeta;
            this.sysTransf = transferencia;
            this.sysTotal = efectivo + tarjeta + transferencia;

            InitializeComponents();
            ActualizarTotales();
        }

        private void InitializeComponents()
        {
            this.Text = "Arqueo y Cierre de Caja";
            this.Size = new Size(450, 480);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5F);

            // Title
            Label lblTitle = new Label
            {
                Text = "Cierre de Caja Diario",
                Font = new Font("Segoe UI Black", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(24, 43, 73),
                Location = new Point(20, 15),
                Size = new Size(400, 30)
            };
            this.Controls.Add(lblTitle);

            // Headers
            Label lblHeaderMetodo = new Label { Text = "Método", Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Location = new Point(25, 65), Size = new Size(130, 20) };
            Label lblHeaderSistema = new Label { Text = "Sistema (S/.)", Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Location = new Point(165, 65), Size = new Size(110, 20), TextAlign = ContentAlignment.TopRight };
            Label lblHeaderFisico = new Label { Text = "Físico (S/.)", Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Location = new Point(295, 65), Size = new Size(110, 20), TextAlign = ContentAlignment.TopRight };
            this.Controls.Add(lblHeaderMetodo);
            this.Controls.Add(lblHeaderSistema);
            this.Controls.Add(lblHeaderFisico);

            // Row 1: Efectivo
            Label lblEfectivo = new Label { Text = "Efectivo:", Location = new Point(25, 100), Size = new Size(130, 25), TextAlign = ContentAlignment.MiddleLeft };
            Label lblSysEfectivo = new Label { Text = sysEfectivo.ToString("N2"), Location = new Point(165, 100), Size = new Size(110, 25), TextAlign = ContentAlignment.MiddleRight };
            txtFisicoEfectivo = new TextBox { Location = new Point(295, 100), Size = new Size(110, 25), TextAlign = HorizontalAlignment.Right, Text = "0.00" };
            txtFisicoEfectivo.TextChanged += (s, e) => ActualizarTotales();
            this.Controls.Add(lblEfectivo);
            this.Controls.Add(lblSysEfectivo);
            this.Controls.Add(txtFisicoEfectivo);

            // Row 2: Tarjeta
            Label lblTarjeta = new Label { Text = "Tarjetas:", Location = new Point(25, 140), Size = new Size(130, 25), TextAlign = ContentAlignment.MiddleLeft };
            Label lblSysTarjeta = new Label { Text = sysTarjeta.ToString("N2"), Location = new Point(165, 140), Size = new Size(110, 25), TextAlign = ContentAlignment.MiddleRight };
            txtFisicoTarjeta = new TextBox { Location = new Point(295, 140), Size = new Size(110, 25), TextAlign = HorizontalAlignment.Right, Text = "0.00" };
            txtFisicoTarjeta.TextChanged += (s, e) => ActualizarTotales();
            this.Controls.Add(lblTarjeta);
            this.Controls.Add(lblSysTarjeta);
            this.Controls.Add(txtFisicoTarjeta);

            // Row 3: Transferencia
            Label lblTransf = new Label { Text = "Yape / Plin:", Location = new Point(25, 180), Size = new Size(130, 25), TextAlign = ContentAlignment.MiddleLeft };
            Label lblSysTransf = new Label { Text = sysTransf.ToString("N2"), Location = new Point(165, 180), Size = new Size(110, 25), TextAlign = ContentAlignment.MiddleRight };
            txtFisicoTransf = new TextBox { Location = new Point(295, 180), Size = new Size(110, 25), TextAlign = HorizontalAlignment.Right, Text = "0.00" };
            txtFisicoTransf.TextChanged += (s, e) => ActualizarTotales();
            this.Controls.Add(lblTransf);
            this.Controls.Add(lblSysTransf);
            this.Controls.Add(txtFisicoTransf);

            // Separator line
            Panel line = new Panel { BackColor = Color.FromArgb(220, 224, 230), Location = new Point(25, 225), Size = new Size(380, 2) };
            this.Controls.Add(line);

            // Totales
            Label lblTotalLabel = new Label { Text = "Total General:", Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Location = new Point(25, 240), Size = new Size(130, 25), TextAlign = ContentAlignment.MiddleLeft };
            lblTotalSistema = new Label { Text = sysTotal.ToString("N2"), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Location = new Point(165, 240), Size = new Size(110, 25), TextAlign = ContentAlignment.MiddleRight };
            lblTotalFisico = new Label { Text = "0.00", Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Location = new Point(295, 240), Size = new Size(110, 25), TextAlign = ContentAlignment.MiddleRight };
            this.Controls.Add(lblTotalLabel);
            this.Controls.Add(lblTotalSistema);
            this.Controls.Add(lblTotalFisico);

            // Diferencia
            Label lblDiferenciaLabel = new Label { Text = "Diferencia (Arqueo):", Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Location = new Point(25, 280), Size = new Size(130, 25), TextAlign = ContentAlignment.MiddleLeft };
            lblDiferencia = new Label { Text = "0.00", Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(295, 280), Size = new Size(110, 25), TextAlign = ContentAlignment.MiddleRight };
            this.Controls.Add(lblDiferenciaLabel);
            this.Controls.Add(lblDiferencia);

            // Confirm Button
            btnConfirmar = new Button
            {
                Text = "💾 Confirmar y Registrar Cierre",
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Location = new Point(25, 350),
                Size = new Size(380, 45),
                Cursor = Cursors.Hand
            };
            btnConfirmar.FlatAppearance.BorderSize = 0;
            btnConfirmar.Click += btnConfirmar_Click;
            this.Controls.Add(btnConfirmar);
        }

        private void ActualizarTotales()
        {
            double.TryParse(txtFisicoEfectivo.Text, out double fisEf);
            double.TryParse(txtFisicoTarjeta.Text, out double fisTar);
            double.TryParse(txtFisicoTransf.Text, out double fisTra);

            double totalFis = fisEf + fisTar + fisTra;
            double dif = totalFis - sysTotal;

            lblTotalFisico.Text = totalFis.ToString("N2");
            lblDiferencia.Text = dif.ToString("N2");

            if (dif < 0)
            {
                lblDiferencia.ForeColor = Color.Red;
            }
            else if (dif > 0)
            {
                lblDiferencia.ForeColor = Color.Green;
            }
            else
            {
                lblDiferencia.ForeColor = Color.Black;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            double.TryParse(txtFisicoEfectivo.Text, out double fisEf);
            double.TryParse(txtFisicoTarjeta.Text, out double fisTar);
            double.TryParse(txtFisicoTransf.Text, out double fisTra);
            double totalFis = fisEf + fisTar + fisTra;
            double dif = totalFis - sysTotal;

            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    string query = @"
                        INSERT INTO Cierre_Caja (caja_id_caja, fecha_cierre, monto_final_sistema, monto_final_fisico, diferencia, total_efectivo, total_dolares, total_tarjeta, total_transferencia)
                        VALUES (1, GETDATE(), @SysTotal, @FisTotal, @Dif, @FisEf, 0, @FisTar, @FisTra)";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@SysTotal", (decimal)sysTotal);
                        cmd.Parameters.AddWithValue("@FisTotal", (decimal)totalFis);
                        cmd.Parameters.AddWithValue("@Dif", (decimal)dif);
                        cmd.Parameters.AddWithValue("@FisEf", (decimal)fisEf);
                        cmd.Parameters.AddWithValue("@FisTar", (decimal)fisTar);
                        cmd.Parameters.AddWithValue("@FisTra", (decimal)fisTra);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("El Cierre de Caja se ha registrado correctamente en SQL Server.", "Cierre Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cierre de caja:\n" + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
