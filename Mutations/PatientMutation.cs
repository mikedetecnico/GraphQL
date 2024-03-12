using GraphQL;
using GraphQL.Types;
using GraphQLProject.Models;
using GraphQLProject.Repositories;
using GraphQLProject.Types;

namespace GraphQLProject.Mutations
{
    public class PatientMutation : ObjectGraphType
    {
        public PatientMutation(IPatientRepository repository)
        {
            Field<PatientType>("CreatePatient").Arguments(new QueryArguments(new QueryArgument<StudyInputType> { Name = "patient"} )).Resolve(context => {
                Patient patient = context.GetArgument<Patient>("patient");
                return repository.Add(patient);
            });

            Field<StudyType>("UpdatePatient").Arguments(new QueryArguments(new QueryArgument<StudyInputType> { Name = "patient"} )).Resolve(context => {
                Patient patient = context.GetArgument<Patient>("patient");
                return repository.Update(patient);
            });

            Field<StringGraphType>("DeletePatient").Arguments(new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id"} )).Resolve(context => {
                Guid id = context.GetArgument<Guid>("id");
                repository.Delete(id);
                return "The patient has been deleted";
            });
        }
    }
}