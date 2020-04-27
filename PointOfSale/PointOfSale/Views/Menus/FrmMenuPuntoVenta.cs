using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.PuntoVenta;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace PointOfSale.Views.Menus
{
    public partial class FrmMenuPuntoVenta : Form
    {
        ReporteController reporteController;
        List<Parametro> parametros;

        public FrmMenuPuntoVenta()
        {
            InitializeComponent();
            reporteController = new ReporteController();
            parametros = new List<Parametro>();
        }

        private void BtnPOS_Click(object sender, EventArgs e)
        {
            var o = new Modulos.PuntoVenta.PointOfSale();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCerrarCaja_Click(object sender, EventArgs e)
        {



            try
            {




                Ambiente.stiReport = new StiReport();
                Ambiente.stiReport.LoadPackedReportFromString(Ambiente.InformeCorte.Codigo);

                Ambiente.stiReport.Dictionary.Variables["FechaSistema"].ValueObject = DateTime.Now.Date;
                Ambiente.stiReport.Dictionary.Variables["UsuarioId"].ValueObject = Ambiente.LoggedUser.UsuarioId;
                Ambiente.stiReport.Dictionary.Variables["Creador"].ValueObject = Ambiente.LoggedUser.Nombre;
                Ambiente.stiReport.Dictionary.Variables["Estacion"].ValueObject = Ambiente.Estacion.EstacionId;
                Ambiente.S1 = Ambiente.Empresa.DirectorioCortes + "CORTE " + Ambiente.LoggedUser.Nombre + "_" + Ambiente.TimeText(DateTime.Now) + ".PDF"; ;

                Ambiente.stiReport.Render(true);
                Ambiente.stiReport.ExportDocument(StiExportFormat.Pdf, Ambiente.S1);

                Process.Start(Ambiente.S1);
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(ex.Message);
            }
        }

        private void BtnTicketAFactura_Click(object sender, EventArgs e)
        {
            var o = new FrmTicketFactura();
            o.MdiParent = MdiParent;
            o.Show();

        }

        private void BtnFacturas_Click(object sender, EventArgs e)
        {
            var o = new FrmFacturas();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnFacturaGlobal_Click(object sender, EventArgs e)
        {
            var o = new FrmFacturaGlobal3();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnMovsCaja_Click(object sender, EventArgs e)
        {

        }

        private void BtnVentasDelDia_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
