using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class FormaPagoController
    {
        public bool Delete(FormaPago o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.Remove(o);
                    return db.SaveChanges() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool Delete(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    var temp = db.FormaPago.FirstOrDefault(x => x.FormaPagoId == Id);
                    if (temp != null)
                    {

                        db.Remove(temp);
                        return db.SaveChanges() > 0 ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertOne(FormaPago o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.Add(o);
                    return db.SaveChanges() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertRange(List<FormaPago> lista)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.AddRange(lista);
                    return db.SaveChanges() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public List<FormaPago> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.FormaPago.ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<FormaPago> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.FormaPago.Take(cantidad).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public FormaPago SelectOne(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.FormaPago.FirstOrDefault(x => x.FormaPagoId == Id);
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<FormaPago> SelectOneOverList(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.FormaPago.Where(x => x.FormaPagoId == Id).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public bool Update(FormaPago o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    return db.SaveChanges() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

    
    }
}
