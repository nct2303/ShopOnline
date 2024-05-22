namespace Model.EntityFramwork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Statistic")]
    public partial class Statistic
    {
        [StringLength(10)]
        public string Id { get; set; }

        public int? AddCount { get; set; }

        public int? DeleteCount { get; set; }

        public DateTime? Time { get; set; }
    }
}
