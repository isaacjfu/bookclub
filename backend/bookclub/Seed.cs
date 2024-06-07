using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Bookclub.Models;
using Bookclub.Data;
using Newtonsoft.Json;

namespace Bookclub.Seed;

public interface IDataSeeder
{
    void seedData();
}

public class DataSeeder : IDataSeeder
{
    private readonly DataContext _dbContext;
    private readonly IConfiguration _config;
    private readonly string _jsonFilePath;

    public DataSeeder(DataContext dbContext, IConfiguration config)
    {
        _config = config;
        _dbContext = dbContext;
        _jsonFilePath = _config["Data:FilePath"];
    }

    public void seedData()
    {
        if (_dbContext.Books.Any())
        {
            return; // Database has already been seeded
        }
        for(int i =1; i <= 3; i++)
        {
            var count = 0;
            var file_name = "books_data_" + i.ToString() + ".json";
            var path_name = Path.Combine(_jsonFilePath, file_name);
            using( var streamReader = new StreamReader(path_name))
            using( var jsonReader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();
                jsonReader.SupportMultipleContent = true;

                while( jsonReader.Read())
                {
                    if(jsonReader.TokenType == JsonToken.StartObject)
                    {
                        var book = serializer.Deserialize<Book>(jsonReader);
                        _dbContext.Books.Add(book);
                        Console.WriteLine((++count) + '\n');
                        if(_dbContext.ChangeTracker.Entries().Count() > 100)
                        {
                            _dbContext.SaveChanges();
                        }
                    }
                }
            }
            count = 0;
        }
        _dbContext.SaveChanges();
    }
}
