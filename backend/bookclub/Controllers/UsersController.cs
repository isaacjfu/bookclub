using Microsoft.AspNetCore.Mvc;
using Bookclub.Repositories;
using Bookclub.Interfaces;
using Bookclub.Models;

namespace Bookclub.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class UsersController: ControllerBase
{
    private IUsersRepository usersRepository;

    public UsersController(IUsersRepository usersRepository)
    {
        this.usersRepository = usersRepository
    }

    public IActionResult GetUsers()
    {
        var users = usersRepository.GetUsers();
        return Ok(users);
    }

    [HttpGet("{Id}")]
    public IActionResult GetUserById(int Id)
    {
        var user = usersRepository.GetUserById(Id);
        return Ok(user);
    }
    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        usersRepository.InsertUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id}, user);
    }
    [HttpDelete("{Id}")]
    public IActionResult DeleteUser(int Id)
    {
        var user = usersRepository.GetUserById(Id);
        if( user == null)
        {
            return NotFound();
        }
        usersRepository.DeleteUser(Id);
        return NoContent();
    }
    [HttpPut("{Id}")]
    public IActionResult UpdateUser(int Id, User user)
    {
        if( Id != user.Id)
        {
            return BadRequest();
        }
        if( !ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        usersRepository.UpdateUser(user);
        return NoContent();
    }

}