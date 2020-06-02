using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Kardex
    {
        public int KardexId { get; set; }
        public int ConceptoMovInvId { get; set; }
        public string ProductoId { get; set; }
        public int ReferenciaId { get; set; }
        public int ReferenciapId { get; set; }
        public string UsuarioId { get; set; }
        public string Estacionid { get; set; }
        public int ClienteId { get; set; }
        public int ProveedorId { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public string Descripcion { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public decimal Costo { get; set; }
        public decimal CantEntrada { get; set; }
        public decimal VlEntrada { get; set; }
        public decimal CantSalida { get; set; }
        public decimal VlSalida { get; set; }
        public decimal StockRestante { get; set; }
        public decimal CantGlobal { get; set; }
        public decimal VlGlobal { get; set; }
    }
}
