using GraphQLProject.Data;
using GraphQLProject.Models;

namespace GraphQLProject.Repositories
{
    public class StudyRepository : Repository<Study>, IStudyRepository
    {
        public StudyRepository(GraphQLDbContext dbContext)
            : base(dbContext)
        {
        }

        /// <summary>
        /// Gets all studies for a patient.
        /// </summary>
        /// <param name="patientId">The patient ID.</param>
        /// <returns>The list of associated studies.</returns>
        public List<Study> GetByPatientId(Guid patientId)
        {
            return _dbContext.Studies.Where(s => s.PatientId == patientId).ToList();
        }
    }
}