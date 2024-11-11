using Promomash.UserRepository.Models;

namespace Promomash.UserRepository.Repository
{
    public interface IUserRepository
    {
        Task<int> AddUser(UserModel user);

        Task<int> UpdateUser(UserModel user);

        Task<int> DeleteUser(int Id);
        Task<IEnumerable<CountryModel>> GetCountries();

        Task<IEnumerable<ProvinceModel>> GetProvincesForCountry(int countryId);
    }
}
