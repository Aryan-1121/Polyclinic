using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using DotNetEnv;


namespace PolyclinicDALCrossPlatform.Models
{
    public partial class PolyclinicDBContext : DbContext
    {

        public PolyclinicDBContext()
        { }

        public PolyclinicDBContext(DbContextOptions<PolyclinicDBContext> options) : base(options)
        { }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }

        [DbFunction]
        public static decimal ufn_CalculateDoctorFees(string doctorId, DateTime dateOfAppointment)
        {
            return 0;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            DotNetEnv.Env.Load();
            var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json");

            var config = builder.Build();
            Console.WriteLine("tryin connection");
            try
            {
                // var connectionString = config.GetConnectionString("PolyclinicDBConnectionString");
                var connectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING");
                if (string.IsNullOrEmpty(connectionString))
                {
                    Console.WriteLine("Environment variable MYSQL_CONNECTION_STRING not found.");
                    return;
                }
                optionsBuilder.UseMySQL(connectionString);
                Console.WriteLine("connection established !!!");
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.HasKey(e => e.AppointmentNo);

                entity.Property(e => e.DateofAppointment).HasColumnType("date");

                entity.Property(e => e.DoctorId)
                    .IsRequired()
                    .HasColumnName("DoctorID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.PatientId)
                    .IsRequired()
                    .HasColumnName("PatientID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DoctorID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientID");
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.Property(e => e.DoctorId)
                    .HasColumnName("DoctorID")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DoctorName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fees).HasColumnType("money");

                entity.Property(e => e.Specialization)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });
        }
    }
}
