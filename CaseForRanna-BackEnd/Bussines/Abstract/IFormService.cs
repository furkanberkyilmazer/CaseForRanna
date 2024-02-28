using CaseForRanna_BackEnd.Entities;

namespace CaseForRanna_BackEnd.Bussines.Abstract
{
    public interface IFormService : IGenericService<Form>
    {
        Task<List<Form>> GetByUserNameAsync(string UserName);

    }
}
