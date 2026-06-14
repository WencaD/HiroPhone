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
            this.tabAsistencias = new System.Windows.Forms.TabPage();
            this.tabContratos = new System.Windows.Forms.TabPage();
            this.tabCapacitaciones = new System.Windows.Forms.TabPage();
            this.tabAreasTurnos = new System.Windows.Forms.TabPage();

            this.panelAsistencia = new System.Windows.Forms.Panel();
            this.btnSalida = new System.Windows.Forms.Button();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.lblMarcarAsistencia = new System.Windows.Forms.Label();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.dgvAsistencia = new System.Windows.Forms.DataGridView();
            this.lblLogsAsistencia = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscarAsistencia = new System.Windows.Forms.TextBox();

            this.dgvContratos = new System.Windows.Forms.DataGridView();
            this.cboEmpleadoContrato = new System.Windows.Forms.ComboBox();
            this.txtSueldoBase = new System.Windows.Forms.TextBox();
            this.dtpInicioContrato = new System.Windows.Forms.DateTimePicker();
            this.dtpFinContrato = new System.Windows.Forms.DateTimePicker();
            this.cboEstadoContrato = new System.Windows.Forms.ComboBox();
            this.btnRegistrarContrato = new System.Windows.Forms.Button();

            this.dgvCapacitaciones = new System.Windows.Forms.DataGridView();
            this.cboEmpleadoCapacitacion = new System.Windows.Forms.ComboBox();
            this.txtNombreCapacitacion = new System.Windows.Forms.TextBox();
            this.txtDescripcionCapacitacion = new System.Windows.Forms.TextBox();
            this.dtpFechaCapacitacion = new System.Windows.Forms.DateTimePicker();
            this.nudDuracionHoras = new System.Windows.Forms.NumericUpDown();
            this.btnRegistrarCapacitacion = new System.Windows.Forms.Button();

            this.dgvAreas = new System.Windows.Forms.DataGridView();
            this.txtNombreArea = new System.Windows.Forms.TextBox();
            this.txtDescripcionArea = new System.Windows.Forms.TextBox();
            this.btnRegistrarArea = new System.Windows.Forms.Button();

            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.txtNombreTurno = new System.Windows.Forms.TextBox();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrarTurno = new System.Windows.Forms.Button();

            this.tabControl.SuspendLayout();
            this.tabAsistencias.SuspendLayout();
            this.tabContratos.SuspendLayout();
            this.tabCapacitaciones.SuspendLayout();
            this.tabAreasTurnos.SuspendLayout();
            this.panelAsistencia.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapacitaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracionHoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTitulo.Size = new System.Drawing.Size(371, 30);
            this.lblTitulo.Text = "Recursos Humanos y Asistencias";

            // 
            // tabControl
            // 
            this.tabControl.Location = new System.Drawing.Point(20, 60);
            this.tabControl.Size = new System.Drawing.Size(800, 480);
            this.tabControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tabControl.TabPages.Add(this.tabAsistencias);
            this.tabControl.TabPages.Add(this.tabContratos);
            this.tabControl.TabPages.Add(this.tabCapacitaciones);
            this.tabControl.TabPages.Add(this.tabAreasTurnos);

            this.tabAsistencias.Text = "Asistencias";
            this.tabAsistencias.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);

            this.tabContratos.Text = "Contratos";
            this.tabContratos.BackColor = System.Drawing.Color.White;

            this.tabCapacitaciones.Text = "Capacitaciones";
            this.tabCapacitaciones.BackColor = System.Drawing.Color.White;

            this.tabAreasTurnos.Text = "Áreas y Turnos";
            this.tabAreasTurnos.BackColor = System.Drawing.Color.White;

            InitializeAsistenciasLayout();
            InitializeContratosLayout();
            InitializeCapacitacionesLayout();
            InitializeAreasTurnosLayout();

            // 
            // FormRRHH
            // 
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

            this.tabControl.ResumeLayout(false);
            this.tabAsistencias.ResumeLayout(false);
            this.tabContratos.ResumeLayout(false);
            this.tabCapacitaciones.ResumeLayout(false);
            this.tabAreasTurnos.ResumeLayout(false);
            this.panelAsistencia.ResumeLayout(false);
            this.panelAsistencia.PerformLayout();
            this.panelGrid.ResumeLayout(false);
            this.panelGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapacitaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracionHoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitializeAsistenciasLayout()
        {
            // panelAsistencia
            this.panelAsistencia.BackColor = System.Drawing.Color.White;
            this.panelAsistencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAsistencia.Controls.Add(this.btnSalida);
            this.panelAsistencia.Controls.Add(this.btnEntrada);
            this.panelAsistencia.Controls.Add(this.cboEmpleado);
            this.panelAsistencia.Controls.Add(this.lblEmpleado);
            this.panelAsistencia.Controls.Add(this.lblMarcarAsistencia);
            this.panelAsistencia.Location = new System.Drawing.Point(10, 10);
            this.panelAsistencia.Size = new System.Drawing.Size(260, 430);
            this.tabAsistencias.Controls.Add(this.panelAsistencia);

            // lblMarcarAsistencia
            this.lblMarcarAsistencia.AutoSize = true;
            this.lblMarcarAsistencia.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblMarcarAsistencia.ForeColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.lblMarcarAsistencia.Location = new System.Drawing.Point(15, 15);
            this.lblMarcarAsistencia.Text = "Marcador de Asistencia";

            // lblEmpleado
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblEmpleado.Location = new System.Drawing.Point(15, 60);
            this.lblEmpleado.Text = "Seleccione Empleado:";

            // cboEmpleado
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboEmpleado.Location = new System.Drawing.Point(15, 85);
            this.cboEmpleado.Size = new System.Drawing.Size(228, 25);

            // btnEntrada
            this.btnEntrada.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnEntrada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrada.FlatAppearance.BorderSize = 0;
            this.btnEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrada.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEntrada.ForeColor = System.Drawing.Color.White;
            this.btnEntrada.Location = new System.Drawing.Point(15, 140);
            this.btnEntrada.Size = new System.Drawing.Size(228, 40);
            this.btnEntrada.Text = "Marcar Entrada";
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);

            // btnSalida
            this.btnSalida.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnSalida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalida.FlatAppearance.BorderSize = 0;
            this.btnSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalida.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalida.ForeColor = System.Drawing.Color.White;
            this.btnSalida.Location = new System.Drawing.Point(15, 200);
            this.btnSalida.Size = new System.Drawing.Size(228, 40);
            this.btnSalida.Text = "Marcar Salida";
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);

            // panelGrid
            this.panelGrid.BackColor = System.Drawing.Color.White;
            this.panelGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrid.Controls.Add(this.lblBuscar);
            this.panelGrid.Controls.Add(this.txtBuscarAsistencia);
            this.panelGrid.Controls.Add(this.dgvAsistencia);
            this.panelGrid.Controls.Add(this.lblLogsAsistencia);
            this.panelGrid.Location = new System.Drawing.Point(280, 10);
            this.panelGrid.Size = new System.Drawing.Size(500, 430);
            this.panelGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tabAsistencias.Controls.Add(this.panelGrid);

            // lblLogsAsistencia
            this.lblLogsAsistencia.AutoSize = true;
            this.lblLogsAsistencia.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogsAsistencia.ForeColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.lblLogsAsistencia.Location = new System.Drawing.Point(15, 15);
            this.lblLogsAsistencia.Text = "Registro de Asistencia";

            // lblBuscar
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblBuscar.Location = new System.Drawing.Point(210, 18);
            this.lblBuscar.Text = "Buscar:";

            // txtBuscarAsistencia
            this.txtBuscarAsistencia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscarAsistencia.Location = new System.Drawing.Point(265, 15);
            this.txtBuscarAsistencia.Size = new System.Drawing.Size(218, 25);
            this.txtBuscarAsistencia.TextChanged += new System.EventHandler(this.txtBuscarAsistencia_TextChanged);

            // dgvAsistencia
            this.dgvAsistencia.AllowUserToAddRows = false;
            this.dgvAsistencia.AllowUserToDeleteRows = false;
            this.dgvAsistencia.BackgroundColor = System.Drawing.Color.White;
            this.dgvAsistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistencia.Location = new System.Drawing.Point(20, 55);
            this.dgvAsistencia.ReadOnly = true;
            this.dgvAsistencia.Size = new System.Drawing.Size(460, 350);
            this.dgvAsistencia.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        }

        private void InitializeContratosLayout()
        {
            // dgvContratos
            this.dgvContratos.AllowUserToAddRows = false;
            this.dgvContratos.AllowUserToDeleteRows = false;
            this.dgvContratos.BackgroundColor = System.Drawing.Color.White;
            this.dgvContratos.Location = new System.Drawing.Point(15, 15);
            this.dgvContratos.Size = new System.Drawing.Size(765, 180);
            this.dgvContratos.ReadOnly = true;
            this.dgvContratos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContratos.RowHeadersVisible = false;
            this.dgvContratos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tabContratos.Controls.Add(this.dgvContratos);

            // Panel de entrada
            System.Windows.Forms.Panel pnlInput = new System.Windows.Forms.Panel
            {
                Location = new System.Drawing.Point(15, 210),
                Size = new System.Drawing.Size(765, 225),
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                BackColor = System.Drawing.Color.FromArgb(248, 249, 250),
                Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right
            };
            this.tabContratos.Controls.Add(pnlInput);

            AddLabel(pnlInput, "Seleccionar Empleado:", 15, 15);
            this.cboEmpleadoContrato.Location = new System.Drawing.Point(15, 35);
            this.cboEmpleadoContrato.Size = new System.Drawing.Size(350, 23);
            this.cboEmpleadoContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            pnlInput.Controls.Add(this.cboEmpleadoContrato);

            AddLabel(pnlInput, "Sueldo Base (S/.):", 15, 75);
            this.txtSueldoBase.Location = new System.Drawing.Point(15, 95);
            this.txtSueldoBase.Size = new System.Drawing.Size(160, 23);
            pnlInput.Controls.Add(this.txtSueldoBase);

            AddLabel(pnlInput, "Estado del Contrato:", 205, 75);
            this.cboEstadoContrato.Location = new System.Drawing.Point(205, 95);
            this.cboEstadoContrato.Size = new System.Drawing.Size(160, 23);
            this.cboEstadoContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoContrato.Items.Add("Activo");
            this.cboEstadoContrato.Items.Add("Inactivo");
            this.cboEstadoContrato.SelectedIndex = 0;
            pnlInput.Controls.Add(this.cboEstadoContrato);

            AddLabel(pnlInput, "Fecha de Inicio:", 15, 135);
            this.dtpInicioContrato.Location = new System.Drawing.Point(15, 155);
            this.dtpInicioContrato.Size = new System.Drawing.Size(160, 23);
            this.dtpInicioContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            pnlInput.Controls.Add(this.dtpInicioContrato);

            AddLabel(pnlInput, "Fecha de Fin:", 205, 135);
            this.dtpFinContrato.Location = new System.Drawing.Point(205, 155);
            this.dtpFinContrato.Size = new System.Drawing.Size(160, 23);
            this.dtpFinContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            pnlInput.Controls.Add(this.dtpFinContrato);

            this.btnRegistrarContrato.Text = "Registrar Contrato";
            this.btnRegistrarContrato.Location = new System.Drawing.Point(410, 35);
            this.btnRegistrarContrato.Size = new System.Drawing.Size(330, 45);
            this.btnRegistrarContrato.BackColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.btnRegistrarContrato.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarContrato.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarContrato.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarContrato.FlatAppearance.BorderSize = 0;
            this.btnRegistrarContrato.Click += new System.EventHandler(this.btnRegistrarContrato_Click);
            pnlInput.Controls.Add(this.btnRegistrarContrato);
        }

        private void InitializeCapacitacionesLayout()
        {
            // dgvCapacitaciones
            this.dgvCapacitaciones.AllowUserToAddRows = false;
            this.dgvCapacitaciones.AllowUserToDeleteRows = false;
            this.dgvCapacitaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvCapacitaciones.Location = new System.Drawing.Point(15, 15);
            this.dgvCapacitaciones.Size = new System.Drawing.Size(765, 180);
            this.dgvCapacitaciones.ReadOnly = true;
            this.dgvCapacitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCapacitaciones.RowHeadersVisible = false;
            this.dgvCapacitaciones.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tabCapacitaciones.Controls.Add(this.dgvCapacitaciones);

            // Panel de entrada
            System.Windows.Forms.Panel pnlInput = new System.Windows.Forms.Panel
            {
                Location = new System.Drawing.Point(15, 210),
                Size = new System.Drawing.Size(765, 225),
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                BackColor = System.Drawing.Color.FromArgb(248, 249, 250),
                Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right
            };
            this.tabCapacitaciones.Controls.Add(pnlInput);

            AddLabel(pnlInput, "Seleccionar Empleado:", 15, 15);
            this.cboEmpleadoCapacitacion.Location = new System.Drawing.Point(15, 35);
            this.cboEmpleadoCapacitacion.Size = new System.Drawing.Size(350, 23);
            this.cboEmpleadoCapacitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            pnlInput.Controls.Add(this.cboEmpleadoCapacitacion);

            AddLabel(pnlInput, "Nombre de Capacitación:", 15, 75);
            this.txtNombreCapacitacion.Location = new System.Drawing.Point(15, 95);
            this.txtNombreCapacitacion.Size = new System.Drawing.Size(350, 23);
            pnlInput.Controls.Add(this.txtNombreCapacitacion);

            AddLabel(pnlInput, "Fecha de Capacitación:", 15, 135);
            this.dtpFechaCapacitacion.Location = new System.Drawing.Point(15, 155);
            this.dtpFechaCapacitacion.Size = new System.Drawing.Size(160, 23);
            this.dtpFechaCapacitacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            pnlInput.Controls.Add(this.dtpFechaCapacitacion);

            AddLabel(pnlInput, "Duración (Horas):", 205, 135);
            this.nudDuracionHoras.Location = new System.Drawing.Point(205, 155);
            this.nudDuracionHoras.Size = new System.Drawing.Size(160, 23);
            this.nudDuracionHoras.Minimum = 1;
            this.nudDuracionHoras.Maximum = 1000;
            this.nudDuracionHoras.Value = 8;
            pnlInput.Controls.Add(this.nudDuracionHoras);

            AddLabel(pnlInput, "Descripción de la Capacitación:", 410, 15);
            this.txtDescripcionCapacitacion.Location = new System.Drawing.Point(410, 35);
            this.txtDescripcionCapacitacion.Size = new System.Drawing.Size(330, 80);
            this.txtDescripcionCapacitacion.Multiline = true;
            pnlInput.Controls.Add(this.txtDescripcionCapacitacion);

            this.btnRegistrarCapacitacion.Text = "Registrar Capacitación";
            this.btnRegistrarCapacitacion.Location = new System.Drawing.Point(410, 135);
            this.btnRegistrarCapacitacion.Size = new System.Drawing.Size(330, 45);
            this.btnRegistrarCapacitacion.BackColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.btnRegistrarCapacitacion.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarCapacitacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarCapacitacion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarCapacitacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarCapacitacion.FlatAppearance.BorderSize = 0;
            this.btnRegistrarCapacitacion.Click += new System.EventHandler(this.btnRegistrarCapacitacion_Click);
            pnlInput.Controls.Add(this.btnRegistrarCapacitacion);
        }

        private void InitializeAreasTurnosLayout()
        {
            // Lado Izquierdo (Áreas)
            this.dgvAreas.AllowUserToAddRows = false;
            this.dgvAreas.AllowUserToDeleteRows = false;
            this.dgvAreas.BackgroundColor = System.Drawing.Color.White;
            this.dgvAreas.Location = new System.Drawing.Point(15, 15);
            this.dgvAreas.Size = new System.Drawing.Size(360, 180);
            this.dgvAreas.ReadOnly = true;
            this.dgvAreas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAreas.RowHeadersVisible = false;
            this.tabAreasTurnos.Controls.Add(this.dgvAreas);

            System.Windows.Forms.Panel pnlAreas = new System.Windows.Forms.Panel
            {
                Location = new System.Drawing.Point(15, 210),
                Size = new System.Drawing.Size(360, 225),
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                BackColor = System.Drawing.Color.FromArgb(248, 249, 250),
                Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left
            };
            this.tabAreasTurnos.Controls.Add(pnlAreas);

            AddLabel(pnlAreas, "Nombre de Área:", 15, 15);
            this.txtNombreArea.Location = new System.Drawing.Point(15, 35);
            this.txtNombreArea.Size = new System.Drawing.Size(328, 23);
            pnlAreas.Controls.Add(this.txtNombreArea);

            AddLabel(pnlAreas, "Descripción del Área:", 15, 75);
            this.txtDescripcionArea.Location = new System.Drawing.Point(15, 95);
            this.txtDescripcionArea.Size = new System.Drawing.Size(328, 50);
            this.txtDescripcionArea.Multiline = true;
            pnlAreas.Controls.Add(this.txtDescripcionArea);

            this.btnRegistrarArea.Text = "📂 Registrar Área";
            this.btnRegistrarArea.Location = new System.Drawing.Point(15, 160);
            this.btnRegistrarArea.Size = new System.Drawing.Size(328, 40);
            this.btnRegistrarArea.BackColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.btnRegistrarArea.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarArea.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarArea.FlatAppearance.BorderSize = 0;
            this.btnRegistrarArea.Click += new System.EventHandler(this.btnRegistrarArea_Click);
            pnlAreas.Controls.Add(this.btnRegistrarArea);

            // Lado Derecho (Turnos)
            this.dgvTurnos.AllowUserToAddRows = false;
            this.dgvTurnos.AllowUserToDeleteRows = false;
            this.dgvTurnos.BackgroundColor = System.Drawing.Color.White;
            this.dgvTurnos.Location = new System.Drawing.Point(395, 15);
            this.dgvTurnos.Size = new System.Drawing.Size(385, 180);
            this.dgvTurnos.ReadOnly = true;
            this.dgvTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTurnos.RowHeadersVisible = false;
            this.dgvTurnos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tabAreasTurnos.Controls.Add(this.dgvTurnos);

            System.Windows.Forms.Panel pnlTurnos = new System.Windows.Forms.Panel
            {
                Location = new System.Drawing.Point(395, 210),
                Size = new System.Drawing.Size(385, 225),
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                BackColor = System.Drawing.Color.FromArgb(248, 249, 250),
                Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right
            };
            this.tabAreasTurnos.Controls.Add(pnlTurnos);

            AddLabel(pnlTurnos, "Nombre del Turno:", 15, 15);
            this.txtNombreTurno.Location = new System.Drawing.Point(15, 35);
            this.txtNombreTurno.Size = new System.Drawing.Size(350, 23);
            pnlTurnos.Controls.Add(this.txtNombreTurno);

            AddLabel(pnlTurnos, "Hora Inicio:", 15, 75);
            this.dtpHoraInicio.Location = new System.Drawing.Point(15, 95);
            this.dtpHoraInicio.Size = new System.Drawing.Size(160, 23);
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicio.ShowUpDown = true;
            pnlTurnos.Controls.Add(this.dtpHoraInicio);

            AddLabel(pnlTurnos, "Hora Fin:", 205, 75);
            this.dtpHoraFin.Location = new System.Drawing.Point(205, 95);
            this.dtpHoraFin.Size = new System.Drawing.Size(160, 23);
            this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraFin.ShowUpDown = true;
            pnlTurnos.Controls.Add(this.dtpHoraFin);

            this.btnRegistrarTurno.Text = "Registrar Turno";
            this.btnRegistrarTurno.Location = new System.Drawing.Point(15, 160);
            this.btnRegistrarTurno.Size = new System.Drawing.Size(350, 40);
            this.btnRegistrarTurno.BackColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.btnRegistrarTurno.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarTurno.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarTurno.FlatAppearance.BorderSize = 0;
            this.btnRegistrarTurno.Click += new System.EventHandler(this.btnRegistrarTurno_Click);
            pnlTurnos.Controls.Add(this.btnRegistrarTurno);
        }

        private void AddLabel(System.Windows.Forms.Panel p, string text, int x, int y)
        {
            System.Windows.Forms.Label lbl = new System.Windows.Forms.Label
            {
                Text = text,
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(350, 18),
                Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(108, 117, 125)
            };
            p.Controls.Add(lbl);
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAsistencias;
        private System.Windows.Forms.TabPage tabContratos;
        private System.Windows.Forms.TabPage tabCapacitaciones;
        private System.Windows.Forms.TabPage tabAreasTurnos;

        private System.Windows.Forms.Panel panelAsistencia;
        private System.Windows.Forms.Label lblMarcarAsistencia;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Label lblLogsAsistencia;
        private System.Windows.Forms.ComboBox cboEmpleado;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.DataGridView dgvAsistencia;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscarAsistencia;

        private System.Windows.Forms.DataGridView dgvContratos;
        private System.Windows.Forms.ComboBox cboEmpleadoContrato;
        private System.Windows.Forms.TextBox txtSueldoBase;
        private System.Windows.Forms.DateTimePicker dtpInicioContrato;
        private System.Windows.Forms.DateTimePicker dtpFinContrato;
        private System.Windows.Forms.ComboBox cboEstadoContrato;
        private System.Windows.Forms.Button btnRegistrarContrato;

        private System.Windows.Forms.DataGridView dgvCapacitaciones;
        private System.Windows.Forms.ComboBox cboEmpleadoCapacitacion;
        private System.Windows.Forms.TextBox txtNombreCapacitacion;
        private System.Windows.Forms.TextBox txtDescripcionCapacitacion;
        private System.Windows.Forms.DateTimePicker dtpFechaCapacitacion;
        private System.Windows.Forms.NumericUpDown nudDuracionHoras;
        private System.Windows.Forms.Button btnRegistrarCapacitacion;

        private System.Windows.Forms.DataGridView dgvAreas;
        private System.Windows.Forms.TextBox txtNombreArea;
        private System.Windows.Forms.TextBox txtDescripcionArea;
        private System.Windows.Forms.Button btnRegistrarArea;

        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.TextBox txtNombreTurno;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;
        private System.Windows.Forms.Button btnRegistrarTurno;
    }
}
