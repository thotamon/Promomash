using Promomash.UserRepository.Entities;
using Promomash.UserRepository.Models;

namespace Promomash.UserRepository.Repository
{
    public static class NaiveMapperInitializer
    {
        private static CountryModel CountryToCountryModel(Country country)
        {
            var model = new CountryModel
            {
                Id = country.Id,
                Name = country.Name     
            };

            return model;
        }

        private static ProvinceModel ProvinceToProvinceModel(Province province)
        {
            var model = new ProvinceModel
            {
                Id = province.Id,
                Name = province.Name,
                CountryId = province.CountryId
            };

            return model;
        }

        private static UserModel UserToUserModel(User user)
        {
            var model = new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Agree = user.Agree,
                ProvinceId = user.ProvinceId
            };

            return model;
        }

        private static User UserModelToUser(UserModel userModel)
        {
            var user = new User
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Password = userModel.Password,
                Agree = userModel.Agree,
                ProvinceId = userModel.ProvinceId
            };

            return user;
        }

        public static INaiveMapper Create()
        {
            var mapper = new NaiveMapper();

            mapper.Register<Province, ProvinceModel>(x => ProvinceToProvinceModel((Province)x));
            mapper.Register<Country, CountryModel>(x => CountryToCountryModel((Country)x));
            mapper.Register<User, UserModel>(x => UserToUserModel((User)x));
            mapper.Register<UserModel, User>(x => UserModelToUser((UserModel)x));

            return mapper;
        }
    }
}
