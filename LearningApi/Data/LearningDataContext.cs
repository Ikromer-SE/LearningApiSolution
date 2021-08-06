using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningApi.Data
{
    public class LearningDataContext : DbContext
    {
        public LearningDataContext(DbContextOptions<LearningDataContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<LearningItem> LearningItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>()
                .Property(p => p.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<TodoItem>()
                .HasData(
                    new TodoItem { Id = 1, Description = "Fix Angular App", IsRemoved = false, WhenAdded = DateTime.Now },
                    new TodoItem { Id = 2, Description = "Add a POST to the API", IsRemoved = false, WhenAdded = DateTime.Now }
                );

            modelBuilder.Entity<LearningItem>()
                .HasData(
                    new LearningItem { Id = 1, Topic = "Learn Protobuf", Competency = "Conscious Incompetence" },
                    new LearningItem { Id = 2, Topic = "Explore Terraform", Competency = "Conscious Competence", Notes = "Watched some good videos. Tried it out. It's cool" }
                );
        }
    }
}
