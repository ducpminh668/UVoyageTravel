namespace UvoyageTravel.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UvoyageDBContext : DbContext
    {
        public UvoyageDBContext()
            : base("name=UvoyageDBContext")
        {
        }

        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<ChiTietDatPhong> ChiTietDatPhongs { get; set; }
        public virtual DbSet<DatPhong> DatPhongs { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<KhachSan> KhachSans { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<PhongKhachSan> PhongKhachSans { get; set; }
        public virtual DbSet<QuanHuyen> QuanHuyens { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<ThanhPho> ThanhPhoes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInRole> UserInRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiViet>()
                .Property(e => e.TenBaiVietUnsigned)
                .IsUnicode(false);

            modelBuilder.Entity<DatPhong>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<DatPhong>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<DatPhong>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<DatPhong>()
                .HasMany(e => e.ChiTietDatPhongs)
                .WithRequired(e => e.DatPhong)
                .HasForeignKey(e => e.PhieuDat_ID);

            modelBuilder.Entity<KhachSan>()
                .Property(e => e.UnsignedName)
                .IsUnicode(false);

            modelBuilder.Entity<KhachSan>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<KhachSan>()
                .Property(e => e.GiaTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KhachSan>()
                .Property(e => e.QuanHuyen_ID)
                .IsUnicode(false);

            modelBuilder.Entity<KhachSan>()
                .Property(e => e.GoogleMap)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.target)
                .IsUnicode(false);

            modelBuilder.Entity<PhongKhachSan>()
                .HasMany(e => e.ChiTietDatPhongs)
                .WithRequired(e => e.PhongKhachSan)
                .HasForeignKey(e => e.Phong_ID);

            modelBuilder.Entity<QuanHuyen>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<QuanHuyen>()
                .Property(e => e.ThanhPho_ID)
                .IsUnicode(false);

            modelBuilder.Entity<QuanHuyen>()
                .HasMany(e => e.KhachSans)
                .WithOptional(e => e.QuanHuyen)
                .HasForeignKey(e => e.QuanHuyen_ID);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Img)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhPho>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhPho>()
                .HasMany(e => e.QuanHuyens)
                .WithOptional(e => e.ThanhPho)
                .HasForeignKey(e => e.ThanhPho_ID);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserInRole>()
                .Property(e => e.Username)
                .IsUnicode(false);
        }
    }
}
