namespace HiroPhone
{
    partial class FormPostventa
    {
        private System.ComponentModel.IContainer components = null;

        // Limpia los recursos que se estén utilizando
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGarantias = new System.Windows.Forms.TabPage();
            this.tabReclamos = new System.Windows.Forms.TabPage();

            this.dgvGarantias = new System.Windows.Forms.DataGridView();
            this.cboVentaDetalleGarantia = new System.Windows.Forms.ComboBox();
            this.cboTipoGarantia = new System.Windows.Forms.ComboBox();
            this.dtpInicioGarantia = new System.Windows.Forms.DateTimePicker();
            this.lblFinGarantiaCalculada = new System.Windows.Forms.Label();
            this.txtCondicionesGarantia = new System.Windows.Forms.TextBox();
            this.btnRegistrarGarantia = new System.Windows.Forms.Button();

            this.dgvReclamos = new System.Windows.Forms.DataGridView();
            this.cboClienteReclamo = new System.Windows.Forms.ComboBox();
            this.cboVentaReclamo = new System.Windows.Forms.ComboBox();
            this.txtDescripcionReclamo = new System.Windows.Forms.TextBox();
            this.cboEstadoReclamo = new System.Windows.Forms.ComboBox();
            this.btnRegistrarReclamo = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvGarantias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReclamos)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabGarantias.SuspendLayout();
            this.tabReclamos.SuspendLayout();
            this.SuspendLayout();

            // Configuración básica del Formulario
            this.Text = "Modulo de Post-Venta";
            this.Size = new System.Drawing.Size(840, 570);
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Load += new System.EventHandler(this.FormPostventa_Load);

            // Título superior
            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label
            {
                Text = "Gestión de Garantías y Reclamos",
                Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(33, 37, 41),
                Location = new System.Drawing.Point(15, 15),
                Size = new System.Drawing.Size(600, 30)
            };
            this.Controls.Add(lblTitle);

            // TabControl contenedor de pestañas
            this.tabControl.Location = new System.Drawing.Point(20, 60);
            this.tabControl.Size = new System.Drawing.Size(800, 480);
            this.tabControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.tabGarantias.Text = "Garantías";
            this.tabGarantias.BackColor = System.Drawing.Color.White;
            this.tabReclamos.Text = "Reclamos de Clientes";
            this.tabReclamos.BackColor = System.Drawing.Color.White;

            this.tabControl.TabPages.Add(this.tabGarantias);
            this.tabControl.TabPages.Add(this.tabReclamos);
            this.Controls.Add(this.tabControl);

            // Inicializa layouts de cada sección
            InitializeGarantiasLayout();
            InitializeReclamosLayout();

