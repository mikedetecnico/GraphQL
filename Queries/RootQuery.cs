using GraphQL.Types;

namespace GraphQLProject.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Field<StudyQuery>("studyQuery").Resolve(context => new { });
            Field<PatientQuery>("patientQuery").Resolve(context => new { });
        }
    }
}