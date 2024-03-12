using GraphQLProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.Data
{
    public class GraphQLDbContext: DbContext
    {
        /// <summary>
        /// The patient DB set.
        /// </summary>
        public DbSet<Patient> Patients 
        { 
            get; set; 
        }

        /// <summary>
        /// The studies DB Set.
        /// </summary>
        public DbSet<Study> Studies 
        { 
            get; set; 
        }

        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options)
            : base(options)
        {
    }
}
}