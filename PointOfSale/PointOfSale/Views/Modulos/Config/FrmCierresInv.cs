using PointOfSale.Controllers;
using PointOfSale.Models;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Config
{
    public partial class FrmCierresInv : Form
    {
        private CierreInventarioController cierreInventarioController;
        private CierreInventariopController cierreInventariopController;
        private InformeController informeController;
        private CierreInventario cierreInventario;
        private CierreInventariop cierreInventariop;

        public FrmCierresInv()
        {
            InitializeComponent();
            Iniciza();
        }

        private void Iniciza()
        {
            cierreInventarioController = new CierreInventarioController();
            cierreInventariopController = new CierreInventariopController();
            informeController = new InformeController();
            cierreInventario = null;
            cierreInventariop = null;
            CargaMalla();
        }

        private void CargaMalla()
        {
            Malla.Rows.Clear();
            foreach (var c in cierreInventarioController.SelectAll())
            {
                Malla.Rows.Add();
                Malla.Rows[Malla.RowCount - 1].Cells[0].Value = c.CierreInventarioId;
                Malla.Rows[Malla.RowCount - 1].Cells[1].Value = c.FechaInicial;
                Malla.Rows[Malla.RowCount - 1].Cells[2].Value = c.FechaFinal;
                Malla.Rows[Malla.RowCount - 1].Cells[3].Value = c.FechaProgramacion;
                Malla.Rows[Malla.RowCount - 1].Cells[4].Value = c.Etapa1Generada;
                Malla.Rows[Malla.RowCount - 1].Cells[5].Value = c.Etapa2Generada;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

            Agregar();
        }

        private void Agregar()
        {

            if (Ambiente.Pregunta("REALMENTE NO ES NECESARIO CREAR CIERRES MANUALES. \n El sistema generá automaticamente los cambios y arranques de periodos automaticamente. \n CREAR DE TODAS FORMAS"))
            {
                if (Ambiente.Pregunta("Aseguresé que conoce las implicaciones de generar periodos manualmente. CONTINUAR"))
                {
                    cierreInventario = new CierreInventario();
                    cierreInventario.FechaInicial = DpFinicial.Value;
                    cierreInventario.FechaFinal = DpFinicial.Value;
                    cierreInventario.FechaProgramacion = DpFechaEjecucion.Value;
                    cierreInventario.Etapa1Generada = false;
                    cierreInventario.Etapa2Generada = false;
                    cierreInventario.CreatedAt = DateTime.Now;
                    cierreInventario.CreatedBy = Ambiente.LoggedUser.UsuarioId;

                    if (cierreInventarioController.InsertOne(cierreInventario))
                        Ambiente.Mensaje("Proceso completado");
                }
            }
        }

        private void BtnGenerarAnioCompleto_Click(object sender, EventArgs e)
        {
            VisualizarReporte();
        }

        private void VisualizarReporte()
        {
            try
            {
                if (Malla.RowCount == 0) return;

                var Id = (int)Malla.Rows[Malla.CurrentRow.Index].Cells[0].Value;
                if (Id != 0)
                {
                    Ambiente.stiReport = new StiReport();
                    Ambiente.stiReport.LoadPackedReportFromString(Ambiente.InformeCierresInv.Codigo);
                    Ambiente.stiReport.Dictionary.Variables["CierreInventarioId"].ValueObject = Id; ;
                    Ambiente.stiReport.Render();
                    Ambiente.stiReport.Show();
                }
                else Ambiente.Mensaje("Seleccione un informe");
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.ToString());
            }

        }

        private void GenerarAnioCompleto()
        {
            var mactual = DateTime.Now.ToString("MMMM").ToUpper();
            var mfinal = (DateTime.Now.AddMonths(12 - DateTime.Now.Month)).ToString("MMMM").ToUpper();
            if (Ambiente.Pregunta("Se generarán los cierres de inventarios de " + mactual + " hasta " + mfinal))
            {
                for (int i = DateTime.Now.Month; i <= DateTime.Now.AddMonths(12 - DateTime.Now.Month).Month; i++)
                {
                    cierreInventario = new CierreInventario();
                    cierreInventario.FechaInicial = new DateTime(DateTime.Now.Year, i, 1);
                    cierreInventario.FechaFinal = cierreInventario.FechaInicial.AddMonths(1).AddDays(-1);
                    cierreInventario.FechaProgramacion = cierreInventario.FechaFinal.AddDays(1);
                    cierreInventario.Etapa1Generada = false;
                    cierreInventario.Etapa2Generada = false;
                    cierreInventario.CreatedAt = DateTime.Now;
                    cierreInventario.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                    cierreInventario.EstacionId = Ambiente.Estacion.EstacionId;
                    cierreInventarioController.InsertOne(cierreInventario);
                }
                CargaMalla();
                Ambiente.Mensaje("Proceso concluido");
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
