using Microsoft.EntityFrameworkCore;
using Promomash.UserRepository.Entities;
using Promomash.UserRepository.Models;

namespace Promomash.UserRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly INaiveMapper _mapper;
        private readonly GenericRepository<User> _users;
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context, INaiveMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _users = new GenericRepository<User>(context);
        }

        public async Task<int> AddUser(UserModel user)
        {
            var userEnitity = _mapper.Map<UserModel, User>(user);
            userEnitity.Id = 0;

            return await this._users.Add(userEnitity);
        }

        public async Task<int> DeleteUser(int Id)
        {
            var user = await this._users.GetById(Id);

            return await this._users.Remove(user);
        }

        public async Task<IEnumerable<CountryModel>> GetCountries()
        {
            return await _context.Countries.Select(x => _mapper.Map<Country, CountryModel>(x)).ToListAsync();
        }

        public async Task<IEnumerable<ProvinceModel>> GetProvincesForCountry(int countryId)
        {
            return await _context.Provinces.Where(x => x.CountryId == countryId).Select(x => _mapper.Map<Province, ProvinceModel>(x)).ToListAsync();
        }

        public async Task<int> UpdateUser(UserModel user)
        {
            var userEntity = _mapper.Map<UserModel, User>(user);

            return await this._users.Update(userEntity);
        }
    }
}
