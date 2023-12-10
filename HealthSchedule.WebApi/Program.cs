using HealthSchedule.Application;
using HealthSchedule.Domain;
using HealthSchedule.Domain.Repositories;
using HealthSchedule.Infra.Contexts;
using HealthSchedule.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

/*var connectionString = builder.Configuration.GetConnectionString("connectionString");
builder.Services.AddDbContext<AppDataContext>(x => x.UseSqlServer(connectionString));*/
builder.Services.AddDbContext<AppDataContext>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddTransient<IPatientRepository, PatientRepository>();
builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddScoped<AppDataContext, AppDataContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
