using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(10);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
        }
    }
}
