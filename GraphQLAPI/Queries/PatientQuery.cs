using GraphQL;
using GraphQL.Types;
using GraphQLProject.Repositories;
using GraphQLProject.Types;

namespace GraphQLProject.Queries
{
    public class PatientQuery : ObjectGraphType
    {
        public PatientQuery(IPatientRepository repository)
        {
            Field<ListGraphType<PatientType>>("Patients").Resolve(context =>
            {
                return repository.GetAll();
            });

            Field<PatientType>("Patient").Arguments(new QueryArguments(new QueryArgument<GuidGraphType> { Name = "patientId"})).Resolve(context =>
            {
                Guid patientId = context.GetArgument<Guid>("patientId");
                return repository.GetById(patientId);
            });
        }
    }
}