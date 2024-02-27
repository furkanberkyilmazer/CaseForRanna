using CaseForRanna_BackEnd.Entities;

namespace CaseForRanna_BackEnd.Bussines.Abstract
{
    public interface IUserService : IGenericService<User>
    {
        Task<List<User>> GetByRoleIdAsync(int RoleId);
        Task<User> LoginAsync(string UserName, string Password);
        Task<User> GetByUserNameAsync(string UserName);


    }
}
