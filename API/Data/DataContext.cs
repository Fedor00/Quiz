

using API.Controllers.Entities;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatMicroservice.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasMany(m => m.Choices)
                .WithOne(u => u.Question)
                .HasForeignKey(m => m.QuestionId);

           modelBuilder.Entity<Answer>()
            .HasOne(e => e.Question)
            .WithOne(e => e.Answer)
            .HasForeignKey<Answer>(e => e.QuestionId);

        }

    }
}