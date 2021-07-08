using BankingRESTApi.Models;
using BankingRESTApi.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingRESTApi.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : EntidadeBase
    {
        protected MySQLContext _context;

        private DbSet<T> _dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return _dataset.AsNoTracking().ToList();
        }

        public T FindByID(long id)
        {
            return _dataset.AsNoTracking().FirstOrDefault(p => p.Id.Equals(id));
        }

        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Update(T item)
        {
            var result = _dataset.AsNoTracking().FirstOrDefault(p => p.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            var result = _dataset.AsNoTracking().FirstOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _dataset.AsNoTracking().Any(p => p.Id.Equals(id));
        }
    }
}