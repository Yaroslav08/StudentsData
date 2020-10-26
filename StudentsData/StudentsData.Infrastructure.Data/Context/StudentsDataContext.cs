using Microsoft.EntityFrameworkCore;
using StudentsData.Domain.Models;
using StudentsData.Infrastructure.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
namespace StudentsData.Infrastructure.Data.Context
{
    public class StudentsDataContext : DbContext
    {
        private const string LocalConnection = "Server=(localdb)\\MSSQLLocalDB;Database=StudentsData;Trusted_Connection=True;";
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(LocalConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }
    }
}