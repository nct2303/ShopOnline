namespace Model.EntityFramwork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_
    {
        [StringLength(20)]
        public string product_id { get; set; }

        [Required]
        [StringLength(50)]
        public string product_name { get; set; }

        [Required]
        [MaxLength(20)]
        public byte[] cate_id { get; set; }

        [StringLength(20)]
        public string product_size { get; set; }

        [StringLength(10)]
        public string product_color { get; set; }

        [StringLength(50)]
        public string product_description { get; set; }
    }
}
