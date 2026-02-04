using Emart_DotNet.DTOs;
using Emart_DotNet.Models;
using Emart_DotNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace Emart_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmartCardController : ControllerBase
    {
        private readonly IEmartCardService _emartCardService;

        public EmartCardController(IEmartCardService emartCardService)
        {
            _emartCardService = emartCardService;
        }

        [HttpPost("apply")]
        public async Task<ActionResult<EmartCard>> ApplyForCard(ApplyEmartCardRequest request)
        {
            try
            {
                var card = await _emartCardService.ApplyForCardAsync(request);
                return Ok(card);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<EmartCardDTO>> GetCardDetails(int userId)
        {
            var card = await _emartCardService.GetCardDetailsAsync(userId);
            if (card == null)
            {
                return NotFound("No Emart Card found for this user.");
            }
            return Ok(card);
        }
    }
    
    // Simple DTO for request if not already defined elsewhere, though it should be in DTOs folder ideally.
    // Putting it here for now if DTOs/ApplyEmartCardRequest.cs doesn't exist, but checking first.
}
