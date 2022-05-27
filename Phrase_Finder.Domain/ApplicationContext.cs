using Microsoft.EntityFrameworkCore;
using Phrase_Finder.Domain.Entities;

namespace Phrase_Finder.Domain
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :
            base(options)
        {

        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Dictionary> Dictionaries { get; set; }
        public DbSet<EnglishWord> EnglishWords { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<TranslationalWord> TranslationalWords { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
