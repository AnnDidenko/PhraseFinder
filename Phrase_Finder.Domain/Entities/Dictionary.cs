using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Phrase_Finder.Domain.Entities
{
    public class Dictionary
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public ICollection<Translation> Translations { get; set; }
    }
}
