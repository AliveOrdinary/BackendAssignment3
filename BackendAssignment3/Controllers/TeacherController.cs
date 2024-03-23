using BackendAssignment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackendAssignment3.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        // GET: Teacher/List

        /// <summary>
        /// This controller will list all the teachers in the database
        /// <example>GET: /Teachers/List</example>
        /// </summary>
        /// <returns>
        /// returns a list of teachers
        /// </returns>
        public ActionResult List()
        {
            // Instantiate the data controller
            TeacherDataController controller = new TeacherDataController();

            // Get the list of teachers
            IEnumerable<Teacher> Teachers = controller.ListTeachers();

            return View(Teachers);
        }

        

        // GET: Teacher/Show/{id}

        /// <summary>
        /// This controller will show the details of a teacher based on the id
        /// <example>GET: /Teacher/Show/1</example>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult Show(int id)
        {
            // Instantiate the data controller
            TeacherDataController controller = new TeacherDataController();


            // Get the teacher based on the id
            Teacher SelectedTeacher = controller.FindTeacher(id);

            // Get the classes taught by the teacher
           IEnumerable<Class> TeacherClasses = controller.FindClassesForTeacher(id);

            TeacherClassModel ViewModel = new TeacherClassModel
            {
                Teacher = SelectedTeacher,
                Classes = TeacherClasses
            };



            return View(ViewModel);
        }
    }
}