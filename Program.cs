using HovedOpgaveWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var npgsqlOptions = new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection"))
    {
        Pooling = true,       // Enable connection pooling
        MinPoolSize = 10,      // Set the minimum pool size
        MaxPoolSize = 500,     // Set the maximum pool size
        CommandTimeout =30,    // Timeout for database commands (seconds)
        ConnectionIdleLifetime = 300  // Connection timeout after being idle (seconds)
    };
        
    options.UseNpgsql(npgsqlOptions.ConnectionString);

});
    
    
    //options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
