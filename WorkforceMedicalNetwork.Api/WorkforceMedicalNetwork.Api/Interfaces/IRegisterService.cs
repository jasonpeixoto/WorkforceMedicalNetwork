// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System.Threading.Tasks;
using WorkforceMedicalNetwork.Api.Models;

namespace WorkforceMedicalNetwork.Api.Interfaces
{
    public interface IRegisterService
    {
        Task<RegisterResponseModel> Register(RegisterRequestModel requestModel);
    }
}
