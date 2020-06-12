using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CierreInventariop
    {
        public int CierreInventariopId { get; set; }
        public int CierreInventarioId { get; set; }
        public string ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal InvInicial { get; set; }
        public decimal Entradas { get; set; }
        public decimal Salidas { get; set; }
        public decimal InvFinal { get; set; }
        public decimal Stock { get; set; }
        public decimal UltimoCosto { get; set; }
        public decimal PrevioVta { get; set; }
        public decimal ValorCosto { get; set; }
        public decimal ValorVenta { get; set; }

        public virtual CierreInventario CierreInventario { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
