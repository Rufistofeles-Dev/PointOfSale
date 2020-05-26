using DYM.Views;
using PointOfSale.Controllers;
using PointOfSale.Views.Login;
using System;
using System.Windows;
using System.Windows.Forms;

namespace PointOfSale.Views
{
    public partial class RootShell : Form
    {

        public RootShell()
        {
            InitializeComponent();


            Inicializador.InicializaListas();
            GetEmpresaEsta();
        }

        private void GetLogin()
        {
            var form = new FrmLogin
            {
                MdiParent = this
            };
            form.Show();
        }
        private void GetEmpresaEsta()
        {
            var form = new FrmEmpresaEsta
            {
                MdiParent = this
            };
            form.Show();
        }

        private void BtnLogin_ButtonClick(object sender, EventArgs e)
        {
            if (Ambiente.LoggedUser == null)
            {
                GetLogin();
            }
            else
            {
                var form = new FrmMain()
                {
                    MdiParent = this
                };
                form.Show();
            }
        }

        private void BtnReporteador_ButtonClick(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }
    }
}
