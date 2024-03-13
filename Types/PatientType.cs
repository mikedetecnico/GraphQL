using GraphQL.Types;
using GraphQLProject.Models;
using GraphQLProject.Repositories;

namespace GraphQLProject.Types
{
    public class PatientType : ObjectGraphType<Patient>
    {
        public PatientType(IStudyRepository studyRepository)
        {
            Field(x => x.PatientId);
            Field(x => x.FirstName); 
            Field(x => x.LastName);
            Field<ListGraphType<StudyType>>("Studies").Resolve(context => { return studyRepository.GetByPatientId(context.Source.PatientId); });
        }
    }
}