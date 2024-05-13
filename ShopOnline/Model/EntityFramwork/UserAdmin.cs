namespace Model.EntityFramwork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAdmin")]
    public partial class UserAdmin
    {
        [StringLength(50)]
        public string id { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [StringLength(50)]
        public string fullname { get; set; }

        [StringLength(50)]
        public string email { get; set; }
    }
}
