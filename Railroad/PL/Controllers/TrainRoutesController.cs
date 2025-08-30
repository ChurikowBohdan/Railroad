using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;

namespace Railroad.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainRoutesController : ControllerBase
    {
        private readonly ITrainRouteService _trainRouteService;

        public TrainRoutesController(ITrainRouteService trainRouteService)
        {
            _trainRouteService = trainRouteService;
        }

        // GET: api/trainRoutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainRouteReadDTO>>> GetAllTrainRoutes()
        {
            var trainRoutes = await _trainRouteService.GetAllAsync();
            if (trainRoutes == null)
            {
                return NotFound();
            }

            return Ok(trainRoutes);
        }

        // GET: api/trainRoutes/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TrainRouteReadDTO>>> GetTrainRouteById(int id)
        {
            var trainRoute = await _trainRouteService.GetByIdAsync(id);
            if (trainRoute == null)
            {
                return NotFound();
            }

            return Ok(trainRoute);
        }

        // PUT: api/trainRoutes
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TrainRouteWriteDTO value)
        {
            await _trainRouteService.AddAsync(value);
            return Ok();
        }

        // PUT: api/trainRoutes/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int Id, [FromBody] TrainRouteWriteDTO value)
        {
            await _trainRouteService.UpdateAsync(Id, value);
            var updatedTrainRoute = await _trainRouteService.GetByIdAsync(Id);
            return Ok(updatedTrainRoute);
        }

        // DELETE: api/trainRoutes/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _trainRouteService.DeleteAsync(id);
            return Ok();
        }
    }
}
