using MobileStoreManager.Entities;
using MobileStoreManager.Entities.DTO;

namespace MobileStoreManager.Services.Interfaces
{
    public interface IUsersService
    {
        LoginOutputDTO Login(Users users);
        int AddUser(Users users);

        int DeleteUser(int userId);
    }
}
