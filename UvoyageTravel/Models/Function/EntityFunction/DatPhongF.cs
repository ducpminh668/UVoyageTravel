using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UvoyageTravel.Models.Entity;

namespace UvoyageTravel.Models.Function.EntityFunction
{
    public class DatPhongF
    {
        private UvoyageDBContext db = new UvoyageDBContext();

        public DatPhong Create(DatPhong Order)
        {
            db.DatPhongs.Add(Order);
            db.SaveChanges();
            return Order;
        }
    }
}