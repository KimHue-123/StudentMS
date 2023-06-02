using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Data.Entities
{
    public class Subject
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<Grade> Grades { get; set; }
    }
}
