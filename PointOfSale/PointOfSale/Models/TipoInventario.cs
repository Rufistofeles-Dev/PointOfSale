using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class TipoInventario
    {
        public int TipoInventarioId { get; set; }
        public string Descripcion { get; set; }
        public bool Bloquea { get; set; }
    }
}
