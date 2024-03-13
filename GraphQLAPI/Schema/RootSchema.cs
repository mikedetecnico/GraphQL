using GraphQLProject.Mutations;
using GraphQLProject.Queries;

namespace GraphQLProject.Schema
{
    public class RootSchema : GraphQL.Types.Schema
    {
        public RootSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = (RootQuery)provider.GetService(typeof(RootQuery)) ?? throw new InvalidOperationException();
            Mutation = (RootMutation)provider.GetService(typeof(RootMutation)) ?? throw new InvalidOperationException();
        }
    }
}