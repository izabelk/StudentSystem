namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
 
    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Data.Migrations;
   
    class StudentSystemConsoleClient
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());

            var data = new StudentSystemData();

            //var student = new Student
            //{
            //    Name = "Simona Ilieva",
            //    Age = 32,
            //    Number = "0557688745656"
            //};

            //data.Students.Add(student);

            //data.SaveChanges();

            var selectedStudent = data.Students.First();
            Console.WriteLine("First student in the database: ");
            Console.WriteLine("{0}. {1}", selectedStudent.StudentId, selectedStudent.Name);
            Console.WriteLine("------------------------------------------------");

            var student1 = new Student
            {
                Name = "Pesho Peshev",
                Age = 26,
                Number = "8658685856858"
            };
            
            var course1 = new Course
            {
                Name = "High Quality Code",
                Description = "Very important course",
                Materials = new List<string>(){"books", "sites", "videos"},
            };

            student1.Courses.Add(course1);

            var course2 = new Course
            {
                Name = "DSA",
                Description = "Another important course",
                Materials = new List<string>() { "books", "sites", "videos" },
            };

            student1.Courses.Add(course2);

            var homework1 = new Homework
            {
                Content = "C# program",
                TimeSent = new DateTime(2014, 8, 30)
            };

            student1.Homeworks.Add(homework1);

            var homework2 = new Homework
            {
                Content = "Java program",
                TimeSent = new DateTime(2014, 8, 31)
            };

            student1.Homeworks.Add(homework2);

            data.SaveChanges();

            var homeworks = data.Homeworks.All();

            Console.WriteLine("Homeworks: ");
            foreach (var homework in homeworks)
            {
                Console.WriteLine("{0} {1}", homework.Content, homework.TimeSent);
            }
            Console.WriteLine("------------------------------------------------");

            var courses = data.Courses.SearchFor(c => c.Students.Contains(student1));

            Console.WriteLine("Filtered courses: ");
            foreach (var course in courses)
            {
                Console.WriteLine("{0} {1}", course.Name, course.Description);
            }
            Console.WriteLine("------------------------------------------------");
        }
    }
}
