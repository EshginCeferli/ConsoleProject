using Domain.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }
        private int _count;
        public Group Create(Group group)
        {
            group.Id = _count;

            _groupRepository.Create(group);
            _count++;

            return group;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public Group GetById(int id)
        {
            var group = _groupRepository.Get(m => m.Id == id);
            if (group == null) return null;
            return group;
        }

        

        public Group Update(int id, Group group)
        {
            throw new NotImplementedException();
        }

        public List<Group> Search(string search)
        {
            return _groupRepository.GetAll(m => m.Name.ToLower().Trim().StartsWith(search.ToLower().Trim()));
            
        }
    }
}
