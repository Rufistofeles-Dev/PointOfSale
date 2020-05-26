﻿using PointOfSale.CFDI33;
using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
using PointOfSale.Views.Modulos.Catalogos;
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

namespace PointOfSale.Views.Modulos.PuntoVenta
{
    public partial class FrmFacturas : Form
    {
        private VentaController ventaController;
        private ClienteController clienteController;
        private EmpresaController empresaController;
        private Cliente cliente;
        private Empresa empresa;
        private CFDI oCFDI;
        private StiReport report;
        private Reporte reporte;
        private ReporteController reporteController;
        private DymErrorController dymErrorController;

        List<Venta> facturas;
        public FrmFacturas()
        {
            InitializeComponent();
            ventaController = new VentaController();
            clienteController = new ClienteController();
            empresaController = new EmpresaController();
            reporteController = new ReporteController();
            dymErrorController = new DymErrorController();
            oCFDI = new CFDI();
            cliente = null;
            empresa = empresaController.SelectTopOne();
            reporte = reporteController.SelectOneByName(empresa.FormatoParaFacturas);
        }


        private void CargaGrid()
        {

            facturas = ventaController.SelectFacturas(DpFechaIni.Value.Date, DpFechaFin.Value.Date, ChkSinTimbrar.Checked);

            Malla.Rows.Clear();
            foreach (var f in facturas)
            {
                Malla.Rows.Add();
                cliente = clienteController.SelectOne(f.ClienteId);
                Malla.Rows[Malla.RowCount - 1].Cells[0].Value = f.VentaId;
                Malla.Rows[Malla.RowCount - 1].Cells[1].Value = f.NoRef;
                Malla.Rows[Malla.RowCount - 1].Cells[2].Value = f.CreatedAt;
                Malla.Rows[Malla.RowCount - 1].Cells[3].Value = cliente.RazonSocial.Trim().Length == 0 ? cliente.Negocio : cliente.RazonSocial;
                Malla.Rows[Malla.RowCount - 1].Cells[4].Value = f.Total;
                Malla.Rows[Malla.RowCount - 1].Cells[5].Value = f.EstatusSat;
                Malla.Rows[Malla.RowCount - 1].Cells[6].Value = f.UuId;
                if (f.EstatusSat != null)
                {


                    if (f.EstatusSat.Equals("Cancelado"))
                        Malla.Rows[Malla.RowCount - 1].DefaultCellStyle.BackColor = Color.Red;
                    else if (f.EstatusSat.Equals("Vigente"))
                        Malla.Rows[Malla.RowCount - 1].DefaultCellStyle.BackColor = Color.LimeGreen;
                    else if (f.EstatusSat.Equals("Pendiente"))
                        Malla.Rows[Malla.RowCount - 1].DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }

        private void FrmFacturas_Load(object sender, EventArgs e)
        {
            CargaGrid();
        }

        private void BtnCambiarCliente_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount > 0)
            {
                int index = Malla.CurrentCell.RowIndex;
                int i = 0;
                foreach (var f in facturas)
                {
                    if (index == i)
                    {
                        cliente = clienteController.SelectOne(f.ClienteId);
                        oCFDI.Venta = f;
                        var c = new FrmClientes(cliente);
                        c.MdiParent = MdiParent;
                        c.Show();
                    }
                    i++;
                }
            }

        }

        private void BtnFacturar_Click(object sender, EventArgs e)
        {

            if (Malla.RowCount > 0)
            {
                int index = Malla.CurrentCell.RowIndex;
                int i = 0;
                foreach (var f in facturas)
                {
                    if (index == i && f.EsFacturaGlobal)
                        oCFDI.Venta = f;

                    i++;
                }
            }



            if (oCFDI.Venta == null)
            {

                Ambiente.Mensaje("Primero actualice los datos del cliente");
                return;
            }
            if (oCFDI.Venta.UuId != null)
            {
                Ambiente.Mensaje("Este documento ya es un CDFI");
                return;
            }
            if (!Ambiente.LoggedUser.Facturar)
            {
                Ambiente.Mensaje("Operacion denegada. No tienes permiso para operar esta vista.");
                return;
            }

            if (oCFDI.Venta == null)
            {
                Ambiente.Mensaje("Proceso abortado, no se encontró ninguna venta seleccionada");
                return;
            }
            //Si no seleccionó otro cliente, se recupera el de la venta
            if (cliente == null)
                cliente = clienteController.SelectOne(oCFDI.Venta.ClienteId);

            //verificar que no sea pago con puntos
            if (oCFDI.Venta.PuntosAplicados || oCFDI.Venta.DescXpuntos > 0)
            {
                Ambiente.Mensaje("Proceso abortado, el documento se cobró con puntos.");
                return;
            }

            //valida rfc
            if (Ambiente.RFCvalido(cliente.Rfc))
            {
                //Timbra la venta
                if (oCFDI.Facturar())
                {
                    //  Ambiente.SaveAndPrintFactura(venta, true, false);
                    Ambiente.SaveAndPrintFactura(oCFDI.Venta, true, false);

                    Close();
                }
                else
                {
                    Ambiente.Mensaje("Algo salió mal al facturar la venta");
                    Close();
                }
            }
            else
                Ambiente.Mensaje("El rfc del cliente está mal formado");




            /////********************************************************



        }



        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnFiltrarFecha_Click(object sender, EventArgs e)
        {
            CargaGrid();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void Cancelar()
        {
            if (Malla.RowCount == 0)
                return;

            int ventaId = (int)Malla.Rows[Malla.CurrentCell.RowIndex].Cells[0].Value;
            if (ventaId > 0)
            {
                var venta = ventaController.SelectOne(ventaId);
                if (venta != null)
                {
                    if (Ambiente.Pregunta("Realmente quieres cancelar la factura " + venta.NoRef))
                    {
                        oCFDI.Venta = venta;
                        oCFDI.Cancelar();
                    }
                }
                else
                {
                    Ambiente.Mensaje("Primero selecciona una venta");
                }
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ActualizarEstatusSAT();
        }
        private void ActualizarEstatusSAT()
        {

            try
            {
                var facturas = ventaController.SelectFacturasPendientesConfirmar();
                if (facturas.Count > 0)
                {
                    foreach (var f in facturas)
                    {
                        oCFDI.Venta = f;
                        oCFDI.ActualizarStatusSAT();
                    }
                }
            }
            catch (Exception ex)
            {
                var error = new DymError();
                error.Message = ex.Message;
                error.ToString = ex.ToString();
                error.VentaId = "NULL";
                error.LoggedUser = Ambiente.LoggedUser.UsuarioId;
                error.CreatedAt = DateTime.Now;
                dymErrorController.InsertOne(error);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!Worker.IsBusy)
                Worker.RunWorkerAsync();
        }

       
        private void Enviar()
        {
            if (Malla.RowCount == 0)
                return;

            int ventaId = (int)Malla.Rows[Malla.CurrentCell.RowIndex].Cells[0].Value;
            if (ventaId > 0)
            {
                var venta = ventaController.SelectOne(ventaId);
                var cliente = clienteController.SelectOne(venta.ClienteId);
                if (venta != null)
                {
                    if (Ambiente.Pregunta("Confirma el envío para " + cliente.Correo))
                        Ambiente.EnviarFactura(Ambiente.Empresa, venta, cliente.Correo);
                }
                else
                {
                    Ambiente.Mensaje("Primero selecciona una venta");
                }
            }

        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            Enviar();
        }
    }
}
