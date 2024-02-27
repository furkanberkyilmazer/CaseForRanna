using CaseForRanna_BackEnd.Bussines.Abstract;
using CaseForRanna_BackEnd.DataAccess.Abstract;
using CaseForRanna_BackEnd.DataAccess.UnitOfWork;
using CaseForRanna_BackEnd.Entities;

namespace CaseForRanna_BackEnd.Bussines.Concrete
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IUnitOfWork _unitofWork;
        public UserService(IUserDal userDal, IUnitOfWork unitofWork) : base(userDal, unitofWork)
        {
            _userDal = userDal;
            _unitofWork = unitofWork;
        }

        public async Task<List<User>> GetByRoleIdAsync(int RoleId)
        {
            return await _userDal.GetByRoleIdAsync(RoleId);
        }

        public async Task<User> GetByUserNameAsync(string UserName)
        {
           return await _userDal.GetByUserNameAsync(UserName);
        }

        public async Task<User> LoginAsync(string UserName, string Password)
        {
            return await _userDal.LoginAsync(UserName,Password);
        }
    }
}
