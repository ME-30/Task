using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BL.Interface;
using Task.DAL.DataBase;

namespace Task.BL.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly TaskContext conext;

        public BaseRepository(TaskContext conext)
        {
            this.conext = conext;
        }
        public IEnumerable<T> GetAll()
        {
            return  conext.Set<T>().ToList();
        }
        public async ValueTask Add(T entity)
        {
             await conext.AddAsync(entity);
        }
        public void Update(T entity)
        {
            conext.Update(entity);
        }
        public void Delete(T entity)
        {
            conext.Remove(entity);
        }

        public async Task<T> GetById(int Id)
        {
            return await conext.Set<T>().FindAsync(Id);
        }
    }
}
