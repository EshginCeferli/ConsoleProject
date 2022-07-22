using Domain.Models;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace ConsoleProject.Controllers
{
    public class StudentController
    {
        readonly StudentService studentService = new StudentService();

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

        public void GetStudentsByAge()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Please add student age : ");

        CorrectAge: string searchAge = Console.ReadLine();

            int selectedAge;

            bool isSearchAge = int.TryParse(searchAge, out selectedAge);

            if (isSearchAge || selectedAge > 0) 
            {
                List<Student> studentsByAge = studentService.GetStudentsByAge(selectedAge);

                if (studentsByAge.Count != 0)
                {
                    foreach (var item in studentsByAge)
                    {
                        Helper.WriteConsole(ConsoleColor.Green, $" Student Id : {item.Id}, Student name : {item.Name}, Student surname : {item.Surname}, Student's age : {item.Age}, Student's Group : {item.Group.Name}");
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, " Student not found ");
                    goto CorrectAge;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Student age is wrong ");
                goto CorrectAge;
            }
        }

        public void GetStudentsByGroupId()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Please add group Id : ");

        CorrectId: string studentGroupId = Console.ReadLine();

            int selecetedId;

            bool isSearchId = int.TryParse(studentGroupId, out selecetedId);

            if (isSearchId)
            {
                List<Student> studentsByGroupId = studentService.GetStudentsByGroupId(selecetedId);

                if (studentsByGroupId.Count != 0)
                {
                    foreach (var item in studentsByGroupId)
                    {
                        Helper.WriteConsole(ConsoleColor.Green, $" Student Id : {item.Id}, Student name : {item.Name}, Student surname : {item.Surname}, Student's age : {item.Age}, Student's Group : {item.Group.Name}");
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, " Group not found ");
                    goto CorrectId;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, " Id type is wrong ");
                goto CorrectId;
            }
        }
    }
}
