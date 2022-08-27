using GraduationProject.ApplicationLogic.Abstractions;

namespace GraduationProject.DataAccess
{
    public class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        protected readonly ApplicationDbContext dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Add(T entity)
        {
            var ent = dbContext.Add<T>(entity);
            dbContext.SaveChanges();
            return ent.Entity;
        }

        public void Delete(T entity)
        {
            dbContext.Remove<T>(entity);
            dbContext.SaveChanges();
        }

        public T? Get(Guid id) => dbContext.Set<T>().Find(id);

        public IEnumerable<T> GetAll() => dbContext.Set<T>().AsEnumerable();

        public T Update(T entity)
        {
            var ent = dbContext.Update<T>(entity);
            dbContext.SaveChanges();
            return ent.Entity;
        }
    }
}
