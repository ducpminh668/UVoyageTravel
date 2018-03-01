namespace UvoyageTravel.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiViet")]
    public partial class BaiViet
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string TenBaiViet { get; set; }

        [StringLength(500)]
        public string TenBaiVietUnsigned { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDang { get; set; }

        public string NoiDung { get; set; }
    }
}
