using Microsoft.EntityFrameworkCore;
using Bookclub.Data;
using Bookclub.Seed;
using Bookclub.Interfaces;
using Bookclub.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddScoped<IBooksRepository,BooksRepository>();
builder.Services.AddScoped<IUsersRepository,UsersRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<IDataSeeder, DataSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (args.Contains("seed"))
{
    using(var scope = app.Services.CreateScope())
    {
        var dataSeeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
        dataSeeder.seedData();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
