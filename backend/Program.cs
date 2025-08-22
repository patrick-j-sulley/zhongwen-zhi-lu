using zhongwen_zhi_lu.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<zhongwen_zhi_lu.Data.AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder.WithOrigins("http://localhost:3000")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers(); // Add this line to register the controllers

var app = builder.Build();

// Configure middleware here
app.UseRouting();
app.UseCors("AllowFrontend"); // if you use CORS

app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    foreach (var endpoint in endpoints.DataSources.SelectMany(ds => ds.Endpoints))
    {
        Console.WriteLine(endpoint.DisplayName);
    }
});

app.Run();

