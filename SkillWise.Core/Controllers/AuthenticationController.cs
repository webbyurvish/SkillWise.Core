using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillWise.Core.DataTransferObjects;
using SkillWise.Core.Service.Contracts;

namespace SkillWise.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthenticationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserForRegistrationDto userForRegistration)
        {
           var result = await _serviceManager.AuthenticationService.RegisterUser(userForRegistration);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }
    }
}
