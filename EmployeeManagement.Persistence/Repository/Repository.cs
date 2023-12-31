﻿#nullable disable
using EmployeeManagement.Persistence.IRepository;
using EmployeeManagement.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbEmployeeManagementContext _context;

        private readonly DbSet<T> _entity;

        public Repository(DbEmployeeManagementContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.AsEnumerable();
        }

        public T GetById(int id)
        {
            return _entity.Find(id);
        }

        public void Add(T entity)
        {
            _entity.Add(entity);
        }
        public void Update(T entity)
        {
            //can use EntityState.Modified (or) _entity.Update(entity);

            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _entity.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

     
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


}
