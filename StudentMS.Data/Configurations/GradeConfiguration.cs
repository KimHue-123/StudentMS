using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Data.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable("Grades");
            builder.HasKey(x => new { x.SubjectId,x.StudentId });

            builder.HasOne(x => x.Student).WithMany(x => x.Grades).HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.Subject).WithMany(x => x.Grades).HasForeignKey(x => x.SubjectId);

        }
    }
}
