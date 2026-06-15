using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HiroPhone
{
    public partial class FormMantenimientosDialog : Form
    {
        public FormMantenimientosDialog()
        {
            InitializeComponent();
            CargarMarcas();
            CargarProveedores();
            CargarCategorias();
            CargarLineas();
        }

        private void CargarMarcas()
        {
            try
            {
                dgvMarcas.DataSource = Conexion.ExecuteQuery("SELECT id_marca AS [ID], nombre_marca AS [Marca], origen_marca AS [Origen] FROM Marca");
            }
            catch { }
        }

        private void CargarProveedores()
        {
            try
            {
                dgvProveedores.DataSource = Conexion.ExecuteQuery("SELECT id_proveedor AS [ID], nombre_proveedor AS [Proveedor], ruc_proveedor AS [RUC], telefono_proveedor AS [Teléfono], correo_proveedor AS [Correo] FROM Proveedor");
            }
            catch { }
        }

        private void CargarCategorias()
        {
            try
            {
                dgvCategorias.DataSource = Conexion.ExecuteQuery("SELECT id_categoria AS [ID], nombre_categoria AS [Categoría], descripcion_categoria AS [Descripción] FROM Categoria_Producto");
            }
            catch { }
        }

        private void CargarLineas()
        {
            try
            {
                dgvLineas.DataSource = Conexion.ExecuteQuery("SELECT id_linea AS [ID], nombre_linea AS [Línea], descripcion_linea AS [Descripción] FROM Linea_de_producto");
            }
            catch { }
        }

        private void btnRegistrarMarca_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreMarca.Text.Trim();
            string origen = txtOrigenMarca.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingrese el nombre de la marca.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO Marca (nombre_marca, origen_marca) VALUES (@Nombre, @Origen)";
                System.Data.SqlClient.SqlParameter[] p = {
                    new System.Data.SqlClient.SqlParameter("@Nombre", nombre),
                    new System.Data.SqlClient.SqlParameter("@Origen", string.IsNullOrEmpty(origen) ? (object)DBNull.Value : origen)
                };
                Conexion.ExecuteNonQuery(query, p);
                MessageBox.Show("Marca registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMarcas();
                txtNombreMarca.Clear();
                txtOrigenMarca.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar marca: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarProveedor_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreProv.Text.Trim();
            string ruc = txtRucProv.Text.Trim();
            string tel = txtTelefonoProv.Text.Trim();
            string correo = txtCorreoProv.Text.Trim();
            string dir = txtDireccionProv.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(ruc))
            {
                MessageBox.Show("Complete el Nombre y RUC del proveedor.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO Proveedor (nombre_proveedor, ruc_proveedor, telefono_proveedor, correo_proveedor, direccion_proveedor) VALUES (@Nombre, @Ruc, @Tel, @Correo, @Dir)";
                System.Data.SqlClient.SqlParameter[] p = {
                    new System.Data.SqlClient.SqlParameter("@Nombre", nombre),
                    new System.Data.SqlClient.SqlParameter("@Ruc", ruc),
                    new System.Data.SqlClient.SqlParameter("@Tel", string.IsNullOrEmpty(tel) ? (object)DBNull.Value : tel),
                    new System.Data.SqlClient.SqlParameter("@Correo", string.IsNullOrEmpty(correo) ? (object)DBNull.Value : correo),
                    new System.Data.SqlClient.SqlParameter("@Dir", string.IsNullOrEmpty(dir) ? (object)DBNull.Value : dir)
                };
                Conexion.ExecuteNonQuery(query, p);
                MessageBox.Show("Proveedor registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProveedores();
                txtNombreProv.Clear();
                txtRucProv.Clear();
                txtTelefonoProv.Clear();
                txtCorreoProv.Clear();
                txtDireccionProv.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar proveedor: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarCategoria_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCategoria.Text.Trim();
            string desc = txtDescripcionCategoria.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Complete el nombre de la categoría.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO Categoria_Producto (nombre_categoria, descripcion_categoria) VALUES (@Nombre, @Desc)";
                System.Data.SqlClient.SqlParameter[] p = {
                    new System.Data.SqlClient.SqlParameter("@Nombre", nombre),
                    new System.Data.SqlClient.SqlParameter("@Desc", string.IsNullOrEmpty(desc) ? (object)DBNull.Value : desc)
                };
                Conexion.ExecuteNonQuery(query, p);
                MessageBox.Show("Categoría registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCategorias();
                txtNombreCategoria.Clear();
                txtDescripcionCategoria.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar categoría: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarLinea_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreLinea.Text.Trim();
            string desc = txtDescripcionLinea.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Complete el nombre de la línea.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO Linea_de_producto (nombre_linea, descripcion_linea) VALUES (@Nombre, @Desc)";
                System.Data.SqlClient.SqlParameter[] p = {
                    new System.Data.SqlClient.SqlParameter("@Nombre", nombre),
                    new System.Data.SqlClient.SqlParameter("@Desc", string.IsNullOrEmpty(desc) ? (object)DBNull.Value : desc)
                };
                Conexion.ExecuteNonQuery(query, p);
                MessageBox.Show("Línea registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarLineas();
                txtNombreLinea.Clear();
                txtDescripcionLinea.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar línea: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMantenimientosDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
