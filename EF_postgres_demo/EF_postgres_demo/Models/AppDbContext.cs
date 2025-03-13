using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_postgres_demo.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Standard> Standards { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Studentaddress> Studentaddresses { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<VwStudentCourse> VwStudentCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ef_demo_db;Username=postgres;Password=Welcome@123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Courseid).HasName("course_pkey");

            entity.ToTable("course");

            entity.Property(e => e.Courseid).HasColumnName("courseid");
            entity.Property(e => e.Coursename)
                .HasMaxLength(100)
                .HasColumnName("coursename");
            entity.Property(e => e.Teacherid).HasColumnName("teacherid");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .HasForeignKey(d => d.Teacherid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("course_teacherid_fkey");
        });

        modelBuilder.Entity<Standard>(entity =>
        {
            entity.HasKey(e => e.Standardid).HasName("standard_pkey");

            entity.ToTable("standard");

            entity.Property(e => e.Standardid).HasColumnName("standardid");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Standardname)
                .HasMaxLength(100)
                .HasColumnName("standardname");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("student_pkey");

            entity.ToTable("student");

            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Standardid).HasColumnName("standardid");

            entity.HasOne(d => d.Standard).WithMany(p => p.Students)
                .HasForeignKey(d => d.Standardid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("student_standardid_fkey");

            entity.HasMany(d => d.Courses).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "Studentcourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("Courseid")
                        .HasConstraintName("studentcourse_courseid_fkey"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("Studentid")
                        .HasConstraintName("studentcourse_studentid_fkey"),
                    j =>
                    {
                        j.HasKey("Studentid", "Courseid").HasName("studentcourse_pkey");
                        j.ToTable("studentcourse");
                        j.IndexerProperty<int>("Studentid").HasColumnName("studentid");
                        j.IndexerProperty<int>("Courseid").HasColumnName("courseid");
                    });
        });

        modelBuilder.Entity<Studentaddress>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("studentaddress_pkey");

            entity.ToTable("studentaddress");

            entity.Property(e => e.Studentid)
                .ValueGeneratedNever()
                .HasColumnName("studentid");
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .HasColumnName("address2");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Mobile)
                .HasMaxLength(10)
                .HasColumnName("mobile");

            entity.HasOne(d => d.Student).WithOne(p => p.Studentaddress)
                .HasForeignKey<Studentaddress>(d => d.Studentid)
                .HasConstraintName("studentaddress_studentid_fkey");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Teacherid).HasName("teacher_pkey");

            entity.ToTable("teacher");

            entity.Property(e => e.Teacherid).HasColumnName("teacherid");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Standardid).HasColumnName("standardid");

            entity.HasOne(d => d.Standard).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.Standardid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("teacher_standardid_fkey");
        });

        modelBuilder.Entity<VwStudentCourse>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_student_course");

            entity.Property(e => e.Courseid).HasColumnName("courseid");
            entity.Property(e => e.Coursename)
                .HasMaxLength(100)
                .HasColumnName("coursename");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Studentid).HasColumnName("studentid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
