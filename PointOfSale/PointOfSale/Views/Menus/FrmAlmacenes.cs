using PointOfSale.Controllers;
using PointOfSale.Views.Modulos.Catalogos;
using PointOfSale.Views.Modulos.Logistica;
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
    public partial class FrmAlmacenes : Form
    {
        public FrmAlmacenes()
        {
            InitializeComponent();
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            var o = new FrmProductos();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnInventario_Click(object sender, EventArgs e)
        {
            var o = new FrmInventario();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnImprimeEtiquetas_Click(object sender, EventArgs e)
        {
            Ambiente.Mensaje("No implementado");
        }
    }
}
