using BusinessEntities;

namespace Core.Services.Users
{
    public interface IDeleteProductService
    {
        void Delete(User user);
        void DeleteAll();
    }
}