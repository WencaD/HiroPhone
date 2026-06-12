namespace HiroPhone
{
    partial class FormRRHH
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
            this.panelAsistencia.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).BeginInit();
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
            // panelAsistencia
            // 
            this.panelAsistencia.BackColor = System.Drawing.Color.White;
            this.panelAsistencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAsistencia.Controls.Add(this.btnSalida);
            this.panelAsistencia.Controls.Add(this.btnEntrada);
            this.panelAsistencia.Controls.Add(this.cboEmpleado);
            this.panelAsistencia.Controls.Add(this.lblEmpleado);
            this.panelAsistencia.Controls.Add(this.lblMarcarAsistencia);
            this.panelAsistencia.Location = new System.Drawing.Point(20, 60);
            this.panelAsistencia.Name = "panelAsistencia";
            this.panelAsistencia.Size = new System.Drawing.Size(300, 490);
            this.panelAsistencia.TabIndex = 1;
            // 
            // btnSalida
            // 
            this.btnSalida.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnSalida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalida.FlatAppearance.BorderSize = 0;
            this.btnSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalida.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalida.ForeColor = System.Drawing.Color.White;
            this.btnSalida.Location = new System.Drawing.Point(20, 260);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(258, 40);
            this.btnSalida.TabIndex = 4;
            this.btnSalida.Text = "🚪 Marcar Salida";
            this.btnSalida.UseVisualStyleBackColor = false;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // btnEntrada
            // 
            this.btnEntrada.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnEntrada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrada.FlatAppearance.BorderSize = 0;
            this.btnEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrada.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEntrada.ForeColor = System.Drawing.Color.White;
            this.btnEntrada.Location = new System.Drawing.Point(20, 190);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(258, 40);
            this.btnEntrada.TabIndex = 3;
            this.btnEntrada.Text = "🕒 Marcar Entrada";
            this.btnEntrada.UseVisualStyleBackColor = false;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(20, 118);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(258, 25);
            this.cboEmpleado.TabIndex = 2;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblEmpleado.Location = new System.Drawing.Point(20, 95);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(148, 17);
            this.lblEmpleado.TabIndex = 1;
            this.lblEmpleado.Text = "Seleccione Empleado:   ";
            // 
            // lblMarcarAsistencia
            // 
            this.lblMarcarAsistencia.AutoSize = true;
            this.lblMarcarAsistencia.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblMarcarAsistencia.ForeColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.lblMarcarAsistencia.Location = new System.Drawing.Point(15, 15);
            this.lblMarcarAsistencia.Name = "lblMarcarAsistencia";
            this.lblMarcarAsistencia.Size = new System.Drawing.Size(163, 21);
            this.lblMarcarAsistencia.TabIndex = 0;
            this.lblMarcarAsistencia.Text = "Marcador de Registro";
            // 
            // panelGrid
            // 
            this.panelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGrid.BackColor = System.Drawing.Color.White;
            this.panelGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrid.Controls.Add(this.lblBuscar);
            this.panelGrid.Controls.Add(this.txtBuscarAsistencia);
            this.panelGrid.Controls.Add(this.dgvAsistencia);
            this.panelGrid.Controls.Add(this.lblLogsAsistencia);
            this.panelGrid.Location = new System.Drawing.Point(340, 60);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(480, 490);
            this.panelGrid.TabIndex = 2;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblBuscar.Location = new System.Drawing.Point(210, 16);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(52, 19);
            this.lblBuscar.TabIndex = 2;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscarAsistencia
            // 
            this.txtBuscarAsistencia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscarAsistencia.Location = new System.Drawing.Point(265, 13);
            this.txtBuscarAsistencia.Name = "txtBuscarAsistencia";
            this.txtBuscarAsistencia.Size = new System.Drawing.Size(195, 25);
            this.txtBuscarAsistencia.TabIndex = 3;
            this.txtBuscarAsistencia.TextChanged += new System.EventHandler(this.txtBuscarAsistencia_TextChanged);
            // 
            // dgvAsistencia
            // 
            this.dgvAsistencia.AllowUserToAddRows = false;
            this.dgvAsistencia.AllowUserToDeleteRows = false;
            this.dgvAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAsistencia.BackgroundColor = System.Drawing.Color.White;
            this.dgvAsistencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAsistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistencia.Location = new System.Drawing.Point(20, 50);
            this.dgvAsistencia.Name = "dgvAsistencia";
            this.dgvAsistencia.ReadOnly = true;
            this.dgvAsistencia.RowHeadersWidth = 51;
            this.dgvAsistencia.Size = new System.Drawing.Size(440, 420);
            this.dgvAsistencia.TabIndex = 1;
            // 
            // lblLogsAsistencia
            // 
            this.lblLogsAsistencia.AutoSize = true;
            this.lblLogsAsistencia.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogsAsistencia.ForeColor = System.Drawing.Color.FromArgb(24, 43, 73);
            this.lblLogsAsistencia.Location = new System.Drawing.Point(15, 15);
            this.lblLogsAsistencia.Name = "lblLogsAsistencia";
            this.lblLogsAsistencia.Size = new System.Drawing.Size(161, 21);
            this.lblLogsAsistencia.TabIndex = 0;
            this.lblLogsAsistencia.Text = "Registro de Asistencia";
            // 
            // FormRRHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);
            this.ClientSize = new System.Drawing.Size(840, 570);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelAsistencia);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRRHH";
            this.Text = "RRHH";
            this.Load += new System.EventHandler(this.FormRRHH_Load);
            this.panelAsistencia.ResumeLayout(false);
            this.panelAsistencia.PerformLayout();
            this.panelGrid.ResumeLayout(false);
            this.panelGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
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
    }
}
