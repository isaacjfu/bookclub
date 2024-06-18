using Bookclub.Models;
using System.Threading.Tasks;
namespace Bookclub.Interfaces;

public interface ICommentsRepository
{
    Task<IEnumerable<Comment>> GetComments();
    Task<Comment> GetCommentById(int commentId);
    Task InsertComment(Comment comment);
    Task DeleteComment(int commentId);
    Task UpdateComment(Comment comment);
    Task Save();
}