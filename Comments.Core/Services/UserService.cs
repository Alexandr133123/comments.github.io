using Comments.Core.Interfaces.IService;
using Comments.Infrastructure.Interfaces.IRepository;

namespace Comments.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public int GetUserIdByEmail(string email)
        {
            return userRepository.GetUserIdByEmail(email);
        }
    }
}
