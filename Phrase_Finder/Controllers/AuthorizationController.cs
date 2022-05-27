using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Phrase_Finder.Application.Infrastructure;
using Phrase_Finder.Application.Models;
using Phrase_Finder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase_Finder.Controllers
{
    [Route("authorization")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpGet("users")]
        public IActionResult AllUsers()
        {
            _authService.AllUsers();
            return Ok();
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationRequestModel newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = _mapper.Map<RegistrationRequestDto>(newUser);
            await _authService.Register(user);
            return Ok();
        }

        [HttpPost("authenticate")]
        public Object Authenticate([FromBody] LoginRequestModel checkLogin)
        {
            var login = _mapper.Map<RegistrationRequestDto>(checkLogin);
            return _authService.Authenticate(login);
        }
    }
}
