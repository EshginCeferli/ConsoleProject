using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data is null) throw new Exception("Data not found");
                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Student data)
        {
            try
            {
                if (data is null) throw new Exception("Data doesn't already exit");
                AppDbContext<Student>.datas.Remove(data);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
        }

        public Student Get(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.Find(predicate) : null;
        }

        public List<Student> GetAll(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate): null;
        }

        public void Update(Student data)
        {
            throw new NotImplementedException();
        }
    }
}
