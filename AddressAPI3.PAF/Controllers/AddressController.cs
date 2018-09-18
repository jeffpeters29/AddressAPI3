using AddressAPI3.Application.Address;
using AddressAPI3.Common.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AddressAPI3.Application.User;
using AddressAPI3.Domain;

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

        public AddressController(ILogger<AddressController> logger, IMailService mailService, IAddressRepository addressRepository
                                ,IUserRepository userRepository)
        {
            _logger = logger;
            _mailService = mailService;
            _addressRepository = addressRepository;
            _userRepository = userRepository;
        }

        [HttpGet("{searchTerm}")]
        public async Task<IActionResult> GetAddressPostcode(string searchTerm)
        {
            var userId = this.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
            var uri = this.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/uri")?.Value;
            var referer = this.Request.Headers["Referer"].ToString();

            if (IsUnrecognisedReferer(uri, referer)) return Unauthorized();

            try
            {
                var sw = new Stopwatch();
                sw.Start();

                var addresses = _addressRepository.GetAddresses(searchTerm);

                await LogActivity(userId, referer, searchTerm.ToUpper(), sw);

                if (addresses.Any())
                    return Ok(addresses);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"###  Exception whilst searching for postcode {searchTerm} ### ", ex);
                _mailService.Send($"PAF Critical Error - {searchTerm}", ex.Message);
                return StatusCode(500, "A problem happened whilst searching for searchTerm {searchTerm}");
            }
        }

        private async Task LogActivity(string userId, string referer, string searchTerm, Stopwatch sw)
        {
            sw.Stop();

            if (string.IsNullOrEmpty(searchTerm)) return;

            _logger.LogInformation($"### Postcode searched for {searchTerm}");

            await _userRepository.LogActivity(new ActivityLog()
            {
                UserId = Convert.ToInt32(userId),
                Referer = referer,
                SearchTerm = searchTerm,
                ElapsedTime = sw.ElapsedMilliseconds
            });
        }

        private static bool IsUnrecognisedReferer(string claimsUri, string referer)
        {
            return claimsUri != referer;
        }
    }
}