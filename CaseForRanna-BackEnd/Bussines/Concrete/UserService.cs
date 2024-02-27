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
    }
}
