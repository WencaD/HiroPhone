using System;
using System.Drawing;
using System.Windows.Forms;

namespace HiroPhone
{
    public partial class FormPagoMixtoDialog : Form
    {
        private double totalVenta;
        public double MontoEfectivo { get; private set; }
        public double MontoTarjeta { get; private set; }

        public FormPagoMixtoDialog(double totalVenta)
        {
            this.totalVenta = totalVenta;
            InitializeComponent();
            txtEfectivo.Text = totalVenta.ToString("F2");
            ActualizarTarjeta();
        }

        private void ActualizarTarjeta()
        {
            if (double.TryParse(txtEfectivo.Text, out double efectivo))
            {
                if (efectivo < 0) efectivo = 0;
                if (efectivo > totalVenta) efectivo = totalVenta;
                double tarjeta = totalVenta - efectivo;
                txtTarjeta.Text = tarjeta.ToString("F2");
            }
            else
            {
                txtTarjeta.Text = totalVenta.ToString("F2");
            }
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            ActualizarTarjeta();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtEfectivo.Text, out double cash) && double.TryParse(txtTarjeta.Text, out double card))
            {
                if (cash < 0 || card < 0 || Math.Abs((cash + card) - totalVenta) > 0.01)
                {
                    MessageBox.Show("La suma de Efectivo y Tarjeta debe ser igual al total a pagar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MontoEfectivo = cash;
                MontoTarjeta = card;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ingrese montos numéricos válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
