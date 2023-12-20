

using API.Controllers.Entities;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasMany(m => m.Choices)
                .WithOne(u => u.Question)
                .HasForeignKey(m => m.QuestionId);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.CorrectAnswer)
                .WithOne()
                .HasForeignKey<Question>(q => q.CorrectAnswerId);


        }

    }
}