using NetcoreCrudBaseApi.Domains.Services;
using NetcoreCrudBaseApi.Infrastructure.Exceptions;
using NetcoreCrudBaseApi.Infrastructure.Responses;

namespace NetcoreCrudBaseApiTests.Domains.Services
{
    public class RootValidationServiceTest
    {

        [Fact]
        public void VerifyRootProfile_ThrowsForbiddenAccessException()
        {
            //Arrange
            var valueId = (int)RootValidationService.ERoot.PROFILEID;

            // Assert
            var result = Assert.Throws<ForbiddenAccessException>(
                //Act
                () => RootValidationService.VerifyRootProfile(valueId)
             );

            Assert.Equal(ResponseForbidden.MsgRootProfileChange, result.Message);
            

        }
        [Fact]
        public void VerifyRootProfile_ReturnVoid()
        {
            //Arrange
            var valueId = int.MaxValue;
            // Act
            RootValidationService.VerifyRootProfile(valueId);
            
        }

        [Fact]
        public void VerifyRootUser_ThrowsForbiddenAccessException()
        {
            //Arrange
            var valueId = (int)RootValidationService.ERoot.USERID;

            // Assert
            var result = Assert.Throws<ForbiddenAccessException>(
                //Act
                () => RootValidationService.VerifyRootUser(valueId)
             );

            Assert.Equal(ResponseForbidden.MsgRootUserChange, result.Message);


        }
        [Fact]
        public void VerifyRootUser_ReturnVoid()
        {
            //Arrange
            var valueId = int.MaxValue;
            // Act
            RootValidationService.VerifyRootUser(valueId);

        }

        [Fact]
        public void VerifyRootPermission_ThrowsForbiddenAccessException()
        {
            //Arrange
            var valueId = (int)RootValidationService.ERoot.PERMISSIONID;

            // Assert
            var result = Assert.Throws<ForbiddenAccessException>(
                //Act
                () => RootValidationService.VerifyRootPermission(valueId)
             );

            Assert.Equal(ResponseForbidden.MsgRootPermissionChange, result.Message);


        }
        [Fact]
        public void VerifyRootPermission_ReturnVoid()
        {
            //Arrange
            var valueId = int.MaxValue;
            // Act
            RootValidationService.VerifyRootPermission(valueId);

        }
    }
}