using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LotusWebApplication.Models
{
    [Table("tblAirport", Schema = "base")]
    public class Airport
    {
        [Key]
        public int APT_Code { get; set; }
        [Required, Display(Name = "IATA Code", AutoGenerateFilter = false), MaxLength(3)]
        public string APT_IATACode { get; set; }
        [Display(Name = "ICAO Code", AutoGenerateFilter = false), MaxLength(4)]
#nullable enable
        public string? APT_ICAOCode { get; set; }
        [Display(Name = "Name (En)", AutoGenerateFilter = false)]
        public string? APT_NameEn { get; set; }
        [Display(Name = "Name (Fa)", AutoGenerateFilter = false)]
        public string? APT_NameFa { get; set; }
        [Display(Name = "City", AutoGenerateFilter = false)]
        public int? APT_CTY_Code { get; set; }      
        [Display(Name = "Alternate Airport 1", AutoGenerateFilter = false)]
        public int? APT_ALT_APT_Code_1 { get; set; }
        [Display(Name = "Alternate Airport 2", AutoGenerateFilter = false)]
        public int? APT_ALT_APT_Code_2 { get; set; }
        [Display(Name = "Alternate Airport 3", AutoGenerateFilter = false)]
        public int? APT_ALT_APT_Code_3 { get; set; }          
#nullable disable
        [ForeignKey("APT_CTY_Code")]
        public City City { get; set; }
        [ForeignKey("APT_ALT_APT_Code_1"), NotMapped]
        public virtual Airport Alternate1 { get; set; }
        [ForeignKey("APT_ALT_APT_Code_2"), NotMapped]
        public virtual Airport Alternate2 { get; set; }
        [ForeignKey("APT_ALT_APT_Code_3"), NotMapped]
        public virtual Airport Alternate3 { get; set; }

        public string IATAICAOCode
        {
            get
            {
                return string.Format("{0} - {1}", APT_IATACode, APT_ICAOCode);
            }
        }
    }
}
