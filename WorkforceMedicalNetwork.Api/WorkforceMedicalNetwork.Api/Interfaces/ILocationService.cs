// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System.Threading.Tasks;
using WorkforceMedicalNetwork.Api.Models;

namespace WorkforceMedicalNetwork.Api.Interfaces
{
    public interface ILocationService
    {
        Task<LocationResponseModel> Location(LocationRequestModel requestModel);
    }
}
