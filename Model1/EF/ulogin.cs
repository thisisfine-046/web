namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ulogin")]
    public partial class ulogin
    {
        [Key]
        public int uid { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string pass { get; set; }

        public bool? Admin { get; set; }
    }
}
