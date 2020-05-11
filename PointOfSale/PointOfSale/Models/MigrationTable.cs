using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class MigrationTable
    {
        public MigrationTable()
        {
            MigrationField = new HashSet<MigrationField>();
        }

        public int MigrationTableId { get; set; }
        public string Tabla { get; set; }
        public DateTime? UltSincronizacion { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public string Condicion { get; set; }

        public virtual ICollection<MigrationField> MigrationField { get; set; }
    }
}
