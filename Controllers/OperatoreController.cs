using Microsoft.AspNetCore.Mvc;
using Enrico_DotNet.Service;
using Enrico_DotNet.Models;

namespace Enrico_DotNet.Controllers;

[ApiController]
[Route("operatore")]
public class OperatoreController : ControllerBase
{

    private OperatoreService operatoreService = new OperatoreService();

    [HttpGet]
    public IEnumerable<Operatore> GetOperatore()
    {
        return operatoreService.GetOperatore();
    }

    [HttpGet("{id}")]
    public Operatore GetOperatore(int id)
    {
        return operatoreService.GetOperatore(id);
    }

    [HttpPost]
    public IActionResult Create(Operatore operatore)
    {
        var created = operatoreService.Create(operatore);
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
    public IActionResult Update(Operatore operatore)
    {
        var updated = operatoreService.Update(operatore);
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
        var deleted = operatoreService.Delete(id);
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