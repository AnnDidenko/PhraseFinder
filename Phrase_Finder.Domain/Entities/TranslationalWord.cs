using System.ComponentModel.DataAnnotations;

namespace Phrase_Finder.Domain.Entities
{
    public class TranslationalWord
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Word { get; set; }
        [Required]
        public string PartOfLanguage { get; set; }
        public Translation Translation { get; set; }
        public int TranslationId { get; set; }
    }
}
