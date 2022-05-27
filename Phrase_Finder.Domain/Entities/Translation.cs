using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Phrase_Finder.Domain.Entities
{
    public class Translation
    {
        [Key]
        public int Id { get; set; }
        public ICollection<EnglishWord> EnglishWord { get; set; }
        public ICollection<TranslationalWord> TranslationalWords { get; set; }
        public Dictionary Dictionary { get; set; }
        public int DictionaryId { get; set; }
        public DateTime DateOfRecall { get; set; }
    }
}
