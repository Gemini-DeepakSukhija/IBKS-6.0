using IBKSTicketTrackingSystemBAL.BAL;
using IBKSTicketTrackingSystemBAL.Interface;
using IBKSTicketTrackingSystemDAL.DAL;
using IBKSTicketTrackingSystemDAL.Interface;
using IBKSTicketTrackingSystemDAL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SupportContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));
builder.Services.AddScoped<ITicketTrackingBAL, TicketTrackingBAL>();
builder.Services.AddScoped<ITicketTrackingDal, TicketTrackingDal>();
builder.Services.AddCors(options => {
    options.AddPolicy("CORSPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());

app.UseCors("CORSPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
