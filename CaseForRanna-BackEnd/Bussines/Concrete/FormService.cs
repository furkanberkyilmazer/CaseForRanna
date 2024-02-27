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
    }
}
