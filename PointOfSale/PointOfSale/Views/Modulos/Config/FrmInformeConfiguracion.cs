using PointOfSale.Controllers;
using PointOfSale.Models;
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
    public partial class FrmInformeConfiguracion : Form
    {
        private Informe informe;
        private InformeController informeController;

        private InformeConfiguracion informeConfiguracion;
        private InformeConfiguracionController informeConfiguracionController;

        private List<Informe> informes;
        private List<InformeConfiguracion> informeConfiguraciones;



        public FrmInformeConfiguracion()
        {
            InitializeComponent();
            Inicializa();
            CargaInformes();
        }

        private void Inicializa()
        {
            informe = null;
            informeController = new InformeController();
            informeConfiguracion = null;
            informeConfiguracionController = new InformeConfiguracionController();
            informes = informeController.SelectAll();
            informeConfiguraciones = informeConfiguracionController.SelectAll();
        }

        private void CargaInformes()
        {
            Malla.Rows.Clear();
            foreach (var i in informes)
            {
                Malla.Rows.Add();
                Malla.Rows[Malla.RowCount - 1].Cells[0].Value = i.InformeId;
                Malla.Rows[Malla.RowCount - 1].Cells[1].Value = i.Descripcion;
            }
        }
        private void CargaInformes(string s)
        {
            Malla.Rows.Clear();
            foreach (var i in informes.Where(x => x.Descripcion.Contains(s.Trim())))
            {
                Malla.Rows.Add();
                Malla.Rows[Malla.RowCount - 1].Cells[0].Value = i.InformeId;
                Malla.Rows[Malla.RowCount - 1].Cells[1].Value = i.Descripcion;
            }
        }

        private void Malla_SelectionChanged(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;
            if (Malla.Rows[Malla.CurrentCell.RowIndex].Cells[0].Value == null) return;


            informe = informes.Where(x => x.InformeId.Equals(Malla.Rows[Malla.CurrentCell.RowIndex].Cells[0].Value.ToString())).FirstOrDefault();

            if (informe != null)
            {
                informeConfiguracion = informeConfiguraciones.Where(x => x.InformeId.Equals(informe.InformeId)).FirstOrDefault();
                LlenaInformeConfiguracion(informe);
            }
            else
                informeConfiguracion = null;
        }

        private void LlenaInformeConfiguracion(Informe informe)
        {
            if (informe == null) return;

            if (informeConfiguracion == null)
                LimpiaRegla();
            else
            {
                ChkFactura.Enabled = true;
                ChkTicket.Enabled = true;
                LblCreatedby.Visible = true;
                LblUpdatedBy.Visible = true;
                BtnCancelar.Enabled = false;
                BtnGuardar.Enabled = true;
                TxtNombreRegla.Enabled = true;
                TxtReporteId.Enabled = true;
                TxtDescrip.Enabled = true;
                TxtNombreRegla.Text = informeConfiguracion.Regla;
                TxtReporteId.Text = informeConfiguracion.InformeId;
                TxtDescrip.Text = informe.Descripcion;
                ChkFactura.Checked = informeConfiguracion.Factura;
                ChkTicket.Checked = informeConfiguracion.Ticket;
                ChkCompras.Checked = informeConfiguracion.Compra;
                ChkCorte.Checked = informeConfiguracion.Corte;
                ChkDevCom.Checked = informeConfiguracion.DevCom;
                ChkInventario.Checked = informeConfiguracion.Inventario;

                LblCreatedby.Text = informeConfiguracion.CreatedBy + " el " + informeConfiguracion.CreatedAt.ToString("dd-MM-yyyy");
                LblUpdatedBy.Text = informeConfiguracion.UpdatedBy + " el " + informeConfiguracion.UpdatedAt.ToString("dd-MM-yyyy");

            }
        }



        private void LimpiaRegla()
        {
            //TxtSearch.Text = "";
            TxtNombreRegla.Text = "";
            TxtReporteId.Text = "";
            TxtDescrip.Text = "";
            ChkFactura.Enabled = false;
            ChkTicket.Enabled = false;
            LblCreatedby.Visible = false;
            LblUpdatedBy.Visible = false;
            BtnCancelar.Enabled = false;
            BtnGuardar.Enabled = false;
            TxtNombreRegla.Enabled = false;
            TxtReporteId.Enabled = false;
            TxtDescrip.Enabled = false;
            ChkFactura.Checked = false;
            ChkTicket.Checked = false;
            ChkCorte.Checked = false;
            ChkDevCom.Checked = false;
            ChkInventario.Checked = false;
        }


        private void BtnAnadir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Anadir();
        }
        private void Anadir()
        {

            if (informe == null) { Ambiente.Mensaje("Primero seleccione un informe"); return; }
            if (informeConfiguracion != null) { Ambiente.Mensaje("Ya existe una regla para " + informe.Descripcion); return; }

            ChkFactura.Enabled = true;
            ChkTicket.Enabled = true;
            LblCreatedby.Visible = true;
            LblUpdatedBy.Visible = true;
            BtnCancelar.Enabled = true;
            BtnGuardar.Enabled = true;
            TxtNombreRegla.Enabled = true;
            TxtReporteId.Enabled = true;
            TxtDescrip.Enabled = true;
            TxtReporteId.Text = informe.InformeId;
            TxtDescrip.Text = informe.Descripcion;

            LblCreatedby.Text = Ambiente.LoggedUser.UsuarioId.ToLower() + " el " + DateTime.Now.ToString("dd-MM-yyyy");
            LblUpdatedBy.Text = Ambiente.LoggedUser.UsuarioId.ToLower() + " el " + DateTime.Now.ToString("dd-MM-yyyy");

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            if (TxtNombreRegla.Text.Trim().Length == 0)
            {
                Ambiente.Mensaje("Informe todos los campos");
                return;
            }
            if (TxtReporteId.Text.Trim().Length == 0)
            {
                Ambiente.Mensaje("Informe todos los campos");
                return;
            }
            if (TxtDescrip.Text.Trim().Length == 0)
            {
                Ambiente.Mensaje("Informe todos los campos");
                return;
            }


            //informeConfiguracion = informeConfiguraciones
            //   .Where(x => x.InformeId.Equals(TxtReporteId.Text.Trim())).FirstOrDefault();

            if (informeConfiguracion == null)
            {
                informe = informes
               .Where(x => x.InformeId.Equals(TxtReporteId.Text.Trim())).FirstOrDefault();

                if (informe == null)
                {
                    Ambiente.Mensaje("El informe seleccionado no existe");
                    return;
                }
                informeConfiguracion = new InformeConfiguracion();
                informeConfiguracion.Regla = TxtNombreRegla.Text.Trim();
                informeConfiguracion.InformeId = TxtReporteId.Text.Trim();
                informeConfiguracion.Ticket = ChkTicket.Checked;
                informeConfiguracion.Factura = ChkFactura.Checked;
                informeConfiguracion.Compra = ChkCompras.Checked;
                informeConfiguracion.Corte = ChkCorte.Checked;
                informeConfiguracion.DevCom = ChkDevCom.Checked;
                informeConfiguracion.Inventario = ChkInventario.Checked;

                informeConfiguracion.CreatedAt = DateTime.Now;
                informeConfiguracion.UpdatedAt = DateTime.Now;
                informeConfiguracion.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                informeConfiguracion.UpdatedBy = Ambiente.LoggedUser.UsuarioId;
                if (informeConfiguracionController.InsertOne(informeConfiguracion))
                {
                    informes = informeController.SelectAll();
                    informeConfiguraciones = informeConfiguracionController.SelectAll();
                    Ambiente.Mensaje("Cambios guardados");

                }
            }
            else
            {
                informe = informes
               .Where(x => x.InformeId.Equals(TxtReporteId.Text.Trim())).FirstOrDefault();

                if (informe == null)
                {
                    Ambiente.Mensaje("El informe seleccionado no existe");
                    return;
                }
                informeConfiguracion.Regla = TxtNombreRegla.Text.Trim();
                informeConfiguracion.InformeId = TxtReporteId.Text.Trim();
                informeConfiguracion.Ticket = ChkTicket.Checked;
                informeConfiguracion.Factura = ChkFactura.Checked;
                informeConfiguracion.Compra = ChkCompras.Checked;
                informeConfiguracion.Corte = ChkCorte.Checked;
                informeConfiguracion.DevCom = ChkDevCom.Checked;
                informeConfiguracion.Inventario = ChkInventario.Checked;

                informeConfiguracion.UpdatedAt = DateTime.Now;
                informeConfiguracion.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                if (informeConfiguracionController.Update(informeConfiguracion))
                {
                    informes = informeController.SelectAll();
                    informeConfiguraciones = informeConfiguracionController.SelectAll();
                    Ambiente.Mensaje("Cambios guardados");

                }
            }
        }

        private void BtnBorrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Borrar();
        }

        private void Borrar()
        {
            if (Malla.RowCount == 0)
            {
                Ambiente.Mensaje("Primero seleccione un informe");
                LimpiaRegla();
                return;
            }


            //informeConfiguracion = informeConfiguraciones
            //   .Where(x => x.InformeId.Equals(TxtReporteId.Text.Trim())).FirstOrDefault();

            if (informeConfiguracion != null)
            {
                if (Ambiente.Pregunta("Confirma la elimanción " + informeConfiguracion.Regla))
                {
                    if (informeConfiguracionController.Delete(informeConfiguracion))
                    {
                        informes = informeController.SelectAll();
                        informeConfiguraciones = informeConfiguracionController.SelectAll();
                        Ambiente.Mensaje("Cambios guardados");
                    }
                }
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtSearch.Text.Trim().Length > 0)
                {
                    CargaInformes(TxtSearch.Text);
                }
            }
        }

        private void ChkTicket_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTicket.Checked) ChkFactura.Checked = false;
        }

        private void ChkFactura_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFactura.Checked) ChkTicket.Checked = false;
        }
    }
}
