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

        public static void WriteConsoleColumn(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public static bool CheckString(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z]+$");
        }
    }
    public enum Menues
    {
        GoBack = 0,
        // Options of Group

        CreateGroup = 1,
        GetGroupById = 2,
        UpdateGroup = 3,
        DeleteGroup = 4,
        GetAllGroups = 5,
                
        GetGroupsByTeacher = 6,
        GetGroupsByRoom = 7,
        SearchForGroupName = 8,
        
        // Options of Student

        CreateStudent = 9,
        GetStudentById = 10,
        DeleteStudent = 11,
        GetStudentByAge = 12,
        GetStudentsByGroupId = 13,
        SearchStudentByName = 14

    }
}
