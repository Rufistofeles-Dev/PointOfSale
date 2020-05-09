using PointOfSale.Controllers;
using PointOfSale.Controllers.TablasIntermedia;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
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

        }

        private void BtnSincCategorias_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void BtnSincComponentes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void BtnSincProds_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void BtnSincProdcomp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void BtnSincProdImp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void BtnSincronizaTodo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

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

    }
}
