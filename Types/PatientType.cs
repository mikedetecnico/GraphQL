using GraphQL.Types;
using GraphQLProject.Models;

namespace GraphQLProject.Types
{
    public class PatientType : ObjectGraphType<Patient>
    {
        public PatientType()
        {
            Field(x => x.PatientId);
            Field(x => x.FirstName); 
            Field(x => x.LastName);
            Field<ListGraphType<StudyType>>("Studies").Resolve(context => { return context.Source.Studies; });
        }
    }
}