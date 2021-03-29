using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateAPI.Entities
{
    public class HotChocolateDbContext: DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=HotChocolateDb;Trusted_Connection=True;";
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(n => n.Email)
                .IsRequired()
                .HasMaxLength(35);
            modelBuilder.Entity<User>()
                .Property(n => n.FirstName)
                .IsRequired()
                .HasMaxLength(35);
            modelBuilder.Entity<User>()
                .Property(n => n.LastName)
                .IsRequired()
                .HasMaxLength(35);
            modelBuilder.Entity<User>()
                .Property(n => n.PasswordHash)
                .IsRequired();
            modelBuilder.Entity<Role>()
                .Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
