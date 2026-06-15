namespace HiroPhone
{
    partial class FormVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlVentas = new System.Windows.Forms.TabControl();
            this.tabPuntoVenta = new System.Windows.Forms.TabPage();
            this.tabHistorial = new System.Windows.Forms.TabPage();

            // Punto de Venta controls
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelInput = new System.Windows.Forms.Panel();
            this.lblDatosVenta = new System.Windows.Forms.Label();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.cboTipoComprobante = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();

            this.panelCart = new System.Windows.Forms.Panel();
            this.lblDetalleVenta = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblSubtotalVal = new System.Windows.Forms.Label();
            this.lblIgv = new System.Windows.Forms.Label();
            this.lblIgvVal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalVal = new System.Windows.Forms.Label();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.cboMetodoPago = new System.Windows.Forms.ComboBox();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnCerrarCaja = new System.Windows.Forms.Button();

            // Historial de Ventas controls
            this.lblHistorialTitulo = new System.Windows.Forms.Label();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.rdbDia = new System.Windows.Forms.RadioButton();
            this.rdbSemana = new System.Windows.Forms.RadioButton();
            this.rdbMes = new System.Windows.Forms.RadioButton();
            this.dgvHistorialVentas = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialVentas)).BeginInit();
            this.panelInput.SuspendLayout();
            this.panelCart.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.tabPuntoVenta.SuspendLayout();
            this.tabHistorial.SuspendLayout();
            this.tabControlVentas.SuspendLayout();
            this.SuspendLayout();

            // 
            // tabControlVentas
            // 
            this.tabControlVentas.Controls.Add(this.tabPuntoVenta);
            this.tabControlVentas.Controls.Add(this.tabHistorial);
            this.tabControlVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlVentas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControlVentas.Location = new System.Drawing.Point(0, 0);
            this.tabControlVentas.Name = "tabControlVentas";
            this.tabControlVentas.SelectedIndex = 0;
            this.tabControlVentas.Size = new System.Drawing.Size(860, 600);
            this.tabControlVentas.TabIndex = 0;
            // 
            // tabPuntoVenta
            // 
            this.tabPuntoVenta.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);
            this.tabPuntoVenta.Controls.Add(this.btnCerrarCaja);
            this.tabPuntoVenta.Controls.Add(this.panelCart);
            this.tabPuntoVenta.Controls.Add(this.panelInput);
            this.tabPuntoVenta.Controls.Add(this.lblTitulo);
            this.tabPuntoVenta.Location = new System.Drawing.Point(4, 26);
            this.tabPuntoVenta.Name = "tabPuntoVenta";
            this.tabPuntoVenta.Padding = new System.Windows.Forms.Padding(3);
            this.tabPuntoVenta.Size = new System.Drawing.Size(852, 570);
            this.tabPuntoVenta.TabIndex = 0;
            this.tabPuntoVenta.Text = "📋 Punto de Venta";
            // 
            // tabHistorial
            // 
            this.tabHistorial.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);
            this.tabHistorial.Controls.Add(this.dgvHistorialVentas);
            this.tabHistorial.Controls.Add(this.panelFiltros);
            this.tabHistorial.Controls.Add(this.lblHistorialTitulo);
            this.tabHistorial.Location = new System.Drawing.Point(4, 26);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistorial.Size = new System.Drawing.Size(852, 570);
            this.tabHistorial.TabIndex = 1;
            this.tabHistorial.Text = "📊 Historial de Ventas";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(325, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro de Caja y Facturación";
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.White;
            this.panelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInput.Controls.Add(this.btnAgregar);
            this.panelInput.Controls.Add(this.lblCantidad);
            this.panelInput.Controls.Add(this.numCantidad);
            this.panelInput.Controls.Add(this.txtPrecio);
            this.panelInput.Controls.Add(this.lblPrecio);
            this.panelInput.Controls.Add(this.cboProducto);
            this.panelInput.Controls.Add(this.lblProducto);
            this.panelInput.Controls.Add(this.cboCategoria);
            this.panelInput.Controls.Add(this.lblCategoria);
            this.panelInput.Controls.Add(this.txtCliente);
            this.panelInput.Controls.Add(this.lblCliente);
            this.panelInput.Controls.Add(this.lblTipoComprobante);
            this.panelInput.Controls.Add(this.cboTipoComprobante);
            this.panelInput.Controls.Add(this.lblDatosVenta);
            this.panelInput.Location = new System.Drawing.Point(20, 50);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(350, 490);
            this.panelInput.TabIndex = 1;
            // 
            // lblDatosVenta
            // 
            this.lblDatosVenta.AutoSize = true;
            this.lblDatosVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblDatosVenta.ForeColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.lblDatosVenta.Location = new System.Drawing.Point(15, 15);
            this.lblDatosVenta.Name = "lblDatosVenta";
            this.lblDatosVenta.Size = new System.Drawing.Size(139, 21);
            this.lblDatosVenta.TabIndex = 0;
            this.lblDatosVenta.Text = "Detalles de Entrada";
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTipoComprobante.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblTipoComprobante.Location = new System.Drawing.Point(20, 45);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(146, 17);
            this.lblTipoComprobante.TabIndex = 10;
            this.lblTipoComprobante.Text = "Tipo de Comprobante:";
            // 
            // cboTipoComprobante
            // 
            this.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipoComprobante.FormattingEnabled = true;
            this.cboTipoComprobante.Location = new System.Drawing.Point(20, 65);
            this.cboTipoComprobante.Name = "cboTipoComprobante";
            this.cboTipoComprobante.Size = new System.Drawing.Size(308, 25);
            this.cboTipoComprobante.TabIndex = 11;
            this.cboTipoComprobante.SelectedIndexChanged += new System.EventHandler(this.cboTipoComprobante_SelectedIndexChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblCliente.Location = new System.Drawing.Point(20, 100);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(126, 17);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente (Nombre/ID):";
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCliente.Location = new System.Drawing.Point(20, 120);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(308, 25);
            this.txtCliente.TabIndex = 2;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblCategoria.Location = new System.Drawing.Point(20, 158);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(70, 17);
            this.lblCategoria.TabIndex = 12;
            this.lblCategoria.Text = "Categoría:";
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(20, 178);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(308, 25);
            this.cboCategoria.TabIndex = 13;
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblProducto.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblProducto.Location = new System.Drawing.Point(20, 215);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(67, 17);
            this.lblProducto.TabIndex = 3;
            this.lblProducto.Text = "Producto:";
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(20, 235);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(308, 25);
            this.cboProducto.TabIndex = 4;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblPrecio.Location = new System.Drawing.Point(20, 272);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(48, 17);
            this.lblPrecio.TabIndex = 5;
            this.lblPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecio.Location = new System.Drawing.Point(20, 292);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(308, 25);
            this.txtPrecio.TabIndex = 6;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblCantidad.Location = new System.Drawing.Point(20, 328);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(65, 17);
            this.lblCantidad.TabIndex = 8;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // numCantidad
            // 
            this.numCantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numCantidad.Location = new System.Drawing.Point(20, 348);
            this.numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(308, 25);
            this.numCantidad.TabIndex = 7;
            this.numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(20, 395);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(308, 40);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "🛒 Agregar a la Venta";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panelCart
            // 
            this.panelCart.BackColor = System.Drawing.Color.White;
            this.panelCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCart.Controls.Add(this.cboMetodoPago);
            this.panelCart.Controls.Add(this.lblMetodoPago);
            this.panelCart.Controls.Add(this.btnProcesar);
            this.panelCart.Controls.Add(this.lblTotalVal);
            this.panelCart.Controls.Add(this.lblTotal);
            this.panelCart.Controls.Add(this.lblIgvVal);
            this.panelCart.Controls.Add(this.lblIgv);
            this.panelCart.Controls.Add(this.lblSubtotalVal);
            this.panelCart.Controls.Add(this.lblSubtotal);
            this.panelCart.Controls.Add(this.dgvDetalle);
            this.panelCart.Controls.Add(this.lblDetalleVenta);
            this.panelCart.Location = new System.Drawing.Point(390, 50);
            this.panelCart.Name = "panelCart";
            this.panelCart.Size = new System.Drawing.Size(450, 490);
            this.panelCart.TabIndex = 2;
            // 
            // lblDetalleVenta
            // 
            this.lblDetalleVenta.AutoSize = true;
            this.lblDetalleVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetalleVenta.ForeColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.lblDetalleVenta.Location = new System.Drawing.Point(15, 15);
            this.lblDetalleVenta.Name = "lblDetalleVenta";
            this.lblDetalleVenta.Size = new System.Drawing.Size(142, 21);
            this.lblDetalleVenta.TabIndex = 0;
            this.lblDetalleVenta.Text = "Detalles del Carro";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(15, 50);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.RowHeadersWidth = 51;
            this.dgvDetalle.Size = new System.Drawing.Size(415, 215);
            this.dgvDetalle.TabIndex = 1;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSubtotal.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblSubtotal.Location = new System.Drawing.Point(230, 280);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(68, 17);
            this.lblSubtotal.TabIndex = 2;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // lblSubtotalVal
            // 
            this.lblSubtotalVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotalVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalVal.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblSubtotalVal.Location = new System.Drawing.Point(310, 278);
            this.lblSubtotalVal.Name = "lblSubtotalVal";
            this.lblSubtotalVal.Size = new System.Drawing.Size(120, 20);
            this.lblSubtotalVal.TabIndex = 3;
            this.lblSubtotalVal.Text = "S/. 0.00";
            this.lblSubtotalVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIgv
            // 
            this.lblIgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIgv.AutoSize = true;
            this.lblIgv.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblIgv.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblIgv.Location = new System.Drawing.Point(230, 305);
            this.lblIgv.Name = "lblIgv";
            this.lblIgv.Size = new System.Drawing.Size(69, 17);
            this.lblIgv.TabIndex = 4;
            this.lblIgv.Text = "IGV (18%):";
            // 
            // lblIgvVal
            // 
            this.lblIgvVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIgvVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIgvVal.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblIgvVal.Location = new System.Drawing.Point(310, 303);
            this.lblIgvVal.Name = "lblIgvVal";
            this.lblIgvVal.Size = new System.Drawing.Size(120, 20);
            this.lblIgvVal.TabIndex = 5;
            this.lblIgvVal.Text = "S/. 0.00";
            this.lblIgvVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.lblTotal.Location = new System.Drawing.Point(210, 335);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(65, 25);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total:";
            // 
            // lblTotalVal
            // 
            this.lblTotalVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalVal.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalVal.ForeColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.lblTotalVal.Location = new System.Drawing.Point(290, 330);
            this.lblTotalVal.Name = "lblTotalVal";
            this.lblTotalVal.Size = new System.Drawing.Size(140, 30);
            this.lblTotalVal.TabIndex = 7;
            this.lblTotalVal.Text = "S/. 0.00";
            this.lblTotalVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblMetodoPago.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblMetodoPago.Location = new System.Drawing.Point(15, 370);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(113, 17);
            this.lblMetodoPago.TabIndex = 10;
            this.lblMetodoPago.Text = "Método de Pago:";
            // 
            // cboMetodoPago
            // 
            this.cboMetodoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMetodoPago.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMetodoPago.FormattingEnabled = true;
            this.cboMetodoPago.Location = new System.Drawing.Point(15, 390);
            this.cboMetodoPago.Name = "cboMetodoPago";
            this.cboMetodoPago.Size = new System.Drawing.Size(200, 25);
            this.cboMetodoPago.TabIndex = 11;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcesar.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcesar.FlatAppearance.BorderSize = 0;
            this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnProcesar.ForeColor = System.Drawing.Color.White;
            this.btnProcesar.Location = new System.Drawing.Point(15, 430);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(415, 45);
            this.btnProcesar.TabIndex = 8;
            this.btnProcesar.Text = "✅ Procesar Venta y Emitir Comprobante";
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnCerrarCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarCaja.FlatAppearance.BorderSize = 0;
            this.btnCerrarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarCaja.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCerrarCaja.ForeColor = System.Drawing.Color.White;
            this.btnCerrarCaja.Location = new System.Drawing.Point(620, 12);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(215, 32);
            this.btnCerrarCaja.TabIndex = 12;
            this.btnCerrarCaja.Text = "🔒 Arqueo y Cierre de Caja";
            this.btnCerrarCaja.UseVisualStyleBackColor = false;
            this.btnCerrarCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);
            //
            // ── Historial de Ventas tab controls ──────────────────────────────
            //
            // lblHistorialTitulo
            // 
            this.lblHistorialTitulo.AutoSize = true;
            this.lblHistorialTitulo.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblHistorialTitulo.ForeColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.lblHistorialTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblHistorialTitulo.Name = "lblHistorialTitulo";
            this.lblHistorialTitulo.Size = new System.Drawing.Size(300, 30);
            this.lblHistorialTitulo.TabIndex = 0;
            this.lblHistorialTitulo.Text = "Historial de Transacciones";
            // 
            // panelFiltros
            // 
            this.panelFiltros.Controls.Add(this.rdbDia);
            this.panelFiltros.Controls.Add(this.rdbSemana);
            this.panelFiltros.Controls.Add(this.rdbMes);
            this.panelFiltros.Location = new System.Drawing.Point(15, 55);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(500, 35);
            this.panelFiltros.TabIndex = 1;
            // 
            // rdbDia
            // 
            this.rdbDia.Checked = true;
            this.rdbDia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbDia.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.rdbDia.Location = new System.Drawing.Point(0, 5);
            this.rdbDia.Name = "rdbDia";
            this.rdbDia.Size = new System.Drawing.Size(130, 25);
            this.rdbDia.TabIndex = 0;
            this.rdbDia.TabStop = true;
            this.rdbDia.Text = "Ventas del Día";
            this.rdbDia.CheckedChanged += new System.EventHandler(this.rdbFiltro_CheckedChanged);
            // 
            // rdbSemana
            // 
            this.rdbSemana.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbSemana.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.rdbSemana.Location = new System.Drawing.Point(140, 5);
            this.rdbSemana.Name = "rdbSemana";
            this.rdbSemana.Size = new System.Drawing.Size(160, 25);
            this.rdbSemana.TabIndex = 1;
            this.rdbSemana.Text = "Ventas de la Semana";
            this.rdbSemana.CheckedChanged += new System.EventHandler(this.rdbFiltro_CheckedChanged);
            // 
            // rdbMes
            // 
            this.rdbMes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbMes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.rdbMes.Location = new System.Drawing.Point(310, 5);
            this.rdbMes.Name = "rdbMes";
            this.rdbMes.Size = new System.Drawing.Size(130, 25);
            this.rdbMes.TabIndex = 2;
            this.rdbMes.Text = "Ventas del Mes";
            this.rdbMes.CheckedChanged += new System.EventHandler(this.rdbFiltro_CheckedChanged);
            // 
            // dgvHistorialVentas
            // 
            this.dgvHistorialVentas.AllowUserToAddRows = false;
            this.dgvHistorialVentas.AllowUserToDeleteRows = false;
            this.dgvHistorialVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorialVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorialVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorialVentas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHistorialVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialVentas.Location = new System.Drawing.Point(15, 100);
            this.dgvHistorialVentas.Name = "dgvHistorialVentas";
            this.dgvHistorialVentas.ReadOnly = true;
            this.dgvHistorialVentas.RowHeadersVisible = false;
            this.dgvHistorialVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorialVentas.Size = new System.Drawing.Size(820, 455);
            this.dgvHistorialVentas.TabIndex = 2;
            this.dgvHistorialVentas.DoubleClick += new System.EventHandler(this.dgvHistorialVentas_DoubleClick);
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);
            this.ClientSize = new System.Drawing.Size(860, 600);
            this.Controls.Add(this.tabControlVentas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVentas";
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.FormVentas_Load);

            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialVentas)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelCart.ResumeLayout(false);
            this.panelCart.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.tabPuntoVenta.ResumeLayout(false);
            this.tabPuntoVenta.PerformLayout();
            this.tabHistorial.ResumeLayout(false);
            this.tabHistorial.PerformLayout();
            this.tabControlVentas.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        // TabControl + Tabs
        private System.Windows.Forms.TabControl tabControlVentas;
        private System.Windows.Forms.TabPage tabPuntoVenta;
        private System.Windows.Forms.TabPage tabHistorial;

        // Punto de Venta controls
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label lblDatosVenta;
        private System.Windows.Forms.Label lblTipoComprobante;
        private System.Windows.Forms.ComboBox cboTipoComprobante;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panelCart;
        private System.Windows.Forms.Label lblDetalleVenta;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblSubtotalVal;
        private System.Windows.Forms.Label lblIgv;
        private System.Windows.Forms.Label lblIgvVal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalVal;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cboMetodoPago;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnCerrarCaja;

        // Historial de Ventas controls
        private System.Windows.Forms.Label lblHistorialTitulo;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.RadioButton rdbDia;
        private System.Windows.Forms.RadioButton rdbSemana;
        private System.Windows.Forms.RadioButton rdbMes;
        private System.Windows.Forms.DataGridView dgvHistorialVentas;
    }
}
