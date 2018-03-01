namespace UvoyageTravel.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongKhachSan")]
    public partial class PhongKhachSan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongKhachSan()
        {
            ChiTietDatPhongs = new HashSet<ChiTietDatPhong>();
        }

        public int ID { get; set; }

        [StringLength(500)]
        public string TenPhong { get; set; }

        public double? DienTich { get; set; }

        public byte? ToiDa { get; set; }

        public bool? DichVuHuyPhong { get; set; }

        public bool? GomBuaAn { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        public int? KhachSan_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatPhong> ChiTietDatPhongs { get; set; }
    }
}
