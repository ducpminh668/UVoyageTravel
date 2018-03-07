using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UvoyageTravel.Models.Entity;

namespace UvoyageTravel.Models.Function.EntityFunction
{
    public class KhachSanF
    {
        private UvoyageDBContext db = new UvoyageDBContext();

        public KhachSan FindEnity(int id)
        {
            return db.KhachSans.Find(id);
        }
        
        public IEnumerable<KhachSan> KhachSans
        {
            get { return db.KhachSans;  }
        } 
    }
}