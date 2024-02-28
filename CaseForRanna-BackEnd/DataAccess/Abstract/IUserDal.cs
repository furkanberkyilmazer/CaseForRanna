using CaseForRanna_BackEnd.Entities;

namespace CaseForRanna_BackEnd.DataAccess.Abstract
{
    public interface IUserDal : IGenericDal<User>
    {
        Task<List<User>> GetByRoleIdAsync(int RoleId);

        Task<User> GetByUserNameAsync(string UserName);

        Task<User> LoginAsync(string UserName, string Password);

    }
}
