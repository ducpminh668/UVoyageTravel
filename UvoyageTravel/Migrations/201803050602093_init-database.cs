namespace UvoyageTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaiViet",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenBaiViet = c.String(nullable: false, maxLength: 500),
                        TenBaiVietUnsigned = c.String(maxLength: 500, unicode: false),
                        NgayDang = c.DateTime(),
                        NoiDung = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ChiTietDatPhong",
                c => new
                    {
                        PhieuDat_ID = c.Guid(nullable: false),
                        Phong_ID = c.Int(nullable: false),
                        TinhTrangXuLy = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => new { t.PhieuDat_ID, t.Phong_ID })
                .ForeignKey("dbo.DatPhong", t => t.PhieuDat_ID, cascadeDelete: true)
                .ForeignKey("dbo.PhongKhachSan", t => t.Phong_ID, cascadeDelete: true)
                .Index(t => t.PhieuDat_ID)
                .Index(t => t.Phong_ID);
            
            CreateTable(
                "dbo.DatPhong",
                c => new
                    {
                        IDPhieuDat = c.Guid(nullable: false),
                        Username = c.String(maxLength: 100, unicode: false),
                        NgayDat = c.DateTime(),
                        TinhTrangThanhToan = c.Boolean(),
                        HoTen = c.String(maxLength: 250),
                        SoDienThoai = c.String(maxLength: 20, unicode: false),
                        Mail = c.String(maxLength: 200, unicode: false),
                        YeuCauKhac = c.String(maxLength: 500),
                        TinhTrangXuLy = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.IDPhieuDat);
            
            CreateTable(
                "dbo.PhongKhachSan",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenPhong = c.String(maxLength: 500),
                        DienTich = c.Double(),
                        ToiDa = c.Byte(),
                        DichVuHuyPhong = c.Boolean(),
                        GiaTien = c.Decimal(precision: 18, scale: 2),
                        GomBuaAn = c.Boolean(),
                        MoTa = c.String(maxLength: 500),
                        KhachSan_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Footer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KhachSan",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenKhachSan = c.String(maxLength: 250),
                        UnsignedName = c.String(maxLength: 250, unicode: false),
                        DiaChi = c.String(maxLength: 250),
                        XepHang = c.Int(),
                        SoDienThoai = c.String(maxLength: 50, unicode: false),
                        ThongTinLienHe = c.String(maxLength: 250),
                        GiaTien = c.Decimal(precision: 18, scale: 0),
                        UuTien = c.Int(),
                        ThongTinMoTa = c.String(maxLength: 500),
                        TienIch = c.String(),
                        ChinhSach = c.String(),
                        QuanHuyen_ID = c.String(maxLength: 100, unicode: false),
                        GoogleMap = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuanHuyen", t => t.QuanHuyen_ID)
                .Index(t => t.QuanHuyen_ID);
            
            CreateTable(
                "dbo.QuanHuyen",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 100, unicode: false),
                        TenQuanHuyen = c.String(maxLength: 250),
                        ThanhPho_ID = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ThanhPho", t => t.ThanhPho_ID)
                .Index(t => t.ThanhPho_ID);
            
            CreateTable(
                "dbo.ThanhPho",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 100, unicode: false),
                        TenThanhPho = c.String(maxLength: 250),
                        Img = c.String(maxLength: 500),
                        Ordering = c.Int(),
                        HotStatus = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 250),
                        target = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Img = c.String(maxLength: 500, unicode: false),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserInRole",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 250, unicode: false),
                        ID_Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Username, t.ID_Role });
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 250, unicode: false),
                        Password = c.String(maxLength: 250, unicode: false),
                        HoTen = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuanHuyen", "ThanhPho_ID", "dbo.ThanhPho");
            DropForeignKey("dbo.KhachSan", "QuanHuyen_ID", "dbo.QuanHuyen");
            DropForeignKey("dbo.ChiTietDatPhong", "Phong_ID", "dbo.PhongKhachSan");
            DropForeignKey("dbo.ChiTietDatPhong", "PhieuDat_ID", "dbo.DatPhong");
            DropIndex("dbo.QuanHuyen", new[] { "ThanhPho_ID" });
            DropIndex("dbo.KhachSan", new[] { "QuanHuyen_ID" });
            DropIndex("dbo.ChiTietDatPhong", new[] { "Phong_ID" });
            DropIndex("dbo.ChiTietDatPhong", new[] { "PhieuDat_ID" });
            DropTable("dbo.User");
            DropTable("dbo.UserInRole");
            DropTable("dbo.Slides");
            DropTable("dbo.Roles");
            DropTable("dbo.Menu");
            DropTable("dbo.ThanhPho");
            DropTable("dbo.QuanHuyen");
            DropTable("dbo.KhachSan");
            DropTable("dbo.Footer");
            DropTable("dbo.PhongKhachSan");
            DropTable("dbo.DatPhong");
            DropTable("dbo.ChiTietDatPhong");
            DropTable("dbo.BaiViet");
        }
    }
}
