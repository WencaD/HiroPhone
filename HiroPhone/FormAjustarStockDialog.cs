using System;
using System.Windows.Forms;

namespace HiroPhone
{
    public partial class FormAjustarStockDialog : Form
    {
        private int idInventario;
        private string modelo;
        private int stockActual;
        private int idAlmacen;

        public FormAjustarStockDialog(int idInventario, string modelo, int stockActual)
        {
            this.idInventario = idInventario;
            this.modelo = modelo;
            this.stockActual = stockActual;

            try
            {
                object res = Conexion.ExecuteScalar("SELECT id_almacen FROM Inventario WHERE id_inventario = " + idInventario);
                this.idAlmacen = res != null ? Convert.ToInt32(res) : 1;
            }
            catch
            {
                this.idAlmacen = 1;
            }

            InitializeComponent();
            lblInfo.Text = $"Dispositivo: {modelo}\nStock Actual: {stockActual} unidades";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int cant = (int)numCantidad.Value;
            string obs = txtObservacion.Text.Trim();
            bool esIngreso = cboTipoAjuste.SelectedIndex == 0;

            if (string.IsNullOrEmpty(obs))
            {
                MessageBox.Show("Por favor ingrese una observación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!esIngreso && cant > stockActual)
            {
                MessageBox.Show("No puede restar más unidades del stock actual disponible.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idEmpleado = UserSession.IsLoggedIn && UserSession.IdEmpleado > 0 ? UserSession.IdEmpleado : 1;

                if (esIngreso)
                {
                    string qUp = "UPDATE Inventario SET stock_actual = stock_actual + @Cant, fecha_ultima_actualizacion = GETDATE() WHERE id_inventario = @IdInv";
                    System.Data.SqlClient.SqlParameter[] pUp = {
                        new System.Data.SqlClient.SqlParameter("@Cant", cant),
                        new System.Data.SqlClient.SqlParameter("@IdInv", idInventario)
                    };
                    Conexion.ExecuteNonQuery(qUp, pUp);

                    string qMov = @"
                        INSERT INTO Movimiento_Inventario (cantidad, fecha_movimiento, observacion, id_tipo_movimiento, id_inventario, id_empleadoEnvia, id_empleadoRecibe, id_almacenEnvia, id_almacenRecibe)
                        VALUES (@Cant, GETDATE(), @Obs, 1, @IdInv, NULL, @IdEmpleado, NULL, @IdAlmacen)";
                    System.Data.SqlClient.SqlParameter[] pMov = {
                        new System.Data.SqlClient.SqlParameter("@Cant", cant),
                        new System.Data.SqlClient.SqlParameter("@Obs", obs),
                        new System.Data.SqlClient.SqlParameter("@IdInv", idInventario),
                        new System.Data.SqlClient.SqlParameter("@IdEmpleado", idEmpleado),
                        new System.Data.SqlClient.SqlParameter("@IdAlmacen", idAlmacen)
                    };
                    Conexion.ExecuteNonQuery(qMov, pMov);
                }
                else
                {
                    string qUp = "UPDATE Inventario SET stock_actual = stock_actual - @Cant, fecha_ultima_actualizacion = GETDATE() WHERE id_inventario = @IdInv";
                    System.Data.SqlClient.SqlParameter[] pUp = {
                        new System.Data.SqlClient.SqlParameter("@Cant", cant),
                        new System.Data.SqlClient.SqlParameter("@IdInv", idInventario)
                    };
                    Conexion.ExecuteNonQuery(qUp, pUp);

                    string qMov = @"
                        INSERT INTO Movimiento_Inventario (cantidad, fecha_movimiento, observacion, id_tipo_movimiento, id_inventario, id_empleadoEnvia, id_empleadoRecibe, id_almacenEnvia, id_almacenRecibe)
                        VALUES (@Cant, GETDATE(), @Obs, 2, @IdInv, @IdEmpleado, NULL, @IdAlmacen, NULL)";
                    System.Data.SqlClient.SqlParameter[] pMov = {
                        new System.Data.SqlClient.SqlParameter("@Cant", cant),
                        new System.Data.SqlClient.SqlParameter("@Obs", obs),
                        new System.Data.SqlClient.SqlParameter("@IdInv", idInventario),
                        new System.Data.SqlClient.SqlParameter("@IdEmpleado", idEmpleado),
                        new System.Data.SqlClient.SqlParameter("@IdAlmacen", idAlmacen)
                    };
                    Conexion.ExecuteNonQuery(qMov, pMov);
                }

                MessageBox.Show("Stock ajustado y movimiento registrado en el Kardex correctamente.", "Ajuste Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ajustar stock en SQL Server:\n" + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormAjustarStockDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
