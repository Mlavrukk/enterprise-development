using UniversityAdmission.Domain.Repositories;
using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option => 
        {
            var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
        });

builder.Services.AddDbContext<UniversityAdmissionContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("MySql"), new MySqlServerVersion(new Version())));

builder.Services.AddScoped<IRepository<Applicant>, ApplicantRepository>();
builder.Services.AddScoped<IRepository<Exam>, ExamRepository>();
builder.Services.AddScoped<IRepository<ExamResult>, ExamResultRepository>();
builder.Services.AddScoped<IRepository<Specialty>, SpecialtyRepository>();
builder.Services.AddScoped<IRepository<Application>, ApplicationRepository>();


builder.Services.AddAutoMapper(typeof(Mapper));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();
