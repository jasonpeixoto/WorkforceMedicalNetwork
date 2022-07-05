using Xunit;
using Microsoft.Extensions.Logging.Abstractions;
using WorkforceMedicalNetwork.Api.Controllers;
using WorkforceMedicalNetwork.Api.Models;
using WorkforceMedicalNetwork.Api.UnitTests.TestFramework;

namespace WorkforceMedicalNetwork.Api.UnitTests
{
    [Collection("UnitTests")]
    public class LocationControllerUnitTests : ControllerUnitTests<LocationServiceMock, LocationController>
    {
        public LocationControllerUnitTests()
        {
            _mockService = new LocationServiceMock();
            _controller = new LocationController(new NullLogger<LocationController>(), _mockService);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("emailAddress", "date")]
        [InlineData(TestConstants.EmailAddress, TestConstants.Password)]
        public async System.Threading.Tasks.Task Login_Tests(string emailAddress, string date)
        {
            LocationRequestModel requestModel = new LocationRequestModel()
            {
                emailAddress = emailAddress,
                date = date,
                latitude = 0,
                longitude = 0
            };

            var verifyPassCodeResult = await _controller.Location(requestModel);

            Assert.NotNull(verifyPassCodeResult);

            // if all null also test passing a null object
            if ((emailAddress == null) && (date == null))
            {
                verifyPassCodeResult = await _controller.Location(null);
                Assert.NotNull(verifyPassCodeResult);
            }
        }

    }
}
