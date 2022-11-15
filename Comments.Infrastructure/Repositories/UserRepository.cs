using Comments.Infrastructure.DbContexts;
using Comments.Infrastructure.Interfaces.IRepository;
using Comments.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comments.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext context;

        public UserRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public int GetUserIdByEmail(string email)
        {
            return context.Users.Where(u => u.Email == email)
                .AsNoTracking()
                .Select(u => u.UserId)
                .FirstOrDefault();
        }
    }
}
