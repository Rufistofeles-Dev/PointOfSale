using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class TipoInventario
    {
        public TipoInventario()
        {
            Inventario = new HashSet<Inventario>();
        }

        public int TipoInventarioId { get; set; }
        public string Descripcion { get; set; }
        public bool Bloquea { get; set; }

        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}
