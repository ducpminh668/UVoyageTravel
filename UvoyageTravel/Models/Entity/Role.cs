namespace UvoyageTravel.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Role
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string RoleName { get; set; }
    }
}
