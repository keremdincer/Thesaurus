using Core.Entities;
using Core.Interfaces;
using Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly ThesaurusContext context;
        public readonly DbSet<T> entities;

        public Repository(ThesaurusContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public T Create(T entity)
        {
            entities.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }
    }
}
