using AddressAPI3.Application.Address;
using AddressAPI3.Common.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

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

        public AddressController(ILogger<AddressController> logger, IMailService mailService, IAddressRepository addressRepository)
        {
            _logger = logger;
            _mailService = mailService;
            _addressRepository = addressRepository;
        }

        [HttpGet("{searchTerm}")]
        public IActionResult GetAddressPostcode(string searchTerm)
        {
            _logger.LogInformation($"### Postcode searched for {searchTerm}");

            try
            {
                var addresses = _addressRepository.GetAddresses(searchTerm);

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
    }
}