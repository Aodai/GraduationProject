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
