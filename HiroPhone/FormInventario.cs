using System;
using System.Data;
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
            CargarDatos();
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
                
                dtProductos = DatabaseHelper.ExecuteQuery(query);
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
            string filtro = txtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(filtro))
            {
                CargarDatos();
            }
            else
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
                            INNER JOIN Almacen a ON i.id_almacen = a.id_almacen
                        WHERE
                            m.nombre_marca LIKE @Filtro OR
                            p.nombre_producto LIKE @Filtro OR
                            c.nombre_categoria LIKE @Filtro OR
                            a.nombre_almacen LIKE @Filtro";
                    
                    System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
                    {
                        new System.Data.SqlClient.SqlParameter("@Filtro", "%" + filtro + "%")
                    };

                    DataTable dtFiltrado = DatabaseHelper.ExecuteQuery(query, parameters);
                    dgvProductos.DataSource = dtFiltrado;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar productos en SQL Server:\n" + ex.Message, 
                                    "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abriendo formulario para añadir nuevo producto al catálogo...", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAjustarStock_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                string modelo = dgvProductos.SelectedRows[0].Cells["Modelo"].Value.ToString();
                string stock = dgvProductos.SelectedRows[0].Cells["Stock Actual"].Value.ToString();
                MessageBox.Show($"Abriendo panel de ajuste de inventario para {modelo} (Stock actual: {stock})...", "Ajuste de Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor seleccione un producto de la lista.", "Ajuste de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTraslado_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abriendo formulario de guías de remisión y traslado entre sedes...", "Traslados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
