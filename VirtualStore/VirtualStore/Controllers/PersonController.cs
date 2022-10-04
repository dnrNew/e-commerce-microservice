using Microsoft.AspNetCore.Mvc;
using VirtualStore.Model;
using VirtualStore.Services.PersonService;

namespace VirtualStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{

    private readonly ILogger<PersonController> _logger;
    private IPersonService _personService;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var persons = _personService.GetAll();

        return Ok(persons);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(long personId)
    {
        var person = _personService.GetById(personId);

        if (person == null)
            return NotFound();

        return Ok(person);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Person person)
    {
        if (person == null)
            return BadRequest();

        var createPerson = _personService.Create(person);

        return Ok(createPerson);
    }

    [HttpPut]
    public IActionResult Update([FromBody] Person person)
    {
        if (person == null)
            return BadRequest();

        var updatePerson = _personService.Update(person);

        return Ok(updatePerson);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long personId)
    {
        _personService.Delete(personId);

        return NoContent();
    }
}
