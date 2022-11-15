using Comments.Infrastructure.Models;

namespace Comments.Infrastructure.Interfaces.IRepository
{
    public interface IUserRepository
    {
        int GetUserIdByEmail(string email);
    }
}
