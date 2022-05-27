using Phrase_Finder.Domain.Entities;
using Phrase_Finder.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase_Finder.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Update(User item)
        {
            _context.Users.Update(item);
            _context.SaveChanges();
        }
    }
}
