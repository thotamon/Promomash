using Promomash.UserRepository.Entities;
using Promomash.UserRepository.Models;
using Promomash.UserRepository.Repository;

namespace Promomash.UserRepository.Tests
{
    internal class MappingTests
    {
        private INaiveMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _mapper = NaiveMapperInitializer.Create();
        }

        [Test]
        public void MapCountryEntityToModel()
        {
            var countryEntity = new Country
            {
                Id = 1,
                Name = "Test"
            };

            var countryModel = new CountryModel
            {
                Id = 1,
                Name = "Test"
            };

            var result = _mapper.Map<Country, CountryModel>(countryEntity);

            Assert.That(result.Id == countryModel.Id && string.Equals(result.Name, countryModel.Name), Is.True);
        }

        [Test]
        public void MapProvinceEntityToModel()
        {
            var provinceEntity = new Province
            {
                Id = 1,
                Name = "Test",
                CountryId = 1
            };

            var provinceModel = new ProvinceModel
            {
                Id = 1,
                Name = "Test",
                CountryId = 1
            };

            var result = _mapper.Map<Province, ProvinceModel>(provinceEntity);

            Assert.That(result.Id == provinceModel.Id && string.Equals(result.Name, provinceModel.Name) && result.CountryId == provinceModel.CountryId, Is.True);
        }

        [Test]
        public void MapUserEntityToModel()
        {
            var userEntity = new User
            {
                Id = 1,
                Name = "Test",
                Agree = true,
                Password = "nopass",
                ProvinceId = 1
            };

            var userModel = new UserModel
            {
                Id = 1,
                Name = "Test",
                Agree = true,
                Password = "nopass",
                ProvinceId = 1
            };

            var result = _mapper.Map<User, UserModel>(userEntity);

            var isEqual = result.Id == userModel.Id &&
                string.Equals(result.Name, userModel.Name) &&
                result.Agree == userModel.Agree &&
                string.Equals(result.Password, userModel.Password) &&
                result.ProvinceId == userModel.ProvinceId;

            Assert.That(isEqual, Is.True);
        }

        [Test]
        public void MapUserModelToEntity()
        {
            var userModel = new UserModel
            {
                Id = 1,
                Name = "Test",
                Agree = true,
                Password = "nopass",
                ProvinceId = 1
            };

            var userEntity = new User
            {
                Id = 1,
                Name = "Test",
                Agree = true,
                Password = "nopass",
                ProvinceId = 1
            };


            var result = _mapper.Map<UserModel, User>(userModel);

            var isEqual = result.Id == userEntity.Id &&
                string.Equals(result.Name, userEntity.Name) &&
                result.Agree == userEntity.Agree &&
                string.Equals(result.Password, userEntity.Password) &&
                result.ProvinceId == userEntity.ProvinceId;

            Assert.That(isEqual, Is.True);
        }

    }
}
