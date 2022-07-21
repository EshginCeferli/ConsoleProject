using Domain.Models;
using System.Collections.Generic;

namespace Service.Services
{
    public interface IGroupService
    {
        //Group Create(Group group);
        Group Update(int id, Group group);
        void Delete(int id);
        Group GetById(int id);
        List<Group> GetAll();
        List<Group> Search(string search);
    }
}
