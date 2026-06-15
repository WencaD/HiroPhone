using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HiroPhone
{
    public partial class FormDetalleVentaDialog : Form
    {
        private int idVenta;
        private string comprobante;
        private string cliente;
        private string fecha;
        private string metodo;
        private double total;

        public FormDetalleVentaDialog(int idVenta, string comprobante, string cliente, string fecha, string metodo, double total)
        {
            this.idVenta = idVenta;
            this.comprobante = comprobante;
            this.cliente = cliente;
            this.fecha = fecha;
            this.metodo = metodo;
            this.total = total;

            InitializeComponent();
            MostrarInformacion();
            CargarDetalles();
        }

        private void MostrarInformacion()
        {
            this.lblInfo.Text = "Comprobante: " + this.comprobante + "\r\n" +
                               "Cliente: " + this.cliente + "\r\n" +
                               "Fecha: " + this.fecha + "\r\n" +
                               "Método de Pago: " + this.metodo + "\r\n" +
                               "Total: S/. " + this.total.ToString("F2");
        }

        private void CargarDetalles()
        {
            try
            {
                string query = @"
                    SELECT 
                        p.nombre_producto AS [Producto], 
                        dv.cantidad AS [Cantidad], 
                        dv.precio_unitario AS [Precio Unit.], 
                        dv.subtotal AS [Subtotal]
                    FROM Detalle_Venta dv
                    INNER JOIN Producto p ON dv.id_producto = p.id_producto
                    WHERE dv.id_venta = " + idVenta;

                DataTable dt = Conexion.ExecuteQuery(query);
                dgvDetalles.DataSource = dt;

                if (dgvDetalles.Columns.Contains("Precio Unit."))
                    dgvDetalles.Columns["Precio Unit."].DefaultCellStyle.Format = "'S/.' #,##0.00";

                if (dgvDetalles.Columns.Contains("Subtotal"))
                    dgvDetalles.Columns["Subtotal"].DefaultCellStyle.Format = "'S/.' #,##0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalles de la venta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
