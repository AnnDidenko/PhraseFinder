
using System.Collections.Generic;

namespace Phrase_Finder.Application.Models
{
    public class DictionaryDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public ICollection<TranslationDto> Translations { get; set; }
    }
}
