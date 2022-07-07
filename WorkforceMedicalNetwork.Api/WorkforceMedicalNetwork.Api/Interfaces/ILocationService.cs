// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Threading.Tasks;
using WorkforceMedicalNetwork.Api.Db.Tables;
using WorkforceMedicalNetwork.Api.Models;

namespace WorkforceMedicalNetwork.Api.Interfaces
{
    public interface ILocationService
    {
        Task<LocationResponseModel> Location(LocationRequestModel requestModel);
        Task<List<LocationTbl>> GetLocations(string email);
    }
}
