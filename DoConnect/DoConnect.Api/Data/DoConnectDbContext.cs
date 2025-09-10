using DoConnect.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DoConnect.Api.Data
{
    public class DoConnectDbContext : DbContext
    {
        public DoConnectDbContext(DbContextOptions<DoConnectDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Answer> Answers => Set<Answer>();
        public DbSet<Image> Images => Set<Image>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Uniques
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

            // Relationships
            modelBuilder.Entity<Question>()
                .HasOne(q => q.User)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.User)
                .WithMany(u => u.Answers)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Question)
                .WithMany(q => q.Images)
                .HasForeignKey(i => i.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Answer)
                .WithMany(a => a.Images)
                .HasForeignKey(i => i.AnswerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
