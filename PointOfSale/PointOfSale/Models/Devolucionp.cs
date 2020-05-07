﻿using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Devolucionp
    {
        public int DevolucionpId { get; set; }
        public int DevolucionId { get; set; }
        public string ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public int? LoteId { get; set; }
        public string NoLote { get; set; }
        public DateTime? Caducidad { get; set; }
        public string ImpuestoId1 { get; set; }
        public string ImpuestoId2 { get; set; }
        public decimal Impuesto1 { get; set; }
        public decimal Impuesto2 { get; set; }
        public decimal ImporteImpuesto1 { get; set; }
        public decimal ImporteImpuesto2 { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}
