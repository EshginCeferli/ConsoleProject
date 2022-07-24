using Domain.Models;
using System.Collections.Generic;

namespace Service.Services
{
    public interface IGroupService
    {
          Group Create(Group group);

        Group Update(int id, Group group);

        bool Delete(int id);

        Group GetById(int id);

        List<Group> GetAll();

        //List<Group> Search(string search);

        List<Group> GetGroupsByTeacher(string teacher);

        List<Group> GetGroupsByRoom(string room);

        List<Group> SearchForGroupName(string text);

        

    }
}
