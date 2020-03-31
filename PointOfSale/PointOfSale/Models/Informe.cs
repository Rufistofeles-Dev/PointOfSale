using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Informe
    {
        public Informe()
        {
            InformeConfiguracion = new HashSet<InformeConfiguracion>();
            InformeParametro = new HashSet<InformeParametro>();
        }

        public string InformeId { get; set; }
        public string Descripcion { get; set; }
        public string Guid { get; set; }
        public string Codigo { get; set; }
        public bool Sistema { get; set; }
        public int InformeCateforiaId { get; set; }

        public virtual InformeCategoria InformeCateforia { get; set; }
        public virtual ICollection<InformeConfiguracion> InformeConfiguracion { get; set; }
        public virtual ICollection<InformeParametro> InformeParametro { get; set; }
    }
}
