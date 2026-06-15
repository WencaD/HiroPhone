using System;
using System.Data;
using System.Windows.Forms;

namespace HiroPhone
{
    public partial class FormTrasladoDialog : Form
    {
        private int idInventarioOrigen;
        private int idProducto;
        private string modelo;
        private int idAlmacenOrigen;
        private int stockOrigen;

        public FormTrasladoDialog(int idInventarioOrigen, string modelo, int stockOrigen)
        {
            this.idInventarioOrigen = idInventarioOrigen;
            this.modelo = modelo;
            this.stockOrigen = stockOrigen;

            try
            {
                DataTable dt = Conexion.ExecuteQuery("SELECT id_producto, id_almacen FROM Inventario WHERE id_inventario = " + idInventarioOrigen);
                if (dt.Rows.Count > 0)
                {
                    this.idProducto = Convert.ToInt32(dt.Rows[0]["id_producto"]);
                    this.idAlmacenOrigen = Convert.ToInt32(dt.Rows[0]["id_almacen"]);
                }
                else
                {
                    this.idProducto = 0;
                    this.idAlmacenOrigen = 1;
                }
            }
            catch
            {
                this.idProducto = 0;
                this.idAlmacenOrigen = 1;
            }

            InitializeComponent();
            lblInfo.Text = $"Dispositivo: {modelo}\nStock en Origen: {stockOrigen} unidades";
            numCantidad.Maximum = Math.Max(1, stockOrigen);
            CargarAlmacenesDestino();
        }

        private void CargarAlmacenesDestino()
        {
            try
            {
                string query = "SELECT id_almacen, nombre_almacen FROM Almacen WHERE id_almacen <> " + idAlmacenOrigen;
                DataTable dt = Conexion.ExecuteQuery(query);
                cboAlmacenDestino.DataSource = dt;
                cboAlmacenDestino.DisplayMember = "nombre_almacen";
                cboAlmacenDestino.ValueMember = "id_almacen";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar almacenes de destino:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int cant = (int)numCantidad.Value;
            string obs = txtObservacion.Text.Trim();

            if (cboAlmacenDestino.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un almacén de destino.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idAlmacenDestino = Convert.ToInt32(cboAlmacenDestino.SelectedValue);

            if (cant > stockOrigen)
            {
                MessageBox.Show("La cantidad a trasladar supera el stock actual disponible en el almacén de origen.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idEmpleado = UserSession.IsLoggedIn && UserSession.IdEmpleado > 0 ? UserSession.IdEmpleado : 1;

                string qSub = "UPDATE Inventario SET stock_actual = stock_actual - @Cant, fecha_ultima_actualizacion = GETDATE() WHERE id_inventario = @IdInvOrigen";
                System.Data.SqlClient.SqlParameter[] pSub = {
                    new System.Data.SqlClient.SqlParameter("@Cant", cant),
                    new System.Data.SqlClient.SqlParameter("@IdInvOrigen", idInventarioOrigen)
                };
                Conexion.ExecuteNonQuery(qSub, pSub);

                string qCheckDestino = "SELECT id_inventario FROM Inventario WHERE id_producto = @IdProd AND id_almacen = @IdAlmacenDest";
                System.Data.SqlClient.SqlParameter[] pCheckDestino = {
                    new System.Data.SqlClient.SqlParameter("@IdProd", idProducto),
                    new System.Data.SqlClient.SqlParameter("@IdAlmacenDest", idAlmacenDestino)
                };
                object resDestino = Conexion.ExecuteScalar(qCheckDestino, pCheckDestino);
                int idInventarioDestino = 0;

                if (resDestino != null)
                {
                    idInventarioDestino = Convert.ToInt32(resDestino);
                    string qAdd = "UPDATE Inventario SET stock_actual = stock_actual + @Cant, fecha_ultima_actualizacion = GETDATE() WHERE id_inventario = @IdInvDest";
                    System.Data.SqlClient.SqlParameter[] pAdd = {
                        new System.Data.SqlClient.SqlParameter("@Cant", cant),
                        new System.Data.SqlClient.SqlParameter("@IdInvDest", idInventarioDestino)
                    };
                    Conexion.ExecuteNonQuery(qAdd, pAdd);
                }
                else
                {
                    string qInsert = "INSERT INTO Inventario (stock_actual, stock_minimo, fecha_ultima_actualizacion, id_producto, id_almacen) VALUES (@Cant, 5, GETDATE(), @IdProd, @IdAlmacenDest); SELECT SCOPE_IDENTITY();";
                    System.Data.SqlClient.SqlParameter[] pInsert = {
                        new System.Data.SqlClient.SqlParameter("@Cant", cant),
                        new System.Data.SqlClient.SqlParameter("@IdProd", idProducto),
                        new System.Data.SqlClient.SqlParameter("@IdAlmacenDest", idAlmacenDestino)
                    };
                    idInventarioDestino = Convert.ToInt32(Conexion.ExecuteScalar(qInsert, pInsert));
                }

                string qMov = @"
                    INSERT INTO Movimiento_Inventario (cantidad, fecha_movimiento, observacion, id_tipo_movimiento, id_inventario, id_empleadoEnvia, id_empleadoRecibe, id_almacenEnvia, id_almacenRecibe)
                    VALUES (@Cant, GETDATE(), @Obs, 3, @IdInvOrigen, @IdEmpleado, @IdEmpleado, @IdAlmacenOrigen, @IdAlmacenDest)";
                System.Data.SqlClient.SqlParameter[] pMov = {
                    new System.Data.SqlClient.SqlParameter("@Cant", cant),
                    new System.Data.SqlClient.SqlParameter("@Obs", obs),
                    new System.Data.SqlClient.SqlParameter("@IdInvOrigen", idInventarioOrigen),
                    new System.Data.SqlClient.SqlParameter("@IdEmpleado", idEmpleado),
                    new System.Data.SqlClient.SqlParameter("@IdAlmacenOrigen", idAlmacenOrigen),
                    new System.Data.SqlClient.SqlParameter("@IdAlmacenDest", idAlmacenDestino)
                };
                Conexion.ExecuteNonQuery(qMov, pMov);

                MessageBox.Show("Traslado realizado y movimiento registrado en el Kardex correctamente.", "Traslado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar traslado en SQL Server:\n" + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormTrasladoDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
