using ConsoleProject.Controllers;
using Service.Helpers;
using System;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentController studentController = new StudentController();
            GroupController groupController = new GroupController();

            Helper.WriteConsole(ConsoleColor.Blue, "Select one option : ");
            GetMenues();

            while (true)
            {
                SelectOption: string selectOption = Console.ReadLine();

                int selectTrueOption;

                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);

                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {                        

                        case (int) Menues.CreateGroup: //1

                            groupController.Create();
                            break;

                        case (int)Menues.GetGroupById: //2

                            groupController.GetById();
                            break;

                        case (int)Menues.UpdateGroup: //3

                            groupController.Update();
                            break;

                        case (int)Menues.DeleteGroup: //4

                            groupController.Delete(); 
                            break;

                        case (int)Menues.GetAllGroups:  //5

                            groupController.GetAll();
                            break;
                                             

                        case (int)Menues.GetGroupsByTeacher: // 6

                            groupController.GetGroupsByTeacher();
                            break;

                        case (int)Menues.GetGroupsByRoom: // 7

                            groupController.GetGroupsByRoom();
                            break;

                        case (int)Menues.SearchForGroupName: // 8

                            groupController.SearchForGroupName();
                            break;

                        case (int)Menues.CreateStudent: // 9

                            studentController.Create();
                            break;

                        case (int)Menues.GetStudentById: // 10

                            studentController.GetById();
                            break;

                        case (int)Menues.DeleteStudent: // 11

                            studentController.DeleteStudent();
                            break;

                        case (int)Menues.GetStudentByAge: // 12

                            studentController.GetStudentsByAge();
                            break;

                        case (int)Menues.GetStudentsByGroupId: // 13

                            studentController.GetStudentsByGroupId();
                            break;

                        case (int)Menues.SearchStudentByName: // 14

                            studentController.SeachStudentsByName();
                            break;

                        default:

                            Helper.WriteConsole(ConsoleColor.Red, "Select existing option : ");
                            break;
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Select correct option : ");
                    goto SelectOption;
                }
            }
        }
        private static void GetMenues()
        {            
            Helper.WriteConsole(ConsoleColor.Yellow, " Create Group - 1, Get Group By Id - 2, Update Group - 3, Delete Group - 4, Get All Groups - 5, Get Groups By Teacher - 6,  GetGroupsByRoom - 7, Search For Group Name - 8, Create Student - 9, Get Student ById - 10, Delete Student - 11, Get students by age - 12, Get students by Group Id - 13, Search student by Name - 14");
           
        }
    }
   
}  
