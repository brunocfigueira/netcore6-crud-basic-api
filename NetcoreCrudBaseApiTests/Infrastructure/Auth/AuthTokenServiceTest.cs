using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NetcoreCrudBaseApi.Infrastructure.Auth;
using NetcoreCrudBaseApiTests.Doubles.Entities;
using NSubstitute;

namespace NetcoreCrudBaseApiTests.Infrastructure.Auth
{
    public class AuthTokenServiceTest
    {
        private AuthTokenService _authTokenService;
        public AuthTokenServiceTest()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var tokenConfiguration = config.GetSection("TokenConfiguration").Get<TokenConfiguration>();
            var option = Options.Create(tokenConfiguration);
            _authTokenService = new AuthTokenService(option);
        }

        [Fact]
        public void CreateTokenUser_ReturnTokenString()
        {
            //Arrange
            var user = UserDouble.GetUserFake();
            //Act
            var result = _authTokenService.CreateTokenUser(user);

            // Assert
            Assert.IsType<string>(result);
        }
        [Fact]
        public void CreateTokenUser_ThrowException()
        {
            //Arrange
            var user = UserDouble.GetUserFake();
            user.Profile = null;
            //Act
            var result = Assert.Throws<Exception>(() => _authTokenService.CreateTokenUser(user));

            // Assert
            Assert.Equal("Error on create token user", result.Message);
        }
    }
}
