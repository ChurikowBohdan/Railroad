using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.DAL.Entities;

namespace Railroad.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteFiltersController : ControllerBase
    {
        private readonly IRouteFilterService _routeFilterService;

        public RouteFiltersController(IRouteFilterService routeFilterService)
        {
            _routeFilterService = routeFilterService;
        }

        [HttpGet("departureCity/{dcName}/arrivalCity/{acName}")]
        public async Task<ActionResult<IEnumerable<FilteredRouteReadDTO>>> GetFilteredRoute(string dcName, string acName, [FromQuery] RouteFilterDTO filterDTO)
        {
            var routes = await _routeFilterService.FilterSearch(dcName, dcName, filterDTO);
            if (routes == null)
            {
                return NotFound();
            }
            return Ok(routes);
        }
    }


}
