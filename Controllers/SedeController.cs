using Microsoft.AspNetCore.Mvc;
using Enrico_DotNet.Service;
using Enrico_DotNet.Models;

namespace Enrico_DotNet.Controllers;

[ApiController]
[Route("sede")]
public class SedeController : ControllerBase
{
    private SedeService sedeService = new SedeService();

    [HttpGet]
    public IEnumerable<Sede> GetSede()
    {
        return sedeService.GetSede();
    }

    [HttpGet("{id}")]
    public Sede GetSede(int id)
    {
        return sedeService.GetSede(id);
    }

    [HttpPost]
    public IActionResult Create(Sede sede)
    {
        var created = sedeService.Create(sede);
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
    public IActionResult Update(Sede sede)
    {
        var updated = sedeService.Update(sede);
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
        var deleted = sedeService.Delete(id);
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