using Domain.Models;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;
using System;

namespace ConsoleProject.Controllers
{
    public class StudentController 
    {
        StudentService studentService = new StudentService();

        public void Create()
        {
            StudentService studentService = new StudentService();

            Helper.WriteConsole(ConsoleColor.Blue, " Add group id ");

            GroupId: string groupId = Console.ReadLine();

            int selectedGroupId;

            bool isGroupId = int.TryParse(groupId, out selectedGroupId);

            if (isGroupId)
            {
                Helper.WriteConsole(ConsoleColor.Blue, " Add student name ");

                NameSurname: string studentName = Console.ReadLine();

                Helper.WriteConsole(ConsoleColor.Blue, " Add student surnname ");

                string studentSurname = Console.ReadLine();

                bool isStudentName = Helper.CheckString(studentName);

                bool isStudentSurname = Helper.CheckString(studentSurname);

                if (isStudentName && isStudentSurname)
                {
                    Helper.WriteConsole(ConsoleColor.Blue, " Add student age");

                    StudentAge: string studentAge = Console.ReadLine();

                    int selectedAge;

                    bool isStudentAge = int.TryParse(studentAge, out selectedAge);

                    if (isStudentAge is true && selectedAge >= 0)
                    {
                        Student student = new Student()
                        {
                            Name = studentName,
                            Surname = studentSurname,
                            Age = selectedAge                        
                        };

                        var result = studentService.Create(selectedGroupId, student);
                        
                        if (result != null)
                        {
                            Helper.WriteConsole(ConsoleColor.Green, $" Student Id : {result.Id}, Student name : {result.Name}, Student surname : {result.Surname}, Student age : {result.Age}, Student's group : {result.Group.Name}");

                        }
                        else
                        {
                            Helper.WriteConsole(ConsoleColor.Red, " Group not found, please add correct group id ");
                            goto GroupId;

                        }

                    }
                    else
                    {
                        Helper.WriteConsole(ConsoleColor.Red, " Student age is wrong ");
                        goto StudentAge;
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, " Name or Surname contains digit ");
                    goto NameSurname;
                }



            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct id type");
                goto GroupId;
            }

        }     

        public void GetById()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add student Id");

        StudentId: string studentId = Console.ReadLine();

            int id;

            bool isId = int.TryParse(studentId, out id);

            if (isId)
            {
                Student student = studentService.GetStudentById(id);

                if (student != null)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $" Student Id : {student.Id}, Student name : {student.Name}, Student surname : {student.Surname}, Student age : {student.Age}, Student's group : {student.Group.Name}");

                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Student not found");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Id should be number");
                goto StudentId;
            }
        }

        public void DeleteStudent()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add student id : ");
            StudentId: string studentId = Console.ReadLine();
            int id;
            bool isStudentId = int.TryParse(studentId, out id);

            if (isStudentId)
            {
                studentService.DeleteStudent(id);
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Id must be number");
                goto StudentId;
            }
        }
    }
}
