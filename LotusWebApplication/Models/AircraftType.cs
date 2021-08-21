using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LotusWebApplication.Models
{
    [Table("tblAircraftType", Schema = "base")]
    public class AircraftType
    {
        [Key]
        public short ACT_Code { get; set; }
        [Display(Name = "Market Name", AutoGenerateFilter = false)]
        public string ACT_MarketName { get; set; }
        [Display(Name = "OfficialName", AutoGenerateFilter = false)]
        public string ACT_OfficialName { get; set; }
        [Display(Name = "Number of Engines", AutoGenerateFilter = false)]
        public byte ACT_NumberofEngines { get; set; }
        [Display(Name = "Manufacturer", AutoGenerateFilter = false)]
        public short ACT_MAN_Code { get; set; }
        [Display(Name = "APU", AutoGenerateFilter = false)]
        public short ACT_APU_Code { get; set; }
        [Display(Name = "Engine", AutoGenerateFilter = false)]
        public short ACT_ENG_Code { get; set; }
        [Display(Name = "Type Certificate", AutoGenerateFilter = false)]
        public string ACT_TypeCertificate { get; set; }
        [Display(Name = "Type Certificate File", AutoGenerateFilter = false)]
        public string ACT_TCPdfFile { get; set; }
        [ForeignKey("ACT_MAN_Code"), Display(Name = "Manufacturer", AutoGenerateFilter = false)]
        public Manufacturer Manufacturer { get; set; }
        [ForeignKey("ACT_APU_Code"), Display(Name = "APU", AutoGenerateFilter = false)]
        public APU APU { get; set; }
        [ForeignKey("ACT_ENG_Code"), Display(Name = "Engines", AutoGenerateFilter = false)]
        public Engines Engines { get; set; }

    }
}
