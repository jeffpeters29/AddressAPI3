﻿using AddressAPI3.Application.Address;
using AddressAPI3.Application.User;
using AddressAPI3.Common.Mail;
using AddressAPI3.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AddressAPI3.API.Controllers
{
    [EnableCors("AllowAll")]
    [Authorize]
    [Route("api/address")]
    public class AddressController : Controller
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IMailService _mailService;
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMemoryCache _cache;

        public AddressController(ILogger<AddressController> logger, IMailService mailService, IAddressRepository addressRepository
                                , IUserRepository userRepository, IMemoryCache cache)
        {
            _logger = logger;
            _mailService = mailService;
            _addressRepository = addressRepository;
            _userRepository = userRepository;
            _cache = cache;
        }

        [HttpGet("{searchTerm}")]
        public async Task<IActionResult> GetAddressPostcode(string searchTerm)
        {
            searchTerm = searchTerm.ToUpper();
            var userId = this.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
            var uri = this.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/uri")?.Value;
            var referer = this.Request.Headers["Referer"].ToString();

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(uri) || string.IsNullOrEmpty(referer)) return Unauthorized();
            if (IsUnrecognisedReferer(uri, referer)) return Unauthorized();

            try
            {
                var sw = StartStopwatch();

                var addresses = GetAddresses(searchTerm);

                await LogActivity(userId, referer, searchTerm, sw);

                if (addresses.Any())
                    return Ok(addresses);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"###  Exception whilst searching for postcode {searchTerm} ### ", ex);
                _mailService.Send($"PAF API : Critical Error - {searchTerm}", ex.Message);
                return StatusCode(500, "A problem happened whilst searching for searchTerm {searchTerm}");
            }
        }

        private IEnumerable<Address> GetAddresses(string searchTerm)
        {
            IEnumerable<Address> addresses;

            if (!_cache.TryGetValue(searchTerm, out addresses))
            {
                addresses = _addressRepository.GetAddresses(searchTerm);
                _cache.Set(searchTerm, addresses);
            }

            return addresses;
        }


        #region LOGGING         

        private static Stopwatch StartStopwatch()
        {
            var sw = new Stopwatch();
            sw.Start();
            return sw;
        }

        private async Task LogActivity(string userId, string referer, string searchTerm, Stopwatch sw)
        {
            sw.Stop();

            if (string.IsNullOrEmpty(searchTerm)) return;

            // Simple logging (NLog / Console)
            _logger.LogInformation($"### Postcode searched for {searchTerm}");

            // Log statistics to db
            await _userRepository.LogActivity(new ActivityLog()
            {
                UserId = Convert.ToInt32(userId),
                Referer = referer,
                SearchTerm = searchTerm,
                ElapsedTime = sw.ElapsedMilliseconds
            });

            // Mail AppErrors
            if (IsElapsedTimeTooLong(sw))
                _mailService.Send("PAF API : Time Warning", $"Elapsed Time : {sw.ElapsedMilliseconds}");
        }

        private static bool IsElapsedTimeTooLong(Stopwatch sw)
        {
            return sw.ElapsedMilliseconds > 2000;
        }

        private static bool IsUnrecognisedReferer(string claimsUri, string referer)
        {
            return claimsUri != referer;
        }

        #endregion
    }
}