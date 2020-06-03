﻿using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Logistica
{
    public partial class FrmSalidasPorTraspaso : Form
    {
        //Controladores
        private ProductoController productoController;
        private SucursalController sucursalController;
        private LoteController loteController;
        private TraspasoController traspasoController;
        private TraspasopController traspasopController;
        private MovInvController movInvController;
        private EmpresaController empresaController;
        //Listas 
        List<Traspasop> partidas;

        // Objetos
        private Traspaso traspaso;
        private Producto producto;
        private Sucursal sucursalO;
        private Sucursal sucursalD;
        private Lote lote;
        private Empresa empresa;


        //Variables
        decimal Subtotal = 0;
        decimal Impuesto = 0;
        private int SigPartida = 0;
        private const int NPARTIDAS = 400;
        private bool sobreGrid = false;

        public FrmSalidasPorTraspaso()
        {
            InitializeComponent();
            ResetPDT();
        }


        #region METODOS

        private void ResetPDT()
        {
            productoController = new ProductoController();
            sucursalController = new SucursalController();
            loteController = new LoteController();
            traspasoController = new TraspasoController();
            traspasopController = new TraspasopController();
            movInvController = new MovInvController();
            empresaController = new EmpresaController();
            //listas
            partidas = new List<Traspasop>();

            // Objetos
            traspaso = null;
            empresa = empresaController.SelectTopOne();
            producto = null;
            sucursalO = null;
            lote = null;

            //Variables
            Subtotal = 0;
            Impuesto = 0;
            sobreGrid = false;
            SigPartida = 0;

            TxtOrigen.Text = "";
            TxtDestino.Text = "";
            TxtDocumento.Text = "";
            TxtProductoId.Text = "";
            NCantidad.Value = 1;
            TxtImpuestos.Text = "";
            TxtSubtotal.Text = "";
            TxtTotal.Text = "";
            TxtDescripcion.Text = "";
            TxtLoteId.Text = "";
            TxtNoLote.Text = "";
            TxtCaducidad.Text = "";

            Malla.Rows.Clear();
            MallaLote.Rows.Clear();
            for (int i = 0; i < NPARTIDAS; i++)
            {
                Malla.Rows.Add();
                Malla.Rows[i].Cells[3].Style.BackColor = Color.Yellow;
                Malla.Rows[i].Cells[4].Style.BackColor = Color.Yellow;
                Malla.Rows[i].Cells[6].Style.BackColor = Color.Yellow;
                Malla.Rows[i].Cells[8].Style.BackColor = Color.Yellow;
            }

            CreaTraspaso();
        }
        private void CreaTraspaso()
        {
            traspaso = new Traspaso();
            traspaso.FechaDocumento = DateTime.Now;
            traspaso.SucursalOrigenId = null;
            traspaso.SucursalOrigenName = "SIN DATOS";
            traspaso.SerieOrigen = "";
            traspaso.SucursalDestinoId = null;
            traspaso.SucursalDestinoName = "SIN DATOS";
            traspaso.SerieDestino = "";
            traspaso.TipoDocId = "STR";
            traspaso.EstadoDocId = "PEN";
            traspaso.CreatedAt = DateTime.Now;
            traspaso.CreatedBy = Ambiente.LoggedUser.UsuarioId;
            traspaso.SentBy = Ambiente.LoggedUser.UsuarioId;
            traspaso.Subtotal = 0;
            traspaso.Impuesto = 0;
            traspaso.Total = 0;
            traspasoController.InsertOne(traspaso);

        }
        private void LlenaDatosProducto()
        {

            TxtProductoId.Text = producto.ProductoId;
            TxtDescripcion.Text = producto.Descripcion;
            CargaMallaLotes(producto);
        }
        private void CargaMallaLotes(Producto producto)
        {
            MallaLote.Rows.Clear();
            if (producto.TieneLote)
            {
                var lotesProd = loteController.SelecByProduc(producto);
                MallaLote.Rows.Clear();

                foreach (var l in lotesProd)
                {
                    MallaLote.Rows.Add();
                    MallaLote.Rows[MallaLote.RowCount - 1].Cells[0].Value = l.LoteId;
                    MallaLote.Rows[MallaLote.RowCount - 1].Cells[1].Value = l.NoLote;
                    MallaLote.Rows[MallaLote.RowCount - 1].Cells[2].Value = l.Caducidad;
                    MallaLote.Rows[MallaLote.RowCount - 1].Cells[3].Value = Math.Round(l.StockRestante, 0);
                }
            }
        }
        private void CalculaTotales()
        {
            Subtotal = 0;
            Impuesto = 0;
            foreach (var partida in partidas)
            {
                partida.Subtotal = partida.Cantidad * partida.Precio;
                partida.ImporteImpuesto1 = partida.Subtotal * partida.Impuesto1;
                partida.ImporteImpuesto2 = partida.Subtotal * partida.Impuesto2;
                partida.Total = partida.Subtotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
                Subtotal += partida.Subtotal;
                Impuesto += partida.ImporteImpuesto1 + partida.ImporteImpuesto2;

                // reflejar totales
                TxtSubtotal.Text = Ambiente.FDinero(Subtotal.ToString());
                TxtImpuestos.Text = Ambiente.FDinero(Impuesto.ToString());
                TxtTotal.Text = Ambiente.FDinero((Subtotal + Impuesto).ToString());
            }

        }
        private void InsertaPartida()
        {
            if (producto == null && TxtProductoId.Text.Trim().Length == 0)
            {
                Ambiente.Mensaje("Producto no encontrado");
                return;
            }

            producto = productoController.SelectOne(TxtProductoId.Text.Trim());
            if (producto == null)
                return;

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


            if (traspaso != null)
            {
                if (traspaso.TraspasoId == 0)
                {
                    Ambiente.Mensaje("El traspaso no existe");
                    return;
                }
            }

            var partida = new Traspasop();
            partida.TraspasoId = traspaso.TraspasoId;
            partida.ProductoId = producto.ProductoId;
            partida.Descripcion = producto.Descripcion;
            partida.Cantidad = NCantidad.Value;
            partida.Stock = producto.Stock;
            partida.Precio = producto.Precio1;
            partida.ImpuestoId1 = producto.Impuesto1Id;
            partida.ImpuestoId2 = producto.Impuesto2Id;
            partida.Impuesto1 = Ambiente.GetTasaImpuesto(partida.ImpuestoId1);
            partida.Impuesto2 = Ambiente.GetTasaImpuesto(partida.ImpuestoId2);
            //Totales de la partida
            partida.Subtotal = partida.Cantidad * partida.Precio;
            partida.ImporteImpuesto1 = partida.Subtotal * partida.Impuesto1;
            partida.ImporteImpuesto2 = partida.Subtotal * partida.Impuesto2;
            partida.Total = partida.Subtotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;


            if (lote != null)
            {

                if (lote.StockRestante >= partida.Cantidad)
                {
                    partida.LoteId = lote.LoteId;
                    partida.NoLote = lote.NoLote;
                    partida.Caducidad = lote.Caducidad;
                }
                else
                {
                    Ambiente.Mensaje("Proceso abortado, el lote seleccionado no tiene suficiente stock.");
                    return;
                }
            }
            else
            {
                partida.LoteId = null;
                partida.NoLote = null;
                partida.Caducidad = null;
            }



            //partida al grid
            Malla.Rows[SigPartida].Cells[0].Value = partida.Descripcion;
            Malla.Rows[SigPartida].Cells[1].Value = partida.Stock;
            Malla.Rows[SigPartida].Cells[2].Value = partida.Cantidad;
            Malla.Rows[SigPartida].Cells[3].Value = partida.Precio;
            Malla.Rows[SigPartida].Cells[4].Value = partida.Impuesto1;
            Malla.Rows[SigPartida].Cells[5].Value = partida.Impuesto2;
            Malla.Rows[SigPartida].Cells[6].Value = partida.Subtotal;
            Malla.Rows[SigPartida].Cells[7].Value = partida.Subtotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
            Malla.Rows[SigPartida].Cells[8].Value = partida.NoLote;
            Malla.Rows[SigPartida].Cells[9].Value = partida.Caducidad;
            partidas.Add(partida);
            ResetPartida();
            CalculaTotales();
        }
        private void LimpiarFilaMalla(int index)
        {
            Malla.Rows[index].Cells[0].Value = null;
            Malla.Rows[index].Cells[1].Value = null;
            Malla.Rows[index].Cells[2].Value = null;
            Malla.Rows[index].Cells[3].Value = null;
            Malla.Rows[index].Cells[4].Value = null;
            Malla.Rows[index].Cells[5].Value = null;
            Malla.Rows[index].Cells[6].Value = null;
            Malla.Rows[index].Cells[7].Value = null;
            Malla.Rows[index].Cells[8].Value = null;
            Malla.Rows[index].Cells[9].Value = null;
        }
        private void Incrementa(int rowIndex)
        {
            if (partidas.Count > 0)
            {
                partidas[rowIndex].Cantidad++;
                Malla.Rows[rowIndex].Cells[2].Value = partidas[rowIndex].Cantidad;
                CalculaTotales();
            }
        }
        private void Decrementa(int rowIndex)
        {
            if (partidas.Count > 0)
            {
                if (partidas[rowIndex].Cantidad > 1)
                {
                    partidas[rowIndex].Cantidad--;
                    Malla.Rows[rowIndex].Cells[2].Value = partidas[rowIndex].Cantidad;
                    CalculaTotales();
                }
                else
                    Ambiente.Mensaje("Operación denegada, solo cantidades positivas");
            }
        }
        private void ActualizaCantidad(decimal cant, int rowIndex)
        {
            if ((rowIndex <= partidas.Count - 1) && cant > 0)
            {
                partidas[rowIndex].Cantidad = cant;
                Malla.Rows[rowIndex].Cells[2].Value = cant;
                CalculaTotales();
            }
            else
            {
                partidas[rowIndex].Cantidad = 1;
                Malla.Rows[rowIndex].Cells[2].Value = 1;
                CalculaTotales();
                Ambiente.Mensaje("Operación denegada, solo cantidades positivas");
            }
        }
        private void ResetPartida()
        {
            producto = null;
            TxtProductoId.Text = "";
            TxtLoteId.Text = "";
            TxtNoLote.Text = "";
            TxtCaducidad.Text = "";
            TxtDescripcion.Text = "";
            NCantidad.Value = 1;
            MallaLote.Rows.Clear();
            SigPartida++;
            TxtLoteId.Text = "";
            TxtNoLote.Text = "";
            TxtCaducidad.Text = "";
            lote = null;
            TxtProductoId.Focus();
        }
        private void EliminaTraspaso()
        {
            if (traspaso != null)
            {
                traspasoController.DeletePartidas(traspaso);
                traspasoController.Delete(traspaso.TraspasoId);
            }
        }
        private void EliminaPartida(int rowIndex, string descrip)
        {
            if (Ambiente.Pregunta("Realmente quiere borrar: " + descrip))
            {
                if (partidas.Count > 0 && rowIndex >= 0)
                {
                    partidas.RemoveAt(rowIndex);
                    SigPartida -= 1;
                    LimpiarFilaMalla(SigPartida);
                    ReCargaGrid();
                    CalculaTotales();
                }
            }

        }
        private void ReCargaGrid()
        {
            int index = 0;
            foreach (var partida in partidas)
            {
                //partida al grid
                Malla.Rows[index].Cells[0].Value = partida.Descripcion;
                Malla.Rows[index].Cells[1].Value = partida.Stock;
                Malla.Rows[index].Cells[2].Value = partida.Cantidad;
                Malla.Rows[index].Cells[3].Value = partida.Precio;
                Malla.Rows[index].Cells[4].Value = partida.Impuesto1;
                Malla.Rows[index].Cells[5].Value = partida.Impuesto2;
                Malla.Rows[index].Cells[6].Value = partida.Subtotal;
                Malla.Rows[index].Cells[7].Value = partida.Subtotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
                Malla.Rows[index].Cells[8].Value = partida.NoLote;
                Malla.Rows[index].Cells[9].Value = partida.Caducidad;
                index++;
            }
        }
        private void CerrarTraspaso(bool pendiente)
        {
            if (partidas.Count > 0)
            {
                if (sucursalO == null || sucursalD == null)
                {
                    Ambiente.Mensaje("Operación denegada, seleccione sucursales");
                    return;
                }
                if (sucursalO.SucursalId == sucursalD.SucursalId)
                {
                    Ambiente.Mensaje("Operación denegada, origen y destino son lo mismo.");
                    return;
                }
                traspaso.FechaDocumento = DpFechaDoc.Value;
                traspaso.SucursalOrigenId = sucursalO.SucursalId;
                traspaso.SucursalOrigenName = sucursalO.Nombre;
                traspaso.SerieOrigen = sucursalO.Serie;
                traspaso.Documento = TxtDocumento.Text.Trim().Length == 0 ? null : TxtDocumento.Text.Trim();
                traspaso.SucursalDestinoId = sucursalD.SucursalId;
                traspaso.SucursalDestinoName = sucursalD.Nombre;
                traspaso.SerieDestino = sucursalD.Serie;
                traspaso.TipoDocId = "TRA";
                traspaso.Enviado = true;
                if (pendiente)
                    traspaso.EstadoDocId = "PEN";
                else
                    traspaso.EstadoDocId = "CON";

                traspaso.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                traspaso.Impuesto = Impuesto;
                traspaso.Subtotal = Subtotal;
                traspaso.Total = Subtotal + Impuesto;
                if (traspasoController.Update(traspaso))
                {
                    if (GuardaPartidas())
                    {

                        RestaLotes();
                        AfectaStock();
                        AfectaMovsInv();

                        //Generar el Excel
                        if (!pendiente)
                            EnviarTraspaso(ChkMandarCat.Checked);

                        Ambiente.Mensaje("Proceso concluido con éxito");
                        ResetPDT();
                    }
                    else
                    {
                        Ambiente.Mensaje("Algo salio mal con: if (GuardaPartidas())");
                    }
                }
                else
                {
                    Ambiente.Mensaje("Algo salio mal con: if (traspasoController.Update(traspaso))");
                }
            }

        }
        private void AfectaMovsInv()
        {
            foreach (var p in partidas)
            {

                //**************MOVIMIENTO DE INVENTARIO****************//
                //var movInv = new MovInv();
                //movInv.ConceptoMovsInvId = traspaso.TipoDocId;
                //movInv.Referencia = traspaso.TraspasoId;
                //movInv.Referenciap = p.TraspasopId;
                //movInv.Es = "S";
                //movInv.Afectacion = movInv.Es.Equals("E") ? 1 : -1;
                //movInv.ProductoId = p.ProductoId;
                //movInv.Cantidad = p.Cantidad;
                //producto = productoController.SelectOne(p.ProductoId);
                //movInv.Costo = producto == null ? 0 : producto.PrecioCompra;
                //movInv.PrecioVta = producto == null ? 0 : producto.Precio1;
                //movInv.Stock = producto == null ? 0 : producto.Stock;
                //movInv.CreatedAt = DateTime.Now;
                //movInv.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                //movInv.EstacionId = Ambiente.Estacion.EstacionId;
                //movInv.IsDeleted = false;
                //Ambiente.CancelaProceso = !movInvController.InsertOne(movInv);

            }
        }
        private void AfectaStock()
        {
            foreach (var p in partidas)
            {
                var prod = productoController.SelectOne(p.ProductoId);
                prod.Stock -= p.Cantidad;
                productoController.Update(prod);
            }
        }
        private void RestaLotes()
        {
            foreach (var p in partidas)
            {
                if (p.LoteId != null)
                {
                    var l = loteController.SelectOne((int)p.LoteId);
                    if (l != null)
                    {
                        l.StockRestante -= p.Cantidad;
                        loteController.Update(l);
                    }
                }

            }
        }
        private void PendienteOdescarta()
        {
            if (partidas.Count > 0 && traspaso.EstadoDocId.Equals("PEN"))
            {
                if (Ambiente.Pregunta("Quiere dejar el traspaso como pendiente"))
                    CerrarTraspaso(true);
                else
                    EliminaTraspaso();
            }
            else
                EliminaTraspaso();
            Close();
        }
        private bool GuardaPartidas()
        {
            return traspasopController.InsertRange(partidas);
        }

        private void EnviarTraspaso(bool enviarPrecios)
        {
            try
            {
                var name = "P" + traspaso.SerieOrigen + traspaso.SerieDestino + Ambiente.JustNow();
                var file = empresa.DirectorioTrabajo + name + ".xlsx";

                Ambiente.CrearDirectorio(empresa.DirectorioTrabajo + name);

                //Escribir platillas
                Ambiente.CrearTraspasoExcel(empresa.DirectorioTrabajo + name + @"\", "PH.XLSX", traspaso);
                Ambiente.CrearTraspasopExcel(empresa.DirectorioTrabajo + name + @"\", "PD.XLSX", partidas);
                if (enviarPrecios)
                    Ambiente.CrearEnvioPreciosExcel(empresa.DirectorioTrabajo + name + @"\", "PP.XLSX");

                //Comprimir 
                Ambiente.ComprimirDirectorio(empresa.DirectorioTrabajo + name, empresa.DirectorioTraspasos + name + ".zip");
            }
            catch (Exception e)
            {
                Ambiente.Mensaje(e.ToString());
            }
        }
        #endregion


        #region EVENTOS
        private void MallaLote_SelectionChanged(object sender, EventArgs e)
        {
            if (MallaLote.Rows[MallaLote.CurrentCell.RowIndex].Cells[0].Value != null)
            {
                var loteId = (int)MallaLote.Rows[MallaLote.CurrentCell.RowIndex].Cells[0].Value;
                lote = loteController.SelectOne(loteId);
                if (lote != null)
                {
                    TxtLoteId.Text = lote.LoteId.ToString();
                    TxtNoLote.Text = lote.NoLote;
                    TxtCaducidad.Text = lote.Caducidad.ToString("dd/MM/yyyy");
                }
            }
        }
        private void TxtOrigen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtOrigen.Text, (int)Ambiente.TipoBusqueda.Sucursal))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        sucursalO = form.Sucursal;
                        TxtOrigen.Text = sucursalO.Nombre;
                    }
                }
            }
        }

        private void TxtDestino_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtDestino.Text, (int)Ambiente.TipoBusqueda.Sucursal))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        sucursalD = form.Sucursal;
                        TxtDestino.Text = sucursalD.Nombre;
                    }
                }
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            CerrarTraspaso(false);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            PendienteOdescarta();
        }

        private void Malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ActualizaCantidad(decimal.Parse(Malla.CurrentCell.Value.ToString()), e.RowIndex);
            CalculaTotales();
            TxtProductoId.Focus();
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
        private void ColumnCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }




        private void Malla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oemplus)
                Incrementa(Malla.CurrentCell.RowIndex);
            else if (e.KeyCode == Keys.OemMinus)
                Decrementa(Malla.CurrentCell.RowIndex);
            else if (e.KeyCode == Keys.Delete)
            {
                if (Malla.Rows[Malla.CurrentCell.RowIndex].Cells[3].Value != null)
                    EliminaPartida(Malla.CurrentCell.RowIndex, Malla.Rows[Malla.CurrentCell.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void Malla_MouseEnter(object sender, EventArgs e)
        {
            sobreGrid = true;
        }

        private void Malla_MouseLeave(object sender, EventArgs e)
        {
            sobreGrid = false;
        }

        private void TxtProductoId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                producto = productoController.SelectOne(TxtProductoId.Text);
                if (producto != null)
                {
                    LlenaDatosProducto();
                    NCantidad.Focus();
                    return;
                }
                using (var form = new FrmBusqueda(TxtProductoId.Text, (int)Ambiente.TipoBusqueda.Productos))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        producto = form.Producto;
                        TxtProductoId.Text = producto.ProductoId;
                    }
                }
            }
        }
        private void TxtProductoId_Leave(object sender, EventArgs e)
        {
            if (TxtProductoId.Text.Trim().Length > 0)
            {
                producto = productoController.SelectOne(TxtProductoId.Text);
                if (producto != null)
                {
                    LlenaDatosProducto();
                }
            }
            else if (TxtProductoId.Text.Trim().Length == 0 && !sobreGrid)
                TxtProductoId.Focus();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            InsertaPartida();
        }
        #endregion


    }
}
