using Microsoft.AspNetCore.Mvc;
using webApiTutorial.Models;
using webApiTutorial.Services;

namespace webApiTutorial.Controllers;

[ApiController]
[Route("[controller]")]
public class ReactionController : ControllerBase
{
    public ReactionController()
    {
    }
    [HttpGet]
    public ActionResult<List<Reaction>> GetAll() => ReactionService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Reaction> Get(Guid id)
    {
        var reaction = ReactionService.Get(id);
        if (reaction is null)
            return NotFound();

        return reaction;
    }


    [HttpPost]
    public IActionResult Create(Reaction reaction)
    {
        ReactionService.Add(reaction);
        return CreatedAtAction(nameof(Get), new(), reaction);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Reaction reaction)
    {
        if (id != reaction.Id)
            return BadRequest();

        var existingReaction = ReactionService.Get(id);
        if (existingReaction is null)
            return NotFound();

        ReactionService.Update(reaction);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var reaction = ReactionService.Get(id);
        if (reaction is null)
            return NotFound();

        ReactionService.Delete(id);

        return NoContent();
    }

}