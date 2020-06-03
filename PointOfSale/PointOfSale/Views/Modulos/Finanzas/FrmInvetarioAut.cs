using PointOfSale.Controllers;
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

namespace PointOfSale.Views.Modulos.Finanzas
{
    public partial class FrmInvetarioAut : Form
    {

        private TipoInventarioController tipoInventarioController;
        private MovInvController movInvController;
        private ProductoController productoController;
        private InventarioController inventarioController;
        private InventariopController inventariopController;
        private LoteController loteController;
        private UsuarioController usuarioController;


        private TipoInventario tipoInventario;
        private Producto producto;
        private Inventario inventario;
        private Inventariop partida;
        private Categoria categoria;
        private Lote lote;
        private Usuario usuario;
        private decimal Costo;

        private List<Inventariop> partidas;

        public FrmInvetarioAut()
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
            usuarioController = new UsuarioController();

            tipoInventario = null;
            producto = null;
            lote = null;
            inventario = null;
            categoria = null;
            partida = null;
            usuario = null;
            Costo = 0;
            partidas = new List<Inventariop>(); ;
            TxtInventario.Focus();
        }
        private void Malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Malla.CurrentCell.Value == null)
                return;


            if (Malla.CurrentCell.ColumnIndex == 3)
            {
                //Cantidad
                try
                {
                    ActualizaCantidad(int.Parse(Malla.CurrentCell.Value.ToString()), e.RowIndex);
                    ReCargaGrid();
                }
                catch (Exception ex)
                {

                    Ambiente.Mensaje(ex.Message);
                }

            }
        }
        private void Decrementa(int rowIndex)
        {
            try
            {
                if (partidas.Count > 0)
                {
                    if (partidas[rowIndex].ExistenciaFisica > 1)
                    {
                        partidas[rowIndex].ExistenciaFisica--;
                        Malla.Rows[rowIndex].Cells[3].Value = partidas[rowIndex].ExistenciaFisica;

                        if (partidas[rowIndex].ExistenciaTeorica > partidas[rowIndex].ExistenciaFisica)
                        {
                            partidas[rowIndex].Diferencia = partidas[rowIndex].ExistenciaTeorica - partidas[rowIndex].ExistenciaFisica;
                            partidas[rowIndex].Diferencia = partidas[rowIndex].Diferencia * -1;
                        }
                        else
                            partidas[rowIndex].Diferencia = partidas[rowIndex].ExistenciaFisica - partidas[rowIndex].ExistenciaTeorica;

                        partidas[rowIndex].CostoParcial = partidas[rowIndex].Costo * partida.Diferencia;
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
                if (Ambiente.Pregunta("Se perderá el conteo para este articulo y el stock se mantendrá igual que antes del conteo: Continuar"))
                {
                    if (partidas.Count > 0 && rowIndex >= 0)
                    {
                        Malla.Rows.RemoveAt(rowIndex);
                        inventariopController.Delete(partidas[rowIndex].InventariopId);
                        partidas.RemoveAt(rowIndex);
                        ReCargaGrid();
                    }
                }

            }

        }
        private void ActualizaCantidad(int cant, int rowIndex, bool resetStock = false)
        {
            try
            {
                if ((rowIndex <= partidas.Count - 1) && cant > 0)
                {
                    partidas[rowIndex].ExistenciaFisica = cant;
                    Malla.Rows[rowIndex].Cells[3].Value = cant;


                    if (partidas[rowIndex].ExistenciaTeorica > partidas[rowIndex].ExistenciaFisica)
                    {
                        partidas[rowIndex].Diferencia = partidas[rowIndex].ExistenciaTeorica - partidas[rowIndex].ExistenciaFisica;
                        partidas[rowIndex].Diferencia = partidas[rowIndex].Diferencia * -1;
                    }
                    else
                        partidas[rowIndex].Diferencia = partidas[rowIndex].ExistenciaFisica - partidas[rowIndex].ExistenciaTeorica;

                    partidas[rowIndex].CostoParcial = partidas[rowIndex].Costo * partida.Diferencia;

                }
                else
                {
                    if (resetStock)
                    {
                        partidas[rowIndex].ExistenciaFisica = 0;
                        Malla.Rows[rowIndex].Cells[3].Value = 0;
                    }
                    else
                    {
                        partidas[rowIndex].ExistenciaFisica = 1;
                        Malla.Rows[rowIndex].Cells[3].Value = 1;
                    }


                    if (partidas[rowIndex].ExistenciaTeorica > partidas[rowIndex].ExistenciaFisica)
                    {
                        partidas[rowIndex].Diferencia = partidas[rowIndex].ExistenciaTeorica - partidas[rowIndex].ExistenciaFisica;
                        partidas[rowIndex].Diferencia = partidas[rowIndex].Diferencia * -1;
                    }
                    else
                        partidas[rowIndex].Diferencia = partidas[rowIndex].ExistenciaFisica - partidas[rowIndex].ExistenciaTeorica;

                    partidas[rowIndex].CostoParcial = partidas[rowIndex].Costo * partidas[rowIndex].Diferencia;

                    if (!resetStock)
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

                if (partidas.IndexOf(partida) > Malla.RowCount - 1)
                    Malla.Rows.Add();

                //partida al grid
                Malla.Rows[index].Cells[0].Value = partida.ProductoId;
                Malla.Rows[index].Cells[1].Value = partida.Descripcion;
                Malla.Rows[index].Cells[2].Value = partida.ExistenciaTeorica;
                Malla.Rows[index].Cells[3].Value = partida.ExistenciaFisica;
                Malla.Rows[index].Cells[4].Value = partida.Diferencia;
                Malla.Rows[index].Cells[5].Value = partida.Costo;
                Malla.Rows[index].Cells[6].Value = partida.CostoParcial;

                index++;
            }
        }
        private void ColumnCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }
        private void Incrementa(int rowIndex)
        {
            try
            {
                if (partidas.Count > 0)
                {
                    partidas[rowIndex].ExistenciaFisica++;
                    Malla.Rows[rowIndex].Cells[3].Value = partidas[rowIndex].ExistenciaFisica;


                    if (partidas[rowIndex].ExistenciaTeorica > partidas[rowIndex].ExistenciaFisica)
                    {
                        partidas[rowIndex].Diferencia = partidas[rowIndex].ExistenciaTeorica - partidas[rowIndex].ExistenciaFisica;
                        partidas[rowIndex].Diferencia = partidas[rowIndex].Diferencia * -1;
                    }
                    else
                        partidas[rowIndex].Diferencia = partidas[rowIndex].ExistenciaFisica - partidas[rowIndex].ExistenciaTeorica;

                    partidas[rowIndex].CostoParcial = partidas[rowIndex].Costo * partida.Diferencia;
                }
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.Message);
            }

        }
        private void Malla_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnCant_KeyPress);
            if (Malla.CurrentCell.ColumnIndex == 3) //Desired Column
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
                    EliminaPartida(Malla.CurrentCell.RowIndex, Malla.Rows[Malla.CurrentCell.RowIndex].Cells[1].Value.ToString());
            }
        }

        private void TxtInventario_KeyDown(object sender, KeyEventArgs e)
        {
            ///INICIAR LA BUSQUEDA DEL INVENTARIO Y TRAER LAS PARTIDAS
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtInventario.Text, (int)Ambiente.TipoBusqueda.Inventarios))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        inventario = form.Inventario;
                        tipoInventario = tipoInventarioController.SelectOne(inventario.TipoInventarioId);
                        usuario = usuarioController.SelectOne(inventario.CreatedBy);
                        CargaDatos();

                    }
                }
            }
        }

        private void CargaDatos()
        {
            LimiarCampos();
            if (inventario == null) return;

            partidas = inventariopController.SelectPartidasById(inventario.InventarioId);
            TxtInventario.Text = inventario.InventarioId.ToString();
            TxtFechaDoc.Text = inventario.CreatedAt.ToString("dd-MM-yyyy");
            TxtFechaBloqueo.Text = inventario.UsuarioBloqueoId != null ? inventario.FechaBloqueo.ToString("dd-MM-yyyy") : "INDEFINIDO";
            TxtUsuarioCaptura.Text = usuario != null ? usuario.Nombre : "SIN DEFINIR";
            TxtSituacion.Text = inventario.EstadoDocId.Equals("PEN") ? "PENDIENTE" : inventario.EstadoDocId;
            TxtUsuarioAut.Text = "";
            ReCargaGrid();
        }

        private void LimiarCampos()
        {
            TxtInventario.Text = "";
            TxtFechaDoc.Text = "";
            TxtFechaBloqueo.Text = "";
            TxtUsuarioCaptura.Text = "";
            TxtUsuarioAut.Text = "";
            Malla.Rows.Clear();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            CerrarInventario(false);
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
                    if (Ambiente.Pregunta("Este proceso no tiene reversión. Continuar"))
                    {
                        inventario.TipoInventario = tipoInventario.Descripcion;
                        inventario.TipoInventarioId = tipoInventario.TipoInventarioId;
                        inventario.EstadoDocId = "CON";
                        inventario.UsuarioAutorizacion = Ambiente.LoggedUser.Nombre;
                        inventario.UsuarioAutorizacionId = Ambiente.LoggedUser.UsuarioId;
                        inventario.FechaAutorizacion = DateTime.Now;

                        if (inventarioController.Update(inventario))
                        {
                            ActualizaPartidas();

                            AfectaLotes();
                            AfectaMovsInv();
                            AfectaStock();

                            foreach (var p in partidas)
                            {
                                producto = productoController.SelectOne(p.ProductoId);
                                if (producto != null)
                                {
                                    producto.Ocupado = false;
                                    productoController.Update(producto);
                                }
                            }
                            Ambiente.stiReport = new Stimulsoft.Report.StiReport();
                            Ambiente.stiReport.LoadPackedReportFromString(Ambiente.InformeInvetarios.Codigo);
                            Ambiente.stiReport.Dictionary.Variables["InventarioId"].ValueObject = inventario.InventarioId;
                            Ambiente.S1 = Ambiente.Empresa.DirectorioInverarios + "INVENTARIO_AUTORIZACION_" + inventario.InventarioId + ".PDF";
                            Ambiente.stiReport.Render(false);
                            Ambiente.stiReport.ExportDocument(Stimulsoft.Report.StiExportFormat.Pdf, Ambiente.S1);
                            Process.Start(Ambiente.S1);
                            Close();
                        }
                        else
                        {
                            Ambiente.Mensaje("Algo salio mal con: if (traspasoController.Update(devolucion))");
                        }
                    }

                }
                else
                    Ambiente.Mensaje("El tipo de invetario no permite autorizacion");
            }
        }
        private void AfectaMovsInv()
        {
            foreach (var p in partidas)
            {

                //**************MOVIMIENTO DE INVENTARIO****************//
                var movInv = new MovInv();
                //movInv.ConceptoMovsInvId = p.Diferencia > 0 ? "AIN" : "DIN";
                //movInv.Referencia = inventario.InventarioId;
                //movInv.Referenciap = p.InventariopId;
                //movInv.Es = p.Diferencia > 0 ? "E" : "S";
                //movInv.Afectacion = movInv.Es.Equals("E") ? 1 : -1;
                //movInv.ProductoId = p.ProductoId;
                //movInv.Cantidad = p.Diferencia;
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


        private void ActualizaPartidas()
        {
            foreach (var p in partidas)
            {
                inventariopController.Update(p);
            }
        }



        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Ambiente.Mensaje("El inventario se guardó tal cual se encuentra en este momento");
            Close();
        }

        private void BtnBorrarPartida_Click(object sender, EventArgs e)
        {
            if (Malla.Rows[Malla.CurrentCell.RowIndex].Cells[0].Value != null)
                EliminaPartida(Malla.CurrentCell.RowIndex, Malla.Rows[Malla.CurrentCell.RowIndex].Cells[1].Value.ToString());
        }

        private void BtnStockCeros_Click(object sender, EventArgs e)
        {
            StockCeros();
        }

        private void StockCeros()
        {
            try
            {
                if (Ambiente.Pregunta("Este proceso eliminará la existencia de los lotes vinculados al articulo y su nombre quedará como responsable: Continuar"))
                {
                    int index = 0;
                    foreach (var p in partidas)
                    {
                        if (p.LoteId != null)
                            lote = loteController.SelectOne((int)p.LoteId);
                        producto = productoController.SelectOne(p.ProductoId);

                        if (lote != null)
                        {
                            lote.StockRestante = 0;
                            loteController.Update(lote);
                        }
                        if (producto != null)
                        {
                            producto.Stock = 0;
                            producto.UpdatedBy = Ambiente.LoggedUser.UsuarioId;
                            productoController.Update(producto);
                        }

                        ActualizaCantidad(0, index, true);
                        index++;
                    }

                    inventario.UpdatedBy = Ambiente.LoggedUser.UsuarioId;
                    inventario.UpdatedAt = DateTime.Now;
                    inventarioController.Update(inventario);
                    ReCargaGrid();
                    Ambiente.Mensaje("Proceso concluido");
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(ex.Message);
            }
        }
    }
}
