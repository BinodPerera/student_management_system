using System;
using System.ComponentModel.DataAnnotations;

namespace student_management_system.Models
{
    public class Marks
    {
        [Key]
        public int MarkID { get; set; }

        public int EnrollmentID { get; set; }
        public Enrollment Enrollment { get; set; }

        public double AssignmentMarks { get; set; }
        public double ExamMarks { get; set; }
        public string Grade { get; set; }
    }


}

