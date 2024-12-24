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
    public UniversityAdmissionContext(DbContextOptions<UniversityAdmissionContext> options) 
        : base(options)
    {
        Database.EnsureCreated();
    }
    public UniversityAdmissionContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>()
            .HasOne<Applicant>()
            .WithMany()
            .HasForeignKey(a => a.ApplicantId);

        modelBuilder.Entity<Application>()
            .HasOne<Specialty>()
            .WithMany()
            .HasForeignKey(a=>a.SpecialtyId);

        modelBuilder.Entity<ExamResult>()
            .HasOne<Applicant>()
            .WithMany()
            .HasForeignKey(e => e.ApplicantId);

        modelBuilder.Entity<ExamResult>()
            .HasOne<Exam>()
            .WithMany()
            .HasForeignKey(e => e.ExamId);

        modelBuilder.Entity<Exam>()
            .HasOne<ExamResult>()
            .WithMany()
            .HasForeignKey(e => e.IdExam);

        modelBuilder.Entity<Specialty>()
            .HasIndex(s => s.Code)
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}
