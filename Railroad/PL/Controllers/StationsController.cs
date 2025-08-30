using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.DAL.Entities;

namespace Railroad.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly IStationService _stationService;

        public StationsController(IStationService stationService)
        {
            _stationService = stationService;
        }

        // GET: api/stations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationReadDTO>>> GetAllStations()
        {
            var stations = await _stationService.GetAllAsync();
            if (stations == null)
            {
                return NotFound();
            }

            return Ok(stations);
        }

        // GET: api/stations/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<StationReadDTO>>> GetStationById(int id)
        {
            var station = await _stationService.GetByIdAsync(id);
            if (station == null)
            {
                return NotFound();
            }

            return Ok(station);
        }

        // PUT: api/stations
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] StationWriteDTO value)
        {
            await _stationService.AddAsync(value);
            return Ok();
        }

        // PUT: api/stations/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int Id, [FromBody] StationWriteDTO value)
        {
            await _stationService.UpdateAsync(Id, value);
            var updatedStation = await _stationService.GetByIdAsync(Id);
            return Ok(updatedStation);
        }

        // DELETE: api/stations/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _stationService.DeleteAsync(id);
            return Ok();
        }
    }
}
