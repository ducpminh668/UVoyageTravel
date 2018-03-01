namespace UvoyageTravel.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDatPhong")]
    public partial class ChiTietDatPhong
    {
        [Key]
        [Column(Order = 0)]
        public Guid PhieuDat_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Phong_ID { get; set; }

        [StringLength(250)]
        public string TinhTrangXuLy { get; set; }

        public virtual DatPhong DatPhong { get; set; }

        public virtual PhongKhachSan PhongKhachSan { get; set; }
    }
}
