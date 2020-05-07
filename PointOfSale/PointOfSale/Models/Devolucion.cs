﻿using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Devolucion
    {
        public int DevolucionId { get; set; }
        public string ConceptoMovInvId { get; set; }
        public string EstadoDocId { get; set; }
        public string ProveedorId { get; set; }
        public string Documento { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
    }
}
