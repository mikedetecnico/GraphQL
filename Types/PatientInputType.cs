using GraphQL.Types;

namespace GraphQLProject.Types
{
    public class PatientInputType : InputObjectGraphType
    {
        public PatientInputType()
        {
            Field<NonNullGraphType<GuidGraphType>>("patientId");
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
        }
    }
}