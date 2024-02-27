using CaseForRanna_BackEnd.DataAccess.Abstract;
using CaseForRanna_BackEnd.DataAccess.Context;
using CaseForRanna_BackEnd.Entities;

namespace CaseForRanna_BackEnd.DataAccess.EntityFramework
{
    public class EfUserRoleDal : GenericDal<UserRole>, IUserRoleDal
    {
        private readonly DbContextForCase _db;

        public EfUserRoleDal(DbContextForCase dbContextForCase) : base(dbContextForCase)
        {
               _db = dbContextForCase;
        }
    }
}
