using PointOfSale.Controllers;
using PointOfSale.Controllers.TablasIntermedia;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Config
{
    public partial class FrmSincronizampv : Form
    {

        //Controllers
        private ProductoSustanciaController productoSustanciaController;
        private ProductoImpuestoController productoImpuestoController;
        private MigrationTableController migrationTableController;
        private MigrationFieldController migrationFieldController;
        private PresentacionController presentacionController;
        private LaboratorioController laboratorioController;
        private CategoriaController categoriaController;
        private SustanciaController sustanciaController;
        private ProductoController productoController;
        private LoteController loteController;

        //Objetos
        private ProductoSustancia productoSustancia;
        private ProductoImpuesto productoImpuesto;
        private MigrationTable migrationTable;
        private MigrationField migrationField;
        private Presentacion presentacion;
        private Laboratorio laboratorio;
        private Categoria categoria;
        private Sustancia sustancia;
        private Producto producto;
        private Lote lote;

        //Listas
        private List<ProductoSustancia> productoSustancias;
        private List<ProductoImpuesto> productoImpuestos;
        private List<MigrationTable> migrationTables;
        private List<MigrationField> migrationFields;
        private List<Presentacion> presentaciones;
        private List<Laboratorio> laboratorios;
        private List<Categoria> categorias;
        private List<Sustancia> sustancias;
        private List<Producto> productos;
        private List<Lote> lotes;

        //Conexion
        private OleDbConnection oleDbConnection;
        private OleDbCommand oleDbCommand;
        private string connectionstring;
        private DataTable dataTable;
        private string Sql;


        public FrmSincronizampv()
        {
            InitializeComponent();
            Initialize();
        }


        #region Metodos

        private void Initialize()
        {
            //Controllers
            productoSustanciaController = new ProductoSustanciaController();
            productoImpuestoController = new ProductoImpuestoController();
            migrationTableController = new MigrationTableController();
            migrationFieldController = new MigrationFieldController();
            presentacionController = new PresentacionController();
            laboratorioController = new LaboratorioController();
            categoriaController = new CategoriaController();
            sustanciaController = new SustanciaController();
            productoController = new ProductoController();
            loteController = new LoteController();

            //Objetos
            productoSustancia = null;
            productoImpuesto = null;
            migrationTable = null;
            migrationField = null;
            presentacion = null;
            laboratorio = null;
            categoria = null;
            sustancia = null;
            producto = null;
            lote = null;

            //Listas
            productoSustancias = new List<ProductoSustancia>();
            productoImpuestos = new List<ProductoImpuesto>();
            migrationTables = new List<MigrationTable>();
            migrationFields = new List<MigrationField>();
            presentaciones = new List<Presentacion>();
            laboratorios = new List<Laboratorio>();
            categorias = new List<Categoria>();
            sustancias = new List<Sustancia>();
            productos = new List<Producto>();
            lotes = new List<Lote>();


            try
            {
                //Conexion vfpro
                Sql = "";
                dataTable = new DataTable();
                connectionstring = "Provider=VFPOLEDB.1;Data Source=" + Ambiente.Empresa.MicroPvdb + ";";
                oleDbConnection = new OleDbConnection(connectionstring);
                oleDbConnection.Open();


                //Llena combo tablas
                migrationTables = migrationTableController.SelectAll();
                CboTabla.DataSource = migrationTables;
                CboTabla.DisplayMember = "Tabla";
                CboTabla.ValueMember = "MigrationTableId";
                CboTabla.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private DataTable GetDataTable(string sqlCommand)
        {
            if (oleDbConnection.State == ConnectionState.Open)
            {
                try
                {
                    oleDbCommand = new OleDbCommand(sqlCommand, oleDbConnection);
                    dataTable = new DataTable();
                    dataTable.Load(oleDbCommand.ExecuteReader());
                    return dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return new DataTable();
                }
            }
            else
                return new DataTable();
        }

        private void SincronizaPresentacion()
        {
            try
            {
                migrationTable = migrationTableController.SelectOne(1);
                migrationFields = migrationFieldController.SelectByTableId(migrationTable.MigrationTableId);
                Sql = "SELECT ";

                foreach (var f in migrationFields)
                {
                    if (migrationFields.Last() == f)
                        Sql += f.Expresion + " FROM " + migrationTable.Tabla;
                    else
                        Sql += f.Expresion + " , ";
                }
                Sql += " " + migrationTable.Condicion;

                GetDataTable(Sql);
                presentacion = null;
                presentaciones = presentacionController.SelectAll();


                foreach (DataRow row in dataTable.Rows)
                {
                    Ambiente.S1 = row["clave"].ToString().Trim().ToUpper();
                    Ambiente.S2 = row["descrip"].ToString().Trim().ToUpper();

                    presentacion = presentaciones.FirstOrDefault(x => x.PresentacionId.ToUpper().Equals(Ambiente.S1));

                    if (presentacion == null)
                    {
                        presentacion = new Presentacion();
                        presentacion.PresentacionId = Ambiente.S1;
                        presentacion.Nombre = Ambiente.S2;
                        presentacion.IsDeleted = false;
                        presentacionController.InsertOne(presentacion);
                    }
                    else
                    {
                        presentacion.Nombre = Ambiente.S2;
                        presentacion.IsDeleted = false;
                        presentacionController.Update(presentacion);
                    }
                }
                Ambiente.Mensaje("Proceso concluido");
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.ToString());
            }
        }
        private void SincronizaFabricantes()
        {
            try
            {
                migrationTable = migrationTableController.SelectOne(3);
                migrationFields = migrationFieldController.SelectByTableId(migrationTable.MigrationTableId);
                Sql = "SELECT ";

                foreach (var f in migrationFields)
                {
                    if (migrationFields.Last() == f)
                        Sql += f.Expresion + " FROM " + migrationTable.Tabla;
                    else
                        Sql += f.Expresion + " , ";
                }
                Sql += " " + migrationTable.Condicion;

                GetDataTable(Sql);
                laboratorio = null;
                laboratorios = laboratorioController.SelectAll();


                foreach (DataRow row in dataTable.Rows)
                {
                    Ambiente.S1 = row["clave"].ToString().Trim().ToUpper();
                    Ambiente.S2 = row["descrip"].ToString().Trim().ToUpper();

                    laboratorio = laboratorios.FirstOrDefault(x => x.LaboratorioId.ToUpper().Equals(Ambiente.S1));

                    if (laboratorio == null)
                    {
                        laboratorio = new Laboratorio();
                        laboratorio.LaboratorioId = Ambiente.S1;
                        laboratorio.Nombre = Ambiente.S2;
                        laboratorio.IsDeleted = false;
                        laboratorioController.InsertOne(laboratorio);
                    }
                    else
                    {
                        laboratorio.Nombre = Ambiente.S2;
                        laboratorio.IsDeleted = false;
                        laboratorioController.Update(laboratorio);
                    }
                }
                Ambiente.Mensaje("Proceso concluido");
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.ToString());
            }
        }
        private void SincronizaCategorias()
        {
            try
            {
                migrationTable = migrationTableController.SelectOne(4);
                migrationFields = migrationFieldController.SelectByTableId(migrationTable.MigrationTableId);
                Sql = "SELECT ";

                foreach (var f in migrationFields)
                {
                    if (migrationFields.Last() == f)
                        Sql += f.Expresion + " FROM " + migrationTable.Tabla;
                    else
                        Sql += f.Expresion + " , ";
                }
                Sql += " " + migrationTable.Condicion;
                GetDataTable(Sql);
                categoria = null;
                categorias = categoriaController.SelectAll();


                foreach (DataRow row in dataTable.Rows)
                {
                    Ambiente.S1 = row["clave"].ToString().Trim().ToUpper();
                    Ambiente.S2 = row["descrip"].ToString().Trim().ToUpper();

                    categoria = categorias.FirstOrDefault(x => x.CategoriaId.ToUpper().Equals(Ambiente.S1));

                    if (categoria == null)
                    {
                        categoria = new Categoria();
                        categoria.CategoriaId = Ambiente.S1;
                        categoria.Nombre = Ambiente.S2;
                        categoria.IsDeleted = false;
                        categoriaController.InsertOne(categoria);
                    }
                    else
                    {
                        categoria.Nombre = Ambiente.S2;
                        categoria.IsDeleted = false;
                        categoriaController.Update(categoria);
                    }
                }
                Ambiente.Mensaje("Proceso concluido");
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.ToString());
            }
        }
        private void SincronizaComponentes()
        {
            try
            {
                migrationTable = migrationTableController.SelectOne(5);
                migrationFields = migrationFieldController.SelectByTableId(migrationTable.MigrationTableId);
                Sql = "SELECT ";

                foreach (var f in migrationFields)
                {
                    if (migrationFields.Last() == f)
                        Sql += f.Expresion + " FROM " + migrationTable.Tabla;
                    else
                        Sql += f.Expresion + " , ";
                }
                Sql += " " + migrationTable.Condicion;
                GetDataTable(Sql);
                sustancia = null;
                sustancias = sustanciaController.SelectAll();


                foreach (DataRow row in dataTable.Rows)
                {
                    Ambiente.S1 = row["clave"].ToString().Trim().ToUpper();
                    Ambiente.S2 = row["descrip"].ToString().Trim().ToUpper();

                    sustancia = sustancias.FirstOrDefault(x => x.SustanciaId.ToUpper().Equals(Ambiente.S1));

                    if (sustancia == null)
                    {
                        sustancia = new Sustancia();
                        sustancia.SustanciaId = Ambiente.S1;
                        sustancia.Nombre = Ambiente.S2.Length == 0 ? Ambiente.S1 : Ambiente.S2;
                        sustancia.IsDeleted = false;
                        sustanciaController.InsertOne(sustancia);
                    }
                    else
                    {
                        sustancia.Nombre = Ambiente.S2;
                        sustancia.IsDeleted = false;
                        sustanciaController.Update(sustancia);
                    }
                }
                Ambiente.Mensaje("Proceso concluido");
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.ToString());
            }
        }
        private void SincronizaProductos()
        {
            try
            {
                migrationTable = migrationTableController.SelectOne(6);
                migrationFields = migrationFieldController.SelectByTableId(migrationTable.MigrationTableId);
                Sql = "SELECT ";

                foreach (var f in migrationFields)
                {
                    if (migrationFields.Last() == f)
                        Sql += f.Expresion + " FROM " + migrationTable.Tabla;
                    else
                        Sql += f.Expresion + " , ";
                }
                Sql += " " + migrationTable.Condicion;
                GetDataTable(Sql);
                producto = null;
                productos = productoController.SelectAll();
                categorias = categoriaController.SelectAll();
                presentaciones = presentacionController.SelectAll();
                laboratorios = laboratorioController.SelectAll();

                decimal p = 0;
                bool b = false;
                foreach (DataRow row in dataTable.Rows)
                {
                    Ambiente.S1 = row["clave"].ToString().Trim().ToUpper();
                    Ambiente.S2 = row["descrip"].ToString().Trim().ToUpper();
                    Ambiente.S3 = row["cupo"].ToString().Trim().ToUpper();

                    Ambiente.S4 = row["presenta"].ToString().Trim().ToUpper();
                    Ambiente.S4 = presentaciones.FirstOrDefault(x => x.PresentacionId.ToUpper().Equals(Ambiente.S4)) == null ? "SYS" : Ambiente.S4;

                    Ambiente.S5 = row["unidades"].ToString().Trim().ToUpper();
                    Ambiente.S6 = row["fabricante"].ToString().Trim().ToUpper();
                    Ambiente.S6 = laboratorios.FirstOrDefault(x => x.LaboratorioId.ToUpper().Equals(Ambiente.S6)) == null ? "SYS" : Ambiente.S6;

                    Ambiente.S8 = row["imagen"].ToString().Trim().ToUpper();
                    Ambiente.S8 = Ambiente.Empresa.DirectorioImg + Path.GetFileName(Ambiente.S8);

                    Ambiente.S9 = row["categoria"].ToString().Trim().ToUpper();
                    Ambiente.S9 = categorias.FirstOrDefault(x => x.CategoriaId.ToUpper().Equals(Ambiente.S9)) == null ? "SYS" : Ambiente.S9;

                    Ambiente.Boolean1 = bool.TryParse(row["encatalogo"].ToString(), out b) == true ? b : false;
                    Ambiente.Boolean2 = bool.TryParse(row["cklote"].ToString(), out b) == true ? b : false;


                    Ambiente.Decimal1 = decimal.TryParse(row["pcompra"].ToString().Trim(), out p) == true ? p : 0;
                    Ambiente.Decimal2 = decimal.TryParse(row["pventa"].ToString().Trim(), out p) == true ? p : 0;
                    Ambiente.Decimal3 = decimal.TryParse(row["pmayoreo"].ToString().Trim(), out p) == true ? p : 0;
                    Ambiente.Decimal4 = decimal.TryParse(row["pcaja"].ToString().Trim(), out p) == true ? p : 0;


                    if (row["tasaimp"].ToString().Trim().ToUpper().Equals("E"))
                        Ambiente.S7 = "SYS";
                    else if (row["tasaimp"].ToString().Trim().ToUpper().Equals("I"))
                        Ambiente.S7 = "IVA";
                    else
                        Ambiente.S7 = "SYS";

                    producto = productos.FirstOrDefault(x => x.ProductoId.ToUpper().Equals(Ambiente.S1));

                    if (producto == null)
                    {
                        producto = new Producto();
                        producto.ProductoId = Ambiente.S1;
                        producto.CategoriaId = Ambiente.S9;
                        producto.PresentacionId = Ambiente.S4;
                        producto.LaboratorioId = Ambiente.S6;
                        producto.Descripcion = Ambiente.S2;
                        producto.Unidades = Ambiente.S5;
                        producto.Contenido = Ambiente.S3;
                        producto.Stock = 0; //atencion
                        producto.PrecioCompra = Ambiente.Decimal1;
                        producto.PrecioCaja = Ambiente.Decimal4;
                        producto.Precio1 = Ambiente.Decimal2;
                        producto.Precio2 = Ambiente.Decimal3;
                        producto.Precio3 = 0;
                        producto.Precio4 = 0;
                        producto.Utilidad1 = Ambiente.Margen(producto.Precio1, producto.PrecioCompra);
                        producto.Utilidad2 = Ambiente.Margen(producto.Precio2, producto.PrecioCompra);
                        producto.Utilidad3 = 0;
                        producto.Utilidad4 = 0;
                        producto.TieneLote = Ambiente.Boolean2;
                        producto.IsDeleted = false;
                        producto.CratedBy = "JMENDOZAJ";
                        producto.CratedAt = DateTime.Now;
                        producto.DeletedBy = null;
                        producto.UpdatedBy = "JMENDOZAJ";
                        producto.LoteId = null; //Atencion
                        producto.UnidadMedidaId = "PZA";
                        producto.ClaveProdServId = "01010101";
                        producto.ClaveUnidadId = "H87";
                        producto.RutaImg = Ambiente.S8;//Atencion
                        producto.ChkCaducidad = producto.TieneLote;
                        producto.Impuesto1Id = Ambiente.S7;
                        producto.Impuesto2Id = "SYS";
                        producto.Impuesto3Id = "SYS";
                        producto.Ocupado = false;
                        producto.IsDeleted = false;
                        producto.Min = 10;
                        producto.Max = 20;
                        productoController.InsertOne(producto);
                    }
                    else
                    {
                        // producto.ProductoId = Ambiente.S1;
                        producto.CategoriaId = Ambiente.S9;
                        producto.PresentacionId = Ambiente.S4;
                        producto.LaboratorioId = Ambiente.S6;
                        producto.Descripcion = Ambiente.S2;
                        producto.Unidades = Ambiente.S5;
                        producto.Contenido = Ambiente.S3;
                        producto.Stock = 0; //atencion
                        producto.PrecioCompra = Ambiente.Decimal1;
                        producto.PrecioCaja = Ambiente.Decimal4;
                        producto.Precio1 = Ambiente.Decimal2;
                        producto.Precio2 = Ambiente.Decimal3;
                        producto.Precio3 = 0;
                        producto.Precio4 = 0;
                        producto.Utilidad1 = Ambiente.Margen(producto.Precio1, producto.PrecioCompra);
                        producto.Utilidad2 = Ambiente.Margen(producto.Precio2, producto.PrecioCompra);
                        producto.Utilidad3 = 0;
                        producto.Utilidad4 = 0;
                        producto.TieneLote = Ambiente.Boolean2;
                        producto.IsDeleted = false;
                        producto.CratedBy = "JMENDOZAJ";
                        producto.CratedAt = DateTime.Now;
                        producto.DeletedBy = null;
                        producto.UpdatedBy = "JMENDOZAJ";
                        producto.LoteId = null; //Atencion
                        producto.UnidadMedidaId = "PZA";
                        producto.ClaveProdServId = "01010101";
                        producto.ClaveUnidadId = "H87";
                        producto.RutaImg = Ambiente.S8; //Atencion
                        producto.ChkCaducidad = producto.TieneLote;
                        producto.Impuesto1Id = Ambiente.S7;
                        producto.Impuesto2Id = "SYS";
                        producto.Impuesto3Id = "SYS";
                        producto.Ocupado = false;
                        producto.IsDeleted = false;
                        productoController.Update(producto);
                    }
                }
                Ambiente.Mensaje("Proceso concluido");
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.ToString());
            }
        }
        private void Sincronizaprodsus()
        {
            try
            {
                migrationTable = migrationTableController.SelectOne(9);
                migrationFields = migrationFieldController.SelectByTableId(migrationTable.MigrationTableId);
                Sql = "SELECT ";

                foreach (var f in migrationFields)
                {
                    if (migrationFields.Last() == f)
                        Sql += f.Expresion + " FROM " + migrationTable.Tabla;
                    else
                        Sql += f.Expresion + " , ";
                }
                Sql += " " + migrationTable.Condicion;
                GetDataTable(Sql);
                productoSustancia = null;
                productoSustancias = productoSustanciaController.SelectAll();
                sustancias = sustanciaController.SelectAll();
                productos = productoController.SelectAll();

                int p = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    Ambiente.S1 = row["producto"].ToString().Trim().ToUpper();
                    Ambiente.S2 = row["componen"].ToString().Trim().ToUpper();
                    //Ambiente.Int1 = int.TryParse(row["orden"].ToString().Trim(), out p) == true ? p : 0;

                    productoSustancia = productoSustancias.FirstOrDefault(x => x.ProductoId.ToUpper().Equals(Ambiente.S1) && x.SustanciaId.ToUpper().Equals(Ambiente.S2));

                    if (productoSustancia == null)
                    {
                        if (productos.FirstOrDefault(x => x.ProductoId.Equals(Ambiente.S1)) == null || sustancias.FirstOrDefault(x => x.SustanciaId.Equals(Ambiente.S2)) == null)
                            continue;

                        productoSustancia = new ProductoSustancia();
                        productoSustancia.ProductoId = Ambiente.S1;
                        productoSustancia.SustanciaId = Ambiente.S2;
                        productoSustancia.Contenido = productos.FirstOrDefault(x => x.ProductoId.Equals(productoSustancia.ProductoId)) == null ? "" : productos.FirstOrDefault(x => x.ProductoId.Equals(productoSustancia.ProductoId)).Contenido;
                        productoSustanciaController.InsertOne(productoSustancia);
                    }
                    else
                    {
                        productoSustancia.Contenido = productos.FirstOrDefault(x => x.ProductoId.Equals(productoSustancia.ProductoId)) == null ? "" : productos.FirstOrDefault(x => x.ProductoId.Equals(productoSustancia.ProductoId)).Contenido;
                        productoSustanciaController.Update(productoSustancia);
                    }
                }
                Ambiente.Mensaje("Proceso concluido");
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.ToString());
            }
        }
        private void SincronizaLotes()
        {
            try
            {
                migrationTable = migrationTableController.SelectOne(8);
                migrationFields = migrationFieldController.SelectByTableId(migrationTable.MigrationTableId);
                Sql = "SELECT ";

                foreach (var f in migrationFields)
                {
                    if (migrationFields.Last() == f)
                        Sql += f.Expresion + " FROM " + migrationTable.Tabla;
                    else
                        Sql += f.Expresion + " , ";
                }
                Sql += " " + migrationTable.Condicion;
                GetDataTable(Sql);
                lote = null;
                lotes = loteController.SelectAll();
                productos = productoController.SelectAll();


                decimal i = 0;
                DateTime dateTime;
                foreach (DataRow row in dataTable.Rows)
                {
                    Ambiente.S1 = row["producto"].ToString().Trim().ToUpper();
                    Ambiente.S2 = row["lote"].ToString().Trim().ToUpper();
                    Ambiente.S3 = "";
                    //var d = row["caducidad"].ToString().Trim();

                    Ambiente.Datetime1 = DateTime.TryParse(row["caducidad"].ToString().Trim(), out dateTime) == true ? dateTime : DateTime.Now;

                    Ambiente.Decimal1 = decimal.TryParse(row["cant"].ToString().Trim(), out i) == true ? i : 0;
                    Ambiente.Decimal2 = decimal.TryParse(row["cant_orig"].ToString().Trim(), out i) == true ? i : 0;
                    Ambiente.Decimal2 = Ambiente.Decimal2 == 0 ? Ambiente.Decimal1 : Ambiente.Decimal2;


                    lote = null;
                    lote = lotes.FirstOrDefault(x => x.ProductoId.ToUpper().Equals(Ambiente.S1) && x.NoLote.ToUpper().Equals(Ambiente.S2.ToUpper()));

                    if (lote == null)
                    {
                        producto = productos.FirstOrDefault(x => x.ProductoId.ToUpper().Equals(Ambiente.S1.ToUpper()));

                        if (producto == null)
                        {
                            Ambiente.S3 += " NO EXISTE PROD, " + Ambiente.S1 + " \n";
                            continue;
                        }


                        lote = new Lote();
                        lote.ProductoId = Ambiente.S1;
                        lote.NoLote = Ambiente.S2.ToUpper();
                        lote.Caducidad = Ambiente.Datetime1;
                        lote.StockInicial = Ambiente.Decimal2;
                        lote.StockRestante = Ambiente.Decimal1;
                        lote.CreatedAt = DateTime.Now;
                        lote.CreatedBy = "JMENDOZAJ";
                        loteController.InsertOne(lote);
                    }
                    else
                    {
                        lote.ProductoId = Ambiente.S1;
                        lote.NoLote = Ambiente.S2.ToUpper();
                        lote.Caducidad = Ambiente.Datetime1;
                        lote.StockInicial = Ambiente.Decimal2;
                        lote.StockRestante = Ambiente.Decimal1;
                        lote.CreatedAt = DateTime.Now;
                        lote.CreatedBy = "JMENDOZAJ";
                        loteController.Update(lote);
                    }
                }

                //foreach (var l in lotes)
                //{
                //    producto = productos.FirstOrDefault(x => x.ProductoId.Equals(l.ProductoId));
                //}
                Ambiente.Mensaje("Proceso concluido");

            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.ToString());
            }
        }
        private void Sincronizaprodsalma()
        {
            try
            {
                migrationTable = migrationTableController.SelectOne(11);
                migrationFields = migrationFieldController.SelectByTableId(migrationTable.MigrationTableId);
                Sql = "SELECT ";

                foreach (var f in migrationFields)
                {
                    if (migrationFields.Last() == f)
                        Sql += f.Expresion + " FROM " + migrationTable.Tabla;
                    else
                        Sql += f.Expresion + " , ";
                }
                Sql += " " + migrationTable.Condicion;
                GetDataTable(Sql);

                productos = productoController.SelectAll();

                decimal i = 0;
                int I = 0;
                Ambiente.S20 = "AJUSTADO X SINCRONIZACION \n";

                foreach (DataRow row in dataTable.Rows)
                {
                    Ambiente.S1 = row["producto"].ToString().Trim().ToUpper();
                    Ambiente.Decimal1 = decimal.TryParse(row["existenc"].ToString().Trim(), out i) == true ? i : 0;
                    Ambiente.Int1 = int.TryParse(row["min"].ToString().Trim(), out I) == true ? I : 0;
                    Ambiente.Int2 = int.TryParse(row["max"].ToString().Trim(), out I) == true ? I : 0;

                    producto = productos.FirstOrDefault(x => x.ProductoId.ToUpper().Equals(Ambiente.S1));

                    if (producto != null)
                    {
                        producto.Stock = Ambiente.Decimal1;
                        producto.Min = Ambiente.Int1;
                        producto.Max = Ambiente.Int2;

                        if (producto.TieneLote)
                        {
                            var lotes = loteController.SelecByProducConRestanteCeros(producto);
                            Ambiente.Decimal6 = 0;

                            if (lotes != null)
                            {
                                if (lotes.Count > 0)
                                {
                                    Ambiente.Decimal6 = Ambiente.Decimal1 / lotes.Count;
                                    foreach (var l in lotes)
                                    {
                                        l.StockInicial = Ambiente.Decimal6;
                                        l.StockRestante = Ambiente.Decimal6;
                                        loteController.Update(l);
                                    }
                                }
                                else
                                {
                                    var l = new Lote();
                                    l.CompraId = 0;
                                    l.NoLote = "ABCD";
                                    l.ProductoId = producto.ProductoId;
                                    l.StockInicial = producto.Stock;
                                    l.StockRestante = producto.Stock;
                                    l.Caducidad = DateTime.Now.AddDays(365);
                                    l.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                                    l.CreatedAt = DateTime.Now;
                                    l.ReferenciaInt = 0;
                                    l.ReferenciaString = "AJUSTADO X SINCRONIZACION";
                                    loteController.InsertOne(l);

                                    Ambiente.S20 += " PRODUCTOID: " + producto.ProductoId + " STOCK: " + producto.Stock + " CONTROL_LOTE: TRUE LOTES ENCONTRADOS: " + lotes.Count + "\n";
                                }

                            }
                        }

                        productoController.Update(producto);
                    }
                    else
                        Ambiente.S2 += " NO EXISTE " + Ambiente.S1 + " \n";
                }
                Ambiente.Mensaje("Proceso concluido");
                if (Ambiente.S20.Length > 30)
                {
                    Ambiente.Mensaje(Ambiente.S20);
                }

            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.ToString());
            }
        }

        private void CargaGrid()
        {

            if (migrationTable == null) return;
            Malla.Rows.Clear();

            migrationFields = migrationFieldController.SelectByTableId(migrationTable.MigrationTableId);
            foreach (var f in migrationFields)
            {
                Malla.Rows.Add();
                Malla.Rows[Malla.RowCount - 1].Cells[0].Value = f.MigrationFieldId;
                Malla.Rows[Malla.RowCount - 1].Cells[1].Value = f.MigrationTableId;
                Malla.Rows[Malla.RowCount - 1].Cells[2].Value = f.Campo;
                Malla.Rows[Malla.RowCount - 1].Cells[3].Value = f.Expresion;
            }
        }
        private void AddCampo()
        {
            if (migrationTable == null)
            {
                Ambiente.Mensaje("Selecciona una tabla");
                return;
            }
            Malla.Rows.Add();
            Malla.Rows[Malla.RowCount - 1].Cells[0].Value = "NewId";
            Malla.Rows[Malla.RowCount - 1].Cells[1].Value = migrationTable.MigrationTableId;
            Malla.Rows[Malla.RowCount - 1].Cells[2].Value = "Rellenar";
            Malla.Rows[Malla.RowCount - 1].Cells[3].Value = "Rellenar";
        }
        private void BorrarCampo()
        {
            if (migrationTable == null) return;
            if (Malla.RowCount == 0) return;

            if (Ambiente.Pregunta("Realmente quiere borrar el campo " + Malla.Rows[Malla.CurrentCell.RowIndex].Cells[2].Value.ToString()))
            {
                if (Ambiente.Pregunta("Si eliminas " + Malla.Rows[Malla.CurrentCell.RowIndex].Cells[2].Value.ToString() + " puede ocasionar problemas ¿CONTINUAR?"))
                {
                    if (migrationFieldController.Delete((int)Malla.Rows[Malla.CurrentCell.RowIndex].Cells[0].Value))
                    {
                        CargaGrid();
                        Ambiente.Mensaje("Proceso completado");
                    }
                }
            }
        }
        private void SalvarCampo()
        {
            if (migrationTable == null)
            {
                Ambiente.Mensaje("Selecciona una tabla");
                return;
            }

            // migrationFields = migrationFieldController.SelectByTableId(migrationTable.MigrationTableId);

            foreach (DataGridViewRow row in Malla.Rows)
            {
                if (row.Cells[0].Value.Equals("NewId"))
                {
                    migrationField = new MigrationField();
                    migrationField.MigrationTableId = (int)row.Cells[1].Value;
                    migrationField.Campo = row.Cells[2].Value.ToString().Trim();
                    migrationField.Expresion = row.Cells[3].Value.ToString().Trim();
                    migrationField.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                    migrationFieldController.InsertOne(migrationField);
                }
            }

            if (Ambiente.BoolValue)
            {
                foreach (var item in migrationFields)
                    migrationFieldController.Update(item);

                Ambiente.BoolValue = false;
            }
            Ambiente.Mensaje("Proceso concluido");
        }
        private void ActualizaCampo(string valor, int rowIndex)
        {
            if ((rowIndex < migrationFields.Count))
            {
                Ambiente.BoolValue = true;
                if (valor.Trim().Length > 0)
                {
                    migrationFields[rowIndex].Campo = valor.Trim();
                    Malla.Rows[rowIndex].Cells[2].Value = valor.Trim();
                }
                else
                {
                    Ambiente.Mensaje("!Advertencia! Dejar la campo en blanco causará problemas");
                }
            }
        }
        private void ActualizaExpr(string valor, int rowIndex)
        {
            if ((rowIndex < migrationFields.Count))
            {
                Ambiente.BoolValue = true;
                if (valor.Trim().Length > 0)
                {
                    migrationFields[rowIndex].Expresion = valor.Trim();
                    Malla.Rows[rowIndex].Cells[3].Value = valor.Trim();
                }
                else
                {
                    Ambiente.Mensaje("!Advertencia! Dejar la expresion en blanco causará problemas");
                }
            }
        }

        #endregion




        #region Eventos

        private void BtnSincPresentaciones_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SincronizaPresentacion();
        }

        private void BtnSincFabricantes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SincronizaFabricantes();
        }

        private void BtnSincCategorias_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SincronizaCategorias();
        }

        private void BtnSincComponentes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SincronizaComponentes();
        }

        private void BtnSincProds_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SincronizaProductos();
        }

        private void BtnSincProdcomp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sincronizaprodsus();
        }

        private void BtnSincProdImp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sincronizaprodsalma();
        }

        private void BtnSincronizaTodo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Ambiente.LoggedUser.UsuarioId.Equals("JMENDOZAJ"))
            {
                using (var db = new DymContext())
                {
                    //  db.Database

                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAddCampo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddCampo();
        }


        private void BtnSalvarCampos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SalvarCampo();
        }



        private void BtnBorrarCampo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BorrarCampo();
        }




        private void FrmSincronizampv_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (oleDbConnection.State == ConnectionState.Open)
            {
                oleDbConnection.Close();
                MessageBox.Show("Conexion cerrada");
            }
        }

        #endregion

        private void CboTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            migrationTable = CboTabla.SelectedItem as MigrationTable;
            CargaGrid();
        }

        private void Malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Malla.CurrentCell.Value == null)
            {
                Ambiente.Mensaje("Este cambio será desconsiderado, el campo y expresion es obligatorio");
                return;
            }

            if (Malla.CurrentCell.ColumnIndex == 2)
            {
                //Campo
                ActualizaCampo(Malla.CurrentCell.Value.ToString(), e.RowIndex);

            }
            if (Malla.CurrentCell.ColumnIndex == 3)
            {
                //Expresion
                ActualizaExpr(Malla.CurrentCell.Value.ToString(), e.RowIndex);

            }
        }

        private void BtnSincLotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SincronizaLotes();
        }
    }
}
