using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InterviewSchedulerAPI.InterviewSchedulerModel
{
    public partial class InterviewSchedulerDBContext : DbContext
    {
        public InterviewSchedulerDBContext()
        {
        }

        public InterviewSchedulerDBContext(DbContextOptions<InterviewSchedulerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<InterviewLevel> InterviewLevels { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KANINI-LTP-536\\SQLSERVER2019MY; Database=InterviewSchedulerDB; Trusted_Connection=True; MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("Candidate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.JobId).HasColumnName("Job_Id");

                entity.Property(e => e.LevelId).HasColumnName("Level_Id");

                entity.Property(e => e.Mobileno)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Resume)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CJFK");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CLFK");
            });

            modelBuilder.Entity<InterviewLevel>(entity =>
            {
                entity.ToTable("InterviewLevel");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LevelDes)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JobId)
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .HasColumnName("JobID")
                    .HasComputedColumnSql("('KA-'+CONVERT([varchar](16),[id]))", false);

                entity.Property(e => e.JobRole)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Rolename)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
