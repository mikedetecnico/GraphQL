using GraphQLProject.Models;

namespace GraphQLProject.Repositories
{
    /// <summary>
    /// Interface for the study repository.
    /// </summary>
    public interface IStudyRepository : IRepository<Study>
    {
        /// <summary>
        /// Gets the studies by patient identifier.
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        /// <returns>The list of associated studies.</returns>
        List<Study> GetByPatientId(Guid patientId);
    }
}