using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LotusWebApplication.Models
{
    [Table("tblEngines", Schema = "base")]
    public class Engines
    {
        [Key]
        public short ENG_Code { get; set; }
        [Display(Name = "Description", AutoGenerateFilter = false)]
        public string ENG_Description { get; set; }
        [Display(Name = "Thrust Rating", AutoGenerateFilter = false)]
        public int ENG_ThrustRating { get; set; }
        [Display(Name = "Manufacturer", AutoGenerateFilter = false)]
        public short ENG_MAN_Code { get; set; }
        [Display(Name = "Type Certificate", AutoGenerateFilter = false)]
        public string ENG_TypeCertificate { get; set; }
        [Display(Name = "Attachment", AutoGenerateFilter = false)]
        public string Eng_TCPDFFile { get; set; }
        [ForeignKey("ENG_MAN_Code"), Display(Name = "Manufacturer", AutoGenerateFilter = false)]
        public Manufacturer Manufacturer { get; set; }

    }
}
