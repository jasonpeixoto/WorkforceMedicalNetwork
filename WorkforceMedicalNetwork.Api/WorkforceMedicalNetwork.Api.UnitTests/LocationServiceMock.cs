using Moq;
using System.Threading.Tasks;
using WorkforceMedicalNetwork.Api.Interfaces;
using WorkforceMedicalNetwork.Api.Models;

namespace WorkforceMedicalNetwork.Api.UnitTests
{
    public class LocationServiceMock : ILocationService
    {
        private readonly ILocationService _ILocationService;
        protected LocationResponseModel _LocationResponseModel;
        public Mock<ILocationService> Mock { get; set; }
        public bool WillSucceed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LocationServiceMock()
        {
            WillSucceed = true;
            Mock = new Mock<ILocationService>();

            Mock.Setup(vs => vs.Location(It.IsAny<LocationRequestModel>()))
                .Returns(() =>
                {
                    return Task.FromResult(_LocationResponseModel);
                })
                .Verifiable();

            _ILocationService = Mock.Object;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<LocationResponseModel> Location(LocationRequestModel requestModel)
        {
            _LocationResponseModel = await _ILocationService.Location(requestModel);
            return _LocationResponseModel;
        }
    }
}
