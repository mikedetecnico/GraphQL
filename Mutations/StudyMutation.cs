using GraphQL;
using GraphQL.Types;
using GraphQLProject.Models;
using GraphQLProject.Repositories;
using GraphQLProject.Types;

namespace GraphQLProject.Mutations
{
    public class StudyMutation : ObjectGraphType
    {
        public StudyMutation(IRepository<Study> repository)
        {
            Field<StudyType>("CreateStudy").Arguments(new QueryArguments(new QueryArgument<StudyInputType> { Name = "study"} )).Resolve(context => {
                Study study = context.GetArgument<Study>("study");
                return repository.Add(study);
            });

            Field<StudyType>("UpdateStudy").Arguments(new QueryArguments(new QueryArgument<StudyInputType> { Name = "study"} )).Resolve(context => {
                Study study = context.GetArgument<Study>("study");
                return repository.Update(study);
            });

            Field<StringGraphType>("DeleteStudy").Arguments(new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id"} )).Resolve(context => {
                Guid id = context.GetArgument<Guid>("id");
                repository.Delete(id);
                return "The study has been deleted";
            });
        }
    }
}