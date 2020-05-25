using PointOfSale.Controllers;
using PointOfSale.Controllers.Utils;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.PuntoVenta
{
    public partial class FrmCobroRapido : Form
    {
        private Moneda moneda;
        public decimal total;
        public decimal pago1;
        public decimal pago2;
        public decimal pago3;
        public decimal cambio;

        public string totalLetra;
        public string tipoDoc;
        public string NoTarjeta;
        public bool CobroConPuntos;

        public bool Cxc;
        public Cliente cliente;
        public CFormapago formaPago1 { get; set; }
        public CFormapago formaPago2 { get; set; }
        public CFormapago formaPago3 { get; set; }
        
        public CMetodopago metodoPago;
        public FormaPagoController formaPagoController;


        public FrmCobroRapido()
        {
            InitializeComponent();
        }

        public FrmCobroRapido(decimal total, Cliente c = null)
        {
            InitializeComponent();
            formaPagoController = new FormaPagoController();
            this.total = total;
            cliente = c;
            InicializaCampos();
        }

        private void InicializaCampos()
        {
            formaPago1 = formaPagoController.SelectOne("01");
            TxtTotal.Text = total.ToString();
            TxtPago1.Text = total.ToString();
            formaPago2 = null;
            formaPago3 = null;
            totalLetra = "";
            pago1 = 0;
            pago2 = 0;
            pago3 = 0;
            Cxc = false;
            tipoDoc = "TIC";
            CobroConPuntos = false;
            NoTarjeta = "";
            moneda = new Moneda();
        }

        private void TxtConceptoPago2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtConceptoPago2.Text.Trim(), (int)Ambiente.TipoBusqueda.FormaPago))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        if (form.FormaPago.FormaPagoId.Equals("05"))
                        {
                            if (cliente == null)
                            {

                                Ambiente.Mensaje("Seleccione un cliente en la venta");
                                DialogResult = DialogResult.Cancel;
                            }
                            else
                            {
                                TxtPago2.Text = Ambiente.FDinero(cliente.DineroElectronico.ToString());
                                TxtPago2.Enabled = false;

                                TxtPago3.Enabled = true;
                                TxtPago3.Text = "";
                                TxtFormaPago3.Text = "";
                                TxtPago1.Enabled = true;
                                TxtPago1.Text = "";
                                TxtFormaPago1.Text = "";
                                ChkCobrarConPtos.Checked = true;
                                ChkCobrarConPtos.Enabled = false;
                            }
                        }
                        else
                        {
                            if (formaPago1 != null && formaPago3 != null)
                            {
                                if (!formaPago1.FormaPagoId.Equals("05") && !formaPago3.FormaPagoId.Equals("05"))
                                {
                                    ChkCobrarConPtos.Checked = false;
                                    ChkCobrarConPtos.Enabled = true;
                                }
                            }


                            TxtPago3.Enabled = true;
                        }
                        TxtFormaPago2.Text = form.FormaPago.FormaPagoId;
                        TxtConceptoPago2.Text = form.FormaPago.Descripcion.ToUpper();


                        if (TxtPago1.Text.Trim().Length == 0)
                            formaPago1 = null;
                        if (TxtPago2.Text.Trim().Length == 0)
                            formaPago2 = null;
                        if (TxtPago3.Text.Trim().Length == 0)
                            formaPago3 = null;

                        formaPago2 = form.FormaPago;

                    }
                }
            }
        }

        private void TxtConceptoPago3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtConceptoPago3.Text.Trim(), (int)Ambiente.TipoBusqueda.FormaPago))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        if (form.FormaPago.FormaPagoId.Equals("05"))
                        {
                            if (cliente == null)
                            {

                                Ambiente.Mensaje("Seleccione un cliente en la venta");
                                DialogResult = DialogResult.Cancel;
                            }
                            else
                            {
                                TxtPago3.Text = Ambiente.FDinero(cliente.DineroElectronico.ToString());
                                TxtPago3.Enabled = false;

                                TxtPago2.Enabled = true;
                                TxtPago2.Text = "";
                                TxtFormaPago2.Text = "";
                                TxtPago1.Enabled = true;
                                TxtPago1.Text = "";
                                TxtFormaPago1.Text = "";
                                ChkCobrarConPtos.Checked = true;
                                ChkCobrarConPtos.Enabled = false;
                            }
                        }
                        else
                        {
                            if (formaPago1 != null && formaPago2 != null)
                            {
                                if (!formaPago1.FormaPagoId.Equals("05") && !formaPago2.FormaPagoId.Equals("05"))
                                {
                                    ChkCobrarConPtos.Checked = false;
                                    ChkCobrarConPtos.Enabled = true;
                                }
                            }


                            TxtPago3.Enabled = true;
                        }
                        TxtFormaPago3.Text = form.FormaPago.FormaPagoId;
                        TxtConceptoPago3.Text = form.FormaPago.Descripcion.ToUpper();


                        if (TxtPago1.Text.Trim().Length == 0)
                            formaPago1 = null;
                        if (TxtPago2.Text.Trim().Length == 0)
                            formaPago2 = null;
                        if (TxtPago3.Text.Trim().Length == 0)
                            formaPago3 = null;

                        formaPago3 = form.FormaPago;
                    }
                }
            }
        }


        private void RTicket_CheckedChanged(object sender, EventArgs e)
        {
            if (RTicket.Checked)
                tipoDoc = "TIC";
        }

        private void TxtPago1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculaCambio();
                if (cambio >= 0)
                    ChkCobrarConPtos.Focus();
            }
        }

        private void TxtPago1_TextChanged(object sender, EventArgs e)
        {
            CalculaCambio();
        }

        private void CalculaCambio()
        {
            decimal.TryParse(TxtPago1.Text.Trim(), out pago1);
            decimal.TryParse(TxtPago2.Text.Trim(), out pago2);
            decimal.TryParse(TxtPago3.Text.Trim(), out pago3);

            cambio = total - (pago1 + pago2 + pago3);
            cambio *= -1;
            TxtCambio.Text = cambio.ToString();
        }

        private void TxtPago1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void TxtPago2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void TxtPago3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void TxtConceptoPago1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtConceptoPago1.Text.Trim(), (int)Ambiente.TipoBusqueda.FormaPago))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        if (form.FormaPago.FormaPagoId.Equals("05"))
                        {
                            if (cliente == null)
                            {

                                Ambiente.Mensaje("Seleccione un cliente en la venta");
                                DialogResult = DialogResult.Cancel;
                            }
                            else
                            {
                                TxtPago1.Text = Ambiente.FDinero(cliente.DineroElectronico.ToString());
                                TxtPago1.Enabled = false;

                                TxtPago3.Enabled = true;
                                TxtPago3.Text = "";
                                TxtFormaPago3.Text = "";
                                TxtPago2.Enabled = true;
                                TxtPago2.Text = "";
                                TxtFormaPago2.Text = "";
                                ChkCobrarConPtos.Checked = true;
                                ChkCobrarConPtos.Enabled = false;
                            }
                        }
                        else
                        {
                            if (formaPago2 != null && formaPago3 != null)
                            {
                                if (!formaPago2.FormaPagoId.Equals("05") && !formaPago3.FormaPagoId.Equals("05"))
                                {
                                    ChkCobrarConPtos.Checked = false;
                                    ChkCobrarConPtos.Enabled = true;
                                }
                            }

                            TxtPago1.Enabled = true;
                        }
                        TxtFormaPago1.Text = form.FormaPago.FormaPagoId;
                        TxtConceptoPago1.Text = form.FormaPago.Descripcion.ToUpper();


                        if (TxtPago1.Text.Trim().Length == 0)
                        {
                            formaPago1 = null;
                            // TxtFormaPago1.Text = "";
                            //TxtConceptoPago1.Text = "";
                        }

                        if (TxtPago2.Text.Trim().Length == 0)
                            formaPago2 = null;
                        if (TxtPago3.Text.Trim().Length == 0)
                            formaPago3 = null;

                        formaPago1 = form.FormaPago;
                    }
                }
            }
        }

        private void TxtPago2_TextChanged(object sender, EventArgs e)
        {
            CalculaCambio();
        }

        private void TxtPago3_TextChanged(object sender, EventArgs e)
        {
            CalculaCambio();
        }

        private void TxtPago2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculaCambio();
                if (cambio >= 0)
                    ChkCobrarConPtos.Focus();
            }
        }

        private void TxtPago3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculaCambio();
                if (cambio >= 0)
                    ChkCobrarConPtos.Focus();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Cxc = false;
            CerrarVenta();
        }

        private void CerrarVenta()
        {

            if (cambio < 0)
            {
                Ambiente.Mensaje("Liquida el documento o mándalo a cuentas por cobrar");
                return;
            }

            if (!(TxtPago1.Text.Trim().Length > 0 && formaPago1 != null))
            {
                Ambiente.Mensaje("Busque y seleccione la forma de pago 1");
                DialogResult = DialogResult.Cancel;
                return;
            }
            if (!(TxtPago2.Text.Trim().Length > 0 && formaPago2 != null))
            {
                Ambiente.Mensaje("Busque y seleccione la forma de pago 2");
                DialogResult = DialogResult.Cancel;
                return;
            }
            if (!(TxtPago3.Text.Trim().Length > 0 && formaPago3 != null))
            {
                Ambiente.Mensaje("Busque y seleccione la forma de pago 3");
                DialogResult = DialogResult.Cancel;
                return;
            }
            //if (tipoDoc.Equals("FAC") && Ambiente.Estacion.SolicitarFmpago)
            //{
            //    using (var form = new FrmMetodoPago())
            //    {
            //        if (form.ShowDialog() == DialogResult.OK)
            //            metodoPago = form.MetodoPago;
            //        else
            //            metodoPago = "PUE";
            //    }
            //}



            CobroConPuntos = ChkCobrarConPtos.Checked;
            totalLetra = moneda.Convertir(total.ToString(), true);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void TxtFormaPago1_TextChanged(object sender, EventArgs e)
        {
            // formapago1 = TxtFormaPago1.Text.Trim();
        }

        private void TxtFormaPago2_TextChanged(object sender, EventArgs e)
        {
            // formapago2 = TxtFormaPago2.Text.Trim();
        }

        private void TxtFormaPago3_TextChanged(object sender, EventArgs e)
        {
            //formapago3 = TxtFormaPago3.Text.Trim();
        }

        private void TxtConceptoPago1_TextChanged(object sender, EventArgs e)
        {
            // concepto1 = TxtConceptoPago1.Text.Trim();
        }

        private void TxtConceptoPago2_TextChanged(object sender, EventArgs e)
        {
            // concepto2 = TxtConceptoPago2.Text.Trim();
        }

        private void TxtConceptoPago3_TextChanged(object sender, EventArgs e)
        {
            // concepto3 = TxtConceptoPago3.Text.Trim();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnCXC_Click(object sender, EventArgs e)
        {
            Cxc = true;
            CerrarVenta();
        }

        private void ChkCobrarConPtos_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCobrarConPtos.Checked)
            {
                TxtNoTarjeta.Enabled = true;
                TxtNoTarjeta.Focus();
            }
            else
            {
                TxtNoTarjeta.Enabled = false;
                TxtNoTarjeta.Focus();
            }

        }

        private void TxtNoTarjeta_Leave(object sender, EventArgs e)
        {
            NoTarjeta = TxtNoTarjeta.Text.Trim();
        }

        private void TxtNoTarjeta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnAceptar.Focus();
            }
        }

        private void ChkCobrarConPtos_Enter(object sender, EventArgs e)
        {
            ChkCobrarConPtos.ForeColor = Color.Black;
        }

        private void ChkCobrarConPtos_Leave(object sender, EventArgs e)
        {
            ChkCobrarConPtos.ForeColor = SystemColors.ControlDarkDark;

        }
    }
}
