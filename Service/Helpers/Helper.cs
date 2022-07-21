using System;
using System.Text.RegularExpressions;

namespace Service.Helpers
{
    public static class Helper
    {
        public static void WriteConsole(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();


            
        }
        public static bool CheckString(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z]+$");
        }
    }
    public enum Menues
    {
        CreateGroup = 1,
        GetGroupById = 2,
        UpdateGroup = 3,
        DeleteGroup = 4,
        GetAllGroups = 5,
        SearchGroup   = 6,
        CreateStudent = 7,
        GetGroupsByTeacher = 8,
        GetGroupsByRoom = 9,
        SearchForGroupName = 10


    }
}
