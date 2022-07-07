// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Threading.Tasks;
using WorkforceMedicalNetwork.Api.Db.Repository;
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
            if (tokenEmail == null || string.IsNullOrEmpty(tokenEmail) || (tokenEmail != requestModel.emailAddress))
            {
                resultModel.login = true;
                resultModel.errorCode = "Invalid";
            }
            else if (await userRepository.IsEmailExistAsync(requestModel.emailAddress))
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
    }
}
