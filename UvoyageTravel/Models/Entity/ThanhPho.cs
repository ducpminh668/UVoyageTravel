namespace UvoyageTravel.Models.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ThanhPho")]
    public partial class ThanhPho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThanhPho()
        {
            QuanHuyens = new HashSet<QuanHuyen>();
        }

        [StringLength(100)]
        public string ID { get; set; }

        [StringLength(250)]
        public string TenThanhPho { get; set; }

        [StringLength(500)]
        public string Img { get; set; }

        public int? Ordering { get; set; }

        public bool? HotStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuanHuyen> QuanHuyens { get; set; }
    }
}