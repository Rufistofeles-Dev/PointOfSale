﻿using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class InformeConfiguracion
    {
        public int InformeConfiguracionId { get; set; }
        public string InformeId { get; set; }
        public string Regla { get; set; }
        public bool Ticket { get; set; }
        public bool Factura { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Informe Informe { get; set; }
    }
}
