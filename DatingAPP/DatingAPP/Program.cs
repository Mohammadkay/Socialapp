using DatingAPP;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Services.Interfaces;
using Services.UnitOfWork;
using System.Text;
using Services.Services;
using DatingAPP.Extinsion;
using DatingAPP.Middelware;
using Microsoft.EntityFrameworkCore;
using Domain.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("crospolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scop=app.Services.CreateScope();
var services = scop.ServiceProvider;
try
{
    var context=services.GetRequiredService<mkContext>();
    await context.Database.MigrateAsync();
    await Seed.seedUsers(context);
}catch (Exception ex)
{
    var logger=services.GetService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}
app.Run();
