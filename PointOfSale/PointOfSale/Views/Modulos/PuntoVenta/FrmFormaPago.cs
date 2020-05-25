using PointOfSale.Controllers;
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
    public partial class FrmFormaPago : Form
    {
        public CFormapago formapago;

        public FrmFormaPago()
        {
            InitializeComponent();
        }

        private void TxtFormaPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtFormaPago.Text, (int)Ambiente.TipoBusqueda.FormaPago))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        formapago = form.FormaPago;
                        TxtFormaPago.Text = formapago.Descripcion;

                    }
                }
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
