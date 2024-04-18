using IBKSTicketTrackingSystemBal.Bal;
using IBKSTicketTrackingSystemBal.Interface;
using IBKSTicketTrackingSystemDal.Dal;
using IBKSTicketTrackingSystemDal.Interface;
using IBKSTicketTrackingSystemDal.Models;
using Microsoft.EntityFrameworkCore;
using Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SupportContext>(options =>
    options.UseSqlServer(SecurityHelper.Decrypt(builder.Configuration.GetConnectionString("DatabaseConnection"),
        builder.Configuration.GetValue<string>("Key"))));

builder.Services.AddScoped<ITicketTrackingBal, TicketTrackingBal>();
builder.Services.AddScoped<ITicketTrackingDal, TicketTrackingDal>();

var allowedOrigins = builder.Configuration.GetValue<string>("AllowedOrigins").Split(";");


builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder => builder.WithOrigins(allowedOrigins).AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());

app.UseCors("CORSPolicy");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
