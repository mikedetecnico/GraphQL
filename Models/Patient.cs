namespace GraphQLProject.Models
{
    public class Patient
    {
        /// <summary>
        /// The unique identifier for the patient.
        /// </summary>
        public Guid PatientId 
        { 
            get; set; 
        }

        /// <summary>
        /// The first name of the patient.
        /// </summary>
        public string FirstName 
        { 
            get; set; 
        }

        /// <summary>
        /// The last name of the patient.
        /// </summary>
        public string LastName 
        { 
            get; set; 
        }

        /// <summary>
        /// The associated studies for the patient.
        /// </summary>
        public ICollection<Study> Studies 
        { 
            get; set; 
        }
    }
}