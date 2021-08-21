using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LotusWebApplication.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace LotusWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftFlightLogsController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private string ProcessedFile(IFormFile file)
        {
            string uniquefilename = null;
            if (file != null)
            {
                if (file.Length > 10485760)
                {
                 
                    return null;
                }
                string uploadsfolder = Path.Combine(webHostEnvironment.WebRootPath, "assets/EngineTypeCertificate");
                uniquefilename = Guid.NewGuid().ToString() + "_" + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(uploadsfolder, uniquefilename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
            }
            return uniquefilename;
        }
        private readonly AppDBContext _context;
        [BindProperty]
        public static IFormFile formFile { get; set; }
        public AircraftFlightLogsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/AircraftFlightLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AircraftFlightLog>>> GetAircraftFlightLog()
        {
            return await _context.AircraftFlightLog.ToListAsync();
        }

        // GET: api/AircraftFlightLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AircraftFlightLog>> GetAircraftFlightLog(int id)
        {
            var aircraftFlightLog = await _context.AircraftFlightLog.FindAsync(id);

            if (aircraftFlightLog == null)
            {
                return NotFound();
            }

            return aircraftFlightLog;
        }

        // PUT: api/AircraftFlightLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAircraftFlightLog(int id, AircraftFlightLog aircraftFlightLog)
        {
            if (id != aircraftFlightLog.AFL_Code)
            {
                return BadRequest();
            }

            _context.Entry(aircraftFlightLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AircraftFlightLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AircraftFlightLogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AircraftFlightLog>> PostAircraftFlightLog([FromForm]IFormFile file)
        {
            AircraftFlightLog aircraftFlightLog = new AircraftFlightLog();
            bool isLastFlight = false;
            if (_context.AircraftFlightLog.Where(a => a.AFL_FLT_Code == aircraftFlightLog.AFL_FLT_Code).Count() == 0)
            {
                isLastFlight = true;
            }
            if (_context.AircraftFlightLog.Where(a => a.AFL_FLT_Code == aircraftFlightLog.AFL_FLT_Code && a.AFL_Date > aircraftFlightLog.AFL_Date).Count() == 0)
            {
                isLastFlight = true;
            }
            if (_context.AircraftFlightLog.Where(a => a.AFL_FLT_Code == aircraftFlightLog.AFL_FLT_Code && a.AFL_Date == aircraftFlightLog.AFL_Date && a.AFL_LandingTime > aircraftFlightLog.AFL_TakeOffTime).Count() == 0)
            {
                isLastFlight = true;
            }
            if (isLastFlight)
            {
                aircraftFlightLog.AFL_FileAddress = ProcessedFile(file);
                aircraftFlightLog.AFL_LegNumber = Convert.ToByte(_context.AircraftFlightLog.Where(a => a.AFL_Date == aircraftFlightLog.AFL_Date && a.AFL_FLT_Code == aircraftFlightLog.AFL_FLT_Code).Count()+1);
                _context.AircraftFlightLog.Add(aircraftFlightLog);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetAircraftFlightLog", new { id = aircraftFlightLog.AFL_Code }, aircraftFlightLog);
            }
            else
            {
                return Problem("Flight is overlapping with previous flights");
            }
        }

        // DELETE: api/AircraftFlightLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AircraftFlightLog>> DeleteAircraftFlightLog(int id)
        {
            var aircraftFlightLog = await _context.AircraftFlightLog.FindAsync(id);
            if (aircraftFlightLog == null)
            {
                return NotFound();
            }

            _context.AircraftFlightLog.Remove(aircraftFlightLog);
            await _context.SaveChangesAsync();

            return aircraftFlightLog;
        }

        private bool AircraftFlightLogExists(int id)
        {
            return _context.AircraftFlightLog.Any(e => e.AFL_Code == id);
        }
    }
}
