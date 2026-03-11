using AutoMapper;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Mappings;
using WebApiProject.Repositories;
using WebApiProject.Services;
using WebApiProject.Repositories.Interface;
using WebApiProject.Services.Interface;

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
builder.Services.AddAutoMapper(cfg => { }, typeof(FacilityMappingProfile).Assembly);
builder.Services.AddAutoMapper(cfg => { }, typeof(CampaignProfile).Assembly);

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IFacilityRepository, FacilityRepository>();
builder.Services.AddScoped<IFacilityService, FacilityService>();
builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();
builder.Services.AddScoped<ICampaignService, CampaignService>();

builder.Services.AddAutoMapper(cfg => { }, typeof(OrderProfile).Assembly);

// Register services and repositories
builder.Services.AddScoped<ISchedulingService, SchedulingService>();
builder.Services.AddScoped<ISchedulingRepository, SchedulingRepository>();

// Register AutoMapper
builder.Services.AddAutoMapper(cfg => { }, typeof(SchedulingProfile).Assembly);



builder.Services.AddControllers();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApiVersioning()
                .AddMvc()
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
