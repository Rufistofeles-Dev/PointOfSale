﻿using PointOfSale.Views.Modulos.Catalogos;
using PointOfSale.Views.Modulos.Logistica;
using PointOfSale.Views.ReportDesigner;
using System;
using System.Windows.Forms;

namespace DYM.Views
{
    public partial class FrmMenuLogistica : Form
    {
        public FrmMenuLogistica()
        {
            InitializeComponent();
        }

        private void BtnProductosCapturaPrecios_Click(object sender, EventArgs e)
        {
            var o = new FrmProductos();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnSalida_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var o = new FrmEntradaPorCompra2();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var o = new FrmSalidasPorTraspaso();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            var o = new FrmEntradasPorTraspaso();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnDevRotura_Click(object sender, EventArgs e)
        {
            var o = new FrmDevoliciones();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnAjusteInv_Click(object sender, EventArgs e)
        {
            var o = new FrmDevoliciones();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnReporteAjustes_Click(object sender, EventArgs e)
        {
            var o = new FrmTreeViewReportes();
            o.MdiParent = MdiParent;
            o.Show();
        }
    }
}
