﻿using Microsoft.EntityFrameworkCore;
using PointOfSale.Controllers;
using PointOfSale.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Busquedas
{
    public partial class FrmBusqueda : Form
    {

        private string SearchText;
        private int Catalogo;
        private bool SoloConLicencia;

        public Cliente Cliente;
        public Proveedor Proveedor;
        public Producto Producto;
        public Categoria Categoria;
        public Laboratorio Laboratorio;
        public Impuesto Impuesto;
        public Sustancia Sustancia;
        public Almacen Almacen;
        public Estacion Estacion;
        public CClaveProdServ CClaveProdServ;
        public Presentacion Presentacion;
        public UnidadMedida UnidadMedida;
        public Usuario Usuario;
        public FormaPago FormaPago;
        public CMetodopago MetodoPago;
        public CUsocfdi Usocfdi;
        public Venta Venta;
        public Empresa Empresa;
        public CRegimenfiscal Regimenfiscal;
        public Sucursal Sucursal;
        public Informe Informe;


        public FrmBusqueda()
        {
            InitializeComponent();
        }
        public FrmBusqueda(string searchText, int tipoBuscqueda, bool licencia = false)
        {

            if (searchText.Length < 2)
            {
                Ambiente.Mensaje("Ingrese almenos 3 caracteres para filtrar");
                Ambiente.CancelaProceso = true;
            }

            InitializeComponent();
            SearchText = searchText;
            Catalogo = tipoBuscqueda;
            SoloConLicencia = licencia;
            if (!Ambiente.CancelaProceso)
                CargaGrid();
        }

        private void FrmBusqueda_Load(object sender, EventArgs e)
        {
            if (Ambiente.CancelaProceso)
            {
                Ambiente.CancelaProceso = false;
                Close();
            }

        }

        private void CargaGrid()
        {
            switch (Catalogo)
            {
                case (int)Ambiente.TipoBusqueda.Clientes:

                    using (var db = new DymContext())
                    {
                        if (SoloConLicencia)
                        {
                            Grid1.DataSource = db.Cliente.AsNoTracking().Where(x => x.RazonSocial.Contains(SearchText) || x.Negocio.Contains(SearchText) && (x.IsDeleted == false && x.TieneLicencia == true)).OrderBy(x => x.RazonSocial).
                            Select(x => new { x.ClienteId, x.RazonSocial, x.Negocio, x.Rfc }).ToList();

                        }
                        else
                        {
                            Grid1.DataSource = db.Cliente.AsNoTracking().Where(x => x.RazonSocial.Contains(SearchText) || x.Negocio.Contains(SearchText) && x.IsDeleted == false).OrderBy(x => x.RazonSocial).
                            Select(x => new { x.ClienteId, x.RazonSocial, x.Negocio, x.Rfc }).ToList();

                        }

                    }


                    break;

                case (int)Ambiente.TipoBusqueda.Proveedores:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.Proveedor.AsNoTracking().Where(x => x.RazonSocial.Contains(SearchText) || x.Negocio.Contains(SearchText) && x.IsDeleted == false).OrderBy(x => x.RazonSocial).
                            Select(x => new { x.ProveedorId, x.RazonSocial, x.Negocio }).ToList();

                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Productos:

                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.Producto.AsNoTracking().Where(
                       x => x.Descripcion.Contains(SearchText) && x.IsDeleted == false).Select(x => new
                       {
                           x.ProductoId,
                           x.Descripcion
                       }).OrderBy(x => x.Descripcion).ToList();

                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Categorias:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.Categoria.AsNoTracking().Where(x => x.Nombre.Contains(SearchText) && x.IsDeleted == false).OrderBy(x => x.Nombre).
                            Select(x => new { x.CategoriaId, x.Nombre }).ToList();


                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Laboratorios:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.Laboratorio.AsNoTracking().Where(x => x.Nombre.Contains(SearchText) && x.IsDeleted == false).OrderBy(x => x.Nombre).
                            Select(x => new { x.LaboratorioId, x.Nombre }).ToList();


                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Impuestos:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.Impuesto.AsNoTracking().Where(x => x.ImpuestoId.Contains(SearchText) && x.IsDeleted == false).OrderBy(x => x.ImpuestoId).
                            Select(x => new { x.ImpuestoId, x.Tasa }).ToList();


                    }

                    break;

                case (int)Ambiente.TipoBusqueda.Sustancias:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.Sustancia.AsNoTracking().Where(x => x.Nombre.Contains(SearchText) && x.IsDeleted == false).
                            Select(x => new { x.SustanciaId, x.Nombre }).OrderBy(x => x.Nombre).ToList();

                    }

                    break;



                case (int)Ambiente.TipoBusqueda.Estaciones:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.Estacion.AsNoTracking().Where(x => x.Nombre.Contains(SearchText) && x.IsDeleted == false).OrderBy(x => x.Nombre).
                            Select(x => new { x.EstacionId, x.Nombre }).ToList();


                    }
                    break;

                case (int)Ambiente.TipoBusqueda.ClavesSat:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.CClaveProdServ.AsNoTracking().Where(x => x.Nombre.Contains(SearchText) && x.IsDeleted == false).OrderBy(x => x.Nombre).
                        Select(x => new { x.ClaveProdServId, x.Nombre }).ToList();


                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Presentaciones:

                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.Presentacion.AsNoTracking().Where(x => x.Nombre.Contains(SearchText) && x.IsDeleted == false).OrderBy(x => x.Nombre).
                             Select(x => new { x.PresentacionId, x.Nombre }).ToList();


                    }
                    break;

                case (int)Ambiente.TipoBusqueda.UnidadesMedida:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.UnidadMedida.AsNoTracking().Where(x => x.Nombre.Contains(SearchText) && x.IsDeleted == false).OrderBy(x => x.Nombre).
                            Select(x => new { x.UnidadMedidaId, x.Nombre }).ToList();


                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Usuarios:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.Usuario.AsNoTracking().Where(x => x.Nombre.Contains(SearchText) && x.IsDeleted == false).OrderBy(x => x.Nombre).
                            Select(x => new { x.UsuarioId, x.Nombre }).ToList();


                    }
                    break;
                case (int)Ambiente.TipoBusqueda.FormaPago:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.FormaPago.AsNoTracking().Where(x => x.Descripcion.Contains(SearchText)).OrderBy(x => x.Descripcion).
                            Select(x => new { x.FormaPagoId, x.Descripcion }).ToList();


                    }
                    break;
                case (int)Ambiente.TipoBusqueda.MetodoPago:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.CMetodopago.AsNoTracking().Where(x => x.Descripcion.Contains(SearchText)).OrderBy(x => x.Descripcion).
                            Select(x => new { x.MetodoPagoId, x.Descripcion }).ToList();


                    }
                    break;
                case (int)Ambiente.TipoBusqueda.UsoCDFI:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.CUsocfdi.AsNoTracking().Where(x => x.Descripcion.Contains(SearchText)).OrderBy(x => x.Descripcion).
                            Select(x => new { x.UsoCfdiid, x.Descripcion }).ToList();


                    }
                    break;
                case (int)Ambiente.TipoBusqueda.Tickets:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.Venta.AsNoTracking().Where(x => x.NoRef == int.Parse(SearchText) && x.EstadoDocId.Equals("CON")).
                            Select(x => new { Ticket = x.NoRef, Status = x.EstadoDocId, x.DatosCliente }).ToList();


                    }
                    break;
                case (int)Ambiente.TipoBusqueda.Empresas:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.Empresa.AsNoTracking().Where(x => x.Nombre.Contains(SearchText) && !(bool)x.IsDeleted).
                            Select(x => new { ID = x.EmpresaId, x.Nombre }).ToList();


                    }
                    break;
                case (int)Ambiente.TipoBusqueda.RegimenFiscal:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.CRegimenfiscal.AsNoTracking().Where(x => x.Descripcion.Contains(SearchText)).
                            Select(x => new { ID = x.RegimenFiscalId, x.Descripcion }).ToList();


                    }
                    break;
                case (int)Ambiente.TipoBusqueda.Sucursal:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.Sucursal.AsNoTracking().Where(x => x.Nombre.Contains(SearchText)).
                            Select(x => new { ID = x.SucursalId, x.Nombre }).ToList();

                    }
                    break;
                case (int)Ambiente.TipoBusqueda.Reportes:
                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.Informe.AsNoTracking().Where(x => x.Descripcion.Contains(SearchText)).
                           Select(x => new { ID = x.InformeId, x.Descripcion }).ToList();

                    }
                    break;
                default:
                    MessageBox.Show("Error, no hay enumerador para catalogo");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeleccionaRegistro();
            Close();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            this.Dispose();
        }



        private void Grid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionaRegistro();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Abort;
                this.Dispose();
            }
        }

        private void SeleccionaRegistro()
        {
            if (Grid1.Rows.Count <= 0)
            {
                DialogResult = DialogResult.Abort;
                Dispose();
                return;
            }


            switch (Catalogo)
            {
                case (int)Ambiente.TipoBusqueda.Clientes:

                    using (var db = new DymContext())
                    {
                        Cliente = db.Cliente.Where(x => x.ClienteId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                    }

                    break;

                case (int)Ambiente.TipoBusqueda.Proveedores:
                    using (var db = new DymContext())
                    {
                        Proveedor = db.Proveedor.Where(x => x.ProveedorId ==
                    Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Productos:
                    using (var db = new DymContext())
                    {
                        Producto = db.Producto.Where(x => x.ProductoId ==
                    Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Categorias:
                    using (var db = new DymContext())
                    {
                        Categoria = db.Categoria.Where(x => x.CategoriaId ==
                    Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Laboratorios:
                    using (var db = new DymContext())
                    {
                        Laboratorio = db.Laboratorio.Where(x => x.LaboratorioId ==
                    Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Impuestos:
                    using (var db = new DymContext())
                    {
                        Impuesto = db.Impuesto.Where(x => x.ImpuestoId ==
                     Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Sustancias:
                    using (var db = new DymContext())
                    {
                        Sustancia = db.Sustancia.Where(x => x.SustanciaId ==
                      Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                    }

                    break;



                case (int)Ambiente.TipoBusqueda.Estaciones:
                    using (var db = new DymContext())
                    {
                        Estacion = db.Estacion.Where(x => x.EstacionId ==
                    Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.ClavesSat:
                    using (var db = new DymContext())
                    {
                        CClaveProdServ = db.CClaveProdServ.Where(x => x.ClaveProdServId ==
                    Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Presentaciones:

                    using (var db = new DymContext())
                    {
                        Presentacion = db.Presentacion.Where(x => x.PresentacionId ==
                    Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.UnidadesMedida:
                    using (var db = new DymContext())
                    {
                        UnidadMedida = db.UnidadMedida.Where(x => x.UnidadMedidaId ==
                    Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                    }
                    break;
                case (int)Ambiente.TipoBusqueda.Usuarios:
                    using (var db = new DymContext())
                    {
                        Usuario = db.Usuario.Where(x => x.UsuarioId ==
                    Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                    }
                    break;
                case (int)Ambiente.TipoBusqueda.MetodoPago:
                    using (var db = new DymContext())
                    {
                        MetodoPago = db.CMetodopago.Where(x => x.MetodoPagoId ==
                    Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                    }
                    break;
                case (int)Ambiente.TipoBusqueda.FormaPago:
                    using (var db = new DymContext())
                    {
                        FormaPago = db.FormaPago.Where(x => x.FormaPagoId ==
                    Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                    }
                    break;
                case (int)Ambiente.TipoBusqueda.UsoCDFI:
                    using (var db = new DymContext())
                    {
                        Usocfdi = db.CUsocfdi.Where(x => x.UsoCfdiid ==
                    Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                    }
                    break;
                case (int)Ambiente.TipoBusqueda.Tickets:
                    using (var db = new DymContext())
                    {
                        Venta = db.Venta.Where(x => x.NoRef ==
                    (int)Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value).FirstOrDefault();
                    }
                    break;
                case (int)Ambiente.TipoBusqueda.Empresas:
                    using (var db = new DymContext())
                    {
                        Empresa = db.Empresa.Where(x => x.EmpresaId ==
                    (int)Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value).FirstOrDefault();
                    }
                    break;
                case (int)Ambiente.TipoBusqueda.RegimenFiscal:
                    using (var db = new DymContext())
                    {
                        Regimenfiscal = db.CRegimenfiscal.Where(x => x.RegimenFiscalId.Equals(
                    Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString())).FirstOrDefault();
                    }
                    break;
                case (int)Ambiente.TipoBusqueda.Sucursal:
                    using (var db = new DymContext())
                    {
                        Sucursal = db.Sucursal.Where(x => x.SucursalId == (int)Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value).FirstOrDefault();
                    }
                    break;
                case (int)Ambiente.TipoBusqueda.Reportes:
                    using (var db = new DymContext())
                    {
                        Informe = db.Informe.Where(x => x.InformeId.Equals(Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString())).FirstOrDefault();
                    }
                    break;
                default:
                    MessageBox.Show("Error, no hay enumerador para catalogo");
                    break;
            }

            DialogResult = DialogResult.OK;
        }


    }
}
