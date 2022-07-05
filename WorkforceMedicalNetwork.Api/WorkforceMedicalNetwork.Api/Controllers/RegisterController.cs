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
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly IRegisterService _registerService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="registerService"></param>
        public RegisterController(ILogger<RegisterController> logger, IRegisterService registerService)
        {
            _logger = logger;
            _registerService = registerService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [Route("api/register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel registerRequest)
        {
            _logger.LogInformation("Start - Register method.");
            RegisterResponseModel registerResponse = null;
            try
            {
                registerResponse = await _registerService.Register(registerRequest);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            _logger.LogInformation("End - Register method.");
            return Ok(registerResponse ?? new RegisterResponseModel());
        }
    }
}
