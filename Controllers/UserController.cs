using Microsoft.AspNetCore.Mvc;
using webApiTutorial.Models;
using webApiTutorial.Services;

namespace webApiTutorial.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public UserController()
    {
    }
    [HttpGet]
    public ActionResult<List<User>> GetAll() => UserService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<User> Get(Guid id)
    {
        var user = UserService.Get(id);
        if (user is null)
            return NotFound();

        return user;
    }


    [HttpPost]
    public IActionResult Create(User user)
    {
        UserService.Add(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, User user)
    {
        if (id != user.Id)
            return BadRequest();

        var existingUser = UserService.Get(id);
        if (existingUser is null)
            return NotFound();

        UserService.Update(user);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var user = UserService.Get(id);
        if (user is null)
            return NotFound();

        UserService.Delete(id);

        return NoContent();
    }

}