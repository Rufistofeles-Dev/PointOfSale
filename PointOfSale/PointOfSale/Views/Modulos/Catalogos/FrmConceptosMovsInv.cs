using PointOfSale.Controllers;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Catalogos
{
    public partial class FrmConceptosMovsInv : Form
    {
        private ConceptoMovInv objeto;
        private ConceptoMovInvController conceptoMovInvController;

        public FrmConceptosMovsInv()
        {
            InitializeComponent();
            Inicializa();
        }
        public FrmConceptosMovsInv(dynamic o)
        {
            InitializeComponent();
            Inicializa();
            objeto = (ConceptoMovInv)o;
            TxtClave.Text = objeto.ConceptoMovInvId;
        }
        private void Inicializa()
        {
            conceptoMovInvController = new ConceptoMovInvController();
            objeto = null;
            CboES.SelectedIndex = 0;
            CboDigitacion.SelectedIndex = 0;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            InsertOrUpdate();
        }

        private void InsertOrUpdate()
        {
            if (objeto == null)
            {
                if (TxtClave.Text.Trim().Length == 0)
                {
                    Ambiente.Mensaje("Proceso abortado");
                    return;
                }
                objeto = new ConceptoMovInv();
                objeto.ConceptoMovInvId = TxtClave.Text.Trim();
                objeto.Descripcion = TxtNombre.Text.Trim();
                objeto.Es = CboES.Text.Trim();
                objeto.Afectacion = objeto.Es.Equals("E") ? 1 : -1;
                objeto.Digitacion = CboDigitacion.Text.Trim().Equals("SI") ? true : false;


                if (conceptoMovInvController.InsertOne(objeto))
                {
                    Ambiente.Mensaje("Cambios guardados");
                    Close();
                }
                else
                    Ambiente.Mensaje("Algo salio mal");

            }
            else
            {
                if (TxtClave.Text.Trim().Length == 0)
                {
                    Ambiente.Mensaje("Proceso abortado");
                    return;
                }
                objeto.ConceptoMovInvId = TxtClave.Text.Trim();
                objeto.Descripcion = TxtNombre.Text.Trim();
                objeto.Es = CboES.Text.Trim();
                objeto.Afectacion = objeto.Es.Equals("E") ? 1 : -1;
                objeto.Digitacion = CboDigitacion.Text.Trim().Equals("SI") ? true : false;

                if (conceptoMovInvController.Update(objeto))
                {
                    Ambiente.Mensaje("Cambios guardados");
                    Close();
                }
                else
                    Ambiente.Mensaje("Algo salio mal");
            }
        }

        private void TxtClave_Leave(object sender, EventArgs e)
        {
            LlenaCampos();
        }

        private void LlenaCampos()
        {
            if (objeto == null)
                objeto = conceptoMovInvController.SelectOne(TxtClave.Text);
            if (objeto == null)
                return;

            TxtClave.Text = objeto.ConceptoMovInvId;
            TxtNombre.Text = objeto.Descripcion;
            if (objeto.Es.Trim().Equals("E")) CboES.SelectedIndex = 0; else CboES.SelectedIndex = 1;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
