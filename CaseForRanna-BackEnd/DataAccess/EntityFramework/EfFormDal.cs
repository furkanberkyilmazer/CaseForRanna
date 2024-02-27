using CaseForRanna_BackEnd.DataAccess.Abstract;
using CaseForRanna_BackEnd.DataAccess.Context;
using CaseForRanna_BackEnd.Entities;

namespace CaseForRanna_BackEnd.DataAccess.EntityFramework
{
    public class EfFormDal : GenericDal<Form>, IFormDal
    {

        private readonly DbContextForCase _db;

        public EfFormDal(DbContextForCase dbContextForCase) : base(dbContextForCase)
        {
            _db = dbContextForCase;
        }
    }
}
