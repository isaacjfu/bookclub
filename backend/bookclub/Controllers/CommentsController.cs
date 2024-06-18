using Microsoft.AspNetCore.Mvc;
using Bookclub.Repositories;
using Bookclub.Interfaces;
using Bookclub.Models;
namespace Bookclub.Controllers;

[Route("[controller]/[action]")]
[ApiController]

public class CommentsController:ControllerBase
{
    private ICommentsRepository commentsRepository;
    public CommentsController(ICommentsRepository commentsRepository)
    {
        this.commentsRepository = commentsRepository;
    }

    [HttpGet]
    public IActionResult GetComments()
    {
        var comments = commentsRepository.GetComments();
        return Ok(comments);
    }

    [HttpGet("{Id}")]
    public IActionResult GetCommentById(int Id)
    {
        var comment = commentsRepository.GetCommentById(Id);
        return Ok(comment);
    }
    
    [HttpPost]
    public IActionResult CreateComment(Comment comment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        commentsRepository.InsertComment(comment);
        return CreatedAtAction(nameof(GetCommentById), new {id = comment.Id}, comment);
    }
    [HttpDelete("{Id}")]
    public IActionResult DeleteComment(int Id)
    {
        var comment = commentsRepository.GetCommentById(Id);
        if ( comment == null)
        {
            return NotFound();
        }
        commentsRepository.DeleteComment(Id);
        return NoContent();
    }
    [HttpPut("{Id}")]
    public IActionResult UpdateComment(int Id, Comment comment)
    {
        if (Id != comment.Id)
        {
            return BadRequest();
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        commentsRepository.UpdateComment(comment);
        return NoContent();
    }

    
}