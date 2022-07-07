// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkforceMedicalNetwork.Api.Db.Repository;
using WorkforceMedicalNetwork.Api.Db.Tables;
using WorkforceMedicalNetwork.Api.Interfaces;
using WorkforceMedicalNetwork.Api.Models;
using WorkforceMedicalNetwork.Api.Utils;

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
            if ((requestModel == null) || !requestModel.IsValid())
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
            var userRepository = new UserRepository();
            var tokenEmail = requestModel.token.Decrypt();

            // force a login
            if (tokenEmail == null || string.IsNullOrEmpty(tokenEmail) || (tokenEmail != requestModel.email))
            {
                resultModel.login = true;
                resultModel.errorCode = "Invalid";
            }
            else if (await userRepository.IsEmailExistAsync(requestModel.email))
            {
                // create location record
                await Utils.Utils.CreateLocationAsync(requestModel);

                // ok user created here
                resultModel.success = true;
                resultModel.login = false;
            }
            else
            {
                resultModel.login = false;
                resultModel.errorCode = "Invalid";
            }
            return resultModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task<List<LocationTbl>> GetLocations(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            return GetLocationsInternalAsync(email);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        private async Task<List<LocationTbl>> GetLocationsInternalAsync(string email)
        {
            List<LocationTbl> locations = null;
            if (await (new UserRepository()).IsEmailExistAsync(email))
            {
                locations = await (new LocationRepository()).GetLocations(email);
            }
            return locations;
        }
    }
}
