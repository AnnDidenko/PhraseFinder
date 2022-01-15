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
    }
}
