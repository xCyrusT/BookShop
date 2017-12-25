namespace BookShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHUDE")]
    public partial class CHUDE
    {
        [Key]
        [Display(Name = "Mã chủ đề")]
        public int MaCD { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên chủ đề")]
        public string Tenchude { get; set; }
    }
}
