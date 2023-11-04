namespace WCFEmployee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int id { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        public decimal? salary { get; set; }
    }
}
