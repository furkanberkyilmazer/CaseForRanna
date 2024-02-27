using CaseForRanna_BackEnd.DataAccess.Abstract;
using CaseForRanna_BackEnd.DataAccess.Context;
using CaseForRanna_BackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<User> GetByUserNameAsync(string userName)
        {
            User user=await _db.Users.Where(x=>x.Username== userName).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> LoginAsync(string UserName , string Password)
        {

           var user= await _db.Users.Where(x => x.Username == UserName && x.Password==Password).Include(x => x.UserRole).FirstOrDefaultAsync();

         
                return user;
         
        }
    }
}
