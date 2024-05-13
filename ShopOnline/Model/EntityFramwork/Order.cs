namespace Model.EntityFramwork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string order_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string customer_id { get; set; }

        public DateTime? order_date { get; set; }

        [StringLength(30)]
        public string order_total { get; set; }
    }
}
