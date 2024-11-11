using Promomash.UserRepository.Entities;

namespace Promomash.UserRepository.Repository
{
    public static class InitialData
    {
        public static List<Country> GetPreconfiguredCountries()
        {
            return new List<Country>
            {
                new Country { Id = 1, Name = "Country1" },
                new Country { Id = 2, Name = "Country2" },
                new Country { Id = 3, Name = "Country3" },
                new Country { Id = 4, Name = "Country4" },
                new Country { Id = 5, Name = "Country5" },
                new Country { Id = 6, Name = "Country6" }
            };
        }
        public static List<Province> GetPreconfiguredProvinces()
        {
            return new List<Province>
            {
                new Province { Id = 1, Name = "Province1.1", CountryId = 1 },
                new Province { Id = 2, Name = "Province2.1", CountryId = 2 },
                new Province { Id = 3, Name = "Province2.2", CountryId = 2 },
                new Province { Id = 4, Name = "Province3.1", CountryId = 3 },
                new Province { Id = 5, Name = "Province3.2", CountryId = 3 },
                new Province { Id = 6, Name = "Province3.3", CountryId = 3 },
                new Province { Id = 7, Name = "Province4.1", CountryId = 4 },
                new Province { Id = 8, Name = "Province4.2", CountryId = 4 },
                new Province { Id = 9, Name = "Province4.3", CountryId = 4 },
                new Province { Id = 10, Name = "Province4.4", CountryId = 4 },
                new Province { Id = 11, Name = "Province5.1", CountryId = 5 },
                new Province { Id = 12, Name = "Province5.2", CountryId = 5 },
                new Province { Id = 13, Name = "Province5.3", CountryId = 5 },
                new Province { Id = 14, Name = "Province5.4", CountryId = 5 },
                new Province { Id = 15, Name = "Province5.5", CountryId = 5 },
                new Province { Id = 16, Name = "Province6.1", CountryId = 6 },
                new Province { Id = 17, Name = "Province6.2", CountryId = 6 },
                new Province { Id = 18, Name = "Province6.3", CountryId = 6 },
                new Province { Id = 19, Name = "Province6.4", CountryId = 6 },
                new Province { Id = 20, Name = "Province6.5", CountryId = 6 },
                new Province { Id = 21, Name = "Province6.6", CountryId = 6 },
            };
        }

    }
}
