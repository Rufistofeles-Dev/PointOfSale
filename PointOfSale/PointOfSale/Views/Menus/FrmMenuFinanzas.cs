using PointOfSale.Views.Modulos.Catalogos;
using PointOfSale.Views.Modulos.Finanzas;
using PointOfSale.Views.Modulos.Logistica;
using PointOfSale.Views.ReportDesigner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Menus
{
    public partial class FrmMenuFinanzas : Form
    {
        public FrmMenuFinanzas()
        {
            InitializeComponent();
        }

        private void BtnAutInv_Click(object sender, EventArgs e)
        {
            var o = new FrmInvetarioAut();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnAjusteInventarios_Click(object sender, EventArgs e)
        {
            var o = new FrmDevoliciones();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            var o = new FrmTreeViewReportes();
            o.MdiParent = MdiParent;
            o.Show();

        }

        private void BtnProds_Click(object sender, EventArgs e)
        {
            var o = new FrmProductos();
            o.MdiParent = MdiParent;
            o.Show();

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
