using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;

namespace Railroad.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
        private readonly ITrainService _trainService;

        public TrainsController(ITrainService trainService)
        {
            _trainService = trainService;
        }

        // GET: api/trains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainReadDTO>>> GetAllTrains()
        {
            var trains = await _trainService.GetAllAsync();
            if (trains == null)
            {
                return NotFound();
            }

            return Ok(trains);
        }

        // GET: api/trains/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TrainReadDTO>>> GetTrainById(int id)
        {
            var train = await _trainService.GetByIdAsync(id);
            if (train == null)
            {
                return NotFound();
            }

            return Ok(train);
        }

        // PUT: api/trains
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TrainWriteDTO value)
        {
            await _trainService.AddAsync(value);
            return Ok();
        }

        // PUT: api/trains/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TrainWriteDTO value)
        {
            await _trainService.UpdateAsync(id, value);
            var updatedTrain = await _trainService.GetByIdAsync(id);
            return Ok(updatedTrain);
        }

        // DELETE: api/trains/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _trainService.DeleteAsync(id);
            return Ok();
        }
    }
}
