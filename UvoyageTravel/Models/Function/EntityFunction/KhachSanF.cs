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

        public IEnumerable<KhachSan> KhachSanByCity(string city)
        {
            var a = from ks in db.KhachSans
                    join qh in db.QuanHuyens on ks.QuanHuyen_ID equals qh.ID
                    join tp in db.ThanhPhoes on qh.ThanhPho_ID equals tp.ID
                    where (tp.ID == city || qh.ID == city)
                    select ks;
            return a;
        }
        
    }
}