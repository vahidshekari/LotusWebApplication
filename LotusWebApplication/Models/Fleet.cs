using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LotusWebApplication.Models
{
    [Table("tblFleet")]
    public class Fleet
    {
        [Key]
        public short FLT_Code { get; set; }
        [Display(Name = "Aircraft Type", AutoGenerateFilter = false)]
        public short FLT_ACT_Code { get; set; }
        [Display(Name = "MSN", AutoGenerateFilter = false)]
        public string FLT_MSN { get; set; }
        [Display(Name = "Registration", AutoGenerateFilter = false)]
        public string FLT_Registration { get; set; }
        [Display(Name = "Max Take-Off Weight", AutoGenerateFilter = false)]
        public int FLT_MOTW { get; set; }
        [Display(Name = "Manufacture Date", AutoGenerateFilter = false), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FLT_ManufactureDate { get; set; }
        [Display(Name = "Total Flight Hour", AutoGenerateFilter = false)]
        public int FLT_TFH { get; set; }
        [Display(Name = "Total Flight Cycle", AutoGenerateFilter = false)]
        public int FLT_TFC { get; set; }
        [ForeignKey("FLT_ACT_Code"), Display(Name = "Aircraft Type", AutoGenerateFilter = false)]
        public AircraftType AircraftType { get; set; }


    }
}
