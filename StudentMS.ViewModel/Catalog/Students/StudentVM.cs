using StudentMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.ViewModel.Catalog.Students
{
    public class StudentVM
    {
        public StudentVM(int id, string name, string phoneNumber, DateTime dob, string sex, string address, float? average)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Dob = dob;
            Sex = sex;
            Address = address;
            Average = average;
        }
        public StudentVM()
        {
        }
        public StudentVM(Student student)
        {
            Id = student.Id;
            Name = student.Name;
            PhoneNumber = student.PhoneNumber;
            Dob = student.Dob;
            Sex = student.Sex;
            Address = student.Address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Dob { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public float? Average { get; set; }
    }
}
