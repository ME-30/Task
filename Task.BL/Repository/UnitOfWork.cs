﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BL.Interface;
using Task.DAL.DataBase;
using Task.DAL.Entity;

namespace Task.BL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskContext context;
        public IBaseRepository<Employee> Employees { get; private set; }

        public UnitOfWork(TaskContext context)
        {
            this.context = context;
            Employees = new BaseRepository<Employee>(context);  
        }
      
        public int Complete()
        {
            return context.SaveChanges();
        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
}
