using Domain.Models;
using Repository.Repositories;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private StudentRepository _studentrepository;
        private GroupRepository _groupRepository;
        private int _count;

        public StudentService()
        {
            _studentrepository = new StudentRepository();
            _groupRepository = new GroupRepository();

        }

        public Student Create(int groupId, Student student)
        {
            var group = _groupRepository.Get(m => m.Id == groupId);
            if (group is null) return null;
            student.Id = _count;
            student.Group = group;
            _studentrepository.Create(student);
            _count++;
            return student;
        }
    }
}
