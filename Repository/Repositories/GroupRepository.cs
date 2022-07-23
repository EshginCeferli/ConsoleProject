using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace Repository.Repositories
{
    public class GroupRepository : IRepository<Group>
    {

        public void Create(Group data)
        {
            try
            {
                if (data is null) throw new Exception("Data not found");
                AppDbContext<Group>.datas.Add(data);                                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Group data)
        {
            try
            {
                if (data is null) throw new Exception("Data doesn't already exit");
                AppDbContext<Group>.datas.Remove(data);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
        }

        public Group Get(Predicate<Group> predicate)
        {
            return predicate != null ? AppDbContext<Group>.datas.Find(predicate) : null;
        }

        public List<Group> GetAll(Predicate<Group> predicate = null)
        {
            return predicate != null ? AppDbContext<Group>.datas.FindAll(predicate) : AppDbContext<Group>.datas;
        }

        public void Update(Group data)
        {
            Group group = Get(m => m.Id == data.Id);
            if (string.IsNullOrEmpty(data.Name.ToString()))
                data.Name = group.Name;

            if (string.IsNullOrEmpty(data.Teacher.ToString()))
                data.Teacher = group.Teacher;

            if (string.IsNullOrEmpty(data.Room.ToString()))
                data.Room = group.Room;
          
        }
    }
}
