using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerAspNetCore.Domain.Entities;
using ServerAspNetCore.Domain.Services;

namespace ServerAspNetCore.Controllers
{
    [Route("api/Access")]
    public class AccessController : Controller
    {
        private IAccessService _accessService;

        public AccessController(IAccessService accessService)
        {
            _accessService = accessService;
        }

        [HttpPost("gainAccessToCourse")]
        public async Task<IActionResult> GainAccessToCourse([FromBody]Access newAccess)
        {
            try
            {
                await _accessService.Create(newAccess);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}