using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProject.ApplicationLogic.Abstractions
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? Get(Guid id);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
