using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase_Finder.Models
{
    public class TranslationModel
    {
        public ICollection<EnglishWordModel> EnglishWord { get; set; }
        public ICollection<TranslationalWordModel> TranslationalWords { get; set; }
    }
}
