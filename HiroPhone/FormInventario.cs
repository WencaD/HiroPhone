using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HiroPhone
{
    public partial class FormInventario : Form
    {
        private DataTable dtProductos;

        public FormInventario()
        {
            InitializeComponent();
        }

        private void FormInventario_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                string query = @"
                    SELECT 
                        i.id_inventario AS [ID],
                        m.nombre_marca AS [Marca],
                        p.nombre_producto AS [Modelo],
                        c.nombre_categoria AS [Categoría],
                        p.capacidad_almacenamiento AS [Capacidad],
                        a.nombre_almacen AS [Almacén],
                        i.stock_actual AS [Stock Actual],
                        i.stock_minimo AS [Stock Mínimo],
                        'S/. ' + CONVERT(VARCHAR, p.precio_venta) AS [Precio Venta]
                    FROM 
                        Producto p
                        INNER JOIN Marca m ON p.id_marca = m.id_marca
                        INNER JOIN Categoria_Producto c ON p.id_categoria = c.id_categoria
                        INNER JOIN Inventario i ON p.id_producto = i.id_producto
                        INNER JOIN Almacen a ON i.id_almacen = a.id_almacen";
                
                dtProductos = Conexion.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del Inventario desde SQL Server:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtProductos = new DataTable(); // Evitar referencia nula
            }

            dgvProductos.DataSource = dtProductos;
            AjustarDiseñoGrid();
        }

        private void AjustarDiseñoGrid()
        {
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void FiltrarProductos()
        {
            if (dtProductos == null) return;
            string filtro = txtBuscar.Text.Trim().Replace("'", "''");
            if (string.IsNullOrEmpty(filtro))
            {
                dtProductos.DefaultView.RowFilter = "";
            }
            else
            {
                dtProductos.DefaultView.RowFilter = string.Format(
                    "Marca LIKE '%{0}%' OR Modelo LIKE '%{0}%' OR Categoría LIKE '%{0}%' OR Almacén LIKE '%{0}%'", filtro);
            }
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            using (var diag = new FormNuevoProductoDialog())
            {
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }

        private void btnAjustarStock_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                int idInventario = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["ID"].Value);
                string modelo = dgvProductos.SelectedRows[0].Cells["Modelo"].Value.ToString();
                int stockActual = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["Stock Actual"].Value);

                using (var diag = new FormAjustarStockDialog(idInventario, modelo, stockActual))
                {
                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        CargarDatos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un producto de la lista para ajustar su stock.", "Ajuste de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTraslado_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                int idInventario = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["ID"].Value);
                string modelo = dgvProductos.SelectedRows[0].Cells["Modelo"].Value.ToString();
                int stockActual = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["Stock Actual"].Value);

                using (var diag = new FormTrasladoDialog(idInventario, modelo, stockActual))
                {
                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        CargarDatos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un producto de la lista para realizar el traslado.", "Traslado de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizarPrecio_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                string modelo = dgvProductos.SelectedRows[0].Cells["Modelo"].Value.ToString();
                
                try
                {
                    // Obtener el id_producto y precio actual
                    string query = "SELECT id_producto, precio_venta FROM Producto WHERE nombre_producto = @Modelo";
                    System.Data.SqlClient.SqlParameter[] parameters = {
                        new System.Data.SqlClient.SqlParameter("@Modelo", modelo)
                    };
                    DataTable dt = Conexion.ExecuteQuery(query, parameters);
                    if (dt.Rows.Count > 0)
                    {
                        int idProducto = Convert.ToInt32(dt.Rows[0]["id_producto"]);
                        double precioActual = Convert.ToDouble(dt.Rows[0]["precio_venta"]);

                        using (var diag = new FormActualizarPrecioDialog(idProducto, modelo, precioActual))
                        {
                            if (diag.ShowDialog() == DialogResult.OK)
                            {
                                CargarDatos(); // Recargar la lista de productos
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el dispositivo en el catálogo de productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el producto:\n" + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un producto de la lista para actualizar su precio.", "Cambio de Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMantenimientos_Click(object sender, EventArgs e)
        {
            using (var diag = new FormMantenimientosDialog())
            {
                diag.ShowDialog();
            }
        }
    }

    public class FormNuevoProductoDialog : Form
    {
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtCapacidad;
        private TextBox txtColor;
        private TextBox txtEspecificaciones;

        private ComboBox cboMarca;
        private ComboBox cboModelo;
        private ComboBox cboCategoria;
        private ComboBox cboLinea;
        private ComboBox cboProveedor;

        private NumericUpDown numStockInicial;
        private NumericUpDown numStockMinimo;
        private Button btnGuardar;

        public FormNuevoProductoDialog()
        {
            InitializeComponents();
            CargarCombos();
        }

        private void InitializeComponents()
        {
            this.Text = "Registrar Nuevo Producto";
            this.Size = new Size(500, 580);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            // Title
            Label lblTitle = new Label { Text = "Nuevo Teléfono / Dispositivo", Font = new Font("Segoe UI Black", 12F, FontStyle.Bold), ForeColor = Color.FromArgb(24, 43, 73), Location = new Point(20, 15), Size = new Size(400, 25) };
            this.Controls.Add(lblTitle);

            // Left Column Labels and Inputs
            AddLabel("Nombre del Producto:", 20, 55);
            txtNombre = AddTextBox(20, 75, 200);

            AddLabel("Precio Venta (S/.):", 20, 115);
            txtPrecio = AddTextBox(20, 135, 200);
            txtPrecio.Text = "0.00";

            AddLabel("Capacidad (ej: 128GB):", 20, 175);
            txtCapacidad = AddTextBox(20, 195, 200);

            AddLabel("Color:", 20, 235);
            txtColor = AddTextBox(20, 255, 200);

            AddLabel("Especificaciones:", 20, 295);
            txtEspecificaciones = AddTextBox(20, 315, 200);

            // Right Column
            AddLabel("Marca:", 260, 55);
            cboMarca = AddComboBox(260, 75, 200);

            AddLabel("Modelo:", 260, 115);
            cboModelo = AddComboBox(260, 135, 200);

            AddLabel("Categoría:", 260, 175);
            cboCategoria = AddComboBox(260, 195, 200);

            AddLabel("Línea de Producto:", 260, 235);
            cboLinea = AddComboBox(260, 255, 200);

            AddLabel("Proveedor:", 260, 295);
            cboProveedor = AddComboBox(260, 315, 200);

            // Stocks at the bottom
            AddLabel("Stock Inicial (Almacén 1):", 20, 370);
            numStockInicial = new NumericUpDown { Location = new Point(20, 390), Size = new Size(200, 23), Minimum = 0, Maximum = 9999, Value = 10 };
            this.Controls.Add(numStockInicial);

            AddLabel("Stock Mínimo:", 260, 370);
            numStockMinimo = new NumericUpDown { Location = new Point(260, 390), Size = new Size(200, 23), Minimum = 1, Maximum = 100, Value = 5 };
            this.Controls.Add(numStockMinimo);

            // Save button
            btnGuardar = new Button
            {
                Text = "💾 Registrar Producto",
                BackColor = Color.FromArgb(41, 128, 185),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Location = new Point(20, 460),
                Size = new Size(440, 45),
                Cursor = Cursors.Hand
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += btnGuardar_Click;
            this.Controls.Add(btnGuardar);
        }

        private void AddLabel(string text, int x, int y)
        {
            Label lbl = new Label { Text = text, Location = new Point(x, y), Size = new Size(200, 18), Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(108, 117, 125) };
            this.Controls.Add(lbl);
        }

        private TextBox AddTextBox(int x, int y, int w)
        {
            TextBox txt = new TextBox { Location = new Point(x, y), Size = new Size(w, 23) };
            this.Controls.Add(txt);
            return txt;
        }

        private ComboBox AddComboBox(int x, int y, int w)
        {
            ComboBox cbo = new ComboBox { Location = new Point(x, y), Size = new Size(w, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.Add(cbo);
            return cbo;
        }

        private void CargarCombos()
        {
            try
            {
                cboMarca.DataSource = Conexion.ExecuteQuery("SELECT id_marca, nombre_marca FROM Marca");
                cboMarca.DisplayMember = "nombre_marca";
                cboMarca.ValueMember = "id_marca";

                cboModelo.DataSource = Conexion.ExecuteQuery("SELECT id_modelo, nombre_modelo FROM Modelo");
                cboModelo.DisplayMember = "nombre_modelo";
                cboModelo.ValueMember = "id_modelo";

                cboCategoria.DataSource = Conexion.ExecuteQuery("SELECT id_categoria, nombre_categoria FROM Categoria_Producto");
                cboCategoria.DisplayMember = "nombre_categoria";
                cboCategoria.ValueMember = "id_categoria";

                cboLinea.DataSource = Conexion.ExecuteQuery("SELECT id_linea, nombre_linea FROM Linea_de_producto");
                cboLinea.DisplayMember = "nombre_linea";
                cboLinea.ValueMember = "id_linea";

                cboProveedor.DataSource = Conexion.ExecuteQuery("SELECT id_proveedor, nombre_proveedor FROM Proveedor");
                cboProveedor.DisplayMember = "nombre_proveedor";
                cboProveedor.ValueMember = "id_proveedor";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del catálogo en los selectores:\n" + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string capacidad = txtCapacidad.Text.Trim();
            string color = txtColor.Text.Trim();
            string espec = txtEspecificaciones.Text.Trim();
            string precioStr = txtPrecio.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(capacidad) || cboMarca.SelectedValue == null || cboModelo.SelectedValue == null)
            {
                MessageBox.Show("Por favor complete los campos obligatorios (Nombre, Capacidad, Marca y Modelo).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(precioStr, out double precio) || precio < 0)
            {
                MessageBox.Show("Por favor ingrese un precio de venta numérico válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string qProd = @"
                    INSERT INTO Producto (nombre_producto, precio_venta, capacidad_almacenamiento, especificaciones_tecnicas, id_marca, id_categoria, id_proveedor, id_modelo, id_linea, color)
                    VALUES (@Nombre, @Precio, @Capacidad, @Espec, @IdMarca, @IdCategoria, @IdProveedor, @IdModelo, @IdLinea, @Color);
                    SELECT SCOPE_IDENTITY();";

                System.Data.SqlClient.SqlParameter[] pProd = {
                    new System.Data.SqlClient.SqlParameter("@Nombre", nombre),
                    new System.Data.SqlClient.SqlParameter("@Precio", (decimal)precio),
                    new System.Data.SqlClient.SqlParameter("@Capacidad", capacidad),
                    new System.Data.SqlClient.SqlParameter("@Espec", espec),
                    new System.Data.SqlClient.SqlParameter("@IdMarca", Convert.ToInt32(cboMarca.SelectedValue)),
                    new System.Data.SqlClient.SqlParameter("@IdCategoria", Convert.ToInt32(cboCategoria.SelectedValue)),
                    new System.Data.SqlClient.SqlParameter("@IdProveedor", Convert.ToInt32(cboProveedor.SelectedValue)),
                    new System.Data.SqlClient.SqlParameter("@IdModelo", Convert.ToInt32(cboModelo.SelectedValue)),
                    new System.Data.SqlClient.SqlParameter("@IdLinea", Convert.ToInt32(cboLinea.SelectedValue)),
                    new System.Data.SqlClient.SqlParameter("@Color", color)
                };

                int idProducto = Convert.ToInt32(Conexion.ExecuteScalar(qProd, pProd));

                DataTable dtAlmacenes = Conexion.ExecuteQuery("SELECT id_almacen FROM Almacen");
                foreach (DataRow row in dtAlmacenes.Rows)
                {
                    int idAlmacen = Convert.ToInt32(row["id_almacen"]);
                    int stockActual = (idAlmacen == 1) ? (int)numStockInicial.Value : 0;
                    int stockMin = (int)numStockMinimo.Value;

                    string qInv = @"
                        INSERT INTO Inventario (stock_actual, stock_minimo, fecha_ultima_actualizacion, id_producto, id_almacen)
                        VALUES (@StockActual, @StockMin, GETDATE(), @IdProd, @IdAlmacen)";

                    System.Data.SqlClient.SqlParameter[] pInv = {
                        new System.Data.SqlClient.SqlParameter("@StockActual", stockActual),
                        new System.Data.SqlClient.SqlParameter("@StockMin", stockMin),
                        new System.Data.SqlClient.SqlParameter("@IdProd", idProducto),
                        new System.Data.SqlClient.SqlParameter("@IdAlmacen", idAlmacen)
                    };
                    Conexion.ExecuteNonQuery(qInv, pInv);
                }

                MessageBox.Show("El producto se ha agregado al catálogo e inventario correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el producto en la Base de Datos:\n" + ex.Message, "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class FormActualizarPrecioDialog : Form
    {
        private int idProducto;
        private double precioAnterior;
        private string nombreProducto;

        private Label lblProductoInfo;
        private TextBox txtNuevoPrecio;
        private TextBox txtMotivo;
        private Button btnGuardar;

        public FormActualizarPrecioDialog(int idProducto, string nombreProducto, double precioAnterior)
        {
            this.idProducto = idProducto;
            this.nombreProducto = nombreProducto;
            this.precioAnterior = precioAnterior;

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Actualizar Precio de Producto";
            this.Size = new Size(400, 320);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5F);

            // Title
            Label lblTitle = new Label 
            { 
                Text = "Cambio de Precio de Venta", 
                Font = new Font("Segoe UI Black", 12F, FontStyle.Bold), 
                ForeColor = Color.FromArgb(24, 43, 73), 
                Location = new Point(20, 15), 
                Size = new Size(350, 25) 
            };
            this.Controls.Add(lblTitle);

            // Product Info
            lblProductoInfo = new Label
            {
                Text = $"Dispositivo: {nombreProducto}\nPrecio Actual: S/. {precioAnterior:F2}",
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(73, 80, 87),
                Location = new Point(20, 50),
                Size = new Size(350, 45)
            };
            this.Controls.Add(lblProductoInfo);

            // New Price
            Label lblNuevoPrecio = new Label { Text = "Nuevo Precio (S/.):", Location = new Point(20, 110), Size = new Size(150, 20), Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold) };
            txtNuevoPrecio = new TextBox { Location = new Point(20, 130), Size = new Size(340, 25) };
            txtNuevoPrecio.Text = precioAnterior.ToString("F2");
            this.Controls.Add(lblNuevoPrecio);
            this.Controls.Add(txtNuevoPrecio);

            // Reason/Motivo
            Label lblMotivo = new Label { Text = "Motivo del Cambio:", Location = new Point(20, 170), Size = new Size(150, 20), Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold) };
            txtMotivo = new TextBox { Location = new Point(20, 190), Size = new Size(340, 25) };
            txtMotivo.Text = "Ajuste de mercado";
            this.Controls.Add(lblMotivo);
            this.Controls.Add(txtMotivo);

            // Save button
            btnGuardar = new Button
            {
                Text = "💾 Actualizar y Registrar Historial",
                BackColor = Color.FromArgb(41, 128, 185),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Location = new Point(20, 230),
                Size = new Size(340, 40),
                Cursor = Cursors.Hand
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += btnGuardar_Click;
            this.Controls.Add(btnGuardar);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nuevoPrecioStr = txtNuevoPrecio.Text.Trim();
            string motivo = txtMotivo.Text.Trim();

            if (!double.TryParse(nuevoPrecioStr, out double nuevoPrecio) || nuevoPrecio <= 0)
            {
                MessageBox.Show("Por favor ingrese un precio numérico válido y mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(motivo))
            {
                MessageBox.Show("Por favor ingrese un motivo para el cambio de precio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Actualizar precio en la tabla Producto
                string qUpdate = "UPDATE Producto SET precio_venta = @Precio WHERE id_producto = @IdProducto";
                System.Data.SqlClient.SqlParameter[] pUpdate = {
                    new System.Data.SqlClient.SqlParameter("@Precio", (decimal)nuevoPrecio),
                    new System.Data.SqlClient.SqlParameter("@IdProducto", idProducto)
                };
                Conexion.ExecuteNonQuery(qUpdate, pUpdate);

                // 2. Registrar en la tabla Historial_Precio_Producto
                string qHistorial = @"
                    INSERT INTO Historial_Precio_Producto (precio_anterior, precio_nuevo, fecha_cambio, motivo, id_producto)
                    VALUES (@PrecioAnt, @PrecioNue, GETDATE(), @Motivo, @IdProducto)";
                System.Data.SqlClient.SqlParameter[] pHistorial = {
                    new System.Data.SqlClient.SqlParameter("@PrecioAnt", (decimal)precioAnterior),
                    new System.Data.SqlClient.SqlParameter("@PrecioNue", (decimal)nuevoPrecio),
                    new System.Data.SqlClient.SqlParameter("@Motivo", motivo),
                    new System.Data.SqlClient.SqlParameter("@IdProducto", idProducto)
                };
                Conexion.ExecuteNonQuery(qHistorial, pHistorial);

                MessageBox.Show("Precio actualizado y registrado en el historial de precios correctamente.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar precio en SQL Server:\n" + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class FormAjustarStockDialog : Form
    {
        private int idInventario;
        private string modelo;
        private int stockActual;
        private int idAlmacen;

        private Label lblInfo;
        private ComboBox cboTipoAjuste;
        private NumericUpDown numCantidad;
        private TextBox txtObservacion;
        private Button btnGuardar;

        public FormAjustarStockDialog(int idInventario, string modelo, int stockActual)
        {
            this.idInventario = idInventario;
            this.modelo = modelo;
            this.stockActual = stockActual;

            try
            {
                object res = Conexion.ExecuteScalar("SELECT id_almacen FROM Inventario WHERE id_inventario = " + idInventario);
                this.idAlmacen = res != null ? Convert.ToInt32(res) : 1;
            }
            catch
            {
                this.idAlmacen = 1;
            }

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Ajuste Manual de Inventario";
            this.Size = new Size(400, 360);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5F);

            // Title
            Label lblTitle = new Label { Text = "Ajustar Stock", Font = new Font("Segoe UI Black", 12F, FontStyle.Bold), ForeColor = Color.FromArgb(24, 43, 73), Location = new Point(20, 15), Size = new Size(350, 25) };
            this.Controls.Add(lblTitle);

            // Info
            lblInfo = new Label
            {
                Text = $"Dispositivo: {modelo}\nStock Actual: {stockActual} unidades",
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(73, 80, 87),
                Location = new Point(20, 50),
                Size = new Size(350, 45)
            };
            this.Controls.Add(lblInfo);

            // Adjustment Type
            Label lblTipo = new Label { Text = "Tipo de Ajuste:", Location = new Point(20, 110), Size = new Size(150, 20), Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold) };
            cboTipoAjuste = new ComboBox { Location = new Point(20, 130), Size = new Size(340, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            cboTipoAjuste.Items.Add("Incrementar Stock (Ingreso)");
            cboTipoAjuste.Items.Add("Decrementar Stock (Salida)");
            cboTipoAjuste.SelectedIndex = 0;
            this.Controls.Add(lblTipo);
            this.Controls.Add(cboTipoAjuste);

            // Quantity
            Label lblCant = new Label { Text = "Cantidad a Ajustar:", Location = new Point(20, 170), Size = new Size(150, 20), Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold) };
            numCantidad = new NumericUpDown { Location = new Point(20, 190), Size = new Size(340, 25), Minimum = 1, Maximum = 1000, Value = 1 };
            this.Controls.Add(lblCant);
            this.Controls.Add(numCantidad);

            // Observation
            Label lblObs = new Label { Text = "Observación / Motivo:", Location = new Point(20, 230), Size = new Size(150, 20), Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold) };
            txtObservacion = new TextBox { Location = new Point(20, 250), Size = new Size(340, 25) };
            txtObservacion.Text = "Corrección de inventario físico";
            this.Controls.Add(lblObs);
            this.Controls.Add(txtObservacion);

            // Save button
            btnGuardar = new Button
            {
                Text = "💾 Registrar Ajuste",
                BackColor = Color.FromArgb(23, 162, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Location = new Point(20, 290),
                Size = new Size(340, 40),
                Cursor = Cursors.Hand
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += btnGuardar_Click;
            this.Controls.Add(btnGuardar);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int cant = (int)numCantidad.Value;
            string obs = txtObservacion.Text.Trim();
            bool esIngreso = cboTipoAjuste.SelectedIndex == 0;

            if (string.IsNullOrEmpty(obs))
            {
                MessageBox.Show("Por favor ingrese una observación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!esIngreso && cant > stockActual)
            {
                MessageBox.Show("No puede restar más unidades del stock actual disponible.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idEmpleado = UserSession.IsLoggedIn && UserSession.IdEmpleado > 0 ? UserSession.IdEmpleado : 1;

                if (esIngreso)
                {
                    string qUp = "UPDATE Inventario SET stock_actual = stock_actual + @Cant, fecha_ultima_actualizacion = GETDATE() WHERE id_inventario = @IdInv";
                    System.Data.SqlClient.SqlParameter[] pUp = {
                        new System.Data.SqlClient.SqlParameter("@Cant", cant),
                        new System.Data.SqlClient.SqlParameter("@IdInv", idInventario)
                    };
                    Conexion.ExecuteNonQuery(qUp, pUp);

                    string qMov = @"
                        INSERT INTO Movimiento_Inventario (cantidad, fecha_movimiento, observacion, id_tipo_movimiento, id_inventario, id_empleadoEnvia, id_empleadoRecibe, id_almacenEnvia, id_almacenRecibe)
                        VALUES (@Cant, GETDATE(), @Obs, 1, @IdInv, NULL, @IdEmpleado, NULL, @IdAlmacen)";
                    System.Data.SqlClient.SqlParameter[] pMov = {
                        new System.Data.SqlClient.SqlParameter("@Cant", cant),
                        new System.Data.SqlClient.SqlParameter("@Obs", obs),
                        new System.Data.SqlClient.SqlParameter("@IdInv", idInventario),
                        new System.Data.SqlClient.SqlParameter("@IdEmpleado", idEmpleado),
                        new System.Data.SqlClient.SqlParameter("@IdAlmacen", idAlmacen)
                    };
                    Conexion.ExecuteNonQuery(qMov, pMov);
                }
                else
                {
                    string qUp = "UPDATE Inventario SET stock_actual = stock_actual - @Cant, fecha_ultima_actualizacion = GETDATE() WHERE id_inventario = @IdInv";
                    System.Data.SqlClient.SqlParameter[] pUp = {
                        new System.Data.SqlClient.SqlParameter("@Cant", cant),
                        new System.Data.SqlClient.SqlParameter("@IdInv", idInventario)
                    };
                    Conexion.ExecuteNonQuery(qUp, pUp);

                    string qMov = @"
                        INSERT INTO Movimiento_Inventario (cantidad, fecha_movimiento, observacion, id_tipo_movimiento, id_inventario, id_empleadoEnvia, id_empleadoRecibe, id_almacenEnvia, id_almacenRecibe)
                        VALUES (@Cant, GETDATE(), @Obs, 2, @IdInv, @IdEmpleado, NULL, @IdAlmacen, NULL)";
                    System.Data.SqlClient.SqlParameter[] pMov = {
                        new System.Data.SqlClient.SqlParameter("@Cant", cant),
                        new System.Data.SqlClient.SqlParameter("@Obs", obs),
                        new System.Data.SqlClient.SqlParameter("@IdInv", idInventario),
                        new System.Data.SqlClient.SqlParameter("@IdEmpleado", idEmpleado),
                        new System.Data.SqlClient.SqlParameter("@IdAlmacen", idAlmacen)
                    };
                    Conexion.ExecuteNonQuery(qMov, pMov);
                }

                MessageBox.Show("Stock ajustado y movimiento registrado en el Kardex correctamente.", "Ajuste Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ajustar stock en SQL Server:\n" + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class FormTrasladoDialog : Form
    {
        private int idInventarioOrigen;
        private int idProducto;
        private string modelo;
        private int idAlmacenOrigen;
        private int stockOrigen;

        private Label lblInfo;
        private ComboBox cboAlmacenDestino;
        private NumericUpDown numCantidad;
        private TextBox txtObservacion;
        private Button btnGuardar;

        public FormTrasladoDialog(int idInventarioOrigen, string modelo, int stockOrigen)
        {
            this.idInventarioOrigen = idInventarioOrigen;
            this.modelo = modelo;
            this.stockOrigen = stockOrigen;

            try
            {
                DataTable dt = Conexion.ExecuteQuery("SELECT id_producto, id_almacen FROM Inventario WHERE id_inventario = " + idInventarioOrigen);
                if (dt.Rows.Count > 0)
                {
                    this.idProducto = Convert.ToInt32(dt.Rows[0]["id_producto"]);
                    this.idAlmacenOrigen = Convert.ToInt32(dt.Rows[0]["id_almacen"]);
                }
                else
                {
                    this.idProducto = 0;
                    this.idAlmacenOrigen = 1;
                }
            }
            catch
            {
                this.idProducto = 0;
                this.idAlmacenOrigen = 1;
            }

            InitializeComponents();
            CargarAlmacenesDestino();
        }

        private void InitializeComponents()
        {
            this.Text = "Traslado de Dispositivos entre Almacenes";
            this.Size = new Size(400, 360);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5F);

            // Title
            Label lblTitle = new Label { Text = "Traslado de Almacén", Font = new Font("Segoe UI Black", 12F, FontStyle.Bold), ForeColor = Color.FromArgb(24, 43, 73), Location = new Point(20, 15), Size = new Size(350, 25) };
            this.Controls.Add(lblTitle);

            // Info
            lblInfo = new Label
            {
                Text = $"Dispositivo: {modelo}\nStock en Origen: {stockOrigen} unidades",
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(73, 80, 87),
                Location = new Point(20, 50),
                Size = new Size(350, 45)
            };
            this.Controls.Add(lblInfo);

            // Target Warehouse
            Label lblDestino = new Label { Text = "Almacén de Destino:", Location = new Point(20, 110), Size = new Size(150, 20), Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold) };
            cboAlmacenDestino = new ComboBox { Location = new Point(20, 130), Size = new Size(340, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.Add(lblDestino);
            this.Controls.Add(cboAlmacenDestino);

            // Quantity
            Label lblCant = new Label { Text = "Cantidad a Trasladar:", Location = new Point(20, 170), Size = new Size(150, 20), Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold) };
            numCantidad = new NumericUpDown { Location = new Point(20, 190), Size = new Size(340, 25), Minimum = 1, Maximum = Math.Max(1, stockOrigen), Value = 1 };
            this.Controls.Add(lblCant);
            this.Controls.Add(numCantidad);

            // Observation
            Label lblObs = new Label { Text = "Observación / Motivo:", Location = new Point(20, 230), Size = new Size(150, 20), Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold) };
            txtObservacion = new TextBox { Location = new Point(20, 250), Size = new Size(340, 25) };
            txtObservacion.Text = "Traslado por stock mínimo";
            this.Controls.Add(lblObs);
            this.Controls.Add(txtObservacion);

            // Save button
            btnGuardar = new Button
            {
                Text = "🚚 Confirmar y Enviar",
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Location = new Point(20, 290),
                Size = new Size(340, 40),
                Cursor = Cursors.Hand
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += btnGuardar_Click;
            this.Controls.Add(btnGuardar);
        }

        private void CargarAlmacenesDestino()
        {
            try
            {
                string query = "SELECT id_almacen, nombre_almacen FROM Almacen WHERE id_almacen <> " + idAlmacenOrigen;
                DataTable dt = Conexion.ExecuteQuery(query);
                cboAlmacenDestino.DataSource = dt;
                cboAlmacenDestino.DisplayMember = "nombre_almacen";
                cboAlmacenDestino.ValueMember = "id_almacen";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar almacenes de destino:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int cant = (int)numCantidad.Value;
            string obs = txtObservacion.Text.Trim();

            if (cboAlmacenDestino.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un almacén de destino.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idAlmacenDestino = Convert.ToInt32(cboAlmacenDestino.SelectedValue);

            if (cant > stockOrigen)
            {
                MessageBox.Show("La cantidad a trasladar supera el stock actual disponible en el almacén de origen.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idEmpleado = UserSession.IsLoggedIn && UserSession.IdEmpleado > 0 ? UserSession.IdEmpleado : 1;

                string qSub = "UPDATE Inventario SET stock_actual = stock_actual - @Cant, fecha_ultima_actualizacion = GETDATE() WHERE id_inventario = @IdInvOrigen";
                System.Data.SqlClient.SqlParameter[] pSub = {
                    new System.Data.SqlClient.SqlParameter("@Cant", cant),
                    new System.Data.SqlClient.SqlParameter("@IdInvOrigen", idInventarioOrigen)
                };
                Conexion.ExecuteNonQuery(qSub, pSub);

                string qCheckDestino = "SELECT id_inventario FROM Inventario WHERE id_producto = @IdProd AND id_almacen = @IdAlmacenDest";
                System.Data.SqlClient.SqlParameter[] pCheckDestino = {
                    new System.Data.SqlClient.SqlParameter("@IdProd", idProducto),
                    new System.Data.SqlClient.SqlParameter("@IdAlmacenDest", idAlmacenDestino)
                };
                object resDestino = Conexion.ExecuteScalar(qCheckDestino, pCheckDestino);
                int idInventarioDestino = 0;

                if (resDestino != null)
                {
                    idInventarioDestino = Convert.ToInt32(resDestino);
                    string qAdd = "UPDATE Inventario SET stock_actual = stock_actual + @Cant, fecha_ultima_actualizacion = GETDATE() WHERE id_inventario = @IdInvDest";
                    System.Data.SqlClient.SqlParameter[] pAdd = {
                        new System.Data.SqlClient.SqlParameter("@Cant", cant),
                        new System.Data.SqlClient.SqlParameter("@IdInvDest", idInventarioDestino)
                    };
                    Conexion.ExecuteNonQuery(qAdd, pAdd);
                }
                else
                {
                    string qInsert = "INSERT INTO Inventario (stock_actual, stock_minimo, fecha_ultima_actualizacion, id_producto, id_almacen) VALUES (@Cant, 5, GETDATE(), @IdProd, @IdAlmacenDest); SELECT SCOPE_IDENTITY();";
                    System.Data.SqlClient.SqlParameter[] pInsert = {
                        new System.Data.SqlClient.SqlParameter("@Cant", cant),
                        new System.Data.SqlClient.SqlParameter("@IdProd", idProducto),
                        new System.Data.SqlClient.SqlParameter("@IdAlmacenDest", idAlmacenDestino)
                    };
                    idInventarioDestino = Convert.ToInt32(Conexion.ExecuteScalar(qInsert, pInsert));
                }

                string qMov = @"
                    INSERT INTO Movimiento_Inventario (cantidad, fecha_movimiento, observacion, id_tipo_movimiento, id_inventario, id_empleadoEnvia, id_empleadoRecibe, id_almacenEnvia, id_almacenRecibe)
                    VALUES (@Cant, GETDATE(), @Obs, 3, @IdInvOrigen, @IdEmpleado, @IdEmpleado, @IdAlmacenOrigen, @IdAlmacenDest)";
                System.Data.SqlClient.SqlParameter[] pMov = {
                    new System.Data.SqlClient.SqlParameter("@Cant", cant),
                    new System.Data.SqlClient.SqlParameter("@Obs", obs),
                    new System.Data.SqlClient.SqlParameter("@IdInvOrigen", idInventarioOrigen),
                    new System.Data.SqlClient.SqlParameter("@IdEmpleado", idEmpleado),
                    new System.Data.SqlClient.SqlParameter("@IdAlmacenOrigen", idAlmacenOrigen),
                    new System.Data.SqlClient.SqlParameter("@IdAlmacenDest", idAlmacenDestino)
                };
                Conexion.ExecuteNonQuery(qMov, pMov);

                MessageBox.Show("Traslado realizado y movimiento registrado en el Kardex correctamente.", "Traslado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar traslado en SQL Server:\n" + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Dialogo para gestionar Catálogos (Marcas, Proveedores, Categorías y Líneas)
    public class FormMantenimientosDialog : Form
    {
        private TabControl tabControl;
        private TabPage tabMarcas;
        private TabPage tabProveedores;
        private TabPage tabCategorias;
        private TabPage tabLineas;

        // Controles Marcas
        private DataGridView dgvMarcas;
        private TextBox txtNombreMarca;
        private TextBox txtOrigenMarca;
        private Button btnRegistrarMarca;

        // Controles Proveedores
        private DataGridView dgvProveedores;
        private TextBox txtNombreProv;
        private TextBox txtRucProv;
        private TextBox txtTelefonoProv;
        private TextBox txtCorreoProv;
        private TextBox txtDireccionProv;
        private Button btnRegistrarProveedor;

        // Controles Categorías
        private DataGridView dgvCategorias;
        private TextBox txtNombreCategoria;
        private TextBox txtDescripcionCategoria;
        private Button btnRegistrarCategoria;

        // Controles Líneas
        private DataGridView dgvLineas;
        private TextBox txtNombreLinea;
        private TextBox txtDescripcionLinea;
        private Button btnRegistrarLinea;

        public FormMantenimientosDialog()
        {
            InitializeComponents();
            CargarMarcas();
            CargarProveedores();
            CargarCategorias();
            CargarLineas();
        }

        private void InitializeComponents()
        {
            this.Text = "Mantenimiento del Catálogo y Proveedores";
            this.Size = new Size(650, 500);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            tabControl = new TabControl { Location = new Point(15, 15), Size = new Size(600, 430) };
            tabMarcas = new TabPage { Text = "🏷️ Marcas", BackColor = Color.White };
            tabProveedores = new TabPage { Text = "🚚 Proveedores", BackColor = Color.White };
            tabCategorias = new TabPage { Text = "📁 Categorías", BackColor = Color.White };
            tabLineas = new TabPage { Text = "🧬 Líneas", BackColor = Color.White };

            tabControl.TabPages.Add(tabMarcas);
            tabControl.TabPages.Add(tabProveedores);
            tabControl.TabPages.Add(tabCategorias);
            tabControl.TabPages.Add(tabLineas);
            this.Controls.Add(tabControl);

            InitializeTabMarcas();
            InitializeTabProveedores();
            InitializeTabCategorias();
            InitializeTabLineas();
        }

        private void InitializeTabMarcas()
        {
            dgvMarcas = new DataGridView
            {
                Location = new Point(15, 15),
                Size = new Size(560, 180),
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false
            };
            tabMarcas.Controls.Add(dgvMarcas);

            Panel pnl = new Panel
            {
                Location = new Point(15, 210),
                Size = new Size(560, 160),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(248, 249, 250)
            };
            tabMarcas.Controls.Add(pnl);

            AddLabel(pnl, "Nombre de Marca:", 15, 15);
            txtNombreMarca = AddTextBox(pnl, 15, 35, 240);

            AddLabel(pnl, "Origen de la Marca:", 15, 75);
            txtOrigenMarca = AddTextBox(pnl, 15, 95, 240);

            btnRegistrarMarca = new Button
            {
                Text = "🏷️ Registrar Marca",
                Location = new Point(285, 35),
                Size = new Size(250, 83),
                BackColor = Color.FromArgb(24, 43, 73),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnRegistrarMarca.FlatAppearance.BorderSize = 0;
            btnRegistrarMarca.Click += btnRegistrarMarca_Click;
            pnl.Controls.Add(btnRegistrarMarca);
        }

        private void InitializeTabProveedores()
        {
            dgvProveedores = new DataGridView
            {
                Location = new Point(15, 15),
                Size = new Size(560, 180),
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false
            };
            tabProveedores.Controls.Add(dgvProveedores);

            Panel pnl = new Panel
            {
                Location = new Point(15, 210),
                Size = new Size(560, 160),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(248, 249, 250)
            };
            tabProveedores.Controls.Add(pnl);

            AddLabel(pnl, "Nombre Proveedor:", 15, 10);
            txtNombreProv = AddTextBox(pnl, 15, 30, 240);

            AddLabel(pnl, "RUC:", 15, 60);
            txtRucProv = AddTextBox(pnl, 15, 80, 240);

            AddLabel(pnl, "Teléfono:", 15, 110);
            txtTelefonoProv = AddTextBox(pnl, 15, 130, 240);

            AddLabel(pnl, "Correo:", 285, 10);
            txtCorreoProv = AddTextBox(pnl, 285, 30, 250);

            AddLabel(pnl, "Dirección:", 285, 60);
            txtDireccionProv = AddTextBox(pnl, 285, 80, 250);

            btnRegistrarProveedor = new Button
            {
                Text = "🚚 Registrar Proveedor",
                Location = new Point(285, 120),
                Size = new Size(250, 30),
                BackColor = Color.FromArgb(24, 43, 73),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnRegistrarProveedor.FlatAppearance.BorderSize = 0;
            btnRegistrarProveedor.Click += btnRegistrarProveedor_Click;
            pnl.Controls.Add(btnRegistrarProveedor);
        }

        private void InitializeTabCategorias()
        {
            dgvCategorias = new DataGridView
            {
                Location = new Point(15, 15),
                Size = new Size(560, 180),
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false
            };
            tabCategorias.Controls.Add(dgvCategorias);

            Panel pnl = new Panel
            {
                Location = new Point(15, 210),
                Size = new Size(560, 160),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(248, 249, 250)
            };
            tabCategorias.Controls.Add(pnl);

            AddLabel(pnl, "Nombre de Categoría:", 15, 15);
            txtNombreCategoria = AddTextBox(pnl, 15, 35, 240);

            AddLabel(pnl, "Descripción:", 15, 75);
            txtDescripcionCategoria = AddTextBox(pnl, 15, 95, 240);

            btnRegistrarCategoria = new Button
            {
                Text = "📁 Registrar Categoría",
                Location = new Point(285, 35),
                Size = new Size(250, 83),
                BackColor = Color.FromArgb(24, 43, 73),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnRegistrarCategoria.FlatAppearance.BorderSize = 0;
            btnRegistrarCategoria.Click += btnRegistrarCategoria_Click;
            pnl.Controls.Add(btnRegistrarCategoria);
        }

        private void InitializeTabLineas()
        {
            dgvLineas = new DataGridView
            {
                Location = new Point(15, 15),
                Size = new Size(560, 180),
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false
            };
            tabLineas.Controls.Add(dgvLineas);

            Panel pnl = new Panel
            {
                Location = new Point(15, 210),
                Size = new Size(560, 160),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(248, 249, 250)
            };
            tabLineas.Controls.Add(pnl);

            AddLabel(pnl, "Nombre de Línea de Producto:", 15, 15);
            txtNombreLinea = AddTextBox(pnl, 15, 35, 240);

            AddLabel(pnl, "Descripción:", 15, 75);
            txtDescripcionLinea = AddTextBox(pnl, 15, 95, 240);

            btnRegistrarLinea = new Button
            {
                Text = "🧬 Registrar Línea",
                Location = new Point(285, 35),
                Size = new Size(250, 83),
                BackColor = Color.FromArgb(24, 43, 73),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnRegistrarLinea.FlatAppearance.BorderSize = 0;
            btnRegistrarLinea.Click += btnRegistrarLinea_Click;
            pnl.Controls.Add(btnRegistrarLinea);
        }

        private void CargarMarcas()
        {
            try
            {
                dgvMarcas.DataSource = Conexion.ExecuteQuery("SELECT id_marca AS [ID], nombre_marca AS [Marca], origen_marca AS [Origen] FROM Marca");
            }
            catch { }
        }

        private void CargarProveedores()
        {
            try
            {
                dgvProveedores.DataSource = Conexion.ExecuteQuery("SELECT id_proveedor AS [ID], nombre_proveedor AS [Proveedor], ruc_proveedor AS [RUC], telefono_proveedor AS [Teléfono], correo_proveedor AS [Correo] FROM Proveedor");
            }
            catch { }
        }

        private void CargarCategorias()
        {
            try
            {
                dgvCategorias.DataSource = Conexion.ExecuteQuery("SELECT id_categoria AS [ID], nombre_categoria AS [Categoría], descripcion_categoria AS [Descripción] FROM Categoria_Producto");
            }
            catch { }
        }

        private void CargarLineas()
        {
            try
            {
                dgvLineas.DataSource = Conexion.ExecuteQuery("SELECT id_linea AS [ID], nombre_linea AS [Línea], descripcion_linea AS [Descripción] FROM Linea_de_producto");
            }
            catch { }
        }

        private void btnRegistrarMarca_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreMarca.Text.Trim();
            string origen = txtOrigenMarca.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingrese el nombre de la marca.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO Marca (nombre_marca, origen_marca) VALUES (@Nombre, @Origen)";
                System.Data.SqlClient.SqlParameter[] p = {
                    new System.Data.SqlClient.SqlParameter("@Nombre", nombre),
                    new System.Data.SqlClient.SqlParameter("@Origen", string.IsNullOrEmpty(origen) ? (object)DBNull.Value : origen)
                };
                Conexion.ExecuteNonQuery(query, p);
                MessageBox.Show("Marca registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMarcas();
                txtNombreMarca.Clear();
                txtOrigenMarca.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar marca: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarProveedor_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreProv.Text.Trim();
            string ruc = txtRucProv.Text.Trim();
            string tel = txtTelefonoProv.Text.Trim();
            string correo = txtCorreoProv.Text.Trim();
            string dir = txtDireccionProv.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(ruc))
            {
                MessageBox.Show("Complete el Nombre y RUC del proveedor.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO Proveedor (nombre_proveedor, ruc_proveedor, telefono_proveedor, correo_proveedor, direccion_proveedor) VALUES (@Nombre, @Ruc, @Tel, @Correo, @Dir)";
                System.Data.SqlClient.SqlParameter[] p = {
                    new System.Data.SqlClient.SqlParameter("@Nombre", nombre),
                    new System.Data.SqlClient.SqlParameter("@Ruc", ruc),
                    new System.Data.SqlClient.SqlParameter("@Tel", string.IsNullOrEmpty(tel) ? (object)DBNull.Value : tel),
                    new System.Data.SqlClient.SqlParameter("@Correo", string.IsNullOrEmpty(correo) ? (object)DBNull.Value : correo),
                    new System.Data.SqlClient.SqlParameter("@Dir", string.IsNullOrEmpty(dir) ? (object)DBNull.Value : dir)
                };
                Conexion.ExecuteNonQuery(query, p);
                MessageBox.Show("Proveedor registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProveedores();
                txtNombreProv.Clear();
                txtRucProv.Clear();
                txtTelefonoProv.Clear();
                txtCorreoProv.Clear();
                txtDireccionProv.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar proveedor: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarCategoria_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCategoria.Text.Trim();
            string desc = txtDescripcionCategoria.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Complete el nombre de la categoría.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO Categoria_Producto (nombre_categoria, descripcion_categoria) VALUES (@Nombre, @Desc)";
                System.Data.SqlClient.SqlParameter[] p = {
                    new System.Data.SqlClient.SqlParameter("@Nombre", nombre),
                    new System.Data.SqlClient.SqlParameter("@Desc", string.IsNullOrEmpty(desc) ? (object)DBNull.Value : desc)
                };
                Conexion.ExecuteNonQuery(query, p);
                MessageBox.Show("Categoría registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCategorias();
                txtNombreCategoria.Clear();
                txtDescripcionCategoria.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar categoría: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarLinea_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreLinea.Text.Trim();
            string desc = txtDescripcionLinea.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Complete el nombre de la línea.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO Linea_de_producto (nombre_linea, descripcion_linea) VALUES (@Nombre, @Desc)";
                System.Data.SqlClient.SqlParameter[] p = {
                    new System.Data.SqlClient.SqlParameter("@Nombre", nombre),
                    new System.Data.SqlClient.SqlParameter("@Desc", string.IsNullOrEmpty(desc) ? (object)DBNull.Value : desc)
                };
                Conexion.ExecuteNonQuery(query, p);
                MessageBox.Show("Línea registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarLineas();
                txtNombreLinea.Clear();
                txtDescripcionLinea.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar línea: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddLabel(Panel p, string text, int x, int y)
        {
            Label lbl = new Label { Text = text, Location = new Point(x, y), Size = new Size(250, 18), Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold), ForeColor = Color.FromArgb(108, 117, 125) };
            p.Controls.Add(lbl);
        }

        private TextBox AddTextBox(Panel p, int x, int y, int w)
        {
            TextBox txt = new TextBox { Location = new Point(x, y), Size = new Size(w, 20) };
            p.Controls.Add(txt);
            return txt;
        }
    }
}

