﻿using PointOfSale.Controllers;
using PointOfSale.Controllers.EvironmentController;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Logistica
{
    public partial class FrmEntradaPorCompra2 : Form
    {
        //objetos
        private Compra compra;
        private Comprap comprap;
        private Producto producto;
        private Proveedor proveedor;
        private CambiosPrecio cambioPrecio;
        private Empresa empresa;

        //listas
        private List<Comprap> partidas;
        private List<Impuesto> impuestos;
        private List<Lote> lotes;
        private List<Producto> productosActualizados;




        //Controladores
        private CompraController compraController;
        private ComprapController comprapController;
        private LoteController loteController;
        private MovInvController movInvController;
        private FlujoController flujoController;
        private ProductoController productoController;
        private LaboratorioController laboratorioController;
        private CambioPrecioController cambioPrecioController;



        //Variables
        private int SigPartida;
        private const int NPARTIDAS = 400;
        private bool sobreGrid;
        private decimal subtotal;
        private decimal impuesto;

        public FrmEntradaPorCompra2()
        {
            InitializeComponent();
            ResetPDC();
            // productoController.SelectMany(1);
        }

        #region Metodos
        private void ResetPDC()
        {
            //objetos
            compra = new Compra();
            comprap = new Comprap();
            producto = new Producto();
            proveedor = new Proveedor();
            cambioPrecio = new CambiosPrecio();
            empresa = new EmpresaController().SelectTopOne();

            //listas
            partidas = new List<Comprap>();
            impuestos = new List<Impuesto>();
            lotes = new List<Lote>();
            productosActualizados = new List<Producto>();

            //Controladores
            compraController = new CompraController();
            comprapController = new ComprapController();
            loteController = new LoteController();
            movInvController = new MovInvController();
            flujoController = new FlujoController();
            productoController = new ProductoController();
            laboratorioController = new LaboratorioController();
            cambioPrecioController = new CambioPrecioController();

            //Variables
            SigPartida = 0;
            subtotal = 0;
            impuesto = 0;
            sobreGrid = false;

            //Reset malla
            Malla.Rows.Clear();
            GridImpuestos.Rows.Clear();
            for (int i = 0; i < NPARTIDAS; i++)
            {
                Malla.Rows.Add();
                Malla.Rows[i].Cells[4].Style.BackColor = Color.Yellow;
                Malla.Rows[i].Cells[6].Style.BackColor = Color.Yellow;
                Malla.Rows[i].Cells[8].Style.BackColor = Color.Yellow;
                Malla.Rows[i].Cells[9].Style.BackColor = Color.Yellow;
                Malla.Rows[i].Cells[14].Style.BackColor = Color.Yellow;
                Malla.Rows[i].Cells[15].Style.BackColor = Color.Yellow;

            }

            TxtProvedorId.Text = "";
            TxtFacturaProveedor.Text = "";
            DpFechaDoc.Value = DateTime.Now;
            DpFechaVencimiento.Value = DateTime.Now;
            TxtDatosProveedor.Text = "";
            TxtProductoId.Text = "";
            NCantidad.Value = 1;
            NCostoU.Value = 0;
            NPrecioCaja.Value = 0;
            NDesc1.Value = 66.66M;
            TxtDescripcion.Text = "";
            TxtU1.Text = "";
            TxtU2.Text = "";
            TxtU3.Text = "";
            TxtU4.Text = "";
            TxtPrecio1.Text = "";
            TxtPrecio2.Text = "";
            TxtPrecio3.Text = "";
            TxtPrecio4.Text = "";
            TxtPrecioS1.Text = "";
            TxtPrecioS2.Text = "";
            TxtPrecioS3.Text = "";
            TxtPrecioS4.Text = "";
            PbxImagen.Image = null;
            TxtSubtotal.Text = "";
            TxtImpuestos.Text = "";
            TxtTotal.Text = "";
            CreaCompra();

        }
        private void CreaCompra()
        {
            compra = new Compra();
            compra.FechaDocumento = DpFechaDoc.Value;
            compra.FechaVencimiento = DpFechaVencimiento.Value;
            if (proveedor != null)
            {
                compra.ProveedorId = "SYS";
                compra.ProveedorName = "PROVEEDOR GENERICO";
            }

            compra.EsCxp = false;
            compra.CxpId = null;
            compra.Importe = 0;
            compra.Impuesto = 0;
            compra.FacturaProveedor = "";
            compra.TipoDocId = "COM";
            compra.EstadoDocId = "PEN";
            compra.AlmacenId = "1";
            compra.Datos = "SIN DATOS";
            compra.EstacionId = Ambiente.Estacion.EstacionId;
            compra.CreatedAt = DateTime.Now;
            compra.CreatedBy = Ambiente.LoggedUser.UsuarioId;
            compraController.InsertOne(compra);
        }
        private void LlenaDatosProducto()
        {

            TxtProductoId.Text = producto.ProductoId;

            TxtDescripcion.Text = producto.Descripcion;
            TxtU1.Text = producto.Utilidad1.ToString();
            TxtU2.Text = producto.Utilidad2.ToString();
            TxtU3.Text = producto.Utilidad3.ToString();
            TxtU4.Text = producto.Utilidad4.ToString();
            TxtPrecio1.Text = producto.Precio1.ToString();
            TxtPrecio2.Text = producto.Precio2.ToString();
            TxtPrecio3.Text = producto.Precio3.ToString();
            TxtPrecio4.Text = producto.Precio4.ToString();
            CargaListaImpuestos(producto);
            CargaGridImpuestos();
            TxtPrecioS1.Text = Ambiente.GetPrecioSalida(TxtPrecio1.Text, impuestos);
            TxtPrecioS2.Text = Ambiente.GetPrecioSalida(TxtPrecio2.Text, impuestos);
            TxtPrecioS3.Text = Ambiente.GetPrecioSalida(TxtPrecio3.Text, impuestos);
            TxtPrecioS4.Text = Ambiente.GetPrecioSalida(TxtPrecio4.Text, impuestos);
            PbxImagen.Image = GetImg(producto.RutaImg);

            //costos compra
            NCantidad.Value = 1;
            NPrecioCaja.Value = producto.PrecioCaja;
            NDesc1.Value = 66.66m;
            NDesc2.Value = 0;
            NCostoU.Value = producto.PrecioCompra;
            NprecioLista.Value = descueto(NPrecioCaja.Value, NDesc1.Value);
            NImporte.Value = NCantidad.Value * NCostoU.Value;

        }
        private void CargaGridImpuestos()
        {
            GridImpuestos.Rows.Clear();
            GridImpuestos.Refresh();
            foreach (var i in impuestos)
            {
                GridImpuestos.Rows.Add();
                GridImpuestos.Rows[GridImpuestos.RowCount - 1].Cells[0].Value = i.ImpuestoId;
                GridImpuestos.Rows[GridImpuestos.RowCount - 1].Cells[1].Value = i.Tasa;
            }
        }
        private void CargaListaImpuestos(Producto producto)
        {

            impuestos = new List<Impuesto>();

            ImpuestoController impuestoController = new ImpuestoController();

            var impuesto1 = impuestoController.SelectOne(producto.Impuesto1Id);
            if (impuesto1 != null)
                impuestos.Add(impuesto1);

            var impuesto2 = impuestoController.SelectOne(producto.Impuesto2Id);
            if (impuesto2 != null)
                impuestos.Add(impuesto2);

        }
        private Image GetImg(string ruta)
        {
            try
            {


                if (!Ambiente.ServerImgAccesible) return null;

                if (!File.Exists(ruta)) return null;

                Image img = Image.FromFile(ruta);
                return img;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private void CalculaTotales()
        {
            subtotal = 0;
            impuesto = 0;
            foreach (var partida in partidas)
            {
                partida.Subtotal = partida.Cantidad * partida.PrecioCompra;
                partida.Subtotal -= partida.Subtotal * partida.Descuento;
                partida.ImporteImpuesto1 = partida.Subtotal * partida.Impuesto1;
                partida.ImporteImpuesto2 = partida.Subtotal * partida.Impuesto2;
                partida.Total = partida.Subtotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
                subtotal += partida.Subtotal;
                impuesto += partida.ImporteImpuesto1 + partida.ImporteImpuesto2;

                //reflejar totales
                TxtSubtotal.Text = Ambiente.FDinero(subtotal.ToString());
                TxtImpuestos.Text = Ambiente.FDinero(impuesto.ToString());
                TxtTotal.Text = Ambiente.FDinero((subtotal + impuesto).ToString());
            }
        }
        private void InsertaPartida()
        {
            if (producto == null && TxtProductoId.Text.Trim().Length == 0)
                Ambiente.Mensaje("Producto no encontrado");

            producto = productoController.SelectOne(TxtProductoId.Text.Trim());
            if (producto == null)
                return;

            if (compra.CompraId == 0)
            {
                Ambiente.Mensaje("La compra no existe");
                return;
            }




            //partida a la lista
            var partida = new Comprap();
            partida.CompraId = compra.CompraId;
            partida.ProductoId = producto.ProductoId;
            partida.Descripcion = producto.Descripcion;
            partida.LaboratorioId = producto.LaboratorioId;
            partida.LaboratorioName = laboratorioController.SelectOne(producto.LaboratorioId).Nombre.Trim();
            partida.Stock = producto.Stock;
            partida.Cantidad = NCantidad.Value;
            partida.PrecioCompra = NCostoU.Value;
            partida.PrecioCaja = NPrecioCaja.Value;
            partida.Descuento = NDesc1.Value / 100;
            partida.NImpuestos = impuestos.Count;

            //control lotes
            if (producto.TieneLote)
            {
                using (var form = new FrmLoteCaducidad(compra.CompraId, NCantidad.Value, producto.ProductoId))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        partida.Lote = form.lotes[0].NoLote;
                        partida.Caducidad = form.lotes[0].Caducidad;
                    }
                    else
                    {
                        partida.Lote = null;
                        partida.Caducidad = null;
                    }
                }
            }

            //cambios de precio
            if (partida.PrecioCompra != producto.PrecioCompra)
            {
                producto.PrecioCompra = NCostoU.Value;
                producto.PrecioCaja = NPrecioCaja.Value;
                producto.Precio1 = Ambiente.ToDecimal(TxtPrecio1.Text);
                producto.Precio2 = Ambiente.ToDecimal(TxtPrecio2.Text);
                producto.Precio3 = Ambiente.ToDecimal(TxtPrecio3.Text);
                producto.Precio4 = Ambiente.ToDecimal(TxtPrecio4.Text);
                producto.Utilidad1 = Ambiente.ToDecimal(TxtU1.Text);
                producto.Utilidad2 = Ambiente.ToDecimal(TxtU2.Text);
                producto.Utilidad3 = Ambiente.ToDecimal(TxtU3.Text);
                producto.Utilidad4 = Ambiente.ToDecimal(TxtU4.Text);
                productosActualizados.Add(producto);
            }
            //totales
            partida.Impuesto1 = impuestos[0].Tasa;
            partida.Impuesto2 = impuestos[1].Tasa;
            partida.Subtotal = partida.Cantidad * partida.PrecioCompra;
            partida.Subtotal -= partida.Subtotal * partida.Descuento;
            partida.ImporteImpuesto1 = partida.Subtotal * partida.Impuesto1;
            partida.ImporteImpuesto2 = partida.Subtotal * partida.Impuesto2;
            partida.Total = partida.Subtotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
            partidas.Add(partida);

            CalculaTotales();
            // partida al grid
            Malla.Rows[SigPartida].Cells[0].Value = partida.ProductoId;
            Malla.Rows[SigPartida].Cells[1].Value = partida.Descripcion;
            Malla.Rows[SigPartida].Cells[2].Value = partida.LaboratorioName;
            Malla.Rows[SigPartida].Cells[3].Value = partida.Stock;
            Malla.Rows[SigPartida].Cells[4].Value = partida.Cantidad;
            Malla.Rows[SigPartida].Cells[5].Value = partida.PrecioCaja;
            Malla.Rows[SigPartida].Cells[6].Value = partida.PrecioCompra;
            Malla.Rows[SigPartida].Cells[7].Value = partida.Descuento;
            Malla.Rows[SigPartida].Cells[8].Value = partida.Impuesto1;
            Malla.Rows[SigPartida].Cells[9].Value = partida.Impuesto2;
            Malla.Rows[SigPartida].Cells[10].Value = partida.Subtotal;
            Malla.Rows[SigPartida].Cells[11].Value = partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
            Malla.Rows[SigPartida].Cells[12].Value = partida.Subtotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
            Malla.Rows[SigPartida].Cells[13].Value = partida.NImpuestos;
            Malla.Rows[SigPartida].Cells[14].Value = partida.Lote;
            Malla.Rows[SigPartida].Cells[15].Value = partida.Caducidad;
            ResetPartida();

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
            Malla.Rows[index].Cells[10].Value = null;
            Malla.Rows[index].Cells[11].Value = null;
            Malla.Rows[index].Cells[12].Value = null;
            Malla.Rows[index].Cells[13].Value = null;
            Malla.Rows[index].Cells[14].Value = null;
        }
        private void Incrementa(int rowIndex)
        {
            if (partidas.Count > 0)
            {
                partidas[rowIndex].Cantidad++;
                Malla.Rows[rowIndex].Cells[4].Value = partidas[rowIndex].Cantidad;
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
                    Malla.Rows[rowIndex].Cells[4].Value = partidas[rowIndex].Cantidad;
                    CalculaTotales();
                }
                else
                    Ambiente.Mensaje("Operación denegada, solo cantidades positivas");
            }
        }
        private void ActualizaCantidad(decimal cant, int rowIndex)
        {
            if ((rowIndex < partidas.Count))
            {
                if (cant > 0)
                {
                    partidas[rowIndex].Cantidad = cant;
                    Malla.Rows[rowIndex].Cells[4].Value = cant;
                }
                else
                {
                    partidas[rowIndex].Cantidad = 1;
                    Malla.Rows[rowIndex].Cells[4].Value = 1;
                    Ambiente.Mensaje("Operación denegada, solo cantidades positivas");
                }
            }
        }
        private void ActualizaPrecioCaja(decimal pcaja, int rowIndex)
        {
            if ((rowIndex < partidas.Count))
            {
                if (pcaja > 0)
                {
                    partidas[rowIndex].PrecioCaja = pcaja;
                    Malla.Rows[rowIndex].Cells[5].Value = pcaja;
                }
                else
                {
                    Malla.Rows[rowIndex].Cells[5].Value = partidas[rowIndex].PrecioCaja;
                    Ambiente.Mensaje("Operación denegada, solo cantidades positivas");
                }
            }
        }
        private void ActualizaImpuesto1(decimal impuesto, int rowIndex)
        {
            if ((rowIndex < partidas.Count))
            {
                if (impuesto > 1)
                {
                    partidas[rowIndex].Impuesto1 = impuesto / 100;
                    Malla.Rows[rowIndex].Cells[8].Value = impuesto / 100;
                }
                else
                {
                    partidas[rowIndex].Impuesto1 = impuesto;
                    Malla.Rows[rowIndex].Cells[8].Value = impuesto;
                }
            }
        }
        private void ActualizaImpuesto2(decimal impuesto, int rowIndex)
        {
            if ((rowIndex < partidas.Count))
            {
                if (impuesto > 1)
                {
                    partidas[rowIndex].Impuesto2 = impuesto / 100;
                    Malla.Rows[rowIndex].Cells[9].Value = impuesto / 100;
                }
                else
                {
                    partidas[rowIndex].Impuesto2 = impuesto;
                    Malla.Rows[rowIndex].Cells[9].Value = impuesto;
                }
            }
        }
        private void ActualizaPrecioCompra(decimal pcompra, int rowIndex)
        {
            if ((rowIndex < partidas.Count))
            {
                if (pcompra > 0)
                {
                    partidas[rowIndex].PrecioCompra = pcompra;
                    Malla.Rows[rowIndex].Cells[6].Value = pcompra;
                }
                else
                {
                    Malla.Rows[rowIndex].Cells[5].Value = partidas[rowIndex].PrecioCompra;
                    Ambiente.Mensaje("Operación denegada, solo cantidades positivas");
                }
            }
        }
        private void ActualizaDescuento(decimal desc, int rowIndex)
        {
            if ((rowIndex < partidas.Count))
            {
                if (desc > 0)
                {
                    if (desc > 1)
                    {
                        partidas[rowIndex].Descuento = desc / 100;
                        Malla.Rows[rowIndex].Cells[7].Value = desc / 100;
                    }
                    else
                    {
                        partidas[rowIndex].Descuento = desc;
                        Malla.Rows[rowIndex].Cells[7].Value = desc;
                    }

                }
                else
                {
                    partidas[rowIndex].Descuento = 0;
                    Malla.Rows[rowIndex].Cells[7].Value = 0;
                    //Ambiente.Mensaje("Operación denegada, solo cero y cantidades positivas");
                }
            }
        }


        private void ResetPartida()
        {
            producto = null;
            TxtProductoId.Text = "";
            NCantidad.Value = 1;
            NCostoU.Value = 0;
            NPrecioCaja.Value = 0;
            TxtPrecio1.Text = "";
            TxtPrecio2.Text = "";
            TxtPrecio3.Text = "";
            TxtPrecio4.Text = "";
            TxtU1.Text = "";
            TxtU2.Text = "";
            TxtU3.Text = "";
            TxtU4.Text = "";
            TxtDescripcion.Text = "";
            SigPartida++;

            TxtProductoId.Focus();
        }
        private void EliminaCompra()
        {
            if (compra != null)
            {
                compraController.DeletePartidas(compra);
                compraController.DeleteOne(compra.CompraId);
            }
        }

        private void EliminaPartida(int rowIndex, string descrip)
        {
            if (Ambiente.Pregunta("Realmente quiere borrar: " + descrip))
            {
                if (partidas.Count > 0 && rowIndex >= 0)
                {
                    EliminaLotes(Malla.Rows[rowIndex].Cells[0].Value.ToString(), compra.CompraId);
                    var p = partidas[rowIndex];
                    partidas.RemoveAt(rowIndex);
                    SigPartida -= 1;
                    LimpiarFilaMalla(SigPartida);
                    ReCargaGrid();
                    CalculaTotales();
                }
            }

        }

        private void EliminaLotes(string productoId, int compraId)
        {
            var lotes = loteController.GetLotes(productoId, compraId);
            if (lotes != null)
            {
                foreach (var l in lotes)
                {
                    loteController.Delete(l.LoteId);
                }
            }
        }

        private void ReCargaGrid()
        {
            int index = 0;
            foreach (var partida in partidas)
            {
                Malla.Rows[index].Cells[0].Value = partida.ProductoId;
                Malla.Rows[index].Cells[1].Value = partida.Descripcion;
                Malla.Rows[index].Cells[2].Value = partida.LaboratorioName;
                Malla.Rows[index].Cells[3].Value = partida.Stock;
                Malla.Rows[index].Cells[4].Value = partida.Cantidad;
                Malla.Rows[index].Cells[5].Value = partida.PrecioCaja;
                Malla.Rows[index].Cells[6].Value = partida.PrecioCompra;
                Malla.Rows[index].Cells[7].Value = partida.Descuento;
                Malla.Rows[index].Cells[8].Value = partida.Impuesto1;
                Malla.Rows[index].Cells[9].Value = partida.Impuesto2;
                Malla.Rows[index].Cells[10].Value = partida.Subtotal;
                Malla.Rows[index].Cells[11].Value = partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
                Malla.Rows[index].Cells[12].Value = partida.Subtotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
                Malla.Rows[index].Cells[13].Value = partida.NImpuestos;
                Malla.Rows[index].Cells[14].Value = partida.Lote;
                Malla.Rows[index].Cells[15].Value = partida.Caducidad;
                index++;
            }
        }

        private void CerrarCompra(bool pendiente)
        {
            if (partidas.Count > 0)
            {
                if (proveedor.ProveedorId == null)
                {
                    Ambiente.Mensaje("Operación denegada, seleccione un proveedor");
                    return;
                }
                compra.FechaDocumento = DpFechaDoc.Value;
                compra.FechaVencimiento = DpFechaVencimiento.Value;
                if (proveedor != null)
                {
                    compra.ProveedorId = proveedor.ProveedorId;
                    compra.ProveedorName = proveedor.RazonSocial.Trim().Length == 0 ? proveedor.Negocio.Trim() : proveedor.RazonSocial.Trim();
                }
                else
                {
                    compra.ProveedorId = "SYS";
                    compra.ProveedorName = "PROVEEDOR GENERICO";

                }
                compra.EsCxp = false;
                compra.CxpId = null;
                compra.Importe = subtotal;
                compra.Impuesto = impuesto;
                compra.FacturaProveedor = TxtFacturaProveedor.Text.Trim().Length == 0 ? "SYS" : TxtFacturaProveedor.Text.Trim();
                compra.TipoDocId = "COM";

                if (pendiente)
                    compra.EstadoDocId = "PEN";
                else
                    compra.EstadoDocId = "CON";

                compra.AlmacenId = "1";
                compra.Datos = TxtDatosProveedor.Text.Trim();
                if (compraController.Update(compra))
                {
                    if (GuardaPartidas())
                    {
                        GuardaCambioPrecios();
                        ActualizaPrecios();
                        AfectaMovsInv();
                        AfectaStock();
                        Reports.empresa = empresa;
                        Reports.EntradaXCompra(compra, partidas);
                        if (!pendiente)
                            ResetPDC();
                        //Ambiente.Mensaje("Proceso concluido con éxito");
                    }
                    else
                        Ambiente.Mensaje("Algo salió mal con: GuardaPartidas()");
                }
                else
                    Ambiente.Mensaje("Algo salió mal con: compraController.Update(compra)");
            }
            else
                Ambiente.Mensaje("Sin productos.");
        }

        private void ActualizaPrecios()
        {
            foreach (var pa in partidas)
                foreach (var pr in productosActualizados)
                    productoController.Update(pr);
        }

        private void GuardaCambioPrecios()
        {

            foreach (var pa in partidas)
            {
                foreach (var pr in productosActualizados)
                {
                    if (pa.ProductoId.Equals(pr.ProductoId))
                    {
                        var p = productoController.SelectOne(pa.ProductoId);
                        if (p != null)
                        {
                            //precios viejos
                            cambioPrecio = new CambiosPrecio();
                            cambioPrecio.ProductoId = p.ProductoId;
                            cambioPrecio.PrecioCompraViejo = p.PrecioCompra;
                            cambioPrecio.Precio1Viejo = p.Precio1;
                            cambioPrecio.Precio2Viejo = p.Precio2;
                            cambioPrecio.Precio3Viejo = p.Precio3;
                            cambioPrecio.Precio4Viejo = p.Precio4;
                            cambioPrecio.Utilidad1Viejo = p.Utilidad1;
                            cambioPrecio.Utilidad2Viejo = p.Utilidad2;
                            cambioPrecio.Utilidad3Viejo = p.Utilidad3;
                            cambioPrecio.Utilidad4Viejo = p.Utilidad4;
                            //precios nuevos
                            cambioPrecio.PrecioCompraNuevo = pa.PrecioCompra;
                            cambioPrecio.Precio1Nuevo = pr.Precio1;
                            cambioPrecio.Precio2Nuevo = pr.Precio2;
                            cambioPrecio.Precio3Nuevo = pr.Precio3;
                            cambioPrecio.Precio4Nuevo = pr.Precio4;
                            cambioPrecio.Utilidad1Nuevo = pr.Utilidad1;
                            cambioPrecio.Utilidad2Nuevo = pr.Utilidad2;
                            cambioPrecio.Utilidad3Nuevo = pr.Utilidad3;
                            cambioPrecio.Utilidad4Nuevo = pr.Utilidad4;

                            cambioPrecio.CompraId = compra.CompraId;
                            cambioPrecio.CreatedAt = DateTime.Now;
                            cambioPrecio.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                            cambioPrecioController.InsertOne(cambioPrecio);
                        }
                        else
                            Ambiente.Mensaje("El producto ya no existe");
                    }
                }
            }



        }

        private void AfectaMovsInv()
        {
            foreach (var p in partidas)
            {
                var movInv = new MovInv();
                movInv.ConceptoMovsInvId = "COM";
                movInv.NoRef = compra.CompraId;
                movInv.EntradaSalida = "E";
                movInv.IdEntrada = p.ComprapId;
                movInv.IdSalida = null;
                movInv.ProductoId = p.ProductoId;
                movInv.Precio = p.PrecioCompra;
                movInv.Cantidad = p.Cantidad;
                movInv.CreatedAt = DateTime.Now;
                movInv.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                movInvController.InsertOne(movInv);
            }
        }

        private void AfectaStock()
        {
            foreach (var p in partidas)
            {
                var prod = productoController.SelectOne(p.ProductoId);
                prod.Stock += p.Cantidad;
                productoController.Update(prod);
            }
        }

        private void PendienteOdescarta()
        {
            if (partidas.Count > 0 && compra.EstadoDocId.Equals("PEN"))
            {
                if (Ambiente.Pregunta("Quiere dejar la venta como pendiente"))
                    CerrarCompra(true);
                else
                    EliminaCompra();
            }
            else
                EliminaCompra();
            Close();
        }

        private bool GuardaPartidas()
        {
            return comprapController.InsertRange(partidas);
        }
        #endregion

        #region Eventos
        private void TxtProvedorId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtProvedorId.Text, (int)Ambiente.TipoBusqueda.Proveedores))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        proveedor = form.Proveedor;
                        TxtProvedorId.Text = proveedor.ProveedorId;
                        TxtDatosProveedor.Text = proveedor.Negocio + " " + proveedor.Direccion + " " + proveedor.Colonia
                            + " " + proveedor.Municipio + " " + proveedor.Localidad + " " + proveedor.Estado + " TEL." + proveedor.Telefono;
                    }
                }
            }
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
                        TxtProductoId.Text = form.Producto.ProductoId;
                    }
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            InsertaPartida();
        }

        private void TxtU1_Leave(object sender, EventArgs e)
        {
            TxtU1.Text = Ambiente.FDinero(TxtU1.Text);
            TxtPrecio1.Text = Ambiente.GetPrecio(NCostoU.Value.ToString(), TxtU1.Text);
        }
        private void TxtPrecio1_Leave(object sender, EventArgs e)
        {
            TxtPrecio1.Text = Ambiente.FDinero(TxtPrecio1.Text);
            TxtU1.Text = Ambiente.GetMargen(NCostoU.Value.ToString(), TxtPrecio1.Text);
            TxtPrecioS1.Text = Ambiente.GetPrecioSalida(TxtPrecio1.Text, impuestos);
        }
        private void TxtU2_Leave(object sender, EventArgs e)
        {
            TxtU2.Text = Ambiente.FDinero(TxtU2.Text);
            TxtPrecio2.Text = Ambiente.GetPrecio(NCostoU.Value.ToString(), TxtU2.Text);
        }
        private void TxtPrecio2_Leave(object sender, EventArgs e)
        {
            TxtPrecio2.Text = Ambiente.FDinero(TxtPrecio2.Text);
            TxtU2.Text = Ambiente.GetMargen(NCostoU.Value.ToString(), TxtPrecio2.Text);
            TxtPrecioS2.Text = Ambiente.GetPrecioSalida(TxtPrecio2.Text, impuestos);
        }
        private void TxtU3_Leave(object sender, EventArgs e)
        {
            TxtU3.Text = Ambiente.FDinero(TxtU3.Text);
            TxtPrecio3.Text = Ambiente.GetPrecio(NCostoU.Value.ToString(), TxtU3.Text);
        }
        private void TxtPrecio3_Leave(object sender, EventArgs e)
        {
            TxtPrecio3.Text = Ambiente.FDinero(TxtPrecio3.Text);
            TxtU3.Text = Ambiente.GetMargen(NCostoU.Value.ToString(), TxtPrecio3.Text);
            TxtPrecioS3.Text = Ambiente.GetPrecioSalida(TxtPrecio3.Text, impuestos);
        }
        private void TxtU4_Leave(object sender, EventArgs e)
        {
            TxtU4.Text = Ambiente.FDinero(TxtU4.Text);
            TxtPrecio4.Text = Ambiente.GetPrecio(NCostoU.Value.ToString(), TxtU4.Text);
        }
        private void TxtPrecio4_Leave(object sender, EventArgs e)
        {
            TxtPrecio4.Text = Ambiente.FDinero(TxtPrecio4.Text);
            TxtU4.Text = Ambiente.GetMargen(NCostoU.Value.ToString(), TxtPrecio4.Text);
            TxtPrecioS4.Text = Ambiente.GetPrecioSalida(TxtPrecio4.Text, impuestos);
            BtnAgregar.Focus();
        }
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            CerrarCompra(false);
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            PendienteOdescarta();
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
        private void Malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Malla.CurrentCell.Value == null)
                return;


            if (Malla.CurrentCell.ColumnIndex == 4)
            {
                //Cantidad
                ActualizaCantidad(decimal.Parse(Malla.CurrentCell.Value.ToString()), e.RowIndex);
                CalculaTotales();
                ReCargaGrid();
                TxtProductoId.Focus();
            }
            if (Malla.CurrentCell.ColumnIndex == 5)
            {
                //Precio de caja
                ActualizaPrecioCaja(decimal.Parse(Malla.CurrentCell.Value.ToString()), e.RowIndex);
                CalculaTotales();
                ReCargaGrid();
                TxtProductoId.Focus();


            }

            if (Malla.CurrentCell.ColumnIndex == 6)
            {
                //Precio de costo
                ActualizaPrecioCompra(decimal.Parse(Malla.CurrentCell.Value.ToString()), e.RowIndex);
                CalculaTotales();
                ReCargaGrid();
                TxtProductoId.Focus();

            }
            if (Malla.CurrentCell.ColumnIndex == 7)
            {
                //desc
                ActualizaDescuento(decimal.Parse(Malla.CurrentCell.Value.ToString()), e.RowIndex);
                CalculaTotales();
                ReCargaGrid();
                TxtProductoId.Focus();

            }
            if (Malla.CurrentCell.ColumnIndex == 8)
            {
                //Impuesto1
                ActualizaImpuesto1(decimal.Parse(Malla.CurrentCell.Value.ToString()), e.RowIndex);
                CalculaTotales();
                ReCargaGrid();
                TxtProductoId.Focus();

            }
            if (Malla.CurrentCell.ColumnIndex == 9)
            {
                //Impuesto2
                ActualizaImpuesto2(decimal.Parse(Malla.CurrentCell.Value.ToString()), e.RowIndex);
                CalculaTotales();
                ReCargaGrid();
                TxtProductoId.Focus();

            }
        }
        private void Malla_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnCant_KeyPress);
            if (Malla.CurrentCell.ColumnIndex == 4 || Malla.CurrentCell.ColumnIndex == 5
                || Malla.CurrentCell.ColumnIndex == 6 || Malla.CurrentCell.ColumnIndex == 7
                || Malla.CurrentCell.ColumnIndex == 8 || Malla.CurrentCell.ColumnIndex == 9) //Desired Column
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // solo se permite un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
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
                    EliminaPartida(Malla.CurrentCell.RowIndex, Malla.Rows[Malla.CurrentCell.RowIndex].Cells[1].Value.ToString());
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
        private void TxtProvedorId_MouseEnter(object sender, EventArgs e)
        {
            sobreGrid = true;
        }


        private void FrmEntradaPorCompra2_Load(object sender, EventArgs e)
        {
            NDesc1.Controls[0].Hide();
            NDesc1.Refresh();
            NDesc2.Controls[0].Hide();
            NDesc2.Refresh();
            NPrecioCaja.Controls[0].Hide();
            NPrecioCaja.Refresh();
            NCostoU.Controls[0].Hide();
            NCostoU.Refresh();
            NCostoUlt.Controls[0].Hide();
            NCostoUlt.Refresh();
            NCantidad.Controls[0].Hide();
            NCantidad.Refresh();
            NprecioLista.Controls[0].Hide();
            NprecioLista.Refresh();
            NImporte.Controls[0].Hide();
            NImporte.Refresh();
        }


        private void NCantidad_Leave(object sender, EventArgs e)
        {
            NprecioLista.Value = descueto(NPrecioCaja.Value, NDesc1.Value);
            NImporte.Value = NCantidad.Value * NCostoU.Value;
        }
        private void NPrecioCaja_Leave(object sender, EventArgs e)
        {
            NprecioLista.Value = descueto(NPrecioCaja.Value, NDesc1.Value);
        }
        private void NDesc1_Leave(object sender, EventArgs e)
        {
            NprecioLista.Value = descueto(NPrecioCaja.Value, NDesc1.Value);
            NDesc1.Value = pdescueto(NPrecioCaja.Value, NprecioLista.Value);
        }



        private void NprecioLista_Leave(object sender, EventArgs e)
        {
            NDesc1.Value = pdescueto(NPrecioCaja.Value, NprecioLista.Value);
        }

        private void NCostoU_Leave(object sender, EventArgs e)
        {
            NDesc2.Value = pdescueto(NprecioLista.Value, NCostoU.Value);
            NImporte.Value = NCantidad.Value * NCostoU.Value;
        }

        private void NImporte_Leave(object sender, EventArgs e)
        {
            NCostoU.Value = NImporte.Value / NCantidad.Value;
            NImporte.Value = NCantidad.Value * NCostoU.Value;
            NDesc2.Value = pdescueto(NprecioLista.Value, NCostoU.Value);

        }
        private void NDesc2_Leave_1(object sender, EventArgs e)
        {
            NCostoU.Value = descueto(NprecioLista.Value, NDesc2.Value);
        }
        #endregion


        private decimal descueto(decimal vlBase, decimal vlDescuento)
        {
            return vlBase - (vlBase * (vlDescuento / 100));
        }
        private decimal pdescueto(decimal vlOriginal, decimal vlNuevo)
        {
            if (vlOriginal == 0) return 0;
            if (vlOriginal == vlNuevo) return 0;

            var x = 100 - ((vlNuevo * 100) / vlOriginal);

            return x;
        }

        private void NCantidad_Enter(object sender, EventArgs e)
        {
            NCantidad.Select(0, NCantidad.Text.Length);
        }

        private void NCantidad_Click(object sender, EventArgs e)
        {
            NCantidad.Select(0, NCantidad.Text.Length);
        }

        private void NPrecioCaja_Enter(object sender, EventArgs e)
        {
            NPrecioCaja.Select(0, NPrecioCaja.Text.Length);
        }

        private void NDesc1_Enter(object sender, EventArgs e)
        {
            NDesc1.Select(0, NDesc1.Text.Length);
        }

        private void NprecioLista_Enter(object sender, EventArgs e)
        {
            NprecioLista.Select(0, NprecioLista.Text.Length);

        }

        private void NDesc2_Enter(object sender, EventArgs e)
        {
            NDesc2.Select(0, NDesc2.Text.Length);
        }

        private void NCostoU_Enter(object sender, EventArgs e)
        {
            NCostoU.Select(0, NCostoU.Text.Length);
        }

        private void NImporte_Enter(object sender, EventArgs e)
        {
            NImporte.Select(0, NImporte.Text.Length);
        }

        private void NPrecioCaja_Click(object sender, EventArgs e)
        {
            NPrecioCaja.Select(0, NPrecioCaja.Text.Length);
        }

        private void NDesc1_Click(object sender, EventArgs e)
        {
            NDesc1.Select(0, NDesc1.Text.Length);
        }

        private void NprecioLista_Click(object sender, EventArgs e)
        {
            NprecioLista.Select(0, NprecioLista.Text.Length);
        }

        private void NDesc2_Click(object sender, EventArgs e)
        {
            NDesc2.Select(0, NDesc2.Text.Length);
        }

        private void NCostoU_Click(object sender, EventArgs e)
        {
            NCostoU.Select(0, NCostoU.Text.Length);
        }

        private void NImporte_Click(object sender, EventArgs e)
        {
            NImporte.Select(0, NImporte.Text.Length);
        }

        private void NDesc1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
