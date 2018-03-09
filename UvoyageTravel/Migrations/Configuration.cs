namespace UvoyageTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;

    internal sealed class Configuration : DbMigrationsConfiguration<UvoyageTravel.Models.Entity.UvoyageDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UvoyageTravel.Models.Entity.UvoyageDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //var a = HttpContext.Current.Server.MapPath("~/Views/Shared/Footer.html");
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", @"Views/Shared/Footer.html");
            //string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Content/Footer.html");
            context.Footers.AddOrUpdate(
                  p => p.ID,
                  new Models.Entity.Footer { Content = File.ReadAllText(filePath) }
                );

            context.Slides.AddOrUpdate(
                p => p.ID,
                new Models.Entity.Slide { Img = "banner-1.png", Description = "Uvoyage-banner-1" },
                new Models.Entity.Slide { Img = "banner-2.png", Description = "Uvoyage-banner-2" }
                );

            context.KhachSans.AddOrUpdate(
                p => p.ID,
                new Models.Entity.KhachSan { TenKhachSan = "Melia Hanoi", DiaChi = "44B Ly Thuong Kiet Street, Quận Hoàn Kiếm, Hà Nội", GiaTien = 4707109, UuTien = 1, Img = "106957226.jpg" },
                new Models.Entity.KhachSan { TenKhachSan = "Somerset Grand Hanoi", DiaChi = "44B Ly Thuong Kiet Street, Quận Hoàn Kiếm, Hà Nội", GiaTien = 3681627, UuTien = 2, Img = "106957226.jpg" },
                new Models.Entity.KhachSan { TenKhachSan = "Somerset West Point Hanoi", DiaChi = "44B Ly Thuong Kiet Street, Quận Hoàn Kiếm, Hà Nội", GiaTien = 2500865, UuTien = 3, Img = "106957226.jpg" },
                new Models.Entity.KhachSan { TenKhachSan = "Crowne Plaza West Hanoi", DiaChi = "44B Ly Thuong Kiet Street, Quận Hoàn Kiếm, Hà Nội", GiaTien = 4707337, UuTien = 4, Img = "106957226.jpg" }
                );

            context.Users.AddOrUpdate(
                p => p.Username,
                new Models.Entity.User { Username = "duc", HoTen ="duc123", Password = "123"},
                new Models.Entity.User { Username = "cuong", HoTen ="cuong123", Password = "123"},
                new Models.Entity.User { Username = "duong", HoTen ="duong123", Password = "123"},
                new Models.Entity.User { Username = "dat", HoTen ="dat123", Password = "123"},
                new Models.Entity.User { Username = "trong", HoTen ="trong123", Password = "123"}
                );

            context.Roles.AddOrUpdate(
               p => p.ID,
               new Models.Entity.Role { RoleName = "SuperAdmin"},
               new Models.Entity.Role { RoleName = "Admin" },
               new Models.Entity.Role { RoleName = "User" },
               new Models.Entity.Role { RoleName = "Manager" }
               );

            context.UserInRoles.AddOrUpdate(
               p => p.Username,
               new Models.Entity.UserInRole { Username = "duc", ID_Role = 1},
               new Models.Entity.UserInRole { Username = "duc", ID_Role = 2},
               new Models.Entity.UserInRole { Username = "duc", ID_Role = 3},
               new Models.Entity.UserInRole { Username = "cuong", ID_Role = 2},
               new Models.Entity.UserInRole { Username = "cuong", ID_Role = 3},
               new Models.Entity.UserInRole { Username = "duong", ID_Role = 3},
               new Models.Entity.UserInRole { Username = "trong", ID_Role = 3},
               new Models.Entity.UserInRole { Username = "dat", ID_Role = 3}


               );

            context.ThanhPhoes.AddOrUpdate(
                p => p.ID,
                new Models.Entity.ThanhPho { ID = "ha-noi", TenThanhPho = "Ha Noi", Ordering = 1, Img = "ha-noi.jpg", HotStatus = true },
                new Models.Entity.ThanhPho { ID = "ha-long", TenThanhPho = "Ha Long", Ordering = 2, Img = "ha-long.jpg", HotStatus = true },
                new Models.Entity.ThanhPho { ID = "sa-pa", TenThanhPho = "Sa Pa", Ordering = 3, Img = "ha-long.jpg", HotStatus = true },
                new Models.Entity.ThanhPho { ID = "hue", TenThanhPho = "Hue", Ordering = 5, Img = "ha-long.jpg", HotStatus = true },
                new Models.Entity.ThanhPho { ID = "da-nang", TenThanhPho = "Da nang", Ordering = 6, Img = "ha-long.jpg", HotStatus = true },
                new Models.Entity.ThanhPho { ID = "ho-chi-minh", TenThanhPho = "Ho Chi Minh", Ordering = 7, Img = "ha-noi.jpg", HotStatus = true },
                new Models.Entity.ThanhPho { ID = "da-lat", TenThanhPho = "Da Lat", Ordering = 8, Img = "ha-noi.jpg", HotStatus = true },
                new Models.Entity.ThanhPho { ID = "phu-quoc", TenThanhPho = "Phu Quoc", Ordering = 9, Img = "ha-long.jpg", HotStatus = true },
                new Models.Entity.ThanhPho { ID = "khanh-hoa", TenThanhPho = "Khanh-Hoa", Ordering = 9, Img = "ha-long.jpg", HotStatus = true }
                );

            context.QuanHuyens.AddOrUpdate(
                p => p.ID,
                new Models.Entity.QuanHuyen { ID = "thanh-tri", TenQuanHuyen = "Thanh Tri", ThanhPho_ID = "ha-noi" },
                new Models.Entity.QuanHuyen { ID = "hoang-mai", TenQuanHuyen = "Thanh Tri", ThanhPho_ID = "ha-noi" },
                new Models.Entity.QuanHuyen { ID = "ba-dinh", TenQuanHuyen = "Thanh Tri", ThanhPho_ID = "ha-noi" },
                new Models.Entity.QuanHuyen { ID = "cau-giay", TenQuanHuyen = "Thanh Tri", ThanhPho_ID = "ha-noi" },
                new Models.Entity.QuanHuyen { ID = "long-bien", TenQuanHuyen = "Thanh Tri", ThanhPho_ID = "ha-noi" },
                new Models.Entity.QuanHuyen { ID = "hai-ba-trung", TenQuanHuyen = "Thanh Tri", ThanhPho_ID = "ha-noi" }
                );

            context.PhongKhachSans.AddOrUpdate(
                p => p.ID,
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Premium Giường Đôi - Cho 1 người ở - Không hoàn tiền - Bao bữa sáng - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 1 , GiaTien = 500000},
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Premium Giường Đôi - Không hoàn tiền - Bao bữa sáng - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 1, GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Grand Premium Giường Đôi - Cho 1 người ở - Không hoàn tiền - Bao bữa sáng - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 1 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Grand Premium Giường Đôi - Cho 1 người ở - Không hoàn tiền - Bao bữa sáng - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 1 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Grand Premium Giường Đôi - Không hoàn tiền - Bao bữa sáng - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 1 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Level Premium - Cho 1 người ở - Không hoàn tiền - Bao bữa sáng - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 1 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Level Premium - Không hoàn tiền - Bao bữa sáng - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 1 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "The Level Suite - Không hoàn tiền - Bao bữa sáng - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 1 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "The Level Suite - Cho 1 người ở - Không hoàn tiền - Bao bữa sáng - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 1 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Hilton Deluxe 2 Giường đơn - Cho 1 người ở - Không hoàn tiền", Img = "detail-room.jpg", KhachSan_ID = 2 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Hilton Deluxe 2 Giường đơn - Không hoàn tiền", Img = "detail-room.jpg", KhachSan_ID = 2 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Hilton Deluxe 2 Giường đơn - Cho 1 người ở - Không hoàn tiền - Bao bữa sáng", Img = "detail-room.jpg", KhachSan_ID = 2, GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Hilton Executive 2 Giường đơn có quyền lui tới Executive Lounge - Cho 1 người ở - Không hoàn tiền", Img = "detail-room.jpg", KhachSan_ID = 2 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Hilton Executive 2 Giường đơn có quyền lui tới Executive Lounge - Không hoàn tiền", Img = "detail-room.jpg", KhachSan_ID = 2 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Hilton Executive 2 Giường đơn có quyền lui tới Executive Lounge - Không hoàn tiền - Bao bữa sáng", Img = "detail-room.jpg", KhachSan_ID = 2 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Hilton Executive Giường đôi có quyền lui tới Executive Lounge - Cho 1 người ở - Không hoàn tiền", Img = "detail-room.jpg", KhachSan_ID = 2 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Hilton Executive Giường đôi có quyền lui tới Executive Lounge - Cho 1 người ở - Không hoàn tiền - Bao bữa sáng", Img = "detail-room.jpg", KhachSan_ID = 2 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Hilton Executive Giường đôi có quyền lui tới Executive Lounge - Cho 1 người ở - Không hoàn tiền - Bao bữa sáng2", Img = "detail-room.jpg", KhachSan_ID = 2 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Studio Executive - Không hoàn tiền - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 3 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Căn hộ Deluxe 1 Phòng ngủ - Không hoàn tiền - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 3 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Căn hộ Premier 2 phòng ngủ - Không hoàn tiền - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 3 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Căn hộ Executive 3 phòng ngủ - Không hoàn tiền - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 3 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Deluxe 2 giường đơn - Hút thuốc. - Không hoàn tiền - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 3 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Deluxe 2 giường đơn - Hút thuốc. - Không hoàn tiền - Bao bữa sáng - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 4 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Premier có Giường cỡ King - Hút thuốc - Không hoàn tiền - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 4 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Club có giường cỡ king - Không được hút thuốc - Không hoàn tiền - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 4 , GiaTien = 500000 },
                new Models.Entity.PhongKhachSan { TenPhong = "Phòng Club có giường cỡ king - Không được hút thuốc - Không hoàn tiền - Bao bữa sáng - WiFi miễn phí", Img = "detail-room.jpg", KhachSan_ID = 4 , GiaTien = 500000 }

                );

        }
    }
}