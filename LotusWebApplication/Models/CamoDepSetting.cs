using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LotusWebApplication.Models
{
	[Table("tblCamoDepSetting")]
	public class CamoDepSetting
    {
		[Key]
		public int CDS_Code { get; set; }
		[Required,Display(Name = "Airline Name", AutoGenerateFilter = false)]
		public string CDS_AirlineName { get; set; }
		[Display(Name = "Address", AutoGenerateFilter = false)]
		public string CDS_Address { get; set; }
		[Display(Name = "National Authority Code", AutoGenerateFilter = false)]
		public string CDS_NAACode { get; set; }
		[Display(Name = "Last Audit Date", AutoGenerateFilter = false), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime CDS_LastAuditDate { get; set; }
		[Display(Name = "Next Audit Date", AutoGenerateFilter = false), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime CDS_NextAuditDate { get; set; }
		[Display(Name = "Telephone Number", AutoGenerateFilter = false), DataType(DataType.PhoneNumber)]
		public string CDS_TelephoneNo { get; set; }
		[Display(Name = "Email Address", AutoGenerateFilter = false), DataType(DataType.EmailAddress)]
		public string CDS_EmailAddress { get; set; }
	}
}