            ((System.ComponentModel.ISupportInitialize)(this.dgvGarantias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReclamos)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabGarantias.ResumeLayout(false);
            this.tabReclamos.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        // Inicializa la pestaña de Garantías
        private void InitializeGarantiasLayout()
        {
            this.dgvGarantias.Location = new System.Drawing.Point(15, 15);
            this.dgvGarantias.Size = new System.Drawing.Size(765, 200);
            this.dgvGarantias.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvGarantias.ReadOnly = true;
            this.dgvGarantias.AllowUserToAddRows = false;
            this.dgvGarantias.BackgroundColor = System.Drawing.Color.White;
            this.dgvGarantias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGarantias.RowHeadersVisible = false;
            this.dgvGarantias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabGarantias.Controls.Add(this.dgvGarantias);

            System.Windows.Forms.Panel pnlInput = new System.Windows.Forms.Panel
            {
                Location = new System.Drawing.Point(15, 230),
                Size = new System.Drawing.Size(765, 205),
                Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                BackColor = System.Drawing.Color.FromArgb(248, 249, 250)
            };
            this.tabGarantias.Controls.Add(pnlInput);

            AddLabel(pnlInput, "Seleccionar Producto Vendido (Detalle Venta):", 15, 10);
            this.cboVentaDetalleGarantia = AddComboBox(pnlInput, 15, 30, 350);

            AddLabel(pnlInput, "Tipo de Garantía:", 15, 70);
            this.cboTipoGarantia = AddComboBox(pnlInput, 15, 90, 200);
            this.cboTipoGarantia.SelectedIndexChanged += new System.EventHandler(this.cboTipoGarantia_SelectedIndexChanged);

            AddLabel(pnlInput, "Fecha de Inicio:", 230, 70);
            this.dtpInicioGarantia.Location = new System.Drawing.Point(230, 90);
            this.dtpInicioGarantia.Size = new System.Drawing.Size(135, 23);
            this.dtpInicioGarantia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicioGarantia.ValueChanged += new System.EventHandler(this.dtpInicioGarantia_ValueChanged);
            pnlInput.Controls.Add(this.dtpInicioGarantia);

            this.lblFinGarantiaCalculada.Location = new System.Drawing.Point(15, 130);
            this.lblFinGarantiaCalculada.Size = new System.Drawing.Size(350, 20);
            this.lblFinGarantiaCalculada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFinGarantiaCalculada.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            pnlInput.Controls.Add(this.lblFinGarantiaCalculada);

            AddLabel(pnlInput, "Condiciones de Garantía / Cobertura:", 400, 10);
            this.txtCondicionesGarantia.Location = new System.Drawing.Point(400, 30);
            this.txtCondicionesGarantia.Size = new System.Drawing.Size(345, 80);
            this.txtCondicionesGarantia.Multiline = true;
            pnlInput.Controls.Add(this.txtCondicionesGarantia);

            this.btnRegistrarGarantia.Text = "Registrar Nueva Garantía";
            this.btnRegistrarGarantia.Location = new System.Drawing.Point(400, 130);
            this.btnRegistrarGarantia.Size = new System.Drawing.Size(345, 40);
            this.btnRegistrarGarantia.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnRegistrarGarantia.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarGarantia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarGarantia.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarGarantia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarGarantia.FlatAppearance.BorderSize = 0;
            this.btnRegistrarGarantia.Click += new System.EventHandler(this.btnRegistrarGarantia_Click);
            pnlInput.Controls.Add(this.btnRegistrarGarantia);
        }

        // Inicializa la pestaña de Reclamos
        private void InitializeReclamosLayout()
        {
            this.dgvReclamos.Location = new System.Drawing.Point(15, 15);
            this.dgvReclamos.Size = new System.Drawing.Size(765, 200);
            this.dgvReclamos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvReclamos.ReadOnly = true;
            this.dgvReclamos.AllowUserToAddRows = false;
            this.dgvReclamos.BackgroundColor = System.Drawing.Color.White;
            this.dgvReclamos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReclamos.RowHeadersVisible = false;
            this.dgvReclamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabReclamos.Controls.Add(this.dgvReclamos);

            System.Windows.Forms.Panel pnlInput = new System.Windows.Forms.Panel
            {
                Location = new System.Drawing.Point(15, 230),
                Size = new System.Drawing.Size(765, 205),
                Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                BackColor = System.Drawing.Color.FromArgb(248, 249, 250)
            };
            this.tabReclamos.Controls.Add(pnlInput);

            AddLabel(pnlInput, "Seleccionar Cliente:", 15, 10);
            this.cboClienteReclamo = AddComboBox(pnlInput, 15, 30, 200);
            this.cboClienteReclamo.SelectedIndexChanged += new System.EventHandler(this.cboClienteReclamo_SelectedIndexChanged);

            AddLabel(pnlInput, "Boleta/Factura Vinculada:", 15, 70);
            this.cboVentaReclamo = AddComboBox(pnlInput, 15, 90, 200);

            AddLabel(pnlInput, "Estado del Reclamo:", 230, 70);
            this.cboEstadoReclamo = AddComboBox(pnlInput, 230, 90, 135);
            this.cboEstadoReclamo.Items.Add("En Proceso");
            this.cboEstadoReclamo.Items.Add("Resuelto");
            this.cboEstadoReclamo.Items.Add("Cerrado");
            this.cboEstadoReclamo.SelectedIndex = 0;

            AddLabel(pnlInput, "Descripción del Reclamo / Problema:", 400, 10);
            this.txtDescripcionReclamo.Location = new System.Drawing.Point(400, 30);
            this.txtDescripcionReclamo.Size = new System.Drawing.Size(345, 80);
            this.txtDescripcionReclamo.Multiline = true;
            pnlInput.Controls.Add(this.txtDescripcionReclamo);

            this.btnRegistrarReclamo.Text = "Registrar Reclamo";
            this.btnRegistrarReclamo.Location = new System.Drawing.Point(400, 130);
            this.btnRegistrarReclamo.Size = new System.Drawing.Size(345, 40);
            this.btnRegistrarReclamo.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnRegistrarReclamo.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarReclamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarReclamo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarReclamo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarReclamo.FlatAppearance.BorderSize = 0;
            this.btnRegistrarReclamo.Click += new System.EventHandler(this.btnRegistrarReclamo_Click);
            pnlInput.Controls.Add(this.btnRegistrarReclamo);
        }

        // Agrega una etiqueta descriptiva al panel
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

        // Agrega un ComboBox de selección al panel
        private System.Windows.Forms.ComboBox AddComboBox(System.Windows.Forms.Panel p, int x, int y, int w)
        {
            System.Windows.Forms.ComboBox cbo = new System.Windows.Forms.ComboBox
            {
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(w, 23),
                DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            };
            p.Controls.Add(cbo);
            return cbo;
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGarantias;
        private System.Windows.Forms.TabPage tabReclamos;

        private System.Windows.Forms.DataGridView dgvGarantias;
        private System.Windows.Forms.ComboBox cboVentaDetalleGarantia;
        private System.Windows.Forms.ComboBox cboTipoGarantia;
        private System.Windows.Forms.DateTimePicker dtpInicioGarantia;
        private System.Windows.Forms.Label lblFinGarantiaCalculada;
        private System.Windows.Forms.TextBox txtCondicionesGarantia;
        private System.Windows.Forms.Button btnRegistrarGarantia;

        private System.Windows.Forms.DataGridView dgvReclamos;
        private System.Windows.Forms.ComboBox cboClienteReclamo;
        private System.Windows.Forms.ComboBox cboVentaReclamo;
        private System.Windows.Forms.TextBox txtDescripcionReclamo;
        private System.Windows.Forms.ComboBox cboEstadoReclamo;
        private System.Windows.Forms.Button btnRegistrarReclamo;
    }
}
