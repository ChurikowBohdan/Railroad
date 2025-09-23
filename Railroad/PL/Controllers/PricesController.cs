using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.BLL.Services;

namespace Railroad.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly IPriceService _priceService;

        public PricesController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        // GET: api/prices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceReadDTO>>> GetAllPrices()
        {
            var prices = await _priceService.GetAllAsync();
            if (prices == null)
            {
                return NotFound();
            }

            return Ok(prices);
        }

        // GET: api/prices/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PriceReadDTO>>> GetPriceById(int id)
        {
            var price = await _priceService.GetByIdAsync(id);
            if (price == null)
            {
                return NotFound();
            }

            return Ok(price);
        }

        // PUT: api/prices
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] PriceWriteDTO value)
        {
            await _priceService.AddAsync(value);
            return Ok();
        }

        // PUT: api/prices/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PriceWriteDTO value)
        {
            await _priceService.UpdateAsync(id, value);
            var updatedPrice = await _priceService.GetByIdAsync(id);
            return Ok(updatedPrice);
        }

        // DELETE: api/prices/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _priceService.DeleteAsync(id);
            return Ok();
        }
    }
}
