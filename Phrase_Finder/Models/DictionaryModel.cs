using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase_Finder.Models
{
    public class DictionaryModel
    {
        public string Name { get; set; }
        public string Topic { get; set; }
        public ICollection<TranslationModel> Translations { get; set; }
    }
}
