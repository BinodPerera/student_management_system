using System;
using System.ComponentModel.DataAnnotations;

namespace student_management_system.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }

        public string Semester { get; set; }
        public int Year { get; set; }

        public Marks Marks { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}

