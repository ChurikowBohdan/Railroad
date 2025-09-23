using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.BLL.Services;

namespace Railroad.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonReadDTO>>> GetAllPersons()
        {
            var persons = await _personService.GetAllAsync();
            if (persons == null)
            {
                return NotFound();
            }

            return Ok(persons);
        }

        // GET: api/persons/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PersonReadDTO>>> GetPersonById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/persons
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] PersonWriteDTO value)
        {
            if (ValidationPersonModel(value))
            {
                return BadRequest(value);
            }

            await _personService.AddAsync(value);
            return Ok();
        }

        // PUT: api/persons/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int Id, [FromBody] PersonWriteDTO value)
        {
            if (ValidationPersonModel(value))
            {
                return BadRequest(value);
            }

            await _personService.UpdateAsync(Id, value);
            var updatedPerson = await _personService.GetByIdAsync(Id);
            return Ok(updatedPerson);
        }

        // DELETE: api/persons/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _personService.DeleteAsync(id);
            return Ok();
        }

        private static bool ValidationPersonModel(PersonWriteDTO model)
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
