using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Inventario
    {
        public int InventarioId { get; set; }
        public string TipoInventario { get; set; }
        public string EstadoDocId { get; set; }
        public int? TipoInventarioId { get; set; }
        public DateTime? FechaBloqueo { get; set; }
        public string UsuarioBloqueoId { get; set; }
        public string UsuarioAutorizacionId { get; set; }
        public DateTime? FechaAutorizacion { get; set; }
        public string UsuarioAutorizacion { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string EstacionId { get; set; }
    }
}
