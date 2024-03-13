using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQLProject.Data;
using GraphQLProject.Mutations;
using GraphQLProject.Queries;
using GraphQLProject.Repositories;
using GraphQLProject.Schema;
using GraphQLProject.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<PatientInputType>();
            services.AddTransient<StudyInputType>();
            services.AddTransient<PatientType>();
            services.AddTransient<StudyType>();

            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IStudyRepository, StudyRepository>();

            services.AddTransient<PatientQuery>();
            services.AddTransient<StudyQuery>();
            services.AddTransient<RootQuery>();

            services.AddTransient<PatientMutation>();
            services.AddTransient<StudyMutation>();
            services.AddTransient<RootMutation>();

            services.AddTransient<ISchema, RootSchema>();
            services.AddGraphQL(b => b.AddAutoSchema<ISchema>().AddSystemTextJson().AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true));

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            services.AddDbContext<GraphQLDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("GraphQLDbContextConnection"))
            );
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseGraphiQl("/graphiql");
            app.UseGraphQL<ISchema>();

            app.UseAuthorization();
        }
    }
}