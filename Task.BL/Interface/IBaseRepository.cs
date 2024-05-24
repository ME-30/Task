using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.BL.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int Id);
        ValueTask Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }

}
