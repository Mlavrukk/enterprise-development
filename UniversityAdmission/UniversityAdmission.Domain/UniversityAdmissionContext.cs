using Microsoft.EntityFrameworkCore;
using UniversityAdmission.Domain.Class;
namespace UniversityAdmission.Domain;

public class UniversityAdmissionContext : DbContext
{
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamResult> ExamResults { get; set; }
    public DbSet<Specialty> Specialties { get; set; }
    public DbSet<Application> Applications { get; set; }
    public UniversityAdmissionContext(DbContextOptions<UniversityAdmissionContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

}
