using MobileStoreManager.Entities;

namespace MobileStoreManager.Repository.Interfaces
{
    public interface IUsersRepository
    {
        Users Login(Users users);
        int AddUser(Users users);

        int DeleteUser(int userId);
    }
}
