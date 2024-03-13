
using GraphQL.Types;
using GraphQLProject.Models;

namespace GraphQLProject.Types
{
    public class StudyType : ObjectGraphType<Study>
    {
        public StudyType()
        {
            Field(x => x.StudyId);
            Field(x => x.Modality);
            Field(x => x.NumImages);
            Field(x => x.PatientId);
        }
    }
}