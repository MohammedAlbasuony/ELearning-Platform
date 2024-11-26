using ELearning_Platform_.DAL.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ELearning_Platform_.DAL.DB
{
    public class ApplicationDBcontext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
        {
        }
        public DbSet<Learner> Learners { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Support> Supports { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Fluent API configurations

            builder.Entity<Instructor>(entity =>
            {
                entity.ToTable("Instructors"); // Custom table name
                entity.HasKey(i => i.Id); // Primary key from IdentityUser

                entity.Property(i => i.InstructorName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasMany(i => i.Courses) // One Instructor has many Courses
                      .WithOne(c => c.Instructor) // One Course has one Instructor
                      .HasForeignKey(c => c.InstructorId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Fluent API for Account
            builder.Entity<Account>(entity =>
            {
                entity.ToTable("Accounts"); // Custom table name
                entity.HasKey(a => a.Id); // Primary key from IdentityUser

                entity.Property(a => a.AccountType)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.HasMany(a => a.Supports) // One Account has many Supports
                      .WithOne(s => s.Account) // One Support belongs to one Account
                      .HasForeignKey(s => s.AccountId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(a => a.Learners) // One Account has many Learners
                      .WithOne(l => l.Account) // One Learner belongs to one Account
                      .HasForeignKey(l => l.AccountId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Fluent API for Learner
            builder.Entity<Learner>(entity =>
            {
                entity.ToTable("Learners");
                entity.HasKey(l => l.LearnerId);

                entity.Property(l => l.LearnerName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasOne(l => l.Account) // One Learner belongs to one Account
                      .WithMany(a => a.Learners) // One Account has many Learners
                      .HasForeignKey(l => l.AccountId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(l => l.Courses) // Many-to-Many relationship (configure join table separately if needed)
                      .WithMany(c => c.Learners);

                entity.HasMany(l => l.Feedbacks)
                      .WithOne(f => f.Learner)
                      .HasForeignKey(f => f.LearnerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(l => l.Certificates)
                      .WithOne(c => c.Learner)
                      .HasForeignKey(c => c.LearnerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Fluent API for Course
            builder.Entity<Course>(entity =>
            {
                entity.ToTable("Courses");
                entity.HasKey(c => c.CourseId);

                entity.Property(c => c.CourseTitle)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.HasOne(c => c.Instructor) // One Course belongs to one Instructor
                      .WithMany(i => i.Courses) // One Instructor has many Courses
                      .HasForeignKey(c => c.InstructorId) // Updated foreign key
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Fluent API for Quiz
            builder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quizzes");
                entity.HasKey(q => q.QuizId);

                entity.Property(q => q.QuizStatus)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.HasOne(q => q.Course) // One Quiz belongs to one Course
                      .WithMany(c => c.Quizzes) // One Course has many Quizzes
                      .HasForeignKey(q => q.CourseId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(q => q.Feedbacks)
                      .WithOne(f => f.Quiz)
                      .HasForeignKey(f => f.QuizId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Fluent API for Feedback
            builder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedbacks");
                entity.HasKey(f => f.FeedbackId);

                entity.Property(f => f.FeedbackText)
                      .IsRequired()
                      .HasMaxLength(500);

                entity.HasOne(f => f.Learner) // One Feedback belongs to one Learner
                      .WithMany(l => l.Feedbacks) // One Learner has many Feedbacks
                      .HasForeignKey(f => f.LearnerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(f => f.Quiz) // One Feedback belongs to one Quiz
                      .WithMany(q => q.Feedbacks) // One Quiz has many Feedbacks
                      .HasForeignKey(f => f.QuizId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Fluent API for Certificate
            builder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificates");
                entity.HasKey(c => c.CertificateId);

                entity.Property(c => c.CertificateDate)
                      .IsRequired();

                entity.HasOne(c => c.Learner) // One Certificate belongs to one Learner
                      .WithMany(l => l.Certificates) // One Learner has many Certificates
                      .HasForeignKey(c => c.LearnerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Fluent API for Support
            builder.Entity<Support>(entity =>
            {
                entity.ToTable("Supports");
                entity.HasKey(s => s.SupportId);

                entity.Property(s => s.SupportCategory)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(s => s.SupportStatus)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.HasOne(s => s.Account) // One Support belongs to one Account
                      .WithMany(a => a.Supports) // One Account has many Supports
                      .HasForeignKey(s => s.AccountId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
