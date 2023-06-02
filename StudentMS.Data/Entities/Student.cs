using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Dob { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }

        public List<Grade> Grades { get; set; }
    }
}
