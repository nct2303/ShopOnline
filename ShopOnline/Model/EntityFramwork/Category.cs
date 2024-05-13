namespace Model.EntityFramwork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [Key]
        [StringLength(10)]
        public string cate_id { get; set; }

        [Required]
        [StringLength(50)]
        public string cate_name { get; set; }
    }
}
