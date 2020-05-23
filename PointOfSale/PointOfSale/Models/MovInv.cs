using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class MovInv
    {
        public int MovInvId { get; set; }
        public string ConceptoMovsInvId { get; set; }
        public int Referencia { get; set; }
        public int Referenciap { get; set; }
        public string Es { get; set; }
        public int Afectacion { get; set; }
        public string ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVta { get; set; }
        public decimal Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string EstacionId { get; set; }

        public virtual ConceptoMovInv ConceptoMovsInv { get; set; }
        public virtual Usuario CreatedByNavigation { get; set; }
    }
}
