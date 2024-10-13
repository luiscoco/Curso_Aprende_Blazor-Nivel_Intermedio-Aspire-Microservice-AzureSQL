using Microsoft.EntityFrameworkCore;
using AzureSQLWebAPIMicroservice.Models;

namespace AzureSQLWebAPIMicroservice.Data
{
    public class ExampleDbContext:DbContext
    {
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options)
        : base(options)
        {
        }

        public DbSet<ExampleModel> ExampleModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the primary key for ExampleModel
            modelBuilder.Entity<ExampleModel>().HasKey(e => e.Id);

            // Configure some properties with more details
            modelBuilder.Entity<ExampleModel>()
                .Property(e => e.Name)
                .IsRequired() // Makes the Name field required
                .HasMaxLength(100); // Sets maximum length of the Name field to 100 characters

            modelBuilder.Entity<ExampleModel>()
                .Property(e => e.Description)
                .HasMaxLength(255); // Sets maximum length of the Description field to 255 characters

            // Set a default value for the CreatedDate field
            modelBuilder.Entity<ExampleModel>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()"); // This will use the SQL Server GETDATE() function to set the default value

            // Seed data
            modelBuilder.Entity<ExampleModel>().HasData(
                new ExampleModel { Id = 1, Name = "Sample Name 1", Description = "Sample Description 1", CreatedDate = DateTime.Now },
                new ExampleModel { Id = 2, Name = "Sample Name 2", Description = "Sample Description 2", CreatedDate = DateTime.Now }
                // Add more seed data as needed
            );
        }
    }
}
