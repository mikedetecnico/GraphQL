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
    }
}