using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UvoyageTravel
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "chitiet",
             url: "chi-tiet-khach-san/{id}",
             defaults: new { controller = "Order", action = "DatPhong", id = UrlParameter.Optional },
             namespaces: new[] { "UvoyageTravel.Controllers" }
         );

            routes.MapRoute(
              name: "danhsach",
              url: "danh-sach-khach-san/{id}",
              defaults: new { controller = "Home", action = "DanhSachKhachSan", id = UrlParameter.Optional },
              namespaces: new[] { "UvoyageTravel.Controllers" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces :new[] { "UvoyageTravel.Controllers" }
            );



           

        }
    }
}
