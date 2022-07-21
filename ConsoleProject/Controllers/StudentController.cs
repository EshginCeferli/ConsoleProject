using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;

namespace ConsoleProject.Controllers
{
    public class StudentController 
    {
        public void Create()
        {
            StudentService studentService = new StudentService();

            Helper.WriteConsole(ConsoleColor.Blue, "Add group id :");

            GroupId:  string groupId = Console.ReadLine();

            int selectedGroupId;

            bool isSelectedId = int.TryParse(groupId, out selectedGroupId);

            if (isSelectedId)
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add student name : ");

                string studentName = Console.ReadLine();
                
                Helper.WriteConsole(ConsoleColor.Blue, "Add student surname : ");

                string studentSurname = Console.ReadLine();

                Helper.WriteConsole(ConsoleColor.Blue, "Add student age");

                StudentAge: string studentAge = Console.ReadLine();

                int selectedStudentAge;

                bool isSelectedStudentAge = int.TryParse(studentAge, out selectedStudentAge);
                
                if (isSelectedStudentAge)
                {
                    Student student = new Student()
                    {
                        Name = studentName,
                        Surname = studentSurname,
                        Age = selectedStudentAge
                                            
                    };

                    var result =studentService.Create(selectedGroupId, student);

                    if (result != null)
                    {
                        Helper.WriteConsole(ConsoleColor.Green, $"Student Id : {result.Id}, Student name : {result.Name}, Student surname : {result.Surname}, Student age : {result.Age}, Student Group : {result.Group.Name}");

                    }
                    else
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Group not found, please add correct group id ");
                        goto GroupId;
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Student age must be number ");

                    goto StudentAge;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct group id type : ");
                goto GroupId;
            }

        }
    }
}
