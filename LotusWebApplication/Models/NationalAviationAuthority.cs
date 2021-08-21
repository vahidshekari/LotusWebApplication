using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LotusWebApplication.Models
{
    [Table("tblNationalAviationAuthority", Schema = "base")]
    public class NationalAviationAuthority
    {
        [Key]
        public short NAA_Code { get; set; }
        [Required, Display(Name = "National Authority", AutoGenerateFilter = false)]
        public string NAA_Desc { get; set; }

    }
}
