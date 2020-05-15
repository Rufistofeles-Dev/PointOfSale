using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class TipoInventarioController
    {
        public bool Delete(TipoInventario o)
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
                    var temp = db.TipoInventario.FirstOrDefault(x => x.TipoInventarioId == Id);
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

        public bool InsertOne(TipoInventario o)
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

        public bool InsertRange(List<TipoInventario> lista)
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

        public List<TipoInventario> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.TipoInventario.ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<TipoInventario> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.TipoInventario.Take(cantidad).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public TipoInventario SelectOne(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.TipoInventario.FirstOrDefault(x => x.TipoInventarioId == Id);
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<TipoInventario> SelectOneOverList(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.TipoInventario.Where(x => x.TipoInventarioId == Id).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public bool Update(TipoInventario o)
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

        public bool DeletePartidas(TipoInventario o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    var partidas = db.Inventariop.Where(x => x.InventarioId == o.TipoInventarioId).ToList();
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
