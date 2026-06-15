using System;
using System.Windows.Forms;

namespace HiroPhone
{
    public partial class FormActualizarPrecioDialog : Form
    {
        private int idProducto;
        private double precioAnterior;
        private string nombreProducto;

        public FormActualizarPrecioDialog(int idProducto, string nombreProducto, double precioAnterior)
        {
            this.idProducto = idProducto;
            this.nombreProducto = nombreProducto;
            this.precioAnterior = precioAnterior;

            InitializeComponent();
            lblProductoInfo.Text = $"Dispositivo: {nombreProducto}\nPrecio Actual: S/. {precioAnterior:F2}";
            txtNuevoPrecio.Text = precioAnterior.ToString("F2");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nuevoPrecioStr = txtNuevoPrecio.Text.Trim();
            string motivo = txtMotivo.Text.Trim();

            if (!double.TryParse(nuevoPrecioStr, out double nuevoPrecio) || nuevoPrecio <= 0)
            {
                MessageBox.Show("Por favor ingrese un precio numérico válido y mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(motivo))
            {
                MessageBox.Show("Por favor ingrese un motivo para el cambio de precio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string qUpdate = "UPDATE Producto SET precio_venta = @Precio WHERE id_producto = @IdProducto";
                System.Data.SqlClient.SqlParameter[] pUpdate = {
                    new System.Data.SqlClient.SqlParameter("@Precio", (decimal)nuevoPrecio),
                    new System.Data.SqlClient.SqlParameter("@IdProducto", idProducto)
                };
                Conexion.ExecuteNonQuery(qUpdate, pUpdate);

                string qHistorial = @"
                    INSERT INTO Historial_Precio_Producto (precio_anterior, precio_nuevo, fecha_cambio, motivo, id_producto)
                    VALUES (@PrecioAnt, @PrecioNue, GETDATE(), @Motivo, @IdProducto)";
                System.Data.SqlClient.SqlParameter[] pHistorial = {
                    new System.Data.SqlClient.SqlParameter("@PrecioAnt", (decimal)precioAnterior),
                    new System.Data.SqlClient.SqlParameter("@PrecioNue", (decimal)nuevoPrecio),
                    new System.Data.SqlClient.SqlParameter("@Motivo", motivo),
                    new System.Data.SqlClient.SqlParameter("@IdProducto", idProducto)
                };
                Conexion.ExecuteNonQuery(qHistorial, pHistorial);

                MessageBox.Show("Precio actualizado y registrado en el historial de precios correctamente.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar precio en SQL Server:\n" + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormActualizarPrecioDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
