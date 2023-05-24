using Microsoft.EntityFrameworkCore;
using PruebaTecnica;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Add ConnectionString DataBase
builder.Services.AddDbContext<AplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnections")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add AutoMapper
builder.Services.AddAutoMapper(typeof(AplicationDbContext));

builder.Services.AddCors(options =>
{

    options.AddPolicy("AllowOrigin", app =>
    {
        app
        .AllowAnyMethod()
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithExposedHeaders("Content-Disposition");
    });

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowOrigin");

app.Run();
