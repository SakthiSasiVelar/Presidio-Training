using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Appointment_Booking_Application_DAL_Library.Models
{
    public partial class AppointmentBookingDbContext : DbContext
    {
        public AppointmentBookingDbContext()
        {
        }

        public AppointmentBookingDbContext(DbContextOptions<AppointmentBookingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<DoctorAppointmentSchedule> DoctorAppointmentSchedules { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=18RBBX3\\INSTANCE;Integrated Security=true;Initial Catalog=AppointmentBookingDb;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.AppointmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("appointment_id");

                entity.Property(e => e.AppointmentTime)
                    .HasColumnType("datetime")
                    .HasColumnName("appointment_time");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("fk_doctorIdInappointment");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("fk_patientId");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.DoctorId)
                    .ValueGeneratedNever()
                    .HasColumnName("doctor_id");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("contact_Number");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("specialization");
            });

            modelBuilder.Entity<DoctorAppointmentSchedule>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DoctorAppointmentSchedule");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.ScheduleList)
                    .HasColumnType("datetime")
                    .HasColumnName("schedule_list");

                entity.HasOne(d => d.Doctor)
                    .WithMany()
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("fk_doctorId");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.PatientId)
                    .ValueGeneratedNever()
                    .HasColumnName("patient_id");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("contact_number");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("dob");

                entity.Property(e => e.MedicalProblem)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("medical_problem");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
