// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Threading.Tasks;
using WorkforceMedicalNetwork.Api.Interfaces;
using WorkforceMedicalNetwork.Api.Models;

namespace WorkforceMedicalNetwork.Api.Services
{
    public class LocationService : ILocationService
    {
        public LocationService()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public Task<LocationResponseModel> Location(LocationRequestModel requestModel)
        {
            if ((requestModel == null) || requestModel.IsValid())
            {
                throw new ArgumentNullException(nameof(requestModel));
            }

            return LocationInternalAsync(requestModel);
        }

        /// <summary>
        /// User: catester
        /// Pass: password
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        private async Task<LocationResponseModel> LocationInternalAsync(LocationRequestModel requestModel)
        {
            var resultModel = new LocationResponseModel();

            // access DAL here

            return resultModel;
        }
    }
}
