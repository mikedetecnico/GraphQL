using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQLProject.Repositories;

namespace GraphQLProject.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(IStudyRepository studyRepository, IPatientRepository patientRepository)
        {
            AddField(new FieldType
            {
                Name = "studyQuery",
                ResolvedType = (IGraphType)new StudyQuery(studyRepository).GetType(),
                Resolver = new FuncFieldResolver<object>(context => new { })
            });

            AddField(new FieldType
            {
                Name = "patientQuery",
                ResolvedType = (IGraphType)new PatientQuery(patientRepository).GetType(),
                Resolver = new FuncFieldResolver<object>(context => new { })
            });
        }
    }
}