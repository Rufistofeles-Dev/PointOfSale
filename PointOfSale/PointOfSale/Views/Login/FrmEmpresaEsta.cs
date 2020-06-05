using DYM.Views;
using PointOfSale.Controllers;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Login
{
    public partial class FrmEmpresaEsta : Form
    {
        private ConexionController conexionController;
        public FrmEmpresaEsta()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                //Inicializa conexion sqlite
                Ambiente.SqliteConnectionString = Application.StartupPath + @"\config.s3db";
                Ambiente.SqliteConnection = new SQLiteConnection(string.Format("Data Source={0};Version=3;", Ambiente.SqliteConnectionString));
                Ambiente.SqliteConnection.Open();


                conexionController = new ConexionController();
                //Llenar Empresas
                CboEmpresa.DataSource = conexionController.SelectAll();
                CboEmpresa.DisplayMember = "Empresa";
                CboEmpresa.ValueMember = "ConexionId";
                CboEmpresa.SelectedIndex = 0;

                //Llenar Establecimientos
                //CboEstablecimineto.DataSource = conexionController.SelectAll();
                CboEstablecimineto.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            IniciaRootShell();
        }

        private void IniciaRootShell()
        {
            try
            {
                Ambiente.Conexion = CboEmpresa.SelectedItem as Conexion;
                Inicializador.InicializaProdiedades();
                Inicializador.InicializaDatabaseDefaultsValues();
                Inicializador.ActualizaCierresInventario();
                Ambiente.InsertaActualizacion();
                GetLogin();
                Close();
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(ex.ToString());
                
            }
           
        }

        private void GetLogin()
        {
            var form = new FrmLogin
            {
                MdiParent = MdiParent
            };
            form.Show();
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
