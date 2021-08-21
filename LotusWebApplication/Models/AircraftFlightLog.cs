using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LotusWebApplication.Models
{
    [Table("tblAircraftFlightLog")]
    public class AircraftFlightLog
    {
        [Key]
        public int AFL_Code { get; set; }
        [Display(Name = "Fleet", AutoGenerateFilter = false)]
        public short AFL_FLT_Code { get; set; }
        [Display(Name = "Date", AutoGenerateFilter = false), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime AFL_Date { get; set; }
        [Display(Name = "Departure Airport", AutoGenerateFilter = false)]
        public int AFL_APT_TakeOff_Code { get; set; }
        [Display(Name = "Block-Off Time", AutoGenerateFilter = false), DataType(DataType.Time)]
        public TimeSpan AFL_BlockOffTime { get; set; }
        [Display(Name = "Take-Off Time", AutoGenerateFilter = false), DataType(DataType.Time)]
        public TimeSpan AFL_TakeOffTime { get; set; }
        [Display(Name = "Destination Airport", AutoGenerateFilter = false)]
        public int AFL_APT_Landing_Code { get; set; }
        [Display(Name = "Landing Time", AutoGenerateFilter = false), DataType(DataType.Time)]
        public TimeSpan AFL_LandingTime { get; set; }
        [Display(Name = "Block-On Time", AutoGenerateFilter = false), DataType(DataType.Time)]
        public TimeSpan AFL_BlockOnTime { get; set; }
        [Display(Name = "ATL Number", AutoGenerateFilter = false)]
        public string AFL_ATLNumber { get; set; }
        [Display(Name = "TOGA Situation", AutoGenerateFilter = false)]
        public bool AFL_IsToga { get; set; }
        [Display(Name = "Leg Number", AutoGenerateFilter = false)]
        public byte AFL_LegNumber { get; set; }
        [Display(Name = "ATL Scan", AutoGenerateFilter = false)]
        public string AFL_FileAddress { get; set; }
        [ForeignKey("AFL_FLT_Code"), Display(Name = "Fleet", AutoGenerateFilter = false)]
        public virtual Fleet Fleet { get; set; }
        [ForeignKey("AFL_APT_TakeOff_Code"), Display(Name = "Departure Airport", AutoGenerateFilter = false)]
        public virtual Airport DeptAirport { get; set; }
        [ForeignKey("AFL_APT_Landing_Code"), Display(Name = "Destination Airport", AutoGenerateFilter = false)]
        public virtual Airport DestAirport { get; set; }

    }
}
