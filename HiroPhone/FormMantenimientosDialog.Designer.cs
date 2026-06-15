namespace HiroPhone
{
    partial class FormMantenimientosDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMarcas;
        private System.Windows.Forms.TabPage tabProveedores;
        private System.Windows.Forms.TabPage tabCategorias;
        private System.Windows.Forms.TabPage tabLineas;

        // Brand controls
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.Panel pnlMarcas;
        private System.Windows.Forms.Label lblNombreMarca;
        private System.Windows.Forms.TextBox txtNombreMarca;
        private System.Windows.Forms.Label lblOrigenMarca;
        private System.Windows.Forms.TextBox txtOrigenMarca;
        private System.Windows.Forms.Button btnRegistrarMarca;

        // Provider controls
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.Panel pnlProveedores;
        private System.Windows.Forms.Label lblNombreProv;
        private System.Windows.Forms.TextBox txtNombreProv;
        private System.Windows.Forms.Label lblRucProv;
        private System.Windows.Forms.TextBox txtRucProv;
        private System.Windows.Forms.Label lblTelefonoProv;
        private System.Windows.Forms.TextBox txtTelefonoProv;
        private System.Windows.Forms.Label lblCorreoProv;
        private System.Windows.Forms.TextBox txtCorreoProv;
        private System.Windows.Forms.Label lblDireccionProv;
        private System.Windows.Forms.TextBox txtDireccionProv;
        private System.Windows.Forms.Button btnRegistrarProveedor;

        // Category controls
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.Panel pnlCategorias;
        private System.Windows.Forms.Label lblNombreCategoria;
        private System.Windows.Forms.TextBox txtNombreCategoria;
        private System.Windows.Forms.Label lblDescripcionCategoria;
        private System.Windows.Forms.TextBox txtDescripcionCategoria;
        private System.Windows.Forms.Button btnRegistrarCategoria;

        // Line controls
        private System.Windows.Forms.DataGridView dgvLineas;
        private System.Windows.Forms.Panel pnlLineas;
        private System.Windows.Forms.Label lblNombreLinea;
        private System.Windows.Forms.TextBox txtNombreLinea;
        private System.Windows.Forms.Label lblDescripcionLinea;
        private System.Windows.Forms.TextBox txtDescripcionLinea;
        private System.Windows.Forms.Button btnRegistrarLinea;

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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMarcas = new System.Windows.Forms.TabPage();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.pnlMarcas = new System.Windows.Forms.Panel();
            this.btnRegistrarMarca = new System.Windows.Forms.Button();
            this.txtOrigenMarca = new System.Windows.Forms.TextBox();
            this.lblOrigenMarca = new System.Windows.Forms.Label();
            this.txtNombreMarca = new System.Windows.Forms.TextBox();
            this.lblNombreMarca = new System.Windows.Forms.Label();
            this.tabProveedores = new System.Windows.Forms.TabPage();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.pnlProveedores = new System.Windows.Forms.Panel();
            this.btnRegistrarProveedor = new System.Windows.Forms.Button();
            this.txtDireccionProv = new System.Windows.Forms.TextBox();
            this.lblDireccionProv = new System.Windows.Forms.Label();
            this.txtCorreoProv = new System.Windows.Forms.TextBox();
            this.lblCorreoProv = new System.Windows.Forms.Label();
            this.txtTelefonoProv = new System.Windows.Forms.TextBox();
            this.lblTelefonoProv = new System.Windows.Forms.Label();
            this.txtRucProv = new System.Windows.Forms.TextBox();
            this.lblRucProv = new System.Windows.Forms.Label();
            this.txtNombreProv = new System.Windows.Forms.TextBox();
            this.lblNombreProv = new System.Windows.Forms.Label();
            this.tabCategorias = new System.Windows.Forms.TabPage();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.pnlCategorias = new System.Windows.Forms.Panel();
            this.btnRegistrarCategoria = new System.Windows.Forms.Button();
            this.txtDescripcionCategoria = new System.Windows.Forms.TextBox();
            this.lblDescripcionCategoria = new System.Windows.Forms.Label();
            this.txtNombreCategoria = new System.Windows.Forms.TextBox();
            this.lblNombreCategoria = new System.Windows.Forms.Label();
            this.tabLineas = new System.Windows.Forms.TabPage();
            this.dgvLineas = new System.Windows.Forms.DataGridView();
            this.pnlLineas = new System.Windows.Forms.Panel();
            this.btnRegistrarLinea = new System.Windows.Forms.Button();
            this.txtDescripcionLinea = new System.Windows.Forms.TextBox();
            this.lblDescripcionLinea = new System.Windows.Forms.Label();
            this.txtNombreLinea = new System.Windows.Forms.TextBox();
            this.lblNombreLinea = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabMarcas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.pnlMarcas.SuspendLayout();
            this.tabProveedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.pnlProveedores.SuspendLayout();
            this.tabCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.pnlCategorias.SuspendLayout();
            this.tabLineas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineas)).BeginInit();
            this.pnlLineas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMarcas);
            this.tabControl.Controls.Add(this.tabProveedores);
            this.tabControl.Controls.Add(this.tabCategorias);
            this.tabControl.Controls.Add(this.tabLineas);
            this.tabControl.Location = new System.Drawing.Point(15, 15);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(600, 430);
            this.tabControl.TabIndex = 0;
            // 
            // tabMarcas
            // 
            this.tabMarcas.Controls.Add(this.dgvMarcas);
            this.tabMarcas.Controls.Add(this.pnlMarcas);
            this.tabMarcas.Location = new System.Drawing.Point(4, 24);
            this.tabMarcas.Name = "tabMarcas";
            this.tabMarcas.Padding = new System.Windows.Forms.Padding(3);
            this.tabMarcas.Size = new System.Drawing.Size(592, 402);
            this.tabMarcas.TabIndex = 0;
            this.tabMarcas.Text = "Marcas";
            this.tabMarcas.UseVisualStyleBackColor = true;
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AllowUserToAddRows = false;
            this.dgvMarcas.AllowUserToDeleteRows = false;
            this.dgvMarcas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMarcas.BackgroundColor = System.Drawing.Color.White;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Location = new System.Drawing.Point(15, 15);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.ReadOnly = true;
            this.dgvMarcas.RowHeadersVisible = false;
            this.dgvMarcas.Size = new System.Drawing.Size(560, 180);
            this.dgvMarcas.TabIndex = 0;
            // 
            // pnlMarcas
            // 
            this.pnlMarcas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlMarcas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMarcas.Controls.Add(this.btnRegistrarMarca);
            this.pnlMarcas.Controls.Add(this.txtOrigenMarca);
            this.pnlMarcas.Controls.Add(this.lblOrigenMarca);
            this.pnlMarcas.Controls.Add(this.txtNombreMarca);
            this.pnlMarcas.Controls.Add(this.lblNombreMarca);
            this.pnlMarcas.Location = new System.Drawing.Point(15, 210);
            this.pnlMarcas.Name = "pnlMarcas";
            this.pnlMarcas.Size = new System.Drawing.Size(560, 160);
            this.pnlMarcas.TabIndex = 1;
            // 
            // btnRegistrarMarca
            // 
            this.btnRegistrarMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.btnRegistrarMarca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarMarca.FlatAppearance.BorderSize = 0;
            this.btnRegistrarMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarMarca.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarMarca.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarMarca.Location = new System.Drawing.Point(285, 35);
            this.btnRegistrarMarca.Name = "btnRegistrarMarca";
            this.btnRegistrarMarca.Size = new System.Drawing.Size(250, 83);
            this.btnRegistrarMarca.TabIndex = 4;
            this.btnRegistrarMarca.Text = "Registrar Marca";
            this.btnRegistrarMarca.UseVisualStyleBackColor = false;
            this.btnRegistrarMarca.Click += new System.EventHandler(this.btnRegistrarMarca_Click);
            // 
            // txtOrigenMarca
            // 
            this.txtOrigenMarca.Location = new System.Drawing.Point(15, 95);
            this.txtOrigenMarca.Name = "txtOrigenMarca";
            this.txtOrigenMarca.Size = new System.Drawing.Size(240, 23);
            this.txtOrigenMarca.TabIndex = 3;
            // 
            // lblOrigenMarca
            // 
            this.lblOrigenMarca.AutoSize = true;
            this.lblOrigenMarca.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblOrigenMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblOrigenMarca.Location = new System.Drawing.Point(15, 75);
            this.lblOrigenMarca.Name = "lblOrigenMarca";
            this.lblOrigenMarca.Size = new System.Drawing.Size(110, 15);
            this.lblOrigenMarca.TabIndex = 2;
            this.lblOrigenMarca.Text = "Origen de la Marca:";
            // 
            // txtNombreMarca
            // 
            this.txtNombreMarca.Location = new System.Drawing.Point(15, 35);
            this.txtNombreMarca.Name = "txtNombreMarca";
            this.txtNombreMarca.Size = new System.Drawing.Size(240, 23);
            this.txtNombreMarca.TabIndex = 1;
            // 
            // lblNombreMarca
            // 
            this.lblNombreMarca.AutoSize = true;
            this.lblNombreMarca.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNombreMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblNombreMarca.Location = new System.Drawing.Point(15, 15);
            this.lblNombreMarca.Name = "lblNombreMarca";
            this.lblNombreMarca.Size = new System.Drawing.Size(106, 15);
            this.lblNombreMarca.TabIndex = 0;
            this.lblNombreMarca.Text = "Nombre de Marca:";
            // 
            // tabProveedores
            // 
            this.tabProveedores.Controls.Add(this.dgvProveedores);
            this.tabProveedores.Controls.Add(this.pnlProveedores);
            this.tabProveedores.Location = new System.Drawing.Point(4, 24);
            this.tabProveedores.Name = "tabProveedores";
            this.tabProveedores.Padding = new System.Windows.Forms.Padding(3);
            this.tabProveedores.Size = new System.Drawing.Size(592, 402);
            this.tabProveedores.TabIndex = 1;
            this.tabProveedores.Text = "Proveedores";
            this.tabProveedores.UseVisualStyleBackColor = true;
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.AllowUserToAddRows = false;
            this.dgvProveedores.AllowUserToDeleteRows = false;
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.BackgroundColor = System.Drawing.Color.White;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Location = new System.Drawing.Point(15, 15);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.RowHeadersVisible = false;
            this.dgvProveedores.Size = new System.Drawing.Size(560, 180);
            this.dgvProveedores.TabIndex = 0;
            // 
            // pnlProveedores
            // 
            this.pnlProveedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlProveedores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProveedores.Controls.Add(this.btnRegistrarProveedor);
            this.pnlProveedores.Controls.Add(this.txtDireccionProv);
            this.pnlProveedores.Controls.Add(this.lblDireccionProv);
            this.pnlProveedores.Controls.Add(this.txtCorreoProv);
            this.pnlProveedores.Controls.Add(this.lblCorreoProv);
            this.pnlProveedores.Controls.Add(this.txtTelefonoProv);
            this.pnlProveedores.Controls.Add(this.lblTelefonoProv);
            this.pnlProveedores.Controls.Add(this.txtRucProv);
            this.pnlProveedores.Controls.Add(this.lblRucProv);
            this.pnlProveedores.Controls.Add(this.txtNombreProv);
            this.pnlProveedores.Controls.Add(this.lblNombreProv);
            this.pnlProveedores.Location = new System.Drawing.Point(15, 210);
            this.pnlProveedores.Name = "pnlProveedores";
            this.pnlProveedores.Size = new System.Drawing.Size(560, 160);
            this.pnlProveedores.TabIndex = 1;
            // 
            // btnRegistrarProveedor
            // 
            this.btnRegistrarProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.btnRegistrarProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarProveedor.FlatAppearance.BorderSize = 0;
            this.btnRegistrarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarProveedor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarProveedor.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarProveedor.Location = new System.Drawing.Point(285, 120);
            this.btnRegistrarProveedor.Name = "btnRegistrarProveedor";
            this.btnRegistrarProveedor.Size = new System.Drawing.Size(250, 30);
            this.btnRegistrarProveedor.TabIndex = 10;
            this.btnRegistrarProveedor.Text = "Registrar Proveedor";
            this.btnRegistrarProveedor.UseVisualStyleBackColor = false;
            this.btnRegistrarProveedor.Click += new System.EventHandler(this.btnRegistrarProveedor_Click);
            // 
            // txtDireccionProv
            // 
            this.txtDireccionProv.Location = new System.Drawing.Point(285, 80);
            this.txtDireccionProv.Name = "txtDireccionProv";
            this.txtDireccionProv.Size = new System.Drawing.Size(250, 23);
            this.txtDireccionProv.TabIndex = 9;
            // 
            // lblDireccionProv
            // 
            this.lblDireccionProv.AutoSize = true;
            this.lblDireccionProv.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDireccionProv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblDireccionProv.Location = new System.Drawing.Point(285, 60);
            this.lblDireccionProv.Name = "lblDireccionProv";
            this.lblDireccionProv.Size = new System.Drawing.Size(61, 15);
            this.lblDireccionProv.TabIndex = 8;
            this.lblDireccionProv.Text = "Dirección:";
            // 
            // txtCorreoProv
            // 
            this.txtCorreoProv.Location = new System.Drawing.Point(285, 30);
            this.txtCorreoProv.Name = "txtCorreoProv";
            this.txtCorreoProv.Size = new System.Drawing.Size(250, 23);
            this.txtCorreoProv.TabIndex = 7;
            // 
            // lblCorreoProv
            // 
            this.lblCorreoProv.AutoSize = true;
            this.lblCorreoProv.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCorreoProv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblCorreoProv.Location = new System.Drawing.Point(285, 10);
            this.lblCorreoProv.Name = "lblCorreoProv";
            this.lblCorreoProv.Size = new System.Drawing.Size(45, 15);
            this.lblCorreoProv.TabIndex = 6;
            this.lblCorreoProv.Text = "Correo:";
            // 
            // txtTelefonoProv
            // 
            this.txtTelefonoProv.Location = new System.Drawing.Point(15, 130);
            this.txtTelefonoProv.Name = "txtTelefonoProv";
            this.txtTelefonoProv.Size = new System.Drawing.Size(240, 23);
            this.txtTelefonoProv.TabIndex = 5;
            // 
            // lblTelefonoProv
            // 
            this.lblTelefonoProv.AutoSize = true;
            this.lblTelefonoProv.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTelefonoProv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblTelefonoProv.Location = new System.Drawing.Point(15, 110);
            this.lblTelefonoProv.Name = "lblTelefonoProv";
            this.lblTelefonoProv.Size = new System.Drawing.Size(56, 15);
            this.lblTelefonoProv.TabIndex = 4;
            this.lblTelefonoProv.Text = "Teléfono:";
            // 
            // txtRucProv
            // 
            this.txtRucProv.Location = new System.Drawing.Point(15, 80);
            this.txtRucProv.Name = "txtRucProv";
            this.txtRucProv.Size = new System.Drawing.Size(240, 23);
            this.txtRucProv.TabIndex = 3;
            // 
            // lblRucProv
            // 
            this.lblRucProv.AutoSize = true;
            this.lblRucProv.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRucProv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblRucProv.Location = new System.Drawing.Point(15, 60);
            this.lblRucProv.Name = "lblRucProv";
            this.lblRucProv.Size = new System.Drawing.Size(32, 15);
            this.lblRucProv.TabIndex = 2;
            this.lblRucProv.Text = "RUC:";
            // 
            // txtNombreProv
            // 
            this.txtNombreProv.Location = new System.Drawing.Point(15, 30);
            this.txtNombreProv.Name = "txtNombreProv";
            this.txtNombreProv.Size = new System.Drawing.Size(240, 23);
            this.txtNombreProv.TabIndex = 1;
            // 
            // lblNombreProv
            // 
            this.lblNombreProv.AutoSize = true;
            this.lblNombreProv.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNombreProv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblNombreProv.Location = new System.Drawing.Point(15, 10);
            this.lblNombreProv.Name = "lblNombreProv";
            this.lblNombreProv.Size = new System.Drawing.Size(111, 15);
            this.lblNombreProv.TabIndex = 0;
            this.lblNombreProv.Text = "Nombre Proveedor:";
            // 
            // tabCategorias
            // 
            this.tabCategorias.Controls.Add(this.dgvCategorias);
            this.tabCategorias.Controls.Add(this.pnlCategorias);
            this.tabCategorias.Location = new System.Drawing.Point(4, 24);
            this.tabCategorias.Name = "tabCategorias";
            this.tabCategorias.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategorias.Size = new System.Drawing.Size(592, 402);
            this.tabCategorias.TabIndex = 2;
            this.tabCategorias.Text = "Categorías";
            this.tabCategorias.UseVisualStyleBackColor = true;
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.AllowUserToAddRows = false;
            this.dgvCategorias.AllowUserToDeleteRows = false;
            this.dgvCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategorias.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Location = new System.Drawing.Point(15, 15);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.ReadOnly = true;
            this.dgvCategorias.RowHeadersVisible = false;
            this.dgvCategorias.Size = new System.Drawing.Size(560, 180);
            this.dgvCategorias.TabIndex = 0;
            // 
            // pnlCategorias
            // 
            this.pnlCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlCategorias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCategorias.Controls.Add(this.btnRegistrarCategoria);
            this.pnlCategorias.Controls.Add(this.txtDescripcionCategoria);
            this.pnlCategorias.Controls.Add(this.lblDescripcionCategoria);
            this.pnlCategorias.Controls.Add(this.txtNombreCategoria);
            this.pnlCategorias.Controls.Add(this.lblNombreCategoria);
            this.pnlCategorias.Location = new System.Drawing.Point(15, 210);
            this.pnlCategorias.Name = "pnlCategorias";
            this.pnlCategorias.Size = new System.Drawing.Size(560, 160);
            this.pnlCategorias.TabIndex = 1;
            // 
            // btnRegistrarCategoria
            // 
            this.btnRegistrarCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.btnRegistrarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarCategoria.FlatAppearance.BorderSize = 0;
            this.btnRegistrarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarCategoria.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarCategoria.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarCategoria.Location = new System.Drawing.Point(285, 35);
            this.btnRegistrarCategoria.Name = "btnRegistrarCategoria";
            this.btnRegistrarCategoria.Size = new System.Drawing.Size(250, 83);
            this.btnRegistrarCategoria.TabIndex = 4;
            this.btnRegistrarCategoria.Text = "Registrar Categoría";
            this.btnRegistrarCategoria.UseVisualStyleBackColor = false;
            this.btnRegistrarCategoria.Click += new System.EventHandler(this.btnRegistrarCategoria_Click);
            // 
            // txtDescripcionCategoria
            // 
            this.txtDescripcionCategoria.Location = new System.Drawing.Point(15, 95);
            this.txtDescripcionCategoria.Name = "txtDescripcionCategoria";
            this.txtDescripcionCategoria.Size = new System.Drawing.Size(240, 23);
            this.txtDescripcionCategoria.TabIndex = 3;
            // 
            // lblDescripcionCategoria
            // 
            this.lblDescripcionCategoria.AutoSize = true;
            this.lblDescripcionCategoria.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDescripcionCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblDescripcionCategoria.Location = new System.Drawing.Point(15, 75);
            this.lblDescripcionCategoria.Name = "lblDescripcionCategoria";
            this.lblDescripcionCategoria.Size = new System.Drawing.Size(73, 15);
            this.lblDescripcionCategoria.TabIndex = 2;
            this.lblDescripcionCategoria.Text = "Descripción:";
            // 
            // txtNombreCategoria
            // 
            this.txtNombreCategoria.Location = new System.Drawing.Point(15, 35);
            this.txtNombreCategoria.Name = "txtNombreCategoria";
            this.txtNombreCategoria.Size = new System.Drawing.Size(240, 23);
            this.txtNombreCategoria.TabIndex = 1;
            // 
            // lblNombreCategoria
            // 
            this.lblNombreCategoria.AutoSize = true;
            this.lblNombreCategoria.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNombreCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblNombreCategoria.Location = new System.Drawing.Point(15, 15);
            this.lblNombreCategoria.Name = "lblNombreCategoria";
            this.lblNombreCategoria.Size = new System.Drawing.Size(123, 15);
            this.lblNombreCategoria.TabIndex = 0;
            this.lblNombreCategoria.Text = "Nombre de Categoría:";
            // 
            // tabLineas
            // 
            this.tabLineas.Controls.Add(this.dgvLineas);
            this.tabLineas.Controls.Add(this.pnlLineas);
            this.tabLineas.Location = new System.Drawing.Point(4, 24);
            this.tabLineas.Name = "tabLineas";
            this.tabLineas.Padding = new System.Windows.Forms.Padding(3);
            this.tabLineas.Size = new System.Drawing.Size(592, 402);
            this.tabLineas.TabIndex = 3;
            this.tabLineas.Text = "Líneas";
            this.tabLineas.UseVisualStyleBackColor = true;
            // 
            // dgvLineas
            // 
            this.dgvLineas.AllowUserToAddRows = false;
            this.dgvLineas.AllowUserToDeleteRows = false;
            this.dgvLineas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLineas.BackgroundColor = System.Drawing.Color.White;
            this.dgvLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineas.Location = new System.Drawing.Point(15, 15);
            this.dgvLineas.Name = "dgvLineas";
            this.dgvLineas.ReadOnly = true;
            this.dgvLineas.RowHeadersVisible = false;
            this.dgvLineas.Size = new System.Drawing.Size(560, 180);
            this.dgvLineas.TabIndex = 0;
            // 
            // pnlLineas
            // 
            this.pnlLineas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlLineas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLineas.Controls.Add(this.btnRegistrarLinea);
            this.pnlLineas.Controls.Add(this.txtDescripcionLinea);
            this.pnlLineas.Controls.Add(this.lblDescripcionLinea);
            this.pnlLineas.Controls.Add(this.txtNombreLinea);
            this.pnlLineas.Controls.Add(this.lblNombreLinea);
            this.pnlLineas.Location = new System.Drawing.Point(15, 210);
            this.pnlLineas.Name = "pnlLineas";
            this.pnlLineas.Size = new System.Drawing.Size(560, 160);
            this.pnlLineas.TabIndex = 1;
            // 
            // btnRegistrarLinea
            // 
            this.btnRegistrarLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.btnRegistrarLinea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarLinea.FlatAppearance.BorderSize = 0;
            this.btnRegistrarLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarLinea.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarLinea.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarLinea.Location = new System.Drawing.Point(285, 35);
            this.btnRegistrarLinea.Name = "btnRegistrarLinea";
            this.btnRegistrarLinea.Size = new System.Drawing.Size(250, 83);
            this.btnRegistrarLinea.TabIndex = 4;
            this.btnRegistrarLinea.Text = "Registrar Línea";
            this.btnRegistrarLinea.UseVisualStyleBackColor = false;
            this.btnRegistrarLinea.Click += new System.EventHandler(this.btnRegistrarLinea_Click);
            // 
            // txtDescripcionLinea
            // 
            this.txtDescripcionLinea.Location = new System.Drawing.Point(15, 95);
            this.txtDescripcionLinea.Name = "txtDescripcionLinea";
            this.txtDescripcionLinea.Size = new System.Drawing.Size(240, 23);
            this.txtDescripcionLinea.TabIndex = 3;
            // 
            // lblDescripcionLinea
            // 
            this.lblDescripcionLinea.AutoSize = true;
            this.lblDescripcionLinea.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDescripcionLinea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblDescripcionLinea.Location = new System.Drawing.Point(15, 75);
            this.lblDescripcionLinea.Name = "lblDescripcionLinea";
            this.lblDescripcionLinea.Size = new System.Drawing.Size(73, 15);
            this.lblDescripcionLinea.TabIndex = 2;
            this.lblDescripcionLinea.Text = "Descripción:";
            // 
            // txtNombreLinea
            // 
            this.txtNombreLinea.Location = new System.Drawing.Point(15, 35);
            this.txtNombreLinea.Name = "txtNombreLinea";
            this.txtNombreLinea.Size = new System.Drawing.Size(240, 23);
            this.txtNombreLinea.TabIndex = 1;
            // 
            // lblNombreLinea
            // 
            this.lblNombreLinea.AutoSize = true;
            this.lblNombreLinea.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNombreLinea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblNombreLinea.Location = new System.Drawing.Point(15, 15);
            this.lblNombreLinea.Name = "lblNombreLinea";
            this.lblNombreLinea.Size = new System.Drawing.Size(169, 15);
            this.lblNombreLinea.TabIndex = 0;
            this.lblNombreLinea.Text = "Nombre de Línea de Producto:";
            // 
            // FormMantenimientosDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMantenimientosDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mantenimiento del Catálogo y Proveedores";
            this.Load += new System.EventHandler(this.FormMantenimientosDialog_Load);
            this.tabControl.ResumeLayout(false);
            this.tabMarcas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.pnlMarcas.ResumeLayout(false);
            this.pnlMarcas.PerformLayout();
            this.tabProveedores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.pnlProveedores.ResumeLayout(false);
            this.pnlProveedores.PerformLayout();
            this.tabCategorias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.pnlCategorias.ResumeLayout(false);
            this.pnlCategorias.PerformLayout();
            this.tabLineas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineas)).EndInit();
            this.pnlLineas.ResumeLayout(false);
            this.pnlLineas.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
