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
            CargarFiltroCategorias();
            CargarDatos();
        }

        private void CargarFiltroCategorias()
        {
            try
            {
                using (System.Data.SqlClient.SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT id_categoria, nombre_categoria FROM Categoria_Producto ORDER BY nombre_categoria", cn))
                    {
                        using (System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            DataRow row = dt.NewRow();
                            row["id_categoria"] = 0;
                            row["nombre_categoria"] = "Todas";
                            dt.Rows.InsertAt(row, 0);

                            cboFiltroCategoria.SelectedIndexChanged -= cboFiltroCategoria_SelectedIndexChanged;
                            cboFiltroCategoria.DataSource = dt;
                            cboFiltroCategoria.DisplayMember = "nombre_categoria";
                            cboFiltroCategoria.ValueMember = "id_categoria";
                            cboFiltroCategoria.SelectedIndexChanged += cboFiltroCategoria_SelectedIndexChanged;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías para el filtro:\n" + ex.Message, 
                                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
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
            string filtroText = txtBuscar.Text.Trim().Replace("'", "''");
            
            string rowFilter = "";
            if (!string.IsNullOrEmpty(filtroText))
            {
                rowFilter = string.Format(
                    "(Marca LIKE '%{0}%' OR Modelo LIKE '%{0}%' OR Categoría LIKE '%{0}%' OR Almacén LIKE '%{0}%')", filtroText);
            }

            if (cboFiltroCategoria.SelectedValue != null)
            {
                string catVal = cboFiltroCategoria.SelectedValue.ToString();
                if (int.TryParse(catVal, out int idCat) && idCat > 0)
                {
                    // Find the category name
                    string catNombre = "";
                    if (cboFiltroCategoria.SelectedItem is DataRowView drv)
                    {
                        catNombre = drv["nombre_categoria"].ToString();
                    }
                    else
                    {
                        catNombre = cboFiltroCategoria.Text;
                    }

                    if (!string.IsNullOrEmpty(catNombre))
                    {
                        string catFilter = string.Format("Categoría = '{0}'", catNombre.Replace("'", "''"));
                        if (string.IsNullOrEmpty(rowFilter))
                        {
                            rowFilter = catFilter;
                        }
                        else
                        {
                            rowFilter = string.Format("{0} AND {1}", rowFilter, catFilter);
                        }
                    }
                }
            }

            dtProductos.DefaultView.RowFilter = rowFilter;
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
}
