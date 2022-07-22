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

                        case (int)Menues.SearchGroup: //6

                            groupController.Search();
                            break;                       

                        case (int)Menues.GetGroupsByTeacher: // 7

                            groupController.GetGroupsByTeacher();
                            break;

                        case (int)Menues.GetGroupsByRoom: // 8

                            groupController.GetGroupsByRoom();
                            break;

                        case (int)Menues.SearchForGroupName: // 9

                            groupController.SearchForGroupName();
                            break;

                        case (int)Menues.CreateStudent: // 10

                            studentController.Create();
                            break;

                        case (int)Menues.GetStudentById: // 11

                            studentController.GetById();
                            break;

                        case (int)Menues.DeleteStudent: // 12

                            studentController.DeleteStudent();
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
            Helper.WriteConsole(ConsoleColor.Yellow, " Create Group - 1, Get Group By Id - 2, Delete Group - 4, Get All Groups - 5, SearchGroup - 6, Get Groups By Teacher - 7,  GetGroupsByRoom - 8, Search For Group Name = 9, Create Student - 10, Get Student ById - 11, Delete Student - 12");
 
        }
    }
   
}  
