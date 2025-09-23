using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.BLL.Services;

namespace Railroad.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // GET: api/admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminReadDTO>>> GetAllAdmins()
        {
            var admins = await _adminService.GetAllAsync();
            if (admins == null)
            {
                return NotFound();
            }

            return Ok(admins);
        }

        // GET: api/admins/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AdminReadDTO>>> GetAdminById(int id)
        {
            var admin = await _adminService.GetByIdAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        // PUT: api/admins
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AdminWriteDTO value)
        {
            if (ValidationAdminModel(value))
            {
                return BadRequest(value);
            }

            await _adminService.AddAsync(value);
            return Ok();
        }

        // PUT: api/admins/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int Id, [FromBody] AdminWriteDTO value)
        {
            if (ValidationAdminModel(value))
            {
                return BadRequest(value);
            }

            await _adminService.UpdateAsync(Id, value);
            var updatedAdmin = await _adminService.GetByIdAsync(Id);
            return Ok(updatedAdmin);
        }

        // DELETE: api/admins/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _adminService.DeleteAsync(id);
            return Ok();
        }

        private static bool ValidationAdminModel(AdminWriteDTO model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Surname))
            {
                return true;
            }

            if (model.BirthDate.Year <= 1899 || model.BirthDate >= DateTime.UtcNow)
            {
                return true;
            }

            return false;
        }
    }
}
