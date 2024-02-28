using CaseForRanna_BackEnd.Entities;

namespace CaseForRanna_BackEnd.DataAccess.Abstract
{
    public interface IFormDal : IGenericDal<Form>
    {
        Task<List<Form>> GetByUserNameAsync(string UserName);
        Task<Form> GetByIdWithUserAsync(int Id);
        Task<List<Form>> GetAllWithUserAsync();

    }
}
