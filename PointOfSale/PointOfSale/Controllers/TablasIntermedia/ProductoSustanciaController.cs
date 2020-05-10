using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers.TablasIntermedia
{
    class ProductoSustanciaController
    {
        public string InsertRange(List<ProductoSustancia> lista)
        {
            List<ProductoSustancia> listaCorrectos = new List<ProductoSustancia>();
            List<string> errores = new List<string>();
            string correctos = string.Empty;

            try
            {
                using (var db = new DymContext())
                {
                    foreach (var item in lista)
                    {
                        var producto = db.Producto.FirstOrDefault(x => x.ProductoId == item.ProductoId);
                        var sustancia = db.Sustancia.FirstOrDefault(x => x.SustanciaId == item.SustanciaId);
                        if (producto != null && sustancia != null)
                        {

                            var prodsus = new ProductoSustancia();
                            prodsus.ProductoId = producto.ProductoId;
                            prodsus.SustanciaId = sustancia.SustanciaId;
                            prodsus.Contenido = item.Contenido;

                            listaCorrectos.Add(prodsus);

                        }
                        else
                        {
                            errores.Add(item.SustanciaId + ", NO EXISTE EN LAS SUSTANCIAS o, " + item.ProductoId + ", NO EXISTE EN LOS PRODUCTOS");
                        }
                    }
                    db.ProductoSustancia.AddRange(listaCorrectos);
                    db.SaveChanges();
                    correctos += "SE GUARDARON " + listaCorrectos.Count + " REGISTOS\n\n";
                    correctos += "SE OMITIERON " + errores.Count + " REGISTOS\n\n";
                    correctos += "COPIE Y PEGUE LOS DETALLES\n\n ";
                    var result = String.Join(" \n ", errores.ToArray());
                    correctos += result;
                }
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + this.GetType().Name + "\n" + ex.ToString());
            }

            return correctos;

        }



        public bool Delete(ProductoSustancia o)
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
        public bool Update(ProductoSustancia o)
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


        public bool InsertOne(ProductoSustancia o)
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


        public List<ProductoSustancia> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.ProductoSustancia.ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<ProductoSustancia> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.ProductoSustancia.Take(cantidad).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salio mal con: " + MethodBase.GetCurrentMethod().Name + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }
     


    }
}
