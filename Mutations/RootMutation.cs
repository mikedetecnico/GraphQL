using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQLProject.Models;
using GraphQLProject.Repositories;

namespace GraphQLProject.Mutations
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation(IStudyRepository studyRepository, IPatientRepository patientRepository)
        {
            AddField(new FieldType
            {
                Name = "studyMutation",
                ResolvedType = (IGraphType)new StudyMutation(studyRepository).GetType(),
                Resolver = new FuncFieldResolver<object>(context => new { })
            });

            AddField(new FieldType
            {
                Name = "patientMutation",
                ResolvedType = (IGraphType)new PatientMutation(patientRepository).GetType(),
                Resolver = new FuncFieldResolver<object>(context => new { })
            });
        }
    }
}