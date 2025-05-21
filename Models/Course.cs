using System;
using System.ComponentModel.DataAnnotations;

namespace student_management_system.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }


}

