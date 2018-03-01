namespace UvoyageTravel.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuanHuyen")]
    public partial class QuanHuyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuanHuyen()
        {
            KhachSans = new HashSet<KhachSan>();
        }

        [StringLength(100)]
        public string ID { get; set; }

        [StringLength(250)]
        public string TenQuanHuyen { get; set; }

        [StringLength(100)]
        public string ThanhPho_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachSan> KhachSans { get; set; }

        public virtual ThanhPho ThanhPho { get; set; }
    }
}
