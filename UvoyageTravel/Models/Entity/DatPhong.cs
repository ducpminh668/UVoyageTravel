namespace UvoyageTravel.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatPhong")]
    public partial class DatPhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatPhong()
        {
            ChiTietDatPhongs = new HashSet<ChiTietDatPhong>();
        }

        [Key]
        public Guid IDPhieuDat { get; set; }

        [StringLength(100)]
        public string Username { get; set; }

        public DateTime? NgayDat { get; set; }

        public bool? TinhTrangThanhToan { get; set; }

        [StringLength(250)]
        public string HoTen { get; set; }

        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [StringLength(200)]
        public string Mail { get; set; }

        [StringLength(500)]
        public string YeuCauKhac { get; set; }

        [StringLength(250)]
        public string TinhTrangXuLy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatPhong> ChiTietDatPhongs { get; set; }
    }
}
