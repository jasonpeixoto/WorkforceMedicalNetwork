// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkforceMedicalNetwork.Api.Models;
using WorkforceMedicalNetwork.Api.Interfaces;

namespace WorkforceMedicalNetwork.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginService _loginService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="loginService"></param>
        public LoginController(ILogger<LoginController> logger, ILoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [Route("api/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel loginRequest)
        {
            _logger.LogInformation("Start - Login method.");
            LoginResponseModel loginResponse = null;
            try
            {
                loginResponse = await _loginService.Login(loginRequest);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            _logger.LogInformation("End - Login method.");
            return Ok(loginResponse ?? new LoginResponseModel());
        }
    }
}
