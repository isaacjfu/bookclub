using Microsoft.AspNetCore.Mvc;
using Bookclub.Repositories;
using Bookclub.Interfaces;
using Bookclub.Models;

namespace Bookclub.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class ClubsController:ControllerBase
{
    private IClubsRepository clubsRepository;
    public ClubsController(IClubsRepository clubsRepository)
    {
        this.clubsRepository = clubsRepository;
    }
    [HttpGet]
    public IActionResult GetClubs()
    {
        var clubs = clubsRepository.GetClubs();
        return Ok(clubs);
    }
    [HttpGet("{Id}")]
    public IActionResult GetClubById(int Id)
    {
        var club = clubsRepository.GetClubById(Id);
        return Ok(club);
    }
    [HttpPost]
    public IActionResult CreateClub(Club club)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        clubsRepository.InsertClub(club);
        return CreatedAtAction(nameof(GetClubById), new { id = club.Id}, club);
    }
    [HttpDelete("{Id}")]
    public IActionResult DeleteClub(int Id)
    {
        var club = clubsRepository.GetClubById(Id);
        if( club == null)
        {
            return NotFound();
        }
        clubsRepository.DeleteClub(Id);
        return NoContent();
    }
    [HttpPut("{Id}")]
    public IActionResult UpdateClub(int Id, Club club)
    {
        if( Id != club.Id)
        {
            return BadRequest();
        }
        if( !ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        clubsRepository.UpdateClub(club);
        return NoContent();
    }
}