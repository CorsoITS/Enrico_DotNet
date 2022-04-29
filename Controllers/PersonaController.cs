using Microsoft.AspNetCore.Mvc;
using Enrico_DotNet.Service;
using Enrico_DotNet.Models;

namespace Enrico_DotNet.Controllers;

[ApiController]
[Route("persona")]
public class PersonController : ControllerBase
{

    private PersonService personService = new PersonService();

    [HttpGet]
    public IEnumerable<Person> GetPeople()
    {
        return personService.GetPeople();
    }

    [HttpGet("{id}")]
    public Person GetPerson(int id)
    {
        return personService.GetPerson(id);
    }

    [HttpPost]
    public IActionResult Create(Person person)
    {
        var created = personService.Create(person);
        if (created)
        {
            return Ok();

        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public IActionResult Update(Person person)
    {
        var updated = personService.Update(person);
        if (updated)
        {
            return Ok();

        }
        else
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = personService.Delete(id);
        if (deleted)
        {
            return Ok();

        }
        else
        {
            return BadRequest();
        }
    }
}