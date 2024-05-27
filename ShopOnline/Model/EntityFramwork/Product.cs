namespace Model.EntityFramwork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int product_id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int? Quanlity { get; set; }

        public decimal? Price { get; set; }

        [StringLength(50)]
        public string cate_name { get; set; }

        public string Image { get; set; }
    }
}
