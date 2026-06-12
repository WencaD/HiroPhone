using System;
using System.Data;
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
            InicializarCarrito();
        }

        private void CargarProductos()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery("SELECT nombre_producto, precio_venta FROM Producto");
                cboProducto.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string nombre = row["nombre_producto"].ToString();
                    double precio = Convert.ToDouble(row["precio_venta"]);
                    cboProducto.Items.Add($"{nombre} - S/. {precio:F2}");
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
            cboMetodoPago.Items.Add("Efectivo Soles");
            cboMetodoPago.Items.Add("Tarjeta de Crédito");
            cboMetodoPago.Items.Add("Yape / Plin");
            cboMetodoPago.SelectedIndex = 0;
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
            string textoProd = cboProducto.SelectedItem.ToString();
            string nombreProd = textoProd.Substring(0, textoProd.IndexOf(" - "));
            double precioUnit = ObtenerPrecioSeleccionado();
            int cant = (int)numCantidad.Value;
            double sub = precioUnit * cant;

            bool existe = false;
            foreach (DataRow row in dtCart.Rows)
            {
                if (row["Producto"].ToString() == nombreProd)
                {
                    int cantActual = (int)row["Cant."];
                    row["Cant."] = cantActual + cant;
                    row["Subtotal"] = (cantActual + cant) * precioUnit;
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
                MessageBox.Show("Por favor, ingrese el nombre del cliente.", "Punto de Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string metodo = cboMetodoPago.SelectedItem.ToString();
            int idMetodoPago = cboMetodoPago.SelectedIndex + 1; // 1: Efectivo, 2: Tarjeta, 3: Yape/Plin

            try
            {
                // 1. Obtener o registrar cliente en base de datos
                int idCliente = 0;
                string qBuscarCliente = "SELECT id_cliente FROM Cliente WHERE nombre_o_razon_social = @Nombre";
                System.Data.SqlClient.SqlParameter[] pBuscarC = { new System.Data.SqlClient.SqlParameter("@Nombre", cliente) };
                object resCli = DatabaseHelper.ExecuteScalar(qBuscarCliente, pBuscarC);

                if (resCli != null)
                {
                    idCliente = Convert.ToInt32(resCli);
                }
                else
                {
                    // Registrar nuevo cliente
                    string numDoc = "CLI" + DateTime.Now.ToString("mmssff"); // Generar número de documento simulado único
                    string qCrearCliente = "INSERT INTO Cliente (numero_documento, nombre_o_razon_social, id_tipo_cliente) VALUES (@Doc, @Nombre, 1); SELECT SCOPE_IDENTITY();";
                    System.Data.SqlClient.SqlParameter[] pCrearC = {
                        new System.Data.SqlClient.SqlParameter("@Doc", numDoc),
                        new System.Data.SqlClient.SqlParameter("@Nombre", cliente)
                    };
                    idCliente = Convert.ToInt32(DatabaseHelper.ExecuteScalar(qCrearCliente, pCrearC));
                }

                // 2. Obtener correlativo diario
                string qCorrelativo = "SELECT ISNULL(MAX(correlativo_diario), 0) + 1 FROM Venta";
                int correlativo = Convert.ToInt32(DatabaseHelper.ExecuteScalar(qCorrelativo));

                // Calcular subtotal, igv, total
                double subtotal = totalAcumulado / 1.18;
                double igv = totalAcumulado - subtotal;

                // 3. Registrar venta (Cabecera)
                // Usamos id_empleado = 1 (Carlos Gomez), id_tipo_comprobante = 1 (Boleta), id_caja = 1 (Caja Principal Jockey)
                string qVenta = @"
                    INSERT INTO Venta (fecha_venta, serie_comprobante, correlativo_diario, subtotal, igv, total_venta, id_cliente, id_empleado, id_metodo_pago, id_tipo_comprobante, id_caja)
                    VALUES (GETDATE(), 'B001', @Correlativo, @Subtotal, @Igv, @Total, @IdCliente, 1, @IdMetodo, 1, 1);
                    SELECT SCOPE_IDENTITY();";

                System.Data.SqlClient.SqlParameter[] pVenta = {
                    new System.Data.SqlClient.SqlParameter("@Correlativo", correlativo),
                    new System.Data.SqlClient.SqlParameter("@Subtotal", (decimal)subtotal),
                    new System.Data.SqlClient.SqlParameter("@Igv", (decimal)igv),
                    new System.Data.SqlClient.SqlParameter("@Total", (decimal)totalAcumulado),
                    new System.Data.SqlClient.SqlParameter("@IdCliente", idCliente),
                    new System.Data.SqlClient.SqlParameter("@IdMetodo", idMetodoPago)
                };

                int idVenta = Convert.ToInt32(DatabaseHelper.ExecuteScalar(qVenta, pVenta));

                // 4. Registrar detalles de venta e insertar en Detalle_Venta
                foreach (DataRow row in dtCart.Rows)
                {
                    string nombreProducto = row["Producto"].ToString();
                    double precioUnit = (double)row["Precio Unit."];
                    int cant = (int)row["Cant."];
                    double subItem = (double)row["Subtotal"];

                    // Buscar el id_producto
                    string qBuscarProd = "SELECT TOP 1 id_producto FROM Producto WHERE nombre_producto = @Nombre";
                    System.Data.SqlClient.SqlParameter[] pBuscarP = { new System.Data.SqlClient.SqlParameter("@Nombre", nombreProducto) };
                    int idProducto = Convert.ToInt32(DatabaseHelper.ExecuteScalar(qBuscarProd, pBuscarP));

                    // Insertar detalle
                    string qDetalle = "INSERT INTO Detalle_Venta (id_venta, id_producto, cantidad, precio_unitario, subtotal) VALUES (@IdVenta, @IdProd, @Cant, @Precio, @Sub);";
                    System.Data.SqlClient.SqlParameter[] pDetalle = {
                        new System.Data.SqlClient.SqlParameter("@IdVenta", idVenta),
                        new System.Data.SqlClient.SqlParameter("@IdProd", idProducto),
                        new System.Data.SqlClient.SqlParameter("@Cant", cant),
                        new System.Data.SqlClient.SqlParameter("@Precio", (decimal)precioUnit),
                        new System.Data.SqlClient.SqlParameter("@Sub", (decimal)subItem)
                    };
                    DatabaseHelper.ExecuteNonQuery(qDetalle, pDetalle);

                    // 5. Actualizar el stock del inventario para ese producto
                    string qUpdateStock = "UPDATE Inventario SET stock_actual = stock_actual - @Cant WHERE id_producto = @IdProd AND id_almacen = 1";
                    System.Data.SqlClient.SqlParameter[] pUpdateStock = {
                        new System.Data.SqlClient.SqlParameter("@Cant", cant),
                        new System.Data.SqlClient.SqlParameter("@IdProd", idProducto)
                    };
                    DatabaseHelper.ExecuteNonQuery(qUpdateStock, pUpdateStock);
                }

                // Mostrar comprobante final
                string boleta = $"--- COMPROBANTE DE PAGO REGISTRADO (SQL Server) ---\n\n" +
                                $"Nro. Comprobante: B001-{correlativo:D8}\n" +
                                $"Cliente: {cliente}\n" +
                                $"Método de Pago: {metodo}\n" +
                                $"Fecha: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}\n" +
                                $"----------------------------------\n";

                foreach (DataRow row in dtCart.Rows)
                {
                    boleta += $"{row["Producto"]} (x{row["Cant."]}) - S/. {row["Subtotal"]:F2}\n";
                }

                boleta += $"----------------------------------\n" +
                          $"Subtotal: {lblSubtotalVal.Text}\n" +
                          $"IGV (18%): {lblIgvVal.Text}\n" +
                          $"TOTAL A PAGAR: {lblTotalVal.Text}\n\n" +
                          $"¡Venta insertada correctamente en la Base de Datos!";

                MessageBox.Show(boleta, "Venta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}
