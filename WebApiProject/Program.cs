using AutoMapper;
using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Mappings;
using WebApiProject.Repositories;
using WebApiProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("PatientsDb"));

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddAutoMapper(cfg => { }, typeof(PatientProfile).Assembly);
builder.Services.AddAutoMapper(cfg => { }, typeof(AppointmentProfile).Assembly);
builder.Services.AddAutoMapper(cfg => { }, typeof(ExamResultProfile).Assembly);
builder.Services.AddAutoMapper(cfg => { }, typeof(CommunicationProfile).Assembly);
builder.Services.AddAutoMapper(cfg => { }, typeof(InsuranceProfile).Assembly);

builder.Services.AddControllers();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
