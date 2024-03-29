﻿using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Exceptions;
using System.Collections.Generic;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }
        private int _count = 1;
        public Group Create(Group group)
        {

            group.Id = _count;

            _groupRepository.Create(group);
            _count++;

            return group;
        }

        public bool Delete(int id)
        {
            Group group = GetById(id);           
            if (group != null)
            {
                _groupRepository.Delete(group);
                return true;
            }
            else
            {
                return false;
            }               
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
            Group dbGroup = GetById(id);
            if (dbGroup is null) return null;
            group.Id = dbGroup.Id;
            _groupRepository.Update(group);
            return group;           
        }        

        public List<Group> GetGroupsByTeacher(string teacher)
        {
            var resultTeacher = _groupRepository.GetAll(m => m.Teacher == teacher);
            return resultTeacher;
        }

        public List<Group> GetGroupsByRoom(string room)
        {
            var resultRoom = _groupRepository.GetAll(m => m.Room == room);
            return resultRoom;
        }

        public List<Group> SearchForGroupName(string text)
        {
            var searchGroupName = _groupRepository.GetAll(m => m.Name.Trim().ToLower().Contains(text.ToLower().Trim()));
            return searchGroupName;
        }        
    }
}
