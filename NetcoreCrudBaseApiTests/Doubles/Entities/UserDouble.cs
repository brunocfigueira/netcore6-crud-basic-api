using NetcoreCrudBaseApi.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetcoreCrudBaseApiTests.Doubles.Entities
{
    internal class UserDouble
    {
        public static UserEntity GetUserFake()
        {
            return new UserEntity
            {
                Id = 1,
                Username = "username",
                Login = "teste.login",
                Email = "teste@gmail.com",
                Password = "password",
                ProfileId = 1,
                Profile = new ProfileEntity
                {
                    Id = 1,
                    Name = "teste",
                    Acronym = "teste",
                    Active = true,
                    CreatedAt = DateTime.Now,
                    Description = "description"
                },
                CreatedAt = DateTime.Now,
                Active = true,
            };
        }
    }
}
