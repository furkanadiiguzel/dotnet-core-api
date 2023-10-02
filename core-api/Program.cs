using Microsoft.EntityFrameworkCore;
using core_api.Context;
using core_api.Middleware; // Include the namespace where JwtAuthenticationMiddleware is defined

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerConnStr"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add the JwtAuthenticationMiddleware before app.UseAuthentication()
app.UseMiddleware<JwtAuthenticationMiddleware>();

app.UseAuthentication();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
