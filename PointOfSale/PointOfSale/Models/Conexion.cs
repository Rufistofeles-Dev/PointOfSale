﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Conexion
    {

        public int ConexionId { get; set; }
        public string Empresa { get; set; }
        public bool TrustedConnection { get; set; }
        public string Host { get; set; }
        public string InstanceName { get; set; }

        public string DbName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }


        public string TrustedConnectionString()
        {
            TrustedConnection = true;
            return "Server=" + Host + ";Database=" + DbName + ";Trusted_Connection=" + TrustedConnection + ";";
        }
        public string StandardSecurityConnectionString()
        {
            if (InstanceName.Equals(""))
                return "Server=" + Host + ";Database=" + DbName + ";User Id=" + User + ";Password=" + Password + ";";
            else
                return "Server=" + Host + @"\" + InstanceName + ";Database=" + DbName + ";User Id=" + User + ";Password=" + Password + ";";

        }
    }
}
