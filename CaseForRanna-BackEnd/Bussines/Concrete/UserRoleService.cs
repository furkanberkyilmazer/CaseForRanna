using CaseForRanna_BackEnd.Bussines.Abstract;
using CaseForRanna_BackEnd.DataAccess.Abstract;
using CaseForRanna_BackEnd.DataAccess.UnitOfWork;
using CaseForRanna_BackEnd.Entities;

namespace CaseForRanna_BackEnd.Bussines.Concrete
{
    public class UserRoleService : GenericService<UserRole>, IUserRoleService
    {
        private readonly IUserRoleDal _userRoleDal;
        private readonly IUnitOfWork _unitofWork;
        public UserRoleService(IUserRoleDal userRoleDal, IUnitOfWork unitofWork) : base(userRoleDal, unitofWork)
        {
            _userRoleDal = userRoleDal;
            _unitofWork = unitofWork;
        }
    }
}
