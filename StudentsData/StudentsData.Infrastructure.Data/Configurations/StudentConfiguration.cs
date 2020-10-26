using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace StudentsData.Infrastructure.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasIndex(d => new
            {
                d.Firstname,
                d.Middlename,
                d.Lastname,
                d.Photo,
                d.GroupId,
                d.Passport,
                d.Address
            });
        }
    }
}