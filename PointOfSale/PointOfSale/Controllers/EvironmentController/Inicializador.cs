using DYM.Views;
using PointOfSale.Models;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Controllers
{
    public static class Inicializador
    {


        public static void InicializaListas()
        {

            Ambiente.CatalgoMensajes = new Dictionary<int, string>
            {
                //[<0] MENSAJES NEGATIVOS
                {-1, "ALGO SALIÓ MAL :( \n" },
                {-2, "PROCESO ABORTADO :( \n" },
                {-3, "PROCESO CANCELADO :( \n" },
                {-4, "ERROR DESCONOCIDO :( \n" },
                {-5, "MÓDULO NO IMPLEMENTADO :( \n" },
                {-6, "EL REGISTRO YA NO EXISTE:( \n" },
                {-7, "LA CADENA NO TIENE EN FORMATO CORRECTO:( \n" },
                {-8, "OPERACIÓN DENEGADA:( \n" },

                //[>0] MENSAJES POSITIVOS
                {1, "COMPLETADO CON ÉXITO :) \n" },
                {2, "PROCESO COMPLETADO :) \n" },
                {3, "CAMBIOS GUARDADOS :) \n" },

            };

        }


        public static void InicializaProdiedades()
        {
            try
            {


                Ambiente.Empresa = new EmpresaController().SelectTopOne();
                Ambiente.reporteController = new ReporteController();
                Ambiente.ImageList = new System.Windows.Forms.ImageList();

                Ambiente.ImageList.TransparentColor = Color.Blue;
                Ambiente.ImageList.ColorDepth = ColorDepth.Depth24Bit;
                Ambiente.ImageList.ImageSize = new Size(16, 16);

                Ambiente.ImageList.Images.Add("reports16", Properties.Resources.reports);
                Ambiente.ImageList.Images.Add("folder16", Properties.Resources.Folder);
                Ambiente.ImageList.Images.Add("openfolder16", Properties.Resources.FolderOpen);
                Ambiente.ServerImgAccesible = Ambiente.PingHost(Ambiente.Empresa.IpServer);
            }
            catch (Exception e)
            {

                Ambiente.Mensaje(e.ToString());
            }
        }

        public static void ActualizaCierresInventario()
        {
            try
            {
                using (var db = new DymContext())
                {
                    var cpendientes1 = db.CierreInventario.Where(x => x.Etapa1Generada == false).ToList();

                    foreach (var c in cpendientes1)
                    {
                        if (c.FechaInicial.Month == DateTime.Now.Month)
                        {
                            if (!c.Etapa1Generada)
                            {
                                foreach (var p in db.Producto.ToList())
                                {
                                    var cierreInventariop = new CierreInventariop();
                                    cierreInventariop.CierreInventarioId = c.CierreInventarioId;
                                    cierreInventariop.ProductoId = p.ProductoId;
                                    cierreInventariop.Descripcion = p.Descripcion;
                                    cierreInventariop.InvInicial = p.Stock;
                                    cierreInventariop.Entradas = 0;
                                    cierreInventariop.Salidas = 0;
                                    cierreInventariop.UltimoCosto = p.UltimoCosto;
                                    cierreInventariop.PrevioVta = p.Precio1;
                                    cierreInventariop.ValorCosto = 0;
                                    cierreInventariop.ValorVenta = 0;
                                    db.Add(cierreInventariop);

                                }
                                c.Etapa1Generada = true;
                                MessageBox.Show("INVENTARIO DE CIERRE GENERADO");
                                db.SaveChanges();
                            }
                        }
                    }

                    var cpendientes2 = db.CierreInventario.Where(x => x.Etapa1Generada == true && x.Etapa2Generada == false).ToList();
                    foreach (var c in cpendientes2)
                    {

                        if (c.FechaProgramacion.Date <= DateTime.Now.Date)
                        {
                            if (!c.Etapa2Generada)
                            {
                                MessageBox.Show("EL SISTEMA INICÍO EL MANTENIMIENTO MENSUAL \n" +
                                    " LE SUPLICAMOS NO CIERRE EL SISTEMA, " +
                                    " INCLUSO SI USTEN NO VE ACTIVIDAD SIMPLEMENTE ESPERE\n" +
                                    " ESTO TOMARÁ UN PAR DE MINUTOS"
                                    , "NO CERRAR EL SISTEMA",
                                MessageBoxButtons.OK);


                                //****************Nuevo cierre inventario**********************
                                var ncierreInventario = new CierreInventario();
                                //var ini = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                                ncierreInventario.FechaInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                                ncierreInventario.FechaFinal = ncierreInventario.FechaInicial.AddMonths(1).AddDays(-1);
                                ncierreInventario.FechaProgramacion = ncierreInventario.FechaFinal.AddDays(1);
                                ncierreInventario.Etapa1Generada = true;
                                ncierreInventario.Etapa2Generada = false;
                                ncierreInventario.CreatedAt = DateTime.Now;
                                ncierreInventario.CreatedBy = "SYS";
                                ncierreInventario.EstacionId = "SYS";
                                db.Add(ncierreInventario);
                                // db.SaveChanges();

                                var productos = db.Producto.ToList();
                                foreach (var pr in productos)
                                {
                                    var cierreInventariop = new CierreInventariop();
                                    cierreInventariop.CierreInventarioId = ncierreInventario.CierreInventarioId;
                                    cierreInventariop.ProductoId = pr.ProductoId;
                                    cierreInventariop.Descripcion = pr.Descripcion;
                                    cierreInventariop.InvInicial = pr.Stock;
                                    cierreInventariop.Entradas = 0;
                                    cierreInventariop.Salidas = 0;
                                    cierreInventariop.UltimoCosto = pr.UltimoCosto;
                                    cierreInventariop.PrevioVta = pr.Precio1;
                                    cierreInventariop.ValorCosto = 0;
                                    cierreInventariop.ValorVenta = 0;
                                    db.Add(cierreInventariop);
                                    // db.SaveChanges();
                                }

                                ////////////////////////////////////////////////////////////////


                                Producto p;
                                var cierreinvp = db.CierreInventariop.Where(x => x.CierreInventarioId == c.CierreInventarioId).ToList();
                                var mosvInv = db.MovInv.Where(x => x.CreatedAt >= c.FechaInicial && x.CreatedAt <= c.FechaFinal.AddDays(1)).ToList();
                                foreach (var cp in cierreinvp)
                                {
                                    p = productos.FirstOrDefault(x => x.ProductoId.Equals(cp.ProductoId));
                                    if (p != null)
                                    {
                                        cp.Entradas = mosvInv.Where(x => x.Es.Equals("E") && !x.ConceptoMovsInvId.Equals("IIN") && x.ProductoId.Equals(p.ProductoId) && x.CreatedAt >= c.FechaInicial && x.CreatedAt <= c.FechaFinal.AddDays(1)).Sum(x => x.Cantidad);
                                        cp.Salidas = mosvInv.Where(x => x.Es.Equals("S") && x.ProductoId.Equals(p.ProductoId) && x.CreatedAt >= c.FechaInicial && x.CreatedAt <= c.FechaFinal.AddDays(1)).Sum(x => x.Cantidad);
                                        cp.InvFinal = cp.InvInicial + cp.Entradas - cp.Salidas;
                                        cp.UltimoCosto = p.UltimoCosto;
                                        cp.PrevioVta = p.Precio1; //ultimo precio venta
                                        cp.Stock = p.Stock;
                                        cp.ValorCosto = mosvInv.Where(x => x.Es.Equals("S") && x.ProductoId.Equals(p.ProductoId) && x.CreatedAt >= c.FechaInicial && x.CreatedAt <= c.FechaFinal.AddDays(1)).Sum(x => x.Valor);
                                        cp.ValorVenta = mosvInv.Where(x => x.Es.Equals("S") && x.ProductoId.Equals(p.ProductoId) && x.CreatedAt >= c.FechaInicial && x.CreatedAt <= c.FechaFinal.AddDays(1)).Sum(x => x.Cantidad * x.PrecioVta);
                                        db.Update(cp);
                                    }
                                }
                                c.Etapa2Generada = true;
                                db.Update(c);
                                db.SaveChanges();


                                MessageBox.Show("INVENTARIO DE CIERRE GENERADO");
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error ActualizaCierresInventario : " + ex.ToString());
            }
        }

        public static void InicializaDatabaseDefaultsValues()
        {
            try
            {
                using (var db = new DymContext())
                {
                    var estacion = db.Estacion.FirstOrDefault(x => x.EstacionId == "SYS");
                    if (estacion == null)
                    {
                        estacion = new Estacion();
                        estacion.EstacionId = "SYS";
                        estacion.Nombre = "DEFAUTL";
                        estacion.CanjearPuntosAuto = false;
                        db.Add(estacion);
                    }

                    var sustancia = db.Sustancia.FirstOrDefault(x => x.SustanciaId == "SYS");
                    if (sustancia == null)
                    {
                        sustancia = new Sustancia();
                        sustancia.SustanciaId = "SYS";
                        sustancia.Nombre = "DEFAUTL";
                        db.Add(sustancia);
                    }

                    var categoria = db.Categoria.FirstOrDefault(x => x.CategoriaId == "SYS");
                    if (categoria == null)
                    {
                        categoria = new Categoria();
                        categoria.CategoriaId = "SYS";
                        categoria.Nombre = "DEFAUTL";
                        db.Add(categoria);
                    }


                    var presentacion = db.Presentacion.FirstOrDefault(x => x.PresentacionId == "SYS");
                    if (presentacion == null)
                    {
                        presentacion = new Presentacion();
                        presentacion.PresentacionId = "SYS";
                        presentacion.Nombre = "DEFAUTL";
                        db.Add(presentacion);
                    }
                    var laboratorio = db.Laboratorio.FirstOrDefault(x => x.LaboratorioId == "SYS");
                    if (laboratorio == null)
                    {
                        laboratorio = new Laboratorio();
                        laboratorio.LaboratorioId = "SYS";
                        laboratorio.Nombre = "DEFAUTL";
                        db.Add(laboratorio);
                    }
                    var impuesto = db.Impuesto.FirstOrDefault(x => x.ImpuestoId == "SYS");
                    if (impuesto == null)
                    {
                        impuesto = new Impuesto();
                        impuesto.ImpuestoId = "SYS";
                        impuesto.Tasa = 0;
                        impuesto.CImpuesto = "002";
                        db.Add(impuesto);
                    }

                    var unidadMedida = db.UnidadMedida.FirstOrDefault(x => x.UnidadMedidaId == "SYS");
                    if (unidadMedida == null)
                    {
                        unidadMedida = new UnidadMedida();
                        unidadMedida.UnidadMedidaId = "SYS";
                        unidadMedida.Nombre = "DEFAUTL";
                        unidadMedida.UnidadSat = "H87";
                        db.Add(unidadMedida);
                    }

                    var edodocP = db.EstadoDoc.FirstOrDefault(x => x.EstadoDocId == "PEN");
                    if (edodocP == null)
                    {
                        edodocP = new EstadoDoc();
                        edodocP.EstadoDocId = "PEN";
                        edodocP.Descripcion = "PENDIENTE";
                        db.Add(edodocP);
                    }
                    var edodocCa = db.EstadoDoc.FirstOrDefault(x => x.EstadoDocId == "CAN");
                    if (edodocCa == null)
                    {
                        edodocCa = new EstadoDoc();
                        edodocCa.EstadoDocId = "CAN";
                        edodocCa.Descripcion = "CANCELADO";
                        db.Add(edodocCa);
                    }
                    var edodocCo = db.EstadoDoc.FirstOrDefault(x => x.EstadoDocId == "CON");
                    if (edodocCo == null)
                    {
                        edodocCo = new EstadoDoc();
                        edodocCo.EstadoDocId = "CON";
                        edodocCo.Descripcion = "CONFIRMADO";
                        db.Add(edodocCo);
                    }




                    var clienteSYS = db.Cliente.FirstOrDefault(x => x.ClienteId == "SYS");
                    if (clienteSYS == null)
                    {
                        clienteSYS = new Cliente();
                        clienteSYS.ClienteId = "SYS";
                        clienteSYS.Rfc = "XAXX010101000";
                        clienteSYS.Negocio = "PUBLICO EN GENERAL";
                        clienteSYS.RazonSocial = "PUBLICO EN GENERAL";
                        clienteSYS.MetodoPagoId = "PUE";
                        clienteSYS.FormaPagoId = "01";
                        clienteSYS.UsoCfdiid = "G01";
                        db.Add(clienteSYS);
                    }

                    var proveedorSYS = db.Proveedor.FirstOrDefault(x => x.ProveedorId == "SYS");
                    if (proveedorSYS == null)
                    {
                        proveedorSYS = new Proveedor();
                        proveedorSYS.ProveedorId = "SYS";
                        proveedorSYS.Negocio = "PROVEEDOR GENERICO";
                        proveedorSYS.RazonSocial = "PROVEEDOR GENERICO";
                        proveedorSYS.Rfc = "XAXX010101000";
                        proveedorSYS.DiasCredito = 0;
                        proveedorSYS.LimiteCredito = 0;
                        proveedorSYS.Saldo = 0;
                        proveedorSYS.IsDeleted = false;
                        db.Add(proveedorSYS);
                    }

                    var puntosConfig = db.PuntoConfig.FirstOrDefault();
                    if (puntosConfig == null)
                    {
                        puntosConfig = new PuntoConfig();
                        puntosConfig.DiasReset = 30;
                        puntosConfig.TasaDescuento = 0.01m;
                        puntosConfig.Vigente = true;
                        puntosConfig.IsDeleted = false;
                        db.Add(puntosConfig);
                    }
                    //01010101
                    var prodSys = db.Producto.FirstOrDefault(x => x.ProductoId.Equals("01010101"));

                    if (prodSys == null)
                    {
                        prodSys = new Producto();
                        prodSys.ProductoId = "01010101";
                        prodSys.CategoriaId = "SYS";
                        prodSys.PresentacionId = "SYS";
                        prodSys.LaboratorioId = "SYS";
                        prodSys.Stock = 0;
                        prodSys.Descripcion = "Concepto generico facturable";
                        prodSys.PrecioCompra = 0;
                        prodSys.PrecioCaja = 0;
                        prodSys.Precio1 = 0;
                        prodSys.Precio2 = 0;
                        prodSys.Precio3 = 0;
                        prodSys.Precio4 = 0;
                        prodSys.Utilidad1 = 0;
                        prodSys.Utilidad2 = 0;
                        prodSys.Utilidad3 = 0;
                        prodSys.Utilidad4 = 0;
                        prodSys.TieneLote = false;
                        prodSys.IsDeleted = false;
                        prodSys.CratedAt = DateTime.Now;
                        prodSys.UnidadMedidaId = "SYS";
                        prodSys.ClaveProdServId = "01010101";
                        prodSys.ClaveUnidadId = "H87";
                        prodSys.ChkCaducidad = false;
                        prodSys.CratedAt = DateTime.Now;
                        prodSys.CratedBy = "JMENDOZAJ";

                        db.Add(prodSys);
                    }




                    /**************ACTUALIZA CONEXION REPORTES**************/
                    var informes = db.Informe.ToList();

                    foreach (var informe in informes)
                    {

                        var stiReport = new StiReport();
                        stiReport.LoadPackedReportFromString(informe.Codigo);
                        stiReport.Dictionary.Databases.Clear();
                        stiReport.Dictionary.Databases.Add(new StiSqlDatabase("Dym", Ambiente.Conexion.StandardSecurityConnectionString()));
                        informe.Codigo = stiReport.SavePackedReportToString();
                        db.Update(informe);
                    }
                    /*******************************************************/
                  

                    Ambiente.InformeTicket = db.Informe.FirstOrDefault(x => x.InformeId.Equals(
                                             db.InformeConfiguracion.Where(y => y.Ticket == true)
                                             .FirstOrDefault().InformeId));

                    Ambiente.InformeFactura = db.Informe.FirstOrDefault(x => x.InformeId.Equals(
                                             db.InformeConfiguracion.Where(y => y.Factura == true)
                                             .FirstOrDefault().InformeId));

                    Ambiente.InformeCompra = db.Informe.FirstOrDefault(x => x.InformeId.Equals(
                                             db.InformeConfiguracion.Where(y => y.Compra == true)
                                             .FirstOrDefault().InformeId));

                    Ambiente.InformeCorte = db.Informe.FirstOrDefault(x => x.InformeId.Equals(
                                           db.InformeConfiguracion.Where(y => y.Corte == true)
                                           .FirstOrDefault().InformeId));

                    Ambiente.InformeDevCom = db.Informe.FirstOrDefault(x => x.InformeId.Equals(
                                           db.InformeConfiguracion.Where(y => y.DevCom == true)
                                           .FirstOrDefault().InformeId));

                    Ambiente.InformeInvetarios = db.Informe.FirstOrDefault(x => x.InformeId.Equals(
                                           db.InformeConfiguracion.Where(y => y.Inventario == true)
                                           .FirstOrDefault().InformeId));

                    Ambiente.InformeCierresInv = db.Informe.FirstOrDefault(x => x.InformeId.Equals(
                                          db.InformeConfiguracion.Where(y => y.CierresInv == true)
                                          .FirstOrDefault().InformeId));


                    if (Ambiente.InformeTicket == null)
                        Ambiente.Mensaje("!Advertencia! El formato  o regla  de impresión de ticket no existe, esto causará problemas");

                    if (Ambiente.InformeFactura == null)
                        Ambiente.Mensaje("!Advertencia! El formato o regla  de impresión de factura no existe, esto causará problemas");

                    if (Ambiente.InformeCompra == null)
                        Ambiente.Mensaje("!Advertencia! El formato o regla  de impresión  de compra no existe, esto causará problemas");

                    if (Ambiente.InformeDevCom == null)
                        Ambiente.Mensaje("!Advertencia! El formato o regla  de impresión  de devcom no existe, esto causará problemas");

                    if (Ambiente.InformeCorte == null)
                        Ambiente.Mensaje("!Advertencia! El formato o regla  de impresión  de corte no existe, esto causará problemas");

                    if (Ambiente.InformeInvetarios == null)
                        Ambiente.Mensaje("!Advertencia! El formato o regla  de impresión  de inventarios no existe, esto causará problemas");

                    if (Ambiente.InformeCierresInv == null)
                        Ambiente.Mensaje("!Advertencia! El formato o regla  de impresión  de InformeCierresInv no existe, esto causará problemas");


                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error al inicializar db defautls: " + ex.ToString());
            }

            if (!Ambiente.ServerImgAccesible)
                Ambiente.Mensaje("!Advertencia! Las rutas de red indicadas para llegar al servidor no  pasaron la prueba del 75%. Esto causará rendiento deficiente al acceder a recursos en el server.  valor real: " + Ambiente.ServerImgAccesible);
        }
    }
}
