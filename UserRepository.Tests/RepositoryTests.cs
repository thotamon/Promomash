using Microsoft.EntityFrameworkCore;
using Promomash.UserRepository.Models;
using Promomash.UserRepository.Repository;

namespace Promomash.UserRepository.Tests
{
    public class Tests
    {
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=EFTest;Trusted_Connection=True;ConnectRetryCount=0";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;


        public AppDbContext CreateContext() => new(
                new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);

        [SetUp]
        public void Setup()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        [Test]
        public async Task ReadCountriesAsyncTest()
        {
            using var context = CreateContext();
            var repository = new Repository.UserRepository(context, NaiveMapperInitializer.Create());

            var countries = await repository.GetCountries();

            Assert.That(countries, Is.Not.Null);
            Assert.That(countries.Any(), Is.True);
        }

        [Test]
        public async Task ReadProvincesAsyncTest()
        {
            using var context = CreateContext();
            var repository = new Repository.UserRepository(context, NaiveMapperInitializer.Create());

            var countries = await repository.GetCountries();
            var country = countries.First();

            var provinces = await repository.GetProvincesForCountry(country.Id);

            Assert.That(provinces, Is.Not.Null);
            Assert.That(provinces.Any(), Is.True);
        }

        [Test]
        public async Task AddUserAsyncTest()
        {
            using var context = CreateContext();
            var repository = new Repository.UserRepository(context, NaiveMapperInitializer.Create());

            var countries = await repository.GetCountries();
            var country = countries.First();

            var provinces = await repository.GetProvincesForCountry(country.Id);
            var province = provinces.First();

            var user = new UserModel
            {
                Id = 10,
                Agree = true,
                Name = "Test",
                Password = "Test",
                ProvinceId = province.Id
            };

            var count = await repository.AddUser(user);

            Assert.That(count, Is.GreaterThan(0));
        }
    }
}