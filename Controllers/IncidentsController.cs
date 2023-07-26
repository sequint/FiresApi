using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FiresApi.Models;
using FiresApi.Data;
using FiresApi.DTOs;

namespace FiresApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IncindentContext _context;

        public IncidentsController(IncindentContext context)
        {
            _context = context;
        }

        // GET: api/Incidents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentDTO>>> GetIncident()
        {
            if (_context.Incident == null)
            {
                return NotFound();
            }

            return await _context.Incident
                .Select(incident => IncindentToDTO(incident))
                .ToListAsync();
        }

        // GET: api/Incidents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentDTO>> GetIncident(string id)
        {
            if (_context.Incident == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }

            return IncindentToDTO(incident);
        }

        // PUT: api/Incidents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident(string id, IncidentDTO incidentDTO)
        {
            if (id != incidentDTO.Id)
            {
                return BadRequest();
            }

            if (id != incidentDTO.Id)
            {
                return BadRequest();
            }

            var incident = await _context.Incident.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }

            incident.Name = incidentDTO.Name;
            incident.Final = incidentDTO.Final;
            incident.Updated = incidentDTO.Updated;
            incident.Started = incidentDTO.Started;
            incident.AdminUnit = incidentDTO.AdminUnit;
            incident.County = incidentDTO.County;
            incident.Location = incidentDTO.Location;
            incident.AcresBurned = incidentDTO.AcresBurned;
            incident.PercentContained = incidentDTO.PercentContained;
            incident.AgencyNames = incidentDTO.AgencyNames;
            incident.Longitude = incidentDTO.Longitude;
            incident.Latitude = incidentDTO.Latitude;
            incident.Type = incidentDTO.Type;
            incident.UniqueId = incidentDTO.UniqueId;
            incident.Url = incidentDTO.Url;
            incident.StartedDateOnly = incidentDTO.StartedDateOnly;
            incident.IsActive = incidentDTO.IsActive;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!IncidentExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Incidents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IncidentDTO>> PostIncident(IncidentDTO incidentDTO)
        {
            if (_context.Incident == null)
            {
                return Problem("Entity set 'IncindentContext.Incident'  is null.");
            }

            var incindent = new Incident
            {
                Id = incidentDTO.Id,
                Name = incidentDTO.Name,
                Final = incidentDTO.Final,
                Updated = incidentDTO.Updated,
                Started = incidentDTO.Started,
                AdminUnit = incidentDTO.AdminUnit,
                County = incidentDTO.County,
                Location = incidentDTO.Location,
                AcresBurned = incidentDTO.AcresBurned,
                PercentContained = incidentDTO.PercentContained,
                AgencyNames = incidentDTO.AgencyNames,
                Longitude = incidentDTO.Longitude,
                Latitude = incidentDTO.Latitude,
                Type = incidentDTO.Type,
                UniqueId = incidentDTO.UniqueId,
                Url = incidentDTO.Url,
                StartedDateOnly = incidentDTO.StartedDateOnly,
                IsActive = incidentDTO.IsActive
            };

            _context.Incident.Add(incindent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IncidentExists(incidentDTO.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIncident", new { id = incidentDTO.Id }, incidentDTO);
        }

        // DELETE: api/Incidents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident(string id)
        {
            if (_context.Incident == null)
            {
                return NotFound();
            }
            var incident = await _context.Incident.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }

            _context.Incident.Remove(incident);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncidentExists(string id)
        {
            return (_context.Incident?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private static IncidentDTO IncindentToDTO(Incident incident) =>
           new IncidentDTO
           {
               Id = incident.Id,
               Name = incident.Name,
               Final = incident.Final,
               Updated = incident.Updated,
               Started = incident.Started,
               AdminUnit = incident.AdminUnit,
               County = incident.County,
               Location = incident.Location,
               AcresBurned = incident.AcresBurned,
               PercentContained = incident.PercentContained,
               AgencyNames = incident.AgencyNames,
               Longitude = incident.Longitude,
               Latitude = incident.Latitude,
               Type = incident.Type,
               UniqueId = incident.UniqueId,
               Url = incident.Url,
               StartedDateOnly = incident.StartedDateOnly,
               IsActive = incident.IsActive
           };
    }
}
