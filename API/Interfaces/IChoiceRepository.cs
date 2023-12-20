using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Entities;

namespace API.Controllers.Interfaces
{
     public interface IChoiceRepository
    {
        Task<IEnumerable<Choice>> GetAllAsync();
        Task<Choice> GetByIdAsync(long id);
        Task AddAsync(Choice choice);
        Task UpdateAsync(Choice choice);
        Task DeleteAsync(long id);
        Task<IEnumerable<Choice>> GetChoicesByQuestionIdAsync(long questionId);
        Task SaveAsync(); 
    }
}