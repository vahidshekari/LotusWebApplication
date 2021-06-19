using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LotusWebApplication.Models
{
    [Table("tblAPU")]
    public class APU
    {
        [Key]
        public short APU_Code { get; set; }
        [Display(Name = "Description", AutoGenerateFilter = false)]
        public string APU_Description { get; set; }
        [Display(Name = "Manufacturer", AutoGenerateFilter = false)]
        public short APU_MAN_Code { get; set; }
        [ForeignKey("APU_MAN_Code"), Display(Name = "Manufacturer", AutoGenerateFilter = false)]
        public Manufacturer Manufacturer { get; set; }

    }
}
