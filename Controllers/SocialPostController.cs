using Microsoft.AspNetCore.Mvc;
using webApiTutorial.Models;
using webApiTutorial.Services;

namespace webApiTutorial.Controllers;

[ApiController]
[Route("[controller]")]
public class SocialPostController : ControllerBase
{
    public SocialPostController()
    {
    }
    [HttpGet]
    public ActionResult<List<SocialPost>> GetAll() => SocialPostService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<SocialPost> Get(Guid id)
    {
        var socialPost = SocialPostService.Get(id);
        if (socialPost is null)
            return NotFound();

        return socialPost;
    }


    [HttpPost]
    public IActionResult Create(SocialPost socialPost)
    {
        SocialPostService.Add(socialPost);
        return CreatedAtAction(nameof(Get), new(), socialPost);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, SocialPost socialPost)
    {
        if (id != socialPost.Id)
            return BadRequest();

        var existingSocialPost = SocialPostService.Get(id);
        if (existingSocialPost is null)
            return NotFound();

        SocialPostService.Update(socialPost);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var socialPost = SocialPostService.Get(id);
        if (socialPost is null)
            return NotFound();

        SocialPostService.Delete(id);

        return NoContent();
    }

}