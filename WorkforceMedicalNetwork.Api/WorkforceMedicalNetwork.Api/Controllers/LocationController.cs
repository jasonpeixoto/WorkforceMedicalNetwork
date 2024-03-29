﻿// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkforceMedicalNetwork.Api.Models;
using WorkforceMedicalNetwork.Api.Interfaces;
using System.Collections.Generic;
using WorkforceMedicalNetwork.Api.Db.Tables;

namespace WorkforceMedicalNetwork.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationService _locationService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="locationService"></param>
        public LocationController(ILogger<LocationController> logger, ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [Route("api/location")]
        public async Task<IActionResult> Location([FromBody] LocationRequestModel locationRequest)
        {
            _logger.LogInformation("Start - Location method.");
            LocationResponseModel locationResponse = null;
            try
            {
                locationResponse = await _locationService.Location(locationRequest);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            _logger.LogInformation("End - Location method.");
            return Ok(locationResponse ?? new LocationResponseModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationRequest"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [Route("api/locations")]
        public async Task<IActionResult> GetLocations(string email)
        {
            _logger.LogInformation("Start - Location method.");
            List<LocationTbl> locationResponse = null;
            try
            {
                locationResponse = await _locationService.GetLocations(email);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            _logger.LogInformation("End - Location method.");
            return Ok(locationResponse ?? new List<LocationTbl>());
        }
    }
}
