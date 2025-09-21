using Microsoft.EntityFrameworkCore;
using BetHunterModel;

namespace BetHunterData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Alternative> Alternatives { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<UserProgressTopic> UserProgressTopics { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired()
                .HasColumnType("varchar(255)");

            modelBuilder.Entity<Article>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Article>()
                .Property(a => a.Title)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Lesson>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Lesson>()
                .Property(l => l.Title)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Question>()
                .HasKey(q => q.Id);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Topic)
                .WithMany()
                .HasForeignKey(q => q.TopicId);

            modelBuilder.Entity<Alternative>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Alternative>()
                .HasOne(a => a.Question)
                .WithMany()
                .HasForeignKey(a => a.QuestionId);

            modelBuilder.Entity<Topic>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Topic>()
                .HasOne(t => t.Lesson)
                .WithMany()
                .HasForeignKey(t => t.LessonId);

            modelBuilder.Entity<UserAnswer>()
                .HasKey(ua => ua.Id);

            modelBuilder.Entity<UserAnswer>()
                .HasOne(ua => ua.User)
                .WithMany()
                .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<UserAnswer>()
                .HasOne(ua => ua.Question)
                .WithMany()
                .HasForeignKey(ua => ua.QuestionId);

            modelBuilder.Entity<UserAnswer>()
                .HasOne(ua => ua.Alternative)
                .WithMany()
                .HasForeignKey(ua => ua.AlternativeId);

            modelBuilder.Entity<UserProgressTopic>()
                .HasKey(upt => upt.Id);

            modelBuilder.Entity<UserProgressTopic>()
                .HasOne(upt => upt.User)
                .WithMany()
                .HasForeignKey(upt => upt.UserId);

            modelBuilder.Entity<UserProgressTopic>()
                .HasOne(upt => upt.Topic)
                .WithMany()
                .HasForeignKey(upt => upt.TopicId);

            modelBuilder.Entity<UserProgressTopic>()
                .HasOne(upt => upt.Question)
                .WithMany()
                .HasForeignKey(upt => upt.QuestionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
