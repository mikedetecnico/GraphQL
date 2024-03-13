using GraphQLProject.Data;
using GraphQLProject.Models;

namespace GraphQLProject.Repositories
{
    /// <summary>
    /// The concrete repository that provides CRUD operations for a specific type of entity.
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
    public class Repository<T> : IRepository<T>
        where T : class, IModel
    {
        /// <summary>
        /// The database context.
        /// </summary>
        protected readonly GraphQLDbContext _dbContext;

        /// <summary>
        /// Constructor for the repository.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        public Repository(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The entity that was added.</returns>
        /// <exception cref="ArgumentNullException">Throws exception if entity is null.</exception>
        /// <exception cref="Exception">Throws exception if entity already exists.</exception>
        public T Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            T existingEntity = _dbContext.Find<T>(entity.GetId());

            if (existingEntity != null)
            {
                throw new Exception("Entity already exists");
            }

            _dbContext.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <exception cref="Exception">Throws an exception if entity does not exist.</exception>
        public void Delete(Guid id)
        {
            T entity = _dbContext.Find<T>(id) ?? throw new Exception("Entity not found");

            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Gets all entities from the database.
        /// </summary>
        /// <returns>The list of entities that are found.</returns>
        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        /// <summary>
        /// Gets an entity by its ID.
        /// </summary>
        /// <param name="id">The entity ID.</param>
        /// <returns>The found entity or null if not found.</returns>
        public T? GetById(Guid id)
        {
            return _dbContext.Find<T>(id);
        }

        /// <summary>
        /// Updates an entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        /// <exception cref="ArgumentNullException">Throws argument exception if entity is null.</exception>
        /// <exception cref="Exception">Throws exception if entity is not found.</exception>
        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            T existingEntity = _dbContext.Find<T>(entity.GetId()) ?? throw new Exception("Entity not found");

            // update all public fields
            typeof(T).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .ToList()
                .ForEach(field => field.SetValue(existingEntity, field.GetValue(entity)));

            _dbContext.SaveChanges();

            return existingEntity;
        }
    }
}