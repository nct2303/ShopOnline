namespace Model.EntityFramwork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerAccount")]
    public partial class CustomerAccount
    {
        [Key]
        public int customer_id { get; set; }

        [StringLength(50)]
        public string customer_username { get; set; }

        [StringLength(50)]
        public string customer_password { get; set; }
    }
}
