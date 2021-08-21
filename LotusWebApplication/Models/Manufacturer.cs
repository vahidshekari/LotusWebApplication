using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LotusWebApplication.Models
{
    [Table("tblManufacturer", Schema = "base")]
    public class Manufacturer
    {
        [Key]
        public short MAN_Code { get; set; }
        [Display(Name = "Manufacturer", AutoGenerateFilter = false)]
        public string MAN_Desc { get; set; }
        [Display(Name = "National Authority", AutoGenerateFilter = false)]
        public short MAN_NAA_Code { get; set; }
        [ForeignKey("MAN_NAA_Code")]
        public NationalAviationAuthority NationalAviationAuthority { get; set; }
    }
}
