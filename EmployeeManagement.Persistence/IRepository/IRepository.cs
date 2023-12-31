﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.IRepository
{
    public interface IRepository<T> : IDisposable
    {
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
       //added
        void Save();

    }
}
