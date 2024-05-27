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
        public int order_id { get; set; }

        [Required]
        [StringLength(50)]
        public string customer_username { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? Status { get; set; }
    }
}
