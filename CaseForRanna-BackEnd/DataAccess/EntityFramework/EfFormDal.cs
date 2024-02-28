using CaseForRanna_BackEnd.DataAccess.Abstract;
using CaseForRanna_BackEnd.DataAccess.Context;
using CaseForRanna_BackEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseForRanna_BackEnd.DataAccess.EntityFramework
{
    public class EfFormDal : GenericDal<Form>, IFormDal
    {

        private readonly DbContextForCase _db;

        public EfFormDal(DbContextForCase dbContextForCase) : base(dbContextForCase)
        {
            _db = dbContextForCase;
        }

        public async Task<List<Form>> GetByUserNameAsync(string UserName)
        {
            return await _db.Forms.Where(x => x.User.Username == UserName).ToListAsync();
        }
    }
}
