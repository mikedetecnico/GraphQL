using GraphQL.Types;

namespace GraphQLProject.Mutations
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Field<PatientMutation>("patientMutation").Resolve(context => new { });
            Field<StudyMutation>("studyMutation").Resolve(context => new { });
        }
    }
}