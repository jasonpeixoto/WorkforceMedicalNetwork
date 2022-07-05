// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System.Threading.Tasks;
using WorkforceMedicalNetwork.Api.Models;

namespace WorkforceMedicalNetwork.Api.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponseModel> Login(LoginRequestModel requestModel);
    }
}
