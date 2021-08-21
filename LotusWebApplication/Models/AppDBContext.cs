
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotusWebApplication.Models;

namespace LotusWebApplication.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<LotusWebApplication.Models.CamoDepSetting> CamoDepSetting { get; set; }
        public DbSet<LotusWebApplication.Models.NationalAviationAuthority> NationalAviationAuthority { get; set; }
        public DbSet<LotusWebApplication.Models.Manufacturer> Manufacturer { get; set; }
        public DbSet<LotusWebApplication.Models.APU> APU { get; set; }
        public DbSet<LotusWebApplication.Models.Engines> Engines { get; set; }
        public DbSet<LotusWebApplication.Models.AircraftType> AircraftType { get; set; }
        public DbSet<LotusWebApplication.Models.Fleet> Fleet { get; set; }
        public DbSet<LotusWebApplication.Models.Country> Country { get; set; }
        public DbSet<LotusWebApplication.Models.Province> Province { get; set; }
        public DbSet<LotusWebApplication.Models.City> City { get; set; }
        public DbSet<LotusWebApplication.Models.Airport> Airport { get; set; }
        public DbSet<LotusWebApplication.Models.AircraftFlightLog> AircraftFlightLog { get; set; }
    }
}
