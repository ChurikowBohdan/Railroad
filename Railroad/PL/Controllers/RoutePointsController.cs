using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.DAL.Entities;

namespace Railroad.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutePointsController : ControllerBase
    {
        private readonly IRoutePointService _routePointService;

        public RoutePointsController(IRoutePointService routePointService)
        {
            _routePointService = routePointService;
        }

        // GET: api/routePoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoutePointReadDTO>>> GetAllRoutePoints()
        {
            var routePoints = await _routePointService.GetAllAsync();
            if (routePoints == null)
            {
                return NotFound();
            }

            return Ok(routePoints);
        }

        // GET: api/routePoints/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RoutePointReadDTO>>> GetRoutePointById(int id)
        {
            var routePoint = await _routePointService.GetByIdAsync(id);
            if (routePoint == null)
            {
                return NotFound();
            }

            return Ok(routePoint);
        }

        // PUT: api/routePoints
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] RoutePointWriteDTO value)
        {
            await _routePointService.AddAsync(value);
            return Ok();
        }

        // PUT: api/routePoints/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int Id, [FromBody] RoutePointWriteDTO value)
        {
            await _routePointService.UpdateAsync(Id, value);
            var updatedRoutePoint = await _routePointService.GetByIdAsync(Id);
            return Ok(updatedRoutePoint);
        }

        // DELETE: api/routePoints/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _routePointService.DeleteAsync(id);
            return Ok();
        }
    }
}
