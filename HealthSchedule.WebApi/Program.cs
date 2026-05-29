using HealthSchedule.Application;
using HealthSchedule.Domain;
using HealthSchedule.Domain.Repositories;
using HealthSchedule.Domain.Services;
using HealthSchedule.Infra;
using HealthSchedule.Infra.Contexts;
using HealthSchedule.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

/*var connectionString = builder.Configuration.GetConnectionString("connectionString");
builder.Services.AddDbContext<AppDataContext>(x => x.UseSqlServer(connectionString));*/
builder.Services.AddDbContext<AppDataContext>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddTransient<IPatientRepository, PatientRepository>();
builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddScoped<AppDataContext, AppDataContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// Use CORS before other middleware
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
