using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        Student Create(int groupId, Student student);

        Student GetStudentById(int id);

        bool DeleteStudent(int id);

        List<Student> GetStudentsByAge(int age);

        List<Student> GetStudentsByGroupId(int id);

        List<Student> SearchStudentsByName(string name);

        Student UpdateStudent(int id, Student student);
       
    }
}
