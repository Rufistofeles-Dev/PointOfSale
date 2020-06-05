using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class CierreInventariopController
    {
        public bool Delete(CierreInventariop o)
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

        public bool Delete(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    var temp = db.CierreInventariop.FirstOrDefault(x => x.CierreInventariopId == Id);
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

        public bool InsertOne(CierreInventariop o)
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

        public bool InsertRange(List<CierreInventariop> lista)
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

        public List<CierreInventariop> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.CierreInventariop.ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<CierreInventariop> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.CierreInventariop.Take(cantidad).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public CierreInventariop SelectOne(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.CierreInventariop.FirstOrDefault(x => x.CierreInventariopId == Id);
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<CierreInventariop> SelectOneOverList(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.CierreInventariop.Where(x => x.CierreInventariopId == Id).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public bool Update(CierreInventariop o)
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

        public bool DeletePartidas(CierreInventario o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    var partidas = db.CierreInventariop.Where(x => x.CierreInventarioId == o.CierreInventarioId).ToList();
                    if (partidas != null)
                    {
                        db.RemoveRange(partidas);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }
    }
}
