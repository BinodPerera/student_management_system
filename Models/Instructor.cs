using System;
using System.ComponentModel.DataAnnotations;

namespace student_management_system.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }

}

