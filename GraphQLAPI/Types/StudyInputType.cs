using GraphQL.Types;

namespace GraphQLProject.Types
{
    public class StudyInputType : InputObjectGraphType
    {
        public StudyInputType()
        {
            Field<NonNullGraphType<GuidGraphType>>("studyId");
            Field<NonNullGraphType<StringGraphType>>("modality");
            Field<NonNullGraphType<IntGraphType>>("numImages");
            Field<NonNullGraphType<GuidGraphType>>("patientId");
        }
    }
}