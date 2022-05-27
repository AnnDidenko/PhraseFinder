using Phrase_Finder.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Infrastructure
{
    public interface IDictionaryService
    {
        public Task AddWordToDictionary(UserDto user, TranslationDto translation);
        public Task<DictionaryDto> GetDictionary(UserDto user);
    }
}
