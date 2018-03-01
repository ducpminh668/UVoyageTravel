namespace UvoyageTravel.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        [StringLength(250)]
        public string Username { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(250)]
        public string HoTen { get; set; }
    }
}
