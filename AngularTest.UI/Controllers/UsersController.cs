using Microsoft.AspNetCore.Mvc;
using Promomash.UserRepository.Models;
using Promomash.UserRepository.Repository;

namespace AngularTest.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserRepository _userRepository;

        public UsersController(ILogger<UsersController> logger, IUserRepository repository)
        {
            _logger = logger;
            _userRepository = repository;

        }

        [HttpGet("countries")]
        public async Task<IEnumerable<CountryModel>> Get()
        {
            return await _userRepository.GetCountries();
        }

        [HttpGet("provinces")]
        public async Task<IEnumerable<ProvinceModel>> Get([FromQuery]int countryId)
        {
            return await _userRepository.GetProvincesForCountry(countryId);
        }

        [HttpPost]
        public async Task<bool> AddUser(UserModel user)
        {
            return await _userRepository.AddUser(user) > 0;
        }
    }
}