using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UvoyageTravel.Models.Entity;

namespace UvoyageTravel.Models.Function.EntityFunction
{
    public class PhongKhachSanF
    {
        private UvoyageDBContext db = new UvoyageDBContext();
        
        public PhongKhachSan FindEnity(int id)
        {
            return db.PhongKhachSans.Find(id);
        }
    }
}