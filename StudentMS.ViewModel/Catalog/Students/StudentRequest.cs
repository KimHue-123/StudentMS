using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.ViewModel.Catalog.Students
{
    public class StudentRequest
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Dob { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
    }
}
