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

                        case (int)Menues.CreateStudent: // 7

                            studentController.Create();
                            break;

                        case (int)Menues.GetGroupsByTeacher: // 8

                            groupController.GetGroupsByTeacher();
                            break;

                        case (int)Menues.GetGroupsByRoom: // 9

                            groupController.GetGroupsByRoom();
                            break;

                        case (int)Menues.SearchForGroupName: // 10

                            groupController.SearchForGroupName();
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
            Helper.WriteConsole(ConsoleColor.Yellow, "1 - Create Group, 2 - Get Group by Id, 3 - Update Group, 4 - Delete Group, 5 - Get all groups, 6 - Search group by text, 7 - Create Student, 8 - Get groups by teacher name, 9 - Get groups by room, 10 - Search for group name");
        }
    }
}
