using System;
using System.Threading.Tasks;
using WorkforceMedicalNetwork.Api.Db.Repository;
using WorkforceMedicalNetwork.Api.Models;

namespace WorkforceMedicalNetwork.Api.Utils
{
    public static class Utils
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="registerRequestModel"></param>
        /// <returns></returns>
        public static async Task CreateUserAsync(this UserRepository userRepository, RegisterRequestModel registerRequestModel)
        {
            // add user to database
            await userRepository.CreateUserAsync(
                registerRequestModel.fullName,
                registerRequestModel.email,
                registerRequestModel.password
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerRequestModel"></param>
        /// <returns></returns>
        public static async Task CreateUserAsync(RegisterRequestModel registerRequestModel)
        {
            await (new UserRepository()).CreateUserAsync(registerRequestModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseLocationRequestModel"></param>
        /// <returns></returns>
        public static async Task CreateLocationAsync(this LocationRepository locationRepository, BaseLocationRequestModel locationRequestModel)
        {
            await locationRepository.CreateLocationAsync(
                locationRequestModel.email,
                locationRequestModel.date,
                locationRequestModel.latitude,
                locationRequestModel.longitude
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationRequestModel"></param>
        /// <returns></returns>
        public static async Task CreateLocationAsync(BaseLocationRequestModel locationRequestModel)
        {
            await (new LocationRepository()).CreateLocationAsync(locationRequestModel);
        }
    }
}

