using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Inventario
    {
        public Inventario()
        {
            Inventariop = new HashSet<Inventariop>();
        }

        public int InventarioId { get; set; }
        public string TipoInventario { get; set; }
        public string EstadoDocId { get; set; }
        public int TipoInventarioId { get; set; }
        public DateTime FechaBloqueo { get; set; }
        public string UsuarioBloqueoId { get; set; }
        public string UsuarioAutorizacionId { get; set; }
        public string UsuarioAutorizacion { get; set; }
        public DateTime FechaAutorizacion { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string EstacionId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Usuario CreatedByNavigation { get; set; }
        public virtual Estacion Estacion { get; set; }
        public virtual TipoInventario TipoInventarioNavigation { get; set; }
        public virtual ICollection<Inventariop> Inventariop { get; set; }
    }
}
