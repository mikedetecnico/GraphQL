using GraphQLProject.Data;
using GraphQLProject.Models;
using GraphQLProject.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAPI.Tests
{
    public class RepositoryTests
    {
        private IRepository<Patient> _patientRepository;

        private Guid _patientId = Guid.NewGuid();

        [SetUp]
        public void Setup()
        {
            // mock db context
            DbContextOptions<GraphQLDbContext> dbContextOptions = new DbContextOptionsBuilder<GraphQLDbContext>()
                .UseInMemoryDatabase(databaseName: "GraphQLDb")
                .Options;

            GraphQLDbContext dbContext = new GraphQLDbContext(dbContextOptions);

            // clear db context
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            // add data to in-memory db
            dbContext.Patients.Add(new Patient { PatientId = _patientId, FirstName = "John", LastName = "Doe" });
            dbContext.Studies.Add(new Study { StudyId = Guid.NewGuid(), PatientId = _patientId, Modality = "CT", NumImages = 100});
            dbContext.SaveChanges();

            _patientRepository = new PatientRepository(dbContext);
        }

        [Test]
        public void TestGetPatientById()
        {
            Patient? result = _patientRepository.GetById(_patientId);

            Assert.IsNotNull(result);
            Assert.That(result.FirstName, Is.EqualTo("John"));
            Assert.That(result.LastName, Is.EqualTo("Doe"));
        }

        [Test]
        public void TestGetPatientByIdWithStudies()
        {
            Patient? result = _patientRepository.GetById(_patientId);

            Assert.IsNotNull(result);
            Assert.That(result.FirstName, Is.EqualTo("John"));
            Assert.That(result.LastName, Is.EqualTo("Doe"));
            Assert.That(result.Studies.Count, Is.EqualTo(1));
            Assert.That(result.Studies.First().Modality, Is.EqualTo("CT"));
            Assert.That(result.Studies.First().NumImages, Is.EqualTo(100));
        }

        [Test]
        public void TestAddPatient()
        {
            Patient newPatient = new Patient { FirstName = "Jane", LastName = "Doe" };
            Patient? result = _patientRepository.Add(newPatient);

            Assert.IsNotNull(result);
            Assert.That(result.FirstName, Is.EqualTo("Jane"));
            Assert.That(result.LastName, Is.EqualTo("Doe"));
        }

        [Test]
        public void TestDeletePatient()
        {
            _patientRepository.Delete(_patientId);
            Patient? result = _patientRepository.GetById(_patientId);

            Assert.IsNull(result);
        }

        [Test]
        public void TestGetAllPatients()
        {
            List<Patient> result = _patientRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.First().FirstName, Is.EqualTo("John"));
            Assert.That(result.First().LastName, Is.EqualTo("Doe"));
        }
    }
}