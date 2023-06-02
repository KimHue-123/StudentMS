using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Dob).IsRequired();
            builder.Property(x => x.PhoneNumber).IsUnicode(false);
            builder.Property(x => x.Sex).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(150);
        }
    }
}
