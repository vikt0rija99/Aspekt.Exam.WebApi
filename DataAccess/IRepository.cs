namespace Aspekt.Exam.WebApi.DataAccess
{
    public interface IRepository<T>
    {
        int Create(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll();
    }
}
