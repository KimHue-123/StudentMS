using Microsoft.EntityFrameworkCore;
using StudentMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    Name = "Vo A",
                    PhoneNumber = "00001",
                    Dob = new DateTime(2001, 01, 01),
                    Sex = "Nam",
                    Address = "Q1"
                },
                new Student()
                {
                    Id = 2,
                    Name = "Vo B",
                    PhoneNumber = "00002",
                    Dob = new DateTime(2001, 02, 02),
                    Sex = "Nu",
                    Address = "Q2"
                },
                new Student()
                {
                    Id = 3,
                    Name = "Vo C",
                    PhoneNumber = "00003",
                    Dob = new DateTime(2001, 03, 03),
                    Sex = "Nam",
                    Address = "Q3"
                },
                new Student()
                {
                    Id = 4,
                    Name = "Vo D",
                    PhoneNumber = "00004",
                    Dob = new DateTime(2001, 04, 04),
                    Sex = "Nam",
                    Address = "Q4"
                });

            modelBuilder.Entity<Subject>().HasData(
                new Subject()
                {
                    Id = "Chemistry",
                    Name = "Chemistry subject"
                }, new Subject()
                {
                    Id = "Physics",
                    Name = "Physics subject"
                }, new Subject()
                {
                    Id = "Math",
                    Name = "Math subject"
                });

            modelBuilder.Entity<Grade>().HasData(
                new Grade()
                {
                    StudentId = 1,
                    SubjectId = "Chemistry",
                    Score = 8
                }, new Grade()
                {
                    StudentId = 1,
                    SubjectId = "Physics",
                    Score = 7.5f
                }, new Grade()
                {
                    StudentId = 1,
                    SubjectId = "Math",
                    Score = 8
                });
        }
    }
}
