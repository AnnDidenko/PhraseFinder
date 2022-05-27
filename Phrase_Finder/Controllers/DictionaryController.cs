using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using Phrase_Finder.Application.Infrastructure;
using Phrase_Finder.Application.Models;
using Phrase_Finder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Phrase_Finder.Controllers
{
    [Route("dictionary")]
    [ApiController]
    public class DictionaryController: ControllerBase
    {
        private readonly IDictionaryService _dictionaryService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public DictionaryController(IDictionaryService dictionaryService,
            IAuthService authService,
            IMapper mapper)
        {
            _dictionaryService = dictionaryService;
            _mapper = mapper;
            _authService = authService;
        }

        [HttpPost("newWords")]
        [Authorize]
        public async Task<string> AddWordsToDictionary([FromBody] TranslationModel translation)
        {
            var userId = User.Claims.Where(c => c.Properties.FirstOrDefault().Value == JwtRegisteredClaimNames.Sub).Select(c => c.Value).SingleOrDefault();
            var user = _authService.UserById(int.Parse(userId));
            await _dictionaryService.AddWordToDictionary(user, _mapper.Map<TranslationDto>(translation));
            var dict = await _dictionaryService.GetDictionary(user);
            return JsonConvert.SerializeObject(_mapper.Map<DictionaryModel>(dict), Formatting.Indented);
        }
    }
}
