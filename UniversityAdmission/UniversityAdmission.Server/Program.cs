using UniversityAdmission.Domain.Repositories;
using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IRepository<Applicant>, ApplicantRepository>();
builder.Services.AddSingleton<IRepository<Exam>, ExamRepository>();
builder.Services.AddSingleton<IRepository<ExamResult>, ExamResultRepository>();
builder.Services.AddSingleton<IRepository<Specialty>, SpecialtyRepository>();



builder.Services.AddAutoMapper(typeof(Mapper));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();
