using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class MigrationFieldController
    {
        public bool Delete(MigrationField o)
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
                    var temp = db.MigrationField.FirstOrDefault(x => x.MigrationFieldId == Id);
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

        public bool InsertOne(MigrationField o)
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

        public bool InsertRange(List<MigrationField> lista)
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

        public List<MigrationField> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.MigrationField.ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }
        public List<MigrationField> SelectByTableId(int id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.MigrationField.Where(x => x.MigrationTableId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<MigrationField> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.MigrationField.Take(cantidad).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public MigrationField SelectOne(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.MigrationField.FirstOrDefault(x => x.MigrationFieldId == Id);
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<MigrationField> SelectOneOverList(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.MigrationField.Where(x => x.MigrationFieldId == Id).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public bool Update(MigrationField o)
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

        public bool DeletePartidas(MigrationField devolucion)
        {
            try
            {
                using (var db = new DymContext())
                {
                    var partidas = db.MigrationField.Where(x => x.MigrationTableId == devolucion.MigrationTableId).ToList();
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
