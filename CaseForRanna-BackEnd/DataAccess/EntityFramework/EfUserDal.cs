using CaseForRanna_BackEnd.DataAccess.Abstract;
using CaseForRanna_BackEnd.DataAccess.Context;
using CaseForRanna_BackEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseForRanna_BackEnd.DataAccess.EntityFramework
{
    public class EfUserDal : GenericDal<User>, IUserDal
    {
        private readonly DbContextForCase _db;

        public EfUserDal(DbContextForCase dbContextForCase) : base(dbContextForCase)
        {
            _db = dbContextForCase;
        }

        public async Task<List<User>> GetByRoleIdAsync(int RoleId)
        {
          return  await  _db.Users.Where(x=>x.UserRoleId==RoleId).ToListAsync();
        }
    }
}
