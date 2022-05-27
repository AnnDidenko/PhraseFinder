using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Models
{
    public class TranslationDto
    {
        public ICollection<EnglishWordDto> EnglishWord { get; set; }
        public ICollection<TranslationalWordDto> TranslationalWords { get; set; }
        public int DictionaryId { get; set; }
        public DateTime DateOfRecall { get; set; }
    }
}
