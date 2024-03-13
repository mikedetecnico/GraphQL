using GraphQLProject.Models;

namespace GraphQLProject.Repositories
{
    /// <summary>
    /// Interface for a repository that provides CRUD operations for a specific type of entity.
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
    public interface IRepository<T>
        where T : class, IModel
    {
        List<T> GetAll();
        T? GetById(Guid id);
        T Add(T entity);
        T Update(T entity);
        void Delete(Guid id);
    }
}