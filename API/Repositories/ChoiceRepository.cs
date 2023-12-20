using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Entities;
using API.Controllers.Interfaces;
using ChatMicroservice.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Repositories
{
    public class ChoiceRepository : IChoiceRepository
    {
        private readonly DataContext _context;

        public ChoiceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Choice>> GetAllAsync()
        {
            return await _context.Choices.ToListAsync();
        }

        public async Task<Choice> GetByIdAsync(long id)
        {
            return await _context.Choices.FindAsync(id);
        }

        public async Task<IEnumerable<Choice>> GetChoicesByQuestionIdAsync(long questionId)
        {
            return await _context.Choices
                .Where(c => c.QuestionId == questionId)
                .ToListAsync();
        }

        public async Task AddAsync(Choice choice)
        {
            _context.Choices.Add(choice);
            await SaveAsync();
        }

        public async Task UpdateAsync(Choice choice)
        {
            _context.Entry(choice).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var choice = await _context.Choices.FindAsync(id);
            if (choice != null)
            {
                _context.Choices.Remove(choice);
                await SaveAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
