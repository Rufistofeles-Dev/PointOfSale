using PointOfSale.Views.Modulos.Finanzas;
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
    }
}
