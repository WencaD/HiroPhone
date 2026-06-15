using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HiroPhone
{
    public partial class FormNuevoProductoDialog : Form
    {
        public FormNuevoProductoDialog()
        {
            InitializeComponent();
            CargarCombos();
        }

        private void CargarCombos()
        {
            try
            {
                cboMarca.DataSource = Conexion.ExecuteQuery("SELECT id_marca, nombre_marca FROM Marca");
                cboMarca.DisplayMember = "nombre_marca";
                cboMarca.ValueMember = "id_marca";

                cboModelo.DataSource = Conexion.ExecuteQuery("SELECT id_modelo, nombre_modelo FROM Modelo");
                cboModelo.DisplayMember = "nombre_modelo";
                cboModelo.ValueMember = "id_modelo";

                cboCategoria.DataSource = Conexion.ExecuteQuery("SELECT id_categoria, nombre_categoria FROM Categoria_Producto");
                cboCategoria.DisplayMember = "nombre_categoria";
                cboCategoria.ValueMember = "id_categoria";

                cboLinea.DataSource = Conexion.ExecuteQuery("SELECT id_linea, nombre_linea FROM Linea_de_producto");
                cboLinea.DisplayMember = "nombre_linea";
                cboLinea.ValueMember = "id_linea";

                cboProveedor.DataSource = Conexion.ExecuteQuery("SELECT id_proveedor, nombre_proveedor FROM Proveedor");
                cboProveedor.DisplayMember = "nombre_proveedor";
                cboProveedor.ValueMember = "id_proveedor";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del catálogo en los selectores:\n" + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string capacidad = txtCapacidad.Text.Trim();
            string color = txtColor.Text.Trim();
            string espec = txtEspecificaciones.Text.Trim();
            string precioStr = txtPrecio.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(capacidad) || cboMarca.SelectedValue == null || cboModelo.SelectedValue == null)
            {
                MessageBox.Show("Por favor complete los campos obligatorios (Nombre, Capacidad, Marca y Modelo).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(precioStr, out double precio) || precio < 0)
            {
                MessageBox.Show("Por favor ingrese un precio de venta numérico válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string qProd = @"
                    INSERT INTO Producto (nombre_producto, precio_venta, capacidad_almacenamiento, especificaciones_tecnicas, id_marca, id_categoria, id_proveedor, id_modelo, id_linea, color)
                    VALUES (@Nombre, @Precio, @Capacidad, @Espec, @IdMarca, @IdCategoria, @IdProveedor, @IdModelo, @IdLinea, @Color);
                    SELECT SCOPE_IDENTITY();";

                System.Data.SqlClient.SqlParameter[] pProd = {
                    new System.Data.SqlClient.SqlParameter("@Nombre", nombre),
                    new System.Data.SqlClient.SqlParameter("@Precio", (decimal)precio),
                    new System.Data.SqlClient.SqlParameter("@Capacidad", capacidad),
                    new System.Data.SqlClient.SqlParameter("@Espec", espec),
                    new System.Data.SqlClient.SqlParameter("@IdMarca", Convert.ToInt32(cboMarca.SelectedValue)),
                    new System.Data.SqlClient.SqlParameter("@IdCategoria", Convert.ToInt32(cboCategoria.SelectedValue)),
                    new System.Data.SqlClient.SqlParameter("@IdProveedor", Convert.ToInt32(cboProveedor.SelectedValue)),
                    new System.Data.SqlClient.SqlParameter("@IdModelo", Convert.ToInt32(cboModelo.SelectedValue)),
                    new System.Data.SqlClient.SqlParameter("@IdLinea", Convert.ToInt32(cboLinea.SelectedValue)),
                    new System.Data.SqlClient.SqlParameter("@Color", color)
                };

                int idProducto = Convert.ToInt32(Conexion.ExecuteScalar(qProd, pProd));

                DataTable dtAlmacenes = Conexion.ExecuteQuery("SELECT id_almacen FROM Almacen");
                foreach (DataRow row in dtAlmacenes.Rows)
                {
                    int idAlmacen = Convert.ToInt32(row["id_almacen"]);
                    int stockActual = (idAlmacen == 1) ? (int)numStockInicial.Value : 0;
                    int stockMin = (int)numStockMinimo.Value;

                    string qInv = @"
                        INSERT INTO Inventario (stock_actual, stock_minimo, fecha_ultima_actualizacion, id_producto, id_almacen)
                        VALUES (@StockActual, @StockMin, GETDATE(), @IdProd, @IdAlmacen)";

                    System.Data.SqlClient.SqlParameter[] pInv = {
                        new System.Data.SqlClient.SqlParameter("@StockActual", stockActual),
                        new System.Data.SqlClient.SqlParameter("@StockMin", stockMin),
                        new System.Data.SqlClient.SqlParameter("@IdProd", idProducto),
                        new System.Data.SqlClient.SqlParameter("@IdAlmacen", idAlmacen)
                    };
                    Conexion.ExecuteNonQuery(qInv, pInv);
                }

                MessageBox.Show("El producto se ha agregado al catálogo e inventario correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el producto en la Base de Datos:\n" + ex.Message, "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
