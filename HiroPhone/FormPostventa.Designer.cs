namespace HiroPhone
{
    partial class FormPostventa
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();

            // Garantías tab
            this.tabGarantias = new System.Windows.Forms.TabPage();
            this.dgvGarantias = new System.Windows.Forms.DataGridView();
            this.pnlGarantias = new System.Windows.Forms.Panel();
            this.lblVentaDetalleGarantia = new System.Windows.Forms.Label();
            this.cboVentaDetalleGarantia = new System.Windows.Forms.ComboBox();
            this.lblTipoGarantia = new System.Windows.Forms.Label();
            this.cboTipoGarantia = new System.Windows.Forms.ComboBox();
            this.lblInicioGarantia = new System.Windows.Forms.Label();
            this.dtpInicioGarantia = new System.Windows.Forms.DateTimePicker();
            this.lblFinGarantiaCalculada = new System.Windows.Forms.Label();
            this.lblCondicionesGarantia = new System.Windows.Forms.Label();
            this.txtCondicionesGarantia = new System.Windows.Forms.TextBox();
            this.btnRegistrarGarantia = new System.Windows.Forms.Button();

            // Reclamos tab
            this.tabReclamos = new System.Windows.Forms.TabPage();
            this.dgvReclamos = new System.Windows.Forms.DataGridView();
            this.pnlReclamos = new System.Windows.Forms.Panel();
            this.lblClienteReclamo = new System.Windows.Forms.Label();
            this.cboClienteReclamo = new System.Windows.Forms.ComboBox();
            this.lblVentaReclamo = new System.Windows.Forms.Label();
            this.cboVentaReclamo = new System.Windows.Forms.ComboBox();
            this.lblEstadoReclamo = new System.Windows.Forms.Label();
            this.cboEstadoReclamo = new System.Windows.Forms.ComboBox();
            this.lblDescripcionReclamo = new System.Windows.Forms.Label();
            this.txtDescripcionReclamo = new System.Windows.Forms.TextBox();
            this.btnRegistrarReclamo = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvGarantias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReclamos)).BeginInit();
            this.pnlGarantias.SuspendLayout();
            this.pnlReclamos.SuspendLayout();
            this.tabGarantias.SuspendLayout();
            this.tabReclamos.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(450, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Garantías y Reclamos";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabGarantias);
            this.tabControl.Controls.Add(this.tabReclamos);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControl.Location = new System.Drawing.Point(20, 58);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 482);
            this.tabControl.TabIndex = 1;

            // ─── TAB GARANTÍAS ────────────────────────────────────────────
            // 
            // tabGarantias
            // 
            this.tabGarantias.BackColor = System.Drawing.Color.White;
            this.tabGarantias.Controls.Add(this.dgvGarantias);
            this.tabGarantias.Controls.Add(this.pnlGarantias);
            this.tabGarantias.Location = new System.Drawing.Point(4, 26);
            this.tabGarantias.Name = "tabGarantias";
            this.tabGarantias.Padding = new System.Windows.Forms.Padding(3);
            this.tabGarantias.Size = new System.Drawing.Size(792, 452);
            this.tabGarantias.TabIndex = 0;
            this.tabGarantias.Text = "🛡️ Garantías";
            // 
            // dgvGarantias
            // 
            this.dgvGarantias.AllowUserToAddRows = false;
            this.dgvGarantias.AllowUserToDeleteRows = false;
            this.dgvGarantias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGarantias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGarantias.BackgroundColor = System.Drawing.Color.White;
            this.dgvGarantias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGarantias.Location = new System.Drawing.Point(15, 15);
            this.dgvGarantias.Name = "dgvGarantias";
            this.dgvGarantias.ReadOnly = true;
            this.dgvGarantias.RowHeadersVisible = false;
            this.dgvGarantias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGarantias.Size = new System.Drawing.Size(762, 200);
            this.dgvGarantias.TabIndex = 0;
            // 
            // pnlGarantias
            // 
            this.pnlGarantias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGarantias.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlGarantias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGarantias.Controls.Add(this.lblVentaDetalleGarantia);
            this.pnlGarantias.Controls.Add(this.cboVentaDetalleGarantia);
            this.pnlGarantias.Controls.Add(this.lblTipoGarantia);
            this.pnlGarantias.Controls.Add(this.cboTipoGarantia);
            this.pnlGarantias.Controls.Add(this.lblInicioGarantia);
            this.pnlGarantias.Controls.Add(this.dtpInicioGarantia);
            this.pnlGarantias.Controls.Add(this.lblFinGarantiaCalculada);
            this.pnlGarantias.Controls.Add(this.lblCondicionesGarantia);
            this.pnlGarantias.Controls.Add(this.txtCondicionesGarantia);
            this.pnlGarantias.Controls.Add(this.btnRegistrarGarantia);
            this.pnlGarantias.Location = new System.Drawing.Point(15, 228);
            this.pnlGarantias.Name = "pnlGarantias";
            this.pnlGarantias.Size = new System.Drawing.Size(762, 210);
            this.pnlGarantias.TabIndex = 1;
            // 
            // lblVentaDetalleGarantia
            // 
            this.lblVentaDetalleGarantia.AutoSize = true;
            this.lblVentaDetalleGarantia.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblVentaDetalleGarantia.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblVentaDetalleGarantia.Location = new System.Drawing.Point(15, 10);
            this.lblVentaDetalleGarantia.Name = "lblVentaDetalleGarantia";
            this.lblVentaDetalleGarantia.Size = new System.Drawing.Size(290, 15);
            this.lblVentaDetalleGarantia.TabIndex = 0;
            this.lblVentaDetalleGarantia.Text = "Seleccionar Producto Vendido (Detalle Venta):";
            // 
            // cboVentaDetalleGarantia
            // 
            this.cboVentaDetalleGarantia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVentaDetalleGarantia.FormattingEnabled = true;
            this.cboVentaDetalleGarantia.Location = new System.Drawing.Point(15, 28);
            this.cboVentaDetalleGarantia.Name = "cboVentaDetalleGarantia";
            this.cboVentaDetalleGarantia.Size = new System.Drawing.Size(350, 23);
            this.cboVentaDetalleGarantia.TabIndex = 1;
            // 
            // lblTipoGarantia
            // 
            this.lblTipoGarantia.AutoSize = true;
            this.lblTipoGarantia.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoGarantia.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblTipoGarantia.Location = new System.Drawing.Point(15, 65);
            this.lblTipoGarantia.Name = "lblTipoGarantia";
            this.lblTipoGarantia.Size = new System.Drawing.Size(101, 15);
            this.lblTipoGarantia.TabIndex = 2;
            this.lblTipoGarantia.Text = "Tipo de Garantía:";
            // 
            // cboTipoGarantia
            // 
            this.cboTipoGarantia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoGarantia.FormattingEnabled = true;
            this.cboTipoGarantia.Location = new System.Drawing.Point(15, 83);
            this.cboTipoGarantia.Name = "cboTipoGarantia";
            this.cboTipoGarantia.Size = new System.Drawing.Size(200, 23);
            this.cboTipoGarantia.TabIndex = 3;
            this.cboTipoGarantia.SelectedIndexChanged += new System.EventHandler(this.cboTipoGarantia_SelectedIndexChanged);
            // 
            // lblInicioGarantia
            // 
            this.lblInicioGarantia.AutoSize = true;
            this.lblInicioGarantia.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblInicioGarantia.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblInicioGarantia.Location = new System.Drawing.Point(232, 65);
            this.lblInicioGarantia.Name = "lblInicioGarantia";
            this.lblInicioGarantia.Size = new System.Drawing.Size(96, 15);
            this.lblInicioGarantia.TabIndex = 4;
            this.lblInicioGarantia.Text = "Fecha de Inicio:";
            // 
            // dtpInicioGarantia
            // 
            this.dtpInicioGarantia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicioGarantia.Location = new System.Drawing.Point(232, 83);
            this.dtpInicioGarantia.Name = "dtpInicioGarantia";
            this.dtpInicioGarantia.Size = new System.Drawing.Size(135, 23);
            this.dtpInicioGarantia.TabIndex = 5;
            this.dtpInicioGarantia.ValueChanged += new System.EventHandler(this.dtpInicioGarantia_ValueChanged);
            // 
            // lblFinGarantiaCalculada
            // 
            this.lblFinGarantiaCalculada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFinGarantiaCalculada.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblFinGarantiaCalculada.Location = new System.Drawing.Point(15, 125);
            this.lblFinGarantiaCalculada.Name = "lblFinGarantiaCalculada";
            this.lblFinGarantiaCalculada.Size = new System.Drawing.Size(350, 20);
            this.lblFinGarantiaCalculada.TabIndex = 6;
            this.lblFinGarantiaCalculada.Text = "Fin de garantía calculada: —";
            // 
            // lblCondicionesGarantia
            // 
            this.lblCondicionesGarantia.AutoSize = true;
            this.lblCondicionesGarantia.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCondicionesGarantia.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblCondicionesGarantia.Location = new System.Drawing.Point(400, 10);
            this.lblCondicionesGarantia.Name = "lblCondicionesGarantia";
            this.lblCondicionesGarantia.Size = new System.Drawing.Size(236, 15);
            this.lblCondicionesGarantia.TabIndex = 7;
            this.lblCondicionesGarantia.Text = "Condiciones de Garantía / Cobertura:";
            // 
            // txtCondicionesGarantia
            // 
            this.txtCondicionesGarantia.Location = new System.Drawing.Point(400, 28);
            this.txtCondicionesGarantia.Multiline = true;
            this.txtCondicionesGarantia.Name = "txtCondicionesGarantia";
            this.txtCondicionesGarantia.Size = new System.Drawing.Size(345, 80);
            this.txtCondicionesGarantia.TabIndex = 8;
            // 
            // btnRegistrarGarantia
            // 
            this.btnRegistrarGarantia.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnRegistrarGarantia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarGarantia.FlatAppearance.BorderSize = 0;
            this.btnRegistrarGarantia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarGarantia.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarGarantia.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarGarantia.Location = new System.Drawing.Point(400, 125);
            this.btnRegistrarGarantia.Name = "btnRegistrarGarantia";
            this.btnRegistrarGarantia.Size = new System.Drawing.Size(345, 42);
            this.btnRegistrarGarantia.TabIndex = 9;
            this.btnRegistrarGarantia.Text = "Registrar Nueva Garantía";
            this.btnRegistrarGarantia.UseVisualStyleBackColor = false;
            this.btnRegistrarGarantia.Click += new System.EventHandler(this.btnRegistrarGarantia_Click);

            // ─── TAB RECLAMOS ─────────────────────────────────────────────
            // 
            // tabReclamos
            // 
            this.tabReclamos.BackColor = System.Drawing.Color.White;
            this.tabReclamos.Controls.Add(this.dgvReclamos);
            this.tabReclamos.Controls.Add(this.pnlReclamos);
            this.tabReclamos.Location = new System.Drawing.Point(4, 26);
            this.tabReclamos.Name = "tabReclamos";
            this.tabReclamos.Padding = new System.Windows.Forms.Padding(3);
            this.tabReclamos.Size = new System.Drawing.Size(792, 452);
            this.tabReclamos.TabIndex = 1;
            this.tabReclamos.Text = "📋 Reclamos de Clientes";
            // 
            // dgvReclamos
            // 
            this.dgvReclamos.AllowUserToAddRows = false;
            this.dgvReclamos.AllowUserToDeleteRows = false;
            this.dgvReclamos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReclamos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReclamos.BackgroundColor = System.Drawing.Color.White;
            this.dgvReclamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReclamos.Location = new System.Drawing.Point(15, 15);
            this.dgvReclamos.Name = "dgvReclamos";
            this.dgvReclamos.ReadOnly = true;
            this.dgvReclamos.RowHeadersVisible = false;
            this.dgvReclamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReclamos.Size = new System.Drawing.Size(762, 200);
            this.dgvReclamos.TabIndex = 0;
            // 
            // pnlReclamos
            // 
            this.pnlReclamos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReclamos.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlReclamos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReclamos.Controls.Add(this.lblClienteReclamo);
            this.pnlReclamos.Controls.Add(this.cboClienteReclamo);
            this.pnlReclamos.Controls.Add(this.lblVentaReclamo);
            this.pnlReclamos.Controls.Add(this.cboVentaReclamo);
            this.pnlReclamos.Controls.Add(this.lblEstadoReclamo);
            this.pnlReclamos.Controls.Add(this.cboEstadoReclamo);
            this.pnlReclamos.Controls.Add(this.lblDescripcionReclamo);
            this.pnlReclamos.Controls.Add(this.txtDescripcionReclamo);
            this.pnlReclamos.Controls.Add(this.btnRegistrarReclamo);
            this.pnlReclamos.Location = new System.Drawing.Point(15, 228);
            this.pnlReclamos.Name = "pnlReclamos";
            this.pnlReclamos.Size = new System.Drawing.Size(762, 210);
            this.pnlReclamos.TabIndex = 1;
            // 
            // lblClienteReclamo
            // 
            this.lblClienteReclamo.AutoSize = true;
            this.lblClienteReclamo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblClienteReclamo.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblClienteReclamo.Location = new System.Drawing.Point(15, 10);
            this.lblClienteReclamo.Name = "lblClienteReclamo";
            this.lblClienteReclamo.Size = new System.Drawing.Size(123, 15);
            this.lblClienteReclamo.TabIndex = 0;
            this.lblClienteReclamo.Text = "Seleccionar Cliente:";
            // 
            // cboClienteReclamo
            // 
            this.cboClienteReclamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClienteReclamo.FormattingEnabled = true;
            this.cboClienteReclamo.Location = new System.Drawing.Point(15, 28);
            this.cboClienteReclamo.Name = "cboClienteReclamo";
            this.cboClienteReclamo.Size = new System.Drawing.Size(200, 23);
            this.cboClienteReclamo.TabIndex = 1;
            this.cboClienteReclamo.SelectedIndexChanged += new System.EventHandler(this.cboClienteReclamo_SelectedIndexChanged);
            // 
            // lblVentaReclamo
            // 
            this.lblVentaReclamo.AutoSize = true;
            this.lblVentaReclamo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblVentaReclamo.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblVentaReclamo.Location = new System.Drawing.Point(15, 65);
            this.lblVentaReclamo.Name = "lblVentaReclamo";
            this.lblVentaReclamo.Size = new System.Drawing.Size(163, 15);
            this.lblVentaReclamo.TabIndex = 2;
            this.lblVentaReclamo.Text = "Boleta/Factura Vinculada:";
            // 
            // cboVentaReclamo
            // 
            this.cboVentaReclamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVentaReclamo.FormattingEnabled = true;
            this.cboVentaReclamo.Location = new System.Drawing.Point(15, 83);
            this.cboVentaReclamo.Name = "cboVentaReclamo";
            this.cboVentaReclamo.Size = new System.Drawing.Size(200, 23);
            this.cboVentaReclamo.TabIndex = 3;
            // 
            // lblEstadoReclamo
            // 
            this.lblEstadoReclamo.AutoSize = true;
            this.lblEstadoReclamo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstadoReclamo.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblEstadoReclamo.Location = new System.Drawing.Point(232, 65);
            this.lblEstadoReclamo.Name = "lblEstadoReclamo";
            this.lblEstadoReclamo.Size = new System.Drawing.Size(125, 15);
            this.lblEstadoReclamo.TabIndex = 4;
            this.lblEstadoReclamo.Text = "Estado del Reclamo:";
            // 
            // cboEstadoReclamo
            // 
            this.cboEstadoReclamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoReclamo.FormattingEnabled = true;
            this.cboEstadoReclamo.Items.AddRange(new object[] { "En Proceso", "Resuelto", "Cerrado" });
            this.cboEstadoReclamo.Location = new System.Drawing.Point(232, 83);
            this.cboEstadoReclamo.Name = "cboEstadoReclamo";
            this.cboEstadoReclamo.Size = new System.Drawing.Size(135, 23);
            this.cboEstadoReclamo.TabIndex = 5;
            // 
            // lblDescripcionReclamo
            // 
            this.lblDescripcionReclamo.AutoSize = true;
            this.lblDescripcionReclamo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescripcionReclamo.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblDescripcionReclamo.Location = new System.Drawing.Point(400, 10);
            this.lblDescripcionReclamo.Name = "lblDescripcionReclamo";
            this.lblDescripcionReclamo.Size = new System.Drawing.Size(237, 15);
            this.lblDescripcionReclamo.TabIndex = 6;
            this.lblDescripcionReclamo.Text = "Descripción del Reclamo / Problema:";
            // 
            // txtDescripcionReclamo
            // 
            this.txtDescripcionReclamo.Location = new System.Drawing.Point(400, 28);
            this.txtDescripcionReclamo.Multiline = true;
            this.txtDescripcionReclamo.Name = "txtDescripcionReclamo";
            this.txtDescripcionReclamo.Size = new System.Drawing.Size(345, 80);
            this.txtDescripcionReclamo.TabIndex = 7;
            // 
            // btnRegistrarReclamo
            // 
            this.btnRegistrarReclamo.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnRegistrarReclamo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarReclamo.FlatAppearance.BorderSize = 0;
            this.btnRegistrarReclamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarReclamo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarReclamo.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarReclamo.Location = new System.Drawing.Point(400, 125);
            this.btnRegistrarReclamo.Name = "btnRegistrarReclamo";
            this.btnRegistrarReclamo.Size = new System.Drawing.Size(345, 42);
            this.btnRegistrarReclamo.TabIndex = 8;
            this.btnRegistrarReclamo.Text = "Registrar Reclamo";
            this.btnRegistrarReclamo.UseVisualStyleBackColor = false;
            this.btnRegistrarReclamo.Click += new System.EventHandler(this.btnRegistrarReclamo_Click);

            // ─── FormPostventa ────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);
            this.ClientSize = new System.Drawing.Size(840, 570);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPostventa";
            this.Text = "Post-Venta";
            this.Load += new System.EventHandler(this.FormPostventa_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvGarantias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReclamos)).EndInit();
            this.pnlGarantias.ResumeLayout(false);
            this.pnlGarantias.PerformLayout();
            this.pnlReclamos.ResumeLayout(false);
            this.pnlReclamos.PerformLayout();
            this.tabGarantias.ResumeLayout(false);
            this.tabReclamos.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGarantias;
        private System.Windows.Forms.TabPage tabReclamos;

        // Garantías
        private System.Windows.Forms.DataGridView dgvGarantias;
        private System.Windows.Forms.Panel pnlGarantias;
        private System.Windows.Forms.Label lblVentaDetalleGarantia;
        private System.Windows.Forms.ComboBox cboVentaDetalleGarantia;
        private System.Windows.Forms.Label lblTipoGarantia;
        private System.Windows.Forms.ComboBox cboTipoGarantia;
        private System.Windows.Forms.Label lblInicioGarantia;
        private System.Windows.Forms.DateTimePicker dtpInicioGarantia;
        private System.Windows.Forms.Label lblFinGarantiaCalculada;
        private System.Windows.Forms.Label lblCondicionesGarantia;
        private System.Windows.Forms.TextBox txtCondicionesGarantia;
        private System.Windows.Forms.Button btnRegistrarGarantia;

        // Reclamos
        private System.Windows.Forms.DataGridView dgvReclamos;
        private System.Windows.Forms.Panel pnlReclamos;
        private System.Windows.Forms.Label lblClienteReclamo;
        private System.Windows.Forms.ComboBox cboClienteReclamo;
        private System.Windows.Forms.Label lblVentaReclamo;
        private System.Windows.Forms.ComboBox cboVentaReclamo;
        private System.Windows.Forms.Label lblEstadoReclamo;
        private System.Windows.Forms.ComboBox cboEstadoReclamo;
        private System.Windows.Forms.Label lblDescripcionReclamo;
        private System.Windows.Forms.TextBox txtDescripcionReclamo;
        private System.Windows.Forms.Button btnRegistrarReclamo;
    }
}
