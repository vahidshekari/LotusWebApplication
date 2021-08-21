using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LotusWebApplication.Models
{
    [Table("tblCountry", Schema = "base")]
    public class Country
    {
        [Key]
        public int CNT_Code { get; set; }
        [Display(Name = "Name (en)", AutoGenerateFilter = false)]
        public string CNT_Name { get; set; }
        [Display(Name = "Name (fa)", AutoGenerateFilter = false)]
        public string CNT_Name_Fa { get; set; }
    }
}
