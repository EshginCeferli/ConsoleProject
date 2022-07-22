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
        // Options of Group

        CreateGroup = 1,
        GetGroupById = 2,
        UpdateGroup = 3,
        DeleteGroup = 4,
        GetAllGroups = 5,
        SearchGroup   = 6,        
        GetGroupsByTeacher = 7,
        GetGroupsByRoom = 8,
        SearchForGroupName = 9,
        
        // Options of Student

        CreateStudent = 10,
        GetStudentById = 11,
        DeleteStudent = 12,
        GetStudentByAge = 13,
        GetStudentsByGroupId =14

    }
}
