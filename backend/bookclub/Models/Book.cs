using Newtonsoft.Json;
namespace Bookclub.Models;

public class Book
{

    public int Id { get; set; }

    [JsonProperty("title")]
    public string Name { get; set; }

    [JsonProperty("author")]
    public string Author {get; set;}
    
    public ICollection<BookClub> BookClubs { get; set; }
}