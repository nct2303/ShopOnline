namespace Model.EntityFramwork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [Key]
        [StringLength(20)]
        public string customer_id { get; set; }

        [StringLength(50)]
        public string customer_name { get; set; }

        [StringLength(50)]
        public string customer_email { get; set; }

        [StringLength(50)]
        public string customer_address { get; set; }

        [StringLength(5)]
        public string customer_gender { get; set; }

        [StringLength(20)]
        public string customer_phone { get; set; }
    }
}
