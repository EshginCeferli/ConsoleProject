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
        readonly GroupService groupService = new GroupService();

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
                    Helper.WriteConsole(ConsoleColor.Red, " Name or Surname contains digit or empty ");
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
                    Helper.WriteConsole(ConsoleColor.Red, " Student not found, try again - 1, back to top - 2");
                    string again = Console.ReadLine();

                    int againCheck;

                    bool isAgainCheck = int.TryParse(again, out againCheck);

                    if (isAgainCheck)
                    {
                        switch (againCheck)
                        {
                            case 1:
                                goto StudentId;
                        }
                    }
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
                    Helper.WriteConsole(ConsoleColor.Red, "Group not found, try again - 1, back to top - 2");
                    string again = Console.ReadLine();

                    int againCheck;

                    bool isAgainCheck = int.TryParse(again, out againCheck);

                    if (isAgainCheck)
                    {
                        switch (againCheck)
                        {
                            case 1:
                                goto CorrectAge;
                        }
                    }
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
                    Helper.WriteConsole(ConsoleColor.Red, "Group not found, try again - 1, back to top - 2");
                    string again = Console.ReadLine();

                    int againCheck;

                    bool isAgainCheck = int.TryParse(again, out againCheck);

                    if (isAgainCheck)
                    {
                        switch (againCheck)
                        {
                            case 1:
                                goto CorrectId;
                        }
                    }
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, " Id type is wrong ");
                goto CorrectId;
            }
        }

        public void SeachStudentsByName()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Please add search text");

        SearchText: string searchStudentName = Console.ReadLine();

            List<Student> studentsByName = studentService.SearchStudentsByName(searchStudentName);
            if (studentsByName.Count != 0)
            {
                foreach (var item in studentsByName)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Student Id : {item.Id}, Student name : {item.Name}, Student surname : {item.Surname}, Student age : {item.Age}, Student group : {item.Group.Name}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group not found, try again - 1, back to top - 2");
                string again = Console.ReadLine();

                int againCheck;

                bool isAgainCheck = int.TryParse(again, out againCheck);

                if (isAgainCheck)
                {
                    switch (againCheck)
                    {
                        case 1:
                            goto SearchText;
                    }
                }
            }
        }

        public void UpdateStudent()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add student id : ");

        StudentId: string updateStudentId = Console.ReadLine();

            int studentId;

            bool isStudentId = int.TryParse(updateStudentId, out studentId);

            if (isStudentId)
            {
                var result = studentService.GetStudentById(studentId);

                if (result != null)
                {
                    Helper.WriteConsole(ConsoleColor.Blue, "Add new student name : ");

                    StudentName:  string studentName = Console.ReadLine();

                    bool isStudentName = Helper.CheckString(studentName);

                    if (isStudentName || studentName == "")
                    {
                        Helper.WriteConsole(ConsoleColor.Blue, "Add new student surname : ");

                        StudentSurname: string studentSurname = Console.ReadLine();

                        bool isStudentSurname = Helper.CheckString(studentSurname);

                        if (isStudentSurname || studentSurname == "")
                        {
                            Helper.WriteConsole(ConsoleColor.Blue, "Add new student age : ");

                        StudentAge: string studentAge = Console.ReadLine();

                            int selectedAge;

                            bool isStudentAge = int.TryParse(studentAge, out selectedAge);

                            if (isStudentAge || studentAge == "")
                            {
                                Helper.WriteConsole(ConsoleColor.Blue, "Add new student group Id : ");

                                StGroupId: string newStGroupId = Console.ReadLine();

                                int selectedGroupId;

                                bool isSelectedId = int.TryParse(newStGroupId, out selectedGroupId);

                                if (isSelectedId || newStGroupId == "") 
                                {                                    
                                    var resultGroup = groupService.GetById(selectedGroupId);
                                    if (resultGroup is null)
                                    {
                                        Console.WriteLine(" Olmadi");
                                    }

                                    Student student = new Student()
                                    {
                                        Name = studentName,
                                        Surname = studentSurname,
                                        Age = selectedAge,
                                        Group = resultGroup
                                    };

                                    var resultUpdate = studentService.UpdateStudent(studentId, student);

                                    if (resultUpdate == null)
                                    {
                                        Helper.WriteConsole(ConsoleColor.Red, " Student not found, add id again : ");
                                        goto StudentId;
                                    }
                                    else
                                    {
                                        Helper.WriteConsole(ConsoleColor.Green, $"Student Id : {resultUpdate.Id}, Student name : {resultUpdate.Name}, Student surname : {resultUpdate.Surname}, Student age : {resultUpdate.Age}, Student Grup : { resultUpdate.Group.Name}");

                                    }

                                }
                                else
                                {
                                    Helper.WriteConsole(ConsoleColor.Red, "Duz yaz da ay merdimazar elim qirildi : ");
                                    goto StGroupId;
                                }

                               //var result = groupService.GetById(newStGroupId)

                               

                            }
                            else
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Add correct new age : ");
                                goto StudentAge;
                            }
                        }
                        else
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Add correct new surname : ");
                            goto StudentSurname;
                        }

                    }
                    else
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Add correct new name : ");
                        goto StudentName;
                    }


                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, " Student not found, add if again : ");
                    goto StudentId;
                }

            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, " Add correct id type : ");
                goto StudentId;
            }
        }
    }
}
