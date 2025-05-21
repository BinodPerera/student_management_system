using System;
using System.ComponentModel.DataAnnotations;

namespace student_management_system.Models
{
    public class Department
    {
        [Key]
        public int DeptID { get; set; }

        public string DeptName { get; set; }

        public ICollection<Course> Courses { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
    }
}

