using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Interfaces
{
    public interface IRepository
    {
        IQueryable<T> GetAll<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task SaveChangesAsync();
    }
}
