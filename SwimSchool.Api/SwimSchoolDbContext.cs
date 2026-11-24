using Microsoft.EntityFrameworkCore;
using SwimSchool.Api.Entities;

namespace SwimSchool.Api;

public sealed class SwimSchoolDbContext(DbContextOptions<SwimSchoolDbContext> options)
    : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();

    public DbSet<SwimClass> SwimClasses => Set<SwimClass>();

    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var enrollment = modelBuilder.Entity<Enrollment>();

        // Map Enrollment → Student using StudentId.
        enrollment.HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        // Map Enrollment → SwimClass using SwimClassId.
        enrollment.HasOne(e => e.SwimClass)
            .WithMany(sc => sc.Enrollments)
            .HasForeignKey(e => e.SwimClassId)
            .OnDelete(DeleteBehavior.Cascade);
        // Add a unique index over StudentId and SwimClassId together.
        enrollment.HasIndex(e => new { e.StudentId, e.SwimClassId })
            .IsUnique();
    }
}
