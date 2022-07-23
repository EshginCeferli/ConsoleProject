using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;

using Domain.Models;

namespace ConsoleProject.Controllers
{    
    public class GroupController
    {
        GroupService groupService = new GroupService();       


        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Please add Group name : ");

        TeacherNameEmpty: string groupName = Console.ReadLine();

            if (groupName != "")
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Please add Group Teacher");

            CorrectName: string groupTeacher = Console.ReadLine();

                bool isGroupTeacher = Helper.CheckString(groupTeacher);

                if (isGroupTeacher is true && groupTeacher != "") 
                {
                    Helper.WriteConsole(ConsoleColor.Blue, "Please add Group Room");


                    string groupRoom = Console.ReadLine();


                    Group group = new Group()
                    {
                        Name = groupName,
                        Teacher = groupTeacher,
                        Room = groupRoom
                    };

                    var result = groupService.Create(group);
                    Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {result.Id}, Group name : {result.Name}, Group teacher : {result.Teacher}, Group room : {result.Room}");

                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct teacher name");
                    goto CorrectName;

                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, " Add group name ");
                goto TeacherNameEmpty;
            }



        }

        public void GetById()
        {
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
                    Helper.WriteConsole(ConsoleColor.Red, "Group not found, try again - 1, back to top - 2");
                    string again = Console.ReadLine();

                    int againCheck;

                    bool isAgainCheck = int.TryParse(again, out againCheck);

                    if (isAgainCheck)
                    {
                        switch (againCheck)
                        {
                            case 1:
                                goto GroupId;
                        }
                    }
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Id should be number");
                goto GroupId;
            }
        }

        public void Update()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group id : ");

        GroupId: string updateGroupId = Console.ReadLine();

            int groupId;

            bool isGroupId = int.TryParse(updateGroupId, out groupId);

            if (isGroupId)
            {
                var result = groupService.GetById(groupId);

                if (result != null)
                {
                    Helper.WriteConsole(ConsoleColor.Blue, "Add new group name : ");

                    string groupNewName = Console.ReadLine();

                    Helper.WriteConsole(ConsoleColor.Blue, "Add new group teacher : ");

                CorrectTeacher: string groupNewTeacher = Console.ReadLine();

                    //string groupTeacher;

                    bool isGroupTeacher = Helper.CheckString(groupNewTeacher);

                    if (isGroupTeacher || groupNewTeacher == "")
                    {
                        Helper.WriteConsole(ConsoleColor.Blue, "Add new group room : ");

                        string groupNewRoom = Console.ReadLine();

                        Group group = new Group()
                        {
                            Name = groupNewName,
                            Teacher = groupNewTeacher,
                            Room = groupNewRoom
                        };

                        var resultGroup = groupService.Update(groupId, group);

                        if (resultGroup == null)
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Group not found, please try again : ");
                            goto GroupId;
                        }
                        else
                        {
                            Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {resultGroup.Id}, Group name : {resultGroup.Name}, Group teacher : {resultGroup.Teacher}, Group room : {resultGroup.Room}");
                        }
                    }
                    else
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Add correct new teacher name : ");
                        goto CorrectTeacher;

                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, " Group not found, add Id again : ");
                    goto GroupId;
                }
                

            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct group id : ");
                goto GroupId;
            }
        }

        public void Delete()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group id : ");
        GroupId: string groupId = Console.ReadLine();

            int id;

            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId )
            {
                groupService.Delete(id);               

            }

            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Id must be number");
                goto GroupId;
            }
        }

        public void GetAll()
        {
            List<Group> groups = groupService.GetAll();

            foreach (var item in groups)
            {
                Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {item.Id}, Group name : {item.Name}, Group teacher : {item.Teacher}, Group room : {item.Room}");

            }
        }

        //public void Search()
        //{
        //    Helper.WriteConsole(ConsoleColor.Blue, "Add search text");

        //SearchText: string searchText = Console.ReadLine();

        //    List<Group> resultGroups = groupService.Search(searchText);
        //    if (resultGroups.Count != 0)
        //    {
        //        foreach (var item in resultGroups)
        //        {
        //            Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {item.Id}, Group name : {item.Name}, Group teacher : {item.Teacher}, Group room : {item.Room}");
        //        }
        //    }
        //    else
        //    {
        //        Helper.WriteConsole(ConsoleColor.Red, "Group not found ");

        //        goto SearchText;
        //    }
        //}                           

        public void GetGroupsByTeacher()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Please add teacher name");
            CorrectTeacher: string searchTeacher = Console.ReadLine();
            bool isSearchTeacher = Helper.CheckString(searchTeacher);
            if (isSearchTeacher)
            {
                List<Group> groupsByTeacher = groupService.GetGroupsByTeacher(searchTeacher);
                if (groupsByTeacher.Count != 0)
                {
                    foreach (var item in groupsByTeacher)
                    {
                        Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {item.Id}, Group name : {item.Name}, Group teacher : {item.Teacher}, Group room : {item.Room}");
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
                                goto CorrectTeacher;
                        }
                    }
                }             
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Teacher name cant be number");
                goto CorrectTeacher;
            }

        }

        public void GetGroupsByRoom()
        { 
            
            Helper.WriteConsole(ConsoleColor.Blue, "Please add group room");
            GroupRoom: string searchRoom = Console.ReadLine();
            List<Group> groupsByRoom = groupService.GetGroupsByRoom(searchRoom);
            if (groupsByRoom.Count != 0)
            {
                foreach (var item in groupsByRoom)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {item.Id}, Group name : {item.Name}, Group teacher : {item.Teacher}, Group room : {item.Room}");
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
                        case 1 :
                            goto GroupRoom;                            
                    }
                }                              
            }           
        }

        public void SearchForGroupName()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Please add search text");

            SearchText:  string searchGroupName = Console.ReadLine();

            List<Group> groupsByName = groupService.SearchForGroupName(searchGroupName);
            if (groupsByName.Count != 0)
            {
                foreach (var item in groupsByName)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {item.Id}, Group name : {item.Name}, Group teacher : {item.Teacher}, Group room : {item.Room}");
                }
            }
            else
            {
                //Helper.WriteConsole(ConsoleColor.Red, "Group not found ");
                //goto SearchText;

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
    }
}
