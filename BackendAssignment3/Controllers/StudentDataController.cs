﻿using BackendAssignment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace BackendAssignment3.Controllers
{
    public class StudentDataController : ApiController
    {
        //The database context class which allows us to access our MySQL Database.
        private SchoolDbContext School = new SchoolDbContext();

        // This Controller Will access the students table of our schooldb database.
        /// <summary>
        ///<example>GET api/StudentData/ListStudents</example>
        ///<returns>
        ///A list of Students in the database (id, student first name, student last name, student number).
        ///</returns>
        ///                             
        [HttpGet]

        public IEnumerable<Student> ListStudents()
        {
            // Create a connection
            MySqlConnection Conn = School.AccessDatabase();

            // Open the connection between the web server and database
            Conn.Open();

            // Establish a new command for our database
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL Query
            cmd.CommandText = "SELECT * from students";

            // Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // Create an empty list of Students
            List<Student> Students = new List<Student> { };

            // Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                string StudentId = ResultSet["studentid"].ToString();
                string StudentFname = ResultSet["studentfname"].ToString(); 
                string StudentLname = ResultSet["studentlname"].ToString();
                string StudentNumber = ResultSet["studentnumber"].ToString();
                string EnrollDate = ResultSet["enroldate"].ToString();

                // Create a new Student Object
                Student NewStudent = new Student();
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrollDate = EnrollDate;

                // Add the Student Name to the List
                Students.Add(NewStudent);
            }

            // Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            // Return the final list of students
            return Students;
        }

        [HttpGet]

        public Student FindStudent(int id)
        {
            Student NewStudent = new Student();

            // Create a connection
            MySqlConnection Conn = School.AccessDatabase();

            // Open the connection between the web server and database
            Conn.Open();

            // Establish a new command for our database
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL Query
            cmd.CommandText = "SELECT * from students where studentid = " + id;

            // Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                string StudentId = ResultSet["studentid"].ToString();
                string StudentFname = ResultSet["studentfname"].ToString();
                string StudentLname = ResultSet["studentlname"].ToString();
                string StudentNumber = ResultSet["studentnumber"].ToString();
                string EnrollDate = ResultSet["enroldate"].ToString();

                // Create a new Student Object
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrollDate = EnrollDate;
            }

            return NewStudent;
        }
    }
}
