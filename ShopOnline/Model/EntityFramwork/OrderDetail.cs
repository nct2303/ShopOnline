namespace Model.EntityFramwork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string order_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string product_id { get; set; }

        [StringLength(20)]
        public string orderdetail_quanlity { get; set; }

        [StringLength(20)]
        public string orderdetail_price { get; set; }
    }
}
