﻿using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Logistica
{
    public partial class FrmInventario : Form
    {
        private TipoInventarioController tipoInventarioController;
        private MovInvController movInvController;
        private ProductoController productoController;
        private InventarioController inventarioController;
        private InventariopController inventariopController;
        private LoteController loteController;


        private TipoInventario tipoInventario;
        private Producto producto;
        private Inventario inventario;
        private Inventariop partida;
        private Categoria categoria;
        private Lote lote;
        private decimal Costo;

        private List<Inventariop> partidas;

        public FrmInventario()
        {
            InitializeComponent();
            Incializa();
        }

        private void Incializa()
        {
            tipoInventarioController = new TipoInventarioController();
            productoController = new ProductoController();
            inventarioController = new InventarioController();
            inventariopController = new InventariopController();
            loteController = new LoteController();
            movInvController = new MovInvController();


            tipoInventario = null;
            producto = null;
            lote = null;
            inventario = null;
            categoria = null;
            partida = null;
            Costo = 0;
            partidas = new List<Inventariop>(); ;
            CreaInventario();
            TxtTipoInv.Focus();
        }
        private void InsertaPartida()
        {
            if (producto == null && TxtProducto.Text.Trim().Length == 0)
            {
                Ambiente.Mensaje("Producto no encontrado");
                return;
            }
            if (producto.TieneLote && lote == null)
            {
                Ambiente.Mensaje("Seleccione el lote del articulo");
                return;
            }
            //producto = productoController.SelectOne(TxtProducto.Text.Trim());

            try
            {
                if ((bool)producto.Ocupado)
                {
                    Ambiente.Mensaje("Operación abortada, el articulo está bloqueado por otro proceso [INVENTARIOS, AJUSTES, AUTORIZACIONES, ETC]");
                    return;
                }
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.Message);
            }
            var partida = new Inventariop();



            partida.InventarioId = inventario.InventarioId;
            partida.ProductoId = producto.ProductoId;
            partida.ExistenciaTeorica = producto.Stock;
            partida.ExistenciaFisica = NCantidad.Value;
            partida.Descripcion = producto.Descripcion;
            partida.Costo = producto.Costopp;
            partida.MovInvId = null;
            if (lote == null)
                partida.LoteId = null;
            else
                partida.LoteId = lote.LoteId;


            if (partida.ExistenciaTeorica > partida.ExistenciaFisica)
            {
                partida.Diferencia = partida.ExistenciaTeorica - partida.ExistenciaFisica;
                partida.Diferencia = partida.Diferencia * -1;
            }
            else
                partida.Diferencia = partida.ExistenciaFisica - partida.ExistenciaTeorica;

            partida.CostoParcial = partida.Costo * partida.Diferencia;

            //partida al grid
            Malla.Rows.Add();
            Malla.Rows[Malla.RowCount - 1].Cells[0].Value = partida.ProductoId;
            Malla.Rows[Malla.RowCount - 1].Cells[1].Value = partida.Descripcion;
            Malla.Rows[Malla.RowCount - 1].Cells[2].Value = partida.ExistenciaFisica;
            partidas.Add(partida);
            ResetPartida();
            //CalculaTotales();
        }

        private void ResetPartida()
        {
            producto = null;
            lote = null;
            TxtProducto.Text = "";
            TxtLote.Text = "";
            TxtDescrip.Text = "";
            NCantidad.Value = 1;
            TxtFechaDoc.Text = DateTime.Now.ToString("dd-MM-yyyy");
            TxtProducto.Focus();
        }

        private void CreaInventario()
        {
            TxtSituacion.Text = "PENDIENTE";
            inventario = new Inventario();
            inventario.TipoInventario = "NO DEFINIDO";
            inventario.TipoInventarioId = 1;
            inventario.EstadoDocId = "PEN";
            inventario.FechaBloqueo = DateTime.Now;
            inventario.UsuarioBloqueoId = null;
            inventario.UsuarioAutorizacionId = null;
            inventario.FechaAutorizacion = DateTime.Now;
            inventario.CreatedAt = DateTime.Now;
            inventario.CreatedBy = Ambiente.LoggedUser.UsuarioId;
            inventario.EstacionId = Ambiente.Estacion.EstacionId;
            inventarioController.InsertOne(inventario);

            TxtFechaDoc.Text = DateTime.Now.ToString("dd-MM-yyyy");

        }




        private void LimpiarFilaMalla(int index)
        {
            Malla.Rows[index].Cells[0].Value = null;
            Malla.Rows[index].Cells[1].Value = null;
            Malla.Rows[index].Cells[2].Value = null;
        }
        private void Incrementa(int rowIndex)
        {
            try
            {
                if (partidas.Count > 0)
                {
                    partidas[rowIndex].ExistenciaFisica++;
                    Malla.Rows[rowIndex].Cells[2].Value = partidas[rowIndex].ExistenciaFisica;
                    //CalculaTotales();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(ex.Message);
            }

        }
        private void Decrementa(int rowIndex)
        {
            try
            {
                if (partidas.Count > 0)
                {
                    if (partidas[rowIndex].ExistenciaFisica >= 1)
                    {
                        partidas[rowIndex].ExistenciaFisica--;
                        Malla.Rows[rowIndex].Cells[2].Value = partidas[rowIndex].ExistenciaFisica;
                        // CalculaTotales();
                    }
                    else
                        Ambiente.Mensaje("Operación denegada, solo cantidades positivas");
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(ex.Message);
            }

        }
        private void EliminaPartida(int rowIndex, string descrip)
        {
            if (Ambiente.Pregunta("Realmente quiere borrar: " + descrip))
            {
                if (partidas.Count > 0 && rowIndex >= 0)
                {
                    Malla.Rows.RemoveAt(rowIndex);
                    partidas.RemoveAt(rowIndex);
                    ReCargaGrid();
                }
            }

        }
        private void ActualizaCantidad(int cant, int rowIndex)
        {
            try
            {
                if ((rowIndex <= partidas.Count - 1) && cant > 0)
                {
                    partidas[rowIndex].ExistenciaFisica = cant;
                    Malla.Rows[rowIndex].Cells[2].Value = cant;
                    //CalculaTotales();
                }
                else
                {
                    partidas[rowIndex].ExistenciaFisica = 1;
                    Malla.Rows[rowIndex].Cells[2].Value = 1;
                    //CalculaTotales();
                    Ambiente.Mensaje("Operación denegada, solo cantidades positivas");
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(ex.Message);
            }


        }
        private void ReCargaGrid()
        {
            int index = 0;
            foreach (var partida in partidas)
            {

                //partida al grid
                Malla.Rows[index].Cells[0].Value = partida.ProductoId;
                Malla.Rows[index].Cells[1].Value = partida.Descripcion;
                Malla.Rows[index].Cells[2].Value = partida.ExistenciaFisica;

                index++;
            }
        }


        private void CerrarInventario(bool pendiente)
        {
            if (partidas.Count > 0)
            {
                if (tipoInventario == null)
                {
                    Ambiente.Mensaje("Operación denegada, seleccione tipo inventario");
                    return;
                }
                if (tipoInventario.Bloquea)
                {
                    if (Ambiente.Pregunta("Todos los productos invetariados se bloquearán hasta la aprobacion del inventario. Continuar"))
                    {

                        foreach (var p in partidas)
                        {
                            producto = productoController.SelectOne(p.ProductoId);
                            if (producto != null)
                            {
                                producto.Ocupado = true;
                                productoController.Update(producto);
                            }
                        }

                        inventario.TipoInventario = tipoInventario.Descripcion;
                        inventario.TipoInventarioId = tipoInventario.TipoInventarioId;
                        inventario.EstadoDocId = "PEN";
                        inventario.FechaBloqueo = DateTime.Now;
                        inventario.UsuarioBloqueoId = Ambiente.LoggedUser.UsuarioId;

                        if (inventarioController.Update(inventario))
                        {
                            if (GuardaPartidas())
                            {
                                if (!pendiente)
                                {
                                    // AfectaLotes();
                                    // AfectaStock();
                                    // AfectaMovsInv();
                                    if (!Ambiente.CancelaProceso)
                                    {
                                        Ambiente.stiReport = new Stimulsoft.Report.StiReport();
                                        Ambiente.stiReport.LoadPackedReportFromString(Ambiente.InformeInvetarios.Codigo);
                                        Ambiente.stiReport.Dictionary.Variables["InventarioId"].ValueObject = inventario.InventarioId;
                                        Ambiente.S1 = Ambiente.Empresa.DirectorioInverarios + "INVENTARIO-" + inventario.InventarioId + ".PDF";
                                        Ambiente.stiReport.Render(false);
                                        Ambiente.stiReport.ExportDocument(Stimulsoft.Report.StiExportFormat.Pdf, Ambiente.S1);
                                        Process.Start(Ambiente.S1);
                                        Close();
                                    }
                                    else
                                        Ambiente.Mensaje("Proceso concluido con inconsistencias");
                                    //ResetPDD();
                                }
                                else
                                {
                                    PendienteOdescarta();
                                }
                            }
                            else
                            {
                                Ambiente.Mensaje("Algo salio mal con: if (GuardaPartidas())");
                            }
                        }
                        else
                        {
                            Ambiente.Mensaje("Algo salio mal con: if (traspasoController.Update(devolucion))");
                        }
                    }

                }
                else
                {
                    inventario.TipoInventario = tipoInventario.Descripcion;
                    inventario.TipoInventarioId = tipoInventario.TipoInventarioId;
                    if (pendiente) inventario.EstadoDocId = "PEN"; else inventario.EstadoDocId = "CON";
                    inventario.FechaBloqueo = DateTime.Now;
                    inventario.UsuarioBloqueoId = null;
                    inventario.UsuarioAutorizacionId = Ambiente.LoggedUser.UsuarioId;
                    inventario.UsuarioAutorizacion = Ambiente.LoggedUser.Nombre;
                    inventario.FechaAutorizacion = DateTime.Now;
                    //inventario.CreatedAt = DateTime.Now;
                    //inventario.CreatedBy = Ambiente.LoggedUser.UsuarioId;

                    if (inventarioController.Update(inventario))
                    {
                        if (GuardaPartidas())
                        {
                            if (!pendiente)
                            {
                                AfectaLotes();
                                AfectaMovsInv();
                                AfectaStock();

                                if (!Ambiente.CancelaProceso)
                                {

                                    Ambiente.stiReport = new Stimulsoft.Report.StiReport();
                                    Ambiente.stiReport.LoadPackedReportFromString(Ambiente.InformeInvetarios.Codigo);
                                    Ambiente.stiReport.Dictionary.Variables["InventarioId"].ValueObject = inventario.InventarioId;
                                    Ambiente.S1 = Ambiente.Empresa.DirectorioInverarios + "INVENTARIO-" + inventario.InventarioId + ".PDF";
                                    Ambiente.stiReport.Render(false);
                                    Ambiente.stiReport.ExportDocument(Stimulsoft.Report.StiExportFormat.Pdf, Ambiente.S1);
                                    Process.Start(Ambiente.S1);
                                    Close();
                                }
                                else
                                    Ambiente.Mensaje("Proceso concluido con inconsistencias");
                                //ResetPDD();
                            }
                            else
                            {
                                PendienteOdescarta();
                            }
                        }
                        else
                        {
                            Ambiente.Mensaje("Algo salio mal con: if (GuardaPartidas())");
                        }
                    }
                    else
                    {
                        Ambiente.Mensaje("Algo salio mal con: if (traspasoController.Update(devolucion))");
                    }

                }




            }
        }


        private void AfectaMovsInv()
        {
            foreach (var p in partidas)
            {


                //**************MOVIMIENTO DE INVENTARIO****************//
                var movInv = new MovInv();
                movInv.FechaOperacion = DateTime.Now;
                movInv.ConceptoMovsInvId = p.Diferencia > 0 ? "AIN" : "DIN";
                movInv.ProductoId = p.ProductoId;
                movInv.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                movInv.ProveedorId = "";
                movInv.ClienteId = "";
                movInv.EstacionId = Ambiente.Estacion.EstacionId;
                movInv.ReferenciaId = inventario.InventarioId;
                movInv.ReferenciapId = p.InventariopId;
                movInv.Es = p.Diferencia > 0 ? "E" : "S";
                movInv.Cantidad = p.Diferencia;
                producto = productoController.SelectOne(p.ProductoId);
                movInv.UltimoCosto = producto.PrecioCompra;
                movInv.Costopp = producto.Costopp;
                movInv.Valor = p.Diferencia * producto.Costopp;
                movInv.StockAlMomento = producto.Stock;
                movInv.PrecioVta = producto.Precio1;
                movInv.Afectacion = movInv.Es.Equals("E") ? 1 : -1;
                movInv.IsDeleted = false;
                movInv.TieneLote = p.LoteId == null ? false : true;
                lote = movInv.TieneLote == true ? loteController.SelectOne((int)p.LoteId) : null;
                movInv.NoLote = movInv.TieneLote == true ? lote.NoLote : "";
                movInv.Caducidad = movInv.TieneLote == true ? lote.Caducidad : DateTime.Now;
                movInv.CreatedAt = DateTime.Now;
                Ambiente.CancelaProceso = !movInvController.InsertOne(movInv);
            }
        }
        private void AfectaStock()
        {
            foreach (var p in partidas)
            {
                var prod = productoController.SelectOne(p.ProductoId);
                prod.Stock += p.Diferencia;
                Ambiente.CancelaProceso = !productoController.Update(prod);
            }
        }
        private void AfectaLotes()
        {
            foreach (var p in partidas)
            {
                if (p.LoteId != null)
                {

                    var l = loteController.SelectOne((int)p.LoteId);
                    if (l != null)
                    {
                        l.StockRestante += p.Diferencia;
                        Ambiente.CancelaProceso = !loteController.Update(l);
                    }
                }

            }
        }




        private void EliminaInventario()
        {
            if (inventario != null)
            {
                inventarioController.DeletePartidas(inventario);
                inventarioController.Delete(inventario);
            }
        }


        private bool GuardaPartidas()
        {
            return inventariopController.InsertRange(partidas);
        }
        private void PendienteOdescarta()
        {
            if (partidas.Count > 0 && inventario.EstadoDocId.Equals("PEN"))
            {
                if (Ambiente.Pregunta("Quiere dejar el inventario como pendiente"))
                    CerrarInventario(true);
                else
                    EliminaInventario();
            }
            else
                EliminaInventario();
            Close();
        }


        private void TxtTipoInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtTipoInv.Text, (int)Ambiente.TipoBusqueda.TipoInvetario))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        tipoInventario = form.TipoInventario;
                        if (!tipoInventario.Bloquea)
                            TxtAprobadoPor.Text = Ambiente.LoggedUser.Nombre;
                        else
                            TxtAprobadoPor.Text = "";
                        TxtTipoInv.Text = tipoInventario.Descripcion;
                    }
                }
            }
        }

        private void TxtCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    using (var form = new FrmBusqueda(TxtFechaDoc.Text, (int)Ambiente.TipoBusqueda.Categorias))
            //    {
            //        if (form.ShowDialog() == DialogResult.OK)
            //        {
            //            categoria = form.Categoria;
            //            TxtFechaDoc.Text = categoria.Nombre;
            //        }
            //    }
            //}
        }

        private void TxtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                producto = productoController.SelectOne(TxtProducto.Text);
                if (producto != null)
                {
                    TxtProducto.Text = producto.ProductoId;
                    TxtDescrip.Text = producto.Descripcion;
                    TxtLote.Text = producto.ProductoId;
                    TxtLote.Focus();
                    return;
                }
                using (var form = new FrmBusqueda(TxtProducto.Text, (int)Ambiente.TipoBusqueda.Productos))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        producto = form.Producto;
                        TxtProducto.Text = producto.ProductoId;
                        TxtDescrip.Text = producto.Descripcion;
                        TxtLote.Text = producto.ProductoId;
                        TxtLote.Focus();
                    }
                }
            }
        }

        private void TxtLote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtLote.Text, (int)Ambiente.TipoBusqueda.Lotes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        lote = form.Lote;
                        TxtLote.Text = lote.NoLote;
                    }
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            InsertaPartida();
        }


        private void Malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Malla.CurrentCell.Value == null)
                return;


            if (Malla.CurrentCell.ColumnIndex == 2)
            {
                //Cantidad
                try
                {
                    ActualizaCantidad(int.Parse(Malla.CurrentCell.Value.ToString()), e.RowIndex);
                    ReCargaGrid();
                    TxtProducto.Focus();
                }
                catch (Exception ex)
                {

                    Ambiente.Mensaje(ex.Message);
                }
            }
        }
        private void ColumnCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }
        private void Malla_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnCant_KeyPress);
            if (Malla.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnCant_KeyPress);
                }
            }
        }

        private void Malla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
                Incrementa(Malla.CurrentCell.RowIndex);
            else if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
                Decrementa(Malla.CurrentCell.RowIndex);
            else if (e.KeyCode == Keys.Delete)
            {
                if (Malla.Rows[Malla.CurrentCell.RowIndex].Cells[0].Value != null)
                    EliminaPartida(Malla.CurrentCell.RowIndex, Malla.Rows[Malla.CurrentCell.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            CerrarInventario(false);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            PendienteOdescarta();
        }
    }
}
