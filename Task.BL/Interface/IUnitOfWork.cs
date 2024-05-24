using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Entity;

namespace Task.BL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Employee> Employees { get; }
        int Complete();
    }
}
