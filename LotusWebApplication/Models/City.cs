using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LotusWebApplication.Models
{
    [Table("tblCity", Schema = "base")]
    public class City
    {
        [Key]
        public int CTY_Code { get; set; }
#nullable enable
        [Display(Name = "Name (Fa)", AutoGenerateFilter = false), MaxLength(64)]
        public string? CTY_Name_Fa { get; set; }
        [Display(Name = "Name (En)", AutoGenerateFilter = false), MaxLength(64)]
        public string? CTY_Name_En { get; set; }
        [Display(Name = "Province", AutoGenerateFilter = false)]
        public int? CTY_PRV_Code { get; set; }
#nullable disable
        [ForeignKey("CTY_PRV_Code")]
        public virtual Province Province { get; set; }
    }
}
