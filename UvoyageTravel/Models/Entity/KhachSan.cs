namespace UvoyageTravel.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachSan")]
    public partial class KhachSan
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string TenKhachSan { get; set; }

        [StringLength(250)]
        public string UnsignedName { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        public int? XepHang { get; set; }

        [StringLength(50)]
        public string SoDienThoai { get; set; }

        [StringLength(500)]
        public string Img { get; set; }

        [StringLength(250)]
        public string ThongTinLienHe { get; set; }

        public decimal? GiaTien { get; set; }

        public int? UuTien { get; set; }

        [StringLength(500)]
        public string ThongTinMoTa { get; set; }

        public string TienIch { get; set; }

        public string ChinhSach { get; set; }

        [StringLength(100)]
        public string QuanHuyen_ID { get; set; }

        [StringLength(500)]
        public string GoogleMap { get; set; }

        public virtual QuanHuyen QuanHuyen { get; set; }
    }
}
