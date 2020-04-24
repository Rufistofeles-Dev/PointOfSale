using Dapper;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class ConexionController
    {
        public List<Conexion> SelectAll()
        {
            try
            {
                return Ambiente.SqliteConnection.Query<Conexion>("SELECT * FROM Conexion;").ToList();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            return null;
        }


        public Conexion SelectOne(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return Ambiente.SqliteConnection.Query<Conexion>("SELECT * FROM Conexion WHERE ConexionId=" + Id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            return null;
        }

    }
}
