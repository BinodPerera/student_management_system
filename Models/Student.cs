using System;
using System.ComponentModel.DataAnnotations;

namespace student_management_system.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public int EnrollmentYear { get; set; }
        public string Status { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }

}

