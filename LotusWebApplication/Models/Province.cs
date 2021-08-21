using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LotusWebApplication.Models
{
    [Table("tblProvince", Schema = "base")]
    public class Province
    {
        [Key]
        public int PRV_Code { get; set; }
#nullable enable
        [Display(Name = "Country", AutoGenerateFilter = false)]
        public int PRV_CNT_Code { get; set; }
        [Display(Name = "Name (Fa)", AutoGenerateFilter = false), MaxLength(64)]
        public string? PRV_Title_Fa { get; set; }
        [Display(Name = "Name (En)", AutoGenerateFilter = false), MaxLength(64)]
        public string? PRV_Title_En { get; set; }
#nullable disable
        [ForeignKey("PRV_CNT_Code")]
        public virtual Country Country { get; set; }

    }
}
