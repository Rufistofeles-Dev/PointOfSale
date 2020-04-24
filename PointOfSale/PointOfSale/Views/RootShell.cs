﻿using DYM.Views;
using PointOfSale.Controllers;
using PointOfSale.Views.Login;
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

namespace PointOfSale.Views
{
    public partial class RootShell : Form
    {

        public RootShell()
        {
            InitializeComponent();
            Inicializador.IniciliazaConexion();
            Inicializador.InicializaListas();
            Inicializador.InicializaProdiedades();
            Inicializador.InicializaDatabaseDefaultsValues();
            Ambiente.InsertaActualizacion();
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


    }
}
