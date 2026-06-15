namespace HiroPhone
{
    partial class FormCierreCajaDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHeaderMetodo;
        private System.Windows.Forms.Label lblHeaderSistema;
        private System.Windows.Forms.Label lblHeaderFisico;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.Label lblSysEfectivo;
        private System.Windows.Forms.TextBox txtFisicoEfectivo;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.Label lblSysTarjeta;
        private System.Windows.Forms.TextBox txtFisicoTarjeta;
        private System.Windows.Forms.Label lblTransf;
        private System.Windows.Forms.Label lblSysTransf;
        private System.Windows.Forms.TextBox txtFisicoTransf;
        private System.Windows.Forms.Panel line;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalSistema;
        private System.Windows.Forms.Label lblTotalFisico;
        private System.Windows.Forms.Label lblDiferenciaLabel;
        private System.Windows.Forms.Label lblDiferencia;
        private System.Windows.Forms.Button btnConfirmar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblHeaderMetodo = new System.Windows.Forms.Label();
            this.lblHeaderSistema = new System.Windows.Forms.Label();
            this.lblHeaderFisico = new System.Windows.Forms.Label();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.lblSysEfectivo = new System.Windows.Forms.Label();
            this.txtFisicoEfectivo = new System.Windows.Forms.TextBox();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.lblSysTarjeta = new System.Windows.Forms.Label();
            this.txtFisicoTarjeta = new System.Windows.Forms.TextBox();
            this.lblTransf = new System.Windows.Forms.Label();
            this.lblSysTransf = new System.Windows.Forms.Label();
            this.txtFisicoTransf = new System.Windows.Forms.TextBox();
            this.line = new System.Windows.Forms.Panel();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalSistema = new System.Windows.Forms.Label();
            this.lblTotalFisico = new System.Windows.Forms.Label();
            this.lblDiferenciaLabel = new System.Windows.Forms.Label();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(201, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cierre de Caja Diario";
            // 
            // lblHeaderMetodo
            // 
            this.lblHeaderMetodo.AutoSize = true;
            this.lblHeaderMetodo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderMetodo.Location = new System.Drawing.Point(25, 65);
            this.lblHeaderMetodo.Name = "lblHeaderMetodo";
            this.lblHeaderMetodo.Size = new System.Drawing.Size(56, 17);
            this.lblHeaderMetodo.TabIndex = 1;
            this.lblHeaderMetodo.Text = "Método";
            // 
            // lblHeaderSistema
            // 
            this.lblHeaderSistema.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderSistema.Location = new System.Drawing.Point(165, 65);
            this.lblHeaderSistema.Name = "lblHeaderSistema";
            this.lblHeaderSistema.Size = new System.Drawing.Size(110, 20);
            this.lblHeaderSistema.TabIndex = 2;
            this.lblHeaderSistema.Text = "Sistema (S/.)";
            this.lblHeaderSistema.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblHeaderFisico
            // 
            this.lblHeaderFisico.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderFisico.Location = new System.Drawing.Point(295, 65);
            this.lblHeaderFisico.Name = "lblHeaderFisico";
            this.lblHeaderFisico.Size = new System.Drawing.Size(110, 20);
            this.lblHeaderFisico.TabIndex = 3;
            this.lblHeaderFisico.Text = "Físico (S/.)";
            this.lblHeaderFisico.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.Location = new System.Drawing.Point(25, 100);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(130, 25);
            this.lblEfectivo.TabIndex = 4;
            this.lblEfectivo.Text = "Efectivo:";
            this.lblEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSysEfectivo
            // 
            this.lblSysEfectivo.Location = new System.Drawing.Point(165, 100);
            this.lblSysEfectivo.Name = "lblSysEfectivo";
            this.lblSysEfectivo.Size = new System.Drawing.Size(110, 25);
            this.lblSysEfectivo.TabIndex = 5;
            this.lblSysEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFisicoEfectivo
            // 
            this.txtFisicoEfectivo.Location = new System.Drawing.Point(295, 100);
            this.txtFisicoEfectivo.Name = "txtFisicoEfectivo";
            this.txtFisicoEfectivo.Size = new System.Drawing.Size(110, 23);
            this.txtFisicoEfectivo.TabIndex = 6;
            this.txtFisicoEfectivo.Text = "0.00";
            this.txtFisicoEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFisicoEfectivo.TextChanged += new System.EventHandler(this.txtFisicoEfectivo_TextChanged);
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.Location = new System.Drawing.Point(25, 140);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(130, 25);
            this.lblTarjeta.TabIndex = 7;
            this.lblTarjeta.Text = "Tarjetas:";
            this.lblTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSysTarjeta
            // 
            this.lblSysTarjeta.Location = new System.Drawing.Point(165, 140);
            this.lblSysTarjeta.Name = "lblSysTarjeta";
            this.lblSysTarjeta.Size = new System.Drawing.Size(110, 25);
            this.lblSysTarjeta.TabIndex = 8;
            this.lblSysTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFisicoTarjeta
            // 
            this.txtFisicoTarjeta.Location = new System.Drawing.Point(295, 140);
            this.txtFisicoTarjeta.Name = "txtFisicoTarjeta";
            this.txtFisicoTarjeta.Size = new System.Drawing.Size(110, 23);
            this.txtFisicoTarjeta.TabIndex = 9;
            this.txtFisicoTarjeta.Text = "0.00";
            this.txtFisicoTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFisicoTarjeta.TextChanged += new System.EventHandler(this.txtFisicoTarjeta_TextChanged);
            // 
            // lblTransf
            // 
            this.lblTransf.Location = new System.Drawing.Point(25, 180);
            this.lblTransf.Name = "lblTransf";
            this.lblTransf.Size = new System.Drawing.Size(130, 25);
            this.lblTransf.TabIndex = 10;
            this.lblTransf.Text = "Yape / Plin:";
            this.lblTransf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSysTransf
            // 
            this.lblSysTransf.Location = new System.Drawing.Point(165, 180);
            this.lblSysTransf.Name = "lblSysTransf";
            this.lblSysTransf.Size = new System.Drawing.Size(110, 25);
            this.lblSysTransf.TabIndex = 11;
            this.lblSysTransf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFisicoTransf
            // 
            this.txtFisicoTransf.Location = new System.Drawing.Point(295, 180);
            this.txtFisicoTransf.Name = "txtFisicoTransf";
            this.txtFisicoTransf.Size = new System.Drawing.Size(110, 23);
            this.txtFisicoTransf.TabIndex = 12;
            this.txtFisicoTransf.Text = "0.00";
            this.txtFisicoTransf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFisicoTransf.TextChanged += new System.EventHandler(this.txtFisicoTransf_TextChanged);
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(224)))), ((int)(((byte)(230)))));
            this.line.Location = new System.Drawing.Point(25, 225);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(380, 2);
            this.line.TabIndex = 13;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.Location = new System.Drawing.Point(25, 240);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(130, 25);
            this.lblTotalLabel.TabIndex = 14;
            this.lblTotalLabel.Text = "Total General:";
            this.lblTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalSistema
            // 
            this.lblTotalSistema.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalSistema.Location = new System.Drawing.Point(165, 240);
            this.lblTotalSistema.Name = "lblTotalSistema";
            this.lblTotalSistema.Size = new System.Drawing.Size(110, 25);
            this.lblTotalSistema.TabIndex = 15;
            this.lblTotalSistema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalFisico
            // 
            this.lblTotalFisico.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalFisico.Location = new System.Drawing.Point(295, 240);
            this.lblTotalFisico.Name = "lblTotalFisico";
            this.lblTotalFisico.Size = new System.Drawing.Size(110, 25);
            this.lblTotalFisico.TabIndex = 16;
            this.lblTotalFisico.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiferenciaLabel
            // 
            this.lblDiferenciaLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDiferenciaLabel.Location = new System.Drawing.Point(25, 280);
            this.lblDiferenciaLabel.Name = "lblDiferenciaLabel";
            this.lblDiferenciaLabel.Size = new System.Drawing.Size(130, 25);
            this.lblDiferenciaLabel.TabIndex = 17;
            this.lblDiferenciaLabel.Text = "Diferencia (Arqueo):";
            this.lblDiferenciaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiferencia.Location = new System.Drawing.Point(295, 280);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(110, 25);
            this.lblDiferencia.TabIndex = 18;
            this.lblDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(25, 350);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(380, 45);
            this.btnConfirmar.TabIndex = 19;
            this.btnConfirmar.Text = "Confirmar y Registrar Cierre";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // FormCierreCajaDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(434, 431);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblDiferencia);
            this.Controls.Add(this.lblDiferenciaLabel);
            this.Controls.Add(this.lblTotalFisico);
            this.Controls.Add(this.lblTotalSistema);
            this.Controls.Add(this.lblTotalLabel);
            this.Controls.Add(this.line);
            this.Controls.Add(this.txtFisicoTransf);
            this.Controls.Add(this.lblSysTransf);
            this.Controls.Add(this.lblTransf);
            this.Controls.Add(this.txtFisicoTarjeta);
            this.Controls.Add(this.lblSysTarjeta);
            this.Controls.Add(this.lblTarjeta);
            this.Controls.Add(this.txtFisicoEfectivo);
            this.Controls.Add(this.lblSysEfectivo);
            this.Controls.Add(this.lblEfectivo);
            this.Controls.Add(this.lblHeaderFisico);
            this.Controls.Add(this.lblHeaderSistema);
            this.Controls.Add(this.lblHeaderMetodo);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCierreCajaDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Arqueo y Cierre de Caja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
