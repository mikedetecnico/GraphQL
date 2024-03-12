namespace GraphQLProject.Models
{
    public class Study : IModel
    {
        /// <summary>
        /// The unique identifier of the study
        /// </summary>
        public Guid StudyId 
        { 
            get; set; 
        }

        /// <summary>
        /// The modality for the study (MRI, CT, etc.)
        /// </summary>
        public string Modality 
        { 
            get; set; 
        }

        /// <summary>
        /// The number of images in the study
        /// </summary>
        public int NumImages
        { 
            get; set; 
        }

        /// <summary>
        /// The patient identifier associated with the study
        /// </summary>
        public Guid PatientId 
        { 
            get; set; 
        }

        /// <summary>
        /// The patient associated with the study.
        /// </summary>
        public Patient Patient 
        { 
            get; set; 
        }

        public Guid GetId()
        {
            return StudyId;
        }
    }
}