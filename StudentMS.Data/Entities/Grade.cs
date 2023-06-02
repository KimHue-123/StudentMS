using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Data.Entities
{
    public class Grade
    {
        public int StudentId { get; set; }
        public string SubjectId { get; set; }
        public float Score { get; set; }

        public Student Student { get; set; }
        public Subject Subject{ get; set; }
    }
}
