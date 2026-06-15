namespace HiroPhone
{
    partial class FormRRHH
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

            // Asistencias tab
            this.tabAsistencias = new System.Windows.Forms.TabPage();
            this.panelAsistencia = new System.Windows.Forms.Panel();
            this.lblMarcarAsistencia = new System.Windows.Forms.Label();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.btnSalida = new System.Windows.Forms.Button();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.lblLogsAsistencia = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscarAsistencia = new System.Windows.Forms.TextBox();
            this.dgvAsistencia = new System.Windows.Forms.DataGridView();

            // Contratos tab
            this.tabContratos = new System.Windows.Forms.TabPage();
            this.dgvContratos = new System.Windows.Forms.DataGridView();
            this.pnlContratos = new System.Windows.Forms.Panel();
            this.lblEmpleadoContrato = new System.Windows.Forms.Label();
            this.cboEmpleadoContrato = new System.Windows.Forms.ComboBox();
            this.lblSueldoBase = new System.Windows.Forms.Label();
            this.txtSueldoBase = new System.Windows.Forms.TextBox();
            this.lblEstadoContrato = new System.Windows.Forms.Label();
            this.cboEstadoContrato = new System.Windows.Forms.ComboBox();
            this.lblInicioContrato = new System.Windows.Forms.Label();
            this.dtpInicioContrato = new System.Windows.Forms.DateTimePicker();
            this.lblFinContrato = new System.Windows.Forms.Label();
            this.dtpFinContrato = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrarContrato = new System.Windows.Forms.Button();

            // Capacitaciones tab
            this.tabCapacitaciones = new System.Windows.Forms.TabPage();
            this.dgvCapacitaciones = new System.Windows.Forms.DataGridView();
            this.pnlCapacitaciones = new System.Windows.Forms.Panel();
            this.lblEmpleadoCapacitacion = new System.Windows.Forms.Label();
            this.cboEmpleadoCapacitacion = new System.Windows.Forms.ComboBox();
            this.lblNombreCapacitacion = new System.Windows.Forms.Label();
            this.txtNombreCapacitacion = new System.Windows.Forms.TextBox();
            this.lblFechaCapacitacion = new System.Windows.Forms.Label();
            this.dtpFechaCapacitacion = new System.Windows.Forms.DateTimePicker();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.nudDuracionHoras = new System.Windows.Forms.NumericUpDown();
            this.lblDescripcionCapacitacion = new System.Windows.Forms.Label();
            this.txtDescripcionCapacitacion = new System.Windows.Forms.TextBox();
            this.btnRegistrarCapacitacion = new System.Windows.Forms.Button();

            // Areas y Turnos tab
            this.tabAreasTurnos = new System.Windows.Forms.TabPage();
            this.dgvAreas = new System.Windows.Forms.DataGridView();
            this.pnlAreas = new System.Windows.Forms.Panel();
            this.lblNombreArea = new System.Windows.Forms.Label();
            this.txtNombreArea = new System.Windows.Forms.TextBox();
            this.lblDescripcionArea = new System.Windows.Forms.Label();
            this.txtDescripcionArea = new System.Windows.Forms.TextBox();
            this.btnRegistrarArea = new System.Windows.Forms.Button();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.pnlTurnos = new System.Windows.Forms.Panel();
            this.lblNombreTurno = new System.Windows.Forms.Label();
            this.txtNombreTurno = new System.Windows.Forms.TextBox();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.lblHoraFin = new System.Windows.Forms.Label();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrarTurno = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapacitaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracionHoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.panelAsistencia.SuspendLayout();
            this.panelGrid.SuspendLayout();
            this.pnlContratos.SuspendLayout();
            this.pnlCapacitaciones.SuspendLayout();
            this.pnlAreas.SuspendLayout();
            this.pnlTurnos.SuspendLayout();
            this.tabAsistencias.SuspendLayout();
            this.tabContratos.SuspendLayout();
            this.tabCapacitaciones.SuspendLayout();
            this.tabAreasTurnos.SuspendLayout();
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
            this.lblTitulo.Size = new System.Drawing.Size(371, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Recursos Humanos y Asistencias";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.tabControl.Controls.Add(this.tabAsistencias);
            this.tabControl.Controls.Add(this.tabContratos);
            this.tabControl.Controls.Add(this.tabCapacitaciones);
            this.tabControl.Controls.Add(this.tabAreasTurnos);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControl.Location = new System.Drawing.Point(20, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 480);
            this.tabControl.TabIndex = 1;

            // ─── TAB ASISTENCIAS ─────────────────────────────────────────
            // 
            // tabAsistencias
            // 
            this.tabAsistencias.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);
            this.tabAsistencias.Controls.Add(this.panelAsistencia);
            this.tabAsistencias.Controls.Add(this.panelGrid);
            this.tabAsistencias.Location = new System.Drawing.Point(4, 26);
            this.tabAsistencias.Name = "tabAsistencias";
            this.tabAsistencias.Padding = new System.Windows.Forms.Padding(3);
            this.tabAsistencias.Size = new System.Drawing.Size(792, 450);
            this.tabAsistencias.TabIndex = 0;
            this.tabAsistencias.Text = "Asistencias";
            // 
            // panelAsistencia
            // 
            this.panelAsistencia.BackColor = System.Drawing.Color.White;
            this.panelAsistencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAsistencia.Controls.Add(this.lblMarcarAsistencia);
            this.panelAsistencia.Controls.Add(this.lblEmpleado);
            this.panelAsistencia.Controls.Add(this.cboEmpleado);
            this.panelAsistencia.Controls.Add(this.btnEntrada);
            this.panelAsistencia.Controls.Add(this.btnSalida);
            this.panelAsistencia.Location = new System.Drawing.Point(10, 10);
            this.panelAsistencia.Name = "panelAsistencia";
            this.panelAsistencia.Size = new System.Drawing.Size(265, 430);
            this.panelAsistencia.TabIndex = 0;
            // 
            // lblMarcarAsistencia
            // 
            this.lblMarcarAsistencia.AutoSize = true;
            this.lblMarcarAsistencia.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblMarcarAsistencia.ForeColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.lblMarcarAsistencia.Location = new System.Drawing.Point(15, 15);
            this.lblMarcarAsistencia.Name = "lblMarcarAsistencia";
            this.lblMarcarAsistencia.Size = new System.Drawing.Size(200, 21);
            this.lblMarcarAsistencia.TabIndex = 0;
            this.lblMarcarAsistencia.Text = "Marcador de Asistencia";
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblEmpleado.Location = new System.Drawing.Point(15, 60);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(148, 17);
            this.lblEmpleado.TabIndex = 1;
            this.lblEmpleado.Text = "Seleccione Empleado:";
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(15, 82);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(230, 25);
            this.cboEmpleado.TabIndex = 2;
            // 
            // btnEntrada
            // 
            this.btnEntrada.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnEntrada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrada.FlatAppearance.BorderSize = 0;
            this.btnEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrada.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEntrada.ForeColor = System.Drawing.Color.White;
            this.btnEntrada.Location = new System.Drawing.Point(15, 130);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(230, 42);
            this.btnEntrada.TabIndex = 3;
            this.btnEntrada.Text = "✅ Marcar Entrada";
            this.btnEntrada.UseVisualStyleBackColor = false;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // btnSalida
            // 
            this.btnSalida.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnSalida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalida.FlatAppearance.BorderSize = 0;
            this.btnSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalida.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalida.ForeColor = System.Drawing.Color.White;
            this.btnSalida.Location = new System.Drawing.Point(15, 185);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(230, 42);
            this.btnSalida.TabIndex = 4;
            this.btnSalida.Text = "🚪 Marcar Salida";
            this.btnSalida.UseVisualStyleBackColor = false;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // panelGrid
            // 
            this.panelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGrid.BackColor = System.Drawing.Color.White;
            this.panelGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrid.Controls.Add(this.lblLogsAsistencia);
            this.panelGrid.Controls.Add(this.lblBuscar);
            this.panelGrid.Controls.Add(this.txtBuscarAsistencia);
            this.panelGrid.Controls.Add(this.dgvAsistencia);
            this.panelGrid.Location = new System.Drawing.Point(285, 10);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(497, 430);
            this.panelGrid.TabIndex = 1;
            // 
            // lblLogsAsistencia
            // 
            this.lblLogsAsistencia.AutoSize = true;
            this.lblLogsAsistencia.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogsAsistencia.ForeColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.lblLogsAsistencia.Location = new System.Drawing.Point(15, 15);
            this.lblLogsAsistencia.Name = "lblLogsAsistencia";
            this.lblLogsAsistencia.Size = new System.Drawing.Size(180, 21);
            this.lblLogsAsistencia.TabIndex = 0;
            this.lblLogsAsistencia.Text = "Registro de Asistencia";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblBuscar.Location = new System.Drawing.Point(220, 18);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(52, 17);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscarAsistencia
            // 
            this.txtBuscarAsistencia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscarAsistencia.Location = new System.Drawing.Point(278, 15);
            this.txtBuscarAsistencia.Name = "txtBuscarAsistencia";
            this.txtBuscarAsistencia.Size = new System.Drawing.Size(200, 25);
            this.txtBuscarAsistencia.TabIndex = 2;
            this.txtBuscarAsistencia.TextChanged += new System.EventHandler(this.txtBuscarAsistencia_TextChanged);
            // 
            // dgvAsistencia
            // 
            this.dgvAsistencia.AllowUserToAddRows = false;
            this.dgvAsistencia.AllowUserToDeleteRows = false;
            this.dgvAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAsistencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsistencia.BackgroundColor = System.Drawing.Color.White;
            this.dgvAsistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistencia.Location = new System.Drawing.Point(15, 50);
            this.dgvAsistencia.Name = "dgvAsistencia";
            this.dgvAsistencia.ReadOnly = true;
            this.dgvAsistencia.RowHeadersVisible = false;
            this.dgvAsistencia.Size = new System.Drawing.Size(465, 365);
            this.dgvAsistencia.TabIndex = 3;

            // ─── TAB CONTRATOS ───────────────────────────────────────────
            // 
            // tabContratos
            // 
            this.tabContratos.BackColor = System.Drawing.Color.White;
            this.tabContratos.Controls.Add(this.dgvContratos);
            this.tabContratos.Controls.Add(this.pnlContratos);
            this.tabContratos.Location = new System.Drawing.Point(4, 26);
            this.tabContratos.Name = "tabContratos";
            this.tabContratos.Padding = new System.Windows.Forms.Padding(3);
            this.tabContratos.Size = new System.Drawing.Size(792, 450);
            this.tabContratos.TabIndex = 1;
            this.tabContratos.Text = "Contratos";
            // 
            // dgvContratos
            // 
            this.dgvContratos.AllowUserToAddRows = false;
            this.dgvContratos.AllowUserToDeleteRows = false;
            this.dgvContratos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContratos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContratos.BackgroundColor = System.Drawing.Color.White;
            this.dgvContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContratos.Location = new System.Drawing.Point(15, 15);
            this.dgvContratos.Name = "dgvContratos";
            this.dgvContratos.ReadOnly = true;
            this.dgvContratos.RowHeadersVisible = false;
            this.dgvContratos.Size = new System.Drawing.Size(762, 180);
            this.dgvContratos.TabIndex = 0;
            // 
            // pnlContratos
            // 
            this.pnlContratos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContratos.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlContratos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContratos.Controls.Add(this.lblEmpleadoContrato);
            this.pnlContratos.Controls.Add(this.cboEmpleadoContrato);
            this.pnlContratos.Controls.Add(this.lblSueldoBase);
            this.pnlContratos.Controls.Add(this.txtSueldoBase);
            this.pnlContratos.Controls.Add(this.lblEstadoContrato);
            this.pnlContratos.Controls.Add(this.cboEstadoContrato);
            this.pnlContratos.Controls.Add(this.lblInicioContrato);
            this.pnlContratos.Controls.Add(this.dtpInicioContrato);
            this.pnlContratos.Controls.Add(this.lblFinContrato);
            this.pnlContratos.Controls.Add(this.dtpFinContrato);
            this.pnlContratos.Controls.Add(this.btnRegistrarContrato);
            this.pnlContratos.Location = new System.Drawing.Point(15, 208);
            this.pnlContratos.Name = "pnlContratos";
            this.pnlContratos.Size = new System.Drawing.Size(762, 232);
            this.pnlContratos.TabIndex = 1;
            // 
            // lblEmpleadoContrato
            // 
            this.lblEmpleadoContrato.AutoSize = true;
            this.lblEmpleadoContrato.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmpleadoContrato.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblEmpleadoContrato.Location = new System.Drawing.Point(15, 15);
            this.lblEmpleadoContrato.Name = "lblEmpleadoContrato";
            this.lblEmpleadoContrato.Size = new System.Drawing.Size(148, 15);
            this.lblEmpleadoContrato.TabIndex = 0;
            this.lblEmpleadoContrato.Text = "Seleccionar Empleado:";
            // 
            // cboEmpleadoContrato
            // 
            this.cboEmpleadoContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleadoContrato.FormattingEnabled = true;
            this.cboEmpleadoContrato.Location = new System.Drawing.Point(15, 33);
            this.cboEmpleadoContrato.Name = "cboEmpleadoContrato";
            this.cboEmpleadoContrato.Size = new System.Drawing.Size(350, 23);
            this.cboEmpleadoContrato.TabIndex = 1;
            // 
            // lblSueldoBase
            // 
            this.lblSueldoBase.AutoSize = true;
            this.lblSueldoBase.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblSueldoBase.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblSueldoBase.Location = new System.Drawing.Point(15, 72);
            this.lblSueldoBase.Name = "lblSueldoBase";
            this.lblSueldoBase.Size = new System.Drawing.Size(113, 15);
            this.lblSueldoBase.TabIndex = 2;
            this.lblSueldoBase.Text = "Sueldo Base (S/.):";
            // 
            // txtSueldoBase
            // 
            this.txtSueldoBase.Location = new System.Drawing.Point(15, 90);
            this.txtSueldoBase.Name = "txtSueldoBase";
            this.txtSueldoBase.Size = new System.Drawing.Size(160, 23);
            this.txtSueldoBase.TabIndex = 3;
            // 
            // lblEstadoContrato
            // 
            this.lblEstadoContrato.AutoSize = true;
            this.lblEstadoContrato.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstadoContrato.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblEstadoContrato.Location = new System.Drawing.Point(205, 72);
            this.lblEstadoContrato.Name = "lblEstadoContrato";
            this.lblEstadoContrato.Size = new System.Drawing.Size(128, 15);
            this.lblEstadoContrato.TabIndex = 4;
            this.lblEstadoContrato.Text = "Estado del Contrato:";
            // 
            // cboEstadoContrato
            // 
            this.cboEstadoContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoContrato.FormattingEnabled = true;
            this.cboEstadoContrato.Items.AddRange(new object[] { "Activo", "Inactivo" });
            this.cboEstadoContrato.Location = new System.Drawing.Point(205, 90);
            this.cboEstadoContrato.Name = "cboEstadoContrato";
            this.cboEstadoContrato.Size = new System.Drawing.Size(160, 23);
            this.cboEstadoContrato.TabIndex = 5;
            // 
            // lblInicioContrato
            // 
            this.lblInicioContrato.AutoSize = true;
            this.lblInicioContrato.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblInicioContrato.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblInicioContrato.Location = new System.Drawing.Point(15, 130);
            this.lblInicioContrato.Name = "lblInicioContrato";
            this.lblInicioContrato.Size = new System.Drawing.Size(96, 15);
            this.lblInicioContrato.TabIndex = 6;
            this.lblInicioContrato.Text = "Fecha de Inicio:";
            // 
            // dtpInicioContrato
            // 
            this.dtpInicioContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicioContrato.Location = new System.Drawing.Point(15, 148);
            this.dtpInicioContrato.Name = "dtpInicioContrato";
            this.dtpInicioContrato.Size = new System.Drawing.Size(160, 23);
            this.dtpInicioContrato.TabIndex = 7;
            // 
            // lblFinContrato
            // 
            this.lblFinContrato.AutoSize = true;
            this.lblFinContrato.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblFinContrato.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblFinContrato.Location = new System.Drawing.Point(205, 130);
            this.lblFinContrato.Name = "lblFinContrato";
            this.lblFinContrato.Size = new System.Drawing.Size(84, 15);
            this.lblFinContrato.TabIndex = 8;
            this.lblFinContrato.Text = "Fecha de Fin:";
            // 
            // dtpFinContrato
            // 
            this.dtpFinContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinContrato.Location = new System.Drawing.Point(205, 148);
            this.dtpFinContrato.Name = "dtpFinContrato";
            this.dtpFinContrato.Size = new System.Drawing.Size(160, 23);
            this.dtpFinContrato.TabIndex = 9;
            // 
            // btnRegistrarContrato
            // 
            this.btnRegistrarContrato.BackColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.btnRegistrarContrato.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarContrato.FlatAppearance.BorderSize = 0;
            this.btnRegistrarContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarContrato.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarContrato.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarContrato.Location = new System.Drawing.Point(410, 33);
            this.btnRegistrarContrato.Name = "btnRegistrarContrato";
            this.btnRegistrarContrato.Size = new System.Drawing.Size(330, 45);
            this.btnRegistrarContrato.TabIndex = 10;
            this.btnRegistrarContrato.Text = "Registrar Contrato";
            this.btnRegistrarContrato.UseVisualStyleBackColor = false;
            this.btnRegistrarContrato.Click += new System.EventHandler(this.btnRegistrarContrato_Click);

            // ─── TAB CAPACITACIONES ──────────────────────────────────────
            // 
            // tabCapacitaciones
            // 
            this.tabCapacitaciones.BackColor = System.Drawing.Color.White;
            this.tabCapacitaciones.Controls.Add(this.dgvCapacitaciones);
            this.tabCapacitaciones.Controls.Add(this.pnlCapacitaciones);
            this.tabCapacitaciones.Location = new System.Drawing.Point(4, 26);
            this.tabCapacitaciones.Name = "tabCapacitaciones";
            this.tabCapacitaciones.Size = new System.Drawing.Size(792, 450);
            this.tabCapacitaciones.TabIndex = 2;
            this.tabCapacitaciones.Text = "Capacitaciones";
            // 
            // dgvCapacitaciones
            // 
            this.dgvCapacitaciones.AllowUserToAddRows = false;
            this.dgvCapacitaciones.AllowUserToDeleteRows = false;
            this.dgvCapacitaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCapacitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCapacitaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvCapacitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCapacitaciones.Location = new System.Drawing.Point(15, 15);
            this.dgvCapacitaciones.Name = "dgvCapacitaciones";
            this.dgvCapacitaciones.ReadOnly = true;
            this.dgvCapacitaciones.RowHeadersVisible = false;
            this.dgvCapacitaciones.Size = new System.Drawing.Size(762, 180);
            this.dgvCapacitaciones.TabIndex = 0;
            // 
            // pnlCapacitaciones
            // 
            this.pnlCapacitaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCapacitaciones.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlCapacitaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCapacitaciones.Controls.Add(this.lblEmpleadoCapacitacion);
            this.pnlCapacitaciones.Controls.Add(this.cboEmpleadoCapacitacion);
            this.pnlCapacitaciones.Controls.Add(this.lblNombreCapacitacion);
            this.pnlCapacitaciones.Controls.Add(this.txtNombreCapacitacion);
            this.pnlCapacitaciones.Controls.Add(this.lblFechaCapacitacion);
            this.pnlCapacitaciones.Controls.Add(this.dtpFechaCapacitacion);
            this.pnlCapacitaciones.Controls.Add(this.lblDuracion);
            this.pnlCapacitaciones.Controls.Add(this.nudDuracionHoras);
            this.pnlCapacitaciones.Controls.Add(this.lblDescripcionCapacitacion);
            this.pnlCapacitaciones.Controls.Add(this.txtDescripcionCapacitacion);
            this.pnlCapacitaciones.Controls.Add(this.btnRegistrarCapacitacion);
            this.pnlCapacitaciones.Location = new System.Drawing.Point(15, 208);
            this.pnlCapacitaciones.Name = "pnlCapacitaciones";
            this.pnlCapacitaciones.Size = new System.Drawing.Size(762, 232);
            this.pnlCapacitaciones.TabIndex = 1;
            // 
            // lblEmpleadoCapacitacion
            // 
            this.lblEmpleadoCapacitacion.AutoSize = true;
            this.lblEmpleadoCapacitacion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmpleadoCapacitacion.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblEmpleadoCapacitacion.Location = new System.Drawing.Point(15, 15);
            this.lblEmpleadoCapacitacion.Name = "lblEmpleadoCapacitacion";
            this.lblEmpleadoCapacitacion.Size = new System.Drawing.Size(148, 15);
            this.lblEmpleadoCapacitacion.TabIndex = 0;
            this.lblEmpleadoCapacitacion.Text = "Seleccionar Empleado:";
            // 
            // cboEmpleadoCapacitacion
            // 
            this.cboEmpleadoCapacitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleadoCapacitacion.FormattingEnabled = true;
            this.cboEmpleadoCapacitacion.Location = new System.Drawing.Point(15, 33);
            this.cboEmpleadoCapacitacion.Name = "cboEmpleadoCapacitacion";
            this.cboEmpleadoCapacitacion.Size = new System.Drawing.Size(350, 23);
            this.cboEmpleadoCapacitacion.TabIndex = 1;
            // 
            // lblNombreCapacitacion
            // 
            this.lblNombreCapacitacion.AutoSize = true;
            this.lblNombreCapacitacion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombreCapacitacion.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblNombreCapacitacion.Location = new System.Drawing.Point(15, 72);
            this.lblNombreCapacitacion.Name = "lblNombreCapacitacion";
            this.lblNombreCapacitacion.Size = new System.Drawing.Size(161, 15);
            this.lblNombreCapacitacion.TabIndex = 2;
            this.lblNombreCapacitacion.Text = "Nombre de Capacitación:";
            // 
            // txtNombreCapacitacion
            // 
            this.txtNombreCapacitacion.Location = new System.Drawing.Point(15, 90);
            this.txtNombreCapacitacion.Name = "txtNombreCapacitacion";
            this.txtNombreCapacitacion.Size = new System.Drawing.Size(350, 23);
            this.txtNombreCapacitacion.TabIndex = 3;
            // 
            // lblFechaCapacitacion
            // 
            this.lblFechaCapacitacion.AutoSize = true;
            this.lblFechaCapacitacion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaCapacitacion.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblFechaCapacitacion.Location = new System.Drawing.Point(15, 130);
            this.lblFechaCapacitacion.Name = "lblFechaCapacitacion";
            this.lblFechaCapacitacion.Size = new System.Drawing.Size(145, 15);
            this.lblFechaCapacitacion.TabIndex = 4;
            this.lblFechaCapacitacion.Text = "Fecha de Capacitación:";
            // 
            // dtpFechaCapacitacion
            // 
            this.dtpFechaCapacitacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCapacitacion.Location = new System.Drawing.Point(15, 148);
            this.dtpFechaCapacitacion.Name = "dtpFechaCapacitacion";
            this.dtpFechaCapacitacion.Size = new System.Drawing.Size(160, 23);
            this.dtpFechaCapacitacion.TabIndex = 5;
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDuracion.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblDuracion.Location = new System.Drawing.Point(205, 130);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(109, 15);
            this.lblDuracion.TabIndex = 6;
            this.lblDuracion.Text = "Duración (Horas):";
            // 
            // nudDuracionHoras
            // 
            this.nudDuracionHoras.Location = new System.Drawing.Point(205, 148);
            this.nudDuracionHoras.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudDuracionHoras.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudDuracionHoras.Name = "nudDuracionHoras";
            this.nudDuracionHoras.Size = new System.Drawing.Size(160, 23);
            this.nudDuracionHoras.TabIndex = 7;
            this.nudDuracionHoras.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // lblDescripcionCapacitacion
            // 
            this.lblDescripcionCapacitacion.AutoSize = true;
            this.lblDescripcionCapacitacion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescripcionCapacitacion.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblDescripcionCapacitacion.Location = new System.Drawing.Point(410, 15);
            this.lblDescripcionCapacitacion.Name = "lblDescripcionCapacitacion";
            this.lblDescripcionCapacitacion.Size = new System.Drawing.Size(218, 15);
            this.lblDescripcionCapacitacion.TabIndex = 8;
            this.lblDescripcionCapacitacion.Text = "Descripción de la Capacitación:";
            // 
            // txtDescripcionCapacitacion
            // 
            this.txtDescripcionCapacitacion.Location = new System.Drawing.Point(410, 33);
            this.txtDescripcionCapacitacion.Multiline = true;
            this.txtDescripcionCapacitacion.Name = "txtDescripcionCapacitacion";
            this.txtDescripcionCapacitacion.Size = new System.Drawing.Size(330, 75);
            this.txtDescripcionCapacitacion.TabIndex = 9;
            // 
            // btnRegistrarCapacitacion
            // 
            this.btnRegistrarCapacitacion.BackColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.btnRegistrarCapacitacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarCapacitacion.FlatAppearance.BorderSize = 0;
            this.btnRegistrarCapacitacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarCapacitacion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarCapacitacion.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarCapacitacion.Location = new System.Drawing.Point(410, 120);
            this.btnRegistrarCapacitacion.Name = "btnRegistrarCapacitacion";
            this.btnRegistrarCapacitacion.Size = new System.Drawing.Size(330, 45);
            this.btnRegistrarCapacitacion.TabIndex = 10;
            this.btnRegistrarCapacitacion.Text = "Registrar Capacitación";
            this.btnRegistrarCapacitacion.UseVisualStyleBackColor = false;
            this.btnRegistrarCapacitacion.Click += new System.EventHandler(this.btnRegistrarCapacitacion_Click);

            // ─── TAB ÁREAS Y TURNOS ──────────────────────────────────────
            // 
            // tabAreasTurnos
            // 
            this.tabAreasTurnos.BackColor = System.Drawing.Color.White;
            this.tabAreasTurnos.Controls.Add(this.dgvAreas);
            this.tabAreasTurnos.Controls.Add(this.pnlAreas);
            this.tabAreasTurnos.Controls.Add(this.dgvTurnos);
            this.tabAreasTurnos.Controls.Add(this.pnlTurnos);
            this.tabAreasTurnos.Location = new System.Drawing.Point(4, 26);
            this.tabAreasTurnos.Name = "tabAreasTurnos";
            this.tabAreasTurnos.Size = new System.Drawing.Size(792, 450);
            this.tabAreasTurnos.TabIndex = 3;
            this.tabAreasTurnos.Text = "Áreas y Turnos";
            // 
            // dgvAreas
            // 
            this.dgvAreas.AllowUserToAddRows = false;
            this.dgvAreas.AllowUserToDeleteRows = false;
            this.dgvAreas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAreas.BackgroundColor = System.Drawing.Color.White;
            this.dgvAreas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAreas.Location = new System.Drawing.Point(15, 15);
            this.dgvAreas.Name = "dgvAreas";
            this.dgvAreas.ReadOnly = true;
            this.dgvAreas.RowHeadersVisible = false;
            this.dgvAreas.Size = new System.Drawing.Size(360, 185);
            this.dgvAreas.TabIndex = 0;
            // 
            // pnlAreas
            // 
            this.pnlAreas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlAreas.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlAreas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAreas.Controls.Add(this.lblNombreArea);
            this.pnlAreas.Controls.Add(this.txtNombreArea);
            this.pnlAreas.Controls.Add(this.lblDescripcionArea);
            this.pnlAreas.Controls.Add(this.txtDescripcionArea);
            this.pnlAreas.Controls.Add(this.btnRegistrarArea);
            this.pnlAreas.Location = new System.Drawing.Point(15, 210);
            this.pnlAreas.Name = "pnlAreas";
            this.pnlAreas.Size = new System.Drawing.Size(360, 230);
            this.pnlAreas.TabIndex = 1;
            // 
            // lblNombreArea
            // 
            this.lblNombreArea.AutoSize = true;
            this.lblNombreArea.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombreArea.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblNombreArea.Location = new System.Drawing.Point(15, 15);
            this.lblNombreArea.Name = "lblNombreArea";
            this.lblNombreArea.Size = new System.Drawing.Size(98, 15);
            this.lblNombreArea.TabIndex = 0;
            this.lblNombreArea.Text = "Nombre de Área:";
            // 
            // txtNombreArea
            // 
            this.txtNombreArea.Location = new System.Drawing.Point(15, 33);
            this.txtNombreArea.Name = "txtNombreArea";
            this.txtNombreArea.Size = new System.Drawing.Size(325, 23);
            this.txtNombreArea.TabIndex = 1;
            // 
            // lblDescripcionArea
            // 
            this.lblDescripcionArea.AutoSize = true;
            this.lblDescripcionArea.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescripcionArea.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblDescripcionArea.Location = new System.Drawing.Point(15, 72);
            this.lblDescripcionArea.Name = "lblDescripcionArea";
            this.lblDescripcionArea.Size = new System.Drawing.Size(132, 15);
            this.lblDescripcionArea.TabIndex = 2;
            this.lblDescripcionArea.Text = "Descripción del Área:";
            // 
            // txtDescripcionArea
            // 
            this.txtDescripcionArea.Location = new System.Drawing.Point(15, 90);
            this.txtDescripcionArea.Multiline = true;
            this.txtDescripcionArea.Name = "txtDescripcionArea";
            this.txtDescripcionArea.Size = new System.Drawing.Size(325, 50);
            this.txtDescripcionArea.TabIndex = 3;
            // 
            // btnRegistrarArea
            // 
            this.btnRegistrarArea.BackColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.btnRegistrarArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarArea.FlatAppearance.BorderSize = 0;
            this.btnRegistrarArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarArea.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarArea.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarArea.Location = new System.Drawing.Point(15, 158);
            this.btnRegistrarArea.Name = "btnRegistrarArea";
            this.btnRegistrarArea.Size = new System.Drawing.Size(325, 40);
            this.btnRegistrarArea.TabIndex = 4;
            this.btnRegistrarArea.Text = "📂 Registrar Área";
            this.btnRegistrarArea.UseVisualStyleBackColor = false;
            this.btnRegistrarArea.Click += new System.EventHandler(this.btnRegistrarArea_Click);
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.AllowUserToAddRows = false;
            this.dgvTurnos.AllowUserToDeleteRows = false;
            this.dgvTurnos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTurnos.BackgroundColor = System.Drawing.Color.White;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Location = new System.Drawing.Point(390, 15);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.ReadOnly = true;
            this.dgvTurnos.RowHeadersVisible = false;
            this.dgvTurnos.Size = new System.Drawing.Size(387, 185);
            this.dgvTurnos.TabIndex = 2;
            // 
            // pnlTurnos
            // 
            this.pnlTurnos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTurnos.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlTurnos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTurnos.Controls.Add(this.lblNombreTurno);
            this.pnlTurnos.Controls.Add(this.txtNombreTurno);
            this.pnlTurnos.Controls.Add(this.lblHoraInicio);
            this.pnlTurnos.Controls.Add(this.dtpHoraInicio);
            this.pnlTurnos.Controls.Add(this.lblHoraFin);
            this.pnlTurnos.Controls.Add(this.dtpHoraFin);
            this.pnlTurnos.Controls.Add(this.btnRegistrarTurno);
            this.pnlTurnos.Location = new System.Drawing.Point(390, 210);
            this.pnlTurnos.Name = "pnlTurnos";
            this.pnlTurnos.Size = new System.Drawing.Size(387, 230);
            this.pnlTurnos.TabIndex = 3;
            // 
            // lblNombreTurno
            // 
            this.lblNombreTurno.AutoSize = true;
            this.lblNombreTurno.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombreTurno.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblNombreTurno.Location = new System.Drawing.Point(15, 15);
            this.lblNombreTurno.Name = "lblNombreTurno";
            this.lblNombreTurno.Size = new System.Drawing.Size(113, 15);
            this.lblNombreTurno.TabIndex = 0;
            this.lblNombreTurno.Text = "Nombre del Turno:";
            // 
            // txtNombreTurno
            // 
            this.txtNombreTurno.Location = new System.Drawing.Point(15, 33);
            this.txtNombreTurno.Name = "txtNombreTurno";
            this.txtNombreTurno.Size = new System.Drawing.Size(350, 23);
            this.txtNombreTurno.TabIndex = 1;
            // 
            // lblHoraInicio
            // 
            this.lblHoraInicio.AutoSize = true;
            this.lblHoraInicio.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblHoraInicio.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblHoraInicio.Location = new System.Drawing.Point(15, 72);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Size = new System.Drawing.Size(74, 15);
            this.lblHoraInicio.TabIndex = 2;
            this.lblHoraInicio.Text = "Hora Inicio:";
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicio.Location = new System.Drawing.Point(15, 90);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Size = new System.Drawing.Size(160, 23);
            this.dtpHoraInicio.TabIndex = 3;
            // 
            // lblHoraFin
            // 
            this.lblHoraFin.AutoSize = true;
            this.lblHoraFin.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblHoraFin.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblHoraFin.Location = new System.Drawing.Point(195, 72);
            this.lblHoraFin.Name = "lblHoraFin";
            this.lblHoraFin.Size = new System.Drawing.Size(58, 15);
            this.lblHoraFin.TabIndex = 4;
            this.lblHoraFin.Text = "Hora Fin:";
            // 
            // dtpHoraFin
            // 
            this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraFin.Location = new System.Drawing.Point(195, 90);
            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.ShowUpDown = true;
            this.dtpHoraFin.Size = new System.Drawing.Size(160, 23);
            this.dtpHoraFin.TabIndex = 5;
            // 
            // btnRegistrarTurno
            // 
            this.btnRegistrarTurno.BackColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.btnRegistrarTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarTurno.FlatAppearance.BorderSize = 0;
            this.btnRegistrarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarTurno.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarTurno.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarTurno.Location = new System.Drawing.Point(15, 158);
            this.btnRegistrarTurno.Name = "btnRegistrarTurno";
            this.btnRegistrarTurno.Size = new System.Drawing.Size(350, 40);
            this.btnRegistrarTurno.TabIndex = 6;
            this.btnRegistrarTurno.Text = "Registrar Turno";
            this.btnRegistrarTurno.UseVisualStyleBackColor = false;
            this.btnRegistrarTurno.Click += new System.EventHandler(this.btnRegistrarTurno_Click);

            // ─── FormRRHH ────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);
            this.ClientSize = new System.Drawing.Size(840, 570);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRRHH";
            this.Text = "RRHH";
            this.Load += new System.EventHandler(this.FormRRHH_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapacitaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracionHoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.panelAsistencia.ResumeLayout(false);
            this.panelAsistencia.PerformLayout();
            this.panelGrid.ResumeLayout(false);
            this.panelGrid.PerformLayout();
            this.pnlContratos.ResumeLayout(false);
            this.pnlContratos.PerformLayout();
            this.pnlCapacitaciones.ResumeLayout(false);
            this.pnlCapacitaciones.PerformLayout();
            this.pnlAreas.ResumeLayout(false);
            this.pnlAreas.PerformLayout();
            this.pnlTurnos.ResumeLayout(false);
            this.pnlTurnos.PerformLayout();
            this.tabAsistencias.ResumeLayout(false);
            this.tabContratos.ResumeLayout(false);
            this.tabCapacitaciones.ResumeLayout(false);
            this.tabAreasTurnos.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAsistencias;
        private System.Windows.Forms.TabPage tabContratos;
        private System.Windows.Forms.TabPage tabCapacitaciones;
        private System.Windows.Forms.TabPage tabAreasTurnos;

        // Asistencias
        private System.Windows.Forms.Panel panelAsistencia;
        private System.Windows.Forms.Label lblMarcarAsistencia;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.ComboBox cboEmpleado;
        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Label lblLogsAsistencia;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscarAsistencia;
        private System.Windows.Forms.DataGridView dgvAsistencia;

        // Contratos
        private System.Windows.Forms.DataGridView dgvContratos;
        private System.Windows.Forms.Panel pnlContratos;
        private System.Windows.Forms.Label lblEmpleadoContrato;
        private System.Windows.Forms.ComboBox cboEmpleadoContrato;
        private System.Windows.Forms.Label lblSueldoBase;
        private System.Windows.Forms.TextBox txtSueldoBase;
        private System.Windows.Forms.Label lblEstadoContrato;
        private System.Windows.Forms.ComboBox cboEstadoContrato;
        private System.Windows.Forms.Label lblInicioContrato;
        private System.Windows.Forms.DateTimePicker dtpInicioContrato;
        private System.Windows.Forms.Label lblFinContrato;
        private System.Windows.Forms.DateTimePicker dtpFinContrato;
        private System.Windows.Forms.Button btnRegistrarContrato;

        // Capacitaciones
        private System.Windows.Forms.DataGridView dgvCapacitaciones;
        private System.Windows.Forms.Panel pnlCapacitaciones;
        private System.Windows.Forms.Label lblEmpleadoCapacitacion;
        private System.Windows.Forms.ComboBox cboEmpleadoCapacitacion;
        private System.Windows.Forms.Label lblNombreCapacitacion;
        private System.Windows.Forms.TextBox txtNombreCapacitacion;
        private System.Windows.Forms.Label lblFechaCapacitacion;
        private System.Windows.Forms.DateTimePicker dtpFechaCapacitacion;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.NumericUpDown nudDuracionHoras;
        private System.Windows.Forms.Label lblDescripcionCapacitacion;
        private System.Windows.Forms.TextBox txtDescripcionCapacitacion;
        private System.Windows.Forms.Button btnRegistrarCapacitacion;

        // Áreas y Turnos
        private System.Windows.Forms.DataGridView dgvAreas;
        private System.Windows.Forms.Panel pnlAreas;
        private System.Windows.Forms.Label lblNombreArea;
        private System.Windows.Forms.TextBox txtNombreArea;
        private System.Windows.Forms.Label lblDescripcionArea;
        private System.Windows.Forms.TextBox txtDescripcionArea;
        private System.Windows.Forms.Button btnRegistrarArea;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.Panel pnlTurnos;
        private System.Windows.Forms.Label lblNombreTurno;
        private System.Windows.Forms.TextBox txtNombreTurno;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.Label lblHoraFin;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;
        private System.Windows.Forms.Button btnRegistrarTurno;
    }
}
