using Domain.Models;
using Repository.Repositories;
using Service.Services.Interfaces;
using System.Collections.Generic;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private StudentRepository _studentRepository;
        private GroupRepository _groupRepository;
        private int _count = 1;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
        }
        public Student Create(int groupId, Student student)
        {
            var group = _groupRepository.Get(m => m.Id == groupId);
            if (group is null) return null;
            student.Group = group;
            student.Id = _count;
            _studentRepository.Create(student);
            _count++;
            return student;

        }

        public void DeleteStudent(int id)
        {
            Student student = GetStudentById(id);
            _studentRepository.Delete(student);
        }

        public Student GetStudentById(int id)
        {
            var student = _studentRepository.Get(m => m.Id == id);
            if (student == null) return null;
            return student;
        }

        public List<Student> GetStudentsByAge(int age)
        {
            var student = _studentRepository.GetAll(m => m.Age == age);
            if (student == null) return null;
            return student;            
        }

        public List<Student> GetStudentsByGroupId(int id)
        {
            var student = _studentRepository.GetAll(m => m.Group.Id == id);
            if (student == null) return null;
            return student;
        }

        public List<Student> SearchStudentsByName(string name)
        {
            return _studentRepository.GetAll(m => m.Name.Trim().ToLower().Contains(name.Trim().ToLower()));
        }

        public Student UpdateStudent(int id, Student student)
        {
            Student dbStudent = GetStudentById(id);
            if (dbStudent == null) return null;
            student.Id = dbStudent.Id;
            _studentRepository.Update(student);
            return student;          
        }
    }
}
