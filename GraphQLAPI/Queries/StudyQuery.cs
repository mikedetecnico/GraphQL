using GraphQL;
using GraphQL.Types;
using GraphQLProject.Repositories;
using GraphQLProject.Types;

namespace GraphQLProject.Queries
{
    public class StudyQuery : ObjectGraphType
    {
        public StudyQuery(IStudyRepository repository)
        {
            Field<ListGraphType<StudyType>>("Studies").Resolve(context =>
            {
                return repository.GetAll();
            });

            Field<StudyType>("Study").Arguments(new QueryArguments(new QueryArgument<GuidGraphType> { Name = "studyId"})).Resolve(context =>
            {
                Guid studyId = context.GetArgument<Guid>("studyId");
                return repository.GetById(studyId);
            });
        }
    }
}