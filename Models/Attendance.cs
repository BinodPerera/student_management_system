using System;
using System.ComponentModel.DataAnnotations;

namespace student_management_system.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }

        public int EnrollmentID { get; set; }
        public Enrollment Enrollment { get; set; }

        public DateTime Date { get; set; }
        public string Status { get; set; } // e.g., "Present", "Absent"
    }
}

