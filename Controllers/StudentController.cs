using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using student_management_system.Data;
using student_management_system.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace student_management_system.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public IActionResult Index()
        {
            var students = _context.Students
                .FromSqlRaw("SELECT * FROM Students WHERE Status = 'Active'")
                .ToList();
            return View(students);
        }

        // GET: Student/Add
        public IActionResult Add() => View();

        // POST: Student/Add
        [HttpPost]
        public IActionResult Add(Student student)
        {
            var sql = "INSERT INTO Students (Name, NIC, DOB, Email, Contact, EnrollmentYear, Status) " +
                      "VALUES (@Name, @NIC, @DOB, @Email, @Contact, @EnrollmentYear, @Status)";

            _context.Database.ExecuteSqlRaw(sql,
                new SqlParameter("@Name", student.Name),
                new SqlParameter("@NIC", student.NIC),
                new SqlParameter("@DOB", student.DOB),
                new SqlParameter("@Email", student.Email),
                new SqlParameter("@Contact", student.Contact),
                new SqlParameter("@EnrollmentYear", student.EnrollmentYear),
                new SqlParameter("@Status", student.Status ?? "Active")
            );

            return RedirectToAction("Index");
        }

        // GET: Student/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = _context.Students
                .FromSqlRaw("SELECT * FROM Students WHERE StudentID = @id", new SqlParameter("@id", id))
                .AsEnumerable()
                .FirstOrDefault();

            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.StudentID) return NotFound();

            if (ModelState.IsValid)
            {
                var sql = "UPDATE Students SET Name = @Name, NIC = @NIC, DOB = @DOB, Email = @Email, " +
                          "Contact = @Contact, EnrollmentYear = @EnrollmentYear, Status = @Status " +
                          "WHERE StudentID = @StudentID";

                _context.Database.ExecuteSqlRaw(sql,
                    new SqlParameter("@Name", student.Name),
                    new SqlParameter("@NIC", student.NIC),
                    new SqlParameter("@DOB", SqlDbType.Date) { Value = student.DOB },
                    new SqlParameter("@Email", student.Email),
                    new SqlParameter("@Contact", student.Contact),
                    new SqlParameter("@EnrollmentYear", student.EnrollmentYear),
                    new SqlParameter("@Status", student.Status ?? "Active"),
                    new SqlParameter("@StudentID", student.StudentID)
                );

                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }


        // GET: Student/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var sql = "UPDATE Students SET Status = 'Inactive' WHERE StudentID = @id";
            _context.Database.ExecuteSqlRaw(sql, new SqlParameter("@id", id));

            return RedirectToAction(nameof(Index));
        }

        // GET: Student/Search
        public IActionResult Search() => View();

        // POST: Student/Search
        [HttpPost]
        public IActionResult Search(string searchText)
        {
            var sql = "SELECT * FROM Students WHERE (Name LIKE @search OR CAST(StudentID AS NVARCHAR) LIKE @search) AND Status = 'Active'";
            var parameter = new SqlParameter("@search", "%" + searchText + "%");

            var results = _context.Students
                .FromSqlRaw(sql, parameter)
                .ToList();

            return View("Index", results);
        }
    }
}
