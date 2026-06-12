namespace HiroPhone
{
    partial class FormSoporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelIngreso = new System.Windows.Forms.Panel();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.lblCosto = new System.Windows.Forms.Label();
            this.txtFalla = new System.Windows.Forms.TextBox();
            this.lblFalla = new System.Windows.Forms.Label();
            this.txtEquipo = new System.Windows.Forms.TextBox();
            this.lblEquipo = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblFichaIngreso = new System.Windows.Forms.Label();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.dgvReparaciones = new System.Windows.Forms.DataGridView();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.lblBuscarSoporte = new System.Windows.Forms.Label();
            this.txtBuscarSoporte = new System.Windows.Forms.TextBox();
            this.panelIngreso.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReparaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(437, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Servicio Técnico, Reparaciones y Soporte";
            // 
            // panelIngreso
            // 
            this.panelIngreso.BackColor = System.Drawing.Color.White;
            this.panelIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIngreso.Controls.Add(this.cboEstado);
            this.panelIngreso.Controls.Add(this.lblEstado);
            this.panelIngreso.Controls.Add(this.btnGuardar);
            this.panelIngreso.Controls.Add(this.txtCosto);
            this.panelIngreso.Controls.Add(this.lblCosto);
            this.panelIngreso.Controls.Add(this.txtFalla);
            this.panelIngreso.Controls.Add(this.lblFalla);
            this.panelIngreso.Controls.Add(this.txtEquipo);
            this.panelIngreso.Controls.Add(this.lblEquipo);
            this.panelIngreso.Controls.Add(this.txtCliente);
            this.panelIngreso.Controls.Add(this.lblCliente);
            this.panelIngreso.Controls.Add(this.lblFichaIngreso);
            this.panelIngreso.Location = new System.Drawing.Point(20, 60);
            this.panelIngreso.Name = "panelIngreso";
            this.panelIngreso.Size = new System.Drawing.Size(320, 490);
            this.panelIngreso.TabIndex = 1;
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(20, 345);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(278, 25);
            this.cboEstado.TabIndex = 11;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblEstado.Location = new System.Drawing.Point(20, 322);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(124, 17);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "Estado de Reparación:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(20, 410);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(278, 40);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "💾 Guardar Ficha / Diagnóstico";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtCosto
            // 
            this.txtCosto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCosto.Location = new System.Drawing.Point(20, 275);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(278, 25);
            this.txtCosto.TabIndex = 8;
            this.txtCosto.Text = "0.00";
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCosto.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblCosto.Location = new System.Drawing.Point(20, 252);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(107, 17);
            this.lblCosto.TabIndex = 7;
            this.lblCosto.Text = "Costo Estimado:";
            // 
            // txtFalla
            // 
            this.txtFalla.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFalla.Location = new System.Drawing.Point(20, 208);
            this.txtFalla.Name = "txtFalla";
            this.txtFalla.Size = new System.Drawing.Size(278, 25);
            this.txtFalla.TabIndex = 6;
            this.txtFalla.Text = "Pantalla rota por caída";
            // 
            // lblFalla
            // 
            this.lblFalla.AutoSize = true;
            this.lblFalla.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFalla.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblFalla.Location = new System.Drawing.Point(20, 185);
            this.lblFalla.Name = "lblFalla";
            this.lblFalla.Size = new System.Drawing.Size(113, 17);
            this.lblFalla.TabIndex = 5;
            this.lblFalla.Text = "Falla Reportada:";
            // 
            // txtEquipo
            // 
            this.txtEquipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEquipo.Location = new System.Drawing.Point(20, 142);
            this.txtEquipo.Name = "txtEquipo";
            this.txtEquipo.Size = new System.Drawing.Size(278, 25);
            this.txtEquipo.TabIndex = 4;
            this.txtEquipo.Text = "Samsung Galaxy S24 Ultra";
            // 
            // lblEquipo
            // 
            this.lblEquipo.AutoSize = true;
            this.lblEquipo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEquipo.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblEquipo.Location = new System.Drawing.Point(20, 119);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Size = new System.Drawing.Size(53, 17);
            this.lblEquipo.TabIndex = 3;
            this.lblEquipo.Text = "Equipo:";
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCliente.Location = new System.Drawing.Point(20, 78);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(278, 25);
            this.txtCliente.TabIndex = 2;
            this.txtCliente.Text = "María Rodríguez Casas";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblCliente.Location = new System.Drawing.Point(20, 55);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(52, 17);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblFichaIngreso
            // 
            this.lblFichaIngreso.AutoSize = true;
            this.lblFichaIngreso.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblFichaIngreso.ForeColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.lblFichaIngreso.Location = new System.Drawing.Point(15, 15);
            this.lblFichaIngreso.Name = "lblFichaIngreso";
            this.lblFichaIngreso.Size = new System.Drawing.Size(131, 21);
            this.lblFichaIngreso.TabIndex = 0;
            this.lblFichaIngreso.Text = "Ficha de Ingreso";
            // 
            // panelGrid
            // 
            this.panelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGrid.BackColor = System.Drawing.Color.White;
            this.panelGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrid.Controls.Add(this.lblBuscarSoporte);
            this.panelGrid.Controls.Add(this.txtBuscarSoporte);
            this.panelGrid.Controls.Add(this.dgvReparaciones);
            this.panelGrid.Controls.Add(this.lblHistorial);
            this.panelGrid.Location = new System.Drawing.Point(360, 60);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(460, 490);
            this.panelGrid.TabIndex = 2;
            // 
            // lblBuscarSoporte
            // 
            this.lblBuscarSoporte.AutoSize = true;
            this.lblBuscarSoporte.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblBuscarSoporte.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblBuscarSoporte.Location = new System.Drawing.Point(185, 16);
            this.lblBuscarSoporte.Name = "lblBuscarSoporte";
            this.lblBuscarSoporte.Size = new System.Drawing.Size(52, 19);
            this.lblBuscarSoporte.TabIndex = 2;
            this.lblBuscarSoporte.Text = "Buscar:";
            // 
            // txtBuscarSoporte
            // 
            this.txtBuscarSoporte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscarSoporte.Location = new System.Drawing.Point(240, 13);
            this.txtBuscarSoporte.Name = "txtBuscarSoporte";
            this.txtBuscarSoporte.Size = new System.Drawing.Size(200, 25);
            this.txtBuscarSoporte.TabIndex = 3;
            this.txtBuscarSoporte.TextChanged += new System.EventHandler(this.txtBuscarSoporte_TextChanged);
            // 
            // dgvReparaciones
            // 
            this.dgvReparaciones.AllowUserToAddRows = false;
            this.dgvReparaciones.AllowUserToDeleteRows = false;
            this.dgvReparaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReparaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvReparaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReparaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReparaciones.Location = new System.Drawing.Point(20, 50);
            this.dgvReparaciones.Name = "dgvReparaciones";
            this.dgvReparaciones.ReadOnly = true;
            this.dgvReparaciones.RowHeadersWidth = 51;
            this.dgvReparaciones.Size = new System.Drawing.Size(420, 420);
            this.dgvReparaciones.TabIndex = 1;
            this.dgvReparaciones.SelectionChanged += new System.EventHandler(this.dgvReparaciones_SelectionChanged);
            // 
            // lblHistorial
            // 
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblHistorial.ForeColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.lblHistorial.Location = new System.Drawing.Point(15, 15);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(207, 21);
            this.lblHistorial.TabIndex = 0;
            this.lblHistorial.Text = "Lista de Órdenes en Taller";
            // 
            // FormSoporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);
            this.ClientSize = new System.Drawing.Size(840, 570);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelIngreso);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSoporte";
            this.Text = "Soporte";
            this.Load += new System.EventHandler(this.FormSoporte_Load);
            this.panelIngreso.ResumeLayout(false);
            this.panelIngreso.PerformLayout();
            this.panelGrid.ResumeLayout(false);
            this.panelGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReparaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelIngreso;
        private System.Windows.Forms.Label lblFichaIngreso;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.TextBox txtFalla;
        private System.Windows.Forms.Label lblFalla;
        private System.Windows.Forms.TextBox txtEquipo;
        private System.Windows.Forms.Label lblEquipo;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvReparaciones;
        private System.Windows.Forms.Label lblBuscarSoporte;
        private System.Windows.Forms.TextBox txtBuscarSoporte;
    }
}
