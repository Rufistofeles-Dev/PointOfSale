using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Inventariop
    {
        public int InventariopId { get; set; }
        public int InventarioId { get; set; }
        public string ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal ExistenciaTeorica { get; set; }
        public decimal ExistenciaFisica { get; set; }
        public decimal Diferencia { get; set; }
        public int? MovInvId { get; set; }
        public int? LoteId { get; set; }
        public decimal CostoParcial { get; set; }
        public decimal Costo { get; set; }
    }
}
