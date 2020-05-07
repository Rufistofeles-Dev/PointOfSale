using PointOfSale.Controllers;
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
    public partial class FrmDevoliciones : Form
    {
        private ConceptoMovInvController conceptoMovInvController;
        private DevolucionpController devolucionpController;
        private DevolucionController devolucionController;
        private ProveedorController proveedorController;
        private ProductoController productoController;
        private MovInvController movInvController;
        private LoteController loteController;


        private ConceptoMovInv conceptoMovInv;
        private Devolucion devolucion;
        private Devolucionp partida;
        private Proveedor proveedor;
        private Producto producto;
        private Lote lote;

        //Listas
        private List<Devolucionp> partidas;

        //Variables
        private bool sobreGrid = false;
        private decimal Subtotal;
        private decimal Impuesto;

        public FrmDevoliciones()
        {
            InitializeComponent();
            Inicilize();
        }

        private void Inicilize()
        {
            conceptoMovInvController = new ConceptoMovInvController();
            devolucionpController = new DevolucionpController();
            devolucionController = new DevolucionController();
            proveedorController = new ProveedorController();
            productoController = new ProductoController();
            movInvController = new MovInvController();
            loteController = new LoteController();


            conceptoMovInv = null;
            devolucion = null;
            partida = null;
            proveedor = null;
            producto = null;
            lote = null;

            //Listas
            partidas = new List<Devolucionp>();

            //Variables
            sobreGrid = false;
            Subtotal = 0;
            Impuesto = 0;
            CreaDevolucion();
        }
        private void ResetPDD()
        {
            //Listas
            partidas = new List<Devolucionp>();

            conceptoMovInv = null;
            devolucion = null;
            partida = null;
            proveedor = null;
            producto = null;
            lote = null;

            //Variables
            sobreGrid = false;
            Subtotal = 0;
            Impuesto = 0;

            TxtConceptoMovInv.Text = "";
            TxtProveedor.Text = "";
            TxtDocto.Text = "";
            TxtFecha.Text = "";
            TxtProducto.Text = "";
            TxtDescrip.Text = "";
            TxtLote.Text = "";
            TxtCaducidad.Text = "";

            Malla.Rows.Clear();
            CreaDevolucion();
        }
        private void CreaDevolucion()
        {
            devolucion = new Devolucion();
            devolucion.ConceptoMovInvId = "";
            devolucion.EstadoDocId = "PEN";
            devolucion.ProveedorId = null;
            devolucion.CreatedAt = DateTime.Now;
            devolucion.CreatedBy = Ambiente.LoggedUser.UsuarioId;
            devolucion.Subtotal = 0;
            devolucion.Impuesto = 0;
            devolucion.Total = 0;
            devolucionController.InsertOne(devolucion);

        }


        private void CalculaTotales()
        {
            Subtotal = 0;
            Impuesto = 0;
            foreach (var partida in partidas)
            {
                partida.Subtotal = partida.Cantidad * partida.PrecioCompra;
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
        private void ActualizaCantidad(int cant, int rowIndex)
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
            lote = null;
            TxtProducto.Text = "";
            TxtLote.Text = "";
            TxtCaducidad.Text = "";
            TxtDescrip.Text = "";
            NCantidad.Value = 1;
            TxtProducto.Focus();
        }
        private void EliminaDevolucion()
        {
            if (devolucion != null)
            {
                devolucionController.DeletePartidas(devolucion);
                devolucionController.Delete(devolucion);
            }
        }
        private void EliminaPartida(int rowIndex, string descrip)
        {
            if (Ambiente.Pregunta("Realmente quiere borrar: " + descrip))
            {
                if (partidas.Count > 0 && rowIndex >= 0)
                {
                    partidas.RemoveAt(rowIndex);
                    LimpiarFilaMalla(rowIndex);
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
                Malla.Rows[index].Cells[3].Value = partida.PrecioCompra;
                Malla.Rows[index].Cells[4].Value = partida.Impuesto1;
                Malla.Rows[index].Cells[5].Value = partida.Impuesto2;
                Malla.Rows[index].Cells[6].Value = partida.Subtotal;
                Malla.Rows[index].Cells[7].Value = partida.Subtotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
                Malla.Rows[index].Cells[8].Value = partida.NoLote;
                Malla.Rows[index].Cells[9].Value = partida.Caducidad;
                index++;
            }
        }
        private void CerrarDevolucion(bool pendiente)
        {
            if (partidas.Count > 0)
            {
                if (conceptoMovInv == null)
                {
                    Ambiente.Mensaje("Operación denegada, seleccione tipo movimiento");
                    return;
                }
                if (conceptoMovInv.ConceptoMovInvId.Equals("DCOM") && proveedor == null)
                {
                    Ambiente.Mensaje("Operación denegada, seleccione el proveedor");
                    return;
                }

                //if (conceptoMovInv.Es.Equals("E"))
                //{
                //    Ambiente.Mensaje("Operación denegada, el tipo de movimiento no está de acuerdo con el proceso");
                //    return;
                //}

                if (pendiente) devolucion.EstadoDocId = "PEN"; else devolucion.EstadoDocId = "CON";
                devolucion.ConceptoMovInvId = conceptoMovInv.ConceptoMovInvId;
                devolucion.ProveedorId = proveedor == null ? null : proveedor.ProveedorId;
                devolucion.Impuesto = Impuesto;
                devolucion.Subtotal = Subtotal;
                devolucion.Total = Subtotal + Impuesto;

                if (devolucionController.Update(devolucion))
                {
                    if (GuardaPartidas())
                    {

                        SumaLotes();
                        AfectaStock();
                        AfectaMovsInv();
                        if (!Ambiente.CancelaProceso)
                            Ambiente.Mensaje("Proceso concluido con éxito");
                        else
                            Ambiente.Mensaje("Proceso concluido con inconsistencias");

                        ResetPDD();
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
                var movInv = new MovInv();
                movInv.ConceptoMovsInvId = "DCOM";
                movInv.NoRef = devolucion.DevolucionId;
                movInv.EntradaSalida = "S";
                movInv.IdEntrada = null;
                movInv.IdSalida = p.DevolucionpId;
                movInv.ProductoId = p.ProductoId;
                movInv.Precio = p.PrecioCompra;
                movInv.Cantidad = p.Cantidad;
                movInv.CreatedAt = DateTime.Now;
                movInv.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                Ambiente.CancelaProceso = !movInvController.InsertOne(movInv);
            }
        }
        private void AfectaStock()
        {
            foreach (var p in partidas)
            {
                var prod = productoController.SelectOne(p.ProductoId);
                prod.Stock -= p.Cantidad;
                Ambiente.CancelaProceso = !productoController.Update(prod);
            }
        }
        private void SumaLotes()
        {
            foreach (var p in partidas)
            {
                if (p.LoteId != null)
                {

                    var l = loteController.SelectOne((int)p.LoteId);
                    if (l != null)
                    {
                        l.StockRestante += p.Cantidad;
                        Ambiente.CancelaProceso = !loteController.Update(l);
                    }
                }

            }
        }

        private bool GuardaPartidas()
        {
            return devolucionpController.InsertRange(partidas);
        }



        private void TxtConceptoMovInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtConceptoMovInv.Text, (int)Ambiente.TipoBusqueda.ConceptoMovsInv))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        conceptoMovInv = form.ConceptoMovInv;
                        TxtConceptoMovInv.Text = conceptoMovInv.Descripcion;
                    }
                }
            }
        }

        private void TxtProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtProveedor.Text, (int)Ambiente.TipoBusqueda.Proveedores))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        proveedor = form.Proveedor;
                        TxtProveedor.Text = proveedor.RazonSocial.Trim().Length == 0 ? proveedor.Negocio : proveedor.RazonSocial.Trim();
                    }
                }
            }
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
                        TxtCaducidad.Text = lote.Caducidad.ToString("DD-MM-YYYY");
                    }
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            InsertaPartida();

        }
        private void InsertaPartida()
        {
            if (producto == null && TxtProducto.Text.Trim().Length == 0)
            {
                Ambiente.Mensaje("Producto no encontrado");
                return;
            }

            producto = productoController.SelectOne(TxtProducto.Text.Trim());


            if (producto == null) return;
            if (conceptoMovInv == null) return;
            var partida = new Devolucionp();

            if (producto.TieneLote)
            {
                producto.Lote = new List<Lote>();
                if (lote == null)
                {
                    Ambiente.Mensaje("Seleccione el lote del articulo");
                    return;
                }
                else
                {
                    producto.Lote.Add(lote);
                    partida.LoteId = lote.LoteId;
                    partida.NoLote = lote.NoLote;
                    partida.Caducidad = lote.Caducidad;
                }
            }

            partida.DevolucionId = devolucion.DevolucionId;
            partida.ProductoId = producto.ProductoId;
            partida.Descripcion = producto.Descripcion;
            partida.Cantidad = (int)NCantidad.Value;
            partida.Stock = (int)producto.Stock;
            partida.PrecioCompra = producto.PrecioCompra;
            partida.ImpuestoId1 = producto.Impuesto1Id;
            partida.ImpuestoId2 = producto.Impuesto2Id;
            partida.Impuesto1 = Ambiente.GetTasaImpuesto(partida.ImpuestoId1);
            partida.Impuesto2 = Ambiente.GetTasaImpuesto(partida.ImpuestoId2);
            //Totales de la partida
            partida.Subtotal = partida.Cantidad * partida.PrecioCompra;
            partida.ImporteImpuesto1 = partida.Subtotal * partida.Impuesto1;
            partida.ImporteImpuesto2 = partida.Subtotal * partida.Impuesto2;
            partida.Total = partida.Subtotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;




            //partida al grid
            Malla.Rows.Add();
            Malla.Rows[Malla.RowCount - 1].Cells[0].Value = partida.Descripcion;
            Malla.Rows[Malla.RowCount - 1].Cells[1].Value = partida.Stock;
            Malla.Rows[Malla.RowCount - 1].Cells[2].Value = partida.Cantidad;
            Malla.Rows[Malla.RowCount - 1].Cells[3].Value = partida.PrecioCompra;
            Malla.Rows[Malla.RowCount - 1].Cells[4].Value = partida.Impuesto1;
            Malla.Rows[Malla.RowCount - 1].Cells[5].Value = partida.Impuesto2;
            Malla.Rows[Malla.RowCount - 1].Cells[6].Value = partida.Subtotal;
            Malla.Rows[Malla.RowCount - 1].Cells[7].Value = partida.Subtotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
            Malla.Rows[Malla.RowCount - 1].Cells[8].Value = partida.NoLote;
            Malla.Rows[Malla.RowCount - 1].Cells[9].Value = partida.Caducidad;
            partidas.Add(partida);
            ResetPartida();
            CalculaTotales();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            CerrarDevolucion(false);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            PendienteOdescarta();
        }
        private void PendienteOdescarta()
        {
            if (partidas.Count > 0 && devolucion.EstadoDocId.Equals("PEN"))
            {
                if (Ambiente.Pregunta("Quiere dejar la devolucion como pendiente"))
                    CerrarDevolucion(true);
                else
                    EliminaDevolucion();
            }
            else
                EliminaDevolucion();
            Close();
        }

        private void Malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ActualizaCantidad(int.Parse(Malla.CurrentCell.Value.ToString()), e.RowIndex);
            CalculaTotales();
            TxtProducto.Focus();
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
    }
}
