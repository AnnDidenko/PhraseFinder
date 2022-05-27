using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Phrase_Finder.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Role { get; set; }
        [Required]
        public string Email { get; set; }
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Dictionary> Dictionaries { get; set; }
    }
}
