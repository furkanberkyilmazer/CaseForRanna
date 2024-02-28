using CaseForRanna_BackEnd.Bussines.Abstract;
using CaseForRanna_BackEnd.DataAccess.Abstract;
using CaseForRanna_BackEnd.DataAccess.UnitOfWork;
using CaseForRanna_BackEnd.Entities;

namespace CaseForRanna_BackEnd.Bussines.Concrete
{
    public class FormService : GenericService<Form>, IFormService
    {
        private readonly IFormDal _formDal;
        private readonly IUnitOfWork _unitofWork;

        public FormService(IFormDal formDal, IUnitOfWork unitofWork) : base(formDal, unitofWork)
        {
            _formDal = formDal;
            _unitofWork = unitofWork;
        }

        public async Task<List<Form>> GetAllWithUserAsync()
        {
            return await _formDal.GetAllWithUserAsync();
        }

        public async Task<Form> GetByIdWithUserAsync(int Id)
        {
            return await _formDal.GetByIdWithUserAsync(Id);
        }

        public async Task<List<Form>> GetByUserNameAsync(string UserName)
        {
            return await _formDal.GetByUserNameAsync(UserName);
        }
    }
}
