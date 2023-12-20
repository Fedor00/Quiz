using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Entities;
using API.Controllers.Interfaces;
using ChatMicroservice.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DataContext _context;

        public QuestionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Questions.Include(q => q.Answer).Include(q=>q.Choices).ToListAsync();
        }

        public async Task<Question> GetByIdAsync(long id)
        {
            return await _context.Questions
                .Include(q => q.Answer)
                .Include(c => c.Choices)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task AddAsync(Question question)
        {
            _context.Questions.Add(question);
            await SaveAsync();
        }

        public async Task UpdateAsync(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                await SaveAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
