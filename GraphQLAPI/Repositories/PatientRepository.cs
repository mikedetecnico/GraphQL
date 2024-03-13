using GraphQLProject.Data;
using GraphQLProject.Models;

namespace GraphQLProject.Repositories
{
    /// <summary>
    /// Patient repository.
    /// </summary>
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(GraphQLDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}