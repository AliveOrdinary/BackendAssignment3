using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackendAssignment3.Models;

namespace BackendAssignment3.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student/List

        /// <summary>
        /// This controller will list all the students in the database
        /// <example>GET: /Student/List</example>
        /// </summary>
        /// <returns>
        /// returns a list of students
        /// </returns>
        public ActionResult List()
        {
            // Instantiate the data controller
            StudentDataController controller = new StudentDataController();

            // Get the list of students
            IEnumerable<Student> Students = controller.ListStudents();

            return View(Students);
        }

        // GET: Student/Show/{id}

        /// <summary>
        /// This controller will show the details of a student based on the id
        /// <example>GET: /Student/Show/1</example>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// returns details of a student
        /// </returns>

        public ActionResult Show(int id)
        {
            StudentDataController controller = new StudentDataController();
            Student SelectedStudent = controller.FindStudent(id);

            return View(SelectedStudent);
        }
    }
}