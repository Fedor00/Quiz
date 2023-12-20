using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers.Entities;

namespace API.Controllers.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllAsync();
        Task<Question> GetByIdAsync(long id);
        Task AddAsync(Question question);
        Task UpdateAsync(Question question);
        Task DeleteAsync(long id);
        Task SaveAsync();
    }
}
