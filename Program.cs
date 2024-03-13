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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// types
builder.Services.AddTransient<PatientInputType>();
builder.Services.AddTransient<StudyInputType>();
builder.Services.AddTransient<PatientType>();
builder.Services.AddTransient<StudyType>();

// repositories
builder.Services.AddTransient<IPatientRepository, PatientRepository>();
builder.Services.AddTransient<IStudyRepository, StudyRepository>();

// queries
builder.Services.AddTransient<PatientQuery>();
builder.Services.AddTransient<StudyQuery>();
builder.Services.AddTransient<RootQuery>();

// mutations
builder.Services.AddTransient<PatientMutation>();
builder.Services.AddTransient<StudyMutation>();
builder.Services.AddTransient<RootMutation>();

// schema
builder.Services.AddTransient<ISchema, RootSchema>();
builder.Services.AddGraphQL(b => b.AddAutoSchema<ISchema>().AddSystemTextJson().AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true));

// db connection
builder.Services.AddDbContext<GraphQLDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GraphQLDbContextConnection")));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseGraphiQl("/graphiql");
app.UseGraphQL<ISchema>();

app.UseAuthorization();

app.MapControllers();

app.Run();
