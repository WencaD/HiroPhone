using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HiroPhone
{
    public partial class FormCierreCajaDialog : Form
    {
        private double sysEfectivo;
        private double sysTarjeta;
        private double sysTransf;
        private double sysTotal;

        public FormCierreCajaDialog(double efectivo, double tarjeta, double transferencia)
        {
            this.sysEfectivo = efectivo;
            this.sysTarjeta = tarjeta;
            this.sysTransf = transferencia;
            this.sysTotal = efectivo + tarjeta + transferencia;

            InitializeComponent();
            lblSysEfectivo.Text = sysEfectivo.ToString("N2");
            lblSysTarjeta.Text = sysTarjeta.ToString("N2");
            lblSysTransf.Text = sysTransf.ToString("N2");
            lblTotalSistema.Text = sysTotal.ToString("N2");
            ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            double.TryParse(txtFisicoEfectivo.Text, out double fisEf);
            double.TryParse(txtFisicoTarjeta.Text, out double fisTar);
            double.TryParse(txtFisicoTransf.Text, out double fisTra);

            double totalFis = fisEf + fisTar + fisTra;
            double dif = totalFis - sysTotal;

            lblTotalFisico.Text = totalFis.ToString("N2");
            lblDiferencia.Text = dif.ToString("N2");

            if (dif < 0)
            {
                lblDiferencia.ForeColor = Color.Red;
            }
            else if (dif > 0)
            {
                lblDiferencia.ForeColor = Color.Green;
            }
            else
            {
                lblDiferencia.ForeColor = Color.Black;
            }
        }

        private void txtFisicoEfectivo_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotales();
        }

        private void txtFisicoTarjeta_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotales();
        }

        private void txtFisicoTransf_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotales();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            double.TryParse(txtFisicoEfectivo.Text, out double fisEf);
            double.TryParse(txtFisicoTarjeta.Text, out double fisTar);
            double.TryParse(txtFisicoTransf.Text, out double fisTra);
            double totalFis = fisEf + fisTar + fisTra;
            double dif = totalFis - sysTotal;

            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    string query = @"
                        INSERT INTO Cierre_Caja (caja_id_caja, fecha_cierre, monto_final_sistema, monto_final_fisico, diferencia, total_efectivo, total_dolares, total_tarjeta, total_transferencia)
                        VALUES (1, GETDATE(), @SysTotal, @FisTotal, @Dif, @FisEf, 0, @FisTar, @FisTra)";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@SysTotal", (decimal)sysTotal);
                        cmd.Parameters.AddWithValue("@FisTotal", (decimal)totalFis);
                        cmd.Parameters.AddWithValue("@Dif", (decimal)dif);
                        cmd.Parameters.AddWithValue("@FisEf", (decimal)fisEf);
                        cmd.Parameters.AddWithValue("@FisTar", (decimal)fisTar);
                        cmd.Parameters.AddWithValue("@FisTra", (decimal)fisTra);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("El Cierre de Caja se ha registrado correctamente en SQL Server.", "Cierre Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cierre de caja:\n" + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
