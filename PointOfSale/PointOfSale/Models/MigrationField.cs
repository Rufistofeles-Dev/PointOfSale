using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class MigrationField
    {
        public int MigrationFieldId { get; set; }
        public int MigrationTableId { get; set; }
        public string Campo { get; set; }
        public string Expresion { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateBy { get; set; }

        public virtual MigrationTable MigrationTable { get; set; }
    }
}
