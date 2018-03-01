namespace UvoyageTravel.Models.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("BaiViet")]
    public partial class BaiViet
    {
        public int ID { get; set; }

        [StringLength(500)]
        [Required]
        public string TenBaiViet { get; set; }

        [StringLength(500)]
        public string TenBaiVietUnsigned { get; set; }

        public DateTime? NgayDang { get; set; }

        public string NoiDung { get; set; }
    }
}