﻿using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    class LoteController
    {

        public bool Delete(Lote o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.Remove(o);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool Delete(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    var temp = db.Lote.FirstOrDefault(x => x.LoteId == Id);
                    if (temp != null)
                    {
                        db.Remove(temp);
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

        public bool InsertOne(Lote o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.Add(o);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertRange(List<Lote> lista)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.AddRange(lista);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public List<Lote> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Lote.ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<Lote> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Lote.Take(cantidad).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<Lote> SelecByProduc(Producto producto)
        {
            try
            {
                using (var db = new DymContext())
                {

                    return db.Lote.Where(x => x.ProductoId.Equals(producto.ProductoId.Trim()) && x.StockRestante > 0)
                        .OrderBy(x => x.CreatedAt).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;

        }

        public List<Lote> SelecByProducConRestanteCeros(Producto producto)
        {
            try
            {
                using (var db = new DymContext())
                {

                    return db.Lote.Where(x => x.ProductoId.Equals(producto.ProductoId.Trim()))
                        .OrderBy(x => x.CreatedAt).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;

        }


        public Lote SelectOne(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Lote.FirstOrDefault(x => x.LoteId == Id);
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }
        public Lote SelectOneByNoLote(string NoLote)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Lote.FirstOrDefault(x => x.NoLote.Equals(NoLote));
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<Lote> SelectOneOverList(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Lote.Where(x => x.LoteId == Id).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public bool Update(Lote o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool UpdateRange(List<Lote> lotes)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.UpdateRange(lotes);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }
        public List<Lote> GetLotes(string productoId, int compraId)
        {

            try
            {
                using (var db = new DymContext())
                {
                    var lotes = db.Lote.Where(x => x.ProductoId.Equals(productoId.Trim()) && x.CompraId == compraId).ToList();
                    if (lotes.Count > 0)
                        return lotes;
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }
        public Lote GetLoteDisponibilidad(string productoId, decimal cantidad)
        {
            List<Lote> lotes = new List<Lote>();
            try
            {

                using (var db = new DymContext())
                {
                    lotes = db.Lote.Where(x => x.ProductoId.Equals(productoId.Trim()) && x.StockRestante > 0)
                       .OrderBy(x => x.CreatedAt).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return lotes.FirstOrDefault();
        }
        public List<Lote> GetLotesDisponibilidad(string productoId, decimal cantidad)
        {
            List<Lote> lotes = new List<Lote>();
            try
            {
                using (var db = new DymContext())
                {
                    lotes = db.Lote.Where(x => x.ProductoId.Equals(productoId.Trim()) && x.StockRestante > 0)
                       .OrderBy(x => x.CreatedAt).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return lotes;
        }
    }
}
