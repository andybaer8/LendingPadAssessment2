using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Users
{
    [AutoRegister]
    public class DeleteProductService : IDeleteProductService
    {
        private readonly IUserRepository _userRepository;

        public DeleteProductService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        public void DeleteAll()
        {
            _userRepository.DeleteAll();
        }
    }
}