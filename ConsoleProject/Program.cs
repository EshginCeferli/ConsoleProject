using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            GroupService groupService = new GroupService();

            Helper.WriteConsole(ConsoleColor.Blue, "Select one option : ");
            Helper.WriteConsole(ConsoleColor.Yellow,"1 - Create Group, 2 - Get Group by Id, 3 - Update Group, 4 - Delete Group, 5 - Get all groups, 6 - Search group by text");

            while (true)
            {
                SelectOption: string selectOption = Console.ReadLine();

                int selectTrueOption;

                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);

                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {
                        case 1: //Create Group

                            Helper.WriteConsole(ConsoleColor.Blue, "Please add Group name : ");

                            string groupName = Console.ReadLine();

                            Helper.WriteConsole(ConsoleColor.Blue, "Please add Group Teacher");

                            string groupTeacher = Console.ReadLine();

                            Helper.WriteConsole(ConsoleColor.Blue, "Please add Group Room");

                            RoomNumber: string groupRoom = Console.ReadLine();

                            int room;

                            bool isGroupRoom = int.TryParse(groupRoom, out room);

                            if (isGroupRoom)
                            {
                                Group group = new Group()
                                {
                                    Name = groupName,
                                    Teacher = groupTeacher,
                                    Room = room
                                };

                                var result = groupService.Create(group);
                                Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {result.Id}, Group name : {result.Name}, Group teacher : {result.Teacher}, Group room : {result.Room}");

                            }
                            else
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Rooms are called by number");
                                goto RoomNumber;
                            }

                            break;

                        case 2: //Get group by id

                            Helper.WriteConsole(ConsoleColor.Blue, "Add group Id");

                            GroupId: string groupId = Console.ReadLine();

                            int id;

                            bool isId = int.TryParse(groupId, out id);

                            if (isId)
                            {
                                Group group = groupService.GetById(id);

                                if (group != null)
                                {
                                    Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {group.Id}, Group name : {group.Name}, Group teacher : {group.Teacher}, Group room : {group.Room}");

                                }
                                else
                                {
                                    Helper.WriteConsole(ConsoleColor.Red, "Group not found");
                                }
                            }
                            else
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Id should be number");
                                goto GroupId;
                            }

                            break;

                        case 3:

                            Console.WriteLine(selectTrueOption);
                            break;

                        case 4:

                            Console.WriteLine(selectTrueOption);
                            break;

                        case 5:  //Get all groups

                            List<Group> groups = groupService.GetAll();

                            foreach (var item in groups)
                            {
                                Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {item.Id}, Group name : {item.Name}, Group teacher : {item.Teacher}, Group room : {item.Room}");

                            }

                            break;

                        case 6: //Search by text

                            Helper.WriteConsole(ConsoleColor.Blue, "Add search text");

                        SearchText: string searchText = Console.ReadLine();

                            List<Group> resultGroups = groupService.Search(searchText);
                            if(resultGroups != null)
                            {
                                foreach (var item in resultGroups)
                                {
                                    Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {item.Id}, Group name : {item.Name}, Group teacher : {item.Teacher}, Group room : {item.Room}");

                                }
                            }
                            else
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Library not found ");

                                goto SearchText;
                            }
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
    }
}
