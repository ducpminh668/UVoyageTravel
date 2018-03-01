namespace UvoyageTravel.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInRole")]
    public partial class UserInRole
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(250)]
        public string Username { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Role { get; set; }
    }
}
