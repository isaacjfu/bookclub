using Bookclub.Models;
using Bookclub.Interfaces;
using Bookclub.Data;

namespace Bookclub.Repositories;

public class CommentsRepository : ICommentsRepository
{
    private DataContext context;

    public CommentsRepository(DataContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Comment>> GetComments()
    {
        return context.Comments.ToList();
    }
    public async Task<Comment> GetCommentById(int commentId)
    {
        return context.Comments.Find(commentId);
    }
    public async Task InsertComment(Comment comment)
    {
        context.Comments.Add(comment);
    }
    public async Task DeleteComment(int commentId)
    {
        Comment c = context.Comments.Find(commentId);
        context.Comments.Remove(c);
    }
    public async Task UpdateComment(Comment comment)
    {
        //
    }
    public async Task Save()
    {
        context.SaveChanges();
    }
}