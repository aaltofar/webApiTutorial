using Microsoft.AspNetCore.Mvc;
using webApiTutorial.Models;
using webApiTutorial.Services;

namespace webApiTutorial.Controllers;

[ApiController]
[Route("[controller]")]
public class CatController : ControllerBase
{
    public CatController()
    {
    }
    [HttpGet]
    public ActionResult<List<Cat>> GetAll() => CatService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Cat> Get(int id)
    {
        var cat = CatService.Get(id);
        if (cat is null)
            return NotFound();

        return cat;
    }


    [HttpPost]
    public IActionResult Create(Cat cat)
    {
        CatService.Add(cat);
        return CreatedAtAction(nameof(Get), new { id = cat.Id }, cat);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Cat cat)
    {
        if (id != cat.Id)
            return BadRequest();

        var existingCat = CatService.Get(id);
        if (existingCat is null)
            return NotFound();

        CatService.Update(cat);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var cat = CatService.Get(id);
        if (cat is null)
            return NotFound();

        CatService.Delete(id);

        return NoContent();
    }

}